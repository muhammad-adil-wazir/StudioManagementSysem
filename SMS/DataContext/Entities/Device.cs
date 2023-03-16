using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SMS.DataContext.Entities
{
    public class Device :  BaseEntity
    {
        public Device() { }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DeviceID { get; set; }
        public string DeviceName { get; set; }
        public string Display { get; set; }
        public string Recorder { get; set; }
        public string Media { get; set; }
        public string Video { get; set; }
        public string Audio { get; set; }
        public string Power { get; set; }
        public int Quantity { get; set; }

    }
}