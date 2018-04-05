using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SceletonTests
{
    public class DummyTests
    {
        private const int initialHealth = 10;
        private const int initialExperience = 10;
        
        
        private Dummy CreateDummy()
        {
            return new Dummy(initialHealth, initialExperience);
        }

        [Test]
        public void DummyLosesHealthIfAttacked()
        {
            var dummy = CreateDummy();

            dummy.TakeAttack(1);

            Assert.That(dummy.Health, Is.EqualTo(9), "Dummy's health is not affected");
        }

        [Test]
        public void DeadDummyThrowsExceptionIfAttacked()
        {
            var dummy = CreateDummy();

            dummy.TakeAttack(10);

            Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(10));
        }

        [Test]
        public void DeadDummyCanGiveXP()
        {
            var dummy = CreateDummy();

            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
        }

        
    }
}
