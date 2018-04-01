using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using ASP_Blog.Models;

namespace ASP_Blog.Helpers
{
    public static class Mailer
    {
        /*CONFIGURATION*/
        private static string smtp = "smtp.mailtrap.io";
        private static int port = 2525;
        private static bool ssl = true;
        private static string username = "fc5f1a232a028d";
        private static string password = "8e7a13908bfd2e";

        public static bool Mail(MessageModel message){
            try
            {
                WebMail.SmtpServer = smtp;
                WebMail.SmtpPort = port;
                WebMail.EnableSsl = ssl;
                WebMail.UserName = username;
                WebMail.Password = password;

                WebMail.Send("admin@aspnet.app", "Contact from " + (message.name != null ? message.name : "blog"),
                    message.message, message.email);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
    }
}