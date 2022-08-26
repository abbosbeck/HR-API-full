using Dadabase;
using Dadabase.Entity;
using Microsoft.AspNetCore.Authorization;
using Post2.Modules;

namespace Post2.Services
{
    public class AddressCRUDService : IGenericCRUDService<AddressModel>
    {

        private readonly IGenericRepositroy<Address> _addressRepository;
        public AddressCRUDService(IGenericRepositroy<Address> addressRepository)
        {
            _addressRepository = addressRepository;
        }
        public async Task<AddressModel> Create(AddressModel model)
        {
            var address = new Address
            {
                Id = model.Id,
                AddressLine1 = model.AddressLine1,
                AddressLine2 = model.AddressLine2,
                PostalCode = model.PostalCode,
                Country = model.Country,
                City = model.City
            };
            var creataeEmployee = await _addressRepository.Create(address);
            var result = new AddressModel
            {
                Id = creataeEmployee.Id,
                AddressLine1 = creataeEmployee.AddressLine1,
                AddressLine2 = creataeEmployee.AddressLine2,
                PostalCode = creataeEmployee.PostalCode,
                Country = creataeEmployee.Country,
                City = creataeEmployee.City
            };
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            return await _addressRepository.Delete(id);
        }

        public async Task<AddressModel> GetById(int id)
        {
            var model = await _addressRepository.GetById(id);
            var result = new AddressModel
            {
                Id = model.Id,
                AddressLine1 = model.AddressLine1,
                AddressLine2 = model.AddressLine2,
                PostalCode = model.PostalCode,
                Country = model.Country,
                City = model.City
            };
            return result;
        }
        public async Task<IEnumerable<AddressModel>> Get()
        {
            var result = new List<AddressModel>();
            var addresses = await _addressRepository.GetAll();
            foreach (var address in addresses)
            {
                var model = new AddressModel
                {
                    Id = address.Id,
                    AddressLine1 = address.AddressLine1,
                    AddressLine2 = address.AddressLine2,
                    PostalCode = address.PostalCode,
                    Country = address.Country,
                    City = address.City
                };
                result.Add(model);
            }
            return result;
        }

        public async Task<AddressModel> Update(int id, AddressModel model)
        {
            var address = new Address
            {
                Id = model.Id,
                AddressLine1 = model.AddressLine1,
                AddressLine2 = model.AddressLine2,
                PostalCode = model.PostalCode,
                Country = model.Country,
                City = model.City
            };
            var updatedAddress = await _addressRepository.Update(id, address);
            var result = new AddressModel
            {
                Id = updatedAddress.Id,
                AddressLine1 = updatedAddress.AddressLine1,
                AddressLine2 = updatedAddress.AddressLine2,
                PostalCode = updatedAddress.PostalCode,
                Country = updatedAddress.Country,
                City = updatedAddress.City
            };
            return result;
        }
    }
}
