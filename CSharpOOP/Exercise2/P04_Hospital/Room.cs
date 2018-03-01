
using System.Collections.Generic;

public class Room
{
    public int Number { get; set; }
    public List<Patient> Patients { get; set; }

    public Room(int number)
    {
        this.Number = number;
        this.Patients = new List<Patient>();
    }
}