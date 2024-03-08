using Heatray.Domain.Abstractions.Models;

namespace Heatray.Domain.Messages.MessageParts.MailMessage;

public class FileAttachment : StronglyTypedValue<Guid>
{
    public string FilePath { get; private set; }

    private FileAttachment()
    {
    }

    private FileAttachment(string filePath) : base(Guid.NewGuid())
    {
        FilePath = filePath;
    }

    public FileAttachment Create(string filePath)
    {
        var attachment = new FileAttachment(filePath);
        return attachment;
    }
}