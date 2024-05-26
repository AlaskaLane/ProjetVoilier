using System;
using System.Collections.Generic;

namespace CourseLibrary
{
    public class Penalite
    {
        #region Attributes
        private double _latitude;
        private double _longitude;
        #endregion
        #region Properties
        public TypePenalite TypePenalite { get; set; }
        public Epreuve Epreuve { get; set; }
        public double Latitude
        {
            get { return _latitude; }
            set
            {
                if (value < -90 || value > 90)
                {
                    throw new ArgumentOutOfRangeException("La latitude doit être comprise entre -90 et 90");
                }
                _latitude = value;
            }
        }
         
             <
             <
         
        public double Longitude
        {
            get { return _longitude; }
            set
            {
                if (value < -180 || value > 180)
                {
                    throw new ArgumentOutOfRangeException("La longitude doit être comprise entre -180 et 180");
                }
                _longitude = value;
            }
        }
        #endregion

        #region  Constructors
        public Penalite(TypePenalite code, Epreuve epreuve, double latitude, double longitude)
        {
            this.TypePenalite = code;
            this.Epreuve = epreuve;
            this.Latitude = latitude;
            this.Longitude = longitude;
        }
        #endregion
    }
}