using Controller;
using Model;

namespace View;

public class ViewPessoa : Form {

    private readonly Label LblNome;
    private readonly Label LblCpf;
    private readonly Label LblIdade;
    private readonly TextBox InpNome;
    private readonly TextBox InpCpf;
    private readonly TextBox InpIdade;
    private readonly Button BtnCadastrar;
    private readonly Button BtnAlterar;
    private readonly Button BtnDeletar;
    private readonly DataGridView DgvPessoas;

    public ViewPessoa() {
        ControllerPessoa.Sincronizar();

        Size = new Size(400, 400);
        StartPosition = FormStartPosition.CenterScreen;

        LblNome = new Label {
            Text = "Nome: ",
            Location = new Point(50, 50),
        };
        LblCpf = new Label {
            Text = "Cpf: ",
            Location = new Point(50, 100),
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
        BtnAlterar = new Button {
            Text = "Alterar",
            Location = new Point(150, 150),
        };
        BtnAlterar.Click += ClickAlterar;
        BtnDeletar = new Button {
            Text = "Deletar",
            Location = new Point(250, 150),
        };
        BtnDeletar.Click += ClickDeletar;

        DgvPessoas = new DataGridView {
            Location = new Point(0, 200),
            Size = new Size(400, 150)
        };


        Controls.Add(LblNome);
        Controls.Add(LblCpf);
        Controls.Add(LblIdade);
        Controls.Add(InpNome);
        Controls.Add(InpCpf);
        Controls.Add(InpIdade);
        Controls.Add(BtnCadastrar);
        Controls.Add(BtnAlterar);
        Controls.Add(BtnDeletar);
        Controls.Add(DgvPessoas);
        
        Listar();
    }

    private void ClickCadastrar(object? sender, EventArgs e) {
        if(InpNome.Text == "") {
            return;
        }
        ControllerPessoa.CriarPessoa(InpNome.Text, 10, InpCpf.Text);
        Listar();
    }

    private void ClickAlterar(object? sender, EventArgs e) {
        int index = DgvPessoas.SelectedRows[0].Index;
        if(InpNome.Text == "") {
            return;
        }
        ControllerPessoa.AlterarPessoa(index, InpNome.Text, 10, InpCpf.Text);
        Listar();
    }

    private void Listar() {
        List<Pessoa> pessoas = ControllerPessoa.ListarPessoa();
        DgvPessoas.Columns.Clear();
        DgvPessoas.AutoGenerateColumns = false;
        DgvPessoas.DataSource = pessoas;
        
        DgvPessoas.Columns.Add(new DataGridViewTextBoxColumn {
            DataPropertyName = "Id",
            HeaderText = "Id"
        });
        DgvPessoas.Columns.Add(new DataGridViewTextBoxColumn {
            DataPropertyName = "Nome",
            HeaderText = "Nome"
        });
        DgvPessoas.Columns.Add(new DataGridViewTextBoxColumn {
            DataPropertyName = "Cpf",
            HeaderText = "Cpf"
        });
        DgvPessoas.Columns.Add(new DataGridViewTextBoxColumn {
            DataPropertyName = "Idade",
            HeaderText = "Idade"
        });
    }
    private void ClickDeletar(object? sender, EventArgs e) {
        int index = DgvPessoas.SelectedRows[0].Index;
        ControllerPessoa.DeletarPessoa(index);
        Listar();
    }


}