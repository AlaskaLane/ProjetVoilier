using NUnit.Framework;
using CourseLibrary;
using System.Collections.Generic;

namespace CourseLibrary.Tests
{
    [TestFixture]
    public class CourseTests
    {
        private Course _course;
        private VoilierEnCourse _voilier1;
        private VoilierEnCourse _voilier2;
        private Epreuve _epreuve1;
        private Epreuve _epreuve2;

        [SetUp]
        public void SetUp()
        {
            _course = new Course();
            _voilier1 = new VoilierEnCourse("code1", "codeInscription1");
            _voilier2 = new VoilierEnCourse("code2", "codeInscription2");
            _epreuve1 = new Epreuve (1, "Epreuve 1", 1, 1);
            _epreuve2 = new Epreuve (2, "Epreuve 2", 2, 1);
        }

        [Test]
        public void AjouterParticipant_ShouldAddParticipant()
        {
            bool result = _course.AjouterParticipant(_voilier1);
            Assert.IsTrue(result);
            Assert.Contains(_voilier1, _course.Participants);
        }

        [Test]
        public void AjouterParticipant_ShouldNotAddDuplicateParticipant()
        {
            _course.AjouterParticipant(_voilier1);
            bool result = _course.AjouterParticipant(_voilier1);
            Assert.IsFalse(result);
        }

        [Test]
        public void GetParticipant_ShouldReturnCorrectParticipant()
        {
            _course.AjouterParticipant(_voilier1);
            var participant = _course.GetParticipant(_voilier1.Code);
            Assert.That(participant, Is.EqualTo(_voilier1));
        }

        [Test]
        public void GetParticipants_ShouldReturnAllParticipants()
        {
            _course.AjouterParticipant(_voilier1);
            _course.AjouterParticipant(_voilier2);
            var participants = _course.GetParticipants();
            Assert.Contains(_voilier1, participants);
            Assert.Contains(_voilier2, participants);
        }

        [Test]
        public void SupprimerParticipant_ShouldRemoveParticipant()
        {
            _course.AjouterParticipant(_voilier1);
            bool result = _course.SupprimerParticipant(_voilier1.Code);
            Assert.IsTrue(result);
            Assert.IsFalse(_course.Participants.Contains(_voilier1));
        }

        [Test]
        public void SupprimerParticipant_ShouldReturnFalseIfParticipantNotExists()
        {
            bool result = _course.SupprimerParticipant("nonexistent_code");
            Assert.IsFalse(result);
        }

        [Test]
        public void AjouterEpreuve_ShouldAddEpreuve()
        {
            bool result = _course.AjouterEpreuve(_epreuve1);
            Assert.IsTrue(result);
            Assert.Contains(_epreuve1, _course.Epreuves);
        }

        [Test]
        public void AjouterEpreuve_ShouldNotAddDuplicateEpreuve()
        {
            _course.AjouterEpreuve(_epreuve1);
            bool result = _course.AjouterEpreuve(_epreuve1);
            Assert.IsFalse(result);
        }

        [Test]
        public void SupprimerEpreuve_ShouldRemoveEpreuve()
        {
            _course.AjouterEpreuve(_epreuve1);
            bool result = _course.SupprimerEpreuve(_epreuve1.Num);
            Assert.IsTrue(result);
            Assert.IsFalse(_course.Epreuves.Contains(_epreuve1));
        }

        [Test]
        public void SupprimerEpreuve_ShouldReturnFalseIfEpreuveNotExists()
        {
            bool result = _course.SupprimerEpreuve(999);
            Assert.IsFalse(result);
        }

        [Test]
        public void ToString_ShouldReturnCorrectFormat()
        {
            _course.AjouterParticipant(_voilier1);
            _course.AjouterEpreuve(_epreuve1);
            string details = _course.ToString();
            Assert.IsTrue(details.Contains("Course ID"));
            Assert.IsTrue(details.Contains("Participants:"));
            Assert.IsTrue(details.Contains(_voilier1.Code));
            Assert.IsTrue(details.Contains("Epreuves:"));
            Assert.IsTrue(details.Contains(_epreuve1.Libelle));
        }
    }
}
