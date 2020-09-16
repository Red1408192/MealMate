using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ControllerModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections;

namespace Comì.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class FamilyController : ControllerBase, IFamilyController
    {

    }
}
