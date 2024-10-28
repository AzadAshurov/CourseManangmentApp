namespace CourseManangmentApp.Models
{
    internal class Student
    {
        public string Name;
        public string Surname;

        public bool IsGuaranteed;
        public Student(string name, string surname, bool isGuaranteed)
        {
            Name = name;
            Surname = surname;
            IsGuaranteed = isGuaranteed;
        }

    }
}
