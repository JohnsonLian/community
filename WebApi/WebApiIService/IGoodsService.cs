using System;
using System.Collections.Generic;
using System.Text;
using WebApiIService.Dto;
using WebApiRepository.Entity;

namespace WebApiIService
{
    public interface IGoodsService
    {
        /// <summary>
        /// 新增商品
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool Create(CreateGoodsDto dto);
        /// <summary>
        /// 删除商品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);
        /// <summary>
        /// 修改商品
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool Update(UpdateGoodsDto dto);
        /// <summary>
        /// 搜索商品
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        List<GoodsRepo> GetList(SearchGoodsDto dto);
        /// <summary>
        /// 上架商品
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool UpStack(int [] id);
        /// <summary>
        /// 下架商品
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool DownStack(int[] id);
        /// <summary>
        /// 查询商品详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        GoodsDetailDto GetDetail(int id);
    }
}
