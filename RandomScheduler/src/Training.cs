using RandomScheduler.src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RandomScheduler.src
    {
    [Serializable]
    [XmlRoot(IsNullable = false)]
    public class Training
        {
        [XmlAttribute("ID")]
        public int ID;
        [XmlElementAttribute("Name")]
        public string Name;
        [XmlElementAttribute("TrainingDuration")]
        public string TrainingDuration;

        public Training() { }

        public Training(int ID, string Name, string TrainingDuration)
            {
            this.ID = ID;
            this.Name = Name;
            this.TrainingDuration = TrainingDuration;
            }
        }
    }

