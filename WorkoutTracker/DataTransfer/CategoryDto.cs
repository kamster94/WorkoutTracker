using System.Collections.Generic;
using System.Xml.Serialization;

namespace WorkoutTracker.DataTransfer
{
    [XmlType("Category")]
    public class CategoryDto : IBaseDto
    {
        [XmlElement("Id")]
        public  int Id { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }

        public List<TypeDto> Types { get; set; }
    }
}
