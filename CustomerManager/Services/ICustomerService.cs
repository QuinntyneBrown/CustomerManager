using CustomerManager.Dtos;
using System.Collections.Generic;

namespace CustomerManager.Services
{
    public interface ICustomerService
    {
        CustomerAddOrUpdateResponseDto AddOrUpdate(CustomerAddOrUpdateRequestDto request);
        ICollection<CustomerDto> Get();
        CustomerDto GetById(int id);
        dynamic Remove(int id);
    }
}
