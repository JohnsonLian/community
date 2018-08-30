using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApiIService;
using WebApiIService.Dto;
using WebApiRepository.Entity;
using WebApiService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Api
{
    /// <summary>
    /// 商品的webapi
    /// </summary>
    [Route("api/[controller]")]
    public class GoodsController : Controller
    {
        private readonly IGoodsService _service;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="goodsService"></param>
        public GoodsController(IGoodsService goodsService)
        {
            _service = goodsService;
        }

        // GET: api/<controller>
        /// <summary>
        /// 查询商品的详情
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetDetail")]
        public GoodsDetailDto GetDetail(int id)
        {
            return _service.GetDetail(id);
        }

        /// <summary>
        /// 搜索商品
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetList")]
        public List<GoodsRepo> GetListForSelect(SearchGoodsModel dto)
        {
            //标签id获取出错，请求失败
            if (dto.Label_id < 0)
            {
                throw new Exception("请求失败");
            }
            //商品状态获取出错，请求失败,0表示全部状态，1表示待上架，2表示已上架，3表示已下架
            if (dto.State != 0 && dto.State != 1 && dto.State != 2 && dto.State != 3)
            {
                throw new Exception("请求失败");
            }
            return _service.GetListForSelect(new SearchGoodsDto
            {
                Name = dto.Name,
                Label_id = dto.Label_id,
                State = dto.State,
                Page = dto.Page,
                PageSize = dto.PageSize
            });
        }

        // POST api/<controller>
        /// <summary>
        /// 新增商品
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Create")]
        public bool Create(CreateGoodsModel dto)
        {
            //商品价格为非正数，抛出异常
            if (dto.Price <= 0)
            {
                throw new Exception("商品价格不能为非正数");
            }
            //若标签大于5个，抛出异常
            if (dto.Tags == null) dto.Tags = new List<int>();
            if (dto.Tags.Count > 5)
            {
                throw new Exception("商品的标签数不能大于5个");
            }
            return _service.Create(new CreateGoodsDto
            {
                Number = dto.Number,
                Name = dto.Name,
                Price = dto.Price,
                Describe = dto.Describe,
                Tags = dto.Tags
            });
        }

        /// <summary>
        /// 上架商品
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UpStack")]
        public bool UpStack(List<int> ids)
        {
            if (ids == null)
            {
                throw new Exception("请求失败");
            }
            return _service.UpStack(ids);
        }

        /// <summary>
        /// 下架商品
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("DownStack")]
        public bool DownStack(List<int> ids)
        {
            if (ids == null)
            {
                throw new Exception("请求失败");
            }
            return _service.DownStack(ids);
        }

        /// <summary>
        /// 修改商品
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Update")]
        public bool Update(UpdateGoodsModel dto)
        {
            //若商品价格为非正数，返回false
            if (dto.Price <= 0)
            {
                throw new Exception("商品价格不能为非正数");
            }
            //若标签大于5个，返回false
            if (dto.Tags == null) dto.Tags = new List<int>();
            if (dto.Tags.Count > 5)
            {
                throw new Exception("商品的标签数不能大于5个");
            }
            return _service.Update(new UpdateGoodsDto
            {
                Id = dto.Id,
                Name = dto.Name,
                Price = dto.Price,
                Describe = dto.Describe,
                Tags = dto.Tags
            });
        }

        /// <summary>
        /// 删除商品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Delete")]
        public bool Delete(int id)
        {
            return _service.Delete(id);
        }
    }
}
