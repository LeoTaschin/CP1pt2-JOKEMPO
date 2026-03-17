using System;
using System.Text;
using System.Windows.Forms;
using Jokempo.Core;

namespace Jokempo.UI
{
    public partial class Form1 : Form
    {
        private JogoEngine _engine = null!;
        private Jogador _p1 = null!;
        private Jogador _p2 = null!;

        // Variáveis de Estado para gerenciar os cliques dos botões
        private TipoJogada _multiplayerJogadaP1 = TipoJogada.Nenhuma;
        private TipoJogada _round6Mao1P1 = TipoJogada.Nenhuma;
        private TipoJogada _round6Mao2P1 = TipoJogada.Nenhuma;
        private TipoJogada _round6Mao1Pc = TipoJogada.Nenhuma;
        private TipoJogada _round6Mao2Pc = TipoJogada.Nenhuma;

        public Form1()
        {
            InitializeComponent();
            _engine = new JogoEngine();
            AtualizarJogadores(); // Cria o _p1 e _p2 primeiro
            cmbModoJogo.SelectedIndex = 0; // Agora é seguro mudar a UI
        }

        private void btnSetP1_Click(object sender, EventArgs e) => AtualizarJogadores();
        private void btnSetP2_Click(object sender, EventArgs e) => AtualizarJogadores();

        private void AtualizarJogadores()
        {
            _p1 = _engine.ObterOuCriarJogador(string.IsNullOrWhiteSpace(txtP1.Text) ? "Jogador 1" : txtP1.Text.Trim());
            _p2 = _engine.ObterOuCriarJogador(string.IsNullOrWhiteSpace(txtP2.Text) ? "Jogador 2" : txtP2.Text.Trim());
            ResetarRodada();
            AtualizarPainelEstatisticas();
        }

        private void cmbModoJogo_SelectedIndexChanged(object sender, EventArgs e) => ResetarRodada();

        private void ResetarRodada()
        {
            _multiplayerJogadaP1 = TipoJogada.Nenhuma;
            _round6Mao1P1 = TipoJogada.Nenhuma;
            _round6Mao2P1 = TipoJogada.Nenhuma;
            
            lblResultado.Text = "";
            lblJogadaOponente.Text = "";

            if (cmbModoJogo.SelectedIndex == 0) lblInstrucoes.Text = $"{_p1.Nome}, escolha sua jogada contra o PC!";
            else if (cmbModoJogo.SelectedIndex == 1) lblInstrucoes.Text = $"Multiplayer: {_p1.Nome}, faça sua jogada secreta!";
            else if (cmbModoJogo.SelectedIndex == 2) lblInstrucoes.Text = $"Round 6: {_p1.Nome}, escolha sua PRIMEIRA mão!";
        }

        // Cliques dos botões (Pedra, Papel, Tesoura) convergem para cá
        private void btnPedra_Click(object sender, EventArgs e) => ProcessarClique(TipoJogada.Pedra);
        private void btnPapel_Click(object sender, EventArgs e) => ProcessarClique(TipoJogada.Papel);
        private void btnTesoura_Click(object sender, EventArgs e) => ProcessarClique(TipoJogada.Tesoura);

        private void ProcessarClique(TipoJogada escolha)
        {
            if (cmbModoJogo.SelectedIndex == 0) JogarVsPc(escolha);
            else if (cmbModoJogo.SelectedIndex == 1) JogarMultiplayer(escolha);
            else JogarRound6(escolha);
        }

        private void JogarVsPc(TipoJogada escolha)
        {
            var res = _engine.JogarContraComputador(_p1, escolha);
            ExibirResultado($"PC escolheu: {res.Jogada2}", res);
        }

        private void JogarMultiplayer(TipoJogada escolha)
        {
            if (_multiplayerJogadaP1 == TipoJogada.Nenhuma)
            {
                // Turno do P1
                _multiplayerJogadaP1 = escolha;
                lblInstrucoes.Text = $"Multiplayer: {_p2.Nome}, faça sua jogada secreta!";
                lblResultado.Text = "Jogada 1 registrada em segredo.";
            }
            else
            {
                // Turno do P2
                var res = _engine.JogarMultiplayer(_p1, _p2, _multiplayerJogadaP1, escolha);
                ExibirResultado($"{_p1.Nome}: {res.Jogada1} | {_p2.Nome}: {res.Jogada2}", res);
                _multiplayerJogadaP1 = TipoJogada.Nenhuma; // Prepara para próxima
                lblInstrucoes.Text = $"Multiplayer: {_p1.Nome}, faça sua jogada secreta!";
            }
        }

        private void JogarRound6(TipoJogada escolha)
        {
            if (_round6Mao1P1 == TipoJogada.Nenhuma)
            {
                _round6Mao1P1 = escolha;
                lblInstrucoes.Text = $"Round 6: {_p1.Nome}, escolha sua SEGUNDA mão!";
            }
            else if (_round6Mao2P1 == TipoJogada.Nenhuma)
            {
                _round6Mao2P1 = escolha;
                var maosPc = _engine.SortearMaosPC();
                _round6Mao1Pc = maosPc.Item1;
                _round6Mao2Pc = maosPc.Item2;

                lblInstrucoes.Text = $"Round 6: MENOS UM! Clique no botão da mão que você quer MANTER.";
                lblJogadaOponente.Text = $"Suas mãos: [{_round6Mao1P1}] e [{_round6Mao2P1}]\nPC sorteou: [{_round6Mao1Pc}] e [{_round6Mao2Pc}]";
            }
            else
            {
                // Decisão final
                if (escolha != _round6Mao1P1 && escolha != _round6Mao2P1)
                {
                    MessageBox.Show("Você deve manter uma das mãos que você escolheu inicialmente!", "Regra", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var res = _engine.ResolverRound6(_p1, escolha, _round6Mao1Pc, _round6Mao2Pc);
                ExibirResultado($"{_p1.Nome} manteve: {res.Jogada1} | PC manteve: {res.Jogada2}", res);
                _round6Mao1P1 = TipoJogada.Nenhuma;
                _round6Mao2P1 = TipoJogada.Nenhuma;
            }
        }

        private void ExibirResultado(string detalheJogadas, RodadaResult res)
        {
            lblJogadaOponente.Text = detalheJogadas;
            lblResultado.Text = res.Resultado == ResultadoRodada.Empate ? "EMPATE!" : $"{res.NomeVencedor} VENCEU!";
            lblResultado.ForeColor = res.Resultado == ResultadoRodada.Empate ? System.Drawing.Color.LightBlue : 
                                     (res.Resultado == ResultadoRodada.VitoriaJogador1 ? System.Drawing.Color.SpringGreen : System.Drawing.Color.Tomato);
            AtualizarPainelEstatisticas();
        }

        private void AtualizarPainelEstatisticas()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("=== RANKING GLOBAL DE SESSÃO ===");
            foreach (var kvp in _engine.Jogadores)
            {
                var h = kvp.Value.Historico;
                sb.AppendLine($"> {kvp.Value.Nome} | Vitórias: {h.Vitorias} | Derrotas: {h.Derrotas} | Empates: {h.Empates}");
            }
            lblEstatisticasGlobais.Text = sb.ToString();
        }
    }
}