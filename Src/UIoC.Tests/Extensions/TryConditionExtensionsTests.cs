using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UIoC.Tests.Interface {
  [TestClass]
  public class TryConditionExtensionsTests {

    private interface I1 {
      public string StrProp { get; }
    }
    private class C1A : I1 {
      public string StrProp => "C1A";
    }
    private class C1B : I1 {
      public string StrProp => "C1B";
    }

    private interface I2 {
      public string StrProp { get; }
    }

    #region TryAddType

    /// <summary
    /// public static bool TryAddType<TActual>(this IContainer container) { ... }
    /// </summary>
    [TestMethod]
    public void TryAddTypeTC() {
      // TODO
    }

    /// <summary
    /// public static bool TryAddType<TActual>(this IContainer container, string resolveName) { ... }
    /// </summary>
    [TestMethod]
    public void TryAddTypeTCS() {
      // TODO
    }

    /// <summary
    /// public static bool TryAddType<TResolve, TActual>(this IContainer container) where TActual : TResolve { ... }
    /// </summary>
    [TestMethod]
    public void TryAddTypeTTC() {
      IContainer container = new Container();

      Assert.IsTrue(container.TryAddType<I1, C1A>());
      Assert.AreEqual(new C1A().StrProp, ((I1)container.Get(typeof(I1), null)).StrProp);

      Assert.IsFalse(container.TryAddType<I1, C1B>());
      Assert.AreEqual(new C1A().StrProp, ((I1)container.Get(typeof(I1), null)).StrProp);
    }

    /// <summary
    /// public static bool TryAddType<TResolve, TActual>(this IContainer container, string resolveName) where TActual : TResolve { ... }
    /// </summary>
    [TestMethod]
    public void TryAddTypeTTCS() {
      // TODO
    }

    #endregion

    #region TryAddSingleton

    /// <summary
    /// public static bool TryAddSingleton<TActual>(this IContainer container) { ... }
    /// </summary>
    [TestMethod]
    public void TryAddSingletonTC() {
      // TODO
    }

    /// <summary
    /// public static bool TryAddSingleton<TActual>(this IContainer container, string resolveName) { ... }
    /// </summary>
    [TestMethod]
    public void TryAddSingletonTCS() {
      // TODO
    }

    /// <summary
    /// public static bool TryAddSingleton<TResolve, TActual>(this IContainer container) where TActual : TResolve { ... }
    /// </summary>
    [TestMethod]
    public void TryAddSingletonTTC() {
      // TODO
    }

    /// <summary
    /// public static bool TryAddSingleton<TResolve, TActual>(this IContainer container, string resolveName) where TActual : TResolve { ... }
    /// </summary>
    [TestMethod]
    public void TryAddSingletonTTCS() {
      // TODO
    }


    #endregion

    #region TryAddInstance

    /// <summary
    /// public static bool TryAddInstance<TResolve>(this IContainer container, TResolve actualInstance) { ... }
    /// </summary>
    [TestMethod]
    public void TryAddInstanceTCT() {
      // TODO
    }

    /// <summary
    /// public static bool TryAddInstance<TResolve>(this IContainer container, string resolveName, TResolve actualInstance) { ... }
    /// </summary>
    [TestMethod]
    public void TryAddInstanceTCST() {
      // TODO
    }

    #endregion

    #region TryAddFactory

    /// <summary
    /// public static bool TryAddFactory<TResolve>(this IContainer container, Func<IContainer, object> actualFactory) { ... }
    /// </summary>
    [TestMethod]
    public void TryAddFactoryTCFCO() {
      // TODO
    }

    /// <summary
    /// public static bool TryAddFactory<TResolve>(this IContainer container, string resolveName, Func<IContainer, object> actualFactory) { ... }
    /// </summary>
    [TestMethod]
    public void TryAddFactoryTCSFCO() {
      // TODO
    }

    #endregion

    #region TryGet

    /// <summary
    /// public static bool TryGet<TResolve>(this IContainer container, out TResolve value) { ... }
    /// </summary>
    [TestMethod]
    public void TryGetTCT() {
      IContainer container = new Container();

      container.AddType<I1, C1A>();
      if (container.TryGet<I1>(out var i1)) {
        Assert.AreEqual(new C1A().StrProp, i1.StrProp);
      }

      if (container.TryGet<I2>(out var i2)) {
        Assert.Fail();
      }
    }

    /// <summary
    /// public static bool TryGet<TResolve>(this IContainer container, string resolveName, out TResolve value) { ... }
    /// </summary>
    [TestMethod]
    public void TryGetTCST() {
      IContainer container = new Container();

      container.AddType<I1, C1A>("keyA");
      if (container.TryGet<I1>("keyA", out var i1)) {
        Assert.AreEqual(new C1A().StrProp, i1.StrProp);
      }

      if (container.TryGet<I2>("keyB", out var i2)) {
        Assert.Fail();
      }
    }

    #endregion
  }
}
