using System;

namespace UIoC {
  public static class MiscellaneousExtensions {

    #region AddType

    public static IContainer AddType(this IContainer container, Type actualType) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      return container.AddType(actualType, null, actualType);
    }
    public static IContainer AddType(this IContainer container, string resolveName, Type actualType) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      return container.AddType(actualType, resolveName, actualType);
    }
    public static IContainer AddType(this IContainer container, Type resolveType, Type actualType) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      return container.AddType(resolveType, null, actualType);
    }

    public static IContainer AddType<TActual>(this IContainer container) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      return container.AddType(typeof(TActual), null, typeof(TActual));
    }
    public static IContainer AddType<TActual>(this IContainer container, string resolveName) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      return container.AddType(typeof(TActual), resolveName, typeof(TActual));
    }
    public static IContainer AddType<TResolve, TActual>(this IContainer container) where TActual : TResolve {
      if (container == null) throw new ArgumentNullException(nameof(container));
      return container.AddType(typeof(TResolve), null, typeof(TActual));
    }
    public static IContainer AddType<TResolve, TActual>(this IContainer container, string resolveName) where TActual : TResolve {
      if (container == null) throw new ArgumentNullException(nameof(container));
      return container.AddType(typeof(TResolve), resolveName, typeof(TActual));
    }

    #endregion

    #region AddSingleton

    public static IContainer AddSingleton(this IContainer container, Type actualType) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      return container.AddSingleton(actualType, null, actualType);
    }
    public static IContainer AddSingleton(this IContainer container, string resolveName, Type actualType) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      return container.AddSingleton(actualType, resolveName, actualType);
    }
    public static IContainer AddSingleton(this IContainer container, Type resolveType, Type actualType) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      return container.AddSingleton(resolveType, null, actualType);
    }

    public static IContainer AddSingleton<TActual>(this IContainer container) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      return container.AddSingleton(typeof(TActual), null, typeof(TActual));
    }
    public static IContainer AddSingleton<TActual>(this IContainer container, string resolveName) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      return container.AddSingleton(typeof(TActual), resolveName, typeof(TActual));
    }
    public static IContainer AddSingleton<TResolve, TActual>(this IContainer container) where TActual : TResolve {
      if (container == null) throw new ArgumentNullException(nameof(container));
      return container.AddSingleton(typeof(TResolve), null, typeof(TActual));
    }
    public static IContainer AddSingleton<TResolve, TActual>(this IContainer container, string resolveName) where TActual : TResolve {
      if (container == null) throw new ArgumentNullException(nameof(container));
      return container.AddSingleton(typeof(TResolve), resolveName, typeof(TActual));
    }

    #endregion

    #region AddInstance

    public static IContainer AddInstance(this IContainer container, Type resolveType, object actualInstance) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      return container.AddInstance(resolveType, null, actualInstance);
    }

    public static IContainer AddInstance<TResolve>(this IContainer container, TResolve actualInstance) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      return container.AddInstance(typeof(TResolve), null, actualInstance);
    }
    public static IContainer AddInstance<TResolve>(this IContainer container, string resolveName, TResolve actualInstance) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      return container.AddInstance(typeof(TResolve), resolveName, actualInstance);
    }

    #endregion

    #region AddFactory

    public static IContainer AddFactory(this IContainer container, Type resolveType, Func<object> actualFactory) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      if (actualFactory == null) throw new ArgumentNullException(nameof(actualFactory));
      return container.AddFactory(resolveType, null, (c, t, n) => actualFactory());
    }
    public static IContainer AddFactory(this IContainer container, Type resolveType, Func<IContainer, object> actualFactory) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      if (actualFactory == null) throw new ArgumentNullException(nameof(actualFactory));
      return container.AddFactory(resolveType, null, (c, t, n) => actualFactory(c));
    }
    public static IContainer AddFactory(this IContainer container, Type resolveType, Func<IContainer, Type, object> actualFactory) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      if (actualFactory == null) throw new ArgumentNullException(nameof(actualFactory));
      return container.AddFactory(resolveType, null, (c, t, n) => actualFactory(c, t));
    }
    public static IContainer AddFactory(this IContainer container, Type resolveType, Func<IContainer, Type, string, object> actualFactory) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      return container.AddFactory(resolveType, null, actualFactory);
    }

    public static IContainer AddFactory(this IContainer container, Type resolveType, string resolveName, Func<object> actualFactory) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      if (actualFactory == null) throw new ArgumentNullException(nameof(actualFactory));
      return container.AddFactory(resolveType, resolveName, (c, t, n) => actualFactory());
    }
    public static IContainer AddFactory(this IContainer container, Type resolveType, string resolveName, Func<IContainer, object> actualFactory) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      if (actualFactory == null) throw new ArgumentNullException(nameof(actualFactory));
      return container.AddFactory(resolveType, resolveName, (c, t, n) => actualFactory(c));
    }
    public static IContainer AddFactory(this IContainer container, Type resolveType, string resolveName, Func<IContainer, Type, object> actualFactory) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      if (actualFactory == null) throw new ArgumentNullException(nameof(actualFactory));
      return container.AddFactory(resolveType, resolveName, (c, t, n) => actualFactory(c, t));
    }

    public static IContainer AddFactory<TResolve>(this IContainer container, Func<object> actualFactory) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      if (actualFactory == null) throw new ArgumentNullException(nameof(actualFactory));
      return container.AddFactory(typeof(TResolve), null, (c, t, n) => actualFactory());
    }
    public static IContainer AddFactory<TResolve>(this IContainer container, Func<IContainer, object> actualFactory) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      if (actualFactory == null) throw new ArgumentNullException(nameof(actualFactory));
      return container.AddFactory(typeof(TResolve), null, (c, t, n) => actualFactory(c));
    }
    public static IContainer AddFactory<TResolve>(this IContainer container, Func<IContainer, Type, object> actualFactory) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      if (actualFactory == null) throw new ArgumentNullException(nameof(actualFactory));
      return container.AddFactory(typeof(TResolve), null, (c, t, n) => actualFactory(c, t));
    }
    public static IContainer AddFactory<TResolve>(this IContainer container, Func<IContainer, Type, string, object> actualFactory) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      return container.AddFactory(typeof(TResolve), null, actualFactory);
    }

    public static IContainer AddFactory<TResolve>(this IContainer container, string resolveName, Func<object> actualFactory) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      if (actualFactory == null) throw new ArgumentNullException(nameof(actualFactory));
      return container.AddFactory(typeof(TResolve), resolveName, (c, t, n) => actualFactory());
    }
    public static IContainer AddFactory<TResolve>(this IContainer container, string resolveName, Func<IContainer, object> actualFactory) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      if (actualFactory == null) throw new ArgumentNullException(nameof(actualFactory));
      return container.AddFactory(typeof(TResolve), resolveName, (c, t, n) => actualFactory(c));
    }
    public static IContainer AddFactory<TResolve>(this IContainer container, string resolveName, Func<IContainer, Type, object> actualFactory) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      if (actualFactory == null) throw new ArgumentNullException(nameof(actualFactory));
      return container.AddFactory(typeof(TResolve), resolveName, (c, t, n) => actualFactory(c, t));
    }
    public static IContainer AddFactory<TResolve>(this IContainer container, string resolveName, Func<IContainer, Type, string, object> actualFactory) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      return container.AddFactory(typeof(TResolve), resolveName, actualFactory);
    }

    #endregion

    #region Contains

    public static bool Contains(this IContainer container, Type resolveType) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      return container.Contains(resolveType, null);
    }

    public static bool Contains<TResolve>(this IContainer container) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      return container.Contains(typeof(TResolve), null);
    }
    public static bool Contains<TResolve>(this IContainer container, string resolveName) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      return container.Contains(typeof(TResolve), resolveName);
    }

    #endregion

    #region Get

    public static object Get(this IContainer container, Type resolveType) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      return container.Get(resolveType, null);
    }

    public static TResolve Get<TResolve>(this IContainer container) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      return (TResolve)container.Get(typeof(TResolve), null);
    }
    public static TResolve Get<TResolve>(this IContainer container, string resolveName) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      return (TResolve)container.Get(typeof(TResolve), resolveName);
    }

    #endregion

    #region Create

    public static TActual Create<TActual>(this IContainer container) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      return (TActual)container.Create(typeof(TActual));
    }

    #endregion
  }
}
