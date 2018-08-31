using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WebApiRepository.Enum;

namespace WebApiIService.Dto
{
    /// <summary>
    /// 商品详情模型
    /// </summary>
    public class GoodsDetailDto
    {
        /// <summary>
        /// 商品id
        /// </summary>
        public int Id { get; set; }
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
        /// 标签
        /// </summary>
        public List<string> Tags { get; set; }
        /// <summary>
        /// 商品状态
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime Createtime { get; set; }
        /// <summary>
        /// 最近更新时间
        /// </summary>
        public DateTime Updatetime { get; set; }
    }
}
