using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using ShoppingCart.Domain.Abstract;
using ShoppingCart.Domain.Entities;

namespace ShoppingCart.Domain.Concrete
{
    public class EmailOrderProcessor : IOrderProcessor
    {
        private EmailSettings settings;

        public EmailOrderProcessor(EmailSettings settings)
        {
            this.settings = settings;
        }

        public void ProcessOrder(Cart cart, ShippingDetails shippingDetails)
        {
            using (var smtpClient = new SmtpClient())
            {
                smtpClient.EnableSsl = settings.UseSsl;
                smtpClient.Host = settings.ServerName;
                smtpClient.Port = settings.ServerPort;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(settings.Username, settings.Password);

                if(settings.WriteAsFile)
                {
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtpClient.PickupDirectoryLocation = settings.FileLocation;
                    smtpClient.EnableSsl = false;
                }

                StringBuilder body = new StringBuilder()
                    .AppendLine("A new order has been submitted!")
                    .AppendLine("---")
                    .AppendLine("Items:");

                foreach (var item in cart.Items)
                {
                    var subtotal = item.Product.Price * item.Quantity;

                    body.AppendFormat("{0} x {1} ({2:c})\n", item.Quantity, item.Product.Name, subtotal);
                }

                body.AppendLine("---")
                    .AppendFormat("Total Order Value: {0:c}", cart.TotalPrice())
                    .AppendLine()
                    .AppendLine("---")
                    .AppendLine("Ship to:")
                    .AppendLine(shippingDetails.Name)
                    .AppendLine(shippingDetails.Line1)
                    .AppendLine(shippingDetails.Line2 ?? "")
                    .AppendLine(shippingDetails.Line3 ?? "")
                    .AppendLine(shippingDetails.City)
                    .AppendLine(shippingDetails.State ?? "")
                    .AppendLine(shippingDetails.Country)
                    .AppendLine(shippingDetails.Zip)
                    .AppendLine("---")
                    .AppendFormat("GiftWrap: {0}", shippingDetails.GiftWrap ? "Yes" : "No");

                MailMessage mailMessage = new MailMessage(settings.MailFromAddress, settings.MailToAddress, "New Order Placed!", body.ToString());

                if (settings.WriteAsFile)
                    mailMessage.BodyEncoding = Encoding.ASCII;

                smtpClient.Send(mailMessage);
            }
        }
    }
}
