using Infrastructure.Models.Data.Interface;
using UIFactory.Data.HTML.Interface;

namespace UIFactory.Factory.HTML
{
    class HTMLFactory
    {
        // Factory method to create HMTL
        public static IHTML CreateHMTL(IData type)
        {
            switch (type)
            {
                case "A":
                    return new ConcreteProductA();
                case "B":
                    return new ConcreteProductB();
                default:
                    throw new ArgumentException("Invalid product type.");
            }
        }
    }
}
