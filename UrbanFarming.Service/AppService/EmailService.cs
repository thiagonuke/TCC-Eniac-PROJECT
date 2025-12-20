using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using UrbanFarming.Domain.Classes;
using UrbanFarming.Domain.Interfaces.Services;

namespace UrbanFarming.Service.AppService
{
    public class EmailService
    {
        private readonly EmailSettings _settings;

        public EmailService(IOptions<EmailSettings> options)
        {
            _settings = options.Value;
        }

        public async Task EnviarEmailAsync(string para, string assunto, string mensagemHtml)
        {
            using var smtp = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("solutionszentrix2@gmail.com", "jssp vuaw tdhk ukuu"),
                EnableSsl = true
            };

            using var mail = new MailMessage()
            {
                From = new MailAddress("solutionszentrix2@gmail.com"),
                Subject = assunto,
                Body = mensagemHtml,
                IsBodyHtml = true
            };

            mail.To.Add(para);
            await smtp.SendMailAsync(mail);
        }
    }
}
