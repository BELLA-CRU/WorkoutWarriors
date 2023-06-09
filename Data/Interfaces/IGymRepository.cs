﻿using WorkoutWarriors.Models;
using WorkoutWarriors.View_Model;

namespace WorkoutWarriors.Data.Interfaces
{
    public interface IGymRepository
    {
        Task<IEnumerable<Gym>> GetAll();

        Task<Gym> GetByIdAsync(int id);
        Task<IEnumerable<Gym>> GetClubByCity(string city);
        bool Add(Gym gym);
        bool Update(Gym gym);
        bool Delete(Gym gym);
        bool Save();

    }
}
