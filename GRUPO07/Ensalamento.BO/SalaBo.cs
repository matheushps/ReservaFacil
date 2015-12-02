using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ensalamento.Dominio;
using Ensalamento.ORM;

namespace Ensalamento.BO
{
    public class SalaBo
    {
        private Contexto db = new Contexto();

        public void Adicionar(Sala sala)
        {
            if (IsValidaCapacidade(sala.Capacidade)){
                sala.DataCadastro = DateTime.Now.ToLocalTime();
                db.Salas.Add(sala);
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