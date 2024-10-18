



namespace GameZone.Services
{
	public class GamesServices : IGamesServices
	{
		public readonly ApplicationDb _context; // 3ashan at3amel ma3a el DB
		public readonly IWebHostEnvironment _WebHostEnvironment;
		private readonly string _imagesPath;

		public GamesServices(ApplicationDb context, IWebHostEnvironment webHostEnvironment)
		{
			_context = context;
			_WebHostEnvironment = webHostEnvironment;
			_imagesPath = $"{_WebHostEnvironment.WebRootPath}{FileSettings.ImagesPath}"; //v17
		}
		public IEnumerable<Game> GetAll() //v27 ..hena ba3mel read
		{
        var games =_context.Games
				.Include(g=>g.Category)
				.Include(g=>g.Devices)
				.ThenInclude(d=>d.Device)
				.AsNoTracking()
				.ToList(); 
			return games;
			
		}
        public Game? GetById(int id)
        {
            var games = _context.Games
                 .Include(g => g.Category)
                 .Include(g => g.Devices)
                 .ThenInclude(d => d.Device)
                 .AsNoTracking()
                 .SingleOrDefault(g=>g.Id==id);
            return games;
        }
        public async Task Create(CreateGameFormViewModel model)
		{
			#region save photo on server
			//var CoverName = $"{Guid.NewGuid()}{Path.GetExtension(model.Cover.FileName)}";
			//var path = Path.Combine(_imagesPath, CoverName); // elmakan + Name
			//												 // elmakan ely save gowah el cover
			//using var stream = File.Create(path);
			//await model.Cover.CopyToAsync(stream); 
			#endregion
			var coverName = await SaveCover(model.Cover);
			Game game = new()
			{
				Name = model.Name,
				Description = model.Description,
                CategoryId=model.CategoryId,
			    Cover= coverName,
				Devices =model.SelectedDevices.Select(d=>new GameDevice { DeviceId =d}).ToList()
				
			};
			_context.Add(game);
			_context.SaveChanges();

		}

		public async Task<Game?> Edit(EditGameFormViewModel model)
		{
			//1 select game from DB
			var game=_context.Games
				.Include(g=>g.Devices)
				.SingleOrDefault(g=>g.Id==model.Id);

			if(game is null)
				return null;

			var hasNewCover =model.Cover != null;
			var oldCover=game.Cover;
			//update data
			game.Name = model.Name;
			game.Description = model.Description;
			game.CategoryId = model.CategoryId;
			game.Devices = model.SelectedDevices.Select(d => new GameDevice { DeviceId = d })
				.ToList();            //hena bagheyer from int ...> string
									  //cover
			if (hasNewCover)
			{ // e3mael save llsor on serever
				game.Cover = await SaveCover(model.Cover!);
			}
			//save updates
			var effectedRows=_context.SaveChanges();
			if (effectedRows > 0)
			{
				if (hasNewCover)
				{
					var cover = Path.Combine(_imagesPath, oldCover);
					File.Delete(cover);
				}
				return game;
			}
			else
			{
				var cover = Path.Combine(_imagesPath, game.Cover);
				File.Delete(cover);

				return null;
			}
		}
		public bool Delete(int id)
		{
			var isDeketed = false;
			//selection
			var game = _context.Games.Find(id);
			if (game is null) { return isDeketed; }

			_context.Games.Remove(game); // or _context.remove(games)
			var effectedrowa=_context.SaveChanges();
			if (effectedrowa > 0)
			{
				isDeketed = true;
				var cover= Path.Combine(_imagesPath, game.Cover);
				File.Delete(cover);	
			}

			return isDeketed;
		}
		private async Task<string> SaveCover(IFormFile cover)
		{
			var CoverName = $"{Guid.NewGuid()}{Path.GetExtension(cover.FileName)}";
			var path = Path.Combine(_imagesPath, CoverName); // elmakan + Name
															 // elmakan ely save gowah el cover
			using var stream = File.Create(path);
			await cover.CopyToAsync(stream);
			return CoverName;
		}

		
	}
	
}
