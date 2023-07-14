using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UIoC.Tests.Attributes {
  [TestClass]
  public class SingletonAttributeTests {

    [Singleton]
    internal class C {
      public int IntProp { get; set; } = 0;
    }

    [TestMethod]
    public void Test() {
      IContainer container = new Container();
      container.AddFromAssembly(Assembly.GetExecutingAssembly());


      var c1 = (C)container.Get(typeof(C), null);
      Assert.IsNotNull(c1);
      Assert.AreEqual(c1.IntProp, 0);

      c1.IntProp++;
      Assert.AreEqual(c1.IntProp, 1);


      var c2 = (C)container.Get(typeof(C), null);
      Assert.IsNotNull(c2);
      Assert.AreEqual(c2.IntProp, 1);

      Assert.AreEqual(c1, c2);
    }
  }
}
