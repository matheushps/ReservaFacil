using Ensalamento.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ensalamento.BO.Interfaces
{
   public interface ISalaBo : IValidator<Sala>
    {
        void Adicionar(Sala sala);
        void Apagar(int id);
        Sala Mostrar(int id);
        void Editar(Sala sala);
        Sala ObterPorId(int id);
    }
}
