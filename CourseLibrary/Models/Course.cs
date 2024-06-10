using System;
using System.Collections.Generic;
using System.Text; 
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseLibrary
{
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public List<Epreuve> Epreuves { get; set; }
        public List<VoilierEnCourse> Participants { get; set; }

        #region Methods

        public bool AjouterParticipant(VoilierEnCourse participant)
        {
            if (Participants.Exists(p => p.Code == participant.Code))
            {
                return false;
            }
            Participants.Add(participant);
            return true;
        }
        public VoilierEnCourse GetParticipant(string code)
        {
            return Participants.Find(p => p.Code == code);
        }
        public List<VoilierEnCourse> GetParticipants()
        {
            return Participants;
        }
        public bool SupprimerParticipant(string code)
        {
            if (Participants.Exists(p => p.Code == code) == false)
            {
                return false;
            }
            Participants.Remove(GetParticipant(code));
            return true;
        }
        public override string ToString()
        {
            var details = new StringBuilder();
            details.AppendLine($"Course ID: {Id}");
            details.AppendLine("Participants:");
            foreach (var p in Participants)
            {
                details.AppendLine($"  - {p.Code}");
            }
            details.AppendLine("Epreuves:");
            foreach (var e in Epreuves)
            {
                details.AppendLine($"  - {e.Num}: {e.Libelle}");
            }
            return details.ToString();
        }
        public void AfficherDetails()
        {
            Console.WriteLine(this.ToString());
        }
        public bool AjouterEpreuve(Epreuve epreuve)
        {
            if (Epreuves.Exists(e => e.Num == epreuve.Num))
            {
                return false;
            }
            Epreuves.Add(epreuve);
            return true;
        }
        public bool SupprimerEpreuve(int num)
        {
            if (Epreuves.Exists(e => e.Num == num) == false)
            {
                return false;
            }
            Epreuves.Remove(Epreuves.Find(e => e.Num == num));
            return true;
        }
        #endregion
        #region Constructors
        public Course()
        {
            Epreuves = new List<Epreuve>();
            Participants = new List<VoilierEnCourse>();
        }
        #endregion
    }
}
