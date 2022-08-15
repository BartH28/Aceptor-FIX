using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickFix;
using Newtonsoft.Json;
using QuickFix.Fields;


namespace AcceptorFix
{
   
    public class AcceptorApplication : IApplication
    {
        //private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(AcceptorApplication));
        
        

        public void FromAdmin(Message message, SessionID sessionID)
        {
            var msgJson = JsonConvert.SerializeObject(message, Formatting.Indented);
           
            log.Info(msgJson.ToString() + " Message from Admin Log4net");
        }

        public void FromApp(Message message, SessionID sessionID)
        {
            var msgJson = JsonConvert.SerializeObject(message, Formatting.Indented);
            
            log.Info(msgJson.ToString() + " Message from App Log4net");
        }

        public void OnCreate(SessionID sessionID)
        {
            
            log.Info("SessionID: " + sessionID);
        }

        public void OnLogon(SessionID sessionID)
        {
            QuickFix.FIX44.NewOrderSingle order = new QuickFix.FIX44.NewOrderSingle(
            new ClOrdID("1234"),
            new Symbol("AAPL"),
            new Side(Side.BUY),
            new TransactTime(DateTime.Now),
            new OrdType(OrdType.MARKET));

            Session.SendToTarget(order, sessionID);
            log.Info("NewOrderSingle send to " + sessionID);

            log.Info(sessionID + " logon");
        }

        public void OnLogout(SessionID sessionID)
        {
            
            
            log.Info(sessionID + " logout");
        }

        public void ToAdmin(Message message, SessionID sessionID)
        {
            var msgJson = JsonConvert.SerializeObject(message, Formatting.Indented);
            log.Info(msgJson.ToString() + " to admin in " + sessionID);
            
        }

        public void ToApp(Message message, SessionID sessionId)
        {
            var msgJson = JsonConvert.SerializeObject(message, Formatting.Indented);
            log.Info(msgJson.ToString() + " Message to app Log4net");
            
        }
    }
}
