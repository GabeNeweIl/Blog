using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.DAL.Data;
using System.Data.Entity;

namespace Blog.DAL
{
    public class BlogDbInitializer : CreateDatabaseIfNotExists<BlogContext>
    {
        protected override void Seed(BlogContext context)
        {
            Article article1 = new Article
            {
                Heading = "Интеграл",
                Publish = new DateTime(2019, 7, 25),
                Text = "Интеграл — одно из важнейших понятий математического анализа," +
                    " которое возникает при решении задач о нахождении площади под кривой, пройденного пути при неравномерном движении," +
                    " массы неоднородного тела, и тому подобных, а также в задаче о восстановлении функции по её производной.",
            };
            Article article2 = new Article
            {
                Heading = "Умножение",
                Publish = new DateTime(2019, 7, 2),
                Text = "Умноже́ние — одна из основных математических операций над двумя аргументами (множителями, сомножителями)." +
                " Иногда первый аргумент называют множимым, а второй множителем; результат умножения двух аргументов называется их произведением.",
            };
            Article artiсle3 = new Article
            {
                Heading = "Заголовок",
                Text = "Какой-то текст",
                Publish = new DateTime(2019, 10, 3),
            };
            context.Articles.Add(article1);
            context.Articles.Add(article2);
            context.Articles.Add(artiсle3);
            Tag tag1 = new Tag { Name = "Mathematics", Articles = new List<Article> { article1, article2 } };
            Tag tag2 = new Tag { Name = "Test", Articles = new List<Article> { article1, article2, artiсle3 } };
            context.Tags.Add(tag1);
            context.Tags.Add(tag2);
            Vote vote1 = new Vote { Count = 0, Name = "Male" };
            Vote vote2 = new Vote { Count = 0, Name = "Female" };
            context.Votes.Add(vote1);
            context.Votes.Add(vote2);
            base.Seed(context);
        }
    }
}
