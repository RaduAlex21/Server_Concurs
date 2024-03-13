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

public class TransportService : ITransportService
{
    private readonly IFactory factory;
    private readonly IValidator<TransportDTO> validator;

    public TransportService(IFactory factory, IValidator<TransportDTO> validator)
    {
        this.factory = factory;
        this.validator = validator;
    }

    public async Task<bool> DeleteAsync(TransportDTO value)
    {
        var transport = new Transport() { IdTransport = value.IdTransport };
        return await this.factory.TransportRepository.DeleteAsync(transport);
    }

    public async Task<List<TransportDTO>> GetAllAsync()
    {
        var transport = await this.factory.TransportRepository.GetAllAsync();
        return ManualMapper.Map(transport);
    }

    public async Task<TransportDTO> InsertAsync(TransportDTO value)
    {
        var existentTransport = this.factory.TransportRepository.FirstOrDefaultAsync(x => x.Id_Location == value.Id_Location);

        if (existentTransport != null)
        {
            throw new Exception("transport in locatia respectiva existent");
        }

        this.validator.Validate(value);

        if (this.validator.Errors.Any())
        {
            throw new Exception(this.validator.GetErrors());
        }

        var transport = ManualMapper.Map(value);

        var transportDTO = await this.factory.TransportRepository.InsertAsync(transport);

        if (transportDTO != null)
        {
            return ManualMapper.Map(transportDTO);
        }

        throw new Exception("Eroare la inserare");
    }

    public async Task<TransportDTO> SearchByIdAsync(int id)
    {
        var transport = await this.factory.TransportRepository.FirstOrDefaultAsync(x => x.IdTransport == id);

        if (transport == null)
            throw new Exception("Location null");

        return ManualMapper.Map(transport);
    }

    public async Task<TransportDTO> UpdateAsync(TransportDTO value)
    {
        var existentTransport = this.factory.TransportRepository.FirstOrDefaultAsync(x => x.Id_Account == value.Id_Account);

        if (existentTransport != null)
        {
            throw new Exception("nu exista id-ul");
        }

        this.validator.Validate(value);

        if (this.validator.Errors.Any())
        {
            throw new Exception(this.validator.GetErrors());
        }

        var transport = ManualMapper.Map(value);

        var transportDTO = await this.factory.TransportRepository.UpdateAsync(transport);

        if (transportDTO != null)
        {
            return ManualMapper.Map(transportDTO);
        }

        throw new Exception("Eroare la inserare");
    }
}
