﻿using HaSe.Data.Project;
using HaSe.Domain.Project;
using HaSe.Domain.Repos;
using HaSe.Infra.Common;

namespace HaSe.Infra.Project
{
    public class PartSpecificationsRepo(ContosoDbContext context) : Repo<PartSpecification,PartSpecificationData>(context, context.PartSpecification), IPartSpecificationsRepo
    {
        protected override IQueryable<PartSpecificationData> AddSearchString(IQueryable<PartSpecificationData> sql)
        {
            return string.IsNullOrEmpty(SearchString) ? sql
                : sql.Where(s => s.Description != null
                                 && (s.Description.Contains(SearchString)
                                     || s.Type.Contains(SearchString)
                                     || s.DateDocumented.ToString().Contains(SearchString))
                                     || s.Comment.Contains(SearchString)
                                     || s.PartId.ToString().Contains(SearchString));
        }

        protected override PartSpecification ToEntity(PartSpecificationData? data) {
            return new PartSpecification(data);
        }
    }
}