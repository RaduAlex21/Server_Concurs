using DataAccess.Data.Domains;
using DataAccess.Factory;
using DTO;
using Mappers;
using Services.ModelServices.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validators;

namespace Services.ModelServices;

public class LocationService : ILocationService
{
    private readonly IFactory factory;
    private readonly IValidator<LocationDTO> validator;

    public LocationService(IFactory factory, IValidator<LocationDTO> validator)
    {
        this.factory = factory;
        this.validator = validator;
    }
    public async Task<bool> DeleteAsync(LocationDTO value)
    {
        var location = new Location() { IdLocation = value.IdLocation };
        return await this.factory.LocationRepository.DeleteAsync(location);
    }

    public async Task<List<LocationDTO>> GetAllAsync()
    {
        var location = await this.factory.LocationRepository.GetAllAsync();
        return ManualMapper.Map(location);
    }

    public async Task<LocationDTO> InsertAsync(LocationDTO value)
    {
        var existentLocation = this.factory.LocationRepository.FirstOrDefaultAsync( x => x.Adress == value.Adress);

        if (existentLocation != null)
        {
            throw new Exception("locatie existenta");
        }

        this.validator.Validate(value);

        if (this.validator.Errors.Any())
        {
            throw new Exception(this.validator.GetErrors());
        }

        var location = ManualMapper.Map(value);

        var locationDTO = await this.factory.LocationRepository.InsertAsync(location);

        if (locationDTO != null)
        {
            return ManualMapper.Map(locationDTO);
        }

        throw new Exception("Eroare la inserare");
    }

    public async Task<LocationDTO> SearchByIdAsync(int id)
    {
        var existentLocation = await this.factory.LocationRepository.FirstOrDefaultAsync(x => x.IdLocation == id);

        if (existentLocation == null)
            throw new Exception("Location null");

        return ManualMapper.Map(existentLocation);
    }

    public async Task<LocationDTO> UpdateAsync(LocationDTO value)
    {
        var existentLocation = this.factory.LocationRepository.FirstOrDefaultAsync(x => x.IdLocation == value.IdLocation);

        if (existentLocation != null)
        {
            throw new Exception("locatie existenta");
        }

        this.validator.Validate(value);

        if (this.validator.Errors.Any())
        {
            throw new Exception(this.validator.GetErrors());
        }

        var location = ManualMapper.Map(value);

        var locationDTO = await this.factory.LocationRepository.UpdateAsync(location);

        if (locationDTO != null)
        {
            return ManualMapper.Map(locationDTO);
        }

        throw new Exception("Eroare la inserare");
    }
}
