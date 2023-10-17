namespace DesafioJogoDaVelhaComputador;
class Program
{
    static char[,] tabuleiro = new char[3, 3];

    static void Main(string[] args)
    {
        Console.WriteLine("JOGO DA VELHA");
        InicializarTabuleiro();

        while (true)
        {
            FazerJogadaEstrategicaComputador();
            DesenharTabuleiro();

            if (VerificarVitoria('O'))
            {
                Console.WriteLine("O computador ganhou!");
                break;
            }

            if (VerificarEmpate())
            {
                Console.WriteLine("O jogo terminou em empate!");
                break;
            }

            FazerJogadaHumano();
            DesenharTabuleiro();

            if (VerificarVitoria('X'))
            {
                Console.WriteLine("Parabéns! Você ganhou!");
                break;
            }

            if (VerificarEmpate())
            {
                Console.WriteLine("O jogo terminou em empate!");
                break;
            }
        }
    }

    static void InicializarTabuleiro()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                tabuleiro[i, j] = ' ';
            }
        }
    }

    static void DesenharTabuleiro()
    {
        Console.WriteLine("  0  1  2");
        for (int i = 0; i < 3; i++)
        {
            Console.Write(i);
            for (int j = 0; j < 3; j++)
            {
                Console.Write("[" + tabuleiro[i, j] + "]");
            }
            Console.WriteLine();
        }
    }

    static void FazerJogadaHumano()
    {
        Console.WriteLine("Sua vez. Digite a linha e a coluna separadas por espaço: ");
        string[] input = Console.ReadLine().Split(' ');
        int linha = int.Parse(input[0]);
        int coluna = int.Parse(input[1]);

        if (tabuleiro[linha, coluna] != ' ')
        {
            Console.WriteLine("Essa posição já está ocupada. Tente novamente.");
            FazerJogadaHumano();
        }
        else
        {
            tabuleiro[linha, coluna] = 'X';
        }
    }

    static void FazerJogadaEstrategicaComputador()
    {

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (tabuleiro[i, j] == ' ')
                {
                    tabuleiro[i, j] = 'O';
                    if (VerificarVitoria('O'))
                    {
                        return;
                    }
                    tabuleiro[i, j] = ' ';
                }
            }
        }

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (tabuleiro[i, j] == ' ')
                {
                    tabuleiro[i, j] = 'X';
                    if (VerificarVitoria('X'))
                    {
                        tabuleiro[i, j] = 'O';
                        return;
                    }
                    tabuleiro[i, j] = ' ';
                }
            }
        }

        if (tabuleiro[1, 1] == ' ')
        {
            tabuleiro[1, 1] = 'O';
            return;
        }

        if (tabuleiro[0, 0] == ' ')
        {
            tabuleiro[0, 0] = 'O';
            return;
        }

        if (tabuleiro[0, 2] == ' ')
        {
            tabuleiro[0, 2] = 'O';
            return;
        }

        if (tabuleiro[2, 0] == ' ')
        {
            tabuleiro[2, 0] = 'O';
            return;
        }

        if (tabuleiro[2, 2] == ' ')
        {
            tabuleiro[2, 2] = 'O';
            return;
        }

        FazerJogadaAleatoriaComputador();
    }

    static void FazerJogadaAleatoriaComputador()
    {
        Random random = new Random();
        int linha, coluna;

        do
        {
            linha = random.Next(0, 3);
            coluna = random.Next(0, 3);
        } while (tabuleiro[linha, coluna] != ' ');

        tabuleiro[linha, coluna] = 'O';
    }

    static bool VerificarVitoria(char jogador)
    {
        for (int i = 0; i < 3; i++)
        {
            if (tabuleiro[i, 0] == jogador && tabuleiro[i, 1] == jogador && tabuleiro[i, 2] == jogador)
            {
                return true;
            }

            if (tabuleiro[0, i] == jogador && tabuleiro[1, i] == jogador && tabuleiro[2, i] == jogador)
            {
                return true;
            }
        }

        if ((tabuleiro[0, 0] == jogador && tabuleiro[1, 1] == jogador && tabuleiro[2, 2] == jogador) ||
            (tabuleiro[0, 2] == jogador && tabuleiro[1, 1] == jogador && tabuleiro[2, 0] == jogador))
        {
            return true;
        }

        return false;
    }

    static bool VerificarEmpate()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (tabuleiro[i, j] == ' ')
                {
                    return false;
                }
            }
        }

        return true;
    }
}