using System;
using System.Collections.Generic;

public class RoomFullException : Exception
{
    public RoomFullException(string message) : base(message) { }
}

public interface IDiagnosisStrategy
{
    string GenerateDiagnosis(string patientName);
}

public class GeneralMedicineStrategy : IDiagnosisStrategy
{
    public string GenerateDiagnosis(string patientName) => $"General checkup completed for {patientName}. Prescribed rest.";
}

public class CardiologyStrategy : IDiagnosisStrategy
{
    public string GenerateDiagnosis(string patientName) => $"Cardiology exam completed for {patientName}. ECG shows normal rhythm.";
}

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string NationalId { get; set; }

    public Person(string name, int age, string nationalId)
    {
        Name = name;
        Age = age;
        NationalId = nationalId;
    }

    public virtual string GetDetails() => $"Name: {Name}, Age: {Age}, National ID: {NationalId}";
}

public class Patient : Person
{
    public string PatientId { get; set; }
    public List<string> MedicalHistory { get; set; } = new List<string>();

    public Patient(string name, int age, string nationalId, string patientId) : base(name, age, nationalId)
    {
        PatientId = patientId;
    }

    public void AddToMedicalHistory(string illness) => MedicalHistory.Add(illness);

    public override string GetDetails() => $"{base.GetDetails()}, Patient ID: {PatientId}, History: {string.Join(", ", MedicalHistory)}";
}

public class Doctor : Person
{
    public string DoctorId { get; set; }
    public string Specialization { get; set; }
    private IDiagnosisStrategy _diagnosisStrategy;

    public Doctor(string name, int age, string nationalId, string doctorId, string specialization, IDiagnosisStrategy strategy) : base(name, age, nationalId)
    {
        DoctorId = doctorId;
        Specialization = specialization;
        _diagnosisStrategy = strategy;
    }

    public void Diagnose(Patient patient)
    {
        string result = _diagnosisStrategy.GenerateDiagnosis(patient.Name);
        patient.AddToMedicalHistory(result);
    }

    public override string GetDetails() => $"{base.GetDetails()}, Doctor ID: {DoctorId}, Specialization: {Specialization}";
}

public class Room
{
    public int RoomNumber { get; set; }
    public int Capacity { get; set; }
    public List<Patient> Patients { get; set; } = new List<Patient>();

    public Room(int roomNumber, int capacity)
    {
        RoomNumber = roomNumber;
        Capacity = capacity;
    }

    public void AssignPatient(Patient patient)
    {
        if (Patients.Count >= Capacity)
            throw new RoomFullException($"Room {RoomNumber} is full.");
        Patients.Add(patient);
    }
}

public class Hospital
{
    private static Hospital _instance;
    private static readonly object _lock = new object();

    public List<Doctor> Doctors { get; set; } = new List<Doctor>();
    public List<Room> Rooms { get; set; } = new List<Room>();

    private Hospital() { }

    public static Hospital Instance
    {
        get
        {
            lock (_lock)
            {
                if (_instance == null) _instance = new Hospital();
                return _instance;
            }
        }
    }

    public void AdmitPatient(Patient patient)
    {
        foreach (var room in Rooms)
        {
            try
            {
                room.AssignPatient(patient);
                Console.WriteLine($"Patient {patient.Name} admitted to Room {room.RoomNumber}.");
                return;
            }
            catch (RoomFullException) { }
        }
        Console.WriteLine($"Could not admit {patient.Name}: No available capacity in any room.");
    }

    public void DischargePatient(Patient patient)
    {
        foreach (var room in Rooms)
        {
            if (room.Patients.Remove(patient))
            {
                Console.WriteLine($"Patient {patient.Name} discharged from Room {room.RoomNumber}.");
                return;
            }
        }
    }
}

public static class PersonFactory
{
    public static Person CreatePerson(string type, string name, int age, string nationalId, string specificId, string extraParam = "", IDiagnosisStrategy strategy = null)
    {
        if (type.Equals("Patient", StringComparison.OrdinalIgnoreCase))
            return new Patient(name, age, nationalId, specificId);
        if (type.Equals("Doctor", StringComparison.OrdinalIgnoreCase))
            return new Doctor(name, age, nationalId, specificId, extraParam, strategy);
        throw new ArgumentException("Invalid person type.");
    }
}

class Program
{
    static void Main()
    {
        Hospital hospital = Hospital.Instance;
        hospital.Rooms.Add(new Room(101, 1));
        hospital.Rooms.Add(new Room(102, 2));

        Patient p1 = (Patient)PersonFactory.CreatePerson("Patient", "John Doe", 30, "111", "PT01");
        Patient p2 = (Patient)PersonFactory.CreatePerson("Patient", "Jane Doe", 25, "222", "PT02");

        Doctor doc = (Doctor)PersonFactory.CreatePerson("Doctor", "Dr. Adams", 50, "333", "DOC01", "Cardiology", new CardiologyStrategy());
        hospital.Doctors.Add(doc);

        doc.Diagnose(p1);

        hospital.AdmitPatient(p1);
        hospital.AdmitPatient(p2);

        hospital.DischargePatient(p1);
    }
}