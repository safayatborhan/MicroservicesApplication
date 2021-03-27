using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Ordering.Application.Mapper
{
    public static class OrderMapper
    {
        /*
         * Automapper in .NET class library :
         * https://www.abhith.net/blog/using-automapper-in-a-net-core-class-library/
         */
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.ShouldMapProperty = p => p.GetMethod is { } && (p.GetMethod.IsPublic || p.GetMethod.IsAssembly);
                cfg.AddProfile<OrderMappingProfile>();
            });

            var mapper = config.CreateMapper();
            return mapper;
        });

        public static IMapper Mapper => Lazy.Value;
    }
}
