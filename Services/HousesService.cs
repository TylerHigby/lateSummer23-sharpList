using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Models;
using server.Repositories;

namespace server.Services;

public class HousesService
{
    private readonly HousesRepository _repo;
    public HousesService(HousesRepository repo)
    {
        _repo = repo;
    }

    internal House CreateHouse(House houseData)
    {
        House house = _repo.CreateHouse(houseData);
        return house;
    }

    internal string DeleteHouse(int houseId)
    {
        House house = this.GetHouseById(houseId);
        _repo.DeleteHouse(houseId);
        return $"The house with the ID of {house.Id} has been destroyed.";
    }

    internal List<House> GetAllHouses()
    {
        List<House> houses = _repo.GetAllHouses();
        return houses;
    }

    internal House GetHouseById(int houseId)
    {
        House house = _repo.GetHouseById(houseId);
        if (house == null) throw new Exception($"There's no house with the id of {houseId}");
        return house;
    }

    internal House UpdateHouse(House updateData)
    {
        House original = this.GetHouseById(updateData.Id);
        original.Bathrooms = updateData.Bathrooms != null ? updateData.Bathrooms : original.Bathrooms;
        original.Bedrooms = updateData.Bedrooms != null ? updateData.Bedrooms : original.Bedrooms;
        original.Description = updateData.Description ?? original.Description;
        original.ImgUrl = updateData.ImgUrl ?? original.ImgUrl;
        original.Price = updateData.Price != null ? updateData.Price : original.Price;
        original.Sqft = updateData.Sqft != null ? updateData.Sqft : original.Sqft;
        House house = _repo.UpdateHouse(original);
        return house;
    }
}