using MySql.Data.MySqlClient;

namespace DAO
{
    public class PessoaDAO
    {
        //Variaveis para o recuperar ID pessoa e ID endereço
        protected object idPessoa;
        protected object idEndereco;
        //Variavel de conexão MySQL
        protected string conString = "Server=localhost;Database=daodb;Uid=root;Pwd=123456789;";
        public bool exclua(Pessoa p)
        {
            //Objeto de conexão do banco de dados
            MySqlConnection con = new MySqlConnection(conString);
            //Objetos de comandos SQL no banco de dados para obtenção do que excluir
            MySqlCommand comGetIdPessoa = new MySqlCommand("SELECT id FROM pessoa WHERE cpf = @cpf;", con);
            MySqlCommand comGetEndPessoa = new MySqlCommand("SELECT endereco FROM pessoa WHERE cpf = @cpf;", con);
            MySqlCommand comGetTelefone = new MySqlCommand("SELECT id_telefone FROM pessoa_telefone WHERE id_pessoa = @idpessoa;", con);
            MySqlCommand comGetTelefoneTipo = new MySqlCommand("SELECT tipo FROM telefone WHERE id = @idtelefone;", con);
            comGetIdPessoa.Parameters.AddWithValue("@cpf", p.cpf);
            comGetEndPessoa.Parameters.AddWithValue("@cpf", p.cpf);
            try
            {
                //Abre a conexão do banco de dados
                con.Open();
                //Obtem o ID pessoa e o ID endereço
                var idPessoaLocal = comGetIdPessoa.ExecuteScalar();
                var idEnderecoLocal = comGetEndPessoa.ExecuteScalar();
                //Obtem o ID do telefone o ID do telefone
                comGetTelefone.Parameters.AddWithValue("@idpessoa", idPessoaLocal);
                var idTelefone = comGetTelefone.ExecuteScalar();
                //Obtem o ID do tipo do telefone
                comGetTelefoneTipo.Parameters.AddWithValue("@idtelefone", idTelefone);
                var idTipoTelefone = comGetTelefoneTipo.ExecuteScalar();
                //Objetos com SQLs de DELETE
                MySqlCommand deletePessoaTelefone = new MySqlCommand("DELETE FROM pessoa_telefone WHERE id_pessoa = @pessoa AND id_telefone = @telefone;", con);
                MySqlCommand deleteTelefone = new MySqlCommand("DELETE FROM telefone WHERE id = @telefone;", con);
                MySqlCommand deleteTelefoneTipo = new MySqlCommand("DELETE FROM telefone_tipo WHERE id = @telefonetipo", con);
                MySqlCommand deletePessoa = new MySqlCommand("DELETE FROM pessoa WHERE id = @pessoa", con);
                MySqlCommand deleteEndereco = new MySqlCommand("DELETE FROM endereco WHERE id = @endereco;", con);
                //Apagando na tabela pessoa_telefone
                deletePessoaTelefone.Parameters.AddWithValue("@pessoa", idPessoaLocal);
                deletePessoaTelefone.Parameters.AddWithValue("@telefone", idTelefone);
                deletePessoaTelefone.ExecuteNonQuery();
                //Apagando na tabela telefone
                deleteTelefone.Parameters.AddWithValue("@telefone", idTelefone);
                deleteTelefone.ExecuteNonQuery();
                //Apagando na tabela telefone_tipo
                deleteTelefoneTipo.Parameters.AddWithValue("@telefonetipo", idTipoTelefone);
                deleteTelefoneTipo.ExecuteNonQuery();
                //Apagando na tabela pessoa
                deletePessoa.Parameters.AddWithValue("@pessoa", idPessoaLocal);
                deletePessoa.ExecuteNonQuery();
                //Apagando na tabela endereço
                deleteEndereco.Parameters.AddWithValue("@endereco", idEnderecoLocal);
                deleteEndereco.ExecuteNonQuery();
                MessageBox.Show("Excluido com sucesso!");
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            con.Close();
        }
        public bool insira(Pessoa p)
        {
            try
            {
                //String de conexão MySQL
                MySqlConnection con = new MySqlConnection(conString);
                //Inserindo endereço na tabela
                MySqlCommand com1 = new MySqlCommand("INSERT INTO endereco (logradouro, numero, cep, bairro, cidade, estado) VALUES (@logradouro, @numero, @cep, @bairro, @cidade, @estado);", con);
                com1.Parameters.AddWithValue("@logradouro", p.endereco.logradouro);
                com1.Parameters.AddWithValue("@numero", p.endereco.numero);
                com1.Parameters.AddWithValue("@cep", p.endereco.cep);
                com1.Parameters.AddWithValue("@bairro", p.endereco.bairro);
                com1.Parameters.AddWithValue("@cidade", p.endereco.cidade);
                com1.Parameters.AddWithValue("@estado", p.endereco.estado);
                con.Open();
                com1.ExecuteNonQuery();
                //Obtendo endereço ID inserido e atribuindo a variável
                MySqlCommand comGetId1 = new MySqlCommand("SELECT LAST_INSERT_ID()", con);
                idEndereco = comGetId1.ExecuteScalar();
                //Inserindo pessoa
                MySqlCommand com2 = new MySqlCommand("INSERT INTO pessoa(nome, cpf, endereco) VALUES (@nome, @cpf, @enderecop);", con);
                com2.Parameters.AddWithValue("@nome", p.nome);
                com2.Parameters.AddWithValue("@cpf", p.cpf);
                com2.Parameters.AddWithValue("@enderecop", idEndereco);
                com2.ExecuteNonQuery();
                //Obtendo pessoa ID inserido e atribuindo a variável
                MySqlCommand comGetId2 = new MySqlCommand("SELECT LAST_INSERT_ID()", con);
                idPessoa = comGetId2.ExecuteScalar();
                //Inserindo telefone_tipo para cada objeto telefone na coleção do telefone do objeto pessoa
                MySqlCommand com3 = new MySqlCommand("INSERT INTO telefone_tipo(tipo) values(@tipo)", con);
                com3.Parameters.AddWithValue("@tipo", p.telefone[0].tipo.tipo);
                com3.ExecuteNonQuery();
                MySqlCommand com4 = new MySqlCommand("INSERT INTO telefone(numero, ddd, tipo) values(@numero, @ddd, LAST_INSERT_ID())", con);
                com4.Parameters.AddWithValue("@numero", p.telefone[0].numero);
                com4.Parameters.AddWithValue("@ddd", p.telefone[0].ddd);
                com4.ExecuteNonQuery();
                try
                {
                    //Inserindo os IDs da pessoa e endereço na tabela de relacionamento pessoa_telefone
                    MySqlCommand com5 = new MySqlCommand("INSERT INTO pessoa_telefone(id_pessoa, id_telefone) values(@pessoa, @endereco)", con);
                    com5.Parameters.AddWithValue("@pessoa", idPessoa);
                    com5.Parameters.AddWithValue("@endereco", idEndereco);
                    com5.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Inserido com sucesso!");
                }
                catch(Exception ex)   
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }
        public bool altere(Pessoa p)
        {
            MySqlConnection con = new MySqlConnection(conString);
            MySqlCommand atualizaPessoa = new MySqlCommand("UPDATE pessoa SET nome = @nome WHERE cpf = @cpf", con);
            atualizaPessoa.Parameters.AddWithValue("@nome", p.nome);
            atualizaPessoa.Parameters.AddWithValue("@cpf", p.cpf);

            MySqlCommand getTelefone = new MySqlCommand("SELECT id_telefone FROM pessoa_telefone WHERE id_pessoa = (SELECT id FROM pessoa WHERE cpf = @cpf);", con);
            getTelefone.Parameters.AddWithValue("@cpf", p.cpf);

            MySqlCommand getEndereco = new MySqlCommand("SELECT endereco FROM pessoa WHERE cpf = @cpf;", con);
            getEndereco.Parameters.AddWithValue("@cpf", p.cpf);
            try
            {
                con.Open();
                var idDoTelefone = getTelefone.ExecuteScalar();
                var idDoEndereco = getEndereco.ExecuteScalar();
                MySqlCommand atualizaEndereco = new MySqlCommand("UPDATE endereco SET logradouro = @logradouro, numero = @numero, cep = @cep, bairro = @bairro, cidade = @cidade, estado = @estado WHERE id = @iddoendereco;", con);
                atualizaEndereco.Parameters.AddWithValue("@iddoendereco", idDoEndereco);
                atualizaEndereco.Parameters.AddWithValue("@logradouro", p.endereco.logradouro);
                atualizaEndereco.Parameters.AddWithValue("@numero", p.endereco.numero);
                atualizaEndereco.Parameters.AddWithValue("@cep", p.endereco.cep);
                atualizaEndereco.Parameters.AddWithValue("@bairro", p.endereco.bairro);
                atualizaEndereco.Parameters.AddWithValue("@cidade", p.endereco.cidade);
                atualizaEndereco.Parameters.AddWithValue("@estado", p.endereco.estado);

                MySqlCommand atualizaTelefone = new MySqlCommand("UPDATE telefone SET numero = @numero, ddd = @ddd WHERE id = @id", con);
                atualizaTelefone.Parameters.AddWithValue("@id", idDoTelefone);
                atualizaTelefone.Parameters.AddWithValue("@numero", p.telefone[0].numero);
                atualizaTelefone.Parameters.AddWithValue("@ddd", p.telefone[0].ddd);

                MySqlCommand atualizaTelefoneTipo = new MySqlCommand("UPDATE telefone_tipo SET tipo = @tipo WHERE id = @idTelefone", con);
                atualizaTelefoneTipo.Parameters.AddWithValue("@tipo", p.telefone[0].tipo.tipo);
                atualizaTelefoneTipo.Parameters.AddWithValue("@idTelefone", idDoTelefone);

                atualizaPessoa.ExecuteNonQuery();
                atualizaEndereco.ExecuteNonQuery();
                atualizaTelefone.ExecuteNonQuery();
                atualizaTelefoneTipo.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Atualizado com sucesso!");
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
                return false;
            }
        }
        public bool consulte(long cpf)
        {
            MySqlConnection con = new MySqlConnection(conString);
            string getCpf = "SELECT * FROM pessoa WHERE cpf = @cpf";
            MySqlCommand comGetCpf = new MySqlCommand(getCpf, con);
            comGetCpf.Parameters.AddWithValue("@cpf", cpf);
            try
            {
                con.Open();
                var pessoaAchada = comGetCpf.ExecuteReader();
                pessoaAchada.Read();
                MessageBox.Show("ID: " + pessoaAchada.GetString(0) + ", Nome: " + pessoaAchada.GetString(1) + ", CPF: " + pessoaAchada.GetString(2) + ", ID do endereço: " + pessoaAchada.GetString(3));
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}