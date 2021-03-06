﻿using System;

namespace Ensalamento.Dominio
{
   public class Laboratorio
    {
        public int LaboratorioId { get; set; }
        public string Nome { get; set; }
        public int Capacidade { get; set; }
        public bool Status { get; set; }
        public DateTime DataCadastro { get; set; }
        public int BlocoId { get; set; }
        public string Tipo { get; set; }
        public string Descricao { get; set; }
        public virtual Bloco Bloco { get; set; }
    }
}
