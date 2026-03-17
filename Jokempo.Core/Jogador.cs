namespace Jokempo.Core
{
    public class Jogador
    {
        public string Nome { get; private set; }
        public Estatisticas Historico { get; private set; }

        public Jogador(string nome)
        {
            Nome = nome;
            Historico = new Estatisticas();
        }
    }
}