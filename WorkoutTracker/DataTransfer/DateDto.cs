using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace WorkoutTracker.DataTransfer
{
    [XmlType("WorkoutDate")]
    public class DateDto
    {
        [XmlElement("Date")]
        public DateTime Date { get; set; }

        public List<WorkoutDto> Workouts { get; set; }
    }
}
