using System;
using System.Collections.Generic;
using System.Text;

namespace DouCalendarService.Contracts.Attributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
    public sealed class XPathLocationAttribute : Attribute
    {
        public XPathLocationAttribute(string location)
        {
            Location = location;
        }

        public string Location { get; set; }
    }
}
