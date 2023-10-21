using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UIoC.Tests.Functional {
  [TestClass]
  public class InjectInConstructor {

    private class C0 {
      public string Text { get; }
      public C0(string text = "Default Text") => Text = text;
    }

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
      public C2(I1 i1 = null) { _i1 = i1; }
      public int IntProp { get => _i1?.IntProp ?? int.MinValue; set => _i1.IntProp = value; }
    }

    public void DefaultConstructorParameter() {
      IContainer container = new Container();

      container.AddType(typeof(C0), null);

      var c0 = container.Get(typeof(C0), null);
      Assert.IsNotNull(c0);
      Assert.AreEqual(new C0().Text, ((C0)c0).Text);
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

      Assert.AreEqual(container.Get<I2>().IntProp, c1.IntProp);
    }

    [TestMethod]
    public void DefaultConstructorTypeParameter() {
      IContainer container = new Container();

      container.AddType<I2, C2>();

      var c2a = container.Get<I2>();
      Assert.AreEqual(int.MinValue, c2a.IntProp);

      container.AddSingleton<I1, C1>();

      var c2b = container.Get<I2>();
      Assert.AreEqual(container.Get<I2>().IntProp, c2b.IntProp);
    }
  }
}
