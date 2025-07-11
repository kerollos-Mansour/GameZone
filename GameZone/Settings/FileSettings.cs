﻿using static System.Net.Mime.MediaTypeNames;

namespace GameZone.Settings
{
	public static class FileSettings
	{
		public const string ImagesPath ="/assets/images/games";
		public const string AllowedExtensions =".jpg,.jpeg,.png";
		public const int MaxFileSizeInMB =1;
		public const int MaxFileSizeInB = MaxFileSizeInMB*1024*1024;
	}
}
