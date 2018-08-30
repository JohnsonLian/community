using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApiRepository;
using WebApiRepository.Entity;
using WebApiIService;
using WebApiIService.Dto;

namespace WebApiService.Impl
{
    public class LabelService : BaseService<LabelRepo>, ILabelService
    {
        /// <summary>
        /// 新增商品标签
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool Create(String name)
        {
            using (var commodityDbContext = new CommodityDbContext())
            {
                //若重名，抛出异常
                if (commodityDbContext.LabelRepos.Any(o => o.Name == name))
                {
                    throw new Exception("标签已存在");
                }
                commodityDbContext.LabelRepos.Add(new LabelRepo()
                {
                    Name = name,
                });
                return commodityDbContext.SaveChanges() > 0;
            }
        }
        /// <summary>
        /// 删除商品标签
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            using (var commodityDbContext = new CommodityDbContext())
            {
                var entity = commodityDbContext.LabelRepos.Where(o => o.Id == id).FirstOrDefault();
                if (entity == null)
                {
                    throw new Exception("标签不存在");
                }
                entity.IsDeleted = true;
                return commodityDbContext.SaveChanges() > 0;
            }
        }
        /// <summary>
        /// 修改商品标签
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool Update(UpdateLabelDto dto)
        {
            using (var commodityDbContext = new CommodityDbContext())
            {
                //若重名，抛出异常
                if (commodityDbContext.LabelRepos.Any(o => o.Name == dto.Name))
                {
                    throw new Exception("标签名重复");
                }
                var entity = commodityDbContext.LabelRepos.Where(o => o.Id == dto.Id).FirstOrDefault();
                if (entity == null)
                {
                    throw new Exception("未选择标签");
                }
                entity.Name = dto.Name;
                return commodityDbContext.SaveChanges() > 0;
            }
        }
        /// <summary>
        /// 查询商品标签
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public List<InquiryLabelDto> GetList()
        {
            using (var commodityDbContext = new CommodityDbContext())
            {
                //查询未被删除的商品标签
                var result = commodityDbContext.LabelRepos.Where(o => o.IsDeleted == false)
                .Select(o => new InquiryLabelDto()
                {
                    Id = o.Id,
                    Name = o.Name,
                }).ToList();
                return result;
            }
        }
    }
}
