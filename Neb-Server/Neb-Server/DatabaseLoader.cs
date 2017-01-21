using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstaSharper;
using System.Configuration;
using System.Web.Mvc;
using InstaSharper.API.Builder;
using InstaSharper.API;
using InstaSharper.Classes.Models;
using InstaSharper.Classes;

public class DatabaseLoader
{
    private static IInstaApi api;
    private static InstaUser user;
    private static InstaMediaList media;
    private static InstaFeed feed;
    private static InstaUserList followers;

    public static void init(string userName, string password)
    {
        var clientId = "d70b4e0076e64b439285d3c979bbb0a8";
        var clientSecret = "26eb62fb0e5b4e0aab0ef66ffa9d59ee";
        var redirectUri = "http://www.google.com";
        var realtimeUri = "";

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
