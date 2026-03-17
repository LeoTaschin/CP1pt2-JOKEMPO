using System;
using System.Collections.Generic;

namespace Jokempo.Core
{
    public class RodadaResult
    {
        public string NomeVencedor { get; set; } = string.Empty;
        public TipoJogada Jogada1 { get; set; }
        public TipoJogada Jogada2 { get; set; }
        public ResultadoRodada Resultado { get; set; }
    }

    public class JogoEngine
    {
        // Centraliza todos os jogadores aqui no Core
        public Dictionary<string, Jogador> Jogadores { get; private set; }
        private Random _random;

        public JogoEngine()
        {
            Jogadores = new Dictionary<string, Jogador>(StringComparer.OrdinalIgnoreCase);
            _random = new Random();
        }

        public Jogador ObterOuCriarJogador(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome)) nome = "Anônimo";
            if (!Jogadores.ContainsKey(nome)) Jogadores[nome] = new Jogador(nome);
            return Jogadores[nome];
        }

        // MODO 1: VS PC
        public RodadaResult JogarContraComputador(Jogador p1, TipoJogada jogadaUsuario)
        {
            Jogador pc = ObterOuCriarJogador("Máquina");
            TipoJogada jogadaPc = (TipoJogada)_random.Next(1, 4);
            
            return AvaliarEGravar(p1, pc, jogadaUsuario, jogadaPc);
        }

        // MODO 2: MULTIPLAYER
        public RodadaResult JogarMultiplayer(Jogador p1, Jogador p2, TipoJogada j1, TipoJogada j2)
        {
            return AvaliarEGravar(p1, p2, j1, j2);
        }

        // MODO 3: ROUND 6
        public (TipoJogada, TipoJogada) SortearMaosPC()
        {
            return ((TipoJogada)_random.Next(1, 4), (TipoJogada)_random.Next(1, 4));
        }

        public RodadaResult ResolverRound6(Jogador p1, TipoJogada escolhaFinalP1, TipoJogada mao1Pc, TipoJogada mao2Pc)
        {
            Jogador pc = ObterOuCriarJogador("Máquina");
            // PC escolhe aleatoriamente qual das duas mãos manter
            TipoJogada escolhaFinalPc = _random.Next(1, 3) == 1 ? mao1Pc : mao2Pc;

            return AvaliarEGravar(p1, pc, escolhaFinalP1, escolhaFinalPc);
        }

        // Lógica central de avaliação para todos os modos
        private RodadaResult AvaliarEGravar(Jogador j1, Jogador j2, TipoJogada jogada1, TipoJogada jogada2)
        {
            ResultadoRodada resultado;

            if (jogada1 == jogada2) 
                resultado = ResultadoRodada.Empate;
            else if ((jogada1 == TipoJogada.Pedra && jogada2 == TipoJogada.Tesoura) ||
                     (jogada1 == TipoJogada.Papel && jogada2 == TipoJogada.Pedra) ||
                     (jogada1 == TipoJogada.Tesoura && jogada2 == TipoJogada.Papel))
                resultado = ResultadoRodada.VitoriaJogador1;
            else
                resultado = ResultadoRodada.VitoriaJogador2;

            j1.Historico.RegistrarResultado(resultado, true);
            j2.Historico.RegistrarResultado(resultado, false);

            string nomeVencedor = resultado == ResultadoRodada.Empate ? "Nenhum" : 
                                  (resultado == ResultadoRodada.VitoriaJogador1 ? j1.Nome : j2.Nome);

            return new RodadaResult { Jogada1 = jogada1, Jogada2 = jogada2, Resultado = resultado, NomeVencedor = nomeVencedor };
        }
    }
}