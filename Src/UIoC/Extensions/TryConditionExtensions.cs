using System;

namespace UIoC {
  public static class TryConditionExtensions {

    #region TryAddType

    public static bool TryAddType<TActual>(this IContainer container) {
      return container.TryAddType<TActual, TActual>();
    }
    public static bool TryAddType<TActual>(this IContainer container, string resolveName) {
      return container.TryAddType<TActual, TActual>(resolveName);
    }
    public static bool TryAddType<TResolve, TActual>(this IContainer container) where TActual : TResolve {
      return container.TryAddType<TResolve, TActual>(null);
    }
    public static bool TryAddType<TResolve, TActual>(this IContainer container, string resolveName) where TActual : TResolve {
      if (container.Contains<TResolve>(resolveName))
        return false;
      container.AddType<TResolve, TActual>(resolveName);
      return true;
    }

    #endregion

    #region TryAddSingleton

    public static bool TryAddSingleton<TActual>(this IContainer container) {
      return container.TryAddSingleton<TActual, TActual>();
    }
    public static bool TryAddSingleton<TActual>(this IContainer container, string resolveName) {
      return container.TryAddSingleton<TActual, TActual>(resolveName);
    }
    public static bool TryAddSingleton<TResolve, TActual>(this IContainer container) where TActual : TResolve {
      return container.TryAddSingleton<TResolve, TActual>(null);
    }
    public static bool TryAddSingleton<TResolve, TActual>(this IContainer container, string resolveName) where TActual : TResolve {
      if (container.Contains<TResolve>(resolveName))
        return false;
      container.AddSingleton<TResolve, TActual>(resolveName);
      return true;
    }

    #endregion

    #region TryAddInstance

    public static bool TryAddInstance<TResolve>(this IContainer container, TResolve actualInstance) {
      return container.TryAddInstance<TResolve>(null, actualInstance);
    }
    public static bool TryAddInstance<TResolve>(this IContainer container, string resolveName, TResolve actualInstance) {
      if (container.Contains<TResolve>(resolveName))
        return false;
      container.AddInstance<TResolve>(resolveName, actualInstance);
      return true;
    }

    #endregion

    #region TryAddFactory

    public static bool TryAddFactory<TResolve>(this IContainer container, Func<IContainer, object> actualFactory) {
      return container.TryAddFactory<TResolve>(null, actualFactory);
    }
    public static bool TryAddFactory<TResolve>(this IContainer container, string resolveName, Func<IContainer, object> actualFactory) {
      if (container.Contains<TResolve>(resolveName))
        return false;
      container.AddFactory<TResolve>(resolveName, actualFactory);
      return true;
    }

    #endregion

    #region TryGet

    public static bool TryGet<TResolve>(this IContainer container, out TResolve value) {
      return container.TryGet(null, out value);
    }
    public static bool TryGet<TResolve>(this IContainer container, string resolveName, out TResolve value) {
      if (container.Contains<TResolve>(resolveName)) {
        value = container.Get<TResolve>(resolveName);
        return true;
      }
      value = default;
      return false;
    }

    #endregion
  }
}
