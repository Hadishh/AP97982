namespace A7
{
    public interface ITeacher
    {
        string Name { get; }
        Degree TopDegree { get; set; }
        string ImgUrl { get; set; }
        string Teach();
    }
}