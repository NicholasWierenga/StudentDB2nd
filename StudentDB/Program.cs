using StudentDB.model.Tables.dbo.Students;

namespace StudentDB
{
    public class Program
    {
        public static StudentCRUD studentDB;
        public static List<Student> students;
        public static void Main()
        {
            studentDB = new StudentCRUD();
            students = studentDB.students.ToList();
            string strInput;
            int numInput = -1;

            Console.WriteLine("Welcome!");

            while(true) // Gets input and checks it for a valid name or index value and handles the all, add, and remove commands.
            {
                PrintAllStudents();
                strInput = GetUserInput("Please enter a student ID or a student's name to select a student or \n" +
                    "or \"all\" to find all student info. You can also add a student by entering \n" +
                    "\"add\" or remove one by typing \"remove.\"");

                if (students.Exists(stu => stu.StudentId.ToString() == strInput))
                { // Looks to see if they entered an integer as a number then if it's a studentID).
                    numInput = students.FindIndex(stu => stu.StudentId.ToString() == strInput);
                    break;
                }
                else if (students.Exists(stu => stu.Name.ToLower() == strInput))
                {
                    numInput = students.FindIndex(student => student.Name.ToLower() == strInput);
                    break;
                }
                else if (strInput == "all") // Prints name, studentID, hometown, and favood for all students.
                {
                    Console.WriteLine("Here's all student info.");
                    for (int i = 0; i < students.Count; i++)
                    {
                        Console.WriteLine(students[i].Name + " has student ID: " + students[i].StudentId + " is from "
                            + students[i].Hometown + " and their favorite food is " + students[i].FavFood + ".");
                    }

                    RunAgain("Do you want to run the program again? y/n");
                    return;
                }
                else if (strInput == "add")
                {
                    string name = GetUserInput("Please enter the student's name."); // Some rich people name their kids numbers.
                    string homeTown = GetUserInput("Please enter their hometown."); // Same thing with the town and food.
                    string favFood = GetUserInput("Please enter their favorite food"); // That's why I'm not validating these, I swear.
                    studentDB.Add(name, homeTown, favFood);

                    studentDB = new StudentCRUD();
                    students = studentDB.students.ToList(); // We must update students after changing studentDB or it won't show to the user.

                    RunAgain("Do you want to run the program again? y/n");
                    return; // Ends the program when the above RunAgain() line finishes, which only occurs if user doesn't want to continue.
                }
                else if (strInput == "remove")
                {
                    while (true)
                    {
                        PrintAllStudents(); // Prints out index of every student so user can see who to pick.

                        strInput = GetUserInput("Please enter the index of the student you'd like to remove.");

                        if (students.Exists(stu => stu.StudentId.ToString() == strInput))
                        {
                            numInput = students.FindIndex(student => student.StudentId.ToString() == strInput);
                            studentDB.Remove(numInput); // Index starts at 1, so we have to push it back 1.

                            break;
                        }

                        Console.WriteLine("That was not a correct value. Let's try again.");
                    }

                    RunAgain("Do you want to run the program again? y/n");
                    return;
                }
                
                Console.WriteLine("Please enter a correct response.");
            }
            
            do // Gets input and checks if it contains a phrase corresponding to favorite food or hometown.
            {
                strInput = GetUserInput("Enter \"hometown\" to see their hometown or \"favorite food\" for their favorite food.");

                if (strInput.Contains("food") || strInput.Contains("fav")) // Checks if their input is referring to favorite food.
                {                     
                    Console.WriteLine(students[numInput].FavFood + " is " + students[numInput].Name + "'s favorite food."); 
                    break;
                }
                else if (strInput.Contains("home") || strInput.Contains("town")) // Checks if their input referring to hometown.
                {
                    Console.WriteLine(students[numInput].Hometown + " is " + students[numInput].Name + "'s hometown.");
                    break;
                }
                else
                {
                    Console.WriteLine("That was not a valid input. Let's try again.");
                }
            } while (true);


            RunAgain("Do you want to run the program again? y/n");
        }

        public static void RunAgain(string prompt)
        {
            Console.WriteLine(prompt);
            string input = Console.ReadLine().ToLower().Trim();
            
            if (input == "y")
            {
                Main();
            }
            else if (input == "n")
            {
                Console.WriteLine("Goodbye!");
                return;
            }
            else
            {
                Console.WriteLine("I didn't understand that. Let's try again.");
                RunAgain(prompt);
            }
        }

        public static string GetUserInput(string prompt)
        {
            Console.WriteLine(prompt);

            string response = Console.ReadLine().ToLower().Trim();

            if (response == "")
            {
                Console.WriteLine("You must enter something. Let's try again");
                return GetUserInput(prompt);
            }

            return response;
        }

        public static void PrintAllStudents()
        {
            Console.WriteLine("Here is the list of the names of all the students with their student ID.");
            for (int i = 0; i < students.Count; i++)
                Console.WriteLine(students[i].Name + " has the number " + students[i].StudentId + ".");
        }
    }
}

