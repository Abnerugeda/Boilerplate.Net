using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories;

public class UserRepository(AppDbContext context) : BaseRepository<User>(context), IUserRepository
{
    private readonly AppDbContext _context = context;

    public async Task<User> GetByEmail(string email, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FirstOrDefaultAsync((x) => x.Email == email, cancellationToken);
        return user ?? throw new NotFoundUser();
    }
}