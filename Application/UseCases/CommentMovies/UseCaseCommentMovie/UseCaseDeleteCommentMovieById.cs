﻿using Application.UseCases.CommentMovies.Dtos;
using Application.UseCases.Utils;
using Infrastructure.Ef;

namespace Application.UseCases.CommentMovies.UseCaseCommentMovie;

public class UseCaseDeleteCommentMovieById:  IUseCaseParameterizedQuery<DtoOutputCommentMovie, int>
{
    private readonly ICommentMovieRepository _commentMovieRepository;

    public UseCaseDeleteCommentMovieById(ICommentMovieRepository commentMovieRepository)
    {
        _commentMovieRepository = commentMovieRepository;
    }
    //execute commentmovie delete comment movie method by movie
    public DtoOutputCommentMovie Execute(int id)
    {
        var dbCommentMovie = _commentMovieRepository.DeleteById(id);
        return Mapper.GetInstance().Map<DtoOutputCommentMovie>(dbCommentMovie);
    }
}