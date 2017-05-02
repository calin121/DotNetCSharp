using System;
using System.ComponentModel.DataAnnotations;

namespace RESTauranter.Models {
       public class Reviews {
        [KeyAttribute]
        public int id { get; set; }

        public string name { get; set; }

        public string restaurant_name { get; set; }

        public string review { get; set; }

        public DateTime visit_date { get; set; }

        public int stars { get; set; }
        public string helpfull { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public Reviews() {
            created_at = DateTime.Now;
            updated_at = DateTime.Now;
            helpfull = null;
        }
    }
}