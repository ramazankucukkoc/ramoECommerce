using Application.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Countries.Rules
{
    public class CountryBusinessRules
    {
        private readonly ICountryRepository _countryRepository;

        public CountryBusinessRules(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }
    }
}
