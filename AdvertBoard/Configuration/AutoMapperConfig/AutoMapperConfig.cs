using AutoMapper;

namespace AdvertBoard.Configuration.AutoMapperConfig
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration Initialize()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<WebProfile>();
                cfg.AddProfile<BuisinessLogicProfile>();
            });

            return config;
        }
    }
}