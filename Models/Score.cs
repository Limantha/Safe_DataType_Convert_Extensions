using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SafeExtensions.Models
{
    public class Score
    {
        public int UserId { get; set; }
        public int SubjectId { get; set; }
        public double? Marks { get; set; }
    }
}