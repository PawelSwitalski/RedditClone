using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage;

namespace RedditClone.Data
{
    public class ExampleData
    {
        public ExampleData(IApplicationBuilder app) 
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            ApplicationDbContext context = app.ApplicationServices.CreateScope()
                .ServiceProvider.GetRequiredService<ApplicationDbContext>();


            if (!context.Users.Any())
            {
                context.Users.AddRange(
                    new IdentityUser
                    {
                        UserName = "admin",
                        Email = "admin@email.com",
                    },
                    new IdentityUser
                    {
                        UserName = "jan",
                        Email = "jan@email.com",
                    },
                    new IdentityUser
                    {
                        UserName = "anna",
                        Email = "anna@email.com",
                    },
                    new IdentityUser
                    {
                        UserName = "kamil",
                        Email = "kamil@email.com",
                    },
                    new IdentityUser
                    {
                        UserName = "paulina",
                        Email = "paulina@email.com",
                    },
                    new IdentityUser
                    {
                        UserName = "ula",
                        Email = "ula@email.com",
                    }
                    );
                context.SaveChanges();
            }

            if (!context.Posts.Any())
            {
                var user = context.Users.Where(u => u.UserName == "jan").FirstOrDefault();
                if (user == null)
                {
                    throw new Exception("User 'jan' was not found in the database.");
                }
                Guid janId = Guid.Parse(user.Id);


                context.Posts.AddRange(
                    new Models.Post
                    {
                        Id = Guid.NewGuid(),
                        Title = "Hello world Post",
                        BodyText = "this is first post. User is unndefined in this post. \nLorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                        LikesNumber = 1
                    },
                    new Models.Post
                    {
                        Id = Guid.NewGuid(),
                        Title = "First Jan Post C# forum",
                        BodyText = "Guid in C#. If the string represents a valid GUID format, you can use either of these methods:\r\n\r\nUsing Guid.Parse\r\nUsing Guid.TryParse\nLorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                        UserId = janId,
                        User = user
                    });

                context.SaveChanges();
            }


        }
    }
}
