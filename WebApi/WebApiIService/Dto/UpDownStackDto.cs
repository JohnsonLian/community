using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiIService.Dto
{
    /// <summary>
    /// 上架或下架商品
    /// </summary>
    public class UpDownStackDto
    {
        /// <summary>
        /// 要上架或要下架的商品id
        /// </summary>
        public List<int> Id { get; set; }
    }
}
