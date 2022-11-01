﻿using Infrastructure.Ef.DbEntities;

namespace Infrastructure.Ef;

public interface IUserRepository
{
    IEnumerable<DbUser> FetchAll();
    DbUser FetchById(int id);
    DbUser Create(string lastName, string firstName, string mail, string nickName, string password, string role, string profilePic);
    bool Delete(int id);
    bool Update(DbUser user);
}