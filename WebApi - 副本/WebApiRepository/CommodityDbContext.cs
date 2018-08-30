
using Microsoft.EntityFrameworkCore;
using System;
using WebApiRepository.Entity;

namespace WebApiRepository
{
    /// <summary>
    /// 构造的 DbContext
    /// </summary>
    public class CommodityDbContext : DbContext
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="options"></param>
        //public CommodityDbContext(DbContextOptions options) : base(options)
        //{

        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql(@"server=localhost;port=3306;Initial Catalog=commodity;user id=root;password=123456;ConnectionReset=false;SslMode = none;");
        /// <summary>
        /// 商品
        /// </summary>
        public DbSet<GoodsRepo> GoodsRepos { get; set; }
        /// <summary>
        /// 商品标签
        /// </summary>
        public DbSet<LabelRepo> LabelRepos { get; set; }
        /// <summary>
        /// 商品标签商品
        /// </summary>
        public DbSet<LabelGoodsRepo> LabelGoodsRepos { get; set; }



    }
}
