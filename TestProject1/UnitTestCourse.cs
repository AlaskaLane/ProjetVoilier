using NUnit.Framework;
using System;
using System.IO;
using CourseLibrary;

namespace CourseTestsNamespace
{
    [TestFixture]
    public class CourseTests
    {
        [Test]
        public void AfficherDetails_Test()
        {
            // Arrange
            Course course = new Course(1);
            course.Participants.Add(new VoilierEnCourse("VA102SETE","CODE52453,", course));
            course.Participants.Add(new VoilierEnCourse("VB103SETE", "CODE546R", course));
            course.Epreuves.Add(new Epreuve(1, "Epreuve 1", 1, course));

            // Capture la sortie console
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            course.AfficherDetails();

            // Récupère la sortie console
            string consoleOutput = stringWriter.ToString();

            // Assert
            StringAssert.Contains("Course ID: 1", consoleOutput);
            StringAssert.Contains("Participants:", consoleOutput);
            StringAssert.Contains("Epreuves:", consoleOutput);
            StringAssert.Contains("VA102SETE", consoleOutput);
            StringAssert.Contains("VB103SETE", consoleOutput);
            StringAssert.Contains("Epreuve 1", consoleOutput);
        }
    }
}
