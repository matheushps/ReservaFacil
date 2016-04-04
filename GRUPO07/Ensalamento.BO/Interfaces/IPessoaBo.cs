using Ensalamento.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensalamento.BO.Interfaces
{
    public interface IPessoaBo : IValidator<Pessoa>
    {
        void Adicionar(Pessoa pessoa);
        void Deletar(int id);
        Pessoa Mostrar(int id);
        void Editar(Pessoa pessoa);
        Pessoa ObterPorId(int id);
    }
}
