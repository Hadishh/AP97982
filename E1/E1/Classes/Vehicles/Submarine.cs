using E1.Interfaces;

namespace E1.Classes.Vehicles
{
    public class Submarine : ISwimable
    {
        public string Model { get; }
        public double MaxDepthSupported { get; }
        public double SpeedRate { get; set; }

        public Submarine(string model, double maxDepthSupported, double speedRate)
        {
            Model = model;
            MaxDepthSupported = maxDepthSupported;
            SpeedRate = speedRate;
        }

        public string Swim()
        {
            string output = Model + " is a Submarine and is swimming in " + 
                MaxDepthSupported + " meter depth";
            return output;
        }
    }
}