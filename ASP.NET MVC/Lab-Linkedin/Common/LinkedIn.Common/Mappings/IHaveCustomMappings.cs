namespace LinkedIn.Common.Mappings
{
    using AutoMapper;

    public interface IHaveCustomMappings
    {
        void CreateMappings(IConfiguration configuration);
    }
}
