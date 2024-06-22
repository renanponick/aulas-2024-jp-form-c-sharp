using Repo;

namespace Model {
    public class Pessoa {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Cpf { get; set; }

        public Pessoa() {}

        public Pessoa(string nome, int idade, string cpf) {
            Nome = nome;
            Idade = idade;
            Cpf = cpf;

            ListPessoa.Criar(this);
        }

        public static List<Pessoa> Sincronizar() {
            return ListPessoa.Sincronizar();
        }

        public static List<Pessoa> ListarPessoa() {
            return ListPessoa.ListPessoas();
        }

        public static void AlterarPessoa(
            int indice,
            string nome,
            int idade,
            string cpf
        ){  
            ListPessoa.UpdatePessoa(indice, nome, idade, cpf);
        }

        public static void DeletarPessoa(int indice) {
            ListPessoa.Delete(indice);
        }

        public void Apresentar() {
            Console.WriteLine($"Olá, meu nome é {Nome}, Idade: {Idade}");
        }
    }
}