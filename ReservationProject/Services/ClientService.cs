using AutoMapper;
using ReservationProject.Context;
using ReservationProject.DTO;
using ReservationProject.Interfaces;
using ReservationProject.Entities;
using Microsoft.EntityFrameworkCore;
using ReservationProject.Enums;
using ReservationProject.EnumExtensions;

namespace ReservationProject.Services
{
    public class ClientService : IClientService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public ClientService(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<Client> Add(ClientCreationDTO clientDto)
        {
            var Client = mapper.Map<Client>(clientDto);
            Client.Status = GetStatus(Client.Age);

            await dbContext.Clients.AddAsync(Client);
            await dbContext.SaveChangesAsync();

            return Client;
        }


        public async Task<ClientDTO?> GetClientById(int id)
        {
            var ClienteFound = await dbContext.Clients.FirstOrDefaultAsync(c => c.Id == id);
            return mapper.Map<ClientDTO>(ClienteFound);
        }

        public async Task<IEnumerable<ClientDTO>> GetClients()
        {
            var Clients = await dbContext.Clients.ToListAsync();

            if (!Clients.Any())
                return Enumerable.Empty<ClientDTO>();

            return mapper.Map<IEnumerable<ClientDTO>>(Clients);
        }
        public async Task<Client?> Delete(int id)
        {
            var ClientFound = await dbContext.Clients.FirstOrDefaultAsync(c => c.Id == id);
            if (ClientFound is null)
                return null;

            dbContext.Clients.Remove(ClientFound);
            await dbContext.SaveChangesAsync();

            return ClientFound;
        }

        public async Task<Client?> Update(ClientUpdateDTO clientDto)
        {
            var ClientFound = await dbContext.Clients.AnyAsync(c => c.Id == clientDto.Id);

            if (!ClientFound)
                return null;

            var Client = mapper.Map<Client>(clientDto);
            Client.Status = GetStatus(Client.Age);

            dbContext.Clients.Update(Client);
            await dbContext.SaveChangesAsync();

            return Client;
        }

        private string GetStatus(int? age)
        {
            if (age < 21)
                return  ClientStatus.Due.ConvertToString();

           return ClientStatus.Available.ConvertToString();
            
        }
    }
}
