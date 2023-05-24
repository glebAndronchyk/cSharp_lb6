using System;

namespace LB6
{
    public struct Service: IComparable<Service>
    {
        public string serviceDate;
        public string carModel;
        public string releaseDate;
        public string taskName;

        public Service(string data)
        {
            string[] serviceData = data.Split(' ');
            
            if (serviceData.Length > 9 || serviceData.Length == 0)
            {
                throw new Exception("Incorrect data format");
            }

            serviceDate = serviceData[0];
            carModel = serviceData[1];
            releaseDate = serviceData[2];
            taskName = serviceData[3];
        }

        public int CompareTo(Service other)
        {
            return taskName.CompareTo(other.taskName);
        }

        public override string ToString()
        {
            return $"{serviceDate}\n{carModel}\n{releaseDate}\n{taskName}\n------\n";
        }
    }
}