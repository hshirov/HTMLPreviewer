using Data.Models;
using System;

namespace UnitTests.Data
{
    public static class HTMLExamples
    {
        public static readonly HTMLExample Example1 = new HTMLExample 
        { 
            Id = 1,
            HTMLCode = "<h1>Test</h1>",
            PreviousHTMLCode = "<h1>Test</h1>",
            CreatedDate = DateTime.Now,
            LastEditedDate = DateTime.Now
        };

        public static readonly HTMLExample Example2 = new HTMLExample
        {
            Id = 2,
            HTMLCode = "<h2>Test2</h2><p>xyz</p>",
            PreviousHTMLCode = "<h2>Test2</h2><p>xyz</p>",
            CreatedDate = DateTime.Now,
            LastEditedDate = DateTime.Now
        };

        public static readonly HTMLExample ExampleToAdd = new HTMLExample
        {
            Id = 0,
            HTMLCode = "<h1>Title</h1><h2>Subtitle</h2>",
            PreviousHTMLCode = "<h1>Title</h1><h2>Subtitle</h2>",
            CreatedDate = DateTime.Now,
            LastEditedDate = DateTime.Now
        };
    }
}
