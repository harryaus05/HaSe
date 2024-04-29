﻿using HaSe.Data.Project;
using HaSe.Domain.Project;
using HaSe.Domain.Repos;
using HaSe.Infra.Common;

namespace HaSe.Infra.Project
{
    public class PartsRepo(ProjectDbContext context) : Repo<Part, PartData>(context, context.Parts), IPartsRepo
    {
        protected override IQueryable<PartData> AddSearchString(IQueryable<PartData> sql)
        {
            return string.IsNullOrEmpty(SearchString) ? sql
                : sql.Where(s => s.Name != null
                    && (s.Name.Contains(SearchString)
                    || s.Type.Contains(SearchString)));
        }

        protected override Part ToEntity(PartData? data) {
            return new Part(data);
        }
    }
}
