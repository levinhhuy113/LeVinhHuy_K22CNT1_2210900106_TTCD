﻿using System.Web;
using System.Web.Mvc;

namespace LEVINHHUY_K22CNT1_2210900106_PROJECT2
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
