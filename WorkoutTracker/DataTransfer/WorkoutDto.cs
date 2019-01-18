using System.Xml.Serialization;

namespace WorkoutTracker.DataTransfer
{
    [XmlType("WorkoutDto")]
    public class WorkoutDto : IBaseDto
    {
        [XmlElement("TypeId")]
        public int TypeId { get; set; }

        [XmlElement("CategoryId")]
        public int CategoryId { get; set; }

        [XmlElement("Count")]
        public int Count { get; set; }
    }
}
