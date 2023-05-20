using AutoMapper;
using CommerceCashFlow.Application.Models;
using CommerceCashFlow.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceCashFlow.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Merchant, MerchantViewModel>();
        }
    }
}
