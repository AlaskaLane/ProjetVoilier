using NUnit.Framework;
using CourseLibrary;

namespace CourseLibrary.Tests
{
    [TestFixture]
    public class PersonneTests
    {
        [Test]
        public void ToString_ReturnsCorrectFormat()
        {
            // Arrange
            var personne = new Personne(1, "Doe", "John", "john.doe@example.com", "123456789", "123 Main St", "12345", "Anytown", "Country");

            // Act
            var result = personne.ToString();

            // Assert
            Assert.That(result, Is.EqualTo("John Doe"));
        }

        [Test]
        public void GetAdresseComplete_ReturnsCorrectFormat()
        {
            // Arrange
            var personne = new Personne(1, "Doe", "John", "john.doe@example.com", "123456789", "123 Main St", "12345", "Anytown", "Country");

            // Act
            var result = personne.GetAdresseComplete();

            // Assert
            Assert.That(result, Is.EqualTo("123 Main St, 12345 Anytown, Country"));
        }

        [Test]
        public void GetContact_ReturnsCorrectFormat()
        {
            // Arrange
            var personne = new Personne(1, "Doe", "John", "john.doe@example.com", "123456789", "123 Main St", "12345", "Anytown", "Country");

            // Act
            var result = personne.GetContact();

            // Assert
            Assert.That(result, Is.EqualTo("Email: john.doe@example.com, Téléphone: 123456789"));
        }

        [Test]
        public void ModifierPersonne_ModifiesPropertiesCorrectly()
        {
            // Arrange
            var personne = new Personne(1, "Doe", "John", "john.doe@example.com", "123456789", "123 Main St", "12345", "Anytown", "Country");

            // Act
            personne.ModifierPersonne("Smith", "Jane", "jane.smith@example.com", "987654321", "456 Oak St", "54321", "Othertown", "AnotherCountry");

            // Assert
            Assert.That(personne.Nom, Is.EqualTo("Smith"));
            Assert.That(personne.Prenom, Is.EqualTo("Jane"));
            Assert.That(personne.Email, Is.EqualTo("jane.smith@example.com"));
            Assert.That(personne.Telephone, Is.EqualTo("987654321"));
            Assert.That(personne.Adresse, Is.EqualTo("456 Oak St"));
            Assert.That(personne.CodePostal, Is.EqualTo("54321"));
            Assert.That(personne.Ville, Is.EqualTo("Othertown"));
            Assert.That(personne.Pays, Is.EqualTo("AnotherCountry"));
        }
    }
}
