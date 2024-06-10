using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CourseLibrary.Models;
using System.Linq;

namespace CourseLibrary
{
    public class Epreuve
    {
        #region Properties
        [Key]
        public int Num { get; set; }
        public string Libelle { get; set; }
        public int Ordre { get; set; }
        public Course Course { get; set; }
        public int CourseId { get; set; }

        #endregion
        #region Methods
        public void ModifierEpreuve(int num, string libelle, int ordre, int courseId)
        {
            Num = num;
            Libelle = libelle;
            Ordre = ordre;
            CourseId = courseId;
        }
        public bool ChargerCourse()
        {
            using var db = new ProjetVoilierContext();
            Course = db.Course.SingleOrDefault(c => c.Id == CourseId);
            if (Course == null)
            {
                return false;
            }
            return true;
        }
        public override string ToString()
        {
            return $"Epreuve {Num}: {Libelle}";
        }
        #endregion
        #region Constructors
        public Epreuve(int num, string libelle, int ordre, int courseId)
        {
            Num = num;
            Libelle = libelle;
            Ordre = ordre;
            CourseId = courseId;
        }
        #endregion
    }
}