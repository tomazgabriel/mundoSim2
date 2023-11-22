using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mundoSim2
{
    internal class Ferramentas
    {
        public static int GerarAleatorio(int valorMaximo)
        {
            Random rnd = new Random();
            int re = rnd.Next(0, (valorMaximo + 1));
            return re;
        }

        public static string MontarSilaba(string[] silabas)
        {
            string nomeGerado;

            int x = GerarAleatorio(silabas.Length - 1);
            int z = GerarAleatorio(silabas.Length - 1);
            int y = GerarAleatorio(silabas.Length - 1);
            int k = GerarAleatorio(silabas.Length - 1);
            int m = GerarAleatorio(silabas.Length - 1);
            int n = GerarAleatorio(silabas.Length - 1);

            int qtSilabas = GerarAleatorio(4);
            switch (qtSilabas)
            {
                case 0:
                    nomeGerado = silabas[x];
                    return char.ToUpper(nomeGerado[0]) + nomeGerado.Substring(1);
                    break;
                case 1:
                    nomeGerado = silabas[x] + silabas[z];
                    return char.ToUpper(nomeGerado[0]) + nomeGerado.Substring(1);
                    break;
                case 2:
                    nomeGerado = silabas[x] + silabas[z] + silabas[x];
                    return char.ToUpper(nomeGerado[0]) + nomeGerado.Substring(1);
                    break;
                case 3:
                    nomeGerado = silabas[x] + silabas[z] + silabas[y];
                    return char.ToUpper(nomeGerado[0]) + nomeGerado.Substring(1);
                    break;
                case 4:
                    int s = GerarAleatorio(1);
                    if(s == 0)
                    {
                        nomeGerado = silabas[x] + silabas[z] + silabas[y] + silabas[k];
                        return char.ToUpper(nomeGerado[0]) + nomeGerado.Substring(1);
                    }
                    else
                    {
                        string ajuste = silabas[m].ToUpper().Substring(0, 1) + silabas[m].Substring(1);
                        nomeGerado = silabas[x] + silabas[z] + silabas[y] + " " + ajuste + silabas[n];
                        return char.ToUpper(nomeGerado[0]) + nomeGerado.Substring(1);
                    }
                    break;
                default:
                    nomeGerado = silabas[x] + silabas[z];
                    return char.ToUpper(nomeGerado[0]) + nomeGerado.Substring(1);
                    break;
            }
        }

        public static string GerarNome(int genero, string[] nomeM, string[] nomeF, string[] silaba)
        {
            int x = GerarAleatorio(1);
            if(x == 1)
            {
                if (genero == 0) return MontarSilaba(silaba) + "zo";
                else return MontarSilaba(silaba) + "sa";
            }
            if (x == 0)
            {
                if (genero == 0) return MontarSilaba(silaba) + "l";
                else return MontarSilaba(silaba) + "la";
            }
            if (genero == 0) return nomeM[GerarAleatorio(nomeM.Length -1)] + "zo";
            else return nomeF[GerarAleatorio(nomeF.Length -1)] + "sa";
        }


    }
}
