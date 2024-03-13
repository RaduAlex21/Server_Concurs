using DataAccess.Connection;
using DataAccess.Data.Domains;
using DataAccess.Factory;
using DTO;
using Mappers;
using Services.ModelServices.Contracts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validators;

namespace Services.ModelServices;

public class GateService : IGateService
{
    private readonly IFactory factory;
    private readonly IValidator<GateDTO> validator;

    public GateService(IFactory factory, IValidator<GateDTO> validator)
    {
        this.factory = factory;
        this.validator = validator;
    }

    public async Task<bool> DeleteAsync(GateDTO value)
    {
        var gate = new Gate() { IdGate = value.IdGate };
        return await this.factory.GateRepository.DeleteAsync(gate);
    }

    public async Task<List<GateDTO>> GetAllAsync()
    {
        var gate = await this.factory.GateRepository.GetAllAsync();
        return ManualMapper.Map(gate);
    } 

    public async Task<GateDTO> InsertAsync(GateDTO value)
    {
        var existentAccount = this.factory.GateRepository.FirstOrDefaultAsync(x => x.Available_Time == value.Available_Time);

        if (existentAccount != null)
        {
            throw new Exception("Exista");
        }

        this.validator.Validate(value);

        if (this.validator.Errors.Any())
        {
            throw new Exception(this.validator.GetErrors());
        }

        var gate = ManualMapper.Map(value);

        var gateDTO = await this.factory.GateRepository.InsertAsync(gate);

        if (gateDTO != null)
        {
            return ManualMapper.Map(gateDTO);
        }

        throw new Exception("Eroare la inserare");
    }

    public async Task<GateDTO> SearchByIdAsync(int id)
    {
        var existentGate = await this.factory.GateRepository.FirstOrDefaultAsync(x => x.IdGate == id);

        if (existentGate == null)
            throw new Exception("Gate null");

        return ManualMapper.Map(existentGate);

    }

    public async Task<GateDTO> UpdateAsync(GateDTO value)
    {
        var existentGate = this.factory.GateRepository.FirstOrDefaultAsync(x => x.IdGate == value.IdGate);
         
        if (existentGate == null)
        {
            throw new Exception("Gate incorrect");
        } 

        this.validator.Validate(value);

        if (this.validator.Errors.Any())
        {
            throw new Exception(this.validator.GetErrors());
        }

        var gate = ManualMapper.Map(value);

        var gateDTO = await this.factory.GateRepository.UpdateAsync(gate);

        if (gateDTO != null)
        {
            return ManualMapper.Map(gateDTO);
        }

        throw new Exception("Eroare la update");
    }
}
