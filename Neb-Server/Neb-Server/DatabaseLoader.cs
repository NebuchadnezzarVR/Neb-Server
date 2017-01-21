using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstaSharper;
using System.Configuration;
using System.Web.Mvc;
using InstaSharper.API.Builder;

namespace Neb_Server
{


    public class DatabaseLoader
    {
        static void Main(string[] args)
        {
            var clientId = "d70b4e0076e64b439285d3c979bbb0a8";
            var clientSecret = "26eb62fb0e5b4e0aab0ef66ffa9d59ee";
            var redirectUri = "http://www.google.com";
            var realtimeUri = "";

            var api = new InstaApiBuilder()
                 .SetUser(new InstaSharper.Classes.UserSessionData()
                 {
                     UserName = "mrshawnabu",
                     Password = "fuckjordan"
                 })
                 .Build();
            api.Login();
            var user = api.GetCurrentUser().Value;
            Console.WriteLine(user.FullName);
            while (true) {
                var media = api.GetUserMedia(user.UserName, 5).Value;
                foreach(var image in media)
                {
                    foreach(var i in image.Images)
                    {
                        Console.WriteLine(i.Url);
                    }
                }
                Console.ReadLine();
            }
           
            //open link
           // System.Diagnostics.Process.Start(link);
        }
    }
}
