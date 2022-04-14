using BookRepository.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace BookRepository.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> SignUpAsync(SignUpModel signUpModel);
    }
}