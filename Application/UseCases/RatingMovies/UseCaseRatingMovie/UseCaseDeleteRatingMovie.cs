﻿using Application.UseCases.RatingMovies.Dtos;
using Application.UseCases.Utils;
using Infrastructure.Ef;

namespace Application.UseCases.RatingMovies.UseCaseRatingMovie;

public class UseCaseDeleteRatingMovie: IUseCaseParameterizedQuery<DtoOutputRatingMovie, int>
{
    private readonly IRatingMovieRepository _ratingMovieRepository;

    public UseCaseDeleteRatingMovie(IRatingMovieRepository ratingMovieRepository)
    {
        _ratingMovieRepository = ratingMovieRepository;
    }

    //execute ratingmovie delete by id method
    public DtoOutputRatingMovie Execute(int id)
    {
        var dbRatingMovie = _ratingMovieRepository.Delete(id);
        return Mapper.GetInstance().Map<DtoOutputRatingMovie>(dbRatingMovie);
    }
}