using System;

namespace Bolao.Domain.Arguments.User
{
    public sealed class ChangePasswordRequest
    {
        public Guid Token { get; set; }
        public string NewPassword { get; set; }
        public string NewPasswordConfirm { get; set; }
    }
}