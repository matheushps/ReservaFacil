using Ensalamento.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensalamento.BO.Interfaces
{
   public interface ILaboratorioBo : IValidator<Laboratorio>
    {
       void Adicionar(Laboratorio laboratorio);
        void Apagar(int id);
        Laboratorio Mostrar(int id);
        void Editar(Laboratorio laboratorio);
        Laboratorio ObterPorId(int id);
    }
}
