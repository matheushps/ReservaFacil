using Ensalamento.BO.Interfaces;
using Ensalamento.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ensalamento.BO
{
    public interface IBlocoBo : IValidator<Bloco>
    {
        void Adicionar(Bloco bloco);
        void Apagar(int id);
        Bloco Mostrar(int id);
        void Editar(Bloco bloco);
        Bloco ObterPorId(int id);
    }
}
