using System;
using System.Collections.Generic;
using System.Text;

namespace HW_L3_01_OOP.Task4

{
    public class RoomFullException : Exception
    {
        public RoomFullException(string message) : base(message) { }
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

        public virtual void GetDetails()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}, National ID: {NationalId}");
        }
    }

    public class Patient : Person
    {
        public int PatientId { get; set; }
        public List<string> MedicalHistory { get; set; } = new List<string>();

        public Patient(string name, int age, string nationalId, int patientId)
            : base(name, age, nationalId)
        {
            PatientId = patientId;
        }

        public void AddToMedicalHistory(string record)
        {
            MedicalHistory.Add(record);
        }

        public override void GetDetails()
        {
            base.GetDetails();
            Console.WriteLine($"Patient ID: {PatientId}");
            Console.WriteLine("Medical History:");
            foreach (var record in MedicalHistory)
            {
                Console.WriteLine($"- {record}");
            }
        }
    }


    public class Doctor : Person
    {
        public int DoctorId { get; set; }
        public string Specialization { get; set; }

        public Doctor(string name, int age, string nationalId, int doctorId, string specialization)
            : base(name, age, nationalId)
        {
            DoctorId = doctorId;
            Specialization = specialization;
        }

        public void Diagnose(Patient patient, string diagnosis)
        {
            Console.WriteLine($"Doctor {Name} diagnosed Patient {patient.Name} with: {diagnosis}");
            patient.AddToMedicalHistory(diagnosis);
        }
    }

    public class Room
    {
        public int RoomNumber { get; set; }
        public int Capacity { get; set; }
        private List<Patient> patients = new List<Patient>();

        public Room(int roomNumber, int capacity)
        {
            RoomNumber = roomNumber;
            Capacity = capacity;
        }

        public void AssignPatient(Patient patient)
        {
            if (patients.Count >= Capacity)
                throw new RoomFullException($"Room {RoomNumber} is full!");
            patients.Add(patient);
            Console.WriteLine($"Patient {patient.Name} assigned to Room {RoomNumber}");
        }

        public void RemovePatient(Patient patient)
        {
            patients.Remove(patient);
            Console.WriteLine($"Patient {patient.Name} removed from Room {RoomNumber}");
        }

        public void ListPatients()
        {
            Console.WriteLine($"Room {RoomNumber} patients:");
            foreach (var p in patients)
            {
                Console.WriteLine($"- {p.Name}");
            }
        }
    }


    public class Hospital
    {
        private static Hospital instance;
        public List<Doctor> Doctors { get; set; } = new List<Doctor>();
        public List<Room> Rooms { get; set; } = new List<Room>();

        private Hospital() { }

        public static Hospital Instance
        {
            get
            {
                if (instance == null)
                    instance = new Hospital();
                return instance;
            }
        }

        public void AdmitPatient(Patient patient)
        {
            foreach (var room in Rooms)
            {
                try
                {
                    room.AssignPatient(patient);
                    Console.WriteLine($"Patient {patient.Name} admitted successfully!");
                    return;
                }
                catch (RoomFullException)
                {
                    continue;
                }
            }
            Console.WriteLine($"No available rooms for Patient {patient.Name}");
        }

        public void DischargePatient(Patient patient)
        {
            foreach (var room in Rooms)
            {
                room.RemovePatient(patient);
            }
            Console.WriteLine($"Patient {patient.Name} discharged.");
        }
    }


    public static class HospitalFactory
    {
        public static Patient CreatePatient(string name, int age, string nationalId, int patientId)
        {
            return new Patient(name, age, nationalId, patientId);
        }

        public static Doctor CreateDoctor(string name, int age, string nationalId, int doctorId, string specialization)
        {
            return new Doctor(name, age, nationalId, doctorId, specialization);
        }

        public static Room CreateRoom(int roomNumber, int capacity)
        {
            return new Room(roomNumber, capacity);
        }
    }
}
