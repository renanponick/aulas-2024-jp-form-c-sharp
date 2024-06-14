using Avaliacao;

namespace Views;

public class PessoaView : Form
{
    private readonly Label LblNome;
    private readonly Label LblCpf;
    private readonly TextBox InpNome;
    private readonly TextBox InpCpf;
    private readonly Button BtnCadastrar;
    private readonly Button BtnListar;
    private readonly Button BtnDeletar;
    private readonly DataGridView DataGridView;
    
    public PessoaView() {
        Size = new Size(400, 400);
        StartPosition = FormStartPosition.CenterScreen;

        LblNome = new Label {
            Text = "Nome: ",
            // ForeColor = Color.White,
            // BackColor = Color.Black,
            Location = new Point(50, 50)
        };
        LblCpf = new Label {
            Text = "Cpf: ",
            Location = new Point(50, 100)
        };

        InpNome = new TextBox {
            Name = "Nome",
            Location = new Point(150, 50),
            Size = new Size(200, 20)
        };
        InpCpf = new TextBox {
            Name = "Cpf",
            Location = new Point(150, 100),
            Size = new Size(200, 20)
        };

        BtnCadastrar = new Button {
            Text = "Cadastrar",
            Location = new Point(50, 150),
        };
        BtnCadastrar.Click += ClickCadastrar;
        
        BtnListar = new Button {
            Text = "Listar",
            Location = new Point(150, 150),
        };
        BtnListar.Click += ClickListar;
                
        BtnDeletar = new Button {
            Text = "Deletar",
            Location = new Point(250, 150),
        };
        BtnDeletar.Click += ClickDeletar;

        DataGridView = new DataGridView {
            Location = new Point(0, 200),
            Size = new Size(400, 150)
        };

        Controls.Add(LblNome);
        Controls.Add(LblCpf);
        Controls.Add(InpNome);
        Controls.Add(InpCpf);
        Controls.Add(BtnCadastrar);
        Controls.Add(BtnListar);
        Controls.Add(BtnDeletar);
        Controls.Add(DataGridView);
    }

    private void Listar() {
        List<Pessoa> pessoas = ControllerPessoa.ListarPessoa();
        DataGridView.Columns.Clear();

        DataGridView.AutoGenerateColumns = false;
        DataGridView.DataSource = pessoas;

        // Adiciona colunas ao DataGridView
        DataGridView.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "Nome",
            HeaderText = "Nome"
        });
        DataGridView.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "Cpf",
            HeaderText = "Cpf"
        });
        DataGridView.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "Idade",
            HeaderText = "Idade"
        });
    }

    private void ClickCadastrar(object? sender, EventArgs e) {
        if(InpNome.Text.Length < 1){
            MessageBox.Show("Input Nome não pode ser vazio");
            return;
        }
        if(InpCpf.Text == ""){
            MessageBox.Show("Input Cpf não pode ser vazio");
            return;
        }
        // Hide();
        ControllerPessoa.CriarPessoa(InpNome.Text, 0 ,InpCpf.Text);
        MessageBox.Show("Cadastrado com sucesso");
        Listar();
        // new Exemplo(this).Show();
    }

    private void ClickListar(object? sender, EventArgs e) {
       Listar();
    }
    
    private void ClickDeletar(object? sender, EventArgs e) {
        int index = DataGridView.SelectedRows[0].Index;
        ControllerPessoa.DeletarPessoa(index);
        Listar();
    }
    
    
}
