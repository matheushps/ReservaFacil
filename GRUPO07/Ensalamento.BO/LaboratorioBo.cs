using Ensalamento.Dominio;
using Ensalamento.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensalamento.BO
{
    public class LaboratorioBo
    {
        private Contexto db = new Contexto();

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
        /// Verifica se a capacidade é maior que zero
        /// </summary>
        /// <param name="capacidade"></param>
        /// <returns></returns>
        /// 
        private bool IsValidaCapacidade(int capacidade)
        {
            return capacidade > 0;
        }

    }
}
