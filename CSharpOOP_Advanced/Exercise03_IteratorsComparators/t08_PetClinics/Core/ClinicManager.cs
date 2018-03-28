
using System;
using System.Collections.Generic;
using System.Linq;

public class ClinicManager
{
    private PetFactory petFactory;
    private ClinicFactory clinicFactory;
    private HashSet<Pet> pets;
    private HashSet<Clinic> clinics;

    public ClinicManager()
    {
        petFactory = new PetFactory();
        clinicFactory = new ClinicFactory();
        pets = new HashSet<Pet>();
        clinics = new HashSet<Clinic>();
    }

    public void CreatePet(string[] args)
    {
        string name = args[2];
        int age = int.Parse(args[3]);
        string kind = args[4];
        Pet pet = petFactory.Create(name, age, kind);
        pets.Add(pet);
    }

    public void CreateClinic(string[] args)
    {
        string clinicName = args[2];
        int rooms = int.Parse(args[3]);
        Clinic clinic = clinicFactory.Create(clinicName, rooms);
        clinics.Add(clinic);
    }

    public bool AddPet(string[] args)
    {
        string petsName = args[1];

        Pet pet = pets.FirstOrDefault(p => p.Name == petsName);

        if (pet == null)
        {
            throw new InvalidOperationException("Invalid pet or clinic");
        }

        string clinicName = args[2];

        Clinic clinic = FindClinic(clinicName);        

        return clinic.Accommodate(pet);
    }

    public bool Release(string[] args)
    {
        string clinicName = args[1];

        Clinic clinic = FindClinic(clinicName);

        return clinic.ReleasePet();
    }

    public bool HasEmptyRooms(string[] args)
    {
        string clinicName = args[1];

        Clinic clinic = FindClinic(clinicName);

        return clinic.HasEmptyRooms();
    }

    public string Print(params string[] args)
    {
        string clinicName = args[1];

        Clinic clinic = FindClinic(clinicName);

        if (args.Length == 3)
        {
            int roomNumber = int.Parse(args[2]);

            return clinic.PrintRoom(roomNumber);
        }

        return clinic.PrintAll();
    }

    public Clinic FindClinic(string clinicName)
    {
        Clinic clinic = clinics.FirstOrDefault(c => c.Name == clinicName);

        if (clinic == null)
        {
            throw new InvalidOperationException("Invalid clinic");
        }

        return clinic;
    }
}
