using Microsoft.AspNetCore.Identity;
using My_Books.Data.Models;

namespace My_Books.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> SignUpAsync(SignUpModel user);
        Task<string> LoginAsync(SignInModel signInModel);
    }
}