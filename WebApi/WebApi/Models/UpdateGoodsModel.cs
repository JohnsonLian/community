using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    /// <summary>
    /// 修改商品Model
    /// </summary>
    public class UpdateGoodsModel
    {
        /// <summary>
        /// 商品id
        /// </summary>
        public int Id { get; set; }
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
        public List<int> Tags { get; set; }
    }
}
