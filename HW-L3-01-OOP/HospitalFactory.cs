using System;
using System.Collections.Generic;

namespace HW_L3_01_OOP.Task4
{
    public class HospitalFactory4
    {
        public static Doctor CreateDoctor(string name, int age, string nationalId, int doctorId, string specialization)
        {
            return new Doctor(name, age, nationalId, doctorId, specialization);
        }

        public static Patient CreatePatient(string name, int age, string nationalId, int patientId)
        {
            return new Patient(name, age, nationalId, patientId);
        }

        public static Room CreateRoom(int roomNumber, int capacity)
        {
            return new Room(roomNumber, capacity);
        }
    }
}
