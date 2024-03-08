using Heatray.Domain.Messages.MessageParts.MailMessage;

namespace Heatray.Domain.Messages.TypedMessage;

public class MailMessage : MessageBase
{
    private readonly List<EmailAddress> _receivers = new();
    private readonly List<EmailAddress> _cc = new();
    private readonly List<EmailAddress> _bcc = new();
    private readonly List<FileAttachment> _attachments = new();

    public EmailAddress Sender { get; private set; }
    public string ReplyTo { get; private set; }
    public IReadOnlyList<EmailAddress> Receivers => _receivers;
    public IReadOnlyList<EmailAddress> Cc => _cc;
    public IReadOnlyList<EmailAddress> Bcc => _bcc;
    public string Subject { get;private  set; }
    public string BodyHtml { get; private set; }
    public string BodyText { get; private set; }
    public Dictionary<string, string> Headers { get; set; } = new();
    public IReadOnlyList<FileAttachment> AttacheAttachments => _attachments;

    private MailMessage()
    {
    }

    public override Task ProcessAsync()
    {
        throw new NotImplementedException();
    }
}