using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartOOP
{
    struct Worker
    {
        public Worker(int id, string fullName, int age, int height, DateTime dateOfBirth, string placeOfBirth)
        {
            Id = id;
            FullName = fullName;
            Age = age;
            Height = height;
            DateOfBirth = dateOfBirth;
            PlaceOfBirth = placeOfBirth;
        }
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public float Height { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
    }
}
