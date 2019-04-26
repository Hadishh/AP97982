namespace A7
{
    public interface ICitizen
    {
        //Name and ID can't change outside the class
        string Name { get; }
        string NationalID { get; }
    }
}