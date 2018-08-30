using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiIService.Dto
{
    /// <summary>
    /// 搜索商品模型
    /// </summary>
    public class SearchGoodsDto
    {
        /// <summary>
        /// 搜索框的内容
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 标签id
        /// </summary>
        public int Label_id { get; set; }
        /// <summary>
        /// 商品状态
        /// </summary>
        public int State { get; set; }
        /// <summary>
        /// 当前页数
        /// </summary>
        public int Page { get; set; }
        /// <summary>
        /// 一页可容纳条数
        /// </summary>
        public int PageSize { get; set; }
    }
}
