// There are Five types of Access Modifiers: public, protected, private, internal, protected internal

using System;
using System.IO;

namespace Mosh_Hamedani
{
    public interface ILogger
    {
        void LogError(string message);
        void LogWarning(string message);
        void LogInfo(string message);
    }
    public class Migrator
    {
        private readonly ILogger logger;

        public Migrator(ILogger logger)
        {
            this.logger = logger;
        }

        public void Migrate()
        {
            String message = "Hey how are you. It's alomst " + DateTime.Now;
            logger.LogWarning(message);
            logger.LogInfo(message);
            logger.LogError(message);
        }
    }

    public class ConsoleLogger : ILogger
    {
        public void LogError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
        }

        public void LogInfo(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
        }

        public void LogWarning(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
        }
    }

    public class FileLogger: ILogger
    {
        private readonly string path;

        public FileLogger(string path)
        {
            this.path = path;
        }

        public void LogError(string message)
        {
            LogMessage(message, "Error");
        }

        public void LogInfo(string message)
        {
            LogMessage(message, "Info");
        }

        public void LogWarning(string message)
        {
            LogMessage(message, "Warning");
        }

        private void LogMessage(string message, string type)
        {
            // StreamWriter uses a file resource. File resource is not managed by CLR (Common Language Runtime) which means we need to
            // dispose that resource once we finish using that. Easy way to do that is by wrapping the whole code in using() command. What
            // happens behind the scene is there is an exception handling mechanism inside using() implemented by compiler. If any exception
            // is thrown, compiler will make sure to close the File Handle by calling the Dispose() method on StreamWriter.
            using (var streamWriter = new StreamWriter(path, true))
            {
                // Dispose() method is used to throw an external resource which is not handled by CLR. Compiler will automatically include
                // this Dispose() method (as we wrapped inside the using()) so we don't have to automatically write it.
                //streamWriter.Dispose();
                streamWriter.WriteLine("{0} Error: {1}", type, message);
            }
        }
    }
}
