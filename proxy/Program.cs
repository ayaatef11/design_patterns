using System.Collections.Generic;
using System.Linq;
namespace proxy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    
        public abstract class SMSService
        {
            public abstract string SendSMS(string custId, string mobile, string sms);

        }
    
    public class ConcereteSMSService : SMSService
        {
            public override string SendSMS(string custId, string mobile, string sms)
            {
                return $"CustomerId {custId}, sms sent to {mobile}";
            }
    }
  

        public class SMSServiceProxy
        {
            //ToDo: Count calls for each customer, if calls > 100 dont send sms
            private SMSService _smsService;
            Dictionary<string, int> sentCount = new Dictionary<string, int>();
            public string SendSMS(string custId, string mobile, string sms)
            {
                if (_smsService == null) { _smsService = new ConcereteSMSService(); }

                // first call
                if (!sentCount.ContainsKey(custId))
                {
                    sentCount.Add(custId, 1);
                    return _smsService.SendSMS(custId, mobile, sms);
                }
                else
                {
                    var customer = sentCount.Where(x => x.Key == custId).FirstOrDefault();
                    if (customer.Value >= 2) { return "Not sent!"; }
                    else { sentCount[custId] = customer.Value + 1; return _smsService.SendSMS(custId, mobile, sms); }
                }
            }
        }
    }

