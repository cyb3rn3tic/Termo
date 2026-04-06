namespace Termo.ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        /*    
        1.Escolha da Palavra
        ● O jogo possui uma lista de palavras de 5 letras previamente cadastradas.
        ● Uma palavra é sorteada aleatoriamente no início da partida.
        ● A palavra escolhida fica oculta para o jogador.
        */

        //Lista de Palavras (5 Letras)
        //string[] palavrasCincoLetras = ["Sagaz", "Nobre", "Ética", "Mútua", "Tenaz", "Vênia", "Pleno", "Índole", "Gerir", "Audaz", "Casto",
        //"Forte", "Poder", "Áureo", "Vigor", "Sanar", "Grave", "Justo", "Ideia", "União", "Pobre", "Manso", "Rocha", "Noite", "Valor", "Falar",
        //"Lutar", "Tempo", "Sonho", "Honra"];

        //char[] palavraSecreta = new char[palavrasCincoLetras.Length];
        string palavraSecreta = "Ética"; //palavrasCincoLetras[new Random().Next(palavrasCincoLetras.Length)];

        Console.WriteLine($"Palavra secreta selecionada: {palavraSecreta}");

        /*
        2. Feedback Visual com Cores
        Após cada tentativa, o jogo exibe a palavra digitada novamente, destacando
        cada letra com uma cor diferente:
        ● Vermelho escuro: letra inexistente na palavra.
        ● Amarelo escuro: a letra existe, mas está na posição errada.
        ● Verde escuro: letra correta na posição correta.
        Esse retorno ajuda o jogador a formular a próxima tentativa.
        */

        //do
        //{
        Console.Write("Digite uma palavra de 5 letras para o chute: ");
        string chutePalavra = Console.ReadLine() ?? "";

        char[] letraIgual = new char[5];
        
        ConsoleColor[] corLetra = new ConsoleColor[palavraSecreta.Length];

        //int n = 0;//Convert.ToInt32(palavraSecreta.Length)-1;

        for (int i = 0; i < palavraSecreta.Length; i++)
        {
            if (chutePalavra[i] == palavraSecreta[i])
            {
                letraIgual[i] = chutePalavra[i];
                corLetra[i] = ConsoleColor.Green;
                //Console.ResetColor();
            }
            else
            {
                for (int n = 0; n < palavraSecreta.Length; n++)
                    if (chutePalavra[i] == palavraSecreta[n])
                    {
                        letraIgual[i] = chutePalavra[i];
                        corLetra[i] = ConsoleColor.Yellow;
                    }
                    else if (corLetra[i] != ConsoleColor.Yellow)
                    {
                        letraIgual[i] = chutePalavra[i];
                        corLetra[i] = ConsoleColor.Red;
                    }
            }
        }
        for(int i = 0; i < palavraSecreta.Length; i++)
        {
            Console.ForegroundColor = corLetra[i];
            Console.Write(letraIgual[i]);
            Console.ResetColor();
        }
        //}while();

       
    }
}