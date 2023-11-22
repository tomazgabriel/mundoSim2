using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace mundoSim2
{
    class Program
    {
        public static void Main(string[] args)
        {
            bool play = true;

            List<Pessoa> listaPessoas = new List<Pessoa>();
            int tamanhoLista = listaPessoas.Count;
            int nrInicial = 15;

            //dados populacionais
            List<Pessoa> nascidos = new List<Pessoa>();
            List<Pessoa> mortos = new List<Pessoa>();
            List<Pessoa> homens = new List<Pessoa>();
            List<Pessoa> div1 = new List<Pessoa>();
            int qtHomens = 0;
            int qtMulheres = 0;
            List<Pessoa> mulheres = new List<Pessoa>();
            int minFertil = 15;
            int maxFertil = 35;
            int alimentosProduzidos = 0;
            int recursosProduzidos = 0;
            int intel = 0;
            int contagemNascimentos = 0;
            int contagemMortos = 0;


            //pop inicial
            for (int i = 0; i < nrInicial; i++)
            {
                Pessoa p = new Pessoa(true);
                listaPessoas.Add(p);
                if(p.Genero == 0)
                {
                    homens.Add(p);
                }
                else
                {
                    mulheres.Add(p);
                }
            }
            //separar generos


            //gerar Mundo
            Mundo mundo = new Mundo();
            mundo.Pop = listaPessoas.Count;

            while(play == true)
            {

                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("Ano: " + mundo.Ano);
                Console.WriteLine("Pop: " + mundo.Pop);
                Console.WriteLine("Homens: " + qtHomens + " Mulheres: " + qtMulheres);
                Console.WriteLine("Nascimentos: " + contagemNascimentos);
                Console.WriteLine("Mortos: " + contagemMortos);
                Console.WriteLine("Alimentos Disponíveis: " + mundo.Comida);
                Console.WriteLine("Recursos Disponíveis: " + mundo.Recursos);
                Console.WriteLine("Tecnologia: " + mundo.Tech);
                Console.WriteLine("\n");
                Console.WriteLine("Evolução " + intel);
                Console.WriteLine("Alimentos Produzidos: " + alimentosProduzidos);
                Console.WriteLine("Recursos Produzidos: " + recursosProduzidos);
                Console.Write("\n");

                //separa a lista de pessoas
                foreach(Pessoa pessoa in listaPessoas.GetRange(0, (listaPessoas.Count) / 2))
                {
                    div1.Add(pessoa);
                    listaPessoas.Remove(pessoa);
                }

                var t1 = Task.Factory.StartNew(() => 
                {
                    foreach (Pessoa pessoa in listaPessoas)
                    {
                        
                        //envelhecer
                        if (pessoa.Envelhecer(pessoa) == true)
                        {
                            mortos.Add(pessoa);
                            //Console.WriteLine(pessoa.Nome + " Morreu aos: " + pessoa.Idade);
                        }
                        //reproducão
                        if (pessoa.Reproduzir(minFertil, maxFertil, pessoa.Genero) == true)
                        {
                            Pessoa novaPessoa = new Pessoa();
                            nascidos.Add(novaPessoa);
                            if (novaPessoa.Genero == 0)
                            {
                                homens.Add(novaPessoa);
                            }
                            else
                            {
                                mulheres.Add(novaPessoa);
                            }
                            //Console.WriteLine(novaPessoa.Nome + " Filho(ª) de " + pessoa.Nome+"|" + pessoa.Idade + " nasceu.");
                        }
                    }
                });

                var t2 = Task.Factory.StartNew(() =>
                {
                    foreach (Pessoa pessoa in div1)
                    {
                     
                        //envelhecer
                        if (pessoa.Envelhecer(pessoa) == true)
                        {
                            mortos.Add(pessoa);
                            //Console.WriteLine(pessoa.Nome + " Morreu aos: " + pessoa.Idade);
                        }
                        //reproducão
                        if (pessoa.Reproduzir(minFertil, maxFertil, pessoa.Genero) == true)
                        {
                            Pessoa novaPessoa = new Pessoa();
                            nascidos.Add(novaPessoa);
                            if (novaPessoa.Genero == 0)
                            {
                                homens.Add(novaPessoa);
                            }
                            else
                            {
                                mulheres.Add(novaPessoa);
                            }
                            //Console.WriteLine(novaPessoa.Nome + " Filho(ª) de " + pessoa.Nome+"|" + pessoa.Idade + " nasceu.");
                        }
                    }
                });

                Task.WaitAll(t1, t2);

                //junta a lista de pessoas novamente
                foreach (Pessoa pessoa in div1)
                {
                    listaPessoas.Add(pessoa);
                }
                div1.Clear();

                //Remover os mortos da lista pop
                foreach (Pessoa morto in mortos)
                {
                    listaPessoas.Remove(morto);
                    if(morto.Genero == 0)
                    {
                        homens.Remove(morto);
                    }
                    else
                    {
                        mulheres.Remove(morto);
                    }
                }
                //Salvar os nascidos na lista pop
                foreach (Pessoa nascido in nascidos)
                {
                    listaPessoas.Add(nascido);
                }

                contagemNascimentos = nascidos.Count;
                contagemMortos= mortos.Count;
                qtHomens = homens.Count;
                qtMulheres = mulheres.Count;
                nascidos.Clear(); //limpar listagem de nascidos para o prox ano
                mortos.Clear(); //limpar listagem de mortos para o prox ano
                mundo.Ano += 1;
                mundo.Pop = listaPessoas.Count;

                if (mundo.Ano >= 20000 || mundo.Pop == 0) play = false;
            }
        }
    }
}