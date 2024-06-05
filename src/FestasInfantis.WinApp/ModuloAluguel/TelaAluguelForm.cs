namespace FestasInfantis.WinApp.ModuloAluguel
{
    public partial class TelaAluguelForm : Form
    {
        private Aluguel aluguel;
        public Aluguel Aluguel
        {
            get => aluguel;
            set
            {

            }
        }
        public TelaAluguelForm(int id)
        {
            InitializeComponent();
        }
    }
}
