using System.Xml.Serialization;

namespace WorkoutTracker.DataTransfer
{
    [XmlType("Workout")]
    public class WorkoutDto
    {
        [XmlElement("TypeId")]
        public int TypeId { get; set; }

        [XmlElement("CategoryId")]
        public int CategoryId { get; set; }

        [XmlElement("TypeOrder")]
        public int TypeOrder { get; set; }

        [XmlElement("CategoryOrder")]
        public int CategoryOrder { get; set; }

        [XmlElement("Count")]
        public int Count { get; set; }
    }
}
