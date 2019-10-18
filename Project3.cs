using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace mdurham.CodeLou.ExerciseProject
{
    class Project3
    {
        private const string file = "students.json";
        private List<Student> _recordList = new List<Student>();
        private Dictionary<string, Student> _recordDictionary = new Dictionary<string, Student>();
        private string ShowMenu()
        {
            Console.WriteLine("Menu");
            Console.WriteLine("1. New Student");
            Console.WriteLine("2. List Students");
            Console.WriteLine("3. Find Student By Name");
            Console.WriteLine("4. Exit");
            var option = Console.ReadLine();
            return option;
        }

        public void DoAction()
        {
            if (File.Exists(file))
            {
                var json = File.ReadAllText(file);
                _recordList = JsonConvert.DeserializeObject<List<Student>>(json);
                foreach (var student in _recordList)
                {
                    _recordDictionary.Add(student.FirstName + " " + student.LastName, student);
                }
                Console.WriteLine($"students.json loaded with {_recordList.Count} students");
            }

            while (true)
            {
                var option = ShowMenu();
                switch (option)
                {
                    case "1":
                        {
                            var student = CreateStudent();
                            _recordList.Add(student);
                            _recordDictionary.Add(student.FirstName + " " + student.LastName, student);
                            break;
                        }
                    case "2":
                        ShowStudents();
                        break;
                    case "3":
                        FindStudent();
                        break;
                    case "4":
                        
                        var json = JsonConvert.SerializeObject(_recordList);
                        File.WriteAllText(file, json);
                        Console.WriteLine("students.json written");
                        return;
                    default:
                        Console.WriteLine("Unknown action " + option);
                        break;
                }
            }
        }

        private void ShowStudents()
        {
            Console.WriteLine($"Student Id | Name |  Class "); ;
            
            foreach (var student in _recordList)
            {
                Console.WriteLine($"{student.StudentId} | {student.FirstName} {student.LastName} | {student.ClassName} "); ;
            }
        }

        private void FindStudent()
        {
            Console.WriteLine("Enter full name to search for");
            var studentName = Console.ReadLine();
            if (_recordDictionary.ContainsKey(studentName))
            {
                var student = _recordDictionary[studentName];
                Console.WriteLine($"{student.StudentId} | {student.FirstName} {student.LastName} | {student.ClassName} "); ;
            }
            else
            {
                Console.WriteLine("Could not find user with that name");
            }
        }

       

        private Student CreateStudent()
        {
            Console.WriteLine("Enter Student Id");
            var studentId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter First Name");
            var studentFirstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name");
            var studentLastName = Console.ReadLine();
            Console.WriteLine("Enter Class Name");
            var className = Console.ReadLine();
            Console.WriteLine("Enter Last Class Completed");
            var lastClass = Console.ReadLine();
            Console.WriteLine("Enter Last Class Completed Date in format MM/dd/YYYY");
            var lastCompletedOn = DateTimeOffset.Parse(Console.ReadLine());
            Console.WriteLine("Enter Start Date in format MM/dd/YYYY");
            var startDate = DateTimeOffset.Parse(Console.ReadLine());

            var studentRecord = new Student();
            studentRecord.StudentId = studentId;
            studentRecord.FirstName = studentFirstName;
            studentRecord.LastName = studentLastName;
            studentRecord.ClassName = className;
            studentRecord.StartDate = startDate;
            studentRecord.LastClassCompleted = lastClass;
            studentRecord.LastClassCompletedOn = lastCompletedOn;
            return studentRecord;
        }
    }

}