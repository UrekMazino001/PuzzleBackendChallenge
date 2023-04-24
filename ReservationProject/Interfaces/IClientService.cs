using ReservationProject.DTO;
using ReservationProject.Entities;

namespace ReservationProject.Interfaces
{
    public interface IClientService
    {
        Task<IEnumerable<ClientDTO>> GetClients();
        Task<ClientDTO?> GetClientById(int id);
        Task<Client> Add(ClientCreationDTO clientDto);
        Task<Client?> Update(ClientUpdateDTO clientDto);
        Task<Client?> Delete(int id);
    }
}
