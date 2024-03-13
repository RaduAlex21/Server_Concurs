using DataAccess.Data.Interfaces;

namespace DataAccess.Factory;

public interface IFactory
{
    IAccountRepository AccountRepository { get; }
    ITransportRepository TransportRepository { get; }
    ILocationRepository LocationRepository { get; }
    IGateRepository GateRepository { get; }
}