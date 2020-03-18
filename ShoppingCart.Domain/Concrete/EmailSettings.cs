using System;
namespace ShoppingCart.Domain.Concrete
{
    public class EmailSettings
    {
        public string MailToAddress = "TO-EMAIL@gmail.com";
        public string MailFromAddress = "FROM-EMAIL@gmail.com";
        public bool UseSsl = true;
        public string Username = "YOUR-EMAIL@gmail.com";
        public string Password = "YOUR-GAIML-APP-PASSWORD";
        public string ServerName = "smtp.gmail.com";
        public int ServerPort = 587;
        public bool WriteAsFile = false;
        public string FileLocation = "";
    }
}
