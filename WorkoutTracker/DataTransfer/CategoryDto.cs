using System.Xml.Serialization;

namespace WorkoutTracker.DataTransfer
{
    [XmlType("CategoryDto")]
    public class CategoryDto : IBaseDto
    {
        [XmlElement("Id")]
        public  int Id { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }
    }
}
