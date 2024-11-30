using AutoMapper;
using Microsoft.AspNetCore.Identity;
using OrderManagementSystem.DTOs.UserDTOs;
using RealEstate.Core.DTOs;
using RealEstate.Core.Entities;
using RealEstate.Core.Entities.Identity;
using RealEstateAPI.DTOs;
using RealEstateAPI.DTOs.RoleDTOs;
namespace RealEstateAPI.Helpers;
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        #region Developer
        CreateMap<Developer, DeveloperCardDTO>()
            .ForMember(dest => dest.ProjectCount, opt => opt.MapFrom(src => src.Projects.Count))
            .ForMember(dest => dest.PropertyCount, opt => opt.MapFrom(src => src.Properties.Count)).ReverseMap();

        CreateMap<Developer, DeveloperDTO>().ReverseMap();
        CreateMap<Developer, AddDeveloperDTO>().ReverseMap();

        #endregion

        #region Project
        CreateMap<Project, ProjectCardDTO>()
            .ForMember(dest => dest.DeveloperName, opt => opt.MapFrom(src => src.Developer.Name))  // Map Developer name
            .ForMember(dest => dest.LocationName, opt => opt.MapFrom(src => src.Location.Name))      // Map Location name
            .ForMember(dest => dest.ProjectTypeName, opt => opt.MapFrom(src => src.ProjectType.Name)) // Map ProjectType name
            .ReverseMap();

        CreateMap<AddProjectDTO, Project>()
            .ForMember(dest => dest.Developer, opt => opt.Ignore()) // Prevent overwriting Developer entity
            .ForMember(dest => dest.Location, opt => opt.Ignore())  // Prevent overwriting Location entity
            .ForMember(dest => dest.ProjectType, opt => opt.Ignore()) // Prevent overwriting ProjectType entity
            .ForMember(dest => dest.Amenities, opt => opt.MapFrom(src => src.AmenityIds.Select(id => new Amenity { Id = id }).ToList()))
            .ForMember(dest => dest.ProjectImages, opt => opt.MapFrom(src => src.ProjectImageIds.Select(id => new ProjectImage { Id = id }).ToList()))
            .ForMember(dest => dest.ProjectHighlights, opt => opt.MapFrom(src => src.ProjectHighlightIds.Select(id => new ProjectHighlight { Id = id }).ToList()))
            .ReverseMap();

        // Mapping from Project to ProjectDTO
        CreateMap<Project, ProjectDTO>()
            .ForMember(dest => dest.DeveloperName, opt => opt.MapFrom(src => src.Developer.Name))   // Map Developer name
            .ForMember(dest => dest.LocationName, opt => opt.MapFrom(src => src.Location.Name))      // Map Location name
            .ForMember(dest => dest.ProjectTypeName, opt => opt.MapFrom(src => src.ProjectType.Name)) // Map ProjectType name
            .ReverseMap();

        CreateMap<Property, SimplePropertyDTO>();
        CreateMap<Project, SimpleProjectDTO>()
            .ForMember(dest => dest.PropertyCount, opt => opt.MapFrom(src => src.Properties.Count));

        CreateMap<ProjectImage, ProjectImageDTO>().ReverseMap();

        #endregion

        #region Property
        CreateMap<PropertyImage, PropertyImageDTO>().ReverseMap();
        CreateMap<Property, PropertyDTO>()
            .ForMember(dest => dest.PropertyTypeName, opt => opt.MapFrom(src => src.PropertyType.Name))  // Map PropertyType name
            .ForMember(dest => dest.LocationName, opt => opt.MapFrom(src => src.Location.Name))  // Map Location name
            .ForMember(dest => dest.DeveloperName, opt => opt.MapFrom(src => src.Developer.Name))  // Map Developer name
            .ForMember(dest => dest.ProjectName, opt => opt.MapFrom(src => src.Project.ProjectTitle))  // Map Project name
            .ReverseMap();

        CreateMap<Property,PropertyCardDTO>()
            .ForMember(dest => dest.PropertyTypeName, opt => opt.MapFrom(src => src.PropertyType.Name))  // Map PropertyType name
            .ForMember(dest => dest.ProjectName, opt => opt.MapFrom(src => src.Project.ProjectName))  // Map Project name
            .ForMember(dest => dest.LocationName, opt => opt.MapFrom(src => src.Location.Name))      // Map Location name
            .ReverseMap();

        CreateMap<AddPropertyDTO, Property>()
            .ForMember(dest => dest.PropertyTypeId, opt => opt.MapFrom(src => src.PropertyTypeId))
            .ForMember(dest => dest.LocationId, opt => opt.MapFrom(src => src.LocationId))
            .ForMember(dest => dest.DeveloperId, opt => opt.MapFrom(src => src.DeveloperId))
            .ForMember(dest => dest.ProjectId, opt => opt.MapFrom(src => src.ProjectId))
            .ForMember(dest => dest.Images, opt => opt.Ignore()) // Assume images will be handled separately
            .ForMember(dest => dest.CallRequests, opt => opt.Ignore()); // Assume call requests will be handled separately

        #endregion

        #region Location
        CreateMap<Location, LocationCardDTO>()
            .ForMember(dest => dest.ProjectCount, opt => opt.MapFrom(src => src.Projects.Count))
            .ForMember(dest => dest.PropertyCount, opt => opt.MapFrom(src => src.Properties.Count)).ReverseMap();

        CreateMap<Location, LocationDTO>()
            .ForMember(dest => dest.ProjectCount, opt => opt.MapFrom(src => src.Projects.Count))
            .ForMember(dest => dest.PropertyCount, opt => opt.MapFrom(src => src.Properties.Count)).ReverseMap();

        CreateMap<Property, SimplePropertyDTO>();
        CreateMap<Project, SimpleProjectDTO>()
            .ForMember(dest => dest.PropertyCount, opt => opt.MapFrom(src => src.Properties.Count));

        CreateMap<Location, AddLocationDTO>().ReverseMap();

        #endregion

        #region Call Request
        CreateMap<CallRequest, CallRequestDTO>()
            .ForMember(dest => dest.PropertyTitle, opt => opt.MapFrom(src => src.Property.Title))
            .ForMember(dest => dest.ProjectName, opt => opt.MapFrom(src => src.Project.ProjectName)).ReverseMap();

        CreateMap<CallRequest, AddCallRequestDTO>().ReverseMap();
        #endregion

        #region Account
        CreateMap<IdentityRole<int>, RoleDTO>()
            .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Name));

        CreateMap<RoleDTO, IdentityRole<int>>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.RoleName));

        CreateMap<IdentityRole<int>, GetAllRolesDTO>()
            .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Name));

        CreateMap<AppUser, UserDTO>().ReverseMap();

        #endregion

    }
}
