using System;
using System.ComponentModel.DataAnnotations;
using CourseLibrary.Models;

namespace CourseLibrary
{
    public class Penalite
    {
        #region Attributes
        private double _latitude;
        private double _longitude;
        private TypePenalite _typePenalite;
        #endregion

        #region Properties
        public TypePenalite TypePenalite
        {
            get => _typePenalite;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(TypePenalite), "TypePenalite cannot be null");
                }
                _typePenalite = value;
            }
        }

        public Epreuve Epreuve { get; set; }
        public string VoilierEnCourseId { get; set; }
        public double Latitude
        {
            get => _latitude;
            set
            {
                if (value < -90 || value > 90)
                {
                    throw new ArgumentOutOfRangeException(nameof(Latitude), "Latitude must be between -90 and 90");
                }
                _latitude = value;
            }
        }
        public double Longitude
        {
            get => _longitude;
            set
            {
                if (value < -180 || value > 180)
                {
                    throw new ArgumentOutOfRangeException(nameof(Longitude), "Longitude must be between -180 and 180");
                }
                _longitude = value;
            }
        }
        #endregion
        #region Methods
        public override string ToString()
        {
            return $"Penalite: {TypePenalite.Libelle} - {Latitude} - {Longitude}";
        }
        public void ModifierVoilierEnCourseId(string voilierEnCourseId)
        {
            VoilierEnCourseId = voilierEnCourseId;
        }
        public bool ModifierPosition(double latitude, double longitude)
        {
            if (latitude < -90 || latitude > 90 || longitude < -180 || longitude > 180)
            {
                return false;
            }
            Latitude = latitude;
            Longitude = longitude;
            return true;
        }
        public bool ModifierTypePenality(TypePenalite typePenalite)
        {
            var db = new ProjetVoilierContext();
            if (typePenalite == null && db.TypePenalite.Find(typePenalite) == null)
            {
                return false;
            }
            TypePenalite = typePenalite;
            return true;
        }
        #endregion

        #region Constructors
        public Penalite() { }

        public Penalite(TypePenalite typePenalite, Epreuve epreuve, string voilierEnCourseId, double latitude, double longitude)
        {
            this.TypePenalite = typePenalite ?? throw new ArgumentNullException(nameof(typePenalite), "TypePenalite cannot be null");
            this.Epreuve = epreuve ?? throw new ArgumentNullException(nameof(epreuve), "Epreuve cannot be null");
            this.VoilierEnCourseId = voilierEnCourseId;
            this.Latitude = (latitude >= -90 && latitude <= 90) ? latitude : throw new ArgumentOutOfRangeException(nameof(latitude), "Latitude must be between -90 and 90");
            this.Longitude = (longitude >= -180 && longitude <= 180) ? longitude : throw new ArgumentOutOfRangeException(nameof(longitude), "Longitude must be between -180 and 180");
        }
        #endregion
    }
}
