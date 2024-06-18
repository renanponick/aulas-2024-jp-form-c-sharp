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

            RepositoryPessoa.AddPessoa(this);
        }

        public static void Sincronizar() {
            RepositoryPessoa.Sincronizar();
        }

        public static List<Pessoa> ListarPessoa() {
            return RepositoryPessoa.ListPessoas();
        }

        public static void AlterarPessoa(
            int indice,
            string nome,
            int idade,
            string cpf
        ){
            Pessoa person = RepositoryPessoa.GetPessoa(indice);
            if(person != null){
                person.Nome = nome;
                person.Cpf = cpf;
                person.Idade = idade;

                RepositoryPessoa.UpdatePessoa(indice, person);
            }
        }

        public static void DeletarPessoa(int indice) {
            RepositoryPessoa.DeletePessoa(indice);
        }

        public void Apresentar() {
            Console.WriteLine($"Olá, meu nome é {Nome}, Idade: {Idade}");
        }
    }
}