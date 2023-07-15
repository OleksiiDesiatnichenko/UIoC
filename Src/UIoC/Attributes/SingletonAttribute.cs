using System;

namespace UIoC {
  [AttributeUsage(AttributeTargets.Class)]
  public class SingletonAttribute : Attribute {
    public SingletonAttribute(Type resolveType = null, string resolveName = null) {
      ResolveType = resolveType;
      ResolveName = resolveName;
    }
    public SingletonAttribute(string resolveName) : this(null, resolveName) {
    }
    public Type ResolveType { get; set; }
    public string ResolveName { get; set; }
  }
}
