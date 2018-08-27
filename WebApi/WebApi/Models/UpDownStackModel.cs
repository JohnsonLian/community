using System;
using System.Collections.Generic;

namespace WebApi.Models
{
    /// <summary>
    /// 要上架或要下架的商品的id
    /// </summary>
    public class UpDownStackModel
    {
        /// <summary>
        /// 要上架或要下架的商品id
        /// </summary>
        public List<int> Id { get; set; }
    }
}
