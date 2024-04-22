using System;
using System.Collections.Generic;

namespace CourseLibrary
{
    public class Effectue
    {
        public int Id { get; set; }
        public int Num { get; set; }
        public int Duree { get; set; }
        public Voilier Voilier { get; set; }
        public Epreuve Epreuve { get; set; }
    }
}