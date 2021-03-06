﻿using System.Threading.Tasks;
using Din.Domain.Authorization.Authorizers.Interfaces;
using Din.Domain.Authorization.Requests;
using Din.Domain.Context;
using Din.Domain.Exceptions.Concrete;
using Din.Domain.Models.Entities;

namespace Din.Domain.Authorization.Authorizers.Concrete
{
    public class RoleAuthorizer<TRequest> : IRequestAuthorizer<TRequest> where TRequest : IAuthorizedRoleRequest
    {
        private readonly IRequestContext _context;

        public RoleAuthorizer(IRequestContext context)
        {
            _context = context;
        }

        public Task Authorize(TRequest request)
        {
            var role = _context.GetAccountRole();

            if (role != request.AuthorizedRole && role != AccountRole.Admin)
            {
                throw new AuthorizationException();
            }

            return Task.CompletedTask;
        }
    }
}