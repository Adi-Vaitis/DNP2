using System.Threading.Tasks;
using DNP2.Data;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;

namespace DNP2.Authentication
{
    public class CustomAuthenticationStateProvider: AuthenticationStateProvider
    {
        private readonly IJSRuntime jsRunTime;
        private readonly IUserService userService;
        
        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}