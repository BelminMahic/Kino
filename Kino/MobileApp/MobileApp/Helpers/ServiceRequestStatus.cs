using MobileApp.EnumHelper;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp.Helpers
{
    public enum ServiceRequestStatus
    {
        [Title("Server error")]
        [Description("Server error occurred. Please try later again.")]
        ServerError,

        [Title("Successfully completed")]
        [Description("Requested operation completed successfully!")]
        RequestSuccess,

        [Title("Email exists")]
        [Description("Account with this email already exists. Please use a different email.")]
        EmailExists,

        [Title("Too many attempts")]
        [Description("We have blocked all requests from this device due to unusual activity. Try again later.")]
        TooManyAttempts,

        [Title("Email not found")]
        [Description("Account with this email was not found. Please try with different one or sign up.")]
        EmailNotFound,

        [Title("Invalid password")]
        [Description("Password is not valid. Try again.")]
        InvalidPassword,

        [Title("User disabled")]
        [Description("The user account has been disabled by an administrator.")]
        UserDisabled,

        [Title("Session expired")]
        [Description("The user's credential is no longer valid. The user must sign in again.")]
        InvalidToken,

        [Title("Weak password")]
        [Description("The password must be 6 characters long or more.")]
        WeakPassword,

        [Title("Congratulations!")]
        [Description("You've set your new best result!")]
        ScoreUpdated,

        [Title("")]
        [Description("")]
        ScoreNotUpdated
    }
}
