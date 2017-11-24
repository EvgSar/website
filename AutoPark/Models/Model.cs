using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoPark.Models
{
    public class Model
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Year { get; set; }
        public ICollection<Marka> Marks { get; set; }
        public Model()
        {
            Marks = new List<Marka>();
        }
    }
}