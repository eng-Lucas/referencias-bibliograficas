using ReferenciasBibliograficas.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReferenciasBibliograficas.Serviços
{
    public interface IProcessarReferencias
    {
        List<Autor> ProcessarNomes(INormas norma);
    }
}
