using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SceletonTests
{
    public class HeroTests
    {
        private const int targetExperience = 5;
        private const int targetHealth = 5;
        private const int axeAttack = 10;
        private const int axeDurability = 10;

        [Test]
        public void HeroGainsXPFromTarget()
        {
            IWeapon axe = new Axe(axeAttack, axeDurability);

            ITarget dummy = new Dummy(targetHealth, targetExperience);

            Hero testHero = new Hero("SuperHero", axe);

            testHero.Attack(dummy);

            Assert.That(testHero.Experience, Is.EqualTo(targetExperience));
        }

        [Test]
        public void MockTest_HeroGainsXPFromTarget()
        {
            var target = new Mock<ITarget>();
            target.Setup(t => t.IsDead()).Returns(true);
            target.Setup(t => t.GiveExperience()).Returns(targetExperience);
            var weapon = new Mock<IWeapon>();
            Hero testHero = new Hero("SuperHero", weapon.Object);

            testHero.Attack(target.Object);

            Assert.That(testHero.Experience, Is.EqualTo(targetExperience));
        }


    }
}
