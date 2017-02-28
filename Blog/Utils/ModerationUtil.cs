using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Utils
{
    public static class ModerationUtil
    {
        public static void Verify(BlogContext db, long postId, string commentText)
        {
            var badWords = db.BadWords.Select(i => i.Word).ToList();
            var splitedText = commentText.Split(new char[] { ' ', ',', '.', '!', '?' }).ToList();

            string newCommentText = "";

            for (int i = 0; i < splitedText.Count; i++)
            {
                if (badWords.Any(w => w == splitedText[i]))
                {
                    string replasementWord = "";
                    for (int J = 0; J < splitedText[i].Length; J++)
                    {
                        replasementWord = replasementWord + "*";
                    }
                    splitedText[i] = replasementWord;
                }

                newCommentText = newCommentText + " " + splitedText[i];

            }

            var comment = new Comment()
            {
                PostId = postId,
                DateCreated = DateTime.Now,
                Text = newCommentText
            };

            db.Comments.Add(comment);
            db.SaveChanges();
        }
    }
}