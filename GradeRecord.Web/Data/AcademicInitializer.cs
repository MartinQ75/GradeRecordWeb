using GradeRecord.Class;
using GradeRecord.Class.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public class AcademicInitializer
{
    public static async Task SeedAcademicDataAsync(
        IServiceProvider serviceProvider)
    {
        var userManager =
            serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

        var context =
            serviceProvider.GetRequiredService<GradeRecordDB>();

        // ==========================================
        // BUSCAR USUARIO STUDENT
        // ==========================================

        var studentUser =
            await userManager.FindByEmailAsync(
                "student@graderecord.com");

        StudentModel? student = null;

        if (studentUser != null)
        {
            student =
                await context.Students
                    .FirstOrDefaultAsync(s => s.UserId == studentUser.Id);

            if (student == null)
            {
                student = new StudentModel
                {
                    Enrollment = "20260001",
                    StudentName = "Martin",
                    Paternal_Surname = "Prueba",
                    Maternal_Surname = "Alumno",
                    Email = "student@graderecord.com",
                    Status = true,
                    UserId = studentUser.Id
                };

                context.Students.Add(student);
                await context.SaveChangesAsync();
            }
        }

        // ==========================================
        // BUSCAR USUARIO TEACHER
        // ==========================================

        var teacherUser =
            await userManager.FindByEmailAsync(
                "teacher@graderecord.com");

        TeacherModel? teacher = null;

        if (teacherUser != null)
        {
            teacher =
                await context.Teachers
                    .FirstOrDefaultAsync(t => t.UserId == teacherUser.Id);

            if (teacher == null)
            {
                teacher = new TeacherModel
                {
                    Number_Employee = 1001,
                    Name = "Profesor",
                    Paternal_Surname = "Prueba",
                    Maternal_Surname = "Docente",
                    Email = "teacher@graderecord.com",
                    Username = "teacher",
                    Status = true,
                    UserId = teacherUser.Id
                };

                context.Teachers.Add(teacher);
                await context.SaveChangesAsync();
            }
        }

        // ==========================================
        // CREAR GRUPO
        // ==========================================

        var group =
            await context.Groups
                .FirstOrDefaultAsync(g => g.Name_Group == "9A");

        if (group == null)
        {
            group = new GroupModel
            {
                Name_Group = "9A",
                Semester = 9,
                Term = "2026-2",
                Turn = "Matutino",
                Status = true
            };

            context.Groups.Add(group);
            await context.SaveChangesAsync();
        }

        // ==========================================
        // INSCRIBIR STUDENT AL GRUPO
        // ==========================================

        if (student != null && group != null)
        {
            var studentGroupExists =
                await context.Students_Groups
                    .AnyAsync(sg =>
                        sg.Id_Student == student.Id &&
                        sg.Id_Group == group.Id);

            if (!studentGroupExists)
            {
                var studentGroup = new Student_Group_Model
                {
                    Id_Student = student.Id,
                    Id_Group = group.Id
                };

                context.Students_Groups.Add(studentGroup);
                await context.SaveChangesAsync();
            }
        }

        // ==========================================
        // CREAR MATERIA 1
        // ==========================================

        var subject1 =
            await context.Subjects
                .FirstOrDefaultAsync(s => s.Code_Subject == "PROG01");

        if (subject1 == null)
        {
            subject1 = new SubjectModel
            {
                Code_Subject = "PROG01",
                Name_Subject = "Programación Avanzada",
                Semester = 9,
                Units = 3,
                Status = true
            };

            context.Subjects.Add(subject1);
            await context.SaveChangesAsync();
        }

        // ==========================================
        // CREAR MATERIA 2
        // ==========================================

        var subject2 =
            await context.Subjects
                .FirstOrDefaultAsync(s => s.Code_Subject == "BD01");

        if (subject2 == null)
        {
            subject2 = new SubjectModel
            {
                Code_Subject = "BD01",
                Name_Subject = "Bases de Datos",
                Semester = 9,
                Units = 3,
                Status = true
            };

            context.Subjects.Add(subject2);
            await context.SaveChangesAsync();
        }

        // ==========================================
        // ASIGNAR PROFESOR + MATERIA + GRUPO
        // ==========================================

        if (teacher != null && group != null)
        {
            if (subject1 != null)
            {
                var assignment1 =
                    await context.Teachers_Subjects
                        .FirstOrDefaultAsync(ts =>
                            ts.Id_Teacher == teacher.Id &&
                            ts.Id_Subject == subject1.Id &&
                            ts.Id_Group == group.Id);

                if (assignment1 == null)
                {
                    assignment1 = new Teacher_Subject_Group_Model
                    {
                        Id_Teacher = teacher.Id,
                        Id_Subject = subject1.Id,
                        Id_Group = group.Id
                    };

                    context.Teachers_Subjects.Add(assignment1);
                    await context.SaveChangesAsync();
                }
            }

            if (subject2 != null)
            {
                var assignment2 =
                    await context.Teachers_Subjects
                        .FirstOrDefaultAsync(ts =>
                            ts.Id_Teacher == teacher.Id &&
                            ts.Id_Subject == subject2.Id &&
                            ts.Id_Group == group.Id);

                if (assignment2 == null)
                {
                    assignment2 = new Teacher_Subject_Group_Model
                    {
                        Id_Teacher = teacher.Id,
                        Id_Subject = subject2.Id,
                        Id_Group = group.Id
                    };

                    context.Teachers_Subjects.Add(assignment2);
                    await context.SaveChangesAsync();
                }
            }
        }

        // ==========================================
        // CREAR CALIFICACIONES DE PRUEBA
        // ==========================================

        if (student != null && teacher != null && group != null)
        {
            var assignment1 =
                await context.Teachers_Subjects
                    .Include(ts => ts.Subject)
                    .FirstOrDefaultAsync(ts =>
                        ts.Id_Teacher == teacher.Id &&
                        ts.Id_Subject == subject1!.Id &&
                        ts.Id_Group == group.Id);

            var assignment2 =
                await context.Teachers_Subjects
                    .Include(ts => ts.Subject)
                    .FirstOrDefaultAsync(ts =>
                        ts.Id_Teacher == teacher.Id &&
                        ts.Id_Subject == subject2!.Id &&
                        ts.Id_Group == group.Id);

            if (assignment1 != null)
            {
                var gradeExists =
                    await context.Grades
                        .AnyAsync(g =>
                            g.Id_Student == student.Id &&
                            g.Id_Teacher_Subject == assignment1.Id &&
                            g.Unit == 1);

                if (!gradeExists)
                {
                    context.Grades.Add(new GradeModel
                    {
                        Unit = 1,
                        Grade = 95,
                        Opportunity = 1,
                        Date_Register = DateTime.Now,
                        Id_Student = student.Id,
                        Id_Teacher_Subject = assignment1.Id
                    });
                }
            }

            if (assignment2 != null)
            {
                var gradeExists =
                    await context.Grades
                        .AnyAsync(g =>
                            g.Id_Student == student.Id &&
                            g.Id_Teacher_Subject == assignment2.Id &&
                            g.Unit == 1);

                if (!gradeExists)
                {
                    context.Grades.Add(new GradeModel
                    {
                        Unit = 1,
                        Grade = 88,
                        Opportunity = 1,
                        Date_Register = DateTime.Now,
                        Id_Student = student.Id,
                        Id_Teacher_Subject = assignment2.Id
                    });
                }
            }

            await context.SaveChangesAsync();
        }
    }
}

