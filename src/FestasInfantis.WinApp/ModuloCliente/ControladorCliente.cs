using System;
using eAgenda.ConsoleApp.Compartilhado;
using eAgenda.WinApp.Compartilhado;
using FestasInfantis.WinApp;
using FestasInfantis.WinApp.ModuloCliente;
using FestasInfantis.WinApp.ModuloItem;
using FestasInfantis.WinFormsApp.ModuloClientes;
namespace FestasInfantis.WinFormsApp.ModuloCliente
{
    internal class ControladorCliente(RepositorioCliente repositorioCliente) : ControladorBase
    {
        private RepositorioCliente repositorioCliente = repositorioCliente;
        private TabelaClienteControl tabelaCliente;

        public int id = 1;

        public override string TipoCadastro { get { return "Clientes"; } }
        public override string ToolTipAdicionar { get { return "Cadadstar um novo cliente"; } }
        public override string ToolTipEditar { get { return "Editar um cliente"; } }
        public override string ToolTipExcluir { get { return "Excluir um cliente"; } }


        public override void Adicionar()
        {
            TelaClienteForm telaCliente = new TelaClienteForm(id++);
            DialogResult resultado = telaCliente.ShowDialog();

            if (resultado != DialogResult.OK) { id--; return; } 
            
            Cliente novoCliente = telaCliente.Cliente;

            repositorioCliente.Cadastrar(novoCliente);

            CarregarClientes();

            TelaPrincipalForm
                .Instancia
                .AtualizarRodape($"O registro \"{novoCliente.Nome}\" foi criado com sucesso!");

        }
        public override void Editar()
        {
            int idSelecionado = tabelaCliente.ObterRegistroSelecionado();

            TelaClienteForm telaCliente = new TelaClienteForm(idSelecionado);

            Cliente clienteSelecionado =
                repositorioCliente.SelecionarPorId(idSelecionado);

            if (clienteSelecionado == null)
            {
                MessageBox.Show(
                    "Não é possível realizar esta ação sem um registro selecionado.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            telaCliente.Cliente = clienteSelecionado;

            DialogResult resultado = telaCliente.ShowDialog();
            if (resultado != DialogResult.OK) return;

            Cliente clienteEditado = telaCliente.Cliente;

            repositorioCliente.Editar(clienteSelecionado.Id, clienteEditado);
            
            CarregarClientes();

            TelaPrincipalForm
                .Instancia
                .AtualizarRodape($"O registro \"{clienteEditado.Nome}\" foi editado com sucesso!");
        }

        public override void Excluir()
        {
            int idSelecionado = tabelaCliente.ObterRegistroSelecionado();

            Cliente clienteSelecionado = 
                repositorioCliente.SelecionarPorId(idSelecionado);

            if (SemSeleção(clienteSelecionado)) return;

            if (clienteSelecionado == null)
            {
                MessageBox.Show(
                    "Não é possível realizar esta ação sem um registro selecionado.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            DialogResult resposta = MessageBox.Show
                (
                $"Você deseja realmente excluir o registro \"{clienteSelecionado.Nome}\"?",
                "Confirmar Exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
                );

            if (resposta != DialogResult.Yes)
                return;

            repositorioCliente.Excluir(clienteSelecionado.Id);

            CarregarClientes();

            TelaPrincipalForm
                .Instancia
                .AtualizarRodape($"O registro \"{clienteSelecionado.Nome}\" foi excluído com sucesso!");

        }
        public override UserControl ObterListagem()
        {
            if (tabelaCliente == null)
                tabelaCliente = new TabelaClienteControl();

            CarregarClientes();

            return tabelaCliente;
        }
        private void CarregarClientes()
        {
            List<Cliente> Clientes = repositorioCliente.SelecionarTodos();

            tabelaCliente.AtualizarRegistros(Clientes);
        }
    }
}
