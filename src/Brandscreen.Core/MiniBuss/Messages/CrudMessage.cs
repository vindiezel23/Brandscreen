using System;

namespace Brandscreen.Core.MiniBuss.Messages
{
    public enum CrudAction
    {
        Created,
        Deleted,
        Modified,
        Activated
    }

    public class CrudMessage : IMessage
    {
        public CrudAction Action { get; set; }

        public Guid InitiatingUserId { get; set; }
    }
}