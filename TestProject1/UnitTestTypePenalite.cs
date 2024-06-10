using NUnit.Framework;
using CourseLibrary;
using Microsoft.EntityFrameworkCore; 

namespace CourseLibrary.Tests
{
    [TestFixture]
    public class TypePenaliteTests
    {
        [Test]
        public void ToString_ReturnsCorrectFormat()
        {
            // Arrange
            var typePenalite = new TypePenalite("T1", "Type 1", 10);

            // Act
            var result = typePenalite.ToString();

            // Assert
            Assert.That(result, Is.EqualTo("T1: Type 1 (10 minutes)"));
        }

        [Test]
        public void ModifierTypePenalite_ModifiesPropertiesCorrectly()
        {
            // Arrange
            var typePenalite = new TypePenalite("T1", "Type 1", 10);

            // Act
            typePenalite.ModifierTypePenalite("T2", "Type 2", 15);

            // Assert
            Assert.That(typePenalite.Code, Is.EqualTo("T2"));
            Assert.That(typePenalite.Libelle, Is.EqualTo("Type 2"));
            Assert.That(typePenalite.Duree, Is.EqualTo(15));
        }

        [Test]
        public void SupprimerTypePenalite_ReturnsFalseIfTypePenaliteDoesNotExist()
        {
            // Arrange
            var typePenalite = new TypePenalite("T2", "Type 2", 15);

            // Act
            var result = typePenalite.SupprimerTypePenalite();

            // Assert
            Assert.IsFalse(result);
        }
    }
}
