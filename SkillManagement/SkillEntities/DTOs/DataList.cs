using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillEntities.DTOs
{
    public class DataList<T> where T : class
    {
       public int TotalRecords { get; set; }
       public List<T> Records { get; set; }
    }
}
