using System;

namespace UIoC {
  public static class TryConditionExtensions {

    #region TryAddType

    public static bool TryAddType<TActual>(this IContainer container) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      if (container.Contains(typeof(TActual), null)) return false;
      container.AddType(typeof(TActual), null, typeof(TActual));
      return true;
    }
    public static bool TryAddType<TActual>(this IContainer container, string resolveName) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      if (container.Contains(typeof(TActual), resolveName)) return false;
      container.AddType(typeof(TActual), resolveName, typeof(TActual));
      return true;
    }
    public static bool TryAddType<TResolve, TActual>(this IContainer container) where TActual : TResolve {
      if (container == null) throw new ArgumentNullException(nameof(container));
      if (container.Contains(typeof(TResolve), null)) return false;
      container.AddType(typeof(TResolve), null, typeof(TActual));
      return true;
    }
    public static bool TryAddType<TResolve, TActual>(this IContainer container, string resolveName) where TActual : TResolve {
      if (container == null) throw new ArgumentNullException(nameof(container));
      if (container.Contains(typeof(TResolve), resolveName)) return false;
      container.AddType(typeof(TResolve), resolveName, typeof(TActual));
      return true;
    }

    #endregion

    #region TryAddSingleton

    public static bool TryAddSingleton<TActual>(this IContainer container) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      if (container.Contains(typeof(TActual), null)) return false;
      container.AddSingleton(typeof(TActual), null, typeof(TActual));
      return true;
    }
    public static bool TryAddSingleton<TActual>(this IContainer container, string resolveName) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      if (container.Contains(typeof(TActual), resolveName)) return false;
      container.AddSingleton(typeof(TActual), resolveName, typeof(TActual));
      return true;
    }
    public static bool TryAddSingleton<TResolve, TActual>(this IContainer container) where TActual : TResolve {
      if (container == null) throw new ArgumentNullException(nameof(container));
      if (container.Contains(typeof(TResolve), null)) return false;
      container.AddSingleton(typeof(TResolve), null, typeof(TActual));
      return true;
    }
    public static bool TryAddSingleton<TResolve, TActual>(this IContainer container, string resolveName) where TActual : TResolve {
      if (container == null) throw new ArgumentNullException(nameof(container));
      if (container.Contains(typeof(TResolve), resolveName)) return false;
      container.AddSingleton(typeof(TResolve), resolveName, typeof(TActual));
      return true;
    }

    #endregion

    #region TryAddInstance

    public static bool TryAddInstance<TResolve>(this IContainer container, TResolve actualInstance) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      if (container.Contains(typeof(TResolve), null)) return false;
      container.AddInstance(typeof(TResolve), null, actualInstance);
      return true;
    }
    public static bool TryAddInstance<TResolve>(this IContainer container, string resolveName, TResolve actualInstance) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      if (container.Contains(typeof(TResolve), resolveName)) return false;
      container.AddInstance(typeof(TResolve), resolveName, actualInstance);
      return true;
    }

    #endregion

    #region TryAddFactory

    public static bool TryAddFactory<TResolve>(this IContainer container, Func<IContainer, object> actualFactory) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      if (actualFactory == null) throw new ArgumentNullException(nameof(actualFactory));
      if (container.Contains(typeof(TResolve), null)) return false;
      container.AddFactory(typeof(TResolve), null, actualFactory);
      return true;
    }
    public static bool TryAddFactory<TResolve>(this IContainer container, string resolveName, Func<IContainer, object> actualFactory) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      if (actualFactory == null) throw new ArgumentNullException(nameof(actualFactory));
      if (container.Contains(typeof(TResolve), resolveName)) return false;
      container.AddFactory(typeof(TResolve), resolveName, actualFactory);
      return true;
    }

    #endregion

    #region TryGet

    public static bool TryGet<TResolve>(this IContainer container, out TResolve value) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      if (!container.Contains(typeof(TResolve), null)) { value = default; return false; }
      value = (TResolve)container.Get(typeof(TResolve), null);
      return true;
    }
    public static bool TryGet<TResolve>(this IContainer container, string resolveName, out TResolve value) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      if (!container.Contains(typeof(TResolve), resolveName)) { value = default; return false; }
      value = (TResolve)container.Get(typeof(TResolve), resolveName);
      return true;
    }

    #endregion
  }
}
