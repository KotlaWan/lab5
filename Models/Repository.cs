using Microsoft.Extensions.Caching.Memory;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IGI_5.Models
{
    public class Repository
    {
        ApplicationContext context;

        public Repository(ApplicationContext context)
        {
            this.context = context;
        }

        public Class GetClassByName(string name)
        {
            return context.Classes.FirstOrDefault(x => x.ClassLead == name);
        }
        public ClassType GetClassTypeByName(string name)
        {
            return context.ClassTypes.FirstOrDefault(x => x.Name == name);
        }
        public Subject GetSubjectByName(string name)
        {
            return context.Subjects.FirstOrDefault(x => x.Name == name);
        }
        
        public IEnumerable<Class> GetClasses()
        {
            return context.Classes.Include("ClassType");
        }
        public void AddClass(Class clas)
        {
            context.Classes.Add(clas);
            context.SaveChanges();
        }
        public void EditClass(Class clas)
        {
            context.Entry(clas).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void RemoveClass(int id)
        {
            context.Classes.Remove(context.Classes.Find(id));
            context.SaveChanges();
        }

        public IEnumerable<ClassType> GetClassTypes()
        {
            return context.ClassTypes;
        }
        public void AddClassType(ClassType classType)
        {
            context.ClassTypes.Add(classType);
            context.SaveChanges();
        }
        public void EditClassType(ClassType classType)
        {
            context.Entry(classType).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void RemoveClassType(int id)
        {
            context.ClassTypes.Remove(context.ClassTypes.Find(id));
            context.SaveChanges();
        }

        public IEnumerable<Schedule> GetSchedules()
        {
            return context.Schedules.Include("Class").Include("Subject");
        }
        public void AddSchedule(Schedule schedule)
        {
            context.Schedules.Add(schedule);
            context.SaveChanges();
        }
        public void EditSchedule(Schedule schedule)
        {
            context.Entry(schedule).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void RemoveSchedule(int id)
        {
            context.Schedules.Remove(context.Schedules.Find(id));
            context.SaveChanges();
        }

        public IEnumerable<Student> GetStudents()
        {
            return context.Students.Include("Class");
        }
        public void AddStudent(Student student)
        {
            context.Students.Add(student);
            context.SaveChanges();
        }
        public void EditStudent(Student student)
        {
            context.Entry(student).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void RemoveStudent(int id)
        {
            context.Students.Remove(context.Students.Find(id));
            context.SaveChanges();
        }

        public IEnumerable<Subject> GetSubjects()
        {
            return context.Subjects;
        }
        public void AddSubject(Subject subject)
        {
            context.Subjects.Add(subject);
            context.SaveChanges();
        }
        public void EditSubject(Subject subject)
        {
            context.Entry(subject).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void RemoveSubject(int id)
        {
            context.Subjects.Remove(context.Subjects.Find(id));
            context.SaveChanges();
        }
    }
}
