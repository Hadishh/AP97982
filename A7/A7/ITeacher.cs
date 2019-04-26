namespace A7
{
    public interface ITeacher
    {
        // I think Name not needed because of ICitizen interface!
        string Name { get; }
        Degree TopDegree { get; set; }
        string ImgUrl { get; set; }
        string Teach();
    }
}