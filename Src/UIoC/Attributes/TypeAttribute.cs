using System;

namespace UIoC {
  [AttributeUsage(AttributeTargets.Class)]
  public class TypeAttribute : Attribute {
    public TypeAttribute(Type resolveType = null, string resolveName = null) {
      ResolveType = resolveType;
      ResolveName = resolveName;
    }
    public TypeAttribute(string resolveName) : this(null, resolveName) {
    }
    public Type ResolveType { get; set; }
    public string ResolveName { get; set; }
  }
}
