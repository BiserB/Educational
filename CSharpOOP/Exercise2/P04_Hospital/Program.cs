using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static List<Department> departments = new List<Department>();
    public static List<Doctor> doctors = new List<Doctor>();

    static void Main()
    {
        DataInput();

        DataRequest();
    }

    public static void DataInput()
    {
        string command = "";
        while ((command = Console.ReadLine()) != "Output")
        {
            string[] data = command.Split();
            string depName = data[0];
            string doctorFirst = data[1];
            string doctorLast = data[2];
            string doctorName = doctorFirst + " " + doctorLast;
            string pacientName = data[3];
            var patient = new Patient(pacientName);

            Department department = departments.FirstOrDefault(d => d.Name == depName);
            if ( department == null)
            {
                department = new Department(depName);
                departments.Add(department);
            }
            department.AddPatient(patient);

            Doctor doctor = doctors.FirstOrDefault(d => d.Fullname == doctorName);
            if (doctor == null)
            {
                doctor = new Doctor(doctorName);
                doctors.Add(doctor);
            }
            doctor.AddPatient(patient);
            
        }
    }

    public static void DataRequest()
    {
        string command = "";
        while ((command = Console.ReadLine()) != "End")
        {
            string[] args = command.Split();

            if (args.Length == 1)
            {
                Department department = departments.FirstOrDefault(d => d.Name == args[0]);
                if (department != null)
                {
                    department.PrintAllPatients();
                }
                
            }
            else if (args.Length == 2 && int.TryParse(args[1], out int roomNumber))
            {
                Department department = departments.FirstOrDefault(d => d.Name == args[0]);
                if (department != null)
                {
                    department.PrintRoom(roomNumber);
                }                
            }
            else
            {
                string doctorName = args[0] + " " + args[1];
                Doctor doctor = doctors.FirstOrDefault(d => d.Fullname == doctorName );
                if (doctor != null)
                {
                    foreach (var patient in doctor.Patients.OrderBy(p => p.Name))
                    {
                        Console.WriteLine(patient.Name);
                    }
                }
                
            }
            
        }
    }
}
