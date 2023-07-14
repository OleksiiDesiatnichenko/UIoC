using System;

namespace UIoC.Models {
  internal class TypeModel : BaseModel {
    public Type ActualType { get; }
    public TypeModel(Type resolveType, string resolveName, Type actualType)
      : base(resolveType, resolveName) {
      ActualType = actualType;
    }
  }
}
