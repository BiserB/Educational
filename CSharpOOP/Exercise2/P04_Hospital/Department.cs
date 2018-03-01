using System;
using System.Collections.Generic;
using System.Linq;

public class Department
{
    int patientCount = 0;

    public string Name { get; set; }
    public List<Room> Rooms { get; set; }
    

    public Department(string name)
    {
        this.Name = name;
        this.Rooms = new List<Room>();
        Rooms.Add(new Room(1));
    }
    
    public void AddPatient(Patient patient)
    {
        if (patientCount < 60)
        {            
            if (Rooms.Last().Patients.Count() < 3)
            {
                Rooms.Last().Patients.Add(patient);
            }
            else
            {
                int roomNumber = Rooms.Count + 1;
                Rooms.Add(new Room(roomNumber));
                Rooms.Last().Patients.Add(patient);
            }
            patientCount++;
        }
        
    }
    public void PrintAllPatients()
    {
        foreach (var room in Rooms)
        {
            foreach (var patient in room.Patients)
            {
                Console.WriteLine(patient.Name);
            }
        }
    }
    public void PrintRoom(int roomNumber)
    {
        var room = Rooms.FirstOrDefault(r => r.Number == roomNumber);
        if (room != null)
        {
            foreach (var patient in room.Patients.OrderBy(p => p.Name))
            {
                Console.WriteLine(patient.Name);
            }
        }        
    }
}
