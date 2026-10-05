using Custom_Authorize_Filter.Models;
using Custom_Authorize_Filter.ViewModels;

namespace Custom_Authorize_Filter.Repositories
{
    public class UserRepo : IUser
    {
        CompanyContext cc;
        public UserRepo(CompanyContext cc)
        {
            this.cc = cc;
        }
        public async Task<LoginResultVM> Login(LoginVM rec)
        {
            LoginResultVM res = new LoginResultVM();
            var urec= this.cc.Users.SingleOrDefault(p=>p.EmailID== rec.EmailID && p.Password==rec.Password);
            if (urec != null)
            {
                //loggedin 
                res.IsLoggedIn = true;
                res.LoggedInUserID = urec.UserID;
                res.FullName = urec.FirstName;
            }
            else
            {
                res.IsLoggedIn = false;
                res.ProblemMesssage = "Invalid Email Id or Password!";
            }
            return res;
        }

        public async Task<bool> Register(User rec)
        {
            await this.cc.Users.AddAsync(rec);
            await this.cc.SaveChangesAsync();
            return true;    
        }
    }
}
