using System;

namespace UIoC {
  [AttributeUsage(AttributeTargets.Parameter)]
  public class ResolveNameAttribute : Attribute {
    public ResolveNameAttribute(string resolveName = null) {
      ResolveName = resolveName;
    }
    public string ResolveName { get; set; }
  }
}
