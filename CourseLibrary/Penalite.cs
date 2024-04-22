using System;
using System.Collections.Generic;

namespace CourseLibrary
{
    public class Penalite
    {
        public int Id { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public TypePenalite Type { get; set; }
        public Voilier Voilier { get; set; }
    }
}