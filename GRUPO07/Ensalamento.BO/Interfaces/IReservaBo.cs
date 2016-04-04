using Ensalamento.BO.Interfaces;
using Ensalamento.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ensalamento.BO
{
    public interface IReservaBo : IValidator<Reserva>
    {
        void Adicionar(Reserva reserva);
        void Apagar(int id);
        Reserva Mostrar(int id);
        void Editar(Reserva reserva);
        Reserva ObterPorId(int id);
    }
}
