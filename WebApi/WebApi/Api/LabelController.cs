using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApiIService;
using WebApiIService.Dto;
using WebApiService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Api
{
    /// <summary>
    /// 商品标签的webapi
    /// </summary>
    [Route("api/[controller]")]
    public class LabelController : Controller
    {
        private readonly ILabelService _service;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="labelService"></param>
        public LabelController(ILabelService labelService)
        {
            _service = labelService;
        }

        // GET: api/<controller>
        /// <summary>
        /// 查询商品标签
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetList")]
        public List<InquiryLabelDto> GetList()
        {
            return _service.GetList();
        }

        // POST api/<controller>
        /// <summary>
        /// 新增商品标签
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Create")]
        public bool Create(String name)
        {
            return _service.Create(name);
        }

        /// <summary>
        /// 修改商品标签
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Update")]
        public bool Update(UpdateModel dto)
        {
            return _service.Update(new UpdateLabelDto
            {
                Id = dto.Id,
                Name = dto.Name
            });
        }

        /// <summary>
        /// 删除商品标签
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
