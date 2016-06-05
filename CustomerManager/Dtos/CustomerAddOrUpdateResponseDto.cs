namespace CustomerManager.Dtos
{
    public class CustomerAddOrUpdateResponseDto: CustomerDto
    {
        public CustomerAddOrUpdateResponseDto(Models.Customer entity)
        :base(entity)
        {

        }
    }
}
