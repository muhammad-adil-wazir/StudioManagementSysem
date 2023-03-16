using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SMS.DataContext.Entities
{
    public class Shift : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ShiftID { get; set; }
        [StringLength(70)]
        public string ShiftName { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public TimeSpan BreakStartTime { get; set; }
        public TimeSpan BreakEndTime { get; set; }
        public TimeSpan TotalTime { get; set; }
        public TimeSpan TotalBreakHours { get; set; }
        public TimeSpan TotalWorkingHours { get; set; }

    }
}