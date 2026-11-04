using System.Xml.Linq;

namespace task_3
{
  class Instructor
    {
        public int Instructor_Id;
        public string Name;
        public string Specialization;

        public Instructor(int Instructor_Id, string Name, string Specialization)
        {
            this.Instructor_Id = Instructor_Id;
            this.Name = Name;
            this.Specialization = Specialization;
        } 
        public string PrintDetails()
        {
            return $"Id: {Instructor_Id}, Name: {Name}, Specialization: {Specialization}";
        }
    }

    class Courses
    {
        public int Course_Id;
        public string Title;
        public Instructor Instructor;

        public Courses(int Course_Id, string Title, Instructor Instructor)
        {
           this.Course_Id = Course_Id;
           this.Title = Title;
           this.Instructor = Instructor;
        }
        public string PrintDetails()
        {
            return $"Id: {Course_Id}, Title: {Title}, Name Of Instructor: {Instructor.Name}";
        }
    }

   
    class Students
    {
        public int Student_Id;
        public string Name;
        public int Age;
        public List<Courses> Courses;

        public Students(int Student_Id, string Name, int Age)
        {
            this.Student_Id = Student_Id;
            this.Name = Name;
            this.Age = Age;
            this.Courses = new List<Courses>();
        }
       public bool Enroll(Courses Courses)
        {
            if (this.Courses.Contains(Courses))
            {
                return false;
            }
            else
            {
               this.Courses.Add(Courses);
                return true;
            }
            
        }
        public string PrintDetails()
        {
            string result = $"Id: {Student_Id}, Name: {Name}, Age: {Age}, Courses: ";
            
            for (int i = 0; i < Courses.Count; i++)
            {
                result += Courses[i].Title + " ";
            }
            return result;
        }


    }


    class Student_Maneger
    {
        public List<Students> Students;
        public List<Courses> Courses;
        public List<Instructor> Instructor;

        public Student_Maneger()
        {
            this.Students = new List<Students>();
            this.Courses = new List<Courses>();
            this.Instructor = new List<Instructor>();
        }
        public bool Add_Student(Students Students)
        {
            if (Find_Student(Students.Student_Id) != null)
            {
                return false; 
            }
            this.Students.Add(Students);
            return true;


        }
        public bool Add_Course(Courses Courses)
        {
            if (Find_Course(Courses.Course_Id) != null)
            {
                return false; 
            }
            this.Courses.Add(Courses);
            return true;


        }
        public bool Add_Instructor(Instructor Instructor)
        {
            if (Find_Instructor(Instructor.Instructor_Id) != null)
            {
                return false; 
            }
            this.Instructor.Add(Instructor);
            return true;


        }
        public Students Find_Student(int Student_Id)
        {
            for (int i = 0; i < this.Students.Count; i++)
            {
                if (this.Students[i].Student_Id == Student_Id)
                {
                    return this.Students[i];
                }
            }
            return null;
        }

        
        public Courses Find_Course(int Course_Id)
        {
            for (int i = 0; i < this.Courses.Count; i++)
            {
                if (this.Courses[i].Course_Id == Course_Id)
                {
                    return this.Courses[i];
                }
            }
            return null;


        }
        public Instructor Find_Instructor(int Instructor_Id)
        {
            for (int i = 0; i < this.Instructor.Count; i++)
            {
                if (this.Instructor[i].Instructor_Id == Instructor_Id)
                {
                    return this.Instructor[i];
                }
            }
            return null;


        }
        public bool Enroll_Student_In_Course(int Student_Id, int Course_Id)
        {
            Students student = Find_Student(Student_Id);
            Courses course = Find_Course(Course_Id);

            if (student == null || course == null)
            {
                return false; 
            }
            return student.Enroll(course);


        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Student_Maneger m = new Student_Maneger();
            
            string choice;
            
            do
            {
                Console.WriteLine("\n1. Add Student");
                Console.WriteLine("2. Add Instructor");
                Console.WriteLine("3. Add Course");
                Console.WriteLine("4. Enroll Student in Course");
                Console.WriteLine("5. Show All Students");
                Console.WriteLine("6. Show All Courses");
                Console.WriteLine("7. Show All Instructors");
                Console.WriteLine("8. Find the student by id or name");
                Console.WriteLine("9. Find the course by id or name");
                Console.WriteLine("10. Check if the student enrolled in specific course");
                Console.WriteLine("11. Return the instructor name by course name");
                Console.WriteLine("12. Exit");

                choice = Console.ReadLine();


                switch (choice)
                {
                    case "1":

                        Console.WriteLine("Enter Student Id:");
                        int stuId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Name:");
                        string stuName = Console.ReadLine();
                        Console.WriteLine("Enter Age:");
                        int stuAge = Convert.ToInt32(Console.ReadLine());

                        Students newStudent = new Students(stuId, stuName, stuAge);

                        if (m.Add_Student(newStudent))
                        {
                            Console.WriteLine("Student added");
                        }

                        else
                        {
                            Console.WriteLine("Id already exists");
                        }

                        break;

                    case "2":

                        Console.WriteLine("Enter Instructor Id:");
                        int instId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Name:");
                        string instName = Console.ReadLine();
                        Console.WriteLine("Enter Specialization:");
                        string instSpec = Console.ReadLine();

                        Instructor newInstructor = new Instructor(instId, instName, instSpec);

                        if (m.Add_Instructor(newInstructor))
                        {
                            Console.WriteLine("Instructor added");
                        }
                        else
                        {
                            Console.WriteLine("Id already exists");
                        }
                        break;

                    case "3":

                        Console.WriteLine("Enter Course Id:");
                        int courseId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Title:");
                        string courseTitle = Console.ReadLine();
                        Console.WriteLine("Enter Instructor Id:");
                        int courseInstId = Convert.ToInt32(Console.ReadLine());

                        Instructor courseInstructor = m.Find_Instructor(courseInstId);

                        if (courseInstructor == null)
                        {
                            Console.WriteLine("Instructor not found");
                        }
                        else
                        {
                            Courses newCourse = new Courses(courseId, courseTitle, courseInstructor);

                            if (m.Add_Course(newCourse))
                            {
                                Console.WriteLine("Course added");
                            }
                            else
                            {
                                Console.WriteLine("Id already exists");
                            }
                        }
                        break;

                    case "4":

                        Console.WriteLine("Enter Student Id:");
                        int enrStuId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Course Id:");
                        int enrCourseId = Convert.ToInt32(Console.ReadLine());

                        if (m.Enroll_Student_In_Course(enrStuId, enrCourseId))
                        {
                            Console.WriteLine("Enrolled successfully");
                        }
                        else
                        {
                            Console.WriteLine("Failed: student/course not found, or already enrolled");
                        }

                        break;

                    case "5":

                        for (int i = 0; i < m.Students.Count; i++)
                        {
                            Console.WriteLine(m.Students[i].PrintDetails());
                        }

                        break;

                    case "6":

                        for (int i = 0; i < m.Courses.Count; i++)
                        {
                            Console.WriteLine(m.Courses[i].PrintDetails());
                        }

                        break;
                           
                    case "7":

                        for (int i = 0; i < m.Instructor.Count; i++)
                        {
                            Console.WriteLine(m.Instructor[i].PrintDetails());
                        }

                        break;

                    case "8":

                        Console.WriteLine("Search by:  (1) Id   |||   (2) Name  ");
                        string stuSearchType = Console.ReadLine();

                        if (stuSearchType == "1")
                        {
                            Console.WriteLine("Enter Student Id:");
                            int stuSearchId = Convert.ToInt32(Console.ReadLine());

                            Students foundById = m.Find_Student(stuSearchId);

                            if (foundById != null)
                            {
                                Console.WriteLine(foundById.PrintDetails());
                            }
                            else
                            {
                                Console.WriteLine("Student not found");
                            }
                        }
                        else if (stuSearchType == "2")
                        {
                            Console.WriteLine("Enter Student Name:");
                            string stuSearchName = Console.ReadLine();
                            bool stuFound = false;

                            for (int i = 0; i < m.Students.Count; i++)
                            {
                                if (m.Students[i].Name.ToUpper().Contains(stuSearchName.ToUpper()))
                                {
                                    Console.WriteLine(m.Students[i].PrintDetails());
                                    stuFound = true;
                                }
                            }

                            if (!stuFound)
                            {
                                Console.WriteLine("Student not found");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice");
                        }

                        break;

                    case "9":

                        Console.WriteLine("Search by:   (1) Id   |||   (2) Title  ");
                        string courseSearchType = Console.ReadLine();

                        if (courseSearchType == "1")
                        {
                            Console.WriteLine("Enter Course Id:");
                            int courseSearchId = Convert.ToInt32(Console.ReadLine());

                            Courses foundCourseById = m.Find_Course(courseSearchId);

                            if (foundCourseById != null)
                            {
                                Console.WriteLine(foundCourseById.PrintDetails());
                            }
                            else
                            {
                                Console.WriteLine("Course not found");
                            }
                        }
                        else if (courseSearchType == "2")
                        {
                            Console.WriteLine("Enter Course Title:");
                            string courseSearchTitle = Console.ReadLine();
                            bool courseFound = false;

                            for (int i = 0; i < m.Courses.Count; i++)
                            {
                                if (m.Courses[i].Title.ToUpper().Contains(courseSearchTitle.ToUpper()))
                                {
                                    Console.WriteLine(m.Courses[i].PrintDetails());
                                    courseFound = true;
                                }
                            }

                            if (!courseFound)
                            {
                                Console.WriteLine("Course not found");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice");
                        }

                        break;

                    case "10":
                        
                        Console.WriteLine("Enter Student Id:");
                        int chkStuId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Course Title:");
                        string chkTitle = Console.ReadLine();

                        Students chkStudent = m.Find_Student(chkStuId);

                        if (chkStudent == null)
                        {
                            Console.WriteLine("Student not found");
                        }
                        else
                        {
                            bool enrolled = false;

                            for (int i = 0; i < chkStudent.Courses.Count; i++)
                            {
                                if (chkStudent.Courses[i].Title.ToUpper() == chkTitle.ToUpper())
                                {
                                    enrolled = true;
                                }
                            }

                            if (enrolled)
                            {
                                Console.WriteLine("Student is enrolled in this course");
                            }
                            else
                            {
                                Console.WriteLine("Student is NOT enrolled in this course");
                            }
                        }

                        break;

                    case "11":

                        Console.WriteLine("Enter Course Title:");
                        string instByTitle = Console.ReadLine();
                        bool instFound = false;

                        for (int i = 0; i < m.Courses.Count; i++)
                        {
                            if (m.Courses[i].Title.ToUpper() == instByTitle.ToUpper())
                            {
                                Console.WriteLine("Instructor: " + m.Courses[i].Instructor.Name);
                                instFound = true;
                            }
                        }

                        if (!instFound)
                        {
                            Console.WriteLine("Course not found");
                        }

                        break;

                    case "12":
                        Console.WriteLine("Goodbye");
                        break;

                    default:
                        Console.WriteLine("Invalid input");
                        break;

                } 
            }
            while (choice != "12");
        }
    }
}
