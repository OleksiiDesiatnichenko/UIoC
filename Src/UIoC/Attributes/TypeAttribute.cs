using System;

namespace UIoC {
  [AttributeUsage(AttributeTargets.Class)]
  public class TypeAttribute : Attribute {
    public Type ResolveType { get; set; }
    public string ResolveName { get; set; }
  }
}
