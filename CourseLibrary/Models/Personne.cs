using System;
using System.Collections.Generic;

namespace CourseLibrary
{
    public class Personne
    {
        #region Properties
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Adresse { get; set; }
        public string CodePostal { get; set; }
        public string Ville { get; set; }
        public string Pays { get; set; }
        #endregion
        #region Methods
        public override string ToString()
        {
            return $"{Prenom} {Nom}";
        }
        public string GetAdresseComplete()
        {
            return $"{Adresse}, {CodePostal} {Ville}, {Pays}";
        }
        public string GetContact()
        {
            return $"Email: {Email}, Téléphone: {Telephone}";
        }
        public void ModifierPersonne(string nom, string prenom, string email, string telephone, string adresse, string codePostal, string ville, string pays)
        {
            Nom = nom;
            Prenom = prenom;
            Email = email;
            Telephone = telephone;
            Adresse = adresse;
            CodePostal = codePostal;
            Ville = ville;
            Pays = pays;
        }
        #endregion

        #region Constructors
        public Personne(int id, string nom, string prenom, string email, string telephone, string adresse, string codePostal, string ville, string pays)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
            Email = email;
            Telephone = telephone;
            Adresse = adresse;
            CodePostal = codePostal;
            Ville = ville;
            Pays = pays;
        }
        #endregion
    }
}