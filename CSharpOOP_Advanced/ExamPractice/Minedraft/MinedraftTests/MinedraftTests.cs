using NUnit.Framework;
using System;
using System.Collections.Generic;

[TestFixture]
public class ProviderControllerTests
{
    private IProviderController providerController;
    private IEnergyRepository energyRepository;

    [SetUp]
    public void TestInit()
    {
        this.energyRepository = new EnergyRepository();
        this.providerController = new ProviderController(this.energyRepository);
    }

    [Test]
    public void RegisterWithCorrectInput()
    {
        // Act
        this.providerController.Register(new List<string> { "Pressure", "40", "100" });
        var providersCount = this.providerController.Entities.Count;

        // Assert

        Assert.AreEqual(1, providersCount, "Count of registered providers is not corect!");
    }

    [Test]
    public void ProduceWithValidProviders()
    {
        // Arrange
        this.providerController.Register(new List<string> { "Pressure", "40", "100" });
        this.providerController.Register(new List<string> { "Solar", "80", "100" });

        // Act
        this.providerController.Produce();
        var energyProduced = this.providerController.TotalEnergyProduced;

        // Assert
        Assert.AreEqual(300, energyProduced, "Total Energy Produced is not corect!");
    }

    [Test]
    public void ProduceRemoveBrokenProviders()
    {
        this.providerController.Register(new List<string> { "Pressure", "10", "100" });
        this.providerController.Register(new List<string> { "Solar", "10", "100" });
        this.providerController.Register(new List<string> { "Standart", "10", "100" });

        for (int i = 0; i <= 10; i++)
        {
            this.providerController.Produce();
        }

        int expectedCount = 1;
        int actualCount = this.providerController.Entities.Count;

        Assert.AreEqual(expectedCount, actualCount, "Prividers count is not correct!");
    }
}



//using NUnit.Framework;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;

//public class MinedraftTests
//{
//    private IEnergyRepository repository;
//    private IProviderController provider;

//    [SetUp]
//    public void InitProvider()
//    {
//        this.repository = new EnergyRepository();
//        this.provider = new ProviderController(repository);
//    }

//    [Test]
//    public void CreateAndProduceProvider()
//    {
//        string[] data = new string[] { "Pressure", "50", "100" };
//        string[] data2 = new string[] { "Solar", "100", "80" };

//        this.provider.Register(data);
//        this.provider.Register(data2);

//        this.provider.Produce();
//        this.provider.Produce();

//        double energyProduced = repository.EnergyStored;

//        Assert.That(energyProduced, Is.EqualTo(560));
//    }

//    [Test]
//    public void DecreaseDurabilityProviders()
//    {
//        string[] data = new string[] { "Solar", "100", "80" };

//        this.provider.Register(data);

//        this.provider.Produce();

//        FieldInfo[] providersFields = this.provider.GetType()
//                                        .GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

//        FieldInfo providerField = providersFields.First(f => f.FieldType == typeof(List<IProvider>));

//        List<IProvider> providerFieldValue = (List<IProvider>)providerField.GetValue(this.provider);

//        Provider selected = (Provider)providerFieldValue.First();

//        Assert.That(selected.Durability, Is.EqualTo(1400));
//    }

//    [Test]
//    public void RepairProvider()
//    {
//        string[] data = new string[] { "Solar", "100", "80" };

//        this.provider.Register(data);

//        for (int i = 0; i < 5; i++)
//        {
//            this.provider.Produce();
//        }

//        provider.Repair(300);

//        double providerDurability = this.provider.Entities.First().Durability;

//        Assert.That(providerDurability, Is.EqualTo(1300));
//    }

//}
