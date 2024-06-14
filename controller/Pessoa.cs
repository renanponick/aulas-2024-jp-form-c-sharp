namespace Avaliacao {
    public class ControllerPessoa {
        public static void CriarPessoa(
            string nome,
            int idade,
            string cpf
        ) {
            // validade cpf, validar idade
            new Pessoa(
                nome,
                idade,
                cpf
            );
        }

        public static List<Pessoa> ListarPessoa() {
            return Pessoa.ListarPessoa();
        }

        public static void AlterarPessoa(
            int indice,
            string nome,
            int idade,
            string cpf
        ) {
            List<Pessoa> pessoas = ListarPessoa();
            if(indice >= 0 && indice < pessoas.Count){
                Pessoa.AlterarPessoa(
                    indice,
                    nome,
                    idade,
                    cpf
                );
                Console.WriteLine("Pessoa alterada com sucesso");
            } else {
                Console.WriteLine("Indice inválido");
            }
        }

        public static void DeletarPessoa(int indice) {
            List<Pessoa> pessoas = ListarPessoa();

            if(indice >= 0 && indice < pessoas.Count){
                Pessoa.DeletarPessoa(indice);
            } else {
                Console.WriteLine("Indice inválido");
            }
        }
    }
}