

using GameZone.Models;

namespace GameZone.Controllers
{
    public class GamesController : Controller
    {

        public readonly ApplicationDb _context; // 3ashan at3amel ma3a el DB
        private readonly ICategorieServices _CategorieServices;
		private readonly IDevicesServices _IDevicesServices;
		private readonly IGamesServices _GamesServices;

		public GamesController(ApplicationDb context, ICategorieServices categorieServices, IDevicesServices iDevicesServices, IGamesServices gamesServices)
		{
			_context = context;
			_CategorieServices = categorieServices;
			_IDevicesServices = iDevicesServices;
			_GamesServices = gamesServices;
		}

		public IActionResult Index()
        {
           {
                var games = _GamesServices.GetAll();
                return View(games);
            }

        }
        public IActionResult Details (int id)
        {
            var game=_GamesServices.GetById(id);
            if (game == null) { return NotFound(); }
            return View(game);
        }
        [HttpGet]
        public IActionResult Create() {
            //   var category = _context.Categories.ToList();

            CreateGameFormViewModel viewModel = new() //hena bamal el ctegory ely gaya men DB
            {
                Categories = _CategorieServices.GetSelectList(),
                Devices = _IDevicesServices.GetSelectList()
			}; // 3amel projection ya3ny ghayart no3ha ... hawelt col categ => select list item
        return View(viewModel);  
        }
		[HttpPost]
        [ValidateAntiForgeryToken] // layer hemaya edafeya
		public async Task<IActionResult> Create(CreateGameFormViewModel model)
        {
            if (!ModelState.IsValid)
			{
                model.Categories = _CategorieServices.GetSelectList();

                model.Devices = _IDevicesServices.GetSelectList();
				return View(model);
			}
            // save game in DB
            await _GamesServices.Create(model);
            // save cover no server
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id) { 
        // make select for obj where its Id == id
        var game= _GamesServices.GetById(id);
            if (game == null)
               return NotFound();

            EditGameFormViewModel viewModel = new()
            {
                Id = id,
                Name = game.Name,
                Description = game.Description,
                CategoryId = game.CategoryId,
                SelectedDevices = game.Devices.Select(d => d.DeviceId).ToList(),
                Categories = _CategorieServices.GetSelectList(),
                Devices= _IDevicesServices.GetSelectList(),
                CurrentCover = game.Cover,
            };
        return View(viewModel) ;
        }
		[HttpPost]
		[ValidateAntiForgeryToken] // layer hemaya edafeya
		public async Task<IActionResult> Edit(EditGameFormViewModel model)
		{
			if (!ModelState.IsValid)
			{
				model.Categories = _CategorieServices.GetSelectList();

				model.Devices = _IDevicesServices.GetSelectList();
				return View(model);
			}
			// save game in DB
			var game =  await _GamesServices.Edit(model);
            if (game == null)
                return BadRequest();

			// save cover no server
			return RedirectToAction(nameof(Index));
		}
        [HttpDelete]
        public IActionResult Delete(int id) {

            var isdeleted =_GamesServices.Delete(id);
            return isdeleted ? Ok() : BadRequest();
        }
	}

}
