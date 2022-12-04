﻿using Infrastructure.Ef.DbEntities;
using Infrastructure.Utils;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Ef;

public class CommentMovieRepository :ICommentMovieRepository
{
    private MovieContextProvider _contextProvider;

    public CommentMovieRepository(MovieContextProvider contextProvider)
    {
        _contextProvider = contextProvider;
    }


    public IEnumerable<DbCommentMovie> FetchAll()
    {
        using var context = _contextProvider.NewContext();
        return context.CommentMovie.ToList();
    }

    public IEnumerable<DbCommentMovie> FetchById(int id)
    {
        using var context = _contextProvider.NewContext();
        return context.CommentMovie.ToList().Where(g => g.IdMovieRef == id);
    }


    public DbCommentMovie Create(int rating, string commentText, int IdMovieRef, int IdUserRef )
    {
        using var context = _contextProvider.NewContext();
        var commentMovie = new DbCommentMovie
        {
            Rating = rating,
            CommentText = commentText,
            IdMovieRef = IdMovieRef,
            IdUserRef = IdUserRef
        };
        context.CommentMovie.Add(commentMovie);
        context.SaveChanges();
        return commentMovie;
    }

    public bool Delete(int id)
    {
        using var context = _contextProvider.NewContext();
        try
        {
            context.CommentMovie.Remove(new DbCommentMovie { IdComMovie = id });
            return context.SaveChanges() == 1;
        }
        catch (DbUpdateConcurrencyException e)
        {
            return false;
        }
    }

    public bool Update(DbCommentMovie commentMovie)
    {
        using var context = _contextProvider.NewContext();
        try
        {
            context.CommentMovie.Update(commentMovie);
            
            
            return context.SaveChanges() == 1;
        }
        catch (DbUpdateConcurrencyException e)
        {
            return false;
        }
    }
}