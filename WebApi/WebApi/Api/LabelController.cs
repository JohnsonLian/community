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
        [Route("GetLabel")]
        public List<InquiryLabelDto> GetLabel()
        {
            return _service.Inquiry();
        }

        // POST api/<controller>
        /// <summary>
        /// 新增商品标签
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("CreateLabel")]
        public bool CreateLabel(String name)
        {
            return _service.Create(name);
        }

        // PUT api/<controller>
        /// <summary>
        /// 修改商品标签
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateLabel")]
        public bool UpdateLabel(LabelModel dto)
        {
            return _service.Edit(new EditLabelDto
            {
                Id = dto.Id,
                Name = dto.Name
            });
        }

        // DELETE api/<controller>
        /// <summary>
        /// 删除商品标签
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteLabel")]
        public bool DeleteLabel(int id)
        {
            return _service.Delete(id);
        }
    }
}
