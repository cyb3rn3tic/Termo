using System.Globalization;

namespace Termo.ConsoleApp;

class Program
{
    //Variaveis de apoio
    static string chutePalavra = "";
    static string palavraSecreta = "";
    static int tentativas = 5;
    static ConsoleColor[] corLetra = new ConsoleColor[5];
    static char[] letraIgual = new char[5];
    static void Main(string[] args)
    {
        SorteioPalavraSecreta();
        ExecucaoDoJogo();
        ResultadoDoJogo();
        //Console.WriteLine($"Palavra secreta selecionada: {palavraSecreta}");
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
        //string[] listaPalavras = [
        //    "SAGAZ", "NOBRE", "ÉTICA", "MÚTUA", "TENAZ", "VÊNUS", "PLENO", "ÍNDOLE", "GERIR", "AUDAZ",
        //    "CASTO", "FORTE", "PODER", "ÁUREO", "VIGOR", "SANAR", "GRAVE", "JUSTO", "IDEIA", "UNIÃO",
        //    "POBRE", "MANSO", "ROCHA", "NOITE", "VALOR", "FALAR", "LUTAR", "TEMPO", "SONHO", "HONRA",
        //];
        palavraSecreta = "GERIR";//listaPalavras[new Random().Next(listaPalavras.Length)];
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

        do
        {
            Console.Write("Digite uma palavra de 5 letras para o chute: ");
            chutePalavra = (Console.ReadLine() ?? "").ToUpper();

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
                    if(palavraSecreta.Contains(chutePalavra[i]))
                    {
                        letraIgual[i] = chutePalavra[i];
                        corLetra[i] = ConsoleColor.Yellow;
                    }
                    /*
                    for (int n = 0; n < palavraSecreta.Length; n++)
                    {
                        if (chutePalavra[i] == palavraSecreta[n])
                        {
                            letraIgual[i] = chutePalavra[i];
                            corLetra[i] = ConsoleColor.Yellow;
                        }
                        else 
                        {
                            letraIgual[i] = chutePalavra[i];
                            corLetra[i] = ConsoleColor.Red;
                        }
                       
                    } */
                }
            }
            tentativas--;
            Console.WriteLine($"Tentativas restantes: {tentativas}");

            for (int i = 0; i < palavraSecreta.Length; i++)
            {
                Console.ForegroundColor = corLetra[i];
                Console.Write(letraIgual[i]);
                Console.ResetColor();
            }
            Console.WriteLine("\n");


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