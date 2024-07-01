using Infrastructure.Models.Data.Interface;

namespace UIFactory.Factory.Concrete.Interface
{
    public interface IConcreteUI
    {
        int? DisplayOrder { get; }
        UIConcrete UIConcreteType { get; }
    }
}
