using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebApiRepository.Entity
{
    /// <summary>
    /// 商品标签实体类
    /// </summary>
    [Table("label")]
    public class LabelRepo
    {
        /// <summary>
        /// 商品标签id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 商品标签名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 商品标签是否删除
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
