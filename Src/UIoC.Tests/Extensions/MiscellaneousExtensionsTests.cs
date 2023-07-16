using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UIoC.Tests.Interface {
  [TestClass]
  public class MiscellaneousExtensionsTests {

    private interface I1 {
      public string StrProp { get; set; }
    }
    private class C1A : I1 {
      public string StrProp { get; set; } = "C1A";
    }
    private class C1B : I1 {
      public string StrProp { get; set; } = "C1B";
    }

    #region AddType

    /// <summary
    /// public static IContainer AddType(this IContainer container, Type actualType) { ... }
    /// </summary>
    [TestMethod]
    public void AddTypeCT() {
      // TODO
    }

    /// <summary
    /// public static IContainer AddType(this IContainer container, string resolveName, Type actualType) { ... }
    /// </summary>
    [TestMethod]
    public void AddTypeCST() {
      // TODO
    }

    /// <summary
    /// public static IContainer AddType(this IContainer container, Type resolveType, Type actualType) { ... }
    /// </summary>
    [TestMethod]
    public void AddTypeCTT() {
      // TODO
    }

    /// <summary
    /// public static IContainer AddType<TActual>(this IContainer container) { ... }
    /// </summary>
    [TestMethod]
    public void AddTypeTC() {
      IContainer container = new Container();

      container.AddType<C1A>();

      Assert.AreEqual(new C1A().StrProp, ((C1A)container.Get(typeof(C1A), null)).StrProp);
    }

    /// <summary
    /// public static IContainer AddType<TActual>(this IContainer container, string resolveName) { ... }
    /// </summary>
    [TestMethod]
    public void AddTypeTCS() {
      // TODO
    }

    /// <summary
    /// public static IContainer AddType<TResolve, TActual>(this IContainer container) where TActual : TResolve { ... }
    /// </summary>
    [TestMethod]
    public void AddTypeTTC() {
      IContainer container = new Container();

      container.AddType<I1, C1A>();
      Assert.AreEqual(new C1A().StrProp, ((I1)container.Get(typeof(I1), null)).StrProp);

      container.AddType<I1, C1B>();
      Assert.AreEqual(new C1B().StrProp, ((I1)container.Get(typeof(I1), null)).StrProp);
    }

    /// <summary
    /// public static IContainer AddType<TResolve, TActual>(this IContainer container, string resolveName) where TActual : TResolve { ... }
    /// </summary>
    [TestMethod]
    public void AddTypeTTCS() {
      IContainer container = new Container();

      container.AddType<I1, C1A>("A");
      Assert.AreEqual(new C1A().StrProp, ((I1)container.Get(typeof(I1), "A")).StrProp);

      container.AddType<I1, C1B>("B");
      Assert.AreEqual(new C1B().StrProp, ((I1)container.Get(typeof(I1), "B")).StrProp);
    }

    #endregion

    #region AddSingleton

    /// <summary
    /// public static IContainer AddSingleton(this IContainer container, Type actualType) { ... }
    /// </summary>
    [TestMethod]
    public void AddSingletonCT() {
      // TODO
    }

    /// <summary
    /// public static IContainer AddSingleton(this IContainer container, string resolveName, Type actualType) { ... }
    /// </summary>
    [TestMethod]
    public void AddSingletonCST() {
      // TODO
    }

    /// <summary
    /// public static IContainer AddSingleton(this IContainer container, Type resolveType, Type actualType) { ... }
    /// </summary>
    [TestMethod]
    public void AddSingletonCTT() {
      // TODO
    }

    /// <summary
    /// public static IContainer AddSingleton<TActual>(this IContainer container) { ... }
    /// </summary>
    [TestMethod]
    public void AddSingletonTC() {
      // TODO
    }

    /// <summary
    /// public static IContainer AddSingleton<TActual>(this IContainer container, string resolveName) { ... }
    /// </summary>
    [TestMethod]
    public void AddSingletonTCS() {
      // TODO
    }

    /// <summary
    /// public static IContainer AddSingleton<TResolve, TActual>(this IContainer container) where TActual : TResolve { ... }
    /// </summary>
    [TestMethod]
    public void AddSingletonTTC() {
      // TODO
    }

    /// <summary
    /// public static IContainer AddSingleton<TResolve, TActual>(this IContainer container, string resolveName) where TActual : TResolve { ... }
    /// </summary>
    [TestMethod]
    public void AddSingletonTTCS() {
      IContainer container = new Container();


      container.AddSingleton<I1, C1A>("A");
      Assert.IsNotNull(container.Get(typeof(I1), "A"));
      Assert.AreEqual(container.Get(typeof(I1), "A"), container.Get(typeof(I1), "A"));

      Assert.AreEqual(new C1A().StrProp, ((I1)container.Get(typeof(I1), "A")).StrProp);
      ((I1)container.Get(typeof(I1), "A")).StrProp = "AAA";
      Assert.AreEqual("AAA", ((I1)container.Get(typeof(I1), "A")).StrProp);


      container.AddSingleton<I1, C1B>("B");
      Assert.IsNotNull(container.Get(typeof(I1), "B"));
      Assert.AreEqual(container.Get(typeof(I1), "B"), container.Get(typeof(I1), "B"));

      Assert.AreEqual(new C1B().StrProp, ((I1)container.Get(typeof(I1), "B")).StrProp);
      ((I1)container.Get(typeof(I1), "B")).StrProp = "BBB";
      Assert.AreEqual("BBB", ((I1)container.Get(typeof(I1), "B")).StrProp);


      Assert.AreNotEqual(container.Get(typeof(I1), "A"), container.Get(typeof(I1), "B"));
    }

    #endregion

    #region AddInstance

    /// <summary
    /// public static IContainer AddInstance(this IContainer container, Type resolveType, object actualInstance) { ... }
    /// </summary>
    [TestMethod]
    public void AddInstanceCTO() {
      // TODO
    }

    /// <summary
    /// public static IContainer AddInstance<TResolve>(this IContainer container, TResolve actualInstance) { ... }
    /// </summary>
    [TestMethod]
    public void AddInstanceTCT() {
      // TODO
    }

    /// <summary
    /// public static IContainer AddInstance<TResolve>(this IContainer container, string resolveName, TResolve actualInstance) { ... }
    /// </summary>
    [TestMethod]
    public void AddInstanceTCST() {
      // TODO
    }

    #endregion

    #region AddFactory

    /// <summary
    /// public static IContainer AddFactory(this IContainer container, Type resolveType, Func<object> actualFactory) { ... }
    /// </summary>
    [TestMethod]
    public void AddFactoryCTFO() {
      // TODO
    }

    /// <summary
    /// public static IContainer AddFactory(this IContainer container, Type resolveType, Func<IContainer, object> actualFactory) { ... }
    /// </summary>
    [TestMethod]
    public void AddFactoryCTFCO() {
      // TODO
    }

    /// <summary
    /// public static IContainer AddFactory(this IContainer container, Type resolveType, Func<IContainer, Type, object> actualFactory) { ... }
    /// </summary>
    [TestMethod]
    public void AddFactoryCTFCTO() {
      // TODO
    }

    /// <summary
    /// public static IContainer AddFactory(this IContainer container, Type resolveType, Func<IContainer, Type, string, object> actualFactory) { ... }
    /// </summary>
    [TestMethod]
    public void AddFactoryCTFCTSO() {
      // TODO
    }

    /// <summary
    /// public static IContainer AddFactory(this IContainer container, Type resolveType, string resolveName, Func<object> actualFactory) { ... }
    /// </summary>
    [TestMethod]
    public void AddFactoryCTSFO() {
      // TODO
    }

    /// <summary
    /// public static IContainer AddFactory(this IContainer container, Type resolveType, string resolveName, Func<IContainer, object> actualFactory) { ... }
    /// </summary>
    [TestMethod]
    public void AddFactoryCTSFCO() {
      // TODO
    }

    /// <summary
    /// public static IContainer AddFactory(this IContainer container, Type resolveType, string resolveName, Func<IContainer, Type, object> actualFactory) { ... }
    /// </summary>
    [TestMethod]
    public void AddFactoryCTSFCTO() {
      // TODO
    }

    /// <summary
    /// public static IContainer AddFactory<TResolve>(this IContainer container, Func<object> actualFactory) { ... }
    /// </summary>
    [TestMethod]
    public void AddFactoryTCFO() {
      // TODO
    }

    /// <summary
    /// public static IContainer AddFactory<TResolve>(this IContainer container, Func<IContainer, object> actualFactory) { ... }
    /// </summary>
    [TestMethod]
    public void AddFactoryTCFCO() {
      IContainer container = new Container();
      container.AddFactory<int>("name", (container) => 555);
      Assert.AreEqual(555, (int)container.Get(typeof(int), "name"));
    }

    /// <summary
    /// public static IContainer AddFactory<TResolve>(this IContainer container, Func<IContainer, Type, object> actualFactory) { ... }
    /// </summary>
    [TestMethod]
    public void AddFactoryTCFCTO() {
      // TODO
    }

    /// <summary
    /// public static IContainer AddFactory<TResolve>(this IContainer container, Func<IContainer, Type, string, object> actualFactory) { ... }
    /// </summary>
    [TestMethod]
    public void AddFactoryTCFCTSO() {
      // TODO
    }

    /// <summary
    /// public static IContainer AddFactory<TResolve>(this IContainer container, string resolveName, Func<object> actualFactory) { ... }
    /// </summary>
    [TestMethod]
    public void AddFactoryTCSFO() {
      // TODO
    }

    /// <summary
    /// public static IContainer AddFactory<TResolve>(this IContainer container, string resolveName, Func<IContainer, object> actualFactory) { ... }
    /// </summary>
    [TestMethod]
    public void AddFactoryTCSFCO() {
      // TODO
    }

    /// <summary
    /// public static IContainer AddFactory<TResolve>(this IContainer container, string resolveName, Func<IContainer, Type, object> actualFactory) { ... }
    /// </summary>
    [TestMethod]
    public void AddFactoryCSFCTO() {
      // TODO
    }

    /// <summary
    /// public static IContainer AddFactory<TResolve>(this IContainer container, string resolveName, Func<IContainer, Type, string, object> actualFactory) { ... }
    /// </summary>
    [TestMethod]
    public void AddFactoryTCSFCTSO() {
      // TODO
    }

    #endregion

    #region Contains

    /// <summary
    /// public static bool Contains(this IContainer container, Type resolveType) { ... }
    /// </summary>
    [TestMethod]
    public void ContainCT() {
      // TODO
    }

    /// <summary
    /// public static bool Contains<TResolve>(this IContainer container) { ... }
    /// </summary>
    [TestMethod]
    public void ContainsTC() {
      // TODO
    }

    /// <summary
    /// public static bool Contains<TResolve>(this IContainer container, string resolveName) { ... }
    /// </summary>
    [TestMethod]
    public void ContainsTCS() {
      // TODO
    }

    #endregion

    #region Get

    /// <summary
    /// public static object Get(this IContainer container, Type resolveType) { ... }
    /// </summary>
    [TestMethod]
    public void GetCT() {
      // TODO
    }

    /// <summary
    /// public static TResolve Get<TResolve>(this IContainer container) { ... }
    /// </summary>
    [TestMethod]
    public void GetTC() {
      // TODO
    }

    /// <summary
    /// public static TResolve Get<TResolve>(this IContainer container, string resolveName) { ... }
    /// </summary>
    [TestMethod]
    public void GetTCS() {
      // TODO
    }

    #endregion

    #region Create

    /// <summary
    /// public static TActual Create<TActual>(this IContainer container) { ... }
    /// </summary>
    [TestMethod]
    public void CreateTC() {
      // TODO
    }

    #endregion
  }
}
