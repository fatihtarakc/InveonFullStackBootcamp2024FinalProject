﻿global using Microsoft.AspNetCore.Identity;
global using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Storage;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Options;
global using System.Linq.Expressions;

global using CourseApp.Backend.Core.Enums;
global using CourseApp.Backend.Core.Options;
global using CourseApp.Backend.Core.Repositories.Abstract;
global using CourseApp.Backend.Core.UnitOfWorks.Abstract;
global using CourseApp.Backend.DataAccess.Abstract.Repositories.Abstract;
global using CourseApp.Backend.DataAccess.Concrete.Repositories.Concrete;
global using CourseApp.Backend.DataAccess.Concrete.SeedDatas;
global using CourseApp.Backend.DataAccess.Concrete.UnitOfWorks.Concrete;
global using CourseApp.Backend.DataAccess.Context;
global using CourseApp.Backend.Entities.Concrete;