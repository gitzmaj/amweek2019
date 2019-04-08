using System;

namespace amweek.messaging.Messages.Events
{
    public class ProspectSignedUpEvent : Message
    {
        public override string Subject { get { return MessageSubject; } }

        public DateTime SignedUpAt { get; set; }

        public amweek.Entities.Prospect Prospect { get; set; }

        public static string MessageSubject = "events.prospect.signedup";
    }
}
