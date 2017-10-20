using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Caelum.Leilao
{
    [TestFixture]
    class MatematicaMalucaTest
    {
        [Test]
        public void VerificaNumeroMaiorQueTrinta()
        {
            // 1a parte: cenario
            MatematicaMaluca matematica = new MatematicaMaluca();

            // 2a parte: acao
            int numero = matematica.ContaMaluca(50);

            // 3a parte: validacao            
            Assert.AreEqual(200, numero);
        }

        [Test]
        public void VerificaNumeroMaiorQueDez()
        {
            // 1a parte: cenario
            MatematicaMaluca matematica = new MatematicaMaluca();

            // 2a parte: acao
            int numero = matematica.ContaMaluca(15);

            // 3a parte: validacao            
            Assert.AreEqual(45, numero);
        }

        [Test]
        public void VerificaNumeroMenorQueDez()
        {
            // 1a parte: cenario
            MatematicaMaluca matematica = new MatematicaMaluca();

            // 2a parte: acao
            int numero = matematica.ContaMaluca(5);

            // 3a parte: validacao            
            Assert.AreEqual(10, numero);
        }

        [Test]
        public void VerificaNumeroTrinta()
        {
            // 1a parte: cenario
            MatematicaMaluca matematica = new MatematicaMaluca();

            // 2a parte: acao
            int numero = matematica.ContaMaluca(30);

            // 3a parte: validacao            
            Assert.AreEqual(90, numero);
        }


        [Test]
        public void VerificaNumeroDez()
        {
            // 1a parte: cenario
            MatematicaMaluca matematica = new MatematicaMaluca();

            // 2a parte: acao
            int numero = matematica.ContaMaluca(10);

            // 3a parte: validacao            
            Assert.AreEqual(20, numero);
        }       
    }
}
