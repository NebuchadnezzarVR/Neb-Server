using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstaSharper;
using System.Configuration;
using System.Web.Mvc;
using System.Web;
using InstaSharper.API.Builder;
using InstaSharper.API;
using InstaSharper.Classes.Models;
using InstaSharper.Classes;
using InstaSharp;
using InstaSharp.Models.Responses;
using System.Web.UI;

public class DatabaseLoader
{
    private static IInstaApi api;
    private static InstaUser user;
    private static InstaMediaList media;
    private static InstaFeed feed;
    private static InstaUserList followers;

    public async static void init(string userName, string password)
    {
        /*var clientId = "e8110e22b15e4448835a7b467b0bc88f";
        var clientSecret = "5b5e0ae2cfdf4e7098cbc0033a86aa07";
        var redirectUri = "http://www.nebvr.org";
        var realtimeUri = "";
        var config = new InstagramConfig(clientId, clientSecret, redirectUri, realtimeUri);

        var scopes = new List<OAuth.Scope>();
        scopes.Add(OAuth.Scope.Likes);
        scopes.Add(OAuth.Scope.Comments);
        scopes.Add(OAuth.Scope.Basic);
        scopes.Add(OAuth.Scope.Follower_List);
        scopes.Add(OAuth.Scope.Public_Content);
        scopes.Add(OAuth.Scope.Relationships);
     
        
        var oauth = new OAuth(config);
        string link = OAuth.AuthLink(config.OAuthUri + "authorize", config.ClientId, config.RedirectUri, scopes, OAuth.ResponseType.Code);
        System.Diagnostics.Process.Start(link);

        var oauthResponse = await oauth.RequestToken(clientSecret);

        System.Web.HttpContext.Current.Session.Add("InstaSharp.AuthInfo", oauthResponse);
        Console.WriteLine(oauthResponse.ToString());
        Console.ReadLine();*/

        api = new InstaApiBuilder()
             .SetUser(new InstaSharper.Classes.UserSessionData()
             {
                 UserName = userName,
                 Password = password
             })
             .Build();
        api.Login();
        user = api.GetCurrentUser().Value;
        media = api.GetUserMedia(user.UserName, 10).Value;
        feed = api.GetUserFeed(5).Value;
        followers = api.GetUserFollowers(user.UserName, 10).Value;

    }
    
    public static string getFullName()
    {
        return user.FullName; 
    }

    public static string getUserName()
    {
        return user.UserName;
    }

    public static InstaMediaList getMedia()
    {
        return media;
    }

    public static InstaFeed getFeed()
    {
        return feed;
    }

    public static InstaUserList getFollowers()
    {
        return followers;
    }

    public static void Logout()
    {
        api.Logout();
    }
    
   /*         foreach (var image in media)
            {
                foreach (var i in image.Images)
                {
                    Console.WriteLine(i.Url);
                }
            }
            Console.ReadLine(); */
}
