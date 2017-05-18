using System;
using DotnetCode.Controller.Base;
using DotnetCore.Model.Transfer;
using DotnetCore.Service;
//using DotnetCore.Code.Code;
using Microsoft.AspNetCore.Mvc;

namespace DotnetCode.Controller.Permission
{
    /// <summary>
    /// 菜单控制器
    /// </summary>
    public class MenuController : BaseController
    {
        /// <summary>
        /// 菜单列表
        /// </summary>
        /// <returns>视图</returns>
        public IActionResult MenuList()
        {
            return this.View();
        }

        /// <summary>
        /// 查询菜单列表
        /// </summary>
        /// <returns>结果</returns>
        [HttpPost]
        public IActionResult QueryMenuList()
        {
            var data = MenuService.QueryZtreeMenus();
            return this.MyJson(data);
        }

        /// <summary>
        /// 查询菜单列表
        /// </summary>
        /// <param name="menuId">菜单Id</param>
        /// <returns>结果</returns>
        [HttpPost]
        public IActionResult QueryMenuById([FromQuery]Guid menuId)
        {
            var data = MenuService.QueryMenuById(menuId);
            return this.MyJson(data);
        }

        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="menuId">菜单</param>
        /// <returns>结果</returns>
        [HttpPost]
        public IActionResult RemoveMenu([FromQuery]Guid menuId)
        {
            var data = MenuService.RemoveMenu(menuId, null);
            return this.MyJson(data);
        }

        /// <summary>
        /// 添加菜单
        /// </summary>
        /// <param name="tMenu">菜单</param>
        /// <returns>结果</returns>
        [HttpPost]
        public IActionResult AddMenu([FromBody]TMenu tMenu)
        {
            var data = MenuService.AddMenu(tMenu, null);
            return this.MyJson(data);
        }

        /// <summary>
        /// 修改菜单
        /// </summary>
        /// <param name="tMenu">菜单</param>
        /// <returns>结果</returns>
        [HttpPost]
        public IActionResult UpdateMenu([FromBody]TMenu tMenu)
        {
            var data = MenuService.UpdateMenu(tMenu, null);
            return this.MyJson(data);
        }
    }
}