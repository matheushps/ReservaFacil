using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ensalamento.Dominio;
using Ensalamento.ORM;
using Ensalamento.BO.Interfaces;
using System.Data.Entity;

namespace Ensalamento.BO
{
    public class SalaBo : ISalaBo
    {
        private Contexto db = new Contexto();

        /// <summary>
        /// Método usado para adicionar uma nova sala
        /// </summary>
        /// <param name="sala"></param>
        /// 

        public void Adicionar(Sala sala)
        {
            if (IsValidaCapacidade(sala.Capacidade))
            {
                sala.DataCadastro = DateTime.Now.ToLocalTime();
                db.Salas.Add(sala);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Método usado para apagar uma sala
        /// </summary>
        /// <param name="id"></param>
        public void Apagar(int id)
        {
            Sala sala = db.Salas.Find(id);
            db.Salas.Remove(sala);
            db.SaveChanges();
        }

        /// <summary>
        /// Método usado para mostrar uma sala
        /// </summary>
        /// <param name="id"></param>
        public Sala Mostrar(int id)
        {
            Sala sala = db.Salas.Find(id);
            return sala;
        }

        /// <summary>
        /// Método usado para editar uma sala
        /// </summary>
        /// <param name="id"></param>
        public void Editar(Sala sala)
        {
            db.Entry(sala).State = EntityState.Modified;
            db.SaveChanges();

        }

        public Sala ObterPorId(int id)
        {
            Sala sala = db.Salas.Find(id);
            return sala;
        }

        #region Validações

        /// <summary>
        /// Verifica se a capacidade é maior que zero
        /// </summary>
        /// <param name="capacidade"></param>
        /// <returns></returns>
        /// 
        public bool IsValidaCapacidade(int capacidade)
        {
            return capacidade > 0;
        }





        //public void Editar(Sala domain)
        //{
        //    throw new NotImplementedException();
        //}

        public void ValidaAdicionar(Sala domain)
        {
            throw new NotImplementedException();
        }

        public void ValidaApagar(Sala domain)
        {
            throw new NotImplementedException();
        }

        public void ValidaEditar(Sala domain)
        {
            throw new NotImplementedException();
        }
    }
        #endregion
}