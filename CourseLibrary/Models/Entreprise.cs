using System;
using System.Collections.Generic;

namespace CourseLibrary
{
    public class Entreprise
    {
        #region Properties
        public int Id { get; set; }
        public string Nom { get; set; }
        #endregion

        #region Constructors
        public Entreprise(int id, string nom)
        {
            Id = id;
            Nom = nom;
        }
        #endregion
    }
}