using HaSe.Data.Project;
using HaSe.Domain.Repos;

namespace HaSe.Domain.Project {
    public sealed class PartSpecification(PartSpecificationData? data) : Entity<PartSpecificationData>(data) {
        public override async Task LoadLazy() {
            await base.LoadLazy();
            SpecificationStatus ??= await GetFromRepo.Items<IPartSpecificationStatusRepo, PartSpecificationStatus>(nameof(PartSpecificationStatusData.PartSpecificationId), Id);
            //Enrollments ??= await GetFromRepo.Items<IEnrollmentsRepo, Enrollment>(nameof(EnrollmentData.CourseId), Id);
            //Assignments ??= await GetFromRepo.Items<IAssignmentsRepo, Assignment>(nameof(AssignmentData.CourseId), Id);
        }
        public string Description => data.Description;
        public string Type => data.Type;
        public List<PartSpecificationStatus>? SpecificationStatus { get; private set; }
        public DateTime DateDocumented => data.DateDocumented;
        public string? Comment => data.Comment;
        public int? PartId => data.PartId;
    }
}
