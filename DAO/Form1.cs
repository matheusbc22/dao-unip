namespace DAO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pessoa p = new Pessoa();
            Telefone t = new Telefone();
            TipoTelefone tt = new TipoTelefone();
            Endereco end = new Endereco();
            PessoaDAO dao = new PessoaDAO();
            p.nome = "Matheus";
            p.cpf = 12345678911;
            end.logradouro = "Logradouro";
            end.numero = 123;
            end.cep = 12345678;
            end.bairro = "Bairro";
            end.cidade = "Cidade";
            end.estado = "Estado";
            p.endereco = end;
            //
            tt.tipo = "Celular";
            t.tipo = tt;
            t.ddd = 13;
            t.numero = 912345678;
            p.telefone.Add(t);
            dao.insira(p);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Pessoa p = new Pessoa();
            Telefone t = new Telefone();
            TipoTelefone tt = new TipoTelefone();
            Endereco end = new Endereco();
            PessoaDAO dao = new PessoaDAO();
            p.nome = "João";
            p.cpf = 12345678911;
            end.logradouro = "Logradouro diferente";
            end.numero = 321;
            end.cep = 87654321;
            end.bairro = "Bairro diferente";
            end.cidade = "Cidade diferente";
            end.estado = "Estado diferente";
            p.endereco = end;
            //
            tt.tipo = "Fixo";
            t.tipo = tt;
            t.ddd = 11;
            t.numero = 30000000;
            p.telefone.Add(t);
            dao.altere(p);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PessoaDAO dao = new PessoaDAO();
            Pessoa p = new Pessoa();
            p.cpf = 12345678911;
            dao.exclua(p);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PessoaDAO dao = new PessoaDAO();
            dao.consulte(12345678911);
        }
    }
}