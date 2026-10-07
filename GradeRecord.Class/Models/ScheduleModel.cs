using System;
using System.ComponentModel.DataAnnotations;

namespace GradeRecord.Class.Models
{
    public class ScheduleModel : IEntity
    {
        [Key]
        public int Id { get; set; }

        public int Id_Teacher_Subject { get; set; }
        public Teacher_Subject_Group_Model Teacher_Subject { get; set; } = null!;

        [Required]
        public string DayOfWeek { get; set; } = null!; // Ej: "Lunes", "Martes"

        [Required]
        public TimeSpan StartTime { get; set; } // Ej: 08:00:00

        [Required]
        public TimeSpan EndTime { get; set; }   // Ej: 10:00:00

        public string Classroom { get; set; } = null!; // Ej: "Aula 101"
    }
}