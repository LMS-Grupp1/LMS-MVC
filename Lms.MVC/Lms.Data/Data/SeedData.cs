﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Bogus;

using Lms.MVC.Core.Entities;

namespace Lms.MVC.Data.Data
{
    internal class SeedData
    {
        //var testUsers = new Faker<User>()

        //.RuleFor(u => u.SomethingUnique, f => $"Value {f.UniqueIndex}");

        //from faker import Fakerfake = Faker()names = [fake.unique.first_name() for i in range(500)] assert len(set(names)) == len(names)

        public static async Task InitAsync(IServiceProvider services)
        {
            var courses = GetCourses();
            var students = GetStudents();
            var teachers = GetTeachers();
            var activities = GetActivities();
            var modules = GetModules();

            foreach (var course in courses)
            {
                // Add students to courses
                while (course.Students.Count < 5)
                {
                    foreach (var student in students)
                    {
                        if (!course.Students.Any(s => s.Email == student.Email))
                        {
                            course.Students.Add(student);                            
                        }
                    }
                }
                // Add teachers to courses
                while (course.Teachers.Count < 1)
                {
                    foreach (var teacher in teachers)
                    {
                        if (!course.Teachers.Any(s => s.Email == teacher.Email))
                        {
                            course.Teachers.Add(teacher);                            
                        }
                    }
                }
                // Add modules to courses
                while (course.Modules.Count < 3)
                {
                    foreach (var module in modules)
                    {
                        // Add activities to modules
                        while (module.Activities.Count < 3)
                        {
                            foreach (var activity in activities)
                            {
                                if (!module.Activities.Any(a => a.Id == activity.Id))
                                {
                                    module.Activities.Add(activity);                                    
                                }
                            }
                        }
                        if (!course.Modules.Any(m => m.Id == module.Id))
                        {
                            course.Modules.Add(module);                            
                        }
                    }
                }
            }
        }
        
        // Save students to db
        // save teachers to db
        // save activities to db
        // save modules to db
        // Save courses to db       

        private static List<Course> GetCourses()
        {
            var fake = new Faker("sv");
            var courses = new List<Course>();
            for (int i = 0; i < 5; i++)
            {
                var course = new Course
                {
                    Title = fake.Company.CatchPhrase(),
                    StartDate = DateTime.Now.AddDays(fake.Random.Int(-2, 2)),
                };
                courses.Add(course);
            }
            return courses;
        }

        private static List<Module> GetModules()
        {
            var fake = new Faker("sv");
            var modules = new List<Module>();
            for (int i = 0; i < 15; i++)
            {
                var module = new Module
                {
                    Title = fake.Name.JobTitle(),
                    StartDate = fake.Date.Soon()
                };
                modules.Add(module);
            }
            return modules;
        }

        private static List<Activity> GetActivities()
        {
            var fake = new Faker("sv");
            var modules = new List<Activity>();
            for (int i = 0; i < 45; i++)
            {
                var ran = fake.Random.Int(0, 4);
                var activity = new Activity
                {
                    Title = fake.Name.JobTitle(),
                    StartDate = fake.Date.Soon(),
                    Description = fake.Lorem.Sentence(),
                    ActivityType = GetActivityType(ran)
                };
                modules.Add(activity);
            }
            return modules;
        }

        private static List<Teacher> GetTeachers()
        {
            var fake = new Faker("sv");

            var teachers = new List<Teacher>();
            for (int i = 0; i < 20; i++)
            {
                var email = fake.Internet.Email();

                while ((teachers.Any(u => u.Email == email)))
                {
                    email = fake.Internet.Email();
                };

                var user = new Teacher
                {
                    Name = fake.Name.FullName(),
                    Email = email,
                };
            }

            return teachers;
        }

        private static List<Student> GetStudents()
        {
            var fake = new Faker("sv");

            var students = new List<Student>();
            for (int i = 0; i < 25; i++)
            {
                var email = fake.Internet.Email();

                while ((students.Any(u => u.Email == email)))
                {
                    email = fake.Internet.Email();
                };

                var student = new Student
                {
                    Name = fake.Name.FullName(),
                    Email = email,
                };
            }

            return students;
        }

        private static ActivityType GetActivityType(int ran)
        {
            var activityTypeEnum = (ActivityTypeEnum)ran;
            var activityTypeName = activityTypeEnum.ToString();
            var activityType = new ActivityType
            {
                Name = activityTypeName
            };
            return activityType;
        }
    }

    public enum ActivityTypeEnum
    {
        Lecture,

        ELearning,

        Practise,

        Assignment,

        Other
    }
}