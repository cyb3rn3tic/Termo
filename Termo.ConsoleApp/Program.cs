using System.Globalization;

namespace Termo.ConsoleApp;

class Program
{
    //Variaveis de apoio "global"
    static string chutePalavra = "";
    static string palavraSecreta = "";
    static char[] letraDoChute = new char[5];
    static void Main(string[] args)
    {
        Cabecalho();
        
        SorteioPalavraSecreta();

        ExecucaoDoJogo();

        ResultadoDoJogo();
    }
    static void Cabecalho()
    {
        Console.WriteLine("--------------------------");
        Console.WriteLine("!!JOGO DO TERMO!!");
        Console.WriteLine("--------------------------\n");
        return;
    }
    static string SorteioPalavraSecreta()
    {
        /*    
        1.Escolha da Palavra
        ● O jogo possui uma lista de palavras de 5 letras previamente cadastradas.
        ● Uma palavra é sorteada aleatoriamente no início da partida.
        ● A palavra escolhida fica oculta para o jogador.
        */

        //Lista de Palavras (5 Letras)
        string[] listaPalavras = [
            "SAGAZ", "NOBRE", "ETICA", "MUTUA", "TENAZ", "VENUS", "PLENO", "INDOLE", "GERIR", "AUDAZ",
            "CASTO", "FORTE", "PODER", "AUREO", "VIGOR", "SANAR", "GRAVE", "JUSTO", "IDEIA", "UNIAO",
            "POBRE", "MANSO", "ROCHA", "NOITE", "VALOR", "FALAR", "LUTAR", "TEMPO", "SONHO", "HONRA",
        ];
        palavraSecreta = listaPalavras[new Random().Next(listaPalavras.Length)];
        return palavraSecreta;
    }
    static void ExecucaoDoJogo()
    {
        /*
        2. Feedback Visual com Cores
        Após cada tentativa, o jogo exibe a palavra digitada novamente, destacando
        cada letra com uma cor diferente:
        ● Vermelho escuro: letra inexistente na palavra.
        ● Amarelo escuro: a letra existe, mas está na posição errada.
        ● Verde escuro: letra correta na posição correta.
        Esse retorno ajuda o jogador a formular a próxima tentativa.
        */

        ConsoleColor[] corLetra = new ConsoleColor[5];
        int tentativas = 5;

        do
        {
            Console.Write("Digite uma palavra de 5 letras para o chute: ");
            chutePalavra = (Console.ReadLine() ?? "").ToUpper();

            if (chutePalavra == "" || chutePalavra.Length != 5)
            {
                Console.WriteLine("\n--------------------------");
                Console.WriteLine("Digite uma palavra válida!");
                Console.WriteLine("--------------------------\n");
            }
            else
            {
                for (int i = 0; i < palavraSecreta.Length; i++)
                {
                    if (chutePalavra[i] == palavraSecreta[i])
                    {
                        letraDoChute[i] = chutePalavra[i];
                        corLetra[i] = ConsoleColor.Green;
                    }
                    else
                    {
                        if (palavraSecreta.Contains(chutePalavra[i]))
                        {
                            letraDoChute[i] = chutePalavra[i];
                            corLetra[i] = ConsoleColor.Yellow;
                        }
                        else
                        {
                            letraDoChute[i] = chutePalavra[i];
                            corLetra[i] = ConsoleColor.Red;
                        }
                    }
                }

                tentativas--;
                Console.WriteLine($"Tentativas restantes: {tentativas}");

                for (int i = 0; i < palavraSecreta.Length; i++)
                {
                    Console.ForegroundColor = corLetra[i];
                    Console.Write(letraDoChute[i]);
                    Console.ResetColor();
                }
                Console.WriteLine("\n");
            }
        } while (chutePalavra != palavraSecreta && tentativas > 0);
        return;
    }
    static void ResultadoDoJogo()
    {
        /*
            3. Condição de Vitória
            ● Se a palavra digitada for exatamente igual à palavra escolhida, o jogador
            vence.
            ● O jogo exibe uma mensagem de sucesso e aguarda o jogador pressionar
            ENTER para sair.

            4. Condição de Derrota
            ● Se o jogador não acertar a palavra antes do fim das tentativas (5), ele
            perde.
            ● O jogo exibe uma mensagem de derrota e aguarda o jogador pressionar
            ENTER para sair.
        */

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
            Console.WriteLine($"A palavra secreta era: {palavraSecreta}");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Digite enter para sair!");
            Console.ReadLine();
        }
        return;
    }
}