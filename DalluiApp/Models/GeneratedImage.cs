using System;
namespace DalluiApp.Models
{
	public class GeneratedImage
	{
        public required string ImagePath { get; set; }

        public required string MainKeyword { get; set; }

        public required List<string> Keywords { get; set; }
    }
}

