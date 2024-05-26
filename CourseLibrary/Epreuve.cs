using System;
using System.Collections.Generic;

namespace CourseLibrary
{
    public class Epreuve
    {
        #region Properties
        public int Num { get; set; }
        public string Libelle { get; set; }
        public int Ordre { get; set; }
        public Course Course { get; set; }
        #endregion
        #region Constructors
        public Epreuve(int num, string libelle, int ordre, Course course)
        {
            Num = num;
            Libelle = libelle;
            Ordre = ordre;
            Course = course;
        }
        public static int calcul(int[] prices, double k){
           double total;
            foreach (int price in prices){
                total =+ price;
            }
            return total;
        }

        #endregion
    }
}