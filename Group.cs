namespace CourseManangmentApp
{
    internal class Group
    {
        public List<Student> Students = new List<Student>();
        public string No;
        public static int GroupCountNo = 100;
        public string Category;
        public bool IsOnline;
        public byte Limit;
        public Group group;
        public Group(string no, string category, bool isOnline, byte limit)
        {
            No = no;
            Category = category;
            IsOnline = isOnline;
            Limit = limit;

        }
        public override string ToString()
        {
            string isOnline;
            if (IsOnline)
            {
                isOnline = "Group is online";
            }
            else
            {
                isOnline = "Group is offline";
            }
            return $"\nGroup name:{No}\nCategory:{Category}\n{isOnline}\nAmount of student:{Students.Count()}\n";
        }
        //public void CreateStudent(Student student)
        //{
        //    Students.Add(student);

        //}


    }
}
