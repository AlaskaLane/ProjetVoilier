using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CourseLibrary
{
    public abstract class Voilier
    {
        #region Properties
        [Key]
        public string Code { get; set; }
        public List<Personne> Equipage { get; set; }
        #endregion

        #region Methods
        public bool AjouterPersonne(Personne personne)
        {
            if (Equipage.Exists(p => p.Id == personne.Id))
            {
                return false;
            }
            Equipage.Add(personne);
            return true;
        }
        public Personne GetPersonne(int id)
        {
            return Equipage.Find(p => p.Id == id);
        }
        public List<Personne> GetPersonnes()
        {
            return Equipage;
        }
        public bool SupprimerPersonne(int id)
        {
            if (Equipage.Exists(p => p.Id == id) == false)
            {
                return false;
            }
            Equipage.Remove(GetPersonne(id));
            return true;
        }
        public void ModifierCode(string code)
        {
            Code = code;
        }
        #endregion

        #region Constructors
        public Voilier(string code)
        {
            Code = code;
            Equipage = new List<Personne>();
        }
        #endregion
    }  
}