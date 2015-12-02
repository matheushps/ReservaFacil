using System;

namespace Ensalamento.Dominio
{
    public class Pessoa
    {
        public int PessoaId { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public bool Status { get; set; }
        public DateTime DataCadastro { get; set; }
        public int CategoriaId { get; set; }
        public virtual Categoria Categorias { get; set; }
    }
}