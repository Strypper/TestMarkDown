using System;
using System.Linq;
using Markdig;
using Markdig.Syntax;
using Markdig.Syntax.Inlines;

namespace MarkdownExample;
    public static class Program
    {
        public static void Main()
        {
            var markdown = File.ReadAllText("TestMarkDown.md");

            markdown = markdown.Replace("\r\n", Environment.NewLine);

            var pipeline = new MarkdownPipelineBuilder().Build();
            var document = Markdown.Parse(markdown, pipeline);

            var headers = document.Descendants<HeadingBlock>();

            foreach (var header in headers)
            {
                var inline = header?.Inline?.FirstOrDefault();
                if (inline is LiteralInline literalInline)
                {
                    Console.WriteLine(literalInline.Content);
                }
            }
        }
    }

