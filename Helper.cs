namespace CourseManangmentApp
{
    internal static class Helper
    {
        public static bool NameCheck(this string name)
        {
            name = name.Trim();
            if (string.IsNullOrEmpty(name) || name.Length <= 3 || name.Length >= 25)
            {
                return false;
            }
            foreach (char c in name)
            {
                if (char.IsDigit(c))
                {
                    return false;
                }
            }

            return true;
        }
        public static string NameCorrector(this string str)
        {
            str = str.Trim();
            str = str.Substring(0, 1).ToUpper() + str.Substring(1).ToLower();
            return str;

        }
        public static string NameInput(this string nameorsurname)
        {
            Console.WriteLine($"Enter student {nameorsurname}");
            do
            {
                string nameInput = Console.ReadLine();
                if (nameInput.NameCheck())
                {
                    return nameInput.NameCorrector();
                }
                else
                {
                    Console.WriteLine($"Student {nameorsurname} is invalid, try another");
                }
            }
            while (true);
        }
        public static bool IsGuaranteed()
        {
            Console.WriteLine("Is your student guaranteed?\nEnter 0 for no and 1 for yes");
            do
            {
                string option = Console.ReadLine();
                if (option == "0")
                {
                    return false;
                }
                else if (option == "1")
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Invalid input, try again");
                }

            }
            while (true);
        }

    }

}
