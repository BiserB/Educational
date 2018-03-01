
using System.Collections.Generic;

public class Doctor
{       
    public string Fullname { get; set; }
    internal List<Patient> Patients { get; set; }

    public Doctor(string fullname)
    {        
        this.Fullname = fullname;
        this.Patients = new List<Patient>();
    }

    public void AddPatient(Patient patient)
    {
        Patients.Add(patient);        
    }    

}
