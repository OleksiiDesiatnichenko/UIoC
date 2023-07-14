using System;

namespace UIoC.Models {
  internal class SingletonModel : BaseModel {
    public Type ActualType { get; }
    public object ActualInstance { get; set; }
    public SingletonModel(Type resolveType, string resolveName, Type actualType)
      : base(resolveType, resolveName) {
      ActualType = actualType;
    }
  }
}
