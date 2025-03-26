using System;

class JogoDaVelha
{
    static char[] tabuleiro = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    static char jogadorAtual = 'X';
    static bool contaAI = false;
    static Random rand = new Random();

    static void Main()
    {
        Console.WriteLine("Bem-vindo ao Jogo da Velha");
        Console.Write("Escolha o modo do jogo (1 - Jogador vs Jogador, 2 - Jogador vs IA): ");
        int modo = int.Parse(Console.ReadLine());
        contaAI = (modo == 2);

        while (true)
        {
            Console.Clear();
            MostrarTabuleiro();

            if (jogadorAtual == 'O' && contaAI)
            {
                JogadaIA();
            }
            else
            {
                JogadaHumana();
            }

            if (VerificarVitoria())
            {
                Console.Clear();
                MostrarTabuleiro();
                Console.WriteLine($"\nJogador {jogadorAtual} venceu!");
                break;
            }

            if (TabuleiroCheio())
            {
                Console.Clear();
                MostrarTabuleiro();
                Console.WriteLine("\nEmpate!");
                break;
            }

            jogadorAtual = (jogadorAtual == 'X') ? 'O' : 'X';
        }
    }

    static void MostrarTabuleiro()
    {
        Console.WriteLine("\n {0} | {1} | {2}", tabuleiro[0], tabuleiro[1], tabuleiro[2]);
        Console.WriteLine("___+___+___");
        Console.WriteLine(" {0} | {1} | {2}", tabuleiro[3], tabuleiro[4], tabuleiro[5]);
        Console.WriteLine("___+___+___");
        Console.WriteLine(" {0} | {1} | {2}", tabuleiro[6], tabuleiro[7], tabuleiro[8]);
    }

    static void JogadaHumana()
    {
        int escolha;
        bool jogadaValida = false;

        do
        {
            Console.Write($"\nJogador {jogadorAtual}, escolha um número disponível: ");
            if (int.TryParse(Console.ReadLine(), out escolha) && escolha >= 1 && escolha <= 9 && tabuleiro[escolha - 1] == escolha.ToString()[0])
            {
                tabuleiro[escolha - 1] = jogadorAtual;
                jogadaValida = true;
            }
            else
            {
                Console.WriteLine("Jogada inválida! Tente novamente.");
            }
        } while (!jogadaValida);
    }

    static void JogadaIA()
    {
        int escolha;
        do
        {
            escolha = rand.Next(1, 10);
        } while (tabuleiro[escolha - 1] == 'X' || tabuleiro[escolha - 1] == 'O');

        tabuleiro[escolha - 1] = 'O';
        Console.WriteLine($"IA escolheu {escolha}");
    }

    static bool VerificarVitoria()
    {
        int[,] vitorias = {
            { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 }, 
            { 0, 3, 6 }, { 1, 4, 7 }, { 2, 5, 8 }, 
            { 0, 4, 8 }, { 2, 4, 6 }              
        };

        for (int i = 0; i < 8; i++)
        {
            int a = vitorias[i, 0], b = vitorias[i, 1], c = vitorias[i, 2];
            if (tabuleiro[a] == tabuleiro[b] && tabuleiro[b] == tabuleiro[c])
            {
                return true;
            }
        }
        return false;
    }

    static bool TabuleiroCheio()
    {
        foreach (char posicao in tabuleiro)
        {
            if (posicao != 'X' && posicao != 'O')
                return false;
        }
        return true;
    }
}
