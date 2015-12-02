using Ensalamento.Dominio;
using Ensalamento.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensalamento
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new Contexto();
            var result = db.Salas.ToList();

            //Exemplo de link to sql
            //var sala =( from x in db.Salas
            //           where x.Id == 1
            //           select x.Nome).First();

            //Inserindo registro
            //Sala al = new Sala();
            //al.Nome = "Sala09";
            //al.Capacidade = 5;
            //al.DataCadastro = DateTime.Now;

            //db.Salas.Add(al);
            //db.SaveChanges();

            //Atualizar registro

            //var sala = db.Salas.FirstOrDefault(x => x.Id == 10);
            //sala.Nome = "Sala06";
            //db.SaveChanges();

            //Excluir registro

            //var sala = db.Salas.FirstOrDefault(x => x.Capacidade == 20);
            //db.Salas.Remove(sala);
            //db.SaveChanges();

            //Exemplo de como buscar o nome de sala que tenha capacidade 2..
            //var teste = db.Salas.FirstOrDefault(x => x.Capacidade == 2).Nome;
        }
    }
}
