using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospitalDataBase.Core.Entities
{
    public class HistoryMedicalExam : BaseEntity
    {
        public int          TransactionID   { get; set; }
        public int          EmployeeID      { get; set; }                       //người nhận bệnh
        public int          DoctorID        { get; set; }                       //tên bác sĩ
        public int          PatientID       { get; set; }                       //mã số bệnh nhân
        public DateTime     DateTakeExam    { get; set; }                       //ngày khám bệnh
        public DateTime     DateReExam      { get; set; }                       //ngày tái khám
        public string       Diagnose        { get; set; } = string.Empty;       //chuẩn đoán
        public int          LineNumber      { get; set; }                       //bốc số

        public PatientTransactionHistory?   Transaction { get; set; }
        public Patient?                     Patient     { get; set; }
        public Doctor?                      Doctor      { get; set; }
        public Employee?                    Employee    { get; set; }

        public virtual ICollection<AnalysationTest>     AnalysationTests    { get; set; } = new HashSet<AnalysationTest>();
    }
}
