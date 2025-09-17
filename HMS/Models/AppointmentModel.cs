namespace HMS.Models
{
    public class AppointmentModel
    {
        public int AppointmentID { get; set; }
        public int DoctorID { get; set; }
        public int PatientID { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public string AppointmentStatus { get; set; }
        public string Description { get; set; }
        public string SpecialRemarks { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public int UserID { get; set; }
        public decimal? TotalConsultedAmount { get; set; }
    }
}
