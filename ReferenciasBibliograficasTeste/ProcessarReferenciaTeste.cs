using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework.Internal;
using ReferenciasBibliograficas.Serviços;
using ReferenciasBibliograficas.Entidades;
using System.Collections.Generic;

namespace ReferenciasBibliograficasTeste
{
    [TestClass]
    public class ProcessarReferenciaTeste
    {
        [TestMethod]
        public void ProcessarNomesTeste()
        {
            List<string> nomes = new List<string> { "SIlva", "Immanuel Kant", "Arthur Schopenhauer", "João cabral DE melo Neto" };
            List<string> valorEsperado = new List<string> { "SILVA", "KANT, Immanuel", "SCHOPENHAUER, Arthur", "MELO NETO, João Cabral de" };
            List<string> resultados = new List<string>();

            NormasABNT abnt = new NormasABNT(nomes);
            ProcessarReferencias _ref = new ProcessarReferencias();

            List<Autor> autores = _ref.ProcessarNomes(abnt);

            foreach (var autor in autores)
            {
                resultados.Add(autor.ToString());
            }

            CollectionAssert.AreEqual(valorEsperado, resultados, "Lista de nomes incorreta!");
        }
    }
}
