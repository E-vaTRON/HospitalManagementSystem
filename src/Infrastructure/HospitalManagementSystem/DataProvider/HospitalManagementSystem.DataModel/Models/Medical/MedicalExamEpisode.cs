﻿namespace HospitalManagementSystem.DataProvider;

public class MedicalExamEpisode : ModelBase
{
    public DateTime     DateTakeExam    { get; set; }       //ngày khám bệnh ?????
    public int          LineNumber      { get; set; }       //bốc số ?????
    public DateTime     RecordDay       { get; set; }       //ngày ghi sổ ?????
    public int          TotalPrice      { get; set; }       //thành tiền

    public Guid?                MedicalExamId       { get; set; }
    public MedicalExam          MedicalExam         { get; set; } = default!;

    public ReExamAppointment?   ReExamAppointment   { get; set; } // MedicalExamEpisode is Principal Table
    public Bill?                Bill                { get; set; } // MedicalExamEpisode is Principal Table

    public virtual ICollection<AssignmentHistory>       AssignmentHistories { get; set; } = new HashSet<AssignmentHistory>();
    public virtual ICollection<Diagnosis>               Diagnoses           { get; set; } = new HashSet<Diagnosis>();
    public virtual ICollection<RoomAllocation>          RoomAllocations     { get; set; } = new HashSet<RoomAllocation>();
    public virtual ICollection<DrugPrescription>        DrugPrescriptions   { get; set; } = new HashSet<DrugPrescription>();
    public virtual ICollection<AnalysisTest>            AnalysisTests       { get; set; } = new HashSet<AnalysisTest>();
    public virtual ICollection<ServiceEpisode>          ServiceEpisodes     { get; set; } = new HashSet<ServiceEpisode>();
}