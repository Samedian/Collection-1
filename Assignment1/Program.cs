using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Assignment1
{
    class Program
    {
        public static ArrayList inputUser()
        {

            ArrayList array = new ArrayList();
            bool acceptFlag = false;
            char accept='y';
            int i = 0;

            while (!acceptFlag)
            {
                Console.WriteLine("Enter some integer ");
                try
                {
                    i = int.Parse(Console.ReadKey().KeyChar.ToString());
                }
                catch (System.FormatException)
                { 
                    
                }
                array.Add(i);

                Console.WriteLine("Do you want to continue :");
                try
                {
                    accept = char.Parse(Console.ReadKey().KeyChar.ToString().ToUpper());
                }
                catch (System.FormatException)
                { 
                  
                }
                if (accept != 'Y')
                    acceptFlag = true;
                else
                    acceptFlag = false;
            }

            return array;
        }
        static void Main(string[] args)
        {
            ArrayList array = new ArrayList();
            char ch;
            int avg = -1;
            do
            {
                Console.WriteLine("1.Add user input in Array List");
                Console.WriteLine("2.Display no of integer in ArrayList");
                Console.WriteLine("3.Insert avg value at middle");
                Console.WriteLine("4.Remove 2 nd position element");
                Console.WriteLine("5.Remove Avg value inserted");
                Console.WriteLine("Enter your choice :");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        array = inputUser();
                        break;
                    case 2:
                        Console.WriteLine("Total Elements are :" + array.Count);
                        display(array);
                        break;
                    case 3:
                        avg = calAvg(array);
                        array.Insert(array.Count / 2, avg);
                        display(array);
                        break;

                    case 4:
                        array.Remove(array[1]);
                        display(array);
                        break;

                    case 5:
                        array.RemoveAt(array.IndexOf(avg));
                        display(array);
                        break;

                }
                Console.WriteLine("Do you want to continue :");
                ch = char.Parse(Console.ReadKey().KeyChar.ToString().ToUpper());

            } while (ch == 'Y' || ch == 'y');

            Console.ReadKey();
        }

        private static int calAvg(ArrayList array)
        {
            int sum = 0;
            for (int index = 0; index < array.Count; index++)
            {
                sum+=Convert.ToInt32(array[index]);
            }

            return sum / array.Count;
        }

        private static void display(ArrayList array)
        {
            Console.WriteLine("Array List  :");
            for(int index=0;index<array.Count;index++)
            {
                Console.Write(array[index]+"  ");
            }
        }
        private static int count(ArrayList array)
        {
            return array.Count;
        }
    }
}
