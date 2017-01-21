using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstaSharp;
using System.Configuration;
using System.Web.Mvc;

namespace Neb_Server
{
    class DatabaseLoader
    {
        public static InstagramConfig config;
        static void Main(string[] args)
        {
            var clientId = "d70b4e0076e64b439285d3c979bbb0a8";
            var clientSecret = "26eb62fb0e5b4e0aab0ef66ffa9d59ee";
            var redirectUri = "http://www.google.com";
            var realtimeUri = "";

            config = new InstagramConfig(clientId, clientSecret, redirectUri, realtimeUri);
            Login();

            //open link
            System.Diagnostics.Process.Start(link);
        }

        public static ActionResult Login()
        {
            var scopes = new List<OAuth.Scope>();
            scopes.Add(OAuth.Scope.Likes);
            scopes.Add(OAuth.Scope.Comments);
            scopes.Add(OAuth.Scope.Follower_List);
            scopes.Add(OAuth.Scope.Basic);
            scopes.Add(OAuth.Scope.Public_Content);
            scopes.Add(OAuth.Scope.Relationships);

            var link =OAuth.AuthLink(config.OAuthUri + "authorize", config.ClientId, config.RedirectUri, scopes, OAuth.ResponseType.Code);

            return Redirect(link)
      
        }
    }
}
