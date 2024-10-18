
using Microsoft.EntityFrameworkCore;

namespace GameZone.Services
{
	public class DevicesServices : IDevicesServices
	{
		public readonly ApplicationDb _context; // 3ashan at3amel ma3a el DB

		public DevicesServices(ApplicationDb context)
		{
			_context = context;
		}
		public IEnumerable<SelectListItem> GetSelectList()
		{
return _context.Devices.Select(d => new SelectListItem { Value = d.Id.ToString(), Text = d.Name })
				.OrderBy(d => d.Text)
				.AsNoTracking()
				.ToList();
		}
	}
}
