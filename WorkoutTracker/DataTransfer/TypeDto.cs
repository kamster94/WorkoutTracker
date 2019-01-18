using System.Xml.Serialization;

namespace WorkoutTracker.DataTransfer
{
    [XmlType("TypeDto")]
    public class TypeDto : IBaseDto
    {
        [XmlElement("Id")]
        public int Id { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }

        public CategoryDto Category { get; set; }
    }
}
