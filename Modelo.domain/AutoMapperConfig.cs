using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Modelo.domain
{
    public class AutoMapperConfig
    {
        public static IMapper Initialize()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Aluno, Aluno>(); 
            });
            return config.CreateMapper();
        }

    }
}
