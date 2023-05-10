using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the name of player 1 : ");
            string p1 = Console.ReadLine();
            Console.Write("Enter the name of player 2 : ");
            string p2 = Console.ReadLine();
            Console.WriteLine();

            Console.Write(p1 + " Choose either X or O : ");
            char coin1 = char.Parse(Console.ReadLine());
            char coin2 = 'X';
            coin1 = char.ToUpper(coin1);
            if (coin1 == coin2)
            {
                coin2 = 'O';
            }

            while (coin1 != 'X' && coin1 != 'O')
            {
                Console.Write(p1 + " Choose either X or O : ");
                coin1 = char.ToUpper(char.Parse(Console.ReadLine()));
            }

            Console.WriteLine();
            Console.WriteLine(p1 + " " + coin1);
            Console.WriteLine(p2 + " " + coin2);
            Console.WriteLine();

            char[] arr = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            Console.WriteLine("--------------------");
            Console.WriteLine("Tic Tac Toe - Board");
            Console.WriteLine("--------------------");
            PrintBoard(arr);

            string curplayer = " ";
            char curcoin = ' ';
            if (coin1 == 'X')
            {
                curplayer = p1;
                curcoin = coin1;
            }
            else if (coin1 != 'X')
            {
                curplayer = p2;
                curcoin = coin2;
            }
            //Console.Write("\n");
            for (int i = 0; i < 9; i++)
            {
                Console.WriteLine("Round No ---->  " + (i+1));
                Console.Write(curplayer + " Where to place " + curcoin + "  :  ");
                int pos = int.Parse(Console.ReadLine());
                while (IsFilled(arr, pos))
                {
                    Console.Write("Position already filled . Choose another Position to place " + curcoin + ": ");
                    pos = int.Parse(Console.ReadLine());
                }

                while (!IsFilled(arr, pos))
                {
                    arr[pos - 1] = curcoin;
                }

                PrintBoard(arr);

                if (IsFormed(arr))
                {
                    Console.WriteLine(curplayer + " is the WINNER");
                    break;
                }

                curcoin = SwitchCoin(curcoin);
                curplayer = SwitchPlayer(p1, p2, curplayer);
            }

            if (!IsFormed(arr))
            {
                Console.WriteLine("The match is tied");
            }
        }


        public static void PrintBoard(char[] arr)
        {
            for (int i = 0 ; i < arr.Length; i++)
            {
                if (i % 3 == 0)
                {
                    Console.Write("\n\n");
                }
                Console.Write(arr[i] + "\t");
            }
            Console.WriteLine("\n");
        }
        public static char SwitchCoin(char coin)
        {
            if (coin == 'X')
            {
                coin = 'O';
            }
            else if (coin == 'O')
            {
                coin = 'X';
            }
            return coin;
        }
        public static string SwitchPlayer(string p1, string p2, string curplayer)
        {
            if (curplayer == p1)
            {
                curplayer = p2;
            }
            else if (curplayer == p2)
            {
                curplayer = p1;
            }
            return curplayer;
        }
        public static bool IsFilled(char[] arr, int pos)
        {
            if (arr[pos - 1] == 'X'|| arr[pos - 1] == 'O')
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool IsFormed(char[] arr)
        {
            if (arr[0] == arr[1] && arr[1] == arr[2])
            {
                return true;
            }

            else if (arr[3] == arr[4] && arr[4] == arr[5])
            {
                return true;
            }

            else if (arr[6] == arr[7] && arr[7] == arr[8])
            {
                return true;
            }

            else if (arr[0] == arr[3] && arr[3] == arr[6])
            {
                return true;
            }

            else if (arr[1] == arr[4] && arr[4] == arr[7])
            {
                return true;
            }

            else if (arr[2] == arr[5] && arr[5] == arr[8])
            {
                return true;
            }

            else if (arr[0] == arr[4] && arr[4] == arr[8])
            {
                return true;
            }

            else if (arr[2] == arr[4] && arr[4] == arr[6])
            {
                return true;
            }

            else
            {
                return false;
            }
        
        }
    }
}
