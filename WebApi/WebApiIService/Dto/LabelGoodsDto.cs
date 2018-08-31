using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiIService.Dto
{
    /// <summary>
    /// 关联商品与标签
    /// </summary>
    public class LabelGoodsDto
    {
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
