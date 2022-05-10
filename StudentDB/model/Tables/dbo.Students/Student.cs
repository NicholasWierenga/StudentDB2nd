using System;
using System.Collections.Generic;

namespace StudentDB.model.Tables.dbo.Students
{
    public partial class Student
    {
        public int StudentId { get; set; }
        public string? Name { get; set; }
        public string? Hometown { get; set; }
        public string? FavFood { get; set; }
    }
}
