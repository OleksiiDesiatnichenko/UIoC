using System;

namespace UIoC {
  [AttributeUsage(AttributeTargets.Parameter)]
  public class InjectAttribute : Attribute {
    public InjectAttribute(Type resolveType = null, string resolveName = null) {
      ResolveType = resolveType;
      ResolveName = resolveName;
    }
    public InjectAttribute(string resolveName) : this(null, resolveName) {
    }
    public Type ResolveType { get; set; }
    public string ResolveName { get; set; }
  }
}
