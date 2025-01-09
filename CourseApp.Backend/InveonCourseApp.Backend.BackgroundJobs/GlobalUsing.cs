global using Hangfire;
global using Hangfire.Annotations;
global using Hangfire.Dashboard;
global using Hangfire.SqlServer;
global using Microsoft.AspNetCore.Builder;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Options;
global using System.Security.Claims;

global using InveonCourseApp.Backend.BackgroundJobs.Managers.FireAndForgetJobs;
global using InveonCourseApp.Backend.BackgroundJobs.Services.Abstract;
global using InveonCourseApp.Backend.BackgroundJobs.Services.Concrete;
global using InveonCourseApp.Backend.BackgroundJobs.Schedules;
global using InveonCourseApp.Backend.Core.Enums;
global using InveonCourseApp.Backend.Core.Options;
global using InveonCourseApp.Backend.Queue.Services.Abstract;