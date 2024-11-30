using Microsoft.EntityFrameworkCore;
using RealEstate.Core.Entities;
using RealEstate.Core.Services__Interfaces_;
using RealEstate.Repository.Data;

namespace RealEstate.Services
{
    public class SearchService : ISearchService
    {
        private readonly RealContext _context;
        public SearchService(RealContext context)
        {
            _context = context;
        }

        public async Task<(List<Project>, List<Property>)> SearchAsync(int? locationId, int? projectTypeId, int? propertyTypeId, int? developerId)
        {
            // Create the queryable for projects and properties
            var queryProjects = _context.Projects
                 .Include(p => p.Properties)  // Include related Properties in Projects
                 .Include(p => p.Location)  // Include related Properties in Projects
                 .Include(p => p.Developer)  // Include related Properties in Projects
                 .Include(p => p.ProjectHighlights)  // Include related Properties in Projects
                 .Include(p => p.ProjectType)  // Include related Properties in Projects
                 .Include(p => p.CallRequests)  // Include related Properties in Projects
                 .Include(p => p.ProjectImages)  // Include related Properties in Projects
                 .AsQueryable();

            var queryProperties = _context.Properties
                 .Include(p => p.Project)  // Include related Properties in Projects
                 .Include(p => p.Location)  // Include related Properties in Projects
                 .Include(p => p.Developer)  // Include related Properties in Projects
                 .Include(p => p.Images)  // Include related Properties in Projects
                 .Include(p => p.PropertyType)  // Include related Properties in Projects
                 .Include(p => p.CallRequests)  // Include related Properties in Projects
                 .AsQueryable();

            // Apply filters for the projects
            if (locationId.HasValue)
                queryProjects = queryProjects.Where(p => p.LocationId == locationId);

            if (projectTypeId.HasValue)
                queryProjects = queryProjects.Where(p => p.ProjectTypeId == projectTypeId);

            if (developerId.HasValue)
                queryProjects = queryProjects.Where(p => p.DeveloperId == developerId);

            if (propertyTypeId.HasValue)
                queryProjects = queryProjects.Where(p => p.Properties.Any(prop => prop.PropertyTypeId == propertyTypeId));

            // Apply filters for the properties
            if (developerId.HasValue)
                queryProperties = queryProperties.Where(p => p.DeveloperId == developerId);

            if (locationId.HasValue)
                queryProperties = queryProperties.Where(p => p.LocationId == locationId);

            if (propertyTypeId.HasValue)
                queryProperties = queryProperties.Where(p => p.PropertyTypeId == propertyTypeId);

            if (projectTypeId.HasValue)
                queryProperties = queryProperties.Where(p => p.Project != null && p.Project.ProjectTypeId == projectTypeId); // Filter properties by their project type

            // Execute the queries and fetch the results as lists
            var projects = await queryProjects.ToListAsync();
            var properties = await queryProperties.ToListAsync();

            return (projects, properties);
        }
    }
}
