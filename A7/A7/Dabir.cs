namespace A7
{
    public class Dabir : ICitizen, ITeacher
    {
        public string Name { get; }
        public string NationalId { get; }
        public Degree TopDegree { get; set; }
        public string ImgUrl { get; set; }
        public string Teach() => "Dabir " + Name + " is teaching";
        public int Under100StudentCount { get; }
        public Dabir(string nationalId, string name, string imgUrl, Degree topDegree, int under100StudentsCount)
        {
            NationalId = nationalId;
            Name = name;
            ImgUrl = imgUrl;
            TopDegree = topDegree;
            Under100StudentCount = under100StudentsCount;
        }
    }
}