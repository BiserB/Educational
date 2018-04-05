using P07_InfernoInfinity.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P07_InfernoInfinity.Core
{
    public class Engine
    {
        private IRepository repo;
        private IWeaponFactory weaponFactory;
        private IGemFactory gemFactory;

        public Engine(IRepository repository, IWeaponFactory weaponFactory, IGemFactory gemFactory)
        {
            this.repo = repository;
            this.weaponFactory = weaponFactory;
            this.gemFactory = gemFactory;
        }

        public void Run()
        {
            while (true)
            {
                string input = Console.ReadLine();

                string[] data = input.Split(';');

                InterpretCommand(data);
            }
        }

        private void InterpretCommand(string[] data )
        {
            switch (data[0])
            {
                case "Create":
                    string[] args = data[1].Split();
                    string rarity = args[0];
                    string weaponType = args[1];
                    string weaponName = data[2];
                    var weapon = weaponFactory.Create(weaponType, weaponName, rarity);
                    if (weapon != null)
                    {
                        repo.AddWeapon(weapon, weaponName);
                    }                    
                    break;

                case "Add":
                    string[] gemArgs = data[3].Split();
                    string gemType = gemArgs[1];
                    string clarity = gemArgs[0];
                    var gem = gemFactory.Create(gemType, clarity);
                    string nameOfWeapon = data[1];
                    int index = int.Parse(data[2]);
                    if (gem != null)
                    {
                        repo.AddGem(nameOfWeapon, index, gem);
                    }                    
                    break;

                case "Remove":                    
                    string weapon_Name = data[1];
                    int gemIndex = int.Parse(data[2]);
                    repo.RemoveGem(weapon_Name, gemIndex);
                    break;

                case "Print":
                    string name = data[1];
                    Console.WriteLine(repo.Print(name));
                    break;

                case "END":                    
                    Environment.Exit(0);
                    break;
            }

        }
    }
}
