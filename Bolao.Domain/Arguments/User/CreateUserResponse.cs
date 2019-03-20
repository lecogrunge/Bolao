using Bolao.Domain.Arguments.Base;
using System;

namespace Bolao.Domain.Arguments.User
{
    public sealed class CreateUserResponse : ResponseBase
    {
        public Guid IdUser { get; set; }
    }
}