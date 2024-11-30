using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Core.Entities;

public class CallRequest
{
    public int? Id { get; set; }
    public string? Name { get; set; }         // Name of the person requesting the call
    public string? PhoneNumber { get; set; }  // Phone number of the person
    public int? PropertyId { get; set; }     // Optional reference to a Property
    public Property? Property { get; set; }
    public int? ProjectId { get; set; }      // Optional reference to a Project
    public Project? Project { get; set; }
    public DateTime? RequestDate { get; set; } = DateTime.Now; // Date of the request
}
