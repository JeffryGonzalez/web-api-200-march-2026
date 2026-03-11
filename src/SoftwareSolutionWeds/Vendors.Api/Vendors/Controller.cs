using Marten;
using Microsoft.AspNetCore.Mvc;

namespace Vendors.Api.Vendors;

/* NOTE
 * This will not be feature complete - just enough so you "get it"
 */

[ApiController]
public class Controller(IDocumentSession session) : ControllerBase
{
    // POST

    [HttpPost("/vendors")]
    public async Task<ActionResult> AddVendorAsync(
    [FromBody] CreateVendorRequestModel request
    )
    {
        return Ok();
    }

   
    [HttpPut("/vendors/{id:guid}/point-of-contact")]
    public async Task<ActionResult> UpdatePoc(Guid id, [FromBody] VendorPointOfContactModel request)
    {
        return Ok();
    }
   
    [HttpGet("/vendors")]
    public async Task<ActionResult> GetAllVendorsAsync(CancellationToken token)
    {
        return Ok();
    }

    [HttpGet("/vendors/{id:guid}")]
    public async Task<ActionResult> GetVendorByIdAsync(Guid id, CancellationToken token)
    {
        return Ok();
    }
}
