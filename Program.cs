namespace CourseManangmentApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Course managment programm");
            do
            {
                Console.WriteLine("\nEnter 1 for creating new class\nEnter 2 for showing all groups info\nEnter 3 for changing group name\nEnter 4 to show students of one group\nEnter 5 to show all students\nEnter 6 to add new student\n");

                switch (Console.ReadLine())
                {
                    case "1":
                        GroopCommandsAndInfo.GroupCreator();
                        break;
                    case "2":
                        GroopCommandsAndInfo.ShowAllGroups();
                        break;
                    case "3":
                        GroopCommandsAndInfo.ChangeGroup();
                        break;
                    case "4":
                        GroopCommandsAndInfo.ShowOneGroupStudents();
                        break;
                    case "5":
                        GroopCommandsAndInfo.ShowAllStudents();
                        break;
                    case "6":
                        GroopCommandsAndInfo.StudentAdd();
                        break;
                    case "7":
                        Console.Beep();
                        break;

                    default:
                        Console.WriteLine("No such operation, try again");

                        break;
                }

            }
            while (true);

        }
    }
}
