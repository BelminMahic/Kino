using System;

namespace MobileApp.EnumHelper
{
    public class TitleAttribute : Attribute
    {
        public string Name { get; private set; }

        public TitleAttribute(string name)
        {
            Name = name;
        }
    }
}
