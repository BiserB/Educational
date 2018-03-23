using Logger_Lib.Models.Contracts;
using System;

namespace Logger_Lib.Models.Factories
{
    public class LayoutFactory
    {
        public ILayout Create(string layoutType)
        {
            switch (layoutType)
            {
                case "SimpleLayout":
                    return new SimpleLayout();

                case "XmlLayout":
                    return new XmlLayout();

                default:
                    throw new ArgumentException("Wrong layout type!");
            }
        }
    }
}