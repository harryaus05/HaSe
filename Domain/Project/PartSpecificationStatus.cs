using HaSe.Data.Project;
using HaSe.Domain.Repos;

namespace HaSe.Domain.Project {
    public sealed class PartSpecificationStatus(PartSpecificationStatusData? data) : Entity<PartSpecificationStatusData>(data) {

        //public override async Task LoadLazy() {
        //    await base.LoadLazy();
        //     ??= await GetFromRepo.Item<IPartsRepo, Part>(PartId);
        //    Enrollments ??= await GetFromRepo.Items<IEnrollmentsRepo, Enrollment>(nameof(EnrollmentData.CourseId), Id);
        //    Assignments ??= await GetFromRepo.Items<IAssignmentsRepo, Assignment>(nameof(AssignmentData.CourseId), Id);
        //}
        public DateTime FromDate => data.FromDate;
        public DateTime ThruDate => data.ThruDate;
        public string Type => data.Type;
    }
}
