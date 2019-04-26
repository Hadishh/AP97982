namespace A7
{
    public class Khalle : ICitizen, ITeacher
    {
        public string Name { get; }
        public string NationalId { get; }
        public Degree TopDegree { get; set; }
        public string ImgUrl { get; set; }
        public string Teach() => "Khalle " + Name + " is teaching";
        public Khalle(string nationalID, string name, string imgUrl, Degree topDegree)
        {
            Name = name;
            NationalId = nationalID;
            ImgUrl = imgUrl;
            TopDegree = topDegree;
        }
    }
}