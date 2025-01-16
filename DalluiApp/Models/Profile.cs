using System;
namespace DalluiApp.Models
{
	public class Profile
	{
		public required string ProfileImage { get; set; }

        public required string Name { get; set; }

        public int NoOfPhotos { get; set; }
    }
}

