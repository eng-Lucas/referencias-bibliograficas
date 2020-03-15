using ReferenciasBibliograficas.Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ReferenciasBibliograficas.Serviços
{
    public class NormasABNT : INormas
    {
        private List<string> Nomes { get; set; }

        public NormasABNT(List<string> nomes)
        {
            Nomes = nomes;
        }

        public List<Autor> OrganizarNomes()
        {
            //Processa os nomes incompletos primeiro
            List<Autor> Autores = NomesIncompletos();

            //Processa os demais nomes
            Autores.AddRange(NomesCompletos());

            return Autores;
        }

        public List<Autor> NomesIncompletos()
        {
            List<Autor> autores = new List<Autor>();

            //Seleciona apenas os nomes incompletos
            var nomesIncompletos = Nomes.Where(nome => !nome.Trim().Contains(' '));

            //Remove da lista inicial os nomes incompletos
            Nomes = Nomes.Except(nomesIncompletos).ToList();
            
            foreach (var nome in nomesIncompletos)
            {
                autores.Add(new Autor(null, nome.Trim()));
            }

            return autores;
        }

        public List<Autor> NomesCompletos()
        {
            List<Autor> autores = new List<Autor>();

            foreach (var nome in Nomes)
            {
                //Divide os nomes em um array pelos espaços
                string[] aux = nome.Trim().Split(' ');

                //Verifica se o último nome é um Agnome
                if (Regex.IsMatch(aux.Last(), @"(?:FILHO|FILHA|NETO|NETA|SOBRINHO|SOBRINHA|JUNIOR|JÚNIOR)", RegexOptions.IgnoreCase))
                    //Adiciona na lista de autores o autor processado caso o último nome seja um Agnome
                    autores.Add(new Autor(string.Join(" ", aux.Take(aux.Length - 2).ToArray()), aux[aux.Length - 2] + " " + aux[aux.Length - 1]));
                else
                    //Adiciona na lista de autores o autor processado
                    autores.Add(new Autor(string.Join(" ", aux.Take(aux.Length - 1).ToArray()), aux.Last()));
            }

            return autores;
        }
    }
}
