using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UIoC.Tests.Attributes {
  [TestClass]
  public class ResolveNameAttributeTests {

    private interface I1 {
      public string StrProp { get; }
    }
    private class C1A : I1 {
      public string StrProp => "C1A";
    }
    private class C1B : I1 {
      public string StrProp => "C1B";
    }

    private class C2 {
      internal I1 _i1;
      public C2([ResolveName("C1B")] I1 i1) { _i1 = i1; }
      public string StrProp => _i1.StrProp;
    }

    [TestMethod]
    public void Test() {
      IContainer container = new Container();

      container.AddType(typeof(I1), "C1A", typeof(C1A));
      container.AddType(typeof(I1), "C1B", typeof(C1B));
      container.AddType(typeof(C2), null, typeof(C2));

      Assert.AreEqual(((C2)container.Get(typeof(C2), null)).StrProp, "C1B");
    }
  }
}
