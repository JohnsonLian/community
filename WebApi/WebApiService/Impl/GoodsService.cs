﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApiIService;
using WebApiIService.Dto;
using WebApiRepository;
using WebApiRepository.Entity;
using WebApiService.Tool;

namespace WebApiService.Impl
{
    public class GoodsService : BaseService<GoodsRepo>, IGoodsService
    {
        private readonly CommodityDbContext commodityDbContext;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="commodityDbContext"></param>
        public GoodsService(CommodityDbContext commodityDbContext)
        {
            this.commodityDbContext = commodityDbContext;
        }
        /// <summary>
        /// 添加商品
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool Create(CreateGoodsDto dto)
        {
            var tran = commodityDbContext.Database.BeginTransaction();
            try
            {
                dto.Price = System.Decimal.Round(System.Decimal.Floor(dto.Price * 100) / 100, 2);
                //若商品编号重复，返回false
                if (commodityDbContext.GoodsRepos.Any(o => o.Number == dto.Number))
                {
                    throw new Exception("商品编号重复");
                }
                //判断标签的id是否存在
                if (commodityDbContext.LabelRepos.Where(o => dto.Tags.Contains(o.Id)).Count() != dto.Tags.Count)
                {
                    throw new Exception("有标签不存在");
                }
                GoodsRepo goods = new GoodsRepo()
                {
                    Number = dto.Number,
                    Name = dto.Name,
                    Pinyin = PinYin.ConvertCh(dto.Name).ToLower(),
                    Price = dto.Price,
                    Describe = dto.Describe,
                    State = "待上架",
                    Updatetime = DateTime.Now
                };
                commodityDbContext.GoodsRepos.Add(goods);
                commodityDbContext.SaveChanges();
                //往label_goods表中添加该商品的标签
                foreach (var Tag in dto.Tags)
                {
                    commodityDbContext.LabelGoodsRepos.Add(new LabelGoodsRepo()
                    {
                        Goods_id = goods.Id,
                        Label_id = Tag
                    });
                }
                return commodityDbContext.SaveChanges()>0;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw ex;
            }
        }
        /// <summary>
        /// 删除商品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            var tran = commodityDbContext.Database.BeginTransaction();
            try
            {
                //判断商品是否存在
                if (commodityDbContext.GoodsRepos.Any(o => o.Id == id))
                {
                    throw new Exception("商品不存在");
                }
                //在Goods表里删除商品
                commodityDbContext.Database.ExecuteSqlCommand(@"delete from goods where id = @p0", id);
                //在label_goods表里删除记录
                commodityDbContext.Database.ExecuteSqlCommand(@"delete from label_goods where goods_id = @p0", id);
                return commodityDbContext.SaveChanges() > 0;

                ////在Goods表里删除商品
                //var entity = commodityDbContext.GoodsRepos.Where(o => o.Id == id).FirstOrDefault();
                //if (entity == null)
                //{
                //    throw new Exception("商品不存在");
                //}
                //commodityDbContext.GoodsRepos.Remove(entity);
                ////在label_goods表里删除记录
                //var result = commodityDbContext.LabelGoodsRepos.Where(o => o.Goods_id == id).ToList();
                //commodityDbContext.LabelGoodsRepos.RemoveRange(result);
                //return commodityDbContext.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw ex;
            }
        }
        /// <summary>
        /// 修改商品
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool Update(UpdateGoodsDto dto)
        {
            var tran = commodityDbContext.Database.BeginTransaction();
            try
            {
                dto.Price = System.Decimal.Round(System.Decimal.Floor(dto.Price * 100) / 100, 2);
                //判断标签的id是否存在
                if (commodityDbContext.LabelRepos.Where(o => dto.Tags.Contains(o.Id)).Count() != dto.Tags.Count)
                {
                    throw new Exception("有标签不存在");
                }
                //修改Goods表
                var entity = commodityDbContext.GoodsRepos.Where(o => o.Id == dto.Id).FirstOrDefault();
                if (entity == null)
                {
                    throw new Exception("商品不存在");
                }
                entity.Name = dto.Name;
                entity.Pinyin = PinYin.ConvertCh(dto.Name).ToLower();
                entity.Price = dto.Price;
                entity.Describe = dto.Describe;
                //删除label_goods表中所有与该商品有关的记录
                //commodityDbContext.Database.ExecuteSqlCommand(@"delete from label_goods where goods_id = @p0", dto.Id);
                var result = commodityDbContext.LabelGoodsRepos.Where(o => o.Goods_id == dto.Id).ToList();
                commodityDbContext.LabelGoodsRepos.RemoveRange(result);
                //往label_goods表中添加该商品的标签
                foreach(var Tag in dto.Tags)
                {
                    commodityDbContext.LabelGoodsRepos.Add(new LabelGoodsRepo()
                    {
                        Goods_id = entity.Id,
                        Label_id = Tag
                    });
                }
                return commodityDbContext.SaveChanges()>0;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw ex;
            }
        }
        /// <summary>
        /// 下架商品
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool DownStack(List<int> ids)
        {
            var entitys = commodityDbContext.GoodsRepos.Where(o => ids.Contains(o.Id)).ToList();
            if(entitys.Count != ids.Count)
            {
                throw new Exception("商品不存在");
            }
            foreach(var entity in entitys)
            {
                if(entity.State == "已上架")
                {
                    entity.State = "已下架";
                }
                else
                {
                    throw new Exception("已下架，不要重复下架");
                }
            }
            return commodityDbContext.SaveChanges()>0;
        }
        /// <summary>
        /// 上架商品
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool UpStack(List<int> ids)
        {
            var entitys = commodityDbContext.GoodsRepos.Where(o => ids.Contains(o.Id)).ToList();
            if (entitys.Count != ids.Count)
            {
                throw new Exception("商品不存在");
            }
            foreach (var entity in entitys)
            {
                if (entity.State == "待上架" || entity.State == "已下架")
                {
                    entity.State = "已上架";
                }
                else
                {
                    throw new Exception("已上架，不要重复上架");
                }
            }
            return commodityDbContext.SaveChanges() > 0;
        }
        /// <summary>
        /// 查询商品详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public GoodsDetailDto GetDetail(int id)
        {
            //获取商品信息
            var entity = commodityDbContext.GoodsRepos.Where(o => o.Id == id).Select(o => new GoodsDetailDto()
            {
                Id = o.Id,
                Number = o.Number,
                Name = o.Name,
                Price = o.Price,
                Describe = o.Describe,
                State = o.State,
                Createtime = o.Createtime,
                Updatetime = o.Updatetime
            }).FirstOrDefault();
            if (entity == null)
            {
                throw new Exception("未选择商品");
            }
            //获取该商品的标签id
            var results = commodityDbContext.LabelGoodsRepos.Where(o => o.Goods_id == id).Select(o => new LabelGoodsDto()
            {
                Goods_id = o.Goods_id,
                Label_id = o.Label_id
            }).ToList();
            //获取标签名
            var str = new List<string>();
            foreach(var result in results)
            {
                var temp = commodityDbContext.LabelRepos.Where(o => o.Id == result.Label_id).Select(o => new InquiryLabelDto()
                {
                    Id = o.Id,
                    Name = o.Name
                }).FirstOrDefault();
                str.Add(temp.Name);
            }
            entity.Tags = str;
            return entity;
        }

        /// <summary>
        /// 搜索商品
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public List<GoodsRepo> GetList(SearchGoodsDto dto)
        {
            var result = new List<GoodsRepo>();
            var name = new MySqlParameter();
            var sel = "select goods.id,goods.number,goods.name,goods.pinyin,goods.price,goods.describe,goods.state,goods.createtime,goods.updatetime";
            var from = " from goods";
            var where = " where 1=1 ";
            var order = $" order by goods.updatetime desc limit {(dto.Page - 1) * dto.PageSize},{dto.PageSize}";
            if (dto.Label_id > 0)
            {
                from = from + @" inner join label_goods on goods.id = label_goods.goods_id ";
                where = where + $" and label_goods.label_id={dto.Label_id}";
            }
            if (dto.State != 0)
            {
                where = where + $" and goods.state={dto.State}";
            }
            if (dto.Name != null)
            {
                dto.Name = dto.Name.Split(' ').Join("");//去空格
                name = new MySqlParameter("@name", "%" + dto.Name + "%");
                where = where + $" and (goods.number = @name or goods.name like @name or goods.pinyin like @name)";
            }
            //ef core
            result = commodityDbContext.GoodsRepos.FromSql(sel + from + where + order, name).ToList();
            //ef 6
            //result = commodityDbContext.Database.SqlQuery<InquiryGoodsDto>(sel + from + where + order, name).ToList();
            return result;
        }
    }
}
