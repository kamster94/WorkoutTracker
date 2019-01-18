using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace WorkoutTracker.DataTransfer
{
    [XmlType("DateDto")]
    public class DateDto : IBaseDto
    {
        [XmlElement("Date")]
        public DateTime Date { get; set; }

        public List<WorkoutDto> Workouts { get; set; }
    }
}
