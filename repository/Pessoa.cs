using Model;

using System.Data;
using MySqlConnector;

namespace Repo
{
    public class RepositoryPessoa
    {
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
            //Define string de conexão
            string info = "server=localhost;database=projetointegrador;user id=root;password=''";
            conexao = new MySqlConnection(info);
            try{
                conexao.Open();
            }
            catch{
                MessageBox.Show("Impossível estabelecer conexão com o banco");
            }
        }

        public static void CloseConexao(){
            conexao.Close();
        }

        public static List<Pessoa> Sincronizar(){
            InitConexao();
            string query = "SELECT * FROM pessoas";
            MySqlCommand command = new MySqlCommand(query, conexao);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                // Aqui você pode acessar os dados retornados pela consulta SELECT
                int id = Convert.ToInt32(reader["id"].ToString());
                Pessoa pessoa = new Pessoa();
                pessoa.Id = id;
                pessoa.Idade = Convert.ToInt32(reader["idade"].ToString());
                pessoa.Nome = reader["nome"].ToString();
                pessoa.Cpf = reader["cpf"].ToString();
                pessoas.Add(pessoa);
            }
            CloseConexao();
            return pessoas;
        }

        public static void AddPessoa(Pessoa pessoa){
            InitConexao();
            string query = "INSERT INTO pessoas (nome, idade, cpf) VALUES (@Nome, @Idade, @Cpf)";
            MySqlCommand command = new MySqlCommand(query, conexao);
            try {
                if(pessoa != null){
                    command.Parameters.AddWithValue("@Nome", pessoa.Nome);
                    command.Parameters.AddWithValue("@Cpf", pessoa.Cpf);
                    command.Parameters.AddWithValue("@Idade", pessoa.Idade);
                    int rowsAffected = command.ExecuteNonQuery();
                    pessoa.Id = Convert.ToInt32(command.LastInsertedId);
                
                    if (rowsAffected > 0) {
                    pessoas.Add(pessoa);
                    }
                    else {
                        MessageBox.Show("Usuário não cadastrada");
                    }
                }else {
                    MessageBox.Show("Usuário não cadastrada");
                }
            }catch (Exception ex){
                MessageBox.Show("Erro durante a execução do comando: " + ex.Message);
            }
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
    
        public static void DeletePessoa(int index){
            InitConexao();
            string query = "DELETE FROM pessoas WHERE id = @Id";
            MySqlCommand command = new MySqlCommand(query, conexao);
            command.Parameters.AddWithValue("@Id", pessoas[index].Id);
            int rowsAffected = command.ExecuteNonQuery();
        
            if (rowsAffected > 0) {
                pessoas.RemoveAt(index);
            }
            else {
                MessageBox.Show("Usuário não excluido");
            }
            CloseConexao();
        }
    }
}