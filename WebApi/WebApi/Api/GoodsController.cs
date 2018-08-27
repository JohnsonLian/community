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
            return _service.Inquiry(id);
        }

        /// <summary>
        /// 搜索商品
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("SearchGoods")]
        public List<GoodsRepo> SearchGoods(SearchGoodsModel dto)
        {
            return _service.Search(new SearchGoodsDto
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
        [Route("CreateGoods")]
        public bool CreateGoods(GoodsModel dto)
        {
            return _service.Create(new CreateGoodsDto
            {
                Number = dto.Number,
                Name = dto.Name,
                Price = dto.Price,
                Describe = dto.Describe,
                Tag = dto.Tag
            });
        }

        /// <summary>
        /// 上架商品
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Up")]
        public bool Up(UpDownStackModel dto)
        {
            return _service.Stack(new UpDownStackDto
            {
                Id = dto.Id
            });
        }

        /// <summary>
        /// 下架商品
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Down")]
        public bool Down(UpDownStackModel dto)
        {
            return _service.DownStack(new UpDownStackDto
            {
                Id = dto.Id
            });
        }

        // PUT api/<controller>/5
        /// <summary>
        /// 修改商品
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateGoods")]
        public bool UpdateGoods(UpdateGoodsModel dto)
        {
            return _service.Update(new EditGoodsDto
            {
                Id = dto.Id,
                Name = dto.Name,
                Price = dto.Price,
                Describe = dto.Describe,
                Tag = dto.Tag
            });
        }

        // DELETE api/<controller>/5
        /// <summary>
        /// 删除商品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteGoods")]
        public bool DeleteGoods(int id)
        {
            return _service.Delete(id);
        }
    }
}
