using FeedbackApp.Server.Models;

namespace FeedbackApp.Server.Data
{
    public class AppDbInitializer
    {
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
                            new Feedback()
                            {
                                Name = "Name for feedback",
                                Description = "Description for feedback",
                                Email = "jotain@jotain.fi"
                            },
                            new Feedback()
                            {
                                Name = "Name for feedback 2",
                                Description = "Description for feedback 2",
                                Email = "jotain2@jotain.fi"
                            },
                            new Feedback()
                            {
                                Name = "Name for feedback 3",
                                Description = "Description for feedback 3",
                                Email = "jotain3@jotain.fi"
                            },
                        });
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}   
