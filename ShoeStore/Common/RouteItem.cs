using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GiaoHang.Common
{
    public class RouteItem
    {
        public static List<RouteItem> customerRoutes = new List<RouteItem>();
        public static List<RouteItem> adminRoutes = new List<RouteItem>();
        public RouteItem(string Name, string Url, string Controller)
        {
            this.Name = Name;
            this.Url = Url;
            this.Controler = Controller;
            this.Action = "Index";
        }
        public RouteItem(string Name,string Url,string Controller,string Action)
        {
            this.Name = Name;
            this.Url = Url;
            this.Controler = Controller;
            this.Action = Action;
        }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Controler { get; set; }
        public string Action { get; set; }
    }
}