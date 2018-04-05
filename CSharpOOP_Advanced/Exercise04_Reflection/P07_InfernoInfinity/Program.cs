using P07_InfernoInfinity.Contracts;
using P07_InfernoInfinity.Core;
using P07_InfernoInfinity.Core.Factories;
using P07_InfernoInfinity.Data;
using System;

namespace P07_InfernoInfinity
{
    public class Program
    {
        static void Main()
        {
            IRepository repository = new WeaponRepository();
            IWeaponFactory weaponFactory = new WeaponFactory();
            IGemFactory gemFactory = new GemFactory();

            Engine engine = new Engine(repository, weaponFactory, gemFactory);

            engine.Run();
        }
    }
}
