using System;
using System.Collections.Generic;

namespace CourseLibrary
{
    public class TypePenalite
    {
        #region Properties
        public string Code { get; set; }
        public string Libelle { get; set; }
        public int Duree { get; set; }
        #endregion
        #region Constructors
        public TypePenalite(string code, string libelle, int duree)
        {
            Code = code;
            Libelle = libelle;
            Duree = duree;
        }
        #endregion
    }
}