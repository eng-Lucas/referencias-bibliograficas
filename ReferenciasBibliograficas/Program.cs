using ReferenciasBibliograficas.Entidades;
using ReferenciasBibliograficas.Serviços;
using System;
using System.Collections.Generic;

namespace ReferenciasBibliograficas
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Quantidade de nomes: ");
            int qtdNomes = 0;

            if (int.TryParse(Console.ReadLine(), out qtdNomes))
            {
                try
                {
                    List<string> nomes = new List<string>();

                    //Receber os nomes
                    for (int i = 1; i <= qtdNomes; i++)
                    {
                        Console.Write(i + "º nome: ");
                        nomes.Add(Console.ReadLine());
                    }

                    //Instância das classes
                    NormasABNT abnt = new NormasABNT(nomes);
                    ProcessarReferencias _ref = new ProcessarReferencias();

                    //Processando os nomes e passando como parâmetro a norma utilizada
                    List<Autor> Autores = _ref.ProcessarNomes(abnt);

                    //Ordenando em ordem alfabética com Linq
                    Autores.Sort((autor1, autor2) => autor1.Sobrenome.ToUpper().CompareTo(autor2.Sobrenome.ToUpper()));

                    //Exibindo os nomes
                    Console.WriteLine();
                    Autores.ForEach(autor => Console.WriteLine(autor.ToString()));
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Houve um erro ao processar os nomes. " + ex.Message);
                }
            }
            else
                Console.WriteLine("Digite apenas números");
        }
    }
}
