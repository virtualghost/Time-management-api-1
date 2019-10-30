using AutoMapper;
using Client_Backend.Domain.DTOs;
using Client_Backend.Domain.DTOs.User;
using Client_Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client_Backend.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
            CreateMap<UserWithoutTokenDTO, User>();
            CreateMap<User, UserWithoutTokenDTO>();
            CreateMap<BookingForCreationDTO, Booking>();
            CreateMap<Booking, BookingForCreationDTO>();
            CreateMap<BookingDTO, Booking>();
            CreateMap<Booking, BookingDTO>();
            CreateMap<RoomDTO, Room>();
            CreateMap<Room, RoomDTO>();
            CreateMap<User, UserAdDTO>();
            CreateMap<UserAdDTO, User>();
            CreateMap<Room, RoomDTO>();
            CreateMap<RoomDTO, Room>();
        }
    }
}
