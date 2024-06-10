using NUnit.Framework;
using CourseLibrary;
using System.Linq.Expressions;

namespace CourseLibrary.Tests
{
    [TestFixture]
    public class PenaliteTests
    {
        [Test]
        public void ModifierVoilierEnCourseId_ValidId_ReturnsTrue()
        {
            var typePenalite = new TypePenalite("SomeType", "SomeLibelle", 1);
            var epreuve = new Epreuve(1, "Test Epreuve", 1, 1);
            // Arrange
            var penalite = new Penalite(typePenalite, epreuve, "CODE4", 20.0, 40.0);

            // Act
            penalite.ModifierVoilierEnCourseId("CODE5");

            // Assert
            Assert.That(penalite.VoilierEnCourseId, Is.EqualTo("CODE5"));
        }

        [Test]
        public void ModifierPosition_ValidPosition_ReturnsTrue()
        {
            // Arrange
            var penalite = new Penalite();

            // Act
            var result = penalite.ModifierPosition(40.7128, -74.0060);

            // Assert
            Assert.IsTrue(result);
            Assert.That(penalite.Latitude, Is.EqualTo(40.7128));
            Assert.That(penalite.Longitude, Is.EqualTo(-74.0060));
        }

        [Test]
        public void ModifierPosition_InvalidLatitude_ReturnsFalse()
        {
            // Arrange
            var penalite = new Penalite();

            // Act
            var result = penalite.ModifierPosition(100, -74.0060);

            // Assert
            Assert.IsFalse(result);
            Assert.That(penalite.Latitude, Is.EqualTo(0)); 
            Assert.That(penalite.Longitude, Is.EqualTo(0));
        }

        [Test]
        public void ModifierPosition_InvalidLongitude_ReturnsFalse()
        {
            // Arrange
            var penalite = new Penalite();

            // Act
            var result = penalite.ModifierPosition(40.7128, -200);

            // Assert
            Assert.IsFalse(result);
            Assert.That(penalite.Latitude, Is.EqualTo(0)); 
            Assert.That(penalite.Longitude, Is.EqualTo(0)); 
        }
    }
}
