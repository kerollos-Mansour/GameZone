namespace GameZone.Services
{
	public interface ICategorieServices
	{
		IEnumerable<SelectListItem> GetSelectList();
	}
}
