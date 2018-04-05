using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace SteemAPI
{
    public class SteemdCommand
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ArrayList Parameter { get; set; }
        public SteemdCommand(int id, string name, string description, ArrayList parameter)
        {
            ID = id;
            Name = name;
            Description = description;
            Parameter = parameter;
        }
    }
}
