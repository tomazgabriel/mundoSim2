using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace mundoSim2
{
    internal class Pessoa
    {
        public string[] nomesM = {"Bingo","Juvenal","Kevin","Fabricio","Matheus","Jefter"};
        public string[] nomesF = { "Binga", "Gerusa","Joyce","Matheusa","Thiphany","Cacilda" };
        public string[] silabas = { "ba", "be", "bi", "bo", "bu", "ca", "ce", "ci", "co", "cu",
            "da", "de", "di", "do", "du", "fa", "fe", "fi", "fo", "fu", "ga", "ge", "gi", "go", 
            "gu", "ha", "he", "hi", "ho", "hu","ja", "je", "ji", "jo", "ju","ka", "ke", "ki", "ko", "ku",
            "la", "le", "li", "lo", "lu", "ma", "me", "mi", "mo", "mu", "na", "ne", "ni", "no", "nu",
            "pa", "pe", "pi", "po", "pu", "qua", "que", "qui", "quo", "vin","ra", "re", "ri", "ro", "ru",
            "ta","te","ti","to","tu","va","ve","vi","vo","vu","xa","xe","xi","xo","xu","rra","rre","rri","rro","rru",
            "an","en","in","on","un"};
        public string Nome {  get; set; }
        public int Genero {  get; set; }
        public int Idade {  get; set; }
        

        public bool Envelhecer(Pessoa pessoa) 
        {
            //aumentar idade
            pessoa.Idade += 1;

            //morte baseado em chance
            if (pessoa.Idade >= 60 && pessoa.Idade <= 80)
            {
                int x = Ferramentas.GerarAleatorio(10);
                if(x == 5) return true;
            }
            if(pessoa.Idade > 80)
            {
                int x = Ferramentas.GerarAleatorio(5);
                if(x == 5) return true;
            }
            else return false;
            return false;
        }
        public bool Reproduzir(int idadeMin, int idadeMax, int genero)
        {
            if(genero == 0) return false;
            if (Idade >= idadeMin && Idade <= idadeMax)
            {
                if(Idade >= 15 && Idade <= 20) 
                {
                    int n = Ferramentas.GerarAleatorio(5);
                    if(n == 5) return true;
                }
                else
                {
                    int n = Ferramentas.GerarAleatorio(10);
                    if (n == 5) return true;
                }

            }
            else return false;
            return false;
        }

        public Pessoa() 
        {
            this.Genero = Ferramentas.GerarAleatorio(1);
            this.Nome = Ferramentas.GerarNome(Genero, nomesM, nomesF, silabas);
            this.Idade = 0;
        }

        public Pessoa(bool idadeAleatoria) 
        {
            this.Genero = Ferramentas.GerarAleatorio(1);
            this.Nome = Ferramentas.GerarNome(Genero, nomesM, nomesF, silabas);
            this.Idade = Ferramentas.GerarAleatorio(35);
        }
        
    }
}
