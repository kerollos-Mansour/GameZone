using GameZone.Attributes;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Runtime.CompilerServices;

namespace GameZone.ViewModels
{
	public class CreateGameFormViewModel:GameFormViewModel
	{
		//[MaxLength(250)]
		//public string Name { get; set; } = string.Empty;
		//[Display(Name = "Category")]
		//public int CategoryId { get; set; }
		//public IEnumerable<SelectListItem>Categories { get; set; }=Enumerable.Empty<SelectListItem>();
		//[Display(Name = "Supported Devices")]

		//public List<int> SelectedDevices { get; set; } = default!; // new List<int>();  ba3mel intialization
		//public IEnumerable<SelectListItem> Devices { get; set; } = Enumerable.Empty<SelectListItem>();
		//[MaxLength(2500)]
		//public string Description { get; set; } = string.Empty;
		// validati extentions
		[AllowedExtensions(FileSettings.AllowedExtensions),
			MaxFileSize(FileSettings.MaxFileSizeInB)]
		public IFormFile Cover { get; set; } = default!;


	}
}
