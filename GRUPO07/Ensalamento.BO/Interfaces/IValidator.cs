using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ensalamento.BO.Interfaces
{
   public interface IValidator<T> where T : class
    {
        void ValidaAdicionar(T domain);
        void ValidaApagar(T domain);
        void ValidaEditar(T domain);
    }
}
