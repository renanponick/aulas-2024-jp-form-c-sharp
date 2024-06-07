using System.Windows.Forms.Design;

namespace Views;

public class Exemplo : Form
{
    private readonly Form ParentForm; 
    private readonly Label LblInfomativa;
    private readonly Button BtnFechar;
    
    public Exemplo(Form parent) {
        ParentForm = parent;
        // Tira a borda externa com os comandos x
        ControlBox = false;
        // Muda a cor da letra
        ForeColor = Color.White;
        // Muda a cor de fundo
        BackColor = Color.Black;
        Size = new Size(300, 200);
        StartPosition = FormStartPosition.CenterScreen;

        LblInfomativa = new Label {
            Text = "Parabéns, você conseguiu logar!",
            Size = new Size(200, 50),
            Location = new Point(50, 50)
        };
        BtnFechar = new Button {
            Text = "Deslogar/Fechar",
            Size = new Size(100, 25),
            Location = new Point(100, 100),
        };
        BtnFechar.Click += ClickFechar;

        Controls.Add(LblInfomativa);
        Controls.Add(BtnFechar);
    }

    private void ClickFechar(object? sender, EventArgs e) {
        Close();
        // MessageBox.Show("Deslogando");
        ParentForm.Show();
    }
    
}
