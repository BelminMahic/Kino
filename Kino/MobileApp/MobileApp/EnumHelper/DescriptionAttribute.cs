using System;

namespace MobileApp.EnumHelper
{
    public class DescriptionAttribute : Attribute
    {
        public string Name { get; private set; }

        public DescriptionAttribute(string name)
        {
            Name = name;
        }
    }
}
