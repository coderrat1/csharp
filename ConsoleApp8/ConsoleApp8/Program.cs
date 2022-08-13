using System;
using System.Reflection;

namespace Serialization_IO
{
    class Reflection_Prop
    {
        private static void Main()
        {
            Console.WriteLine("Using Assembly getting the types present in Assembly");
            ////getting metaata from assembly 
            var currentAssembly = Assembly.GetExecutingAssembly();
            var typesfromCurrentAssembly = currentAssembly.GetTypes();
            foreach (var type in typesfromCurrentAssembly)
            {
                Console.WriteLine(type.Name);
            }
            Console.WriteLine();
            //Console.WriteLine("Getting only one type by");
            //var onetypeFromCurrentAssembly = currentAssembly.GetType("Serialization_IO.Students");
            //Console.WriteLine(onetypeFromCurrentAssembly.Name);
            //Console.WriteLine();

            //Type T = Type.GetType("Serialization_IO.Students");
            Students stud = new Students();
            Type T = stud.GetType();
            Console.WriteLine("Full name of namespace: " + T.FullName);
            Console.WriteLine("Name : " + T.Name);
            Console.WriteLine();

            PropertyInfo[] properties = T.GetProperties();
            Console.WriteLine("Properties of Studenys");
            foreach (PropertyInfo property in properties)
            {
                Console.WriteLine(property.PropertyType.Name + " " + property.Name);
            }

            //displaying method present in assembly 
            MethodInfo[] methods = T.GetMethods();
            Console.WriteLine("Methods of Students");
            foreach (MethodInfo method in methods)
            {
                Console.WriteLine(method.ReturnType.Name + " " + method.Name);
            }
            Console.WriteLine();

            //loading protected fields or methods
            MethodInfo[] methods2 = T.GetMethods(BindingFlags.Instance | BindingFlags.Public
                | BindingFlags.NonPublic);
            Console.WriteLine("Methods of Students");
            foreach (MethodInfo method in methods2)
            {
                Console.WriteLine(method.ReturnType.Name + " " + method.Name);
            }
            Console.WriteLine();

            //Displaying Constructors
            Console.WriteLine("Constructors of Students");
            ConstructorInfo[] constructors = T.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance
                | BindingFlags.Public);
            foreach (ConstructorInfo constructor in constructors)
            {
                Console.WriteLine(constructor.ToString());
            }
            Console.WriteLine();
            //Invoking constructors using Invoke method
            var student = constructors[1].Invoke(null);
            var student2 = constructors[0].Invoke(new object[] { 10, "Kevin" });

            //Creating an instance dynamically
            var student1 = Activator.CreateInstance(T, new object[] { 101, "Eren" });

            //cretae instance for private field by using unwrap 
            var studentManipulate = Activator.CreateInstance("Serialization_IO", "Serialization_IO.Students"
                , true, BindingFlags.Instance | BindingFlags.NonPublic, null, new object[] { "Carol" },
                null, null).Unwrap();

            var nameProperty = studentManipulate.GetType().GetProperty("Name");
            nameProperty.SetValue(studentManipulate, "Steven");

            Console.WriteLine(studentManipulate);

            Console.ReadLine();
        }
    }
    public interface IDetails
    {
        void StudentDet(string sentence);
    }
    public class Students : IDetails
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Students(int ID, string Name)
        {
            this.ID = ID;
            this.Name = Name;
            //Console.WriteLine($"Constructor is invoked {this.ID} and {this.Name}");
            PrintID();
            PrintName();
        }
        private Students(string Name)
        {
            this.Name = Name;
            PrintName();
        }
        public Students()
        {
            this.ID = -1;
            this.Name = string.Empty;
            Console.WriteLine("Constructor is invoked");
        }
        public void PrintID()
        {
            Console.WriteLine("Student ID: " + this.ID);
        }
        public void PrintName()
        {
            Console.WriteLine("Student Name: " + this.Name);
        }
        public void StudentDet(string sentence)
        {
            Console.WriteLine($"Students playing in {sentence}");
        }
        protected void Details(string sentence)
        {
            Console.WriteLine($"Introducing: {sentence}");
        }
    }
}