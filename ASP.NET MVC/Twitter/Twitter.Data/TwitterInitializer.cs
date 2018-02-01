using System.Collections.Generic;
using System.Data.Entity;

using Twitter.Models;

namespace Twitter.Data
{
    public class TwitterInitializer : DropCreateDatabaseIfModelChanges<TwitterDBContext>
    {
        protected override void Seed(TwitterDBContext context)
        {
            var users = new List<User>
            {
                new User{Id="1", UserName="pesho", Email="pesho@gosho.com", PasswordHash="Mnogoslojnaparola123@"},
                new User{Id="2", UserName="tseko", Email="tseko@gosho.com", PasswordHash="Mnogoslojnaparola123@"},
                new User{Id="3", UserName="gosho", Email="gosho@gosho.com", PasswordHash="Mnogoslojnaparola123@"},
                new User{Id="4", UserName="mosho", Email="moshoo@gosho.com", PasswordHash="Mnogoslojnaparola123@"},
                new User{Id="5", UserName="tosho", Email="tosho@gosho.com", PasswordHash="Mnogoslojnaparola123@"},
                new User{Id="6", UserName="losho", Email="losho@gosho.com", PasswordHash="Mnogoslojnaparola123@"},
                new User{Id="7", UserName="kokosho", Email="kokosho@gosho.com", PasswordHash="Mnogoslojnaparola123@"},
                new User{Id="8", UserName="prucho", Email="prucho@gosho.com", PasswordHash="Mnogoslojnaparola123@"},
                new User{Id="9", UserName="siyka", Email="siyka@gosho.com", PasswordHash="Mnogoslojnaparola123@"},
                new User{Id="10", UserName="mariyka", Email="mariyka@gosho.com", PasswordHash="Mnogoslojnaparola123@"},
                new User{Id="11", UserName="gonka", Email="gonka@gosho.com", PasswordHash="Mnogoslojnaparola123@"},
                new User{Id="12", UserName="ginka", Email="ginka@gosho.com", PasswordHash="Mnogoslojnaparola123@"},
                new User{Id="13", UserName="stanka", Email="stanka@gosho.com", PasswordHash="Mnogoslojnaparola123@"},
                new User{Id="14", UserName="GinyoGanev", Email="ginyo@gosho.com", PasswordHash="Mnogoslojnaparola123@"},
                new User{Id="15", UserName="DjaniMorandi", Email="djani@gosho.com", PasswordHash="Mnogoslojnaparola123@"}
            };

            users.ForEach(u => context.Users.Add(u));
            context.SaveChanges();

            var posts = new List<Post>
            {
                new Post{Id = 1, Title="What the fuck", Content="******!??!", QuestionID = null, UserID = "1" },
                new Post{Id = 2, Title="Hey guys!", Content="Hi guys", QuestionID = null, UserID = "1" },
                new Post{Id = 3, Title="I am at starbucks", Content="At starbucks drinking coffee",
                            QuestionID = null, UserID = "1"},
                new Post{Id = 4, Title="I am at the toilet", Content="At the toilet taking a dump",
                            QuestionID = null, UserID = "1"},
                new Post{Id = 5, Title="Hey gals!", Content="Hi gals", QuestionID = null, UserID = "12"},
                new Post{Id = 6, Title="I am in the woods", Content="At the woods taking a crap", QuestionID = null,
                            UserID = "3"},
                new Post { Id = 9, Title = "Wasn't me:))", Content = ":))))", UserID = "3", QuestionID = 1 },
                new Post { Id = 10, Title = "Hi", Content = "Hi", UserID = "3", QuestionID = 2 },
                new Post { Id = 11, Title = "Hi", Content = "Hi", UserID = "2", QuestionID = 2 },
                new Post { Id = 12, Title = "Hey", Content = "Hi", UserID = "4", QuestionID = 2 },
                new Post { Id = 13, Title = "Nice!!!", Content = "I like lasagna", UserID = "1",
                           QuestionID = 7 },
                new Post { Id = 14, Title = "No way!!!", Content = "The lasagna is all mine this time asshole", UserID = "3",
                           QuestionID = 7 },
                new Post { Id = 15, Title = "Wow", Content = "I wish I could cook too", UserID = "13",
                           QuestionID = 7 },
                new Post { Id = 16, Title = "Fuck you!!!", Content = "!?*****, Gosho!!!!", UserID = "1",
                           QuestionID = 7 },
                new Post { Id = 17, Title = "Wow", Content = "Guys, take it easy...", UserID = "13",
                            QuestionID = 7 },
                new Post { Id = 18, Title = "Speechless", Content = "...", UserID = "12", QuestionID = 7 },
                new Post{Id = 7, Title="I am in the kitchen", Content="Cooking lasagna", QuestionID = null,
                            UserID = "13" },
                new Post{Id = 8, Title="Can't you guys be more original",
                     Content ="What's the point of all those meaningless posts?!!", QuestionID = null,
                            UserID = "9"}
            };

            posts.ForEach(p => context.Posts.Add(p));
            context.SaveChanges();

            var postAnswers = new List<PostAnswer>
            {
                new PostAnswer{ Id = 1, ParentPostId = 1, AnswerId = 9 },
                new PostAnswer{ Id = 2, ParentPostId = 2, AnswerId = 10 },
                new PostAnswer{ Id = 3, ParentPostId = 2, AnswerId = 11 },
                new PostAnswer{ Id = 4, ParentPostId = 2, AnswerId = 12 },
                new PostAnswer{ Id = 7, ParentPostId = 7, AnswerId = 13 },
                new PostAnswer{ Id = 8, ParentPostId = 7, AnswerId = 14 },
                new PostAnswer{ Id = 9, ParentPostId = 7, AnswerId = 15 },
                new PostAnswer{ Id = 10, ParentPostId = 7, AnswerId = 16 },
                new PostAnswer{ Id = 11, ParentPostId = 7, AnswerId = 17 },
                new PostAnswer{ Id = 12, ParentPostId = 7, AnswerId = 18 }
            };

            postAnswers.ForEach(a => context.PostAnswers.Add(a));
            context.SaveChanges();

            context.PostFavourites.Add(new PostFavourite { UserId = "3", PostId = 1 });
            context.PostFavourites.Add(new PostFavourite { UserId = "3", PostId = 4 });
            context.PostFavourites.Add(new PostFavourite { UserId = "1", PostId = 6 });
            context.PostFavourites.Add(new PostFavourite { UserId = "1", PostId = 7 });
            context.PostFavourites.Add(new PostFavourite { UserId = "3", PostId = 7 });
            context.PostFavourites.Add(new PostFavourite { UserId = "2", PostId = 7 });

            context.SaveChanges();
        }
    }
}
