﻿using Application.UseCases.Favorie.Dtos;
using Application.UseCases.Favorie.UseCaseFavorie;
using Infrastructure.Ef.DbEntities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Favorie;
[ApiController
]
[Route("api/v1/favorie")]
public class FavorieController : ControllerBase
{
    private readonly UseCaseFetchAllFavorie _useCaseFetchAllFavorie;
    private readonly UseCaseCreateFavorie _useCaseCreateFavorie;
    private readonly UseCaseFetchFavorieById _useCaseFetchFavorieById;
    private readonly UseCaseDeleteFavorie _useCaseDeleteFavorie;
    private readonly UseCaseUpdateFavorie _useCaseUpdateFavorie;
    private readonly UseCaseDeleteFavorieByUser _useCaseDeleteFavorieByUser;
    private readonly UseCaseDeleteFavorieById _useCaseDeleteFavorieById;

    public FavorieController(UseCaseFetchAllFavorie useCaseFetchAllFavorie,
        UseCaseCreateFavorie useCaseCreateFavorie, UseCaseFetchFavorieById useCaseFetchFavorieById,
        UseCaseDeleteFavorie useCaseDeleteFavorie, UseCaseUpdateFavorie useCaseUpdateFavorie,
        UseCaseDeleteFavorieByUser useCaseDeleteFavorieByUser, UseCaseDeleteFavorieById useCaseDeleteFavorieById)
    {
        _useCaseFetchAllFavorie = useCaseFetchAllFavorie;
        _useCaseCreateFavorie = useCaseCreateFavorie;
        _useCaseFetchFavorieById = useCaseFetchFavorieById;
        _useCaseDeleteFavorie = useCaseDeleteFavorie;
        _useCaseUpdateFavorie = useCaseUpdateFavorie;
        _useCaseDeleteFavorieByUser = useCaseDeleteFavorieByUser;
        _useCaseDeleteFavorieById = useCaseDeleteFavorieById;
    }
    
    //execute use case _useCaseFetchAllFavorie
    [HttpGet]
    public ActionResult<IEnumerable<DtoOutputFavorie>> FetchAll()
    {
        return Ok(_useCaseFetchAllFavorie.Execute());
    }
    
    //execute use case _useCaseCreateFavorie
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public ActionResult<DtoOutputFavorie> Create(DtoInputCreateFavorie dto)
    {
        var output = _useCaseCreateFavorie.Execute(dto);
        return CreatedAtAction(
            nameof(FetchById),
            new { id = output.IdFav },
            output
        );
    }
    
    
    //execute use case _useCaseDeleteFavorie
    [HttpDelete]
    [Route("movie/{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<DtoOutputFavorie>  Delete(int id)
    {
        try
        {
            return _useCaseDeleteFavorie.Execute(id);
        }
        catch (KeyNotFoundException e)
        {
            return NotFound(new
            {
                e.Message
            });
        }
    }
    
    //execute use case _useCaseDeleteFavorieById
    [HttpDelete]
    [Route("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<DtoOutputFavorie>  DeleteById(int id)
    {
        try
        {
            return _useCaseDeleteFavorieById.Execute(id);
        }
        catch (KeyNotFoundException e)
        {
            return NotFound(new
            {
                e.Message
            });
        }
    }
    
    //execute use case _useCaseFetchFavorieById
    [HttpGet]
    [Route("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<IEnumerable<DtoOutputFavorie>> FetchById(int id)
    {
        return Ok(_useCaseFetchFavorieById.Execute(id));
    }
    
    //execute use case _useCaseUpdateFavorie
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult Update(DbFavorie favorie)
    {
        return _useCaseUpdateFavorie.Execute(favorie) ? NoContent() : NotFound();
    }
    
    //execute use case _useCaseDeleteFavorieByUser
    [HttpDelete]
    [Route("deletebyuser/{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<DtoOutputFavorie>  DeleteByUser(int id)
    {
        try
        {
            return _useCaseDeleteFavorieByUser.Execute(id);
        }
        catch (KeyNotFoundException e)
        {
            return NotFound(new
            {
                e.Message
            });
        }
    }
}