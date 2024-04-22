using System;
using System.Collections.Generic;

namespace CourseLibrary
{
    public class Participe
    {
        public int Id { get; set; }
        public Voilier Voilier { get; set; }
        public Course Course { get; set; }
    }
}