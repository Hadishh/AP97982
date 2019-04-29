using E1.Enums;

namespace E1.Interfaces
{
    public interface IAnimal
    {
        string Name { get; }
        int Age { get; }
        double Health { get; set; }
        string EatFood();
        string Reproduction(IAnimal animal);
        string Move(Environment moveType);
    }
}