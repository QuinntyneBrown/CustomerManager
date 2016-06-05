namespace CustomerManager.Dtos
{
    public class CustomerDto
    {
        public CustomerDto()
        {

        }

        public CustomerDto(Models.Customer entity)
        {
            Id = entity.Id;
            Name = entity.Name;
        }

        public int? Id { get; set; }
        public string Name { get; set; }
    }
}
