using GroupJoinLinq;

class Program
{
    static void Main(string[] args)
    {
        //Listelerimizi oluşturduk verilerimizi ekledik
        List<Classes> classess = new List<Classes>();
        classess.Add(new Classes { ClassId = 1, ClassName = "Matematik" });
        classess.Add(new Classes { ClassId = 2, ClassName = "Türkçe" });
        classess.Add(new Classes { ClassId = 3, ClassName = "Kimya" });
        //Listelerimizi oluşturduk verilerimizi ekledik
        List<Students> students = new List<Students>();
        students.Add(new Students { StudentId = 1, StudentName = "Ali", ClassId = 1 });
        students.Add(new Students { StudentId = 2, StudentName = "Ayşe", ClassId = 2 });
        students.Add(new Students { StudentId = 3, StudentName = "Mehmet", ClassId = 1 });
        students.Add(new Students { StudentId = 4, StudentName = "Fatma", ClassId = 3 });
        students.Add(new Students { StudentId = 5, StudentName = "Ahmet", ClassId = 2 });


        /*
         classess tablomuz ile students tablomuzu birleştiriyoruz.
        GroupJoin yazdıktan sonra ilk birleştireceğimzi tabloyu yazıyoruz
        daha sonrası eşleştirme kriterlerimizi belirtiriyoruz.Class Id Lere göre eşleştirme yapıyoruz
        daha sonra anonim bir nesne yapıp çıkarmak istediğimiz verilerimizi seçiyoruz.
         */
        var studentsWithClass = classess.GroupJoin(
            students,
            clas => clas.ClassId,
            student => student.ClassId,
            (clas, studentGroup) => new
            {
                ClassName = clas.ClassName,
                Students = studentGroup.ToList()
            });

        foreach (var item in studentsWithClass)
        {
            Console.WriteLine($"Sınıfın Adı : {item.ClassName}");
            foreach (var student in item.Students)
            {
                Console.WriteLine($"Sınıfa Kayıtlı öğrenciler : {student.StudentName}");
            }
            Console.WriteLine("-------------------------------------"); 
        }


    }
}