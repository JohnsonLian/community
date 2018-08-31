using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebApiRepository.Entity
{
    /// <summary>
    /// 商品标签商品关联表实体类
    /// </summary>
    [Table("label_goods")]
    public class LabelGoodsRepo
    {
        /// <summary>
        /// 商品标签商品关联表id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 商品id
        /// </summary>
        public int Goods_id { get; set; }
        /// <summary>
        /// 商品标签id
        /// </summary>
        public int Label_id { get; set; }
    }
}
