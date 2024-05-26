using System;
using System.Collections.Generic;

namespace CourseLibrary
{
    public class Course
    {
        public int Id { get; set; }
        public List<Epreuve> Epreuves { get; set; }
        public List<Voilier> Participants { get; set; }

        #region Methods
        public void AfficherDetails()
        {
            Console.WriteLine("Course ID: " + this.Id);
            Console.WriteLine("Participants: ");
            foreach (Voilier p in this.Participants)
            {
                Console.WriteLine("  - " + p.Code);
            }
            Console.WriteLine("Epreuves: ");
            foreach (Epreuve e in this.Epreuves)
            {
                Console.WriteLine("  - " + e.Num);
                Console.WriteLine(" " + e.Libelle);
            }
        }
        #endregion
        #region Constructors
        public Course(int id)
        {
            Id = id;
            Epreuves = new List<Epreuve>();
            Participants = new List<Voilier>();
        }
        #endregion
    }
}
