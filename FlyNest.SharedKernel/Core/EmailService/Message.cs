﻿using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Http;
using MimeKit;

namespace FlyNest.SharedKernel.Core.EmailService;

public class Message(IEnumerable<string> to, string subject, string content, IFormFileCollection attachments)
{
    public List<MailboxAddress> To { get; set; } = [.. to.Select(x => MailboxAddress.Parse(x))];
    public string Subject { get; set; } = subject;
    public string Content { get; set; } = content;
    public IFormFileCollection Attachments { get; set; } = attachments;
}
