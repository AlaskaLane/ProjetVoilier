using System;
using System.Collections.Generic;

namespace CourseLibrary
{
    public class Voilier
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public Entreprise Proprietaire { get; set; }
        public List<Personne> Personnes { get; set; }
        public List<Effectue> EpreuvesEffectuees { get; set; }
    }  
}