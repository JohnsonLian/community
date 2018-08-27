using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    /// <summary>
    /// 商品Model
    /// </summary>
    public class GoodsModel
    {
        /// <summary>
        /// 商品编号
        /// </summary>
        [Required, MaxLength(100)]
        public string Number { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        [Required, MaxLength(100)]
        public string Name { get; set; }
        /// <summary>
        /// 商品单价
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 商品描述
        /// </summary>
        [MaxLength(2000)]
        public string Describe { get; set; }
        /// <summary>
        /// 商品标签
        /// </summary>
        public List<int> Tag { get; set; }
    }
}
