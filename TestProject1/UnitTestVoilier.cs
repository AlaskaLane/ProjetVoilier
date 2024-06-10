using NUnit.Framework;
using CourseLibrary;

namespace CourseLibrary.Tests
{
    [TestFixture]
    public class VoilierTests
    {
        [Test]
        public void AjouterPersonne_ReturnsTrueIfPersonneIsAdded()
        {
            // Arrange
            var voilier = new TestVoilier("V1");
            var personne = new Personne(1, "Doe", "John", "john@example.com", "123456789", "123 Street", "12345", "City", "Country");

            // Act
            var result = voilier.AjouterPersonne(personne);

            // Assert
            Assert.IsTrue(result);
            Assert.Contains(personne, voilier.Equipage);
        }

        [Test]
        public void AjouterPersonne_ReturnsFalseIfPersonneAlreadyExists()
        {
            // Arrange
            var voilier = new TestVoilier("V1");
            var personne = new Personne(1, "Doe", "John", "john@example.com", "123456789", "123 Street", "12345", "City", "Country");
            voilier.AjouterPersonne(personne);

            // Act
            var result = voilier.AjouterPersonne(personne);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void SupprimerPersonne_ReturnsTrueIfPersonneIsDeleted()
        {
            // Arrange
            var voilier = new TestVoilier("V1");
            var personne = new Personne(1, "Doe", "John", "john@example.com", "123456789", "123 Street", "12345", "City", "Country");
            voilier.AjouterPersonne(personne);

            // Act
            var result = voilier.SupprimerPersonne(1);

            // Assert
            Assert.IsTrue(result);
            Assert.IsEmpty(voilier.Equipage);
        }

        [Test]
        public void SupprimerPersonne_ReturnsFalseIfPersonneDoesNotExist()
        {
            // Arrange
            var voilier = new TestVoilier("V1");

            // Act
            var result = voilier.SupprimerPersonne(1);

            // Assert
            Assert.IsFalse(result);
        }
    }
    public class TestVoilier : Voilier
    {
        public TestVoilier(string code) : base(code)
        {
        }
    }
}
