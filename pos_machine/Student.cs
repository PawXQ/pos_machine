using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos_machine
{
    internal class Student
    {
        public String Name = "Leo";
        public int Number = 1;
        public int Score = 100;
        public Student(string name, int number, int score)
        {
            Name = name;
            Number = number;
            Score = score;
        }

        public Student() { }
    }
}
