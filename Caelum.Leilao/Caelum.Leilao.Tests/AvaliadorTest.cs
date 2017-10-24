using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Leilao
{
    [TestFixture]
    public class AvaliadorTest
    {
        private Avaliador leiloeiro;
        private Usuario joao;
        private Usuario jose;
        private Usuario maria;

        [SetUp]
        public void CriaAvaliador()
        {
            this.leiloeiro = new Avaliador();

            this.joao = new Usuario("Joao");
            this.jose = new Usuario("Jose");
            this.maria = new Usuario("Maria");
        }

        [Test]
        public void DeveEntenderLancesEmOrdemCrescente()
        {
            Leilao leilao = new CriadorDeLeilao().Para("Playstation 3 Novo")
                        .Lance(maria, 250)
                        .Lance(joao, 300)
                        .Lance(jose, 400)    
                        .Constroi();

            // 2a parte: acao            
            leiloeiro.Avalia(leilao);

            // 3a parte: validacao
            double maiorEsperado = 400;
            double menorEsperado = 250;

            Assert.AreEqual(maiorEsperado, leiloeiro.MaiorLance);
            Assert.AreEqual(menorEsperado, leiloeiro.Menorlance);
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void naoDeveAvaliarLeilaoesSemnenhumLanceDado()
        {
           Leilao leilao = new CriadorDeLeilao().Para("Playstation 3 Novo")
                        .Constroi();
            
           leiloeiro.Avalia(leilao);
        }

        [Test]
        public void DeveEndenderLeilaoComApenasUmLance()
        {
            
            Leilao leilao = new CriadorDeLeilao().Para("Playstation 3 Novo")
            .Lance(joao, 1000)
            .Lance(joao, 1000)
            .Constroi();            
                        
            leiloeiro.Avalia(leilao);

            Assert.AreEqual(1000.0, leiloeiro.MaiorLance, 0.0001);
            Assert.AreEqual(1000.0, leiloeiro.Menorlance, 0.0001);

        }

        [Test]
        public void DeveEntenderLancesEmOrdemAleatoria()
        {
            // 1a parte: cenario

            Leilao leilao = new CriadorDeLeilao().Para("Playstation 3 Novo")
            .Lance(maria, 250)
            .Lance(jose, 400)
            .Lance(joao, 300.0)
            .Lance(jose, 100.0)
            .Lance(maria, 500.0)
            .Lance(joao, 75.0)            
            .Constroi();

            // 2a parte: acao            
            leiloeiro.Avalia(leilao);

            // 3a parte: validacao

            Assert.AreEqual(500.0, leiloeiro.MaiorLance, 0.001);
            Assert.AreEqual(75.0, leiloeiro.Menorlance, 0.001);
        }

        [Test]
        public void DeveEntenderLancesEmOrdemDecrescente()
        {
            // 1a parte: cenario
            Leilao leilao = new CriadorDeLeilao().Para("Playstation 3 Novo")
                    .Lance(jose, 400.0)
                    .Lance(joao, 300.0)
                    .Lance(maria, 200.0)
                    .Lance(joao, 100.0)                    
                    .Constroi();
            
            // 2a parte: acao            
            leiloeiro.Avalia(leilao);

            // 3a parte: validacao

            Assert.AreEqual(400.0, leiloeiro.MaiorLance, 0.001);
            Assert.AreEqual(100.0, leiloeiro.Menorlance, 0.001);
        }

        [Test]
        public void DeveEncontrarOsTresMaioresLances()
        {
            Leilao leilao = new CriadorDeLeilao().Para("Playstation")
                .Lance(joao, 100)
                .Lance(maria, 200)
                .Lance(joao, 300)
                .Lance(maria, 400)
                .Constroi();
   
                        
            leiloeiro.Avalia(leilao);

            var maiores = leiloeiro.TresMaiores;

            Assert.AreEqual(3, maiores.Count);

            Assert.AreEqual(400, maiores[0].Valor, 0.001);
            Assert.AreEqual(300, maiores[1].Valor, 0.001);
            Assert.AreEqual(200, maiores[2].Valor, 0.001);
        }

        [Test]
        public void DeveEncontrarOsDoisMaioresLances()
        {

            Leilao leilao = new CriadorDeLeilao().Para("Playstation 3 Novo")
                        .Lance(joao, 100.0)
                        .Lance(maria, 400.0)

                        .Constroi();


            leiloeiro.Avalia(leilao);

            var maiores = leiloeiro.TresMaiores;

            Assert.AreEqual(2, maiores.Count);

            Assert.AreEqual(400, maiores[0].Valor, 0.001);
            Assert.AreEqual(100, maiores[1].Valor, 0.001);            
        }

        [Test]
        public void DeveEncontraNenhumLance()
        {

            Leilao leilao = new CriadorDeLeilao().Para("Playstation 3 Novo")
            .Constroi();

            leiloeiro.Avalia(leilao);

            var maiores = leiloeiro.TresMaiores;

            Assert.AreEqual(0, maiores.Count);            
        }

        [TearDown]
        public void Finaliza()
        {
            Console.WriteLine("fim");
        }
       
    }
}
