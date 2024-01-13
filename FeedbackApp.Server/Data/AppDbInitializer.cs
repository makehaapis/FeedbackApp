using FeedbackApp.Server.Models;
using Microsoft.AspNetCore.Identity;
using System.Drawing;
using System.Reflection.Metadata;

namespace FeedbackApp.Server.Data
{
    public class AppDbInitializer
    {
        //Initialize database with feedbacks
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                    if (context.Database.EnsureCreated())
                    {
                        if (!context.Feedbacks.Any())
                        {
                            context.Feedbacks.AddRange(new List<Feedback>()
                        {
                            new()
                            {
                                Name = "John",
                                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas elit lectus, eleifend at nunc non, rhoncus lobortis nulla. Donec efficitur ornare suscipit. Vestibulum dapibus sed magna id ullamcorper. Nunc vel eros et quam volutpat venenatis et eget neque. Cras lacinia turpis erat. Curabitur at scelerisque ligula. Sed cursus turpis nec eros consectetur, et suscipit dui facilisis. Donec congue, nunc posuere blandit mattis, est eros dapibus magna, porta volutpat nisl est ut arcu. Maecenas justo.",
                                Email = "john@gmail.com",
                                Created = DateTime.Now,
                                Rating = 5
                            },
                            new()
                            {
                                Name = "Steve",
                                Description = "Vivamus sed lectus eros. Praesent faucibus, turpis quis luctus sollicitudin.",
                                Email = "steve@gmail.com",
                                Created = DateTime.Now,
                                Rating = 4
                            },
                            new()
                            {
                                Name = "Adeline",
                                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam eros turpis, tempus eu lacus non.",
                                Email = "adelene@gmail.com",
                                Rating = 2
                            },
                            new()
                            {
                                Name = "Holly",
                                Description = "Sed viverra ex leo, a integer.",
                                Email = "holly@gmail.com",
                                Rating = 5
                            },
                            new()
                            {
                                Name = "Karol",
                                Description = "Maecenas imperdiet pulvinar ex, ut mattis massa. Sed ut augue eu lorem dignissim ullamcorper. Nam ultrices augue non hendrerit congue. Integer malesuada tortor ornare suscipit venenatis. Fusce iaculis leo sem.",
                                Email = "karol@gmail.com",
                                Rating = 2
                            },
                            new()
                            {
                                Name = "Bob",
                                Description = "Proin libero lectus efficitur.",
                                Email = "bob@gmail.com",
                                Rating = 3
                            }
                            });
                            context.SaveChanges();
                        }
                    }
                }
            }
        }
    }
