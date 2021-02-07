using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace labirintus
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("map.txt");
            StreamReader ar = new StreamReader("map.txt");
            string p = " ";
            int hossz=0;
            while (!ar.EndOfStream)
            {
                p = ar.ReadLine();
                hossz++;
            }
            char[,] map = new char[hossz, p.Length];
            string sor = " ";
            for (int i = 0; i < map.GetLength(0); i++)
            {
                sor = sr.ReadLine();
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = sor[j];
                }
            }
            int y = 1;
            int x = 1;
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i,j]+" ");
                    if (map[i, j]=='O')
                    {
                        y = i;
                        x = j;
                    }
                }
                Console.WriteLine();
            }
            int vegey = 0;
            int vegex = 0;
            for (int i = 0; i < map.GetLength(0); i++)
            {
                if (map[0, i] == ' ')
                {
                    vegex = i;
                    break;
                }
                else if (map[map.GetLength(0)-1, i] == ' ')
                {
                    vegex = i;
                    vegey = map.GetLength(0) - 1;
                    break;
                }
                else if (map[i, 0] == ' ')
                {
                    vegey = i;
                    break;
                }
                else if (map[i, map.GetLength(1) - 1] == ' ')
                {
                    vegex = map.GetLength(1) - 1;
                    vegey = i;
                    break;
                }
            }
            bool vege=true ;           
            while (vege)
            {
                var irany = Console.ReadKey();
                switch (irany.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (map[y-1,x]!='#')
                        {
                            map[y - 1, x ] = 'O';
                            map[y, x] = ' ';
                            y--;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (map[y + 1, x ] != '#')
                        {
                            map[y + 1, x ] = 'O';
                            map[y, x] = ' ';
                            y++;
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (map[y , x - 1] != '#')
                        {
                            map[y , x - 1] = 'O';
                            map[y, x] = ' ';
                            x--;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (map[y , x + 1] != '#')
                        {
                            map[y , x+1] = 'O';
                            map[y, x] = ' ';
                            x++;
                        }
                        break;
                    default:
                        break;
                }
                Console.Clear();
                for (int i = 0; i < map.GetLength(0); i++)
                {
                    for (int j = 0; j < map.GetLength(1); j++)
                    {
                        Console.Write(map[i, j] + " ");
                    }
                    Console.WriteLine();
                }
                if (map[vegey,vegex]=='O')
                {
                    vege = false;
                }
            }
            Console.WriteLine("kurva jo vagy!");
            Console.ReadKey();
        }
    }
}
