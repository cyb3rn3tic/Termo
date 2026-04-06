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

        string chutePalavra;
        char[] letraIgual = new char[palavraSecreta.Length];
        ConsoleColor[] corLetra = new ConsoleColor[palavraSecreta.Length];
        int tentativas = 5;
        /*
        2. Feedback Visual com Cores
        Após cada tentativa, o jogo exibe a palavra digitada novamente, destacando
        cada letra com uma cor diferente:
        ● Vermelho escuro: letra inexistente na palavra.
        ● Amarelo escuro: a letra existe, mas está na posição errada.
        ● Verde escuro: letra correta na posição correta.
        Esse retorno ajuda o jogador a formular a próxima tentativa.
        */

        do
        {
            Console.Write("Digite uma palavra de 5 letras para o chute: ");
            chutePalavra = Console.ReadLine() ?? "";

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
                    {
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
            }
            tentativas--;
            Console.WriteLine($"Tentativas restantes: {tentativas}");
            
            for (int i = 0; i < palavraSecreta.Length; i++)
            {
                Console.ForegroundColor = corLetra[i];
                Console.Write(letraIgual[i]);
                Console.ResetColor();
            } Console.WriteLine("\n");      

        /*
        3. Condição de Vitória
        ● Se a palavra digitada for exatamente igual à palavra escolhida, o jogador
        vence.
        ● O jogo exibe uma mensagem de sucesso e aguarda o jogador pressionar
        ENTER para sair.
        */
        } while (chutePalavra != palavraSecreta && tentativas > 0);

        if (chutePalavra == palavraSecreta)
        {
            Console.WriteLine("\n---------------------------------");
            Console.WriteLine("Parabéns! Você acertou a palavra!");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Digite enter para sair!");
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("\n------------------------------------------");
            Console.WriteLine("Que pena! Você gastou todas as tentativas!");
            Console.WriteLine("------------------------------------------");
        }
    }
}