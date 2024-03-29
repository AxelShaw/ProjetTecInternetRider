﻿using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Ef.DbEntities;

public class DbUser
{
    [Key]
    public int IdUser { get; set; }
    public string last_name { get; set; }
    public string first_name { get; set; }
    public string mail { get; set; }
    public string nickname { get; set; }
    
    public string password { get; set; }
    
    public string role { get; set; }
    
    public byte[] profil_picture { get; set; }
}