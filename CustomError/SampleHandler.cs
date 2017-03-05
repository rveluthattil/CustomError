using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace CustomError
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
    public abstract class SampleHandler : FilterAttribute, IExceptionFilter
    {
        Type exceptionType = typeof(Exception);
        int statusCode = 404;
        string viewName = "Error";

        public SampleHandler(Type exceptionType, int statusCode, string viewName)
        {
            this.exceptionType = exceptionType;
            this.statusCode = statusCode;
            this.viewName = viewName;
        }
        public void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled) return;
            if (!filterContext.HttpContext.IsCustomErrorEnabled) return;
            if (filterContext.Exception == null) return;

            var exception = filterContext.Exception;
            if (exception is TargetInvocationException)
                exception = (exception as TargetInvocationException).InnerException;

            if (!exceptionType.IsInstanceOfType(exception)) return;
            filterContext.Result = new ViewResult
            {
                ViewData = filterContext.Controller.ViewData,
                TempData = filterContext.Controller.TempData,
                ViewName = viewName
            };


            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.Clear();
            filterContext.HttpContext.Response.StatusCode = statusCode;
            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;

            OnExceptionHandled(filterContext);
        }

        protected virtual void OnExceptionHandled(ExceptionContext filterContext)
        {

        }
    }
}