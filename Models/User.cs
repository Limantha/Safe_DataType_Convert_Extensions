using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SafeExtensions.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public int? NoOfSubjects { get; set; }
        public ICollection<Score> Scores { get; set; }
        public double Average {
            get
            {
                var avg = Scores.Sum(m => m.Marks) / NoOfSubjects;
                return (double)avg;
            }
        }

    }
}