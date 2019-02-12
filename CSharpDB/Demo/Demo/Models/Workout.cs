using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Models
{
    public class Workout
    {
        public int Id { get; set; }

        [Required]
        public DateTimeOffset Date { get; set; }

        public int DistanceInMeters { get; set; }

        [Required]
        public long TimeInSeconds { get; set; }

        [JsonIgnore]
        public string UserId { get; set; }
    }
}
