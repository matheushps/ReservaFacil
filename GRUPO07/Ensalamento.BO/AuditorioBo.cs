using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ensalamento.Dominio;
using Ensalamento.ORM;

namespace Ensalamento.BO
{
   public class AuditorioBo
    { 
       private Contexto db = new Contexto();

       public void Adicionar ( Auditorio auditorio)
       {
           if (IsValidaCapacidade(auditorio.Capacidade))
           {
               auditorio.DataCadastro = DateTime.Now.ToLocalTime();
               db.Auditorios.Add(auditorio);
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
