using System;
using System.Collections.Generic;
using System.Text;
using WebApiIService.Dto;

namespace WebApiService.Tool
{
    /// <summary>
    /// 去除list中的重复元素
    /// </summary>
    public class LabelCompareByGoods_id : IEqualityComparer<LabelGoodsDto>
    {
        public bool Equals(LabelGoodsDto x, LabelGoodsDto y)
        {
            if (x == null || y == null)
                return false;
            if (x.Goods_id == y.Goods_id)
                return true;
            else
                return false;
        }

        public int GetHashCode(LabelGoodsDto obj)
        {
            if (obj == null)
                return 0;
            else
                return obj.Goods_id.GetHashCode();
        }
    }
}
