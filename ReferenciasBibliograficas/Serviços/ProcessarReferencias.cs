using ReferenciasBibliograficas.Entidades;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ReferenciasBibliograficas.Serviços
{
    public class ProcessarReferencias : IProcessarReferencias
    {
        //Método que processa os nomes recebendo como parâmetro a interface da norma, não sabendo exatamente qual é a norma utilizada,
        //realizando o desacoplamento e a Dependency Inversion Principle
        public List<Autor> ProcessarNomes(INormas norma)
        {
            return norma.OrganizarNomes();
        }
    }
}
