global using Microsoft.AspNetCore.Builder;
global using Microsoft.Extensions.Caching.Distributed;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Localization;
global using Microsoft.Extensions.Logging;
global using Microsoft.Extensions.Options;
global using System.Text.Json;

global using InveonCourseApp.Backend.Cache.Services.Abstract;
global using InveonCourseApp.Backend.Cache.Services.Concrete;
global using InveonCourseApp.Backend.Core.Constants;
global using InveonCourseApp.Backend.Core.Entities.Abstract;
global using InveonCourseApp.Backend.Core.Options;
global using InveonCourseApp.Backend.Core.Resources;
global using InveonCourseApp.Backend.Core.Utilities.Results.Abstract;
global using InveonCourseApp.Backend.Core.Utilities.Results.Concrete;