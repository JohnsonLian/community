using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WebApiRepository.Enum
{
    /// <summary>
    /// 商品状态类型 待上架 1，已上架 2，已下架 3
    /// </summary>
    public enum StateType
    {
        /// <summary>
        /// 待上架
        /// </summary>
        [Description("待上架")]
        BeforePutaway = 1,
        /// <summary>
        /// 已上架
        /// </summary>
        [Description("已上架")]
        Putaway = 2,
        /// <summary>
        /// 已下架
        /// </summary>
        [Description("已下架")]
        Soldout = 3,
    }
}
