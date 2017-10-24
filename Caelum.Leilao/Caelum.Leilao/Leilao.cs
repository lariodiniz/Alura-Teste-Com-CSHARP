using System;
using System.Collections.Generic;
namespace Caelum.Leilao
{

    public class Leilao
    {

        public string Descricao { get; set; }
        public IList<Lance> Lances { get; set; }

        public Leilao(string descricao)
        {
            this.Descricao = descricao;
            this.Lances = new List<Lance>();
        }

        public void Propoe(Lance lance)
        {           

            if (Lances.Count == 0 || podeDarlance(lance.Usuario))
            {
                Lances.Add(lance);
            }

        }

        private bool podeDarlance(Usuario usuario)
        {
            return (!ultimoLanceDado().Usuario.Equals(usuario) && qtdDeLacesDo(usuario) < 5);
        }

        private int qtdDeLacesDo(Usuario usuario)
        {
            int total = 0;
            foreach (var l in Lances)
            {
                if (l.Usuario.Equals(usuario)) total++;
            }

            return total;
        }

        private Lance ultimoLanceDado()
        {
            return Lances[Lances.Count - 1];
        }

        private double ultimoLanceDadoPeloUsuario(Usuario usuario)
        {
            double lan = 0;
            foreach (var l in Lances)
            {
                if (l.Usuario.Equals(usuario)) lan = l.Valor;
            }

            return lan;
            
        }

        public void DobraLance(Usuario usuario)
        {
            double valor = ultimoLanceDadoPeloUsuario(usuario);
            if (valor > 0)
            {
                this.Propoe(new Lance(usuario, valor * 2));
            }           
        }
    }
}