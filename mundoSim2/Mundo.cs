using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mundoSim2
{
    internal class Mundo
    {
        public int Ano {  get; set; }
        public int TerraFertil = Ferramentas.GerarAleatorio(1000);
        public int Comida { get; set; }
        public int Pop {  get; set; }
        public int Recursos {  get; set; }

        public int Tech {  get; set; }

        public Mundo()
        {
            Ano = 1;
            Comida = TerraFertil / (Ferramentas.GerarAleatorio(500)+1);
            TerraFertil -= Comida;
            Recursos = TerraFertil;
            TerraFertil -= Recursos;
            Pop = 0;
            Tech = 0;
        }
    }
}
