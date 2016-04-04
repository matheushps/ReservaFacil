using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ensalamento.Dominio;
using Ensalamento.ORM;
using System.Data.Entity;

namespace Ensalamento.BO
{
    public class ReservaBo : IReservaBo
    {
        private Contexto db = new Contexto();

        public void Adicionar(Reserva reserva)
        {
            reserva.DataCadastro = DateTime.Now.ToLocalTime();
            db.Reservas.Add(reserva);
            db.SaveChanges();
        }

        public Reserva Mostrar(int id)
        {
            Reserva reserva = db.Reservas.Find(id);
            return reserva;
        }

        public void Editar(Reserva reserva)
        {
            db.Entry(reserva).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Apagar(int id) 
        {
            Reserva reserva = db.Reservas.Find(id);
            db.Reservas.Remove(reserva);
            db.SaveChanges();
        }

        public Reserva ObterPorId(int id)
        {
            Reserva reserva = db.Reservas.Find(id);
            return reserva;
        }

        public void ValidaAdicionar(Reserva domain)
        {
            throw new NotImplementedException();
        }

        public void ValidaApagar(Reserva domain)
        {
            throw new NotImplementedException();
        }

        public void ValidaEditar(Reserva domain)
        {
            throw new NotImplementedException();
        }
    }
}
