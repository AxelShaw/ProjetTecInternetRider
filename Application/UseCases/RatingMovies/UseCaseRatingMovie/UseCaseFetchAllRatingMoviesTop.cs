﻿using Application.UseCases.RatingMovies.Dtos;
using Application.UseCases.Utils;
using Infrastructure.Ef;

namespace Application.UseCases.RatingMovies.UseCaseRatingMovie;

public class UseCaseFetchAllRatingMoviesTop : IUseCaseQuery<IEnumerable<DtoOutputRatingMovie>>
{
    private readonly IRatingMovieRepository _ratingMovieRepository;

    public UseCaseFetchAllRatingMoviesTop(IRatingMovieRepository ratingMovieRepository)
    {
        _ratingMovieRepository = ratingMovieRepository;
    }

    //execute FetchAllTop rating movie method
    public IEnumerable<DtoOutputRatingMovie> Execute()
    {
        var dbRatingMovie = _ratingMovieRepository.FetchAllTop();
        return Mapper.GetInstance().Map<IEnumerable<DtoOutputRatingMovie>>(dbRatingMovie);
    }
}