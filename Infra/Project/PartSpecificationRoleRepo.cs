﻿using HaSe.Data.Project;
using HaSe.Domain.Project;
using HaSe.Domain.Repos;
using HaSe.Infra.Common;

namespace HaSe.Infra.Project
{
    public class PartSpecificationRoleRepo(ProjectDbContext context) : Repo<PartSpecificationRole, PartSpecificationRoleData>(context, context.PartSpecificationRole), IPartSpecificationRoleRepo {
        protected override IQueryable<PartSpecificationRoleData> AddSearchString(IQueryable<PartSpecificationRoleData> sql)
        {
            return string.IsNullOrEmpty(SearchString) ? sql
                : sql.Where(s => s.PartyName != null
                    && (s.PartyName.Contains(SearchString)
                    || s.Type.Contains(SearchString)));
        }

        protected override PartSpecificationRole ToEntity(PartSpecificationRoleData? data) {
            return new PartSpecificationRole(data);
        }
    }
}