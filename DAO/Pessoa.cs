using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class Pessoa
    {
        protected int id;
        public string nome;
        public Int64 cpf;
        public Endereco endereco;
        public List<Telefone> telefone = new List<Telefone>();
    }
}
