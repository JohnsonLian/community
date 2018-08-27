using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebApiIService.Dto
{
    /// <summary>
    /// 新增商品模型
    /// </summary>
    public class CreateGoodsDto
    {
        /// <summary>
        /// 商品编号
        /// </summary>
        public string Number { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 商品单价
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 商品描述
        /// </summary>
        public string Describe { get; set; }
        /// <summary>
        /// 商品标签
        /// </summary>
        public List<int> Tag { get; set; }
    }
}
