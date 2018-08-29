using System;
using System.Collections.Generic;
using System.Text;
using WebApiIService.Dto;

namespace WebApiIService
{
    public interface ILabelService
    {
        /// <summary>
        /// 新增商品标签
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        bool Create(String name);
        /// <summary>
        /// 删除商品标签
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);
        /// <summary>
        /// 修改商品标签
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool Update(UpdateLabelDto dto);
        /// <summary>
        /// 查询商品标签
        /// </summary>
        /// <returns></returns>
        List<InquiryLabelDto> GetList();
    }
}
