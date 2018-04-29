// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to your project (entities/controllers/etc)

namespace FestivalManager.Tests
{
    using FestivalManager.Core.Controllers;
    using FestivalManager.Entities;
    using FestivalManager.Entities.Contracts;
    using FestivalManager.Entities.Instruments;
    using FestivalManager.Entities.Sets;
    using NUnit.Framework;
    using System;

    [TestFixture]
	public class SetControllerTests
    {
		[Test]
	    public void TestRegisterSet()
	    {
            ISet shortSet = new Short("shortSet");

            IStage testStage = new Stage();

            testStage.AddSet(shortSet);

            SetController testController = new SetController(testStage);

           string result =  testController.PerformSets();

            Assert.That(result, Is.EqualTo("1. shortSet:\r\n-- Did not perform"));

		}

        [Test]
        public void TestRegisterSetWithSongs()
        {
            IPerformer performer = new Performer("Pesho", 20);

            IInstrument instrument = new AKG();

            performer.AddInstrument(instrument);

            TimeSpan span = new TimeSpan(0, 0, 5, 5, 0);

            ISong song = new Song("AAA", span );

            ISet shortSet = new Short("shortSet");

            shortSet.AddSong(song);
            shortSet.AddPerformer(performer);


            IStage testStage = new Stage();

            testStage.AddSet(shortSet);

            SetController testController = new SetController(testStage);

            string result = testController.PerformSets();

            Assert.That(result, Is.EqualTo("1. shortSet:\r\n-- 1. AAA (05:05)\r\n-- Set Successful"));

        }

    }
}