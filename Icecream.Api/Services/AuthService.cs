﻿using Icecream.Api.Data;
using Icecream.Api.Data.Entities;
using Icecream.Shared.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Icecream.Api.Services
{
    public class AuthService(DataContext context, TokenService tokenService, PasswordService passwordService)
    {
        private TokenService _tokenService = tokenService;
        private readonly DataContext _context = context;
        private readonly PasswordService _passwordService = passwordService;
        public async Task<ResultWithDataDto<AuthResponseDto>> SignupAsync(SignupRequestDto dto)
        {
            if (await _context.Users.AsNoTracking().AnyAsync(u => u.Email == dto.Email))
            {
                return ResultWithDataDto<AuthResponseDto>.Failure("Email alredy exists");
            }
            var user = new User
            {
                Email = dto.Email,
                Address = dto.Address,
                Name = dto.Name,
            };
            (user.Salt, user.Hash) = _passwordService.GenerateSaltAndHash(dto.Password);
            try
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();

                return GenerateAuthResonse(user);

            }
            catch (Exception ex)
            {
                return ResultWithDataDto<AuthResponseDto>.Failure(ex.Message);
            }


        }

        private ResultWithDataDto<AuthResponseDto> GenerateAuthResonse(User user)
        {
            var loggedIndUser = new LoggedInUserDto(user.Id, user.Name, user.Email, user.Address);
            var token = _tokenService.GenerateJwt(loggedIndUser);

            return ResultWithDataDto<AuthResponseDto>.Success(new AuthResponseDto(loggedIndUser, token));
        }

        public async Task<ResultWithDataDto<AuthResponseDto>> SigninAsync(SigninRequestDto dto)
        {
            var dbUser = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == dto.Email);

            if (dbUser is null)
                return ResultWithDataDto<AuthResponseDto>.Failure("User does not exist");
            
            if (!_passwordService.AreEqual(dto.Password, dbUser.Salt, dbUser.Hash))
                return ResultWithDataDto<AuthResponseDto>.Failure("Incorrect Password");


            return GenerateAuthResonse(dbUser);
        }

    }
}
