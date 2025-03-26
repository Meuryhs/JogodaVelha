using System;

class JogoDaVelha
{
    static char[] tabuleiro = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    static char jogadorAtual = 'X';
    satatic bool contaAI = false;
    static Random rand = new Random();

    satatuc void Main ()
    {

        Console.WriteLine("Bem vindo ao Jogo da Velha");
        Console.Write("Escolha o modo do jogo(1 - Jogador vs jogador, 2 - Jogador vs IA):");
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
                Console.WriteLine($"\nJogador{jogadorAtual} venceu!");
                break
            }
            if (TabuleiroCheio())
            {
                Console.Clear();
                MostrarTabuleiro();

                Console.WriteLine("\nEmpate!");
                break
            }
            jogadorAtual = (jogadorAtual == 'X') ? 'O' : 'X';
            }
        }
    static void MostrarTabuleiro()
    {
        Console.WriteLine("\n {0} | {1} | {2}", tabuleiro[0], tabuleiro[1], tabuleiro[2]);
        Console.WriteLine("___+___+___");
        Console.WriteLine(" {0} | {1} | {2}", tabuleiro[6], tabuleiro[7], tabuleiro[8]);
    }
    staticvoid JogadaHumana()
    {
        int escolha;
        bool JogadaValida = false;
        do
        {
            Console.Write($\nJogador{ jogadorAtual}, escolha um numero disponivel: ");
                if (int.TryParse(Console.ReadLine(), out escolha) && escolha >= 1 && escolha <= 9 && tab)
        }
    }
    }
}
        }
    }
}
