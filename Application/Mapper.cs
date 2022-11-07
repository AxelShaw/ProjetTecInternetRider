﻿using Application.UseCases.Movies.Dtos;
using Application.UseCases.Series.Dtos;
using Application.UseCases.Users.Dtos;
using AutoMapper;
using Domain;
using Infrastructure.Ef.DbEntities;

namespace Application;

public class Mapper
{
    private static AutoMapper.Mapper _instance;

    public static AutoMapper.Mapper GetInstance()
    {
        return _instance ??= CreateMapper();
    }

    private static AutoMapper.Mapper CreateMapper()
    {
        var config = new MapperConfiguration(cfg =>
        {
            // Source, Destination
            // User
            cfg.CreateMap<Movie, DtoOutputMovie>();
            cfg.CreateMap<DbMovie, DtoOutputMovie>();
            cfg.CreateMap<DbMovie, Movie>();
            cfg.CreateMap<Boolean, DtoOutputMovie>();
            cfg.CreateMap<DtoOutputMovie, Movie>();
            cfg.CreateMap<User, DtoOutputUser>();
            cfg.CreateMap<DbUser, DtoOutputUser>();
            cfg.CreateMap<DbUser, User>();
            cfg.CreateMap<Boolean, DtoOutputUser>();
            cfg.CreateMap<DtoOutputSerie, Serie>();
            cfg.CreateMap<Serie, DtoOutputSerie>();
            cfg.CreateMap<DbSerie, DtoOutputSerie>();
            cfg.CreateMap<DbSerie, Serie>();
            cfg.CreateMap<Boolean, DtoOutputSerie>();
            cfg.CreateMap<DtoOutputSerie, Serie>();

        });
        return new AutoMapper.Mapper(config);
    }
}