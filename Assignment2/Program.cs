using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{

    public class NameContainDigit : Exception
    {
        public NameContainDigit(string msg)
            : base(msg)
        {
            
        }
    }

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
            int choice=-1;
            ArrayList array = new ArrayList();
            ClsPerson person=null;
            do
            {
                Console.WriteLine("1.Add Object ");
                Console.WriteLine("2.Display all object");
                Console.WriteLine("Enter your choice");

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
                catch (System.FormatException exception)
                { 
                    Console.WriteLine(exception);

                }
                switch (choice)
                {
                    case 1:
                        person = AddPerson(person);
                        if (person != null)
                        {
                            array.Add(person);
                            Console.WriteLine("Object Added Succesfully");
                        }
                        break;
                    case 2:
                        Display(array);
                        break;

                }

                Console.WriteLine("Do you want to continue :");
                ch = Char.Parse(Console.ReadLine());

            } while (ch == 'Y' || ch == 'y');

            Console.ReadKey();
        }

        private static ClsPerson AddPerson(ClsPerson person)
        {
            string Name=null;
            Console.WriteLine("Enter Name :");
            try
            {
                Name = Console.ReadLine();
                Name = ValidateName(Name);
                if (Name == null)
                {
                    throw new NameContainDigit("Sorry Name Doesn't contain digits");
                    
                }

            }catch(NameContainDigit exception)
            {
                Console.WriteLine(exception);
                return null;
            }

            person = new ClsPerson(Name);
          
            return person;
            
        }

        private static string ValidateName(string name)
        {
            if (name.Any(char.IsDigit))
                  return null;
            
             TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
             name = textInfo.ToTitleCase(name);
             return name;

        }

        private static void Display(ArrayList array)
        {
            foreach (ClsPerson person  in array)
            {
                Console.WriteLine(person.Name);        
            }

            
        }
    }
}
