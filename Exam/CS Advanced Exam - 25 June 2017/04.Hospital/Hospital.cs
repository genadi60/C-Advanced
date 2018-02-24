using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Hospital
{
    class Department
    {
        public const int RoomsCapacity = 20;

        public string Name { get; set; }
        public List<Room> Rooms { get; set; }
        public int RoomCounter { get; set; }

        public Department(string name)
        {
            Name = name;
            Rooms = new List<Room>();
            RoomCounter = 0;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var room in Rooms)
            {
                foreach (var patient in room.PatientListByRoom)
                {
                    sb.Append(patient).Append(Environment.NewLine);
                }
            }
            return sb.ToString().Trim();
        }
    }

    class Room
    {
        public const int patientsNumber = 3;

        public int Id { get; set; }
        public List<string> PatientListByRoom { get; set; }

        public int PatientCounter { get; set; }

        public Room(int id)
        {
            Id = id;
            PatientListByRoom = new List<string>();
            PatientCounter = 0;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            var sorted = PatientListByRoom
                .OrderBy(s => s)
                .ToList();
            foreach (var patient in sorted)
            {
                sb.Append(patient).Append(Environment.NewLine);
            }
            return sb.ToString().Trim();
        }
    }

    class Doctor
    {
        public string Name { get; set; }
        public List<string> PatientListByDoctor { get; set; }

        public Doctor(string name)
        {
            Name = name;
            PatientListByDoctor = new List<string>();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            var sorted = PatientListByDoctor
                .OrderBy(s => s)
                .ToList();
            foreach (var patient in sorted)
            {
                sb.Append(patient).Append(Environment.NewLine);
            }
            return sb.ToString().Trim();
        }
    }
    static void Main()
    {
        var departments = new Dictionary<string, Department>();
        var doctors = new Dictionary<string, Doctor>();
        var roomsCount = 20;
        var patientsCount = 3;

        while (true)
        {
            var input = Console.ReadLine();
            if ("Output".Equals(input))
            {
                break;
            }

            var hospitalInputData = input.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
            var departmentName = hospitalInputData[0];
            var doctorName = hospitalInputData[1] + " " + hospitalInputData[2];
            var patientName = hospitalInputData[3];

            if (!departments.ContainsKey(departmentName))
            {
                var dep = new Department(departmentName);
                var room = new Room(dep.RoomCounter + 1);
                room.PatientListByRoom.Add(patientName);
                room.PatientCounter++;
                dep.Rooms.Add(room);
                dep.RoomCounter++;
                departments[departmentName] = dep;
            }
            else
            {
                var department = departments[departmentName];
                var currentRoom = department.Rooms[department.Rooms.Count - 1];
                var index = currentRoom.PatientCounter;

                if (index < patientsCount)
                {
                    currentRoom.PatientListByRoom.Add(patientName);
                    currentRoom.PatientCounter++;
                }
                else if(department.RoomCounter < roomsCount)
                {
                    currentRoom = new Room(department.RoomCounter + 1);
                    currentRoom.PatientListByRoom.Add(patientName);
                    currentRoom.PatientCounter++;
                    department.Rooms.Add(currentRoom);
                    department.RoomCounter++;
                }
                
            }

            if (!doctors.ContainsKey(doctorName))
            {
                doctors[doctorName] = new Doctor(doctorName);
            }

            var doctor = doctors[doctorName];
            doctor.PatientListByDoctor.Add(patientName);
        }

        while (true)
        {
            var input = Console.ReadLine();
            if ("End".Equals(input))
            {
                break;
            }

            var outputData = input.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
            if (outputData.Length == 1)
            {
                var departmentName = outputData[0];
                var department = departments[departmentName];
                Console.WriteLine(department.ToString());
            }
            else
            {
                if (Char.IsDigit(outputData[1][0]))
                {
                    var department = departments[outputData[0]];
                    foreach (var room in department.Rooms)
                    {
                        if (room.Id == int.Parse(outputData[1]))
                        {
                            Console.WriteLine(room.ToString());
                            break;
                        }
                    }
                }
                else
                {
                    var doctor = doctors[outputData[0] + " " + outputData[1]];
                    Console.WriteLine(doctor.ToString());
                }
            }
        }
    }
}