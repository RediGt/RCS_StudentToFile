using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCS_StudentContactsJson
{
    class Student
    {
        public String name;
        public String lastName;
        public int age;

        public Student(String name, String lastName, int age)
        {
            this.name = name;
            this.lastName = lastName;
            this.age = age;
        }
    }
}
