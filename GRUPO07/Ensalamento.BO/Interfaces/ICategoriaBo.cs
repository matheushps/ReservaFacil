using Ensalamento.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensalamento.BO.Interfaces
{
   public interface ICategoriaBo : IValidator<Categoria>
    {
        void Adicionar(Categoria categoria);
        void Apagar(int id);
        Categoria Mostrar(int id);
        void Editar(Categoria categoria);
        Categoria ObterPorId(int id);
    }
}
