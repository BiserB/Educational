using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Reflection;

public class MinedraftTests
{
    private IEnergyRepository energyRepository;
    private IProviderController providerController;

    [SetUp]
    public void SetupProviderController()
    {
        IEnergyRepository energyRepository = new EnergyRepository();
        IProviderController providerController = new ProviderController(energyRepository);
    }

    [Test]
    public void ProviderControllerTest()
    {
        List<string> data1 = new List<string> { "Pressure", "40", "100" };
        List<string> data2 = new List<string> { "Solar", "80", "100" };

        this.providerController.Register(data1);
        this.providerController.Register(data2);

        this.providerController.Produce();
        this.providerController.Produce();
        this.providerController.Produce();

        double producedEnergy = this.providerController.TotalEnergyProduced;

        Assert.That(producedEnergy, Is.EqualTo(360));
    }
}
