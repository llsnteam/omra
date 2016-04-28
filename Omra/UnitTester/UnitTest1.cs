using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Omra;
using Adatkezelő;
using System.Linq;

namespace UnitTester
{
    [TestClass]
    public class UnitTest1
    {
        [TestClass]
        public class UnitTester
        {
            [TestMethod]
            public void TestBizonyitek()
            {
                Adatkezelő.Kereséskezelő k = new Adatkezelő.Kereséskezelő();
                object returnType = k.Bizonyítékkeresés("").First();

                Assert.AreEqual(new Bizonyitekok(), returnType, "Jó");
            }

            [TestMethod]
            public void TestBuneset()
            {
                Adatkezelő.Kereséskezelő k = new Adatkezelő.Kereséskezelő();
                object returnType = k.Bűnesetkeresés("").First();

                Assert.AreEqual(typeof(Bűneset), returnType, "Jó");
            }

            [TestMethod]
            public void TestGyanusitott()
            {
                Adatkezelő.Kereséskezelő k = new Adatkezelő.Kereséskezelő();
                object returnType = k.Gyanúsítottkeresés("").First();

                Assert.AreEqual(typeof(Gyanúsított), returnType, "Jó");
            }
        }
    }
}
