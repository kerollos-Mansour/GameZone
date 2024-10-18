namespace GameZone.Services
{
	public interface IGamesServices
	{
		// kol ma add func lazem agy hena 
	
		IEnumerable<Game> GetAll();
        Game? GetById(int id);
        Task Create(CreateGameFormViewModel model); //void
        Task<Game?> Edit(EditGameFormViewModel model);
		bool Delete (int id);	
	}
}
