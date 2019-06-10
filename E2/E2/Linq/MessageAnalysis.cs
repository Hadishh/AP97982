using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.VisualBasic.FileIO;

namespace E2.Linq
{
    public class MessageAnalysis
    {
        public List<MessageData> Messages { get; set; }

        public MessageAnalysis()
        {
            Messages = new List<MessageData>();
        }

        public static MessageAnalysis MessageAnalysisFactory(string csvAddress)
        {
            MessageAnalysis messageAnalysis = new MessageAnalysis();
            using (TextFieldParser parser = new TextFieldParser(csvAddress))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                var fields = parser.ReadFields();

                while (!parser.EndOfData)
                {
                    fields = parser.ReadFields();
                    messageAnalysis.AppendMessage(fields);
                }
            }

            return messageAnalysis;
        }

        public void AppendMessage(string[] fields)
        {
            Messages.Add(new MessageData(fields));
        }

        public MessageData MostRepliedMessage()
        {
            var messageKey = Messages.Where(d => d.ReplyMessageId.HasValue)
                .GroupBy(g => g.ReplyMessageId)
                .OrderByDescending(g => g.Count())
                .First().Key;
            return Messages.Where(d => d.Id == messageKey.Value).First();
        }

        public Tuple<string, int>[] MostPostedMessagePersons()
            => Messages.Where(d => d.Author != "Sauleh Eetemadi" && d.Author != "Ali Heydari")
                .GroupBy(d => d.Author)
                .OrderByDescending(g => g.Count())
                .Take(5)
                .Select(g => Tuple.Create<string, int>(g.Key, g.Count())).ToArray();
        

        public Tuple<string, int>[] MostActivesAtMidNight()
            => Messages.Where(d => d.DateTime.Hour <= 4 && d.DateTime.Hour >= 0)
                .GroupBy(d => d.Author)
                .OrderByDescending(g => g.Count())
                .Take(5)
                .Select(g => Tuple.Create<string, int>(g.Key, g.Count())).ToArray();

        public string StudentWithMostUnansweredQuestions()
                =>  Messages.Where(d => d.Content.Contains("?") || d.Content.Contains("¿"))
                .Where(d => !d.ReplyMessageId.HasValue)
                .GroupBy(d => d.Author)
                .OrderByDescending(g => g.Count())
                .First().Key;
    }
}