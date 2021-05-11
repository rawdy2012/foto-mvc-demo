using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InLineEditingDemo.Models
{
    public class PublicationType
    {
        public int ID { get; set; }
        public string PUB_TYPE { get; set; }
        public string PUB_NAME { get; set; }
        public decimal SIZE { get; set; }
        public decimal RATE { get; set; }

        public List<PublicationType> usersinfo { get; set; }
    }
}