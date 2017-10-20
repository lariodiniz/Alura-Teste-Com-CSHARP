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
        [Test]
        public void DeveEntenderLancesEmOrdemCrescente()
        {
            // 1a parte: cenario
            Usuario joao = new Usuario("Joao");
            Usuario jose = new Usuario("Jose");
            Usuario maria = new Usuario("Maria");

            Leilao leilao = new Leilao("Playstation 3 Novo");

            leilao.Propoe(new Lance(maria, 250.0));
            leilao.Propoe(new Lance(joao, 300.0));
            leilao.Propoe(new Lance(jose, 400.0));

            // 2a parte: acao
            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            // 3a parte: validacao
            double maiorEsperado = 400;
            double menorEsperado = 250;

            Assert.AreEqual(maiorEsperado, leiloeiro.MaiorLance);
            Assert.AreEqual(menorEsperado, leiloeiro.Menorlance);
        }
        
        [Test]
        public void DeveEndenderLeilaoComApenasUmLance()
        {
            Usuario joao = new Usuario("Joao");
            Leilao leilao = new Leilao("Playstation 3 Novo");

            leilao.Propoe(new Lance(joao, 1000.0));

            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            Assert.AreEqual(1000.0, leiloeiro.MaiorLance, 0.0001);
            Assert.AreEqual(1000.0, leiloeiro.Menorlance, 0.0001);

        }

        [Test]
        public void DeveEntenderLancesEmOrdemAleatoria()
        {
            // 1a parte: cenario
            Usuario joao = new Usuario("Joao");
            Usuario jose = new Usuario("Jose");
            Usuario maria = new Usuario("Maria");

            Leilao leilao = new Leilao("Playstation 3 Novo");

            leilao.Propoe(new Lance(maria, 250.0));
            leilao.Propoe(new Lance(jose, 400.0));
            leilao.Propoe(new Lance(joao, 300.0));
            leilao.Propoe(new Lance(jose, 100.0));
            leilao.Propoe(new Lance(maria, 500.0));
            leilao.Propoe(new Lance(joao, 75.0));

            // 2a parte: acao
            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            // 3a parte: validacao

            Assert.AreEqual(500.0, leiloeiro.MaiorLance, 0.001);
            Assert.AreEqual(75.0, leiloeiro.Menorlance, 0.001);
        }

        [Test]
        public void DeveEntenderLancesEmOrdemDecrescente()
        {
            // 1a parte: cenario
            Usuario joao = new Usuario("Joao");
            Usuario jose = new Usuario("Jose");
            Usuario maria = new Usuario("Maria");

            Leilao leilao = new Leilao("Playstation 3 Novo");
                        
            leilao.Propoe(new Lance(jose, 400.0));
            leilao.Propoe(new Lance(joao, 300.0));
            leilao.Propoe(new Lance(maria, 200.0));            
            leilao.Propoe(new Lance(joao, 100.0));

            // 2a parte: acao
            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            // 3a parte: validacao

            Assert.AreEqual(400.0, leiloeiro.MaiorLance, 0.001);
            Assert.AreEqual(100.0, leiloeiro.Menorlance, 0.001);
        }

        [Test]
        public void DeveEncontrarOsTresMaioresLances()
        {
            Usuario joao = new Usuario("Joao");
            Usuario maria = new Usuario("Maria");
            Leilao leilao = new Leilao("Playstation 3 Novo");

            leilao.Propoe(new Lance(joao, 100.0));
            leilao.Propoe(new Lance(maria, 200.0));
            leilao.Propoe(new Lance(joao, 300.0));
            leilao.Propoe(new Lance(maria, 400.0));
            
            Avaliador leiloeiro = new Avaliador();
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
            Usuario joao = new Usuario("Joao");
            Usuario maria = new Usuario("Maria");
            Leilao leilao = new Leilao("Playstation 3 Novo");

            leilao.Propoe(new Lance(joao, 100.0));            
            leilao.Propoe(new Lance(maria, 400.0));

            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            var maiores = leiloeiro.TresMaiores;

            Assert.AreEqual(2, maiores.Count);

            Assert.AreEqual(400, maiores[0].Valor, 0.001);
            Assert.AreEqual(100, maiores[1].Valor, 0.001);            
        }

        [Test]
        public void DeveEncontraNenhumLance()
        {
            
            Leilao leilao = new Leilao("Playstation 3 Novo");

            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            var maiores = leiloeiro.TresMaiores;

            Assert.AreEqual(0, maiores.Count);            
        }
    }
}
