using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQStudio
{
    // https://www.dotnetcurry.com/ShowArticle.aspx?ID=414

    public class NewStudent
    {
        public int NewStudentId { get; set; }
        public int SubjectId { get; set; }
        public float Marks { get; set; }
    }

    public static class School
    {
        private static List<NewStudent> GetNewStudents()
        {
            List<NewStudent> NewStudents = new List<NewStudent>
            {
                new NewStudent() {NewStudentId = 1, SubjectId = 1, Marks = 8.0f},
                new NewStudent() {NewStudentId = 2, SubjectId = 1, Marks = 5.0f},
                new NewStudent() {NewStudentId = 3, SubjectId = 1, Marks = 7.0f},
                new NewStudent() {NewStudentId = 4, SubjectId = 1, Marks = 9.5f},
                new NewStudent() {NewStudentId = 1, SubjectId = 2, Marks = 9.0f},
                new NewStudent() {NewStudentId = 2, SubjectId = 2, Marks = 7.0f},
                new NewStudent() {NewStudentId = 3, SubjectId = 2, Marks = 4.0f},
                new NewStudent() {NewStudentId = 4, SubjectId = 2, Marks = 7.5f}
            };

            return NewStudents;
        }

        public static void GetHighMarks()
        {
            var groups = from s in GetNewStudents()
                group s by s.SubjectId into stugrp
                let topp = stugrp.Max(x => x.Marks)
                select new
                {
                    Subject = stugrp.Key,
                    TopStudent = stugrp.First(y => y.Marks == topp).NewStudentId,
                    MaximumMarks = topp
                };

            foreach (var student in groups)
            {
                Console.WriteLine("In SubjectID {0}, Student with StudentId {1} got {2}",
                    student.Subject,
                    student.TopStudent,
                    student.MaximumMarks);
            }

            Console.ReadKey();
        }    
    }
}
