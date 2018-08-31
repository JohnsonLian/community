using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WebApiRepository.Enum;

namespace WebApiRepository.Entity
{
    /// <summary>
    /// 商品实体类
    /// </summary>
    [Table("Goods")]
    public class GoodsRepo
    {
        /// <summary>
        /// 商品id
        /// </summary>
        public int Id { get; set; }
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
        /// 商品拼音
        /// </summary>
        public string Pinyin { get; set; }
        /// <summary>
        /// 商品单价
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 商品描述
        /// </summary>
        public string Describe { get; set; }
        /// <summary>
        /// 商品状态
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Createtime { get; set; }
        /// <summary>
        /// 最近更新时间
        /// </summary>
        public DateTime Updatetime { get; set; }
    }
}
