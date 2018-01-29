

namespace EmployeeChallenge.Data
{
    using EmployeeChallenge.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class DbInitializer
    {
        public static void Initialize(EmployeeChallengeContext context)
        {
            context.Database.EnsureCreated();

            if (context.Employees.Any())
            {
                return;   
            }

            var skills = new Skill[]
            {
                new Skill()
                {
                    Name = "Skill1"
                },
                new Skill()
                {
                    Name = "Skill2"
                },
                new Skill()
                {
                    Name = "Skill3"
                },
                new Skill()
                {
                    Name = "Skill4"
                }
            };
            foreach (Skill r in skills)
            {
                context.Skills.Add(r);
            }

            context.SaveChanges();



            var employees = new Employee[]
            {
                new Employee()
                {
                     FirstName = "FirstName1",
                     LastName = "LastName1",
                     DateOfBirth  = DateTime.Parse("2005-08-15"),
                     Email = "email1@mail.com",
                     PhoneNumber ="+3052585258",
                     Address = new Address()
                     {
                         AddressLine = "Address1",
                         City = "City1",
                         Country = "Country1",
                         ZipCode = "15855"
                     },
                     SkillAssignments = new SkillAssignment[]
                     {
                          new SkillAssignment()
                          {
                              Skill = skills[0],
                              AssignmentDate = DateTime.Parse("2004-07-14")
                          },
                          new SkillAssignment()
                          {
                              Skill = skills[1],
                              AssignmentDate = DateTime.Parse("2002-07-14")
                          },
                          new SkillAssignment()
                          {
                              Skill = skills[2],
                              AssignmentDate = DateTime.Parse("2006-07-14")
                          }
                     }
                },
                new Employee()
                {
                     FirstName = "FirstName2",
                     LastName = "LastName2",
                     DateOfBirth  =DateTime.Parse("2005-08-15"),
                     Email = "email2@mail.com",
                     PhoneNumber ="+4052585258",
                     Address = new Address()
                     {
                         AddressLine = "Address2",
                         City = "City2",
                         Country = "Country2",
                         ZipCode = "15855"
                     },
                     SkillAssignments = new SkillAssignment[]
                     {
                          new SkillAssignment()
                          {
                              Skill = skills[0],
                              AssignmentDate = DateTime.Parse("2002-07-14")
                          }
                     }
                },
                new Employee()
                {
                     FirstName = "FirstName3",
                     LastName = "LastName3",
                     DateOfBirth  =DateTime.Parse("2003-08-15"),
                     Email = "email3@mail.com",
                     PhoneNumber ="+4052585258",
                     Address = new Address()
                     {
                         AddressLine = "Address3",
                         City = "City3",
                         Country = "Country3",
                         ZipCode = "15455"
                     }
                },
                new Employee()
                {
                     FirstName = "FirstName4",
                     LastName = "LastName4",
                     DateOfBirth  =DateTime.Parse("2000-08-15"),
                     Email = "email4@mail.com",
                     PhoneNumber ="+3052585258",
                     Address = new Address()
                     {
                         AddressLine = "Address4",
                         City = "City4",
                         Country = "Country4",
                         ZipCode = "15854"
                     },
                     SkillAssignments = new SkillAssignment[]
                     {
                          new SkillAssignment()
                          {
                              Skill = skills[0],
                              AssignmentDate = DateTime.Parse("2001-07-14")
                          },
                          new SkillAssignment()
                          {
                              Skill = skills[2],
                              AssignmentDate = DateTime.Parse("2017-07-14")
                          }
                     }
                }
            };
            foreach (Employee e in employees)
            {
                context.Employees.Add(e);
            }

            context.SaveChanges();

        }
    }
}
