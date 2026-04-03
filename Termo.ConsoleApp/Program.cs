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
        string[] palavrasCincoLetras = new[] {"Sagaz", "Nobre", "Ética", "Mútua", "Tenaz", "Vênia", "Pleno", "Índole", "Gerir", "Audaz", "Casto",
        "Forte", "Poder", "Áureo", "Vigor", "Sanar", "Grave", "Justo", "Ideia", "União", "Pobre", "Manso", "Rocha", "Noite", "Valor", "Falar",
        "Lutar", "Tempo", "Sonho", "Honra"};

        string palavraSecreta = palavrasCincoLetras[new Random().Next(palavrasCincoLetras.Length)];

        Console.WriteLine($"Palavra secreta selecionada: {palavraSecreta}");


    }
}
