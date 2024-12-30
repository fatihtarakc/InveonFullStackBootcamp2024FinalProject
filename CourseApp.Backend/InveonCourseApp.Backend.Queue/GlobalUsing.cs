﻿global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Localization;
global using Microsoft.Extensions.Logging;
global using Microsoft.Extensions.Options;
global using Newtonsoft.Json;
global using RabbitMQ.Client;
global using RabbitMQ.Client.Events;
global using System.Text;

global using InveonCourseApp.Backend.Core.Constants;
global using InveonCourseApp.Backend.Core.Utilities.Results.Abstract;
global using InveonCourseApp.Backend.Queue.Services.Abstract;
global using InveonCourseApp.Backend.Business.Abstract.Services.Abstract;
global using InveonCourseApp.Backend.Core.Options;
global using InveonCourseApp.Backend.Core.Resources;
global using InveonCourseApp.Backend.Core.Utilities.Results.Concrete;
global using InveonCourseApp.Backend.Dtos.EmailDtos;
global using InveonCourseApp.Backend.Queue.Services.Concrete;