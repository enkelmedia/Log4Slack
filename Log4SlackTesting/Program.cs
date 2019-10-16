﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using Log4Slack;

namespace Log4SlackTesting {
    class Program {
        static void Main(string[] args) {
            log4net.Config.XmlConfigurator.Configure();

            // Add exception to ignore
            SlackAppender.ExceptionTypesToIgnore.Add(typeof(UnauthorizedAccessException));

            // Or add exception to ignore using extension
            SlackAppender.ExceptionTypesToIgnore.Add<InvalidCastException>();

            var logger = LogManager.GetLogger(typeof(Program));
            logger.Info("I know he can get the job, but can he do the job?");
            logger.Debug("I'm not arguing that with you.");
            logger.Warn("Be careful!");

            logger.Error("Have you used a computer before?", new FieldAccessException("You can't access this field.", new AggregateException("You can't aggregate this!")));
            try {
                var hi = 1 / int.Parse("0");
            } catch (Exception ex) {
                logger.Error("I'm afraid I can't do that.", ex);
            }

            logger.Fatal("That's it. It's over.", new EncoderFallbackException("Could not fall backwards."));

            logger.Error("This should be ignored.", new UnauthorizedAccessException("No."));
            logger.Error("This as well.", new InvalidCastException("No."));

            Console.ReadKey();
        }
    }
}

