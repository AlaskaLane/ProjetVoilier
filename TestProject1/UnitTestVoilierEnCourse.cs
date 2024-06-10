using NUnit.Framework;
using CourseLibrary;

namespace CourseLibrary.Tests
{
    [TestFixture]
    public class VoilierEnCourseTests
    {
        [Test]
        public void AjouterEpreuve_ReturnsTrueIfEpreuveIsAdded()
        {
            // Arrange
            var voilierEnCourse = new TestVoilierEnCourse("V1", "123");
            var epreuve = new Epreuve(1, "Test Epreuve", 1, 1);

            // Act
            var result = voilierEnCourse.AjouterEpreuve(epreuve);

            // Assert
            Assert.IsTrue(result);
            Assert.Contains(epreuve, voilierEnCourse.EpreuvesEffectuees);
        }

        [Test]
        public void AjouterEpreuve_ReturnsFalseIfEpreuveAlreadyExists()
        {
            // Arrange
            var voilierEnCourse = new TestVoilierEnCourse("V1", "123");
            var epreuve = new Epreuve(1, "Test Epreuve", 1, 1);
            voilierEnCourse.AjouterEpreuve(epreuve);

            // Act
            var result = voilierEnCourse.AjouterEpreuve(epreuve);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void SupprimerEpreuve_ReturnsTrueIfEpreuveIsDeleted()
        {
            // Arrange
            var voilierEnCourse = new TestVoilierEnCourse("V1", "123");
            var epreuve = new Epreuve(1, "Test Epreuve", 1, 1);
            voilierEnCourse.AjouterEpreuve(epreuve);

            // Act
            var result = voilierEnCourse.SupprimerEpreuve(1);

            // Assert
            Assert.IsTrue(result);
            Assert.IsEmpty(voilierEnCourse.EpreuvesEffectuees);
        }

        [Test]
        public void SupprimerEpreuve_ReturnsFalseIfEpreuveDoesNotExist()
        {
            // Arrange
            var voilierEnCourse = new TestVoilierEnCourse("V1", "123");

            // Act
            var result = voilierEnCourse.SupprimerEpreuve(1);

            // Assert
            Assert.IsFalse(result);
        }
    }


    public class TestVoilierEnCourse : VoilierEnCourse
    {
        public TestVoilierEnCourse(string code, string codeInscription) : base(code, codeInscription)
        {
        }
    }
}
