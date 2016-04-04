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
    public class BlocoBo :IBlocoBo
    {
        private Contexto db = new Contexto();

        public void Adicionar(Bloco bloco)
        {
            bloco.DataCadastro = DateTime.Now.ToLocalTime();
            db.Blocos.Add(bloco);
            db.SaveChanges();
        }

        public void Apagar(int id)
        {
            Bloco bloco = db.Blocos.Find(id);
            db.Blocos.Remove(bloco);
            db.SaveChanges();
        }

        public Bloco Mostrar(int id)
        {
            Bloco bloco = db.Blocos.Find(id);
            return bloco;
        }

        public void Editar(Bloco bloco)
        {
            db.Entry(bloco).State = EntityState.Modified;
            db.SaveChanges();
        }

        public Bloco ObterPorId(int id)
        {
            Bloco bloco = db.Blocos.Find(id);
            return bloco;
        }

        #region Validações



        public void ValidaAdicionar(Bloco domain)
        {
            throw new NotImplementedException();
        }

        public void ValidaApagar(Bloco domain)
        {
            throw new NotImplementedException();
        }

        public void ValidaEditar(Bloco domain)
        {
            throw new NotImplementedException();
        }
    }
    #endregion
}