public class Program
{
    public static void Main()
    {
        string strInput;
        int numInput;
        bool validResponse;

        string[] name = { "Nick", "Jared", "Jake", "Casey", "Hannah", "Scott", "Zach", "John", "Jimmy" };
        string[] homeTown = { "Grand Rapids", "Grandville", "Detroit", "New York", "Detroit", "Atlanta", "New Orleans", "Detroit", "Detroit" };
        string[] favFood = { "spaghetti", "pizza", "ramen noodles", "cake", "Hershey's chocolate", "ice cream", "pancakes", "steak", "hotdog" };

        Console.Write("Welcome! ");

        do
        {
            Console.WriteLine("Please enter a number from 1-" + name.Length + " or a student's name to select a student.");
            Console.WriteLine("If you would like to see data for all students enter 0.");

            validResponse = false;
            do // Gets input and checks it.
            {
                strInput = Console.ReadLine().ToLower();

                if (int.TryParse(strInput, out numInput) && numInput <= name.Length && numInput >= 0)
                { // Looks to see if they entered a number that is valid.
                    numInput = int.Parse(strInput);
                    validResponse = true;
                }
                else
                    for (int i = 0; i < name.Length; i++)
                    {
                        if (name[i].ToLower() == strInput)
                        {
                            numInput = i + 1;
                            validResponse = true;
                        }
                    }

                if (!validResponse)
                    Console.WriteLine("Please enter a correct response.");

            } while (!validResponse);

            if (numInput == 0) // Prints all names if input is 0.
            {
                Console.WriteLine("Here is the list of the names of all the students with the number that corresponds to them.");
                for (int i = 0; i < name.Length; i++)
                    Console.WriteLine(name[i] + " has the number " + (i+1) + ".");
            }
            else
            {
                Console.WriteLine("Enter \"hometown\" to see their hometown or \"favorite food\" for their favorite food.");

                do // Gets input and checks if it contains a phrase corresponding to favorite food or hometown.
                {
                    strInput = Console.ReadLine().ToLower();


                    if (strInput.Contains("food") || strInput.Contains("fav")) // Checks if their input is referring to favorite food.
                    {                     // Below was to make sure the first letter of the word is capitalized.
                        Console.WriteLine(char.ToUpper(favFood[numInput - 1][0]) + favFood[numInput - 1].Substring(1) + " is " + name[numInput - 1] + "'s favorite food.");
                        break;
                    }
                    else if (strInput.Contains("home") || strInput.Contains("town")) // Checks if their input referring to hometown.
                    {
                        Console.WriteLine(homeTown[numInput - 1] + " is " + name[numInput - 1] + "'s hometown.");
                        break;
                    }

                    Console.WriteLine("Please enter the correct keyword, which is either \"hometown\" or \"favorite food.\"");

                } while (true);
            }

            Console.WriteLine("Would you like to search for another student? y to continue, anything else to exit.");

        } while (Console.ReadLine().ToLower() == "y");

        Console.WriteLine("Goodbye.");
    }
}