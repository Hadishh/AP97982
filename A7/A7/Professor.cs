namespace A7
{
    public class Professor : ICitizen , ITeacher
    {
        public string Name { get; }
        public string NationalId { get; }
        public Degree TopDegree { get; set; }
        public string ImgUrl { get; set; }
        public string Teach() => "Professor " + Name + " is teaching";
        public int ResearchCount { get; set; }
        public Professor(string nationalId, string name , string imgUrl, Degree topDegree, int researchCount)
        {
            NationalId = nationalId;
            Name = name;
            ImgUrl = imgUrl;
            TopDegree = topDegree;
            ResearchCount = researchCount;
        }
    }
}