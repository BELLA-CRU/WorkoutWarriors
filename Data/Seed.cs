using Microsoft.AspNetCore.Identity;
using System.Diagnostics;
using System.Runtime.Intrinsics.X86;
using WorkoutWarriors.Data;
using WorkoutWarriors.Data.Enum;
using WorkoutWarriors.Models;

namespace WorkoutWarriors.Data { 

    public class Seed
{
    public static void SeedData(IApplicationBuilder applicationBuilder)
    {
        using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
        {
            var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

            context.Database.EnsureCreated();

            if (!context.Gyms.Any())
            {
                context.Gyms.AddRange(new List<Gym>()
                    {
                        new Gym()
                        {
                            Title = "Norman Crunch Gym",
                            Image = "https://1000logos.net/wp-content/uploads/2020/08/Logo-Crunch-Fitness.jpg",
                            Description = "You Can Crunch With Us!",
                            GymType = GymType.CrunchGym,
                            Address = new Address()
                            {
                                Street = "2300 W Main St",
                                City = "Norman",
                                State = "OK"
                            }
                         },
                        new Gym()
                        {
                            Title = "Sarkey's Fitness Center",
                            Image = "https://1000logos.net/wp-content/uploads/2019/09/Oklahoma-Sooners-softball-logo.jpg",
                            Description = "Free with College Tuition",
                            GymType = GymType.SarkeyGym,
                            Address = new Address()
                            {
                                Street = "1401 Asp Ave",
                                City = "Norman",
                                State = "OK"
                            }
                        },
                        new Gym()
                        {
                            Title = "Norman Planet Fitness",
                            Image = "https://logos-world.net/wp-content/uploads/2022/01/Planet-Fitness-Logo.png",
                            Description = "Welcome to a Judgement Free Zone",
                            GymType = GymType.PlanetGym,
                            Address = new Address()
                            {
                                Street = "1000 E Alameda St",
                                City = "Norman",
                                State = "OK"
                            }
                        },
                        new Gym()
                        {
                            Title = "Norman Orangetheory",
                            Image = "https://1000logos.net/wp-content/uploads/2020/07/Orangetheory-Fitness-Logo.png",
                            Description = "We Exist to Give People a Longer, More Vibrant Life",
                            GymType = GymType.OrangeTheory,
                            Address = new Address()
                            {
                                Street = "3700 W Robinson St Suite 120-124",
                                City = "Norman",
                                State = "OK"
                            }
                        }
                    });
                context.SaveChanges();
            }
            //Workouts
            if (!context.Workouts.Any())
            {
                context.Workouts.AddRange(new List<Workout>()
                    {
                        new Workout()
                        {
                            Title = "Orangetheory HIIT",
                            Image = "https://1000logos.net/wp-content/uploads/2020/07/Orangetheory-Fitness-Logo.png",
                            Description = "Come Join Us for a Science-Backed HIIT Workout Guaranteed to Make You Sweat!",
                            WorkoutType = WorkoutType.HIIT,
                            Address = new Address()
                            {
                                Street = "3700 W Robinson St Suite 120-124",
                                City = "Norman",
                                State = "OK"
                            }
                        },
                        new Workout()
                        {
                            Title = "Sarkey's Spin Class",
                            Image = "https://1000logos.net/wp-content/uploads/2019/09/Oklahoma-Sooners-softball-logo.jpg",
                            Description = "Come Join us for a Spin Class!",
                            WorkoutType = WorkoutType.Spin,
                            
                            Address = new Address()
                            {
                                Street = "1401 Asp Ave",
                                City = "Norman",
                                State = "OK"
                            }
                        }
                    });
                context.SaveChanges();
            }
        }
    }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                string adminUserEmail = "bellavcruz@gmail.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new AppUser()
                    {
                        UserName = "bella_cruz",
                        Email = adminUserEmail,
                        EmailConfirmed = true,
                        TwoFactorEnabled = false,
                        PhoneNumberConfirmed = false,
                        LockoutEnabled = false,
                        AccessFailedCount = 0,
                        Address = new Address()
                        {
                            Street = "123 Main St",
                            City = "Norman",
                            State = "OK"
                        }
                    };
                    await userManager.CreateAsync(newAdminUser, "Se2023!");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                string adminUserEmail1 = "danielli@gmail.com";

                var adminUser1 = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser1 == null)
                {
                    var newAdminUser1 = new AppUser()
                    {
                        UserName = "daniel_li",
                        Email = adminUserEmail1,
                        EmailConfirmed = true,
                        TwoFactorEnabled = false,
                        PhoneNumberConfirmed = false,
                        LockoutEnabled = false,
                        AccessFailedCount = 0,
                        Address = new Address()
                        {
                            Street = "123 Main St",
                            City = "Norman",
                            State = "OK"
                        }
                    };
                    await userManager.CreateAsync(newAdminUser1, "Se2023!");
                    await userManager.AddToRoleAsync(newAdminUser1, UserRoles.Admin);
                }

                string adminUserEmail2 = "KarlyMeeks@gmail.com";

                var adminUser2 = await userManager.FindByEmailAsync(adminUserEmail2);
                if (adminUser2 == null)
                {
                    var newAdminUser2 = new AppUser()
                    {
                        UserName = "karly_meeks",
                        Email = adminUserEmail2,
                        EmailConfirmed = true,
                        TwoFactorEnabled = false,
                        PhoneNumberConfirmed = false,
                        LockoutEnabled = false,
                        AccessFailedCount = 0,
                        Address = new Address()
                        {
                            Street = "123 Main St",
                            City = "Norman",
                            State = "OK"
                        }
                    };
                    await userManager.CreateAsync(newAdminUser2, "Se2023!");
                    await userManager.AddToRoleAsync(newAdminUser2, UserRoles.Admin);
                }

                string adminUserEmail3 = "lucywestmicer@gmail.com";

                var adminUser3 = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser3 == null)
                {
                    var newAdminUser3 = new AppUser()
                    {
                        UserName = "lucy_westmicer",
                        Email = adminUserEmail3,
                        EmailConfirmed = true,
                        TwoFactorEnabled = false,
                        PhoneNumberConfirmed = false,
                        LockoutEnabled = false,
                        AccessFailedCount = 0,
                        Address = new Address()
                        {
                            Street = "123 Main St",
                            City = "Norman",
                            State = "OK"
                        }
                    };
                    await userManager.CreateAsync(newAdminUser3, "Se2023!");
                    await userManager.AddToRoleAsync(newAdminUser3, UserRoles.Admin);
                }
                string appUserEmail = "user@etickets.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new AppUser()
                    {
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true,
                        TwoFactorEnabled = false,
                        PhoneNumberConfirmed = false,
                        LockoutEnabled = false,
                        AccessFailedCount = 0,
                        Address = new Address()
                        {
                            Street = "123 Main St",
                            City = "Charlotte",
                            State = "NC"
                        }
                    };
                    await userManager.CreateAsync(newAppUser, "Se2023!");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}
