using System;
using System.Collections.Generic;

namespace A7
{
    public class EduInstitute<TTeacher> where TTeacher : ITeacher, ICitizen
    {
        public string Title { get; }
        public Degree MinimumDegree { get; }

        public List<TTeacher> Teachers { get; set; }

        public EduInstitute(string title, Degree minimumDegree)
        {
            Teachers = new List<TTeacher>();
            MinimumDegree = minimumDegree;
            Title = title;
        }
        public bool Register(TTeacher teacher)
        {
            if(IsEligible(teacher))
            {
                Teachers.Add(teacher);
                return true;
            }
            return false;
        }

        public bool IsEligible(TTeacher teacher)
        {
            if (teacher.TopDegree > MinimumDegree)
                return true;
            return false;
        }
    }
}