using GiaoHang.Common;
using System.Web.Mvc;

namespace ShoeStore.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            //RouteItem.adminRoutes.Add(new RouteItem("Tên route", "đường dẫn", "Controller", "Action"));
            foreach (var item in RouteItem.adminRoutes)
            {
                context.MapRoute(
                    name: item.Name,
                    url: item.Url,
                    defaults: new { controller = item.Controler, action = item.Action, id = UrlParameter.Optional }
                );
            }


            //Route mặc định
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}