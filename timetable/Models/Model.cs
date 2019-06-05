using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;

namespace timetable.Models
{
    public class TimetableContext : DbContext
    {
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherLesson> TeacherLessons { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<SemesterLesson> SemesterLessons { get; set; }
        public DbSet<Cabinet> Cabinets { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Schedule> Schedules { get; set; }

        public TimetableContext(DbContextOptions<TimetableContext> options)
            : base(options)
        { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lesson>()
                .Property(p => p.Type)
                .HasConversion(
                    v => v.ToString(),
                    v => (LessonType) Enum.Parse(typeof(LessonType), v));

            modelBuilder.Entity<Cabinet>()
                .Property(p => p.Type)
                .HasConversion(
                    v => v.ToString(),
                    v => (LessonType) Enum.Parse(typeof(LessonType), v));

            modelBuilder.Entity<Schedule>()
                .Property(p => p.Week)
                .HasConversion(
                    v => v.ToString(),
                    v => (Week) Enum.Parse(typeof(Week), v));

            modelBuilder.Entity<Schedule>()
                .Property(p => p.DayOfWeek)
                .HasConversion<int>();

            base.OnModelCreating(modelBuilder);
        }
    }

    public class Subject
    {
        public int SubjectId { get; set; }
        public string Name { get; set; }
    }

    public enum LessonType
    {
        Lecture,
        Seminar,
        LaboratoryWork
    }

    public class Lesson
    {
        public int LessonId { get; set; }
        public LessonType Type { get; set; }
        public int SubjectId { get; set; }
        public bool HalfGroup { get; set; }
        public bool Joinable { get; set; }
    }

    public class Teacher
    {
        public int TeacherId { get; set; }
        public string FullName { get; set; }
        public ICollection<TeacherLesson> TeacherLessons { get; set; }
    }

    public class TeacherLesson
    {
        public int TeacherLessonId { get; set; }
        public int TeacherId { get; set; }
        public int LessonId { get; set; }
    }

    public class Specialty
    {
        public int SpecialtyId { get; set; }
        public string Name { get; set; }
        // public int FacultyId { get; set; }
    }

    public class Semester
    {
        public int SemesterId { get; set; }
        public int SpecialtyId { get; set; }
        public int SemesterIndex { get; set; }  // 1..8 or 1..10 or 1..12
        public ICollection<SemesterLesson> SemesterLessons { get; set; }
    }

    public class SemesterLesson
    {
        public int SemesterLessonId { get; set; }
        public int LessonId { get; set; }
        public int Duration { get; set; }
    }

    public class Cabinet
    {
        public int CabinetId { get; set; }
        public int Housing { get; set; }
        public string Auditorium { get; set; }
        public LessonType Type { get; set; }
    }

    public class Group
    {
        public int GroupId { get; set; }
        public string Name { get; set; }
        public int SemesterId { get; set; }
    }

    public enum Week
    {
        Odd,
        Even
    }

    public enum DayOfWeek
    {
        Mon,
        Tue,
        Wed,
        Thu,
        Fri,
        Sat
    }
    
    public class Schedule
    {
        public int ScheduleId { get; set; }
        public int GroupId { get; set; }
        public int LessonId { get; set; }
        public int TeacherId { get; set; }
        public int CabinetId { get; set; }
        public Week Week { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public int LessonIndex { get; set; }
    }
}
