﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntityFramework
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class WorkDayEntities : DbContext
    {
        public WorkDayEntities()
            : base("name=WorkDayEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TaAccountLeave> TaAccountLeaves { get; set; }
        public virtual DbSet<TaAttendance> TaAttendances { get; set; }
        public virtual DbSet<TaEmployee> TaEmployees { get; set; }
        public virtual DbSet<TaHolidayList> TaHolidayLists { get; set; }
        public virtual DbSet<TaLeave> TaLeaves { get; set; }
        public virtual DbSet<TaLogin> TaLogins { get; set; }
        public virtual DbSet<TaMail> TaMails { get; set; }
    
        public virtual ObjectResult<get_data_Result> get_data(Nullable<bool> action)
        {
            var actionParameter = action.HasValue ?
                new ObjectParameter("action", action) :
                new ObjectParameter("action", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<get_data_Result>("get_data", actionParameter);
        }
    }
}
