using NUnit.Framework;
using CourseLibrary;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CourseLibrary.Tests
{
    [TestFixture]
    public class EpreuveTests
    {
        private Epreuve _epreuve;

        [SetUp]
        public void SetUp()
        {
            _epreuve = new Epreuve(1, "Libelle Test", 1, 1);
        }

        [Test]
        public void Constructor_ShouldInitializeProperties()
        {
            Assert.That(_epreuve.Num, Is.EqualTo(1));
            Assert.That(_epreuve.Libelle, Is.EqualTo("Libelle Test"));
            Assert.That(_epreuve.Ordre, Is.EqualTo(1));
            Assert.That(_epreuve.CourseId, Is.EqualTo(1));
        }

        [Test]
        public void ModifierEpreuve_ShouldModifyProperties()
        {
            _epreuve.ModifierEpreuve(2, "Libelle Modifié", 2, 2);

            Assert.That(_epreuve.Num, Is.EqualTo(2));
            Assert.That(_epreuve.Libelle, Is.EqualTo("Libelle Modifié"));
            Assert.That(_epreuve.Ordre, Is.EqualTo(2));
            Assert.That(_epreuve.CourseId, Is.EqualTo(2));
        }

        // [Test]
        // public void ChargerCourse_ShouldLoadCourse()
        // {
        //     // Arrange
        //     var options = new DbContextOptionsBuilder<ProjetVoilierContext>()
        //         .UseInMemoryDatabase(databaseName: "TestDatabase")
        //         .Options;

        //     using (var context = new ProjetVoilierContext(options))
        //     {
        //         var epreuve = new Epreuve(1, "Test Epreuve", 1, 1);
        //         var typePenalite = new TypePenalite(1, "Test Type Penalite", 1);
        //         var penalite = new Penalite(typePenalite, epreuve, 1, 20.0, 13.0);
        //         context.Epreuves.Add(epreuve);
                
        //         var course = new Course();
        //         course.Epreuves.Add(epreuve);
        //         context.Course.Add(course);
                
        //         context.SaveChanges();
        //     }

        //     using (var context = new ProjetVoilierContext(options))
        //     {
        //         _epreuve = new Epreuve(1, "Libelle Test", 1, 1);

        //         // Act
        //         var result = _epreuve.ChargerCourse();

        //         // Assert
        //         Assert.IsTrue(result);
        //         Assert.IsNotNull(_epreuve.Course);
        //         Assert.That(_epreuve.Course.Id, Is.EqualTo(1));
        //     }
        // }


        [Test]
        public void ChargerCourse_ShouldReturnFalseIfCourseNotFound()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ProjetVoilierContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new ProjetVoilierContext(options))
            {
                _epreuve = new Epreuve(1, "Libelle Test", 1, 999);

                // Act
                var result = _epreuve.ChargerCourse();

                // Assert
                Assert.IsFalse(result);
                Assert.IsNull(_epreuve.Course);
            }
        }

        [Test]
        public void ToString_ShouldReturnCorrectFormat()
        {
            var result = _epreuve.ToString();
            Assert.That(result, Is.EqualTo("Epreuve 1: Libelle Test"));
        }
    }

    public class ProjetVoilierContext : DbContext
    {
        public ProjetVoilierContext(DbContextOptions<ProjetVoilierContext> options) : base(options) { }

        public DbSet<Course> Course { get; set; }
        public DbSet<Epreuve> Epreuves { get; set; }
    }
}
