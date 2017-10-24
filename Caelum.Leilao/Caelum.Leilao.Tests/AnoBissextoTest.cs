using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;


namespace Caelum.Leilao
{
    [TestFixture]
    class AnoBissextoTest
    {
        [Test]
        public void EhBissexto()
        {
            AnoBissexto ano = new AnoBissexto();
            bool teste = ano.EhBissexto(2016);


            Assert.AreEqual(true, teste);
        }
    }

    [TestFixture]
    class AnoNaoBissextoTest
    {
        [Test]
        public void EhBissesto()
        {
            AnoBissexto ano = new AnoBissexto();
            bool teste = ano.EhBissexto(2017);


            Assert.AreEqual(false, teste);
        }
    }
}
