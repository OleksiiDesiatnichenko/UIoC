using System;

namespace UIoC.Models {
  internal class FactoryModel : BaseModel {
    public Func<IContainer, Type, string, object> ActualFactory { get; }
    public FactoryModel(Type resolveType, string resolveName, Func<IContainer, Type, string, object> actualFactory)
      : base(resolveType, resolveName) {
      ActualFactory = actualFactory;
    }
  }
}
