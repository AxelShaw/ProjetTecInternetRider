﻿using System.ComponentModel.DataAnnotations;

namespace Application.UseCases.CommentMovies.Dtos;

public class DtoInputCreateCommentMovie
{
    [Required]public int Rating { get; set; }
    public string CommentText { get; set; }

    [Required]public int IdMovieRef{ get; set; }
    [Required]public int IdUserRef{ get; set; }
}