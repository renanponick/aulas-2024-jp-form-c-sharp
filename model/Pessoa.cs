namespace Avaliacao {
    public class Pessoa {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Cpf { get; set; }

        public Pessoa(string nome, int idade, string cpf) {
            this.Nome = nome;
            Idade = idade;
            Cpf = cpf;

            ListPessoa.pessoas.Add(this);
        }

        public static List<Pessoa> ListarPessoa() {
            return ListPessoa.pessoas;
        }

        public static void AlterarPessoa(
            int indice,
            string nome,
            int idade,
            string cpf
        ){
            Pessoa person = ListPessoa.pessoas[indice];
            person.Nome = nome;
            person.Idade = idade;
            person.Cpf = cpf;

            ListPessoa.pessoas[indice] = person;
        }

        public static void DeletarPessoa(int indice) {
            ListPessoa.pessoas.RemoveAt(indice);
        }

        public void Apresentar() {
            Console.WriteLine($"Olá, meu nome é {Nome}, Idade: {Idade}");
        }
    }
}