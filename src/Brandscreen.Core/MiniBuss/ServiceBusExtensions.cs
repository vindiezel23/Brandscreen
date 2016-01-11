using System;
using System.Messaging;

namespace Brandscreen.Core.MiniBuss
{
    public static class ServiceBusExtensions
    {
        /// <summary>
        /// Sends command without throwing ServiceNotAvailable exception which happens when no MSMQ setup in the server side
        /// </summary>
        public static void Send(this IServiceBus serviceBus, object command, bool noThrowServiceNotAvailableException)
        {
            try
            {
                serviceBus.Send(command);
            }
            catch (MessageQueueException exception)
            {
                if (noThrowServiceNotAvailableException &&
                    exception.MessageQueueErrorCode == MessageQueueErrorCode.ServiceNotAvailable)
                {
                    return;
                }
                throw;
            }
            catch (InvalidOperationException exception)
            {
                if (noThrowServiceNotAvailableException &&
                    exception.HResult == -2146233079) // "Message Queuing has not been installed on this computer."
                {
                    return;
                }
                throw;
            }
        }
    }
}