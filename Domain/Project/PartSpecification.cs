﻿using HaSe.Data.Project;
using HaSe.Domain.Repos;

namespace HaSe.Domain.Project {
    public sealed class PartSpecification(PartSpecificationData? data) : Entity<PartSpecificationData>(data) {
        public override async Task LoadLazy() {
            await base.LoadLazy();
            SpecificationStatus ??= await GetFromRepo.Items<IPartSpecificationStatusRepo, PartSpecificationStatus>(nameof(PartSpecificationStatusData.PartSpecificationId), Id);
            SpecificationRole ??= await GetFromRepo.Items<IPartSpecificationRoleRepo, PartSpecificationRole>(nameof(PartSpecificationRoleData.PartSpecificationId), Id);
            Part ??= await GetFromRepo.Item<IPartsRepo, Part>(PartId);
        }
        public string Description => data.Description;
        public string Type => data.Type;
        public List<PartSpecificationStatus>? SpecificationStatus { get; private set; }
        public List<PartSpecificationRole>? SpecificationRole { get; private set; }
        public DateTime DateDocumented => data.DateDocumented;
        public string? Comment => data.Comment;
        public int PartId => data.PartId;
        public Part? Part { get; private set; }
    }
}
