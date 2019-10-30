using AutoMapper;
using Client_Backend.Domain.DTOs;
using Client_Backend.Domain.Entities;
using Client_Backend.Domain.Interfaces;
using Client_Backend.Domain.Interfaces.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Client_Backend.Controllers
{
    [Route("api/users")]
    public class UsersController : Controller
    {
        
    }

}
