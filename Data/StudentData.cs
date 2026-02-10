using FirstRest_Project.Model;

namespace FirstRest_Project.Data
{
    public class StudentData
    {
        public static readonly List<Student> StudentList = new List<Student>
        {
            new Student{Id=1 , Name="Ahmad Alshikh", Age = 25 , Grade = 90 },
            new Student{Id=2 , Name="Omar Ali", Age = 20 , Grade = 66 },
            new Student{Id=3 , Name="Akram katib ", Age = 23 , Grade = 35},
            new Student{Id=4 , Name="Hazem Ammar", Age = 22 , Grade = 50 },
            new Student{Id=5 , Name="husin Alshikh", Age = 24 , Grade = 45 },
        };
    }
}
