using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebApiIService.Dto
{
    /// <summary>
    /// 修改商品模型
    /// </summary>
    public class UpdateGoodsDto
    {
        /// <summary>
        /// 商品id
        /// </summary>
        public int Id { get; set; }
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
        public int[] Tags { get; set; }
    }
}
