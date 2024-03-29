﻿using Application.UseCases.Actu.Dtos;
using Application.UseCases.Utils;
using Infrastructure.Ef;

namespace Application.UseCases.Favorie.UseCaseCommentMovie;

public class UseCaseDeleteByIdActu : IUseCaseParameterizedQuery<DtoOutputActu, int>
{
    private readonly IActuRepository _actuRepository;

    public UseCaseDeleteByIdActu(IActuRepository actuRepository)
    {
        _actuRepository = actuRepository;
    }
    //execute news delete by id movie method with id to dtoOutput
    public DtoOutputActu Execute(int id)
    {
        var dbActu = _actuRepository.DeleteById(id);
        return Mapper.GetInstance().Map<DtoOutputActu>(dbActu);
    }
}