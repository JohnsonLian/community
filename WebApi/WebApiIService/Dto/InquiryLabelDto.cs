using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebApiIService.Dto
{
    /// <summary>
    /// 查询商品标签模型
    /// </summary>
    public class InquiryLabelDto
    {
        /// <summary>
        /// 商品标签id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 商品标签名称
        /// </summary>
        public string Name { get; set; }
    }
}
