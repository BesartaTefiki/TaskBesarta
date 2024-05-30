using AutoMapper;
using TaskManagement2.DTOs;
using TaskManagement2.Models;

namespace TaskManagement2.Mapping
{
    public class MappingProfile : Profile
    {


        public MappingProfile() {

            CreateMap<TaskRequestDTO, TaskRequest>();
            CreateMap<Data.Task2, TaskDTO>();
            CreateMap<TaskDTO, Data.Task2 >();

        }
    }
}
