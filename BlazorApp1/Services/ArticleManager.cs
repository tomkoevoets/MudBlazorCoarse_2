using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace ArticlesPlatform.Services
{
    public class ArticleManager
    {
        private readonly SqlConnection _sqlconnection;

        public ArticleManager(SqlConnection sqlconnection)
        {
            _sqlconnection = sqlconnection;
        }

        public async Task<bool> InsertNewArticle(NewArticle newarticle)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT_NewArticle", _sqlconnection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Title", newarticle.Title);
                cmd.Parameters.AddWithValue("Subtitle", newarticle.Subtitle);
                cmd.Parameters.AddWithValue("ArticleBody", newarticle.ArticleBody);
                cmd.Parameters.AddWithValue("Category", newarticle.Category);
                cmd.Parameters.AddWithValue("Authors", NewArticle.AuthorsToString(newarticle.Authors));

                if (await cmd.ExecuteNonQueryAsync() == 1)
                {
                    return true;
                }

                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public class NewArticle
        {
            public string Title { get; set; }
            public string Subtitle { get; set; }
            public string ArticleBody { get; set; }
            public int Category { get; set; }
            public List<string> Authors { get; set; }

            public static string AuthorsToString(List<string> authors)
            {
                string result = "";

                if (authors.Count == 1)
                {
                    result = authors[0];
                    return result;
                }

                for (int i = 0; i < authors.Count; i++)
                {
                    if (i != authors.Count - 1)
                    {
                        result += authors[i] + ";";
                    }
                    else
                    {
                        result += authors[i];
                    }
                }
                return result;
            }
        }
    }
}
