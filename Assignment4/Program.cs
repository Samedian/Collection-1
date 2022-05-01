using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    public class IntegerNonNegative : Exception
    {
        public IntegerNonNegative(string msg)
            : base(msg)
        {

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            char ch;
            Queue queue = new Queue();
            int choice = 0;
            string str;

            do
            {
                Console.WriteLine("1.Add Element");
                Console.WriteLine("2.Delete Element");
                Console.WriteLine("3.Enter Element b/w two value");

                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                    if (choice < 0)
                        throw new IntegerNonNegative("Sorry It's negative");
                }
                catch (IntegerNonNegative exception)
                {
                    Console.WriteLine(exception);
                }
                catch (System.FormatException exeception)
                {
                    Console.WriteLine(exeception);
                }
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter Element :");
                        str = Console.ReadLine();
                        queue.Enqueue(str);
                        Display(queue);
                        break;

                    case 2:
                        queue.Dequeue();
                        Display(queue);
                        break;

                    case 3:
                        queue = AddElement(queue);
                        Display(queue);
                        break;

                    default:
                        Console.WriteLine("Wrong Choice ");
                        break;
                }

                Console.WriteLine("Do you want to continue ");
                ch = Char.Parse(Console.ReadLine());

            } while (ch == 'Y' || ch == 'y');

            Console.ReadKey();

        }

        private static Queue AddElement(Queue queue)
        {
            Queue temp = new Queue();
            string data;

            Console.WriteLine("Enter First String ");
            string str1 = Console.ReadLine();

            Console.WriteLine("Enter Second String ");
            string str2 = Console.ReadLine();



            while (queue != null)
            {
                data = (string)queue.Dequeue();
                temp.Enqueue(data);

                if(data.Equals(str1))
                {
                    data = (string)queue.Dequeue();
                    if (data.Equals(str2))
                    {
                        Console.WriteLine("Enter string ");
                        string dataEnter = Console.ReadLine();
                        temp.Enqueue(dataEnter);
                        temp.Enqueue(data);
                        break;
                        
                    }
                }
            }

            foreach (var element in queue)
                temp.Enqueue(element);
            return temp;

        }

        private static void Display(Queue queue)
        {
            Console.WriteLine("Queue  :");
            foreach (string element in queue)
            {
                Console.Write(element+"  ");
            }
            Console.WriteLine();
        }
    }
}
