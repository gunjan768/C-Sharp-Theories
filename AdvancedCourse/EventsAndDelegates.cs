using System;
using System.Threading;

namespace AdvancedCourse
{
    // Events:
    // a) It is a mechanism for communication b/w objects.
    // b) Used in building Loosely Coupled Applciatios.
    // c) Helps extending applciations.

    // Delegates:
    // a) Agreement / Contract b/w Publisher abd Subscriber
    // b) Determines the signature of the event handler method in Subscriber which will be called when the publisher
    // (in this case VideoEncoder) publishes an event
    public class Video
    {
        public string Title { get; set; }
    }

    public class VideoEventArgs: EventArgs
    {
        public Video Video { get; set; }
    }

    public class VideoEncoder
    {
        // To implement an event in the VideoEncoder class such that when an encoding is finished, it notifies
        // anyone who is interested in this event, we need to follow three steps. Those three steps are as follows:
        // 1. Define a delegate
        // This delegate holds the reference of a function which must have same signature to that of delegate.
        // Or delegate determines the shape/signature of methods.
        // EventArgs include any additional data about the data.
        public delegate void VideoEncodedEventHandler(object source, VideoEventArgs args);

        // 2. Define an event based on that delegate.
        public event VideoEncodedEventHandler VideoEncoded;

        // 3. Raise the event. In .Net, there is a convention to declare the event publisher method as protected,
        // virtual and void. This method will publish the event to all the interested subscribers i.e. notify all the
        // interested subscribers.
        protected virtual void OnVideoEncoded(Video video)
        {
            // If someone has subscribed to an event.
            if (VideoEncoded != null)
            {
                // Don't want to send any extra data so EventArgs.Empty which will return an instance of EventsArgs
                // which is empty.
                //VideoEncoded(this, EventArgs.Empty);

                // In this case, we are sending an extra data that is the video which was encoded.
                VideoEncoded(this, new VideoEventArgs() { Video = video });
            }
        }

        public void Encode(Video video)
        {
            Console.WriteLine("Encoding Video...");
            Thread.Sleep(3000);
            Console.WriteLine("Encoding Video is finished");

            // Publish the event to the subscribers.
            OnVideoEncoded(video);
        }
    }

    // MailService and MessageService act as subscribers.
    public class MailService
    {
        // Event handler method
        public void OnVideoEncoded(object source, VideoEventArgs eventArgs)
        {
            Console.WriteLine("MailService: sending an email... " + eventArgs.Video.Title);
        }
    }

    public class MessageService
    {
        // Event handler method
        public void OnVideoEncoded(object source, VideoEventArgs eventArgs)
        {
            Console.WriteLine("MessageService: sending a text message... " + eventArgs.Video.Title);
        }
    }
}