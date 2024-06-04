using eAgenda.ConsoleApp.Compartilhado;
using FestasInfantis.WinApp;

namespace eAgenda.WinApp.Compartilhado
{
    public abstract class ControladorBase
    {
        public abstract string TipoCadastro { get; }

        public abstract string ToolTipAdicionar { get; }
        public abstract string ToolTipEditar { get; }
        public abstract string ToolTipExcluir { get; }

        public abstract UserControl ObterListagem();

        public abstract void Adicionar();
        public abstract void Editar();
        public abstract void Excluir();

        public bool SemSeleção(EntidadeBase entidadeSelecionada)
        {
            if (entidadeSelecionada == null)
            {
                MessageBox.Show(
                    "Não é possível realizar esta ação sem um registro selecionado.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return true;
            }
            return false;
        }
    }
}
