using Application.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CreditCards.Rules
{
    public class CreditCardBusinessRules
    {
        
        private readonly ICreditCartRepository _creditCartRepository;
        public CreditCardBusinessRules(ICreditCartRepository creditCartRepository)
        {
            _creditCartRepository = creditCartRepository;
        }


    }
}
