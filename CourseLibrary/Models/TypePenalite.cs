using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CourseLibrary.Models;

namespace CourseLibrary
{
    public class TypePenalite
    {
        #region Properties
        [Key]
        public string Code { get; set; }
        public string Libelle { get; set; }
        public int Duree { get; set; }
        #endregion
        #region Methods
        public override string ToString()
        {
            return $"{Code}: {Libelle} ({Duree} minutes)";
        }
        public void ModifierTypePenalite(string code, string libelle, int duree)
        {
            Code = code;
            Libelle = libelle;
            Duree = duree;
        }
        public bool SupprimerTypePenalite()
        {
            var db = new ProjetVoilierContext();
            var typePenalite = db.TypePenalite.Find(Code);
            if (typePenalite == null)
            {
                return false;
            }
            db.TypePenalite.Remove(typePenalite);
            db.SaveChanges();
            return true;
        }
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