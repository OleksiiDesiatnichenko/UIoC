using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UIoC.Tests.Interface {
  [TestClass]
  public class AssembliesExtensionsTests {

    internal class C1 {
      public int IntProp { get; set; } = 0;
    }

    internal class C2 {
      private C1 _c1;
      public C2(C1 c1) { _c1 = c1; }
      public int IntProp { get => _c1.IntProp; set => _c1.IntProp = value; }
    }

    /// <summary
    /// public static IContainer AddFromPath(this IContainer container, string path, string searchPattern = "*.dll", bool includeSubfolders = true) { ... }
    /// </summary>
    [TestMethod]
    public void AddFromPathCSSB() {
      // TODO
    }

    /// <summary
    /// public static IContainer AddFromAssembly(this IContainer container, Assembly assembly) { ... }
    /// </summary>
    [TestMethod]
    public void AddFromAssemblyCA() {
      // TODO
    }

    /// <summary
    /// public static IContainer AddAllTypesFromPath(this IContainer container, string path, string searchPattern = "*.dll", bool includeSubfolders = true) { ... }
    /// </summary>
    [TestMethod]
    public void AddAllTypesFromPathCSSB() {
      // TODO
    }

    /// <summary
    /// public static IContainer AddAllTypesFromAssembly(this IContainer container, Assembly assembly) { ... }
    /// </summary>
    [TestMethod]
    public void AddAllTypesFromAssemblyCA() {
      var container = new Container();
      container.AddAllFromAssembly(Assembly.GetExecutingAssembly());


      var c1A = (C1)container.Get(typeof(C1), null);
      Assert.IsNotNull(c1A);
      Assert.AreEqual(c1A.IntProp, new C1().IntProp);

      c1A.IntProp++;
      Assert.AreEqual(c1A.IntProp, 1);

      var c1B = (C1)container.Get(typeof(C1), null);
      Assert.IsNotNull(c1B);
      Assert.AreNotEqual(c1A, c1B);
      Assert.AreEqual(c1B.IntProp, 0);


      var c2 = (C2)container.Get(typeof(C2), null);
      Assert.IsNotNull(c2);
      Assert.AreEqual(c2.IntProp, 0);

      c2.IntProp++;
      Assert.AreEqual(c2.IntProp, 1);
    }
  }
}
