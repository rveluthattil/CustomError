using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomError
{
    public class TestSampleHandler : SampleHandler
    {
        public TestSampleHandler(int Order) : base(new Exception().GetType(),404,"test")
        {
            this.Order = Order;
        }

        public TestSampleHandler(Type exceptionType, int statusCode, string viewName) : 
            base(exceptionType, statusCode, viewName)
        {
        }
    }
}