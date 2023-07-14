using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UIoC.Tests.Functional {
  [TestClass]
  public class InjectInConstructor {

    private interface I1 {
      public int IntProp { get; set; }
    }
    private class C1 : I1 {
      public C1() {}
      public int IntProp { get; set; } = 0;
    }

    private interface I2 {
      public int IntProp { get; set; }
    }
    private class C2 : I2 {
      private I1 _i1;
      public C2(I1 i1) { _i1 = i1; }
      public int IntProp { get => _i1.IntProp; set => _i1.IntProp = value; }
    }

    [TestMethod]
    public void Types() {
      IContainer container = new Container();

      container.AddType<I1, C1>();
      container.AddType<I2, C2>();

      var c1 = container.Get<I1>();
      var c2 = container.Get<I2>();
      Assert.AreEqual(c1.IntProp, c2.IntProp);

      c1.IntProp++;
      Assert.AreNotEqual(c1.IntProp, c2.IntProp);
    }

    [TestMethod]
    public void Singleton() {
      IContainer container = new Container();

      container.AddSingleton<I1, C1>();
      container.AddType<I2, C2>();

      Assert.AreEqual(container.Get<I1>(), container.Get<I1>());

      var c1 = container.Get<I1>();
      var c2 = container.Get<I2>();
      Assert.AreEqual(c1.IntProp, c2.IntProp);

      c1.IntProp++;
      Assert.AreEqual(c1.IntProp, c2.IntProp);

      Assert.AreEqual(c1.IntProp, container.Get<I2>().IntProp);
    }
  }
}
