using QuickFix;
using QuickFix.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcceptorFix
{
    internal class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(Program));
        static void Main(string[] args)
        {
                    SessionSettings settings = new SessionSettings(args[0]);
                    IApplication myApp = new AcceptorApplication();
                    IMessageStoreFactory storeFactory = new FileStoreFactory(settings);
                    ILogFactory logFactory = new FileLogFactory(settings);
                    ThreadedSocketAcceptor acceptor = new ThreadedSocketAcceptor(
                        myApp,
                        storeFactory,
                        settings,
                        logFactory);

                    acceptor.Start();

            log.Info("Acceptor iniciado");
            
            Console.WriteLine("press <enter> to quit");
                    Console.Read();
                    acceptor.Stop();
                
        }
    }
}
