using Model;
using MySqlConnector;

namespace Repo {
    public class ListPessoa {
        private static MySqlConnection conexao;

        static List<Pessoa> pessoas = new List<Pessoa>();
        
        public static List<Pessoa> ListPessoas(){
            return pessoas;
        }

        public static Pessoa? GetPessoa(int index){
            if(index < 0 || index >= pessoas.Count){
                return null;
            }else {
                return pessoas[index];
            }
        }

        public static void InitConexao(){
            string info = "server=localhost;database=projetointegrador;user id=root;password=''";
            conexao = new MySqlConnection(info);
            try {
                conexao.Open();
            } catch {
                MessageBox.Show("Não deu, foi mal");
            }
        }
        public static void CloseConexao() {
            conexao.Close();
        }

        public static List<Pessoa> Sincronizar() {
            // inicializa a conexão com o banco
            InitConexao();
            string query = "SELECT * FROM pessoas";
            MySqlCommand command = new MySqlCommand(query, conexao);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read()) {
                Pessoa pessoa = new Pessoa();
                pessoa.Id = Convert.ToInt32(reader["id"].ToString());
                pessoa.Nome = reader["nome"].ToString();
                pessoa.Idade = Convert.ToInt32(reader["idade"].ToString());
                pessoa.Cpf = reader["cpf"].ToString();
                pessoas.Add(pessoa);
            }
            // fcha a conexão com o banco
            CloseConexao();
            return pessoas;
        }

        public static void Criar(Pessoa pessoa) {
            InitConexao();
            string insert = "INSERT INTO pessoas (nome, idade, cpf) VALUES (@Nome, @Idade, @Cpf)";
            MySqlCommand command = new MySqlCommand(insert, conexao);
            try {
                if(pessoa.Nome == null || pessoa.Idade < 0 || pessoa.Cpf == null) {
                    MessageBox.Show("Deu ruim, favor preencher a pessoa");
                } else {
                    command.Parameters.AddWithValue("@Nome", pessoa.Nome);
                    command.Parameters.AddWithValue("@Idade", pessoa.Idade);
                    command.Parameters.AddWithValue("@Cpf", pessoa.Cpf);

                    int rowsAffected = command.ExecuteNonQuery();
                    pessoa.Id = Convert.ToInt32(command.LastInsertedId);

                    if(rowsAffected > 0){
                        MessageBox.Show("Pessoa cadastrada com sucesso");
                        pessoas.Add(pessoa);
                    } else {
                        MessageBox.Show("Deu ruim, não deu pra adicionar");
                    }
                }
            } catch (Exception e) {
                MessageBox.Show("Deu ruim: " + e.Message);
            }
            // Executar a query


            CloseConexao();
        }

        public static void UpdatePessoa(int index, Pessoa pessoa){
            InitConexao();
            MessageBox.Show("iniciando");
            string query = "UPDATE pessoas SET nome = @Nome, idade = @Idade, cpf = @Cpf WHERE id = @Id";
            MySqlCommand command = new MySqlCommand(query, conexao);
            try {
            if(pessoa != null){
                command.Parameters.AddWithValue("@Id", pessoa.Id);
                command.Parameters.AddWithValue("@Nome", pessoa.Nome);
                command.Parameters.AddWithValue("@Cpf", pessoa.Cpf);
                command.Parameters.AddWithValue("@Idade", pessoa.Idade);
                int rowsAffected = command.ExecuteNonQuery();
            
                if (rowsAffected > 0) {
                    pessoas[index] = pessoa;
                }
                else {
                    MessageBox.Show(rowsAffected.ToString());
                }
            }else {
                MessageBox.Show("Usuário não encontrado");
            }
                
            }catch (Exception ex){
                    MessageBox.Show("Erro durante a execução do comando: " + ex.Message);
            }
            CloseConexao();
        }

        public static void Delete(int index) {
            InitConexao();
            string delete = "DELETE FROM pessoas WHERE id = @Id";
            MySqlCommand command = new MySqlCommand(delete, conexao);
            command.Parameters.AddWithValue("@Id", pessoas[index].Id);
            // executar
            if(rowsAffected > 0) {
                int rowsAffected = command.ExecuteNonQuery();
                pessoas.RemoveAt(index);
                MessageBox.Show("Pessoa deletada com sucesso.");
            } else {
                MessageBox.Show("Usuário não encontrado.");
            }
            CloseConexao();
        }

    }

}