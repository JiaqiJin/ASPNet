using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Management.Web.Data;
using Management.Web.Models;

namespace Management.Web.Folder
{
    public class MapperTest : Profile
    {
        public MapperTest()
        {
            CreateMap<Order, OrderDTO>();
            CreateMap<OrderDTO, Order>();
            CreateMap<OrderCreateDTO, Order>();
            CreateMap<OrdersForUpdateDTO, Order>();
        }
    }
}
