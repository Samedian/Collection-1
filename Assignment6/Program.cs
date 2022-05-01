using Assignment5;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6
{
    public class IntegerNonNegativeAndExceed : Exception
    {
        public IntegerNonNegativeAndExceed(string msg)
            : base(msg)
        {

        }
    }

    public class NameContainDigit : Exception
    {
        public NameContainDigit(string msg)
            : base(msg)
        {

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            SortedList<string, AgePlace> sortList = new SortedList<string, AgePlace>();

            ClsPerson person = null;

            char ch = 'y';
            do
            {
                person = AddPerson(person);

                if (!sortList.ContainsKey(person.Name))
                {
                    sortList.Add(person.Name, person.Age_Place);

                    if (CanVote(person.Age_Place.Age))
                        Console.WriteLine("You are Eligible ");
                    else
                        Console.WriteLine("Sorry You are not Eligible");
                }
                else
                    Console.WriteLine("Sorry Duplicate Key ");
                Console.WriteLine("Do you want to continue ");
                try
                {
                    ch = Convert.ToChar(Console.ReadLine());
                }
                catch (System.FormatException exception)
                {
                    Console.WriteLine(exception);
                }

            } while (ch == 'y' || ch == 'Y');

            AgePlace agePlace;
            Console.WriteLine("All Details :");
            foreach (string key in sortList.Keys)
            {
                agePlace = (AgePlace)sortList[key];
                Console.WriteLine("Name   :" + key);
                Console.WriteLine("Age    :" + agePlace.Age);
                Console.WriteLine("Place  :" + agePlace.Place);
                Console.WriteLine();
            }

            Console.ReadKey();
        }
        private static string ConvertName(string name)
        {
            if (name.Any(Char.IsDigit))
                return null;

            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            name = textInfo.ToTitleCase(name);
            return name;
        }


        private static bool CanVote(int age)
        {
            if (age < 18)
                return false;
            return true;
        }

        private static ClsPerson AddPerson(ClsPerson person)
        {

            string name = null, place = null;
            int age = 0;
            Console.WriteLine("Enter Name ");
            name = Console.ReadLine();

            name = ConvertName(name);

            try
            {

                if (name == null)
                    throw new NameContainDigit("Sorry ,Name Contain Digit ");
            }
            catch (NameContainDigit exception)
            {
                Console.WriteLine(exception);
            }

            Console.WriteLine("Enter Age ");

            try
            {
                age = Convert.ToInt32(Console.ReadLine());

                if (age < 0 && age > 150)
                    throw new IntegerNonNegativeAndExceed("Age is Either negative or too high");
            }
            catch (IntegerNonNegativeAndExceed exception)
            {
                Console.WriteLine(exception);
            }
            catch (System.FormatException exception)
            {
                Console.WriteLine(exception);
            }

            Console.WriteLine("Enter Place");

            try
            {

                place = Console.ReadLine();
                place = ConvertName(place);
                if (place == null)
                    throw new NameContainDigit("Place contain Digit");

            }
            catch (NameContainDigit exception)
            {

                Console.WriteLine(exception);
            }

            AgePlace agePlace = new AgePlace(age, place);
            person = new ClsPerson(name, agePlace);

            return person;
        
        }
    }
}
