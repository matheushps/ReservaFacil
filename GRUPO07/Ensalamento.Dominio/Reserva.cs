using System;

namespace Ensalamento.Dominio
{
    public class Reserva
    {
        public int ReservaId { get; set; }
        public DateTime DataInicio {get; set;}
        public DateTime DataFim { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFim { get; set; }
        public DateTime DataCadastro { get; set; }
        public int PessoaId { get; set; }
        public virtual Pessoa Pesssoas { get; set; }
        public int SalaId { get; set; }
        public virtual Sala Salas {get; set;}
        public int LaboratorioId { get; set; }
        public virtual Laboratorio Laboratorios { get; set; }
        public int AuditorioId { get; set; }
        public virtual Auditorio Auditorios { get; set; }

    }
}
