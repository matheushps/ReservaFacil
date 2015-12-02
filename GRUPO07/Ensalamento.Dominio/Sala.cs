using System;

namespace Ensalamento.Dominio
{
   public class Sala
    {
       public int SalaId { get; set; }
       public string Nome { get; set; }
       public int Capacidade { get; set; }
       public bool Status { get; set; }
       public DateTime DataCadastro { get; set; }
       public int BlocoId { get; set; }
       public virtual Bloco Bloco { get; set; }

    }
   
}
