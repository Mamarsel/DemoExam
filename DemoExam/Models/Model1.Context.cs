﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DemoExam.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class user60Entities : DbContext
    {
        public user60Entities()
            : base("name=user60Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Activity> Activity { get; set; }
        public virtual DbSet<Activity_event> Activity_event { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Direction> Direction { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<Event_jury> Event_jury { get; set; }
        public virtual DbSet<Event_type_event> Event_type_event { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Type_event> Type_event { get; set; }
        public virtual DbSet<Uzer> Uzer { get; set; }
        public virtual DbSet<Uzer_role> Uzer_role { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    }
}