using System.Reflection.Metadata.Ecma335;

namespace MinimalApis
{
    public class ArticleServices
    {
        private int a; 
        private List<Article> articles = new List<Article>
            {
                 new(1, "marteau"),
                 new(2, "scie")
            };

        public List<Article> GetAll() => articles;
        public Article Add(string title) 
        {
            var article = new Article(articles.Max(a => a.Id) + 1, title);
            articles.Add(article);
            return article;
        }

    }
}
