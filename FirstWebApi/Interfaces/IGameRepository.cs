﻿using FirstWebApi.Models;

namespace FirstWebApi.Interfaces
{
    public interface IGameRepository
    {
        IEnumerable<Game> GetAll();
        Game? GetById(int id);
        int Create(Game game);
        bool Update(int id, Game game);
        bool Delete(int id);

    }
}
