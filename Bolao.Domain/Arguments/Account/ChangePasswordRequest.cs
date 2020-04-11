using System;

namespace Bolao.Domain.Arguments.User
{
    public sealed class ChangePasswordRequest
    {
        public ChangePasswordRequest(string newPassword, string newPasswordConfirm)
        {
            NewPassword = newPassword.ToLower().Trim();
            NewPasswordConfirm = newPasswordConfirm.ToLower().Trim();
        }

        public Guid Token { get; private set; }
        public string NewPassword { get; private set; }
        public string NewPasswordConfirm { get; private set; }
    }
}