namespace Views;

public class Login : Form
{
    private readonly Label LblNome;
    private readonly Label LblSenha;
    private readonly TextBox InpNome;
    private readonly TextBox InpSenha;
    private readonly Button BtnLogar;
    
    public Login() {
        Size = new Size(400, 400);
        StartPosition = FormStartPosition.CenterScreen;

        LblNome = new Label {
            Text = "Nome: ",
            ForeColor = Color.White,
            BackColor = Color.Black,
            Location = new Point(50, 50)
        };
        LblSenha = new Label {
            Text = "Senha: ",
            Location = new Point(50, 150)
        };

        InpNome = new TextBox {
            Name = "Nome",
            Location = new Point(150, 50),
            Size = new Size(200, 20)
        };
        InpSenha = new TextBox {
            Name = "Senha",
            Location = new Point(150, 150),
            Size = new Size(200, 20)
        };

        BtnLogar = new Button {
            Text = "Logar",
            Location = new Point(150, 250),
        };
        BtnLogar.Click += ClickLogar;

        Controls.Add(LblNome);
        Controls.Add(LblSenha);
        Controls.Add(InpNome);
        Controls.Add(InpSenha);
        Controls.Add(BtnLogar);
    }

    private void ClickLogar(object? sender, EventArgs e) {
        if(InpNome.Text.Length < 1){
            MessageBox.Show("Input Nome não pode ser vazio");
            return;
        }
        if(InpSenha.Text == ""){
            MessageBox.Show("Input Senha não pode ser vazio");
            return;
        }
        Hide();
        // MessageBox.Show("Você será redirecionado");
        new Exemplo(this).Show();
    }
    
}
