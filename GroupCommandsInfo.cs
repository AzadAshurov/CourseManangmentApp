namespace CourseManangmentApp
{
    internal class GroopCommandsAndInfo
    {
        static List<Group> groups { get; set; } = new List<Group>();
        public static bool GroupCloneCheck(string groupFullInit)
        {
            foreach (Group groupName in groups)
            {
                if (groupName.No == groupFullInit)
                {
                    return true;
                }
            }
            return false;
        }
        public static void GroupCreator()
        {
            Console.WriteLine("\nEnter Group specialization \nP for programming\nD for design \nS for System administration\n0 to return main menu");
            string option = null;
            int groupInitNum;
            string groupInit = null;
            bool isOnline = false;
            byte limit;
            string groupFullInit;
            string category = null;

            int result;

            do
            {
                option = Console.ReadLine().Trim();
                switch (option)
                {
                    case "P":
                    case "p":
                        groupInit = "P";
                        category = Category.Programming.ToString();
                        break;
                    case "D":
                    case "d":
                        groupInit = "D";
                        category = Category.Design.ToString();
                        break;
                    case "S":
                    case "s":
                        groupInit = "S";
                        category = Category.SystemAdministration.ToString();
                        break;
                    case "0":
                        return;
                    case null:
                    default:
                        Console.WriteLine("No such operation try again");
                        break;
                }
            }
            while (groupInit != "P" && groupInit != "D" && groupInit != "S");

            option = null;

            Console.WriteLine("\nEnter group serial number (from 100 up to 999)\nEnter 0 to return main menu\nEnter 1 to restart creating group");
            do
            {
                option = Console.ReadLine().Trim();

                if (int.TryParse(option, out result))
                {
                    if (result == 0)
                    {
                        return;
                    }
                    else if (result == 1)
                    {
                        GroupCreator();
                        return;
                    }
                    else if (result >= 100 && result <= 999)
                    {
                        bool groupClone = false;
                        groupInitNum = result;
                        groupFullInit = groupInit + groupInitNum;
                        if (GroupCloneCheck(groupFullInit))
                        {
                            Console.WriteLine("\nThis group already exists, try another serial number");
                        }
                        else
                        {
                            break;
                        }

                    }
                    else
                    {
                        Console.WriteLine("Invalid serial number try again");
                    }
                }
                else
                {
                    Console.WriteLine("No such operation try again");
                }
            }
            while (true);
            option = null;
            Console.WriteLine("\nIs group online?Enter Yes/No\nEnter 0 to return main menu\nEnter 1 to restart creating group");
            do
            {
                option = Console.ReadLine().ToLower().Trim();

                if (option == "yes")
                {
                    isOnline = true;
                    break;
                }
                else if (option == "no")
                {
                    isOnline = false;
                    break;
                }
                else if (option == "0")
                {
                    return;
                }
                else if (option == "1")
                {
                    GroupCreator();
                    return;
                }
                else
                {
                    Console.WriteLine("No such operation try again");
                }
            }
            while (true);
            if (isOnline)
            {
                limit = 15;
            }
            else
            {
                limit = 10;
            }

            groupFullInit = groupInit + groupInitNum;
            Group group = new Group(groupFullInit, category, isOnline, limit);
            groups.Add(group);
            Console.WriteLine($"\nGroup {groupFullInit} was added successufully\n");
            //foreach (var item in groups)
            //{
            //    Console.WriteLine(item.IsOnline);
            //}
        }


        public static void ShowAllGroups()
        {
            if (groups.Count() == 0)
            {
                Console.WriteLine("\nNo groups added yet.Try create one first!");
            }
            else
            {
                foreach (Group group in groups)
                {
                    Console.WriteLine(group.ToString());
                }
            }
        }
        public static void ChangeGroup()
        {
            if (!groups.Any())
            {
                Console.WriteLine("\nNo groups added yet.Try create one first!");
                GroupCreator();
                return;
            }
            Console.WriteLine("Choose group that you want to change or enter 0 to return to main menu\nAvailable groups:");
            foreach (Group group in groups)
            {
                Console.WriteLine(group.No);
            }
            do
            {

                string inputGroupName = Console.ReadLine().ToUpper().Trim();
                if (inputGroupName == "0")
                {
                    return;
                }
                foreach (Group group in groups)
                {
                    if (group.No == inputGroupName)
                    {
                        string input;
                        Console.WriteLine("Change group specialization and serial number(100-999) \nP for programming\nD for design \nS for System administration\n0 to return main menu\n");
                        do
                        {
                            input = Console.ReadLine().ToUpper().Trim();
                            if (input.Length == 4 && (input[0] == 'D' || input[0] == 'P' || input[0] == 'S') && char.IsDigit(input[1]) && input[1] != '0' && char.IsDigit(input[2]) && char.IsDigit(input[3]))
                            {
                                if (!GroupCloneCheck(input))
                                {
                                    group.No = input;
                                    switch (input[0])
                                    {
                                        case 'P':
                                            group.Category = Category.Programming.ToString();
                                            break;
                                        case 'S':
                                            group.Category = Category.SystemAdministration.ToString();
                                            break;
                                        case 'D':
                                            group.Category = Category.Design.ToString();
                                            break;

                                    }
                                    Console.WriteLine($"Group name was changed to {input}");
                                    return;
                                }
                                else
                                {
                                    Console.WriteLine($"You cant change group name to {input} because this name is already used");
                                }
                            }
                            else if (input == "0")
                            {
                                return;
                            }

                            Console.WriteLine("Invalid group name,try another");

                        }
                        while (true);

                    }


                }
                Console.WriteLine("Group doesnt exist,try available one");
            }
            while (true);

        }
        public static void StudentAdd()
        {
            if (!groups.Any())
            {
                Console.WriteLine("\nCant add students because no groups created yet.Try create one first!");
                GroupCreator();
                return;
            }
            Console.WriteLine("Choose group that you want to add new student or enter 0 to return to main menu\nAvailable groups:");
            foreach (Group group in groups)
            {
                Console.WriteLine(group.No);
            }
            do
            {

                string inputGroupName = Console.ReadLine().ToUpper().Trim();
                if (inputGroupName == "0")
                {
                    return;
                }
                foreach (Group group in groups)
                {
                    if (group.No == inputGroupName)
                    {
                        if (group.Students.Count >= group.Limit)
                        {
                            Console.WriteLine("Cant add anyone because group overloaded");
                            return;
                        }
                        else
                        {
                            Student student = new Student("name".NameInput(), "surname".NameInput(), Helper.IsGuaranteed());
                            group.Students.Add(student);

                            return;
                        }
                    }
                }
                Console.WriteLine("This group doesnt exist try again");
            } while (true);
        }

        public static void ShowOneGroupStudents()
        {
            if (!groups.Any())
            {
                Console.WriteLine("\nNo groups added yet.Try create one first!");
                GroupCreator();
                return;
            }
            Console.WriteLine("Choose group that students will apply on screen or enter 0 to return to main menu\nAvailable groups:");
            foreach (Group group in groups)
            {
                Console.WriteLine(group.No);
            }
            string inputGroupName = Console.ReadLine().ToUpper().Trim();
            if (inputGroupName == "0")
            {
                return;
            }
            foreach (Group group in groups)
            {
                if (group.No == inputGroupName)
                {
                    foreach (Student student in group.Students)
                    {
                        Console.WriteLine($"{student.Name} {student.Surname}");
                    }
                    return;
                }
            }
            Console.WriteLine("\nThis group doesnt exist");

        }

        public static void ShowAllStudents()
        {
            if (!groups.Any())
            {
                Console.WriteLine("\nNot one group exists, add groups then students.");
                return;
            }

            bool anyGroupWithStudents = false;

            foreach (Group group in groups)
            {
                if (group.Students.Any())
                {
                    anyGroupWithStudents = true;
                    Console.WriteLine($"\nGroup {group.No}");
                    foreach (Student student in group.Students)
                    {
                        Console.WriteLine($"{student.Name} {student.Surname}");
                    }
                }
            }

            if (!anyGroupWithStudents)
            {
                Console.WriteLine("All groups have no students.");
            }
        }


    }
}
