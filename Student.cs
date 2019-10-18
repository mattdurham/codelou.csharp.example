using System;
using System.Collections.Generic;
using System.Text;

namespace mdurham.CodeLou.ExerciseProject
{
    class Student
    {
        public int StudentId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ClassName { get; set; }

        public DateTimeOffset StartDate { get; set; }

        public string LastClassCompleted { get; set; }

        public DateTimeOffset LastClassCompletedOn { get; set; }
    }
}
