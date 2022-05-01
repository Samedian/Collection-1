using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
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
            Stack stack = new Stack();
            int choice=0;
            string str;

            do
            {
                Console.WriteLine("1.Push Element");
                Console.WriteLine("2.Pop Element");
                Console.WriteLine("3.Peek Element");
                Console.WriteLine("4.Enter Element b/w two value");

                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                    if (choice < 0)
                        throw new IntegerNonNegative("Sorry It's negative");
                }
                catch (IntegerNonNegative exception)
                {
                    Console.WriteLine(exception);
                }catch(System.FormatException exeception)
                {
                    Console.WriteLine(exeception);
                }
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter string ");
                        str = Console.ReadLine();
                        stack.Push(str);
                        Display(stack);
                        break;

                    case 2:
                        stack.Pop();
                        break;

                    case 3:
                        Console.WriteLine("Top Element :"+stack.Peek());
                        break;
                    case 4:
                        stack=AddBetweenElement(stack);
                        Display(stack);
                        break;

                }

                Console.WriteLine("Do you want to continue ");
                ch = Char.Parse(Console.ReadLine());

            } while (ch == 'Y' || ch == 'y');
            

           

            Console.ReadKey();

        }

        private static void Display(Stack stack)
        {
            Console.WriteLine("Stack :");
            foreach (string str in stack)
            {
                Console.Write(str+"  ");
            }
            Console.WriteLine();

        }

        private static Stack AddBetweenElement(Stack stack)
        {
            Console.WriteLine("Enter First String ");
            string str1 = Console.ReadLine();

            Console.WriteLine("Enter Second String ");
            string str2 = Console.ReadLine();

            Stack temp = new Stack();
            String data;
           
            while(stack!=null)
            {
                data = (string)stack.Pop();
                if(data.Equals(str1))
                {
                    temp.Push(data);
                    if (stack.Peek().Equals(str2))
                        break;
                }
                else
                {
                    temp.Push(data);
                }
               
            }

            Console.WriteLine("Enter String ");
            string str = Console.ReadLine();

            stack.Push(str);

            foreach (var element in temp)
            {
                stack.Push(element);
            }


            return stack;
        }
    }
}
