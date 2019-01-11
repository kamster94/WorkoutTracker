using System;
using System.Collections.Generic;

namespace WorkoutTracker.DataTransfer
{
    public class DateDto
    {
        public DateTime Date { get; set; }

        public List<WorkoutDto> Workouts { get; set; }
    }
}
