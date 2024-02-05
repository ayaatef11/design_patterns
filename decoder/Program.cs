using System.Text;
using System;
using System.Text;
namespace decoder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
   

        public class NotificationEmailDecorator : AbstractDecorator
        {
            public string SmsSentNotification(string custId, string sms)
            {
                return $"sms {sms}, sent to {custId}, at {DateTime.Now.ToLongDateString()}";
            }

            public override string SendSMS(string custId, string mobile, string sms)
            {
                StringBuilder result = new StringBuilder();
                result.AppendLine(base.SendSMS(custId, mobile, sms));

                // decorator method to send mail 
                result.AppendLine(SmsSentNotification(custId, sms));

                return result.ToString();
            }
        }
    public abstract class SMSService
    {
        public abstract string SendSMS(string custId, string mobile, string sms);

    }
    public abstract class AbstractDecorator : SMSService
        {
            protected SMSService notificationService;
            public void SetService(SMSService service)
            {
                notificationService = service;
            }

            public override string SendSMS(string custId, string mobile, string sms)
            {
                if (notificationService != null)
                { return notificationService.SendSMS(custId, mobile, sms); }
                else { return "Notification service not initialized!"; }
            }
        }
    }
