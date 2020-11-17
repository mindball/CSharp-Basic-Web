using SUS.HTTP;
using System;
using System.Collections.Generic;
using System.Text;

namespace SUS.MvcFramework.Attributes
{
    public abstract class BaseHttpAttribute : Attribute
    {
        //public string ActionName { get; set; }

        //public string Url { get; set; }

        //public abstract HttpMethod Method { get; set; }

        public string Url { get; set; }

        public abstract HttpMethod Method { get; }
    }
}
