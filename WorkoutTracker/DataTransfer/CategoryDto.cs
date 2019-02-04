using System.Collections.Generic;
using System.Xml.Serialization;

namespace WorkoutTracker.DataTransfer
{
    [XmlType("Category")]
    public class CategoryDto
    {
        [XmlElement("Id")]
        public  int Id { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Order")]
        public int Order { get; set; }

        public List<TypeDto> Types { get; set; }
    }
}
