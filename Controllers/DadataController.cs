using Dadata.Model;
using Dadata;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Dadata_API.Dto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Dadata_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DadataController : Controller
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        private readonly IConfiguration Configuration;
        private readonly IMapper _mapper;
        public DadataController(IConfiguration configuration, IMapper mapper)
        {
            Configuration = configuration;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetDadataInfo")]
        [ProducesResponseType(200, Type = typeof(IAsyncEnumerable<DestinationDto>))]
        public async IAsyncEnumerable<DestinationDto> GetAsync(string request)
        {                        
            var authOptions = new Auth();
            Configuration.GetSection(Auth.DadataAuth).Bind(authOptions);

            var api = new CleanClientAsync(authOptions.token, authOptions.secret);
            var address = await api.Clean<Address>(request);

            if (address != null)
            {
                var destionation = _mapper.Map<DestinationDto>(address);
                Logger.Info("it`s working");
                yield return destionation;
            }          
            
        }

       
    }
}
