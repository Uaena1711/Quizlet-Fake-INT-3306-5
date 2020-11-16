using System;
using System.Collections.Generic;
using System.Text;

namespace Quizlet_Fake.Courses
{
    public class FilterCourseDto
    {
        #region constructor
        public FilterCourseDto()
        {
            Sortby = sortby.a_z;
            Price = price.lowTohigh;

        }
        #endregion

        public sortby Sortby { get; set; }

        public price Price { get; set; }

    }
}

public enum sortby
{
    a_z,
    z_a
}

public enum price
{
    lowTohigh,
    highTolow
} 


