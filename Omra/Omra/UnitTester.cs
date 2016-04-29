using Adatkezelő;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Omra
{
    [TestClass]
    public class UnitTester
    {

        [TestMethod]
        public void TestBizonyitek()
        {
            Adatkezelő.Kereséskezelő k = new Adatkezelő.Kereséskezelő();
            object returnType = k.Bizonyítékkeresés("").First();

            Assert.IsInstanceOfType(returnType, typeof(Bizonyíték));
        }

        [TestMethod]
        public void TestBuneset()
        {
            Adatkezelő.Kereséskezelő k = new Adatkezelő.Kereséskezelő();
            object returnType = k.Bűnesetkeresés("").First();

            Assert.IsInstanceOfType(returnType, typeof(Bűneset));
        }

        [TestMethod]
        public void TestGyanusitott()
        {
            Adatkezelő.Kereséskezelő k = new Adatkezelő.Kereséskezelő();
            object returnType = k.Gyanúsítottkeresés("").First();

            Assert.IsInstanceOfType(returnType, typeof(Gyanúsított));
        }
    }
    
}
