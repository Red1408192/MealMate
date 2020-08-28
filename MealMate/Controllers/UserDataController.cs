using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using MealMate.Data;
using MealMate.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections;

namespace MealMate.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class UserDataController : ControllerBase
    {

    }
}
