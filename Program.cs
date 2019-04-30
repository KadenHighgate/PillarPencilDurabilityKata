using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PillarPencilDurabilityKata
{
    class Program
    {
        static void Main(string[] args)
        {
            Paper paper = new Paper();
            Pencil pencil = new Pencil(100, 8, 100);
            bool running = true;

            while (running)
            {
                string Commands = string.Format($"Keyboard commands:  W - Write, E - Erase, D - Edit, S- Sharpen, esc - exit\n" +
               $"Durability {pencil.durability}\n" +
               $"Length {pencil.length}\n" +
               $"Eraser Dur. {pencil.eraserDurability}\n");

                Console.WriteLine(Commands);
                ConsoleKeyInfo input = Console.ReadKey();

                switch (char.ToUpper(input.KeyChar))
                {
                    case 'W':
                    {
                        Console.WriteLine("\nEnter text and press enter to submit\n");
                        Write(pencil, paper);
                        break;
                    }
                    case 'E':
                    {
                        Console.WriteLine("\nEnter text you wish to erase and press enter to submit\n");
                        Erase(pencil, paper);
                        break;
                    }
                    case 'D':
                    {
                        Console.WriteLine("\nEnter text you wish to add to erased space and press enter to submit\n");
                        Edit(pencil, paper);
                        break;
                    }
                    case 'S':
                    {
                        Console.WriteLine("\nSharpened your pencil\n");
                        Sharpen(pencil);
                        break;
                    }
                    case (char)27:
                    {
                        Console.WriteLine("\nPress enter to exit program\n");

                        running = false;
                        break;
                    }
                }
            }
        }

        private static void Sharpen(Pencil pencil)
        {
            pencil.Sharpen();
        }

        private static void Edit(Pencil pencil, Paper paper)
        {
            string input = Console.ReadLine();
            paper.EditContent(pencil.Write(input));
            Console.Write("\nPaper's Content:\n\n" + paper.content + "\n\n");
        }

        private static void Erase(Pencil pencil, Paper paper)
        {
            string input = Console.ReadLine();
            pencil.Erase(paper, input);
            Console.Write("\nPaper's Content:\n\n" + paper.content + "\n\n");
        }
        private static void Write(Pencil pencil, Paper paper)
        {
            string input = Console.ReadLine();
            paper.AddContent(pencil.Write(input));
            Console.Write("\nPaper's Content:\n\n" + paper.content + "\n\n");
        }
    }
}
