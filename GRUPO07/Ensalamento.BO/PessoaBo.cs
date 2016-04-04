using Ensalamento.BO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ensalamento.Dominio;
using Ensalamento.ORM;
using System.Data.Entity;

namespace Ensalamento.BO
{
    public class PessoaBo : IPessoaBo
    {
        private Contexto db = new Contexto();

        public void Adicionar(Pessoa pessoa)
        {
            pessoa.DataCadastro = DateTime.Now.ToLocalTime();
            db.Pessoas.Add(pessoa);
            db.SaveChanges();
        }

        public void Deletar(int id)
        {
            Pessoa pessoa = db.Pessoas.Find(id);
            db.Pessoas.Remove(pessoa);
            db.SaveChanges();
        }

        public void Editar(Pessoa pessoa)
        {
            db.Entry(pessoa).State = EntityState.Modified;
            db.SaveChanges();
        }
        
        public Pessoa Mostrar(int id)
        {
            Pessoa pessoa = db.Pessoas.Find(id);
            return pessoa;
        }
        
        public void Listar()
        {

        }

        public Pessoa ObterPorId(int id)
        {
            Pessoa pessoa = db.Pessoas.Find(id);
            return pessoa;
        }

        #region validacoes
        /// <summary>
        /// Verifica se a capacidade é maior que zero
        /// </summary>
        /// <param name="capacidade"></param>
        /// <returns></returns>
        /// 

        public bool IsValidaId(int id)
        {
            return id > 0;
        }

        // public bool IsValida

        public void ValidaAdicionar(Pessoa domain)
        {
            throw new NotImplementedException();
        }

        public void ValidaApagar(Pessoa domain)
        {
            throw new NotImplementedException();
        }

        public void ValidaEditar(Pessoa domain)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
