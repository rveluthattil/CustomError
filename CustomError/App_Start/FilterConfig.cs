﻿using System.Web;
using System.Web.Mvc;

namespace CustomError
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new TestSampleHandler(1));
        }
    }
}