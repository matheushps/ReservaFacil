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
    public class AuditorioBo : IAuditorioBo
    {
        private Contexto db = new Contexto();

        public void Adicionar(Auditorio auditorio)
        {
            if (IsValidaCapacidade(auditorio.Capacidade))
            {
                auditorio.DataCadastro = DateTime.Now.ToLocalTime();
                db.Auditorios.Add(auditorio);
                db.SaveChanges();
            }
        }
        public void Deletar(int id)
        {
            Auditorio auditorio = db.Auditorios.Find(id);
            db.Auditorios.Remove(auditorio);
            db.SaveChanges();
        }

        public void Editar(Auditorio auditorio)
        {
            db.Entry(auditorio).State = EntityState.Modified;
            db.SaveChanges();
        }

        public Auditorio Mostrar(int id)
        {
            Auditorio auditorio = db.Auditorios.Find(id);
            return auditorio;
        }
        public Auditorio ObterPorId(int id)
        {
            Auditorio auditorio = db.Auditorios.Find(id);
            return auditorio;
        }

        #region validacoes
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

        public bool IsValidaId(int id)
        {
            return id > 0;
        }

        // public bool IsValida

        # endregion


        //public void Editar(Auditorio domain)
        //{
        //    throw new NotImplementedException();
        //}

        public void ValidaAdicionar(Auditorio domain)
        {
            throw new NotImplementedException();
        }

        public void ValidaApagar(Auditorio domain)
        {
            throw new NotImplementedException();
        }

        public void ValidaEditar(Auditorio domain)
        {
            throw new NotImplementedException();
        }
    }
}
