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
    public class CategoriaBo : ICategoriaBo
    {
        private Contexto db = new Contexto();

        public void Adicionar(Categoria categoria)
        {
            categoria.DataCadastro = DateTime.Now.ToLocalTime();
            db.Categorias.Add(categoria);
            db.SaveChanges();
        }

        public void Apagar(int id)
        {
            Categoria categoria = db.Categorias.Find(id);
            db.Categorias.Remove(categoria);
            db.SaveChanges();
        }

        public Categoria Mostrar(int id)
        {
            Categoria categoria = db.Categorias.Find(id);
            return categoria;
        }

        public void Editar(Categoria categoria)
        {
            db.Entry(categoria).State = EntityState.Modified;
            db.SaveChanges();
        }

        public Categoria ObterPorId(int id)
        {
            Categoria categoria = db.Categorias.Find(id);
            return categoria;
        }

        #region Validação


        public void ValidaAdicionar(Categoria domain)
        {
            throw new NotImplementedException();
        }

        public void ValidaApagar(Categoria domain)
        {
            throw new NotImplementedException();
        }

        public void ValidaEditar(Categoria domain)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
