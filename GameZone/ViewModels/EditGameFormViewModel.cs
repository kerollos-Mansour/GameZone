using GameZone.Attributes;

namespace GameZone.ViewModels
{
    public class EditGameFormViewModel : GameFormViewModel
    {
        //[MaxLength(250)]
        //public string Name { get; set; } = string.Empty;
        //[Display(Name = "Category")]
        //public int CategoryId { get; set; }
        //public IEnumerable<SelectListItem> Categories { get; set; } = Enumerable.Empty<SelectListItem>();
        //[Display(Name = "Supported Devices")]

        //public List<int> SelectedDevices { get; set; } = default!; // new List<int>();  ba3mel intialization
        //public IEnumerable<SelectListItem> Devices { get; set; } = Enumerable.Empty<SelectListItem>();
        //[MaxLength(2500)]
        //public string Description { get; set; } = string.Empty;
        // validati extentions
        public int Id { get; set; }
        public string? CurrentCover { get; set; }
        [AllowedExtensions(FileSettings.AllowedExtensions),
            MaxFileSize(FileSettings.MaxFileSizeInB)]
        public IFormFile? Cover { get; set; } = default!;

    }
}
