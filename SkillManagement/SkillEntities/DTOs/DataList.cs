using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillEntities.DTOs
{
    public class DataList<T> where T : class
    {
        /// <summary>
        /// Store the total no of records in db
        /// </summary>
       public int TotalRecords { get; set; }
        public decimal TotalPages { get; set; }

        /// <summary>
        /// List of the recordes after filters
        /// </summary>
       public List<T> Records { get; set; }
    }
}
