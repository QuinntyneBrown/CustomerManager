using System;
using System.Collections.Generic;
using CustomerManager.Dtos;
using CustomerManager.Data;
using System.Linq;

namespace CustomerManager.Services
{
    public class CustomerService : ICustomerService
    {
        public CustomerService(IUow uow, ICacheProvider cacheProvider)
        {
            _uow = uow;
            _repository = uow.Customers;
            _cache = cacheProvider.GetCache();
        }

        public CustomerAddOrUpdateResponseDto AddOrUpdate(CustomerAddOrUpdateRequestDto request)
        {
            var entity = _repository.GetAll()
                .FirstOrDefault(x => x.Id == request.Id && x.IsDeleted == false);
            if (entity == null) _repository.Add(entity = new Models.Customer());
            entity.Name = request.Name;
            _uow.SaveChanges();
            return new CustomerAddOrUpdateResponseDto(entity);
        }

        public ICollection<CustomerDto> Get()
        {
            ICollection<CustomerDto> response = new HashSet<CustomerDto>();
            var entities = _repository.GetAll().Where(x => x.IsDeleted == false).ToList();
            foreach (var entity in entities) { response.Add(new CustomerDto(entity)); }
            return response;
        }

        public CustomerDto GetById(int id)
        {
            return new CustomerDto(_repository.GetAll().Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefault());
        }

        public dynamic Remove(int id)
        {
            var entity = _repository.GetById(id);
            entity.IsDeleted = true;
            _uow.SaveChanges();
            return id;
        }

        protected readonly IUow _uow;
        protected readonly IRepository<Models.Customer> _repository;
        protected readonly ICache _cache;
    }
}
