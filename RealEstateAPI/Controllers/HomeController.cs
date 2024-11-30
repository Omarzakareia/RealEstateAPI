//using AutoMapper;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using RealEstate.Core;
//using RealEstate.Core.Entities;
//using RealEstate.Core.Specifications;
//using RealEstateAPI.DTOs;
//using Talabat.APIs.Helpers;

//namespace RealEstateAPI.Controllers
//{

//    public class HomeController : ApiBaseController
//    {
//        private readonly IMapper _mapper;
//        private readonly IUnitOfWork _unitOfWork;
//        public HomeController(IMapper mapper, IUnitOfWork unitOfWork)
//        {
//            _mapper = mapper;
//            this._unitOfWork = unitOfWork;
//        }
            
//        [CachedAttribute(300)]
//        //Get All Locations , with Project Count and Properties Count
//        [HttpGet("FeaturedLocations")]
//        public async Task<ActionResult<IEnumerable<LocationHomeDTO>>>GetAllLocations()
//        {
//            // Use the UnitOfWork to get all locations
//            var Spec = new LocationSpecification();
//            var locations = await _unitOfWork.Repository<Location>().GetAllWithSpecAsync(Spec);          
//            var locationDTOs = _mapper.Map<List<LocationHomeDTO>>(locations);

//            return Ok(locationDTOs);
//        }

//        //Get All Locations , with Project Count and Properties Count
//        [CachedAttribute(300)]
//        [HttpGet("FeaturedProjects")]
//        public async Task<ActionResult<IEnumerable<LocationTabDTO>>> FeaturedProjects()
//        {
//            // Use the UnitOfWork to get all locations
//            var Spec = new LocationSpecification();
//            var locations = await _unitOfWork.Repository<Location>().GetTopThreeAsync(Spec);
//            var locationDTOs = _mapper.Map<List<LocationTabDTO>>(locations);

//            return Ok(locationDTOs);
//        }


//        [HttpGet("FeaturedDevelopers")]
//        [CachedAttribute(300)]
//        public async Task<ActionResult<IEnumerable<DeveloperTabDTO>>> FeaturedDevelopers()
//        {
//            var Spec = new DeveloperSpecification();
//            var developers = await _unitOfWork.Repository<Developer>().GetAllWithSpecAsync(Spec);
//            var mappedDevleopers = _mapper.Map<List<DeveloperTabDTO>>(developers);

//            return Ok(mappedDevleopers);
//        }

//    }
//}
