using Ensalamento.BO.Interfaces;
using Ensalamento.Dominio;
using Ensalamento.ORM;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensalamento.BO
{
    public class LaboratorioBo : ILaboratorioBo
    {
        private Contexto db = new Contexto();

        /// <summary>
        /// Método usado para adicionar uma nova sala
        /// </summary>
        /// <param name="sala"></param>
        public void Adicionar(Laboratorio laboratorio)
        {
            if (IsValidaCapacidade(laboratorio.Capacidade))
            {
                laboratorio.DataCadastro = DateTime.Now.ToLocalTime();
                db.Laboratorios.Add(laboratorio);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Método usado para apagar uma sala
        /// </summary>
        /// <param name="id"></param>
        public void Apagar(int id)
        {
            Laboratorio laboratorio = db.Laboratorios.Find(id);
            db.Laboratorios.Remove(laboratorio);
            db.SaveChanges();
        }

        public void Editar (Laboratorio laboratorio)
        {
            db.Entry(laboratorio).State = EntityState.Modified;
            db.SaveChanges();
            
        }

        public Laboratorio Mostrar(int id)
        {
            Laboratorio laboratorio = db.Laboratorios.Find(id);
            return laboratorio;
        }
        
        public Laboratorio ObterPorId(int id)
        {
            Laboratorio laboratorio = db.Laboratorios.Find(id);
            return laboratorio;
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

        public void ValidaAdicionar(Laboratorio domain)
        {
            throw new NotImplementedException();
        }

        public void ValidaApagar(Laboratorio domain)
        {
            throw new NotImplementedException();
        }

        public void ValidaEditar(Laboratorio domain)
        {
            throw new NotImplementedException();
        }
    }
    #endregion
}
