using System;
using System.Collections.Generic;

namespace CourseLibrary
{
    public class Epreuve
    {
        public int Num { get; set; }
        public string Libelle { get; set; }
        public int Ordre { get; set; }
        public Course Course { get; set; }
        public List<Penalite> Penalites { get; set; }
    }
}