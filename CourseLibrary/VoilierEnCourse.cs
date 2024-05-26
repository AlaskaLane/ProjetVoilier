using System;
using System.Collections.Generic;
using System.Linq;

namespace CourseLibrary
{
    public class VoilierEnCourse : Voilier
    {
        #region Properties
        public string CodeInscritption { get; set; }
        public List<Epreuve> EpreuvesEffectuees { get; set; }
        public List<Penalite> Penalites { get; set; }
        public List<Entreprise> Sponsors { get; set; }
        public Course Course { get; set; }
        public int TempsBrut { get; set; }
        public bool Desistement { get; set; }
        #endregion

        #region Methods
         public bool AjouterEpreuve(Epreuve epreuve)
        {
            if (EpreuvesEffectuees.Exists(e => e.Num == epreuve.Num))
            {
                return false;
            }
            EpreuvesEffectuees.Add(epreuve);
            return true;
        }

        public Epreuve GetEpreuve(int num)
        {
            return EpreuvesEffectuees.Find(e => e.Num == num);
        }

        public void AfficherEpreuves()
        {
            foreach (Epreuve e in EpreuvesEffectuees)
            {
                Console.WriteLine("Epreuve Num: " + e.Num);
                Console.WriteLine("Libelle: " + e.Libelle);
                Console.WriteLine("Ordre: " + e.Ordre);
                Console.WriteLine("Course: " + e.Course.Id);
                Console.WriteLine("Penalites: ");
                AfficherPenalites();
            }
        }

        public void AfficherPenalites()
        {
            foreach (var penalite in Penalites)
            {
                AfficherDetailsPenalite(penalite);
            }
        }

        public bool SupprimerEpreuve(int num)
        {
            if (EpreuvesEffectuees.Exists(e => e.Num == num) == false)
            {
                return false;
            }
            Epreuve epreuve = GetEpreuve(num);
            EpreuvesEffectuees.Remove(epreuve);
            return true;
        }

        public int getTempPenalites()
        {
            int total = 0;
            foreach (Penalite p in this.Penalites)
            {
                total += p.TypePenalite.Duree;
            }
            return total;
        }

        public int getTempTotal()
        {
            int penalites = getTempPenalites();
            return TempsBrut - penalites;
        }

        public void AjouterPenalite(Penalite penalite)
        {
            Penalites.Add(penalite);
        }

        public void SupprimerPenalite(Penalite penalite)
        {
            Penalites.Remove(penalite);
        }

        public void AfficherDetailsPenalite(Penalite penalite)
        {
            Console.WriteLine("Penalite: " + penalite.TypePenalite.Libelle);
            Console.WriteLine("Voilier: " + this.CodeInscritption);
            Console.WriteLine("Epreuve: " + penalite.Epreuve.Libelle);
            Console.WriteLine("Position: " + penalite.Latitude + " " + penalite.Longitude);
        }

        public bool AjouterSponsor(Entreprise sponsor)
        {
            if (Sponsors.Exists(s => s.Id == sponsor.Id))
            {
                return false;
            }
            Sponsors.Add(sponsor);
            return true;
        }

        public bool SupprimerSponsor(Entreprise sponsor)
        {
            if (Sponsors.Exists(s => s.Id == sponsor.Id))
            {
                Sponsors.Remove(sponsor);
                return true;
            }
            return true;
        }

        #endregion
        #region Constructors
        public VoilierEnCourse(string code, string codeInscritption, Course course) 
            : base(code)
        {
            EpreuvesEffectuees = new List<Epreuve>();
            Sponsors = new List<Entreprise>();
            Penalites = new List<Penalite>();
            CodeInscritption = codeInscritption;
            Course = course;
            this.TempsBrut = 0;
            this.Desistement = false;
        }
        #endregion
    }
}