using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UIoC.Tests.Interface {
  [TestClass]
  public class SetExtensionsTests {

    private interface I1 {
      public string StrProp { get; }
    }
    private class C1A : I1 {
      public string StrProp => "C1A";
    }

    private interface I2 {
      public string StrProp { get; }
    }
    private class C2A : I2 {
      public string StrProp => "C2A";
    }
    private class C2B : I2 {
      public string StrProp => "C2B";
    }

    /// <summary>
    /// public static void Merge(this IContainer dest, IContainer src) { ... }
    /// </summary>
    [TestMethod]
    public void MergeCC() {

      IContainer containerA = new Container();
      containerA.AddType(typeof(I1), null, typeof(C1A));
      Assert.AreEqual(((I1)containerA.Get(typeof(I1), null)).StrProp, new C1A().StrProp);

      IContainer containerB = new Container();
      containerB.AddType(typeof(I2), null, typeof(C2A));
      Assert.AreEqual(((I2)containerB.Get(typeof(I2), null)).StrProp, new C2A().StrProp);


      containerA.Merge(containerB);

      Assert.AreEqual(((I1)containerA.Get(typeof(I1), null)).StrProp, new C1A().StrProp);
      Assert.AreEqual(((I2)containerA.Get(typeof(I2), null)).StrProp, new C2A().StrProp);


      IContainer containerC = new Container();
      containerC.AddType(typeof(I2), null, typeof(C2B));
      Assert.AreEqual(((I2)containerC.Get(typeof(I2), null)).StrProp, new C2B().StrProp);


      containerA.Merge(containerC);

      Assert.AreEqual(((I1)containerA.Get(typeof(I1), null)).StrProp, new C1A().StrProp);
      Assert.AreEqual(((I2)containerA.Get(typeof(I2), null)).StrProp, new C2B().StrProp);
    }
  }
}
