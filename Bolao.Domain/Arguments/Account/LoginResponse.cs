using Bolao.Domain.Arguments.Base;
using System;

namespace Bolao.Domain.Arguments.User
{
    public sealed class LoginResponse : ResponseBase
    {
        public Guid IdUser { get; set; }
        public string FirstName { get; set; }
    }
}