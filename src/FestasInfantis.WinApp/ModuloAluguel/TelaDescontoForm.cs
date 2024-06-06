namespace FestasInfantis.WinApp.ModuloAluguel
{
    public partial class TelaDescontoForm : Form
    {
        public decimal porcentPorAluguel;
        public decimal porcentDescontoMax;
        public TelaDescontoForm(decimal porcentAluguel, decimal porcentMax) 
        { 
            InitializeComponent(); 
            txtPorcentPorAluguel.Text = (porcentAluguel * 100).ToString();
            txtPorcentMax.Text = (porcentMax * 100).ToString();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            porcentPorAluguel = txtPorcentPorAluguel.Value / 100;
            porcentDescontoMax = txtPorcentMax.Value / 100;
        }
    }
}
