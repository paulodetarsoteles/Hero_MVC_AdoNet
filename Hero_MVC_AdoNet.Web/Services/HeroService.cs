﻿using Hero_MVC_AdoNet.DAL.Repositories.Interfaces;
using Hero_MVC_AdoNet.Domain.Models;
using Hero_MVC_AdoNet.Web.Services.Interfaces;
using Hero_MVC_AdoNet.Web.ViewModels;

namespace Hero_MVC_AdoNet.Web.Services
{
    public class HeroService : IHeroService
    {
        private readonly IHeroRepository _heroRepository;
        private readonly IMovieRepository _movieRepository;
        private readonly ISecretRepository _secretRepository;
        private readonly IWeaponRepository _weaponRepository;

        public HeroService(IHeroRepository heroRepository, IMovieRepository movieRepository, ISecretRepository secretRepository, IWeaponRepository weaponRepository)
        {
            _heroRepository = heroRepository;
            _movieRepository = movieRepository;
            _secretRepository = secretRepository;
            _weaponRepository = weaponRepository;
        }

        public List<HeroViewModel> GetAll()
        {
            try
            {
                List<Hero> heroes = _heroRepository.GetAll();

                if (heroes.Count == 0)
                    return null;

                List<HeroViewModel> result = new();

                foreach (Hero hero in heroes)
                    result.Add(new HeroViewModel
                    {
                        HeroId = hero.HeroId,
                        Name = hero.Name,
                        Active = hero.Active,
                        UpdateDate = hero.UpdateDate
                    });

                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro: {e.Message} - {e.StackTrace} - {DateTime.Now}");
                throw new(e.Message);
            }
        }

        public HeroViewModel GetById(int id)
        {
            try
            {
                Hero hero = _heroRepository.GetById(id);

                if (hero is null)
                    return null;

                HeroViewModel result = new();

                result.HeroId = hero.HeroId;
                result.Name = hero.Name;
                result.Active = hero.Active;
                result.UpdateDate = hero.UpdateDate;

                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro: {e.Message} - {e.StackTrace} - {DateTime.Now}");
                throw new(e.Message);
            }
        }

        public bool Insert(HeroViewModel model)
        {
            try
            {
                Hero hero = new()
                {
                    HeroId = model.HeroId,
                    Name = model.Name,
                    Active = model.Active,
                    UpdateDate = model.UpdateDate
                };

                return _heroRepository.Insert(hero);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro: {e.Message} - {e.StackTrace} - {DateTime.Now}");
                throw new(e.Message);
            }
        }

        public bool Update(HeroViewModel model)
        {
            try
            {
                Hero hero = new()
                {
                    HeroId = model.HeroId,
                    Name = model.Name,
                    Active = model.Active,
                    UpdateDate = model.UpdateDate
                };

                return _heroRepository.Update(hero);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro: {e.Message} - {e.StackTrace} - {DateTime.Now}");
                throw new(e.Message);
            }
        }

        public bool Delete(int id)
        {
            try
            {
                return _heroRepository.Delete(id);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro: {e.Message} - {e.StackTrace} - {DateTime.Now}");
                throw new(e.Message);
            }
        }

        #region Methods of Verify Relations

        public int VerifyRelationWithSecret(int id)
        {
            try
            {
                return _heroRepository.VerifyRelationWithSecret(id);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro: {e.Message} - {e.StackTrace} - {DateTime.Now}");
                throw new(e.Message);
            }
        }

        public int VerifyRelationWithWeapons(int id)
        {
            try
            {
                return _heroRepository.VerifyRelationWithWeapons(id);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro: {e.Message} - {e.StackTrace} - {DateTime.Now}");
                throw new(e.Message);
            }
        }

        public int VerifyRelationWithMovies(int id)
        {
            try
            {
                return _heroRepository.VerifyRelationWithMovies(id);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro: {e.Message} - {e.StackTrace} - {DateTime.Now}");
                throw new(e.Message);
            }
        }

        #endregion
    }
}
