﻿using Application.UseCases.RatingMovies.Dtos;
using Application.UseCases.Utils;
using Infrastructure.Ef;

namespace Application.UseCases.RatingMovies.UseCaseRatingMovie;

public class UseCaseFetchAllRatingMoviesTopHome : IUseCaseQuery<IEnumerable<DtoOutputRatingMovie>>
{
    private readonly IRatingMovieRepository _ratingMovieRepository;

    public UseCaseFetchAllRatingMoviesTopHome(IRatingMovieRepository ratingMovieRepository)
    {
        _ratingMovieRepository = ratingMovieRepository;
    }

    public IEnumerable<DtoOutputRatingMovie> Execute()
    {
        var dbUsers = _ratingMovieRepository.FetchAllTopHome();
        return Mapper.GetInstance().Map<IEnumerable<DtoOutputRatingMovie>>(dbUsers);
    }
}