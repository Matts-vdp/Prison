﻿using Microsoft.EntityFrameworkCore;
using Prison.Models.Base;

namespace Prison.Data.Extensions;

public static class DbContextExtensions
{
    public static void AddAuditInfo(this DbContext ctx)
    {
        //request all changed entries
        var entries = ctx.ChangeTracker.Entries().Where(entry =>
            entry.Entity is BaseAuditableEntity && entry.State is EntityState.Added ||
            entry.State is EntityState.Modified);

        foreach (var entry in entries)
        {
            if (entry.State is EntityState.Added) ((BaseAuditableEntity)entry.Entity).Created = DateTime.UtcNow;
            ((BaseAuditableEntity)entry.Entity).Modified = DateTime.UtcNow;
        }
    }
}