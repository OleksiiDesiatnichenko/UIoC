using System;

namespace UIoC.Models {
  internal class InstanceModel : BaseModel {
    public object ActualInstance { get; }
    public InstanceModel(Type resolveType, string resolveName, object actualInstance)
      : base(resolveType, resolveName) {
      ActualInstance = actualInstance;
    }
  }
}
