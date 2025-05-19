using MultiShop.Catalog.Dtos.ContactDtos;

namespace MultiShop.Catalog.Services.ContactServices
{
    public interface IContactServices
    {
        Task<List<ResultContactDto>> GetAllContactAsync();
        Task CreateContactAsync(CreateContactDto createContactDto);
        Task UpdateContactAsync(UpdateContactDto updateContactDto);
        Task DeleteContactAsync(string id);
        Task<GetByIdContactDto> GetByIDContactAsync(string id);
    }
}
