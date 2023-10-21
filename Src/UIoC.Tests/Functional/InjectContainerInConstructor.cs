using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UIoC.Tests.Functional {
  [TestClass]
  public class InjectContainerInConstructor {

    private class C0 {
      public int IntProp { get; set; } = 0;
    }

    private class C1 {
      private IContainer _container;
      public C1(IContainer container) {
        _container = container;
      }
      public int IntProp {
        get {
          var c0 = (C0)_container.Get(typeof(C0), null);
          return c0.IntProp;
        }
        set {
          var c0 = (C0)_container.Get(typeof(C0), null);
          c0.IntProp = value;
        }
      }
    }

    [TestMethod]
    public void Singleton() {
      IContainer container = new Container();

      container.AddSingleton(typeof(C0), null, typeof(C0));
      container.AddType(typeof(C1), null, typeof(C1));

      var c1a = (C1)container.Get(typeof(C1), null);
      var c1b = (C1)container.Get(typeof(C1), null);

      Assert.AreEqual(c1a.IntProp, c1b.IntProp);

      c1a.IntProp++;
      Assert.AreEqual(c1a.IntProp, c1b.IntProp);

      var c0 = (C0)container.Get(typeof(C0), null);
      Assert.AreEqual(c0.IntProp, c1a.IntProp);
    }
  }
}
