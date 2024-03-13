using DataAccess.Data.Domains;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace Mappers;

public static class ManualMapper
{
    #region Account
    public static AccountDTO Map(Account value)
    {
        AccountDTO result = new AccountDTO();
        result.IdAccount = value.IdAccount;
        result.Username = value.Username;
        result.Password = value.Password;
        result.Nickname = value.Nickname;
        result.Email = value.Email;
        result.PhoneNumber = value.PhoneNumber;
        result.Role = value.Role;

        return result;
    }

    public static Account Map(AccountDTO value)
    {
        Account result = new Account();
        result.IdAccount = value.IdAccount;
        result.Username = value.Username;
        result.Password = value.Password;
        result.Nickname = value.Nickname;
        result.Email = value.Email;
        result.PhoneNumber = value.PhoneNumber;
        result.Role = value.Role;

        return result;
    }

    public static MyProfileDTO Map(Account value, List<Transport> transports)
    {
        var result = new MyProfileDTO();
/*        result.MyTransport = transports;*/
        result.Username = value.Username;
        result.Password = value.Password;
        result.Nickname = value.Nickname;
        result.Email = value.Email;
        result.PhoneNumber = value.PhoneNumber;

        return result;
    }

    public static List<AccountDTO> Map(List<Account> accounts)
    {
        return accounts.Select(account => Map(account)).ToList();
    }
    #endregion

    #region Transport
    public static TransportDTO Map(Transport value)
    {
        TransportDTO result = new TransportDTO();
        result.IdTransport = value.IdTransport;
        result.Id_Account = value.Id_Account;
        result.Id_Location = value.Id_Location;
        result.StartLocation = value.StartLocation;
        result.Amount = value.Amount;
        result.DispatchDate = value.DispatchDate;
        result.DeliveryDate = value.DeliveryDate;
        result.EstimateDelivery = value.EstimateDelivery;
        result.Status = value.Status;

        return result;
    }

    public static Transport Map(TransportDTO value)
    {
        Transport result = new Transport();
        result.IdTransport = value.IdTransport;
        result.Id_Account = value.Id_Account;
        result.Id_Location = value.Id_Location;
        result.StartLocation = value.StartLocation;
        result.Amount = value.Amount;
        result.DispatchDate = value.DispatchDate;
        result.DeliveryDate = value.DeliveryDate;
        result.EstimateDelivery = value.EstimateDelivery;
        result.Status = value.Status;

        return result;
    }

    public static DetailsTransportDTO Map(TransportDetails value)
    {
        var result = new DetailsTransportDTO();
        result.StartLocation = value.StartLocation;
        result.Amount = value.Amount;
        result.DispatchDate = value.DispatchDate;
        result.DeliveryDate = value.DeliveryDate;
        result.Status = value.Status;

        return result;
    }

    public static TransportDetails Map(DetailsTransportDTO value)
    {
        var result = new TransportDetails();
        result.StartLocation = value.StartLocation;
        result.Amount = value.Amount;
        result.DispatchDate = value.DispatchDate;
        result.DeliveryDate = value.DeliveryDate;
        result.Status = value.Status;

        return result;
    }

    public static List<TransportDTO> Map(List<Transport> transport)
    {
        return transport.Select(transport => Map(transport)).ToList();
    }
    #endregion

    #region Gate
    public static Gate Map(GateDTO value)
    {
        Gate result = new Gate();
        result.IdGate = value.IdGate;
        result.Id_Location = value.Id_Location;
        result.Status = value.Status;
        result.Available_Time = value.Available_Time;
        result.TimeOfUnpacking = value.TimeOfUnpacking;

        return result;
    }

    public static GateDTO Map(Gate value)
    {
        GateDTO result = new GateDTO();
        result.IdGate = value.IdGate;
        result.Id_Location = value.Id_Location;
        result.Status = value.Status;
        result.Available_Time = value.Available_Time;
        result.TimeOfUnpacking = value.TimeOfUnpacking;

        return result;
    }
    public static List<GateDTO> Map(List<Gate> gate)
    {
        return gate.Select(gate => Map(gate)).ToList();
    }
    #endregion

    #region Location
    public static Location Map(LocationDTO value)
    {
        Location result = new Location();
        result.IdLocation = value.IdLocation;
        result.Adress = value.Adress;

        return result;
    }

    public static LocationDTO Map(Location value)
    {
        LocationDTO result = new LocationDTO();
        result.IdLocation = value.IdLocation;
        result.Adress = value.Adress;

        return result;
    }

    public static List<LocationDTO> Map(List<Location> location)
    {
        return location.Select(location => Map(location)).ToList();
    }
    #endregion
}
