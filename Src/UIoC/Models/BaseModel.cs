using System;

namespace UIoC.Models {
  internal class BaseModel {
    public Type ResolveType { get; }
    public string ResolveName { get; }
    public string ResolveKey { get; }
    public BaseModel(Type resolveType, string resolveName) {
      ResolveType = resolveType;
      ResolveName = resolveName;
      ResolveKey =
        (ResolveType != null ? $"{nameof(ResolveType)} = '{ResolveType.FullName}'" : "") +
        (" ") +
        (ResolveName != null ? $"{nameof(ResolveName)} = '{ResolveName}'" : "");
    }
  }
}
