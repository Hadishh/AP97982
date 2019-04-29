using E1.Interfaces;

namespace E1.Classes.Vehicles
{
    public class Airplane : IFlyable
    {
        public string Model { get; }
        public double SpeedRate { get; set; }

        public string Fly()
        {
            string output = Model + " with " + SpeedRate + " speed rate is flying";
            return output;
        }
        public Airplane(double speedRate, string model)
        {
            SpeedRate = speedRate;
            Model = model;
        }

    }
}