using System;
using System.ComponentModel.DataAnnotations;
using WebApiRepository.Enum;

namespace WebApi.Models
{
    /// <summary>
    /// 搜索商品Model
    /// </summary>
    public class SearchGoodsModel
    {
        /// <summary>
        /// 搜索框的内容
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 标签id,null表示全部标签
        /// </summary>
        public int? Label_id { get; set; }
        /// <summary>
        /// 1表示待上架，2表示已上架，3表示已下架
        /// </summary>
        public StateType State { get; set; }
        /// <summary>
        /// 当前页数
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// 一页可容纳条数
        /// </summary>
        public int PageSize { get; set; }
    }
}
