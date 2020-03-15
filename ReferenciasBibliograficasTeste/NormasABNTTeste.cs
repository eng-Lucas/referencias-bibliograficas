using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReferenciasBibliograficas.Entidades;
using ReferenciasBibliograficas.Serviços;
using System.Collections.Generic;

namespace ReferenciasBibliograficasTeste
{
    [TestClass]
    public class NormasABNTTeste
    {
        [TestMethod]
        public void OrganizarNomesTeste()
        {
            List<string> nomes = new List<string> { "SIlva", "Immanuel Kant", "Arthur Schopenhauer", "João cabral DE melo Neto" };
            List<string> valorEsperado = new List<string> { "SILVA", "KANT, Immanuel", "SCHOPENHAUER, Arthur", "MELO NETO, João Cabral de" };
            List<string> resultados = new List<string>();

            NormasABNT abnt = new NormasABNT(nomes);

            List<Autor> autores = abnt.OrganizarNomes();

            foreach (var autor in autores)
            {
                resultados.Add(autor.ToString());
            }

            CollectionAssert.AreEqual(valorEsperado, resultados, "Lista de nomes incorreta!");
        }

        [TestMethod]
        public void NomesIncompletosTeste()
        {
            List<string> nomes = new List<string> { "GuiMaRaes" };

            string valorEsperado = "GUIMARAES";

            NormasABNT abnt = new NormasABNT(nomes);

            List<Autor> autores = abnt.NomesIncompletos();

            Assert.AreEqual(valorEsperado, autores[0].ToString(), "Nome retornado incorreto!");
        }

        [TestMethod]
        public void NomesCompletosTeste()
        {
            List<string> nomes = new List<string> { "Friedrich Wilhelm Nietzsche" };

            string valorEsperado = "NIETZSCHE, Friedrich Wilhelm";

            NormasABNT abnt = new NormasABNT(nomes);

            List<Autor> autores = abnt.NomesCompletos();

            Assert.AreEqual(valorEsperado, autores[0].ToString(), "Nome retornado incorreto!");
        }

        [TestMethod]
        public void NomesCompletosAgnomeTeste()
        {
            List<string> nomes = new List<string> { "João cabral DE melo Neto" };

            string valorEsperado = "MELO NETO, João Cabral de";

            NormasABNT abnt = new NormasABNT(nomes);

            List<Autor> autores = abnt.NomesCompletos();

            Assert.AreEqual(valorEsperado, autores[0].ToString(), "Nome retornado incorreto!");
        }
    }
}
