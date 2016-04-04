using Ensalamento.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ensalamento.BO.Interfaces
{
    public interface IAuditorioBo : IValidator<Auditorio>
    {
        void Adicionar(Auditorio auditorio);
        void Deletar(int id);
        Auditorio Mostrar(int id);
        void Editar(Auditorio auditorio);
        Auditorio ObterPorId(int id);
    }
}
