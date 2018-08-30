using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    /// <summary>
    /// 商品标签Model
    /// </summary>
    public class UpdateModel
    {
        /// <summary>
        /// 商品标签id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 商品标签名称
        /// </summary>
        [Required, MaxLength(100)]
        public string Name { get; set; }
    }
}
