using NUnit.Framework;
using CourseLibrary;
using System.Collections.Generic;

namespace CourseTestsNamespace
{
    [TestFixture]
    public class VoilierEnCourseTests
    {
        [Test]
        public void AjouterPersonne_AjoutePersonneAvecSucces()
        {
            // Arrange
            VoilierEnCourse voilier = new VoilierEnCourse("Code1", "InscriptionCode1", new Course(1));
            Personne personne = new Personne(1, "John", "Doe", "john.doe@mail.fr", "0123456789", "1 rue de la Source", "75000", "Paris", "France");

            // Act
            bool ajoutReussi = voilier.AjouterPersonne(personne);

            // Assert
            Assert.IsTrue(ajoutReussi);
            Assert.Contains(personne, voilier.Equipage);
        }

        [Test]
        public void AjouterPersonne_EchoueSiPersonneDejaDansLEquipage()
        {
            // Arrange
            VoilierEnCourse voilier = new VoilierEnCourse("Code2", "InscriptionCode2", new Course(2));
            Personne personne = new Personne(2, "Jane", "Doe", "jane.doe@mail.fr", "0123456789", "1 rue de la Source", "75000", "Paris", "France");
            voilier.AjouterPersonne(personne);

            // Act
            bool ajoutReussi = voilier.AjouterPersonne(personne);

            // Assert
            Assert.That(ajoutReussi, Is.False);
            Assert.That(voilier.Equipage.Count, Is.EqualTo(1)); // Vérifie que la personne n'a pas été ajoutée deux fois
        }

        [Test]
        public void AjouterEpreuve_AjouteEpreuveAvecSucces()
        {
            // Arrange
            VoilierEnCourse voilier = new VoilierEnCourse("Code3", "InscriptionCode3", new Course(3));
            Epreuve epreuve = new Epreuve(1, "Epreuve 1", 1, new Course(3));

            // Act
            bool ajoutReussi = voilier.AjouterEpreuve(epreuve);

            // Assert
            Assert.IsTrue(ajoutReussi);
            Assert.Contains(epreuve, voilier.EpreuvesEffectuees);
        }

        [Test]
        public void GetPersonne_RenvoiePersonneCorrecte()
        {
            // Arrange
            VoilierEnCourse voilier = new VoilierEnCourse("Code5", "InscriptionCode5", new Course(5));
            Personne personne = new Personne(5, "John", "Doe", "john.doe@mail.fr", "0123456789", "1 rue de la Source", "75000", "Paris", "France");
            voilier.AjouterPersonne(personne);

            // Act
            Personne personneRecuperee = voilier.GetPersonne(5);

            // Assert
            Assert.That(personneRecuperee, Is.Not.Null);
            Assert.That(personneRecuperee, Is.EqualTo(personne));
        }

        // Autres tests similaires pour les autres méthodes de Voilier

        [Test]
        public void SupprimerPersonne_SupprimePersonneAvecSucces()
        {
            // Arrange
            VoilierEnCourse voilier = new VoilierEnCourse("Code6", "InscriptionCode6", new Course(6));
            Personne personne = new Personne(6, "John", "Doe", "john.doe@mail.fr", "0123456789", "1 rue de la Source", "75000", "Paris", "France");
            voilier.AjouterPersonne(personne);

            // Act
            bool suppressionReussie = voilier.SupprimerPersonne(6);

            // Assert
            Assert.IsTrue(suppressionReussie);
            Assert.IsFalse(voilier.Equipage.Contains(personne));
        }

        [Test]
        public void AfficherEpreuves_AfficheEpreuvesAvecSucces()
        {
            // Arrange
            VoilierEnCourse voilier = new VoilierEnCourse("Code1", "InscriptionCode1", new Course(1));
            Epreuve epreuve1 = new Epreuve(1, "Epreuve 1", 1, new Course(1));
            Epreuve epreuve2 = new Epreuve(2, "Epreuve 2", 2, new Course(1));
            voilier.AjouterEpreuve(epreuve1);
            voilier.AjouterEpreuve(epreuve2);

            // Act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                voilier.AfficherEpreuves();
                string consoleOutput = sw.ToString();

                // Assert
                StringAssert.Contains("Epreuve Num: 1", consoleOutput);
                StringAssert.Contains("Epreuve Num: 2", consoleOutput);
                StringAssert.Contains("Libelle: Epreuve 1", consoleOutput);
                StringAssert.Contains("Libelle: Epreuve 2", consoleOutput);
            }
        }
        [Test]
        public void getTempPenalites_CalculeCorrectementLaDureeTotaleDesPenalites()
        {
            // Arrange
            VoilierEnCourse voilier = new VoilierEnCourse("Code2", "InscriptionCode2", new Course(2));
            Penalite penalite1 = new Penalite(new TypePenalite("Pénalité 1","libellé 1", 10), new Epreuve(1, "Epreuve 1", 1, new Course(2)), 1, 1);
            Penalite penalite2 = new Penalite(new TypePenalite("Pénalité 2","libellé 2", 20), new Epreuve(2, "Epreuve 2", 2, new Course(2)), 2, 2);
            voilier.AjouterPenalite(penalite1);
            voilier.AjouterPenalite(penalite2);

            // Act
            int totalPenalites = voilier.getTempPenalites();

            // Assert
            Assert.That(totalPenalites.Equals(30));
        }
        [Test]
        public void getTempTotal_CalculeCorrectementLeTempsTotalApresLesPenalites()
        {
            // Arrange
            VoilierEnCourse voilier = new VoilierEnCourse("Code3", "InscriptionCode3", new Course(3));
            voilier.TempsBrut = 100;
            Penalite penalite1 = new Penalite(new TypePenalite("Pénalité 1","libellé 1", 10), new Epreuve(1, "Epreuve 1", 1, new Course(3)), 1, 1);
            Penalite penalite2 = new Penalite(new TypePenalite("Pénalité 2","libellé 2", 20), new Epreuve(2, "Epreuve 2", 2, new Course(3)), 2, 2);
            voilier.AjouterPenalite(penalite1);
            voilier.AjouterPenalite(penalite2);

            // Act
            int tempsTotal = voilier.getTempTotal();

            // Assert
            Assert.That(tempsTotal.Equals(70));
        }


        // Autres tests similaires pour les autres méthodes de Voilier
    }
}
