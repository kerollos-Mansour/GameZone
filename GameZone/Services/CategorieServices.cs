

namespace GameZone.Services
{
	public class CategorieServices : ICategorieServices
	{
		public readonly ApplicationDb _context; // 3ashan at3amel ma3a el DB

		public CategorieServices(ApplicationDb context)
		{
			_context = context;
		}
		public IEnumerable<SelectListItem> GetSelectList()
		{
			return _context.Categories
							.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
							.OrderBy(c => c.Text).AsNoTracking()

							.ToList();
		}
	}
}
