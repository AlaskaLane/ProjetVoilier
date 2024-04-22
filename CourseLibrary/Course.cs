using System;
using System.Collections.Generic;

namespace CourseLibrary
{
    public class Course
    {
        public int Id { get; set; }
        public List<Epreuve> Epreuves { get; set; }
        public List<Participe> Participants { get; set; }
    }
}
