namespace desafioJogoDaVelha
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool jogarNovamente = true;
            while (jogarNovamente)
            {
                string[,] matriz = new string[3, 3];
                string jogador = "X";
                int index = 1;
                string jogada;
                int tentativas;

                Console.WriteLine("JOGO DA VELHA");

                Console.WriteLine();

                for (int i = 0; i < matriz.GetLength(0); i++)
                {
                    for (int j = 0; j < matriz.GetLength(1); j++)
                    {
                        matriz[i, j] = index.ToString();
                        index++;
                    }
                }

                for (tentativas = 1; tentativas < 9; tentativas++)
                {
                    for (int i = 0; i < matriz.GetLength(0); i++)
                    {
                        for (int j = 0; j < matriz.GetLength(1); j++)
                        {
                            Console.Write("[" + matriz[i, j] + "]");
                        }
                        Console.WriteLine();
                    }

                    if ((matriz[0, 0] == matriz[1, 1] && matriz[1, 1] == matriz[2, 2]) ||
                        (matriz[0, 2] == matriz[1, 1] && matriz[1, 1] == matriz[2, 0]) ||
                        (matriz[0, 0] == matriz[0, 1] && matriz[0, 1] == matriz[0, 2]) ||
                        (matriz[1, 0] == matriz[1, 1] && matriz[1, 1] == matriz[1, 2]) ||
                        (matriz[2, 0] == matriz[2, 1] && matriz[2, 1] == matriz[2, 2]) ||
                        (matriz[0, 0] == matriz[1, 0] && matriz[1, 0] == matriz[2, 0]) ||
                        (matriz[0, 1] == matriz[1, 1] && matriz[1, 1] == matriz[2, 1]) ||
                        (matriz[0, 2] == matriz[1, 2] && matriz[1, 2] == matriz[2, 2]))
                    {
                        Console.WriteLine();
                        Console.WriteLine("Fim de Jogo!!!");
                        Console.WriteLine();
                        Console.WriteLine("Parabéns!!! O ganhador é [" + jogador + "].");
                        break;
                    }

                    if (jogador == "X")
                    {
                        jogador = "O";
                    }
                    else
                    {
                        jogador = "X";
                    }

                    Console.WriteLine();
                    Console.WriteLine("Você quer jogar [" + jogador + "] em qual posição? ");
                    jogada = Console.ReadLine();

                    while (!"123456789".Contains(jogada))
                    {
                        Console.WriteLine();
                        Console.Write("Jogada inválida. Tente Novamente: ");
                        jogada = Console.ReadLine();
                    }

                    for (int i = 0; i < matriz.GetLength(0); i++)
                    {
                        for (int j = 0; j < matriz.GetLength(1); j++)
                        {
                            if (matriz[i, j] == jogada)
                            {
                                matriz[i, j] = jogador;
                            }
                        }
                    }

                    Console.Clear();
                }

                if (tentativas == 9)
                {
                    for (int i = 0; i < matriz.GetLength(0); i++)
                    {
                        for (int j = 0; j < matriz.GetLength(1); j++)
                        {
                            Console.Write("[" + matriz[i, j] + "]");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                    Console.WriteLine("Fim de Jogo!!!");
                    Console.WriteLine();
                    Console.WriteLine("Que triste!!! Ninguém ganhou.");
                }

                Console.WriteLine();
                Console.WriteLine("Deseja jogar novamente? (s/n)");
                char resposta = char.Parse(Console.ReadLine().ToUpper());
                jogarNovamente = (resposta == 'S');

                Console.Clear();
            }
        }
    }
}