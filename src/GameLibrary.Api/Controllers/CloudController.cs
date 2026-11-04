using GameLibrary.Business;
using Microsoft.AspNetCore.Mvc;

namespace GameLibrary.Api.Controllers;

[ApiController]
[Route("api/cloud")]
public class CloudController : ControllerBase
{
    private readonly CloudManager manager;

    public CloudController(CloudManager manager)
    {
        this.manager = manager;
    }

    // TODO: Write game-summary and playtime-estimate GET actions.
    // Call the corresponding business methods, then return their results.
}
