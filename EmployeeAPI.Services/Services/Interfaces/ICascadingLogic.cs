using EmployeeAPI.Data.Models;

namespace EmployeeAPI.Services.Services.Interfaces
{
    public interface ICascadingLogic
    {
        Task<List<Country>> BindCountry();

        Task<List<State>> BindState(int countryId);

        Task<List<City>> BindCity(int stateId);

    }
}
