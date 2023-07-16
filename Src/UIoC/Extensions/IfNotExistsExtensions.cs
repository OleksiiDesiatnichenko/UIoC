using System;

namespace UIoC {
  public static class IfNotExistsExtensions {

    #region AddTypeIfNotExists

    public static IContainer AddTypeIfNotExists(this IContainer container, Type actualType) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      if (container.Contains(actualType, null)) return container;
      return container.AddType(actualType, null, actualType);
    }
    public static IContainer AddTypeIfNotExists(this IContainer container, string resolveName, Type actualType) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      if (container.Contains(actualType, resolveName)) return container;
      return container.AddType(actualType, resolveName, actualType);
    }
    public static IContainer AddTypeIfNotExists(this IContainer container, Type resolveType, Type actualType) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      if (container.Contains(resolveType, null)) return container;
      return container.AddType(resolveType, null, actualType);
    }
    public static IContainer AddTypeIfNotExists(this IContainer container, Type resolveType, string resolveName, Type actualType) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      if (container.Contains(resolveType, resolveName)) return container;
      return container.AddType(resolveType, resolveName, actualType);
    }

    public static IContainer AddTypeIfNotExists<TActual>(this IContainer container) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      if (container.Contains(typeof(TActual), null)) return container;
      return container.AddType(typeof(TActual), null, typeof(TActual));
    }
    public static IContainer AddTypeIfNotExists<TActual>(this IContainer container, string resolveName) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      if (container.Contains(typeof(TActual), resolveName)) return container;
      return container.AddType(typeof(TActual), resolveName, typeof(TActual));
    }
    public static IContainer AddTypeIfNotExists<TResolve, TActual>(this IContainer container) where TActual : TResolve {
      if (container == null) throw new ArgumentNullException(nameof(container));
      if (container.Contains(typeof(TResolve), null)) return container;
      return container.AddType(typeof(TResolve), null, typeof(TActual));
    }
    public static IContainer AddTypeIfNotExists<TResolve, TActual>(this IContainer container, string resolveName) where TActual : TResolve {
      if (container == null) throw new ArgumentNullException(nameof(container));
      if (container.Contains(typeof(TResolve), resolveName)) return container;
      return container.AddType(typeof(TResolve), resolveName, typeof(TActual));
    }

    #endregion

    #region AddSingletonIfNotExists

    public static IContainer AddSingletonIfNotExists(this IContainer container, Type actualType) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      if (container.Contains(actualType, null)) return container;
      return container.AddSingleton(actualType, null, actualType);
    }
    public static IContainer AddSingletonIfNotExists(this IContainer container, string resolveName, Type actualType) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      if (container.Contains(actualType, resolveName)) return container;
      return container.AddSingleton(actualType, resolveName, actualType);
    }
    public static IContainer AddSingletonIfNotExists(this IContainer container, Type resolveType, Type actualType) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      if (container.Contains(resolveType, null)) return container;
      return container.AddSingleton(resolveType, null, actualType);
    }
    public static IContainer AddSingletonIfNotExists(this IContainer container, Type resolveType, string resolveName, Type actualType) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      if (container.Contains(resolveType, resolveName)) return container;
      return container.AddSingleton(resolveType, resolveName, actualType);
    }

    public static IContainer AddSingletonIfNotExists<TActual>(this IContainer container) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      if (container.Contains(typeof(TActual), null)) return container;
      return container.AddSingleton(typeof(TActual), null, typeof(TActual));
    }
    public static IContainer AddSingletonIfNotExists<TActual>(this IContainer container, string resolveName) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      if (container.Contains(typeof(TActual), resolveName)) return container;
      return container.AddSingleton(typeof(TActual), resolveName, typeof(TActual));
    }
    public static IContainer AddSingletonIfNotExists<TResolve, TActual>(this IContainer container) where TActual : TResolve {
      if (container == null) throw new ArgumentNullException(nameof(container));
      if (container.Contains(typeof(TResolve), null)) return container;
      return container.AddSingleton(typeof(TResolve), null, typeof(TActual));
    }
    public static IContainer AddSingletonIfNotExists<TResolve, TActual>(this IContainer container, string resolveName) where TActual : TResolve {
      if (container == null) throw new ArgumentNullException(nameof(container));
      if (container.Contains(typeof(TResolve), resolveName)) return container;
      return container.AddSingleton(typeof(TResolve), resolveName, typeof(TActual));
    }

    #endregion

    #region AddInstanceIfNotExists

    public static IContainer AddInstanceIfNotExists(this IContainer container, Type resolveType, string resolveName, object actualInstance) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      if (container.Contains(resolveType, resolveName)) return container;
      return container.AddInstance(resolveType, null, actualInstance);
    }
    public static IContainer AddInstanceIfNotExists(this IContainer container, Type resolveType, object actualInstance) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      if (container.Contains(resolveType, null)) return container;
      return container.AddInstance(resolveType, null, actualInstance);
    }

    public static IContainer AddInstanceIfNotExists<TResolve>(this IContainer container, TResolve actualInstance) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      if (container.Contains(typeof(TResolve), null)) return container;
      return container.AddInstance(typeof(TResolve), null, actualInstance);
    }
    public static IContainer AddInstanceIfNotExists<TResolve>(this IContainer container, string resolveName, TResolve actualInstance) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      if (container.Contains(typeof(TResolve), resolveName)) return container;
      return container.AddInstance(typeof(TResolve), resolveName, actualInstance);
    }

    #endregion

    #region AddFactoryIfNotExists

    public static IContainer AddFactoryIfNotExists(this IContainer container, Type resolveType, Func<object> actualFactory) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      if (actualFactory == null) throw new ArgumentNullException(nameof(actualFactory));
      if (container.Contains(resolveType, null)) return container;
      return container.AddFactory(resolveType, null, (c, t, n) => actualFactory());
    }
    public static IContainer AddFactoryIfNotExists(this IContainer container, Type resolveType, Func<IContainer, object> actualFactory) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      if (actualFactory == null) throw new ArgumentNullException(nameof(actualFactory));
      if (container.Contains(resolveType, null)) return container;
      return container.AddFactory(resolveType, null, (c, t, n) => actualFactory(c));
    }
    public static IContainer AddFactoryIfNotExists(this IContainer container, Type resolveType, Func<IContainer, Type, object> actualFactory) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      if (actualFactory == null) throw new ArgumentNullException(nameof(actualFactory));
      if (container.Contains(resolveType, null)) return container;
      return container.AddFactory(resolveType, null, (c, t, n) => actualFactory(c, t));
    }
    public static IContainer AddFactoryIfNotExists(this IContainer container, Type resolveType, Func<IContainer, Type, string, object> actualFactory) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      if (actualFactory == null) throw new ArgumentNullException(nameof(actualFactory));
      if (container.Contains(resolveType, null)) return container;
      return container.AddFactory(resolveType, null, actualFactory);
    }

    public static IContainer AddFactoryIfNotExists(this IContainer container, Type resolveType, string resolveName, Func<object> actualFactory) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      if (actualFactory == null) throw new ArgumentNullException(nameof(actualFactory));
      if (container.Contains(resolveType, resolveName)) return container;
      return container.AddFactory(resolveType, resolveName, (c, t, n) => actualFactory());
    }
    public static IContainer AddFactoryIfNotExists(this IContainer container, Type resolveType, string resolveName, Func<IContainer, object> actualFactory) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      if (actualFactory == null) throw new ArgumentNullException(nameof(actualFactory));
      if (container.Contains(resolveType, resolveName)) return container;
      return container.AddFactory(resolveType, resolveName, (c, t, n) => actualFactory(c));
    }
    public static IContainer AddFactoryIfNotExists(this IContainer container, Type resolveType, string resolveName, Func<IContainer, Type, object> actualFactory) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      if (actualFactory == null) throw new ArgumentNullException(nameof(actualFactory));
      if (container.Contains(resolveType, resolveName)) return container;
      return container.AddFactory(resolveType, resolveName, (c, t, n) => actualFactory(c, t));
    }
    public static IContainer AddFactoryIfNotExists(this IContainer container, Type resolveType, string resolveName, Func<IContainer, Type, string, object> actualFactory) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      if (actualFactory == null) throw new ArgumentNullException(nameof(actualFactory));
      if (container.Contains(resolveType, resolveName)) return container;
      return container.AddFactory(resolveType, resolveName, actualFactory);
    }

    public static IContainer AddFactoryIfNotExists<TResolve>(this IContainer container, Func<object> actualFactory) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      if (actualFactory == null) throw new ArgumentNullException(nameof(actualFactory));
      if (container.Contains(typeof(TResolve), null)) return container;
      return container.AddFactory(typeof(TResolve), null, (c, t, n) => actualFactory());
    }
    public static IContainer AddFactoryIfNotExists<TResolve>(this IContainer container, Func<IContainer, object> actualFactory) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      if (actualFactory == null) throw new ArgumentNullException(nameof(actualFactory));
      if (container.Contains(typeof(TResolve), null)) return container;
      return container.AddFactory(typeof(TResolve), null, (c, t, n) => actualFactory(c));
    }
    public static IContainer AddFactoryIfNotExists<TResolve>(this IContainer container, Func<IContainer, Type, object> actualFactory) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      if (actualFactory == null) throw new ArgumentNullException(nameof(actualFactory));
      if (container.Contains(typeof(TResolve), null)) return container;
      return container.AddFactory(typeof(TResolve), null, (c, t, n) => actualFactory(c, t));
    }
    public static IContainer AddFactoryIfNotExists<TResolve>(this IContainer container, Func<IContainer, Type, string, object> actualFactory) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      if (container.Contains(typeof(TResolve), null)) return container;
      return container.AddFactory(typeof(TResolve), null, actualFactory);
    }

    public static IContainer AddFactoryIfNotExists<TResolve>(this IContainer container, string resolveName, Func<object> actualFactory) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      if (actualFactory == null) throw new ArgumentNullException(nameof(actualFactory));
      if (container.Contains(typeof(TResolve), resolveName)) return container;
      return container.AddFactory(typeof(TResolve), resolveName, (c, t, n) => actualFactory());
    }
    public static IContainer AddFactoryIfNotExists<TResolve>(this IContainer container, string resolveName, Func<IContainer, object> actualFactory) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      if (actualFactory == null) throw new ArgumentNullException(nameof(actualFactory));
      if (container.Contains(typeof(TResolve), resolveName)) return container;
      return container.AddFactory(typeof(TResolve), resolveName, (c, t, n) => actualFactory(c));
    }
    public static IContainer AddFactoryIfNotExists<TResolve>(this IContainer container, string resolveName, Func<IContainer, Type, object> actualFactory) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      if (actualFactory == null) throw new ArgumentNullException(nameof(actualFactory));
      if (container.Contains(typeof(TResolve), resolveName)) return container;
      return container.AddFactory(typeof(TResolve), resolveName, (c, t, n) => actualFactory(c, t));
    }
    public static IContainer AddFactoryIfNotExists<TResolve>(this IContainer container, string resolveName, Func<IContainer, Type, string, object> actualFactory) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      if (actualFactory == null) throw new ArgumentNullException(nameof(actualFactory));
      if (container.Contains(typeof(TResolve), resolveName)) return container;
      return container.AddFactory(typeof(TResolve), resolveName, actualFactory);
    }

    #endregion

    #region GetOrDefault

    public static object GetOrDefault(this IContainer container, Type resolveType) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      if (!container.Contains(resolveType, null)) return default;
      return container.Get(resolveType, null);
    }

    public static TResolve GetOrDefault<TResolve>(this IContainer container) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      if (!container.Contains(typeof(TResolve), null)) return default;
      return (TResolve)container.Get(typeof(TResolve), null);
    }
    public static TResolve GetOrDefault<TResolve>(this IContainer container, string resolveName) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      if (!container.Contains(typeof(TResolve), resolveName)) return default;
      return (TResolve)container.Get(typeof(TResolve), resolveName);
    }

    #endregion
  }
}
