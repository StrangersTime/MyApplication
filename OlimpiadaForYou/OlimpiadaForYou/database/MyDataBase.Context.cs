﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OlimpiadaForYou.database
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class user91_dbEntities1 : DbContext
    {
        public user91_dbEntities1()
            : base("name=user91_dbEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Olimp_Class> Olimp_Class { get; set; }
        public virtual DbSet<Olimp_Difficulty> Olimp_Difficulty { get; set; }
        public virtual DbSet<Olimp_Olimp> Olimp_Olimp { get; set; }
        public virtual DbSet<Olimp_Registration> Olimp_Registration { get; set; }
        public virtual DbSet<Olimp_Role> Olimp_Role { get; set; }
        public virtual DbSet<Olimp_Subject> Olimp_Subject { get; set; }
        public virtual DbSet<Olimp_Users> Olimp_Users { get; set; }
    }
}
