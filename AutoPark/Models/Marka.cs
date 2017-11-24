using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoPark.Models
{
    public class Marka
    {
        public int Id { get; set; }
        public string NameMarka { get; set; }
        public int? ModelId { get; set; } // может принимать значение null
        public Model Model { get; set; } // взаимосвязь
    }
}