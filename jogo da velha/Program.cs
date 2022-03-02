using System;

namespace jogo_da_velha
{
    internal class Program
    {
        private const string X = "X";
        private const string O = "O";
        static void Main()
        {
            string continuar = "S";

            while (continuar == "S" || continuar == "SIM")
            {
                Console.Clear();

                Jogar();

                Console.Write("\nDeseja continuar[S/N]?: ");
                continuar = Console.ReadLine().ToUpper();


                while (continuar != "S" && continuar != "SIM" && continuar != "N" && continuar != "NAO")
                {
                    Console.Write("ERRO! Escolha [S] ou [N]: ");
                    continuar = Console.ReadLine().ToUpper();
                }
            }

            Console.WriteLine("Saindo...");
        }

        public static void Jogar()
        {
            string[,] matrizJv = new string[3, 3];

            Console.WriteLine("\n----------- JOGO DA VELHA -----------");
            Console.WriteLine("Escolha um nome para os jogadores:");
            Console.Write("Jogador 1: ");
            string jogador1 = Console.ReadLine();
            Console.Write("Jogador 2: ");
            string jogador2 = Console.ReadLine();

            Console.WriteLine("\n\n     1 | 2 | 3 \n   -------------\n     4 | 5 | 6\n   -------------\n     7 | 8 | 9\n\n");

            Console.Write($"{jogador1} escolha uma posição dentre as opções exibidas anteriormente: ");
            bool parse = int.TryParse(Console.ReadLine(), out int escolha);

            while (!parse)
            {
                Console.Write("ERRO! Digite apenas número: ");
                parse = int.TryParse(Console.ReadLine(), out escolha);
            }

            AtribuirValorNaPosicao(escolha, matrizJv, X);
            ImprimirJogo(matrizJv);

            Console.Write($"{jogador2} escolha uma posição, que esteja disponível: ");
            parse = int.TryParse(Console.ReadLine(), out escolha);

            while (!parse)
            {
                Console.Write("ERRO! Digite apenas número: ");
                parse = int.TryParse(Console.ReadLine(), out escolha);
            }

            AtribuirValorNaPosicao(escolha, matrizJv, O);
            ImprimirJogo(matrizJv);

            for (int j = 3; j <= 9; j++)
            {
                string nome;
                string xo;

                if (j % 2 == 0)
                {
                    nome = jogador2;
                    xo = O;
                }
                else
                {
                    nome = jogador1;
                    xo = X;
                }

                Console.Write($"{nome} escolha uma posição disponivel: ");
                parse = int.TryParse(Console.ReadLine(), out escolha);

                while (!parse)
                {
                    Console.Write("ERRO! Digite apenas número: ");
                    parse = int.TryParse(Console.ReadLine(), out escolha);
                }

                AtribuirValorNaPosicao(escolha, matrizJv, xo);
                ImprimirJogo(matrizJv);
                int vencedor = VerificarVencedor(matrizJv);

                if (vencedor == 1)
                {
                    Console.WriteLine($"VENCEDOR:{jogador1}!!");
                    break;
                }
                else if (vencedor == 2)
                {
                    Console.WriteLine($"VENCEDOR:{jogador2}!!");
                    break;
                }
                else if (j == 9)
                {
                    Console.WriteLine("VELHA!");
                }
            }
        }

        public static void AtribuirValorNaPosicao(int escolha, string[,] matrizJv, string xo)
        {
            bool parse;
            bool disponivel = false;
            while (!disponivel)
            {
                if (escolha > 0 && escolha < 4)
                {
                    if (matrizJv[0, escolha - 1] == null)
                    {
                        matrizJv[0, escolha - 1] = xo;
                        disponivel = true;
                    }
                    else
                    {
                        Console.Write("Posição Indisponivel, escolha outra posição: ");
                        parse = int.TryParse(Console.ReadLine(), out escolha);

                        while (!parse)
                        {
                            Console.Write("ERRO! Digite apenas número: ");
                            parse = int.TryParse(Console.ReadLine(), out escolha);
                        }
                    }
                }
                else if (escolha > 3 && escolha < 7)
                {
                    if (matrizJv[1, escolha - 4] == null)
                    {
                        matrizJv[1, escolha - 4] = xo;
                        disponivel = true;
                    }
                    else
                    {
                        Console.Write("Posição Indisponivel, escolha outra posição: ");
                        parse = int.TryParse(Console.ReadLine(), out escolha);

                        while (!parse)
                        {
                            Console.Write("ERRO! Digite apenas número: ");
                            parse = int.TryParse(Console.ReadLine(), out escolha);
                        }
                    }

                }
                else if (escolha > 6 && escolha < 10)
                {
                    if (matrizJv[2, escolha - 7] == null)
                    {
                        matrizJv[2, escolha - 7] = xo;
                        disponivel = true;
                    }
                    else
                    {
                        Console.Write("Posição Indisponivel, escolha outra posição: ");
                        parse = int.TryParse(Console.ReadLine(), out escolha);

                        while (!parse)
                        {
                            Console.Write("ERRO! Digite apenas número: ");
                            parse = int.TryParse(Console.ReadLine(), out escolha);
                        }
                    }
                }
                else
                {
                    Console.Write("Posição Invalida, escolha outra posição (1 a 9): ");
                    parse = int.TryParse(Console.ReadLine(), out escolha);

                    while (!parse)
                    {
                        Console.Write("ERRO! Digite apenas número: ");
                        parse = int.TryParse(Console.ReadLine(), out escolha);
                    }
                }
            }
        }

        public static int VerificarVencedor(string[,] matrizJv)
        {
            for (int i = 0; i < matrizJv.GetLength(0); i++)
            {
                if (matrizJv[i, 0] != null && matrizJv[i, 0] == matrizJv[i, 1] && matrizJv[i, 1] == matrizJv[i, 2])
                {
                    if (matrizJv[i, 0] == X)
                    {
                        return 1;
                    }
                    else
                    {
                        return 2;
                    }
                }
                else if (matrizJv[0, i] != null && matrizJv[0, i] == matrizJv[1, i] && matrizJv[1, i] == matrizJv[2, i])
                {
                    if (matrizJv[0, i] == X)
                    {
                        return 1;
                    }
                    else
                    {
                        return 2;
                    }
                }
            }
            if (matrizJv[0, 0] != null && matrizJv[0, 0] == matrizJv[1, 1] && matrizJv[1, 1] == matrizJv[2, 2])
            {
                if (matrizJv[0, 0] == X)
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            }
            else if (matrizJv[0, 2] != null && matrizJv[0, 2] == matrizJv[1, 1] && matrizJv[1, 1] == matrizJv[2, 0])
            {
                if (matrizJv[0, 2] == X)
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            }
            else
            {
                return 0;
            }
        }

        public static void ImprimirJogo(string[,] matrizJv)
        {
            Console.WriteLine("\n\n\t1 | 2 | 3 \n\t----------\n\t4 | 5 | 6\n\t----------\n\t7 | 8 | 9\n\n");

            for (int linha = 0; linha < matrizJv.GetLength(0); linha++)
            {
                Console.Write("\t");
                for (int coluna = 0; coluna < matrizJv.GetLength(1); coluna++)
                {
                    if (matrizJv[linha, coluna] == null)
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write($"{matrizJv[linha, coluna]}");
                    }

                    if (coluna < matrizJv.GetLength(1) - 1)
                    {
                        Console.Write(" | ");
                    }
                }
                if (linha < matrizJv.GetLength(0) - 1)
                {
                    Console.WriteLine("\n\t----------");
                }
            }
            Console.WriteLine("\n\n");
        }
    }
}
