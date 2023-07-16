using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UIoC.Tests.Attributes {
  [TestClass]
  public class SingletonAttributeTests {

    internal interface I {
      public string StrProp { get; set; }
    }

    [Singleton]
    internal class C1 : I {
      public string StrProp { get; set; } = "C1";
    }

    [Singleton(typeof(I))]
    internal class C2 : I {
      public string StrProp { get; set; } = "C2";
    }

    [Singleton("C3")]
    internal class C3 : I {
      public string StrProp { get; set; } = "C3";
    }

    [TestMethod]
    public void DefaultParameters() {
      IContainer container = new Container();
      container.AddByAttributeFromAssembly(Assembly.GetExecutingAssembly());


      var c1 = (I)container.Get(typeof(C1), null);
      Assert.IsNotNull(c1);
      Assert.AreEqual(new C1().StrProp, c1.StrProp);

      c1.StrProp += "new";
      Assert.AreEqual(new C1().StrProp + "new", c1.StrProp);


      var c2 = (I)container.Get(typeof(C1), null);
      Assert.IsNotNull(c2);
      Assert.AreEqual(new C1().StrProp + "new", c2.StrProp);

      Assert.AreEqual(c1, c2);
    }

    [TestMethod]
    public void TypeParameters() {
      IContainer container = new Container();
      container.AddByAttributeFromAssembly(Assembly.GetExecutingAssembly());

      var c2 = (I)container.Get(typeof(I), null);
      Assert.IsNotNull(c2);
      Assert.AreEqual(new C2().StrProp, c2.StrProp);
    }

    [TestMethod]
    public void NameParameters() {
      IContainer container = new Container();
      container.AddByAttributeFromAssembly(Assembly.GetExecutingAssembly());

      var c3 = (I)container.Get(typeof(C3), "C3");
      Assert.IsNotNull(c3);
      Assert.AreEqual(new C3().StrProp, c3.StrProp);
    }
  }
}
