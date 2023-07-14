using System;

namespace UIoC {
  public interface IContainer {
    IContainer AddType(Type resolveType, string resolveName, Type actualType);
    IContainer AddSingleton(Type resolveType, string resolveName, Type actualType);
    IContainer AddInstance(Type resolveType, string resolveName, object actualInstance);
    IContainer AddFactory(Type resolveType, string resolveName, Func<IContainer, Type, string, object> actualFactory);
    bool Contains(Type resolveType, string resolveName);
    object Get(Type resolveType, string resolveName);
    object Create(Type actualType);
  }
}
