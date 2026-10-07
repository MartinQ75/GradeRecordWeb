using Microsoft.AspNetCore.Identity;

namespace GradeRecord.Web.Data
{
    public class UserInitializer
    {
        public static async Task SeedUsersAsync(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            // =========================
            // ADMIN
            // =========================

            var adminEmail = "admin@graderecord.com";

            var admin = await userManager.FindByEmailAsync(adminEmail);

            if (admin == null)
            {
                admin = new IdentityUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(admin, "Admin123!");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "Admin");
                }
            }

            // =========================
            // TEACHER
            // =========================

            var teacherEmail = "teacher@graderecord.com";

            var teacher = await userManager.FindByEmailAsync(teacherEmail);

            if (teacher == null)
            {
                teacher = new IdentityUser
                {
                    UserName = teacherEmail,
                    Email = teacherEmail,
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(teacher, "Teacher123!");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(teacher, "Teacher");
                }
            }

            // =========================
            // STUDENT
            // =========================

            var studentEmail = "student@graderecord.com";

            var student = await userManager.FindByEmailAsync(studentEmail);

            if (student == null)
            {
                student = new IdentityUser
                {
                    UserName = studentEmail,
                    Email = studentEmail,
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(student, "Student123!");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(student, "Student");
                }
            }
        }
    }
}
