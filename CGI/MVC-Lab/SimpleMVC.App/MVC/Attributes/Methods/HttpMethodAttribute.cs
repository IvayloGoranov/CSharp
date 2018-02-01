using System;

namespace SimpleMVC.App.MVC.Attributes.Methods
{
    public abstract class HttpMethodAttribute : Attribute
    {
        public abstract bool IsValid(string requestMethod);
    }
}

