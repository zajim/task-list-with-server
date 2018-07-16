using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TL.Service.Business
{
    public class BaseBusiness
    {
        public BaseBusiness(IMapper mapper)
        {
            Mapper = mapper;
        }

        public IMapper Mapper { get; }
    }
}
