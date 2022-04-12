using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospitalDataBase.Core.Entities
{
    public class HistoryMedicalExam : BaseEntity
    {
        public string       PatientID       { get; set; } = string.Empty;       //mã số bệnh nhân
        public DateTime     DateTakeExam    { get; set; }                       //ngày khám bệnh
        public DateTime     DateReExam      { get; set; }                       //ngày tái khám
        public string       EmployeeID      { get; set; } = string.Empty;       //người nhận bệnh
        public string       DoctorID        { get; set; } = string.Empty;       //tên bác sĩ
        public string       Diagnose        { get; set; } = string.Empty;       //chuẩn đoán
        public int          LineID          { get; set; }                       //bốc số

        public Patient?         Patient     { get; set; }
        public Doctor?      Doctor      { get; set; }
        public Employee?    Employee    { get; set; }
        public virtual ICollection<AnalysationTest>             AnalysationTests    { get; set; } = new HashSet<AnalysationTest>();
        public virtual ICollection<PatientTransactionHistory>   Transactions        { get; set; } = new HashSet<PatientTransactionHistory>();
    }
}
