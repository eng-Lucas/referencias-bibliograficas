using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ReferenciasBibliograficas.Entidades
{
    public class Autor
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }

        public Autor(string nome, string sobrenome)
        {
            Nome = nome;
            Sobrenome = sobrenome;
        }

        public override string ToString()
        {
            return Nome != null 
                ? Sobrenome.ToUpper() + ", " + Regex.Replace(
                    CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Nome.ToLower()), @"(?: DA| DE| DO| DAS| DOS) {0,4}", m => m.ToString().ToLower(), RegexOptions.IgnoreCase) 
                : Sobrenome.ToUpper();
        }
    }
}
