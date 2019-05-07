namespace Copernicus.API.Dtos
{
    public class ProviderDto
    {
        public ProviderDto(string name, string id)
        {
            Name = name;
            Id = id;
        }

        public string Name { get; set; }
        public string Id { get; set; }
    }
}