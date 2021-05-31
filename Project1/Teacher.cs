//Myren Govender
using System;
using System.IO;

namespace Project1
{
    class Teacher
    {
        string id;
        string name;
        int year;
 
        static void Main(string[] args)
        {
            Teacher A = new Teacher();
            A.id = "A";
            A.name = "John";
            A.year = 2020;

            Teacher B = new Teacher();
            B.id = "B";
            B.name = "Henry";
            B.year = 2005;

            string dir = Directory.GetCurrentDirectory();
            string filePath = dir + "studentData.txt";

            if (File.Exists(filePath))
            {
                Console.WriteLine("File already exists");
            }
            else
            {
                using (StreamWriter writer = File.CreateText(filePath))
                {
                    writer.WriteLine(A.id + " " + A.name + " " + A.year);
                    writer.WriteLine(B.id + " " + B.name + " " + B.year);
                }
                
                Console.WriteLine("File is created and data is inserted");
            }

            Console.WriteLine("Enter 1 to store, 2 to retrieve, 3 to update");
            int option = Convert.ToInt32(Console.ReadLine());
            bool found = false;

            string answer = "";
            switch (option)
            {
                case 1:
                    Console.WriteLine("Enter the ID of the teacher");
                    answer = Console.ReadLine();
                    Teacher C = new Teacher();
                    C.id = answer;
                    Console.WriteLine("Enter the name of the teacher");
                    answer = Console.ReadLine();
                    C.name = answer;
                    Console.WriteLine("Enter the year they started");
                    int yearStart = Convert.ToInt32(Console.ReadLine());
                    C.year = yearStart;
                    using (StreamWriter add = new StreamWriter(filePath, true))
                    {
                        add.WriteLine(C.id + " " + C.name + " " + C.year);
                    }
                    break;
                case 2:
                    Console.WriteLine("Enter the ID of the teacher to retrieve");
                    answer = Console.ReadLine();
                    string[] lines = File.ReadAllLines(filePath);
                    foreach (string line in lines)
                    {
                        if (line.Contains(answer))
                        {
                            Console.WriteLine(line);
                            found = true;
                        }
                    }
                    if (found == false)
                    {
                        Console.WriteLine("No teacher matches the ID");

                    }
                    break;
                case 3:
                    Console.WriteLine("Enter the ID of the teacher to update");
                    answer = Console.ReadLine();
                    string[] liness = File.ReadAllLines(filePath);
                    File.Delete(filePath);
                    StreamWriter writer = File.CreateText(filePath);
                    writer.Close();
                    Teacher D = new Teacher();
                    foreach (string line in liness)
                    {
                        if (line.Contains(answer))
                        {
                            Console.WriteLine(line);
                            found = true;
                            Console.WriteLine("Teacher found");
                            Console.WriteLine("Input the new ID");
                            string answers = Console.ReadLine();
                            D.id = answers;
                            Console.WriteLine("Input the new name");
                            answers = Console.ReadLine();
                            D.name = answers;
                            Console.WriteLine("Input the new starting year");
                            int startYear = Convert.ToInt32(Console.ReadLine());
                            D.year = startYear;
                            using (StreamWriter replace = new StreamWriter(filePath, true))
                            {
                                replace.WriteLine(D.id + " " + D.name + " " + D.year);
                            }
                        }
                        else
                        {
                            using (StreamWriter replace = new StreamWriter(filePath, true))
                            {
                                replace.WriteLine(line);                                
                            }
                        }
                    }
                    if (found == false)
                    {
                        Console.WriteLine("No teacher matches the ID");
                    }
                    break;
                default:
                    Console.WriteLine("A valid option was not selected");
                    break;
            }    


            




            
        }
    }
}
