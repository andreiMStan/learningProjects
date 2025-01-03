﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using RunGroupMVC_teddy.Data;
using RunGroupMVC_teddy.Interfaces;
using RunGroupMVC_teddy.Models;

namespace RunGroupMVC_teddy.Repository
{
 public class UserRepository : IUserRepository
 {
  private readonly ApplicationDbContext _context;

  public UserRepository(ApplicationDbContext context)
  {
   _context = context;
  }

  public bool Add(AppUser user)
  {
   _context.AddAsync(user);
   return Save();
  }

  public bool Delete(AppUser user)
  {
   _context.Remove(user);
   return Save();
  }

  public async Task<IEnumerable<AppUser>> GetAllUsers()
  {
   return await _context.Users.ToListAsync();

  }

  public async Task<AppUser> GetUserById(string id)
  {
   return await _context.Users.FindAsync(id);
  }

  public bool Save()
  {

   var saved = _context.SaveChanges();
   return saved>0 ? true : false;
  }

  public bool Update(AppUser user)
  {
   _context.Update(user);
   return Save();
  }
 }
}
