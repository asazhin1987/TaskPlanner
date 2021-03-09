﻿using Microsoft.EntityFrameworkCore;
using TaskPlanner.DAL.Entities;


namespace TaskPlanner.DAL.EF
{
	public class TaskPlannerContext : DbContext
	{
		//Sys
		public virtual DbSet<User> Users { get; set; }
		public virtual DbSet<Hour> Hours { get; set; }
		public virtual DbSet<Minute> Minutes { get; set; }
		//Users
		public virtual DbSet<Project> Projects { get; set; }
		public virtual DbSet<TypicalAssignment> TypicalAssignments { get; set; }
		public virtual DbSet<Assignment> Assignments { get; set; }
		public virtual DbSet<WTF> WTFs { get; set; }

		public TaskPlannerContext(DbContextOptions<TaskPlannerContext> options)
			: base(options)
		{
			Database.EnsureCreated();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Project>()
			   .HasMany(c => c.TypicalAssignments)
			   .WithMany(s => s.Projects)
			   .UsingEntity(j => j.ToTable("ProjectsTypicalAssignments"));
			int i = 0;
			modelBuilder.Entity<Hour>().HasData(new Hour { Id = ++i, Value = 0 });
			modelBuilder.Entity<Hour>().HasData(new Hour { Id = ++i, Value = 1 });
			modelBuilder.Entity<Hour>().HasData(new Hour { Id = ++i, Value = 2 });
			modelBuilder.Entity<Hour>().HasData(new Hour { Id = ++i, Value = 3 });
			modelBuilder.Entity<Hour>().HasData(new Hour { Id = ++i, Value = 4 });
			modelBuilder.Entity<Hour>().HasData(new Hour { Id = ++i, Value = 5 });
			modelBuilder.Entity<Hour>().HasData(new Hour { Id = ++i, Value = 6 });
			modelBuilder.Entity<Hour>().HasData(new Hour { Id = ++i, Value = 7 });
			modelBuilder.Entity<Hour>().HasData(new Hour { Id = ++i, Value = 8 });
			modelBuilder.Entity<Hour>().HasData(new Hour { Id = ++i, Value = 9 });
			modelBuilder.Entity<Hour>().HasData(new Hour { Id = ++i, Value = 10 });
			modelBuilder.Entity<Hour>().HasData(new Hour { Id = ++i, Value = 11 });
			modelBuilder.Entity<Hour>().HasData(new Hour { Id = ++i, Value = 12 });
			modelBuilder.Entity<Hour>().HasData(new Hour { Id = ++i, Value = 13 });
			modelBuilder.Entity<Hour>().HasData(new Hour { Id = ++i, Value = 14 });
			modelBuilder.Entity<Hour>().HasData(new Hour { Id = ++i, Value = 15 });
			modelBuilder.Entity<Hour>().HasData(new Hour { Id = ++i, Value = 16 });
			modelBuilder.Entity<Hour>().HasData(new Hour { Id = ++i, Value = 17 });
			modelBuilder.Entity<Hour>().HasData(new Hour { Id = ++i, Value = 18 });
			modelBuilder.Entity<Hour>().HasData(new Hour { Id = ++i, Value = 19 });
			modelBuilder.Entity<Hour>().HasData(new Hour { Id = ++i, Value = 20 });
			modelBuilder.Entity<Hour>().HasData(new Hour { Id = ++i, Value = 21 });
			modelBuilder.Entity<Hour>().HasData(new Hour { Id = ++i, Value = 22 });
			modelBuilder.Entity<Hour>().HasData(new Hour { Id = ++i, Value = 23 });

			i = 0;
			modelBuilder.Entity<Minute>().HasData(new Minute { Id = ++i, Value = 0 });
			modelBuilder.Entity<Minute>().HasData(new Minute { Id = ++i, Value = 15 });
			modelBuilder.Entity<Minute>().HasData(new Minute { Id = ++i, Value = 30 });
			modelBuilder.Entity<Minute>().HasData(new Minute { Id = ++i, Value = 45 });

		}

	}
}
