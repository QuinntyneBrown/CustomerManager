using CustomerManager.Config;
using CustomerManager.Services;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using System;

namespace CustomerManager.Auth
{
    public class OAuthOptions : OAuthAuthorizationServerOptions
    {
        public OAuthOptions(Lazy<IAuthConfiguration> lazyAuthConfiguration, IIdentityService identityService)
        {
            _lazyAuthConfiguration = lazyAuthConfiguration;
            TokenEndpointPath = new PathString(_authConfiguration.TokenPath);
            AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(_authConfiguration.ExpirationMinutes);
            AccessTokenFormat = new JwtWriterFormat(lazyAuthConfiguration, this);
            Provider = new OAuthProvider(lazyAuthConfiguration, identityService);
            AllowInsecureHttp = true;
        }

        protected IAuthConfiguration _authConfiguration { get { return _lazyAuthConfiguration.Value; } }
        protected Lazy<IAuthConfiguration> _lazyAuthConfiguration;

    }
}
