namespace Jokempo.Core
{
    public class Estatisticas
    {
        public int Vitorias { get; private set; } = 0;
        public int Derrotas { get; private set; } = 0;
        public int Empates { get; private set; } = 0;

        public void RegistrarResultado(ResultadoRodada resultado, bool isJogador1)
        {
            if (resultado == ResultadoRodada.Empate) 
            {
                Empates++;
            }
            else if ((resultado == ResultadoRodada.VitoriaJogador1 && isJogador1) || 
                     (resultado == ResultadoRodada.VitoriaJogador2 && !isJogador1)) 
            {
                Vitorias++;
            }
            else 
            {
                Derrotas++;
            }
        }
    }
}