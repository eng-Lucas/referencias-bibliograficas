using ReferenciasBibliograficas.Entidades;
using System.Collections.Generic;

namespace ReferenciasBibliograficas.Serviços
{
    public interface INormas
    {
        List<Autor> OrganizarNomes();
    }
}
