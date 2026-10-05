using Custom_Authorize_Filter.Models;
using Custom_Authorize_Filter.ViewModels;

namespace Custom_Authorize_Filter.Repositories
{
    public interface IUser
    {
        Task<bool> Register(User rec);
        Task<LoginResultVM> Login(LoginVM rec);
    }
}
