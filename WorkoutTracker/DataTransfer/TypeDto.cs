using System.Xml.Serialization;

namespace WorkoutTracker.DataTransfer
{
    [XmlType("Type")]
    public class TypeDto : IBaseDto
    {
        [XmlElement("Id")]
        public int Id { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Order")]
        public int Order { get; set; }

        [XmlElement("CategoryId")]
        public int CategoryId { get; set; }
    }
}
