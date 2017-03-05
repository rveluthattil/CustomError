using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomError.Controllers
{
    //[HandleAppError(ExceptionType= typeof(Exception), Order =2)] - In case you are using the HandleAppError
    [TestSampleHandler(2)]
    public class TestController : Controller
    {
        // GET: Test
        public string Index()
        {
            string strvar = null;
            int loc = strvar.IndexOf("a");
            return strvar;
        }
    }
}