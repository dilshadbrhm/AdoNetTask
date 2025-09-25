namespace AdoNetTask
{
    internal class Program
    {
        static void Main(string[] args)
        {

            StudentService service = new StudentService();

       
            Student newStudent = new Student
            {
                Name = "Dilshad",
                Surname = "Ibrahimli",
                Age = 22
            };
            service.Add(newStudent);

            Student student = service.Get(1); 
            if (student != null)
            {
                Console.WriteLine($"Id: {student.Id}, Name: {student.Name}, Surname: {student.Surname}, Age: {student.Age}");
            }
            else
            {
                Console.WriteLine("Student not found");
            }

        
            Student updateStudent = new Student
            {
                Id = 1, 
                Name = "dd",
                Surname = "ibrahimli",
                Age = 22
            };
            service.Update(updateStudent);

         
            service.Remove(1); 

            
        }
    }
    
}
