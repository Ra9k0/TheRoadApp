using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using TheRoadApp.Services.Interfaces;

namespace TheRoadApp.Services
{
	public class ContactService : IContactService
	{
		public Task SendEmailAsync(string fullName,string email, string subject, string message)
		{
			var mail = "rstambolijski@gmail.com";
			var pw = "qezs xobi rkyq wcmw";

			var client = new SmtpClient("smtp.gmail.com", 587)
			{
				EnableSsl = true,
				Credentials = new NetworkCredential(mail, pw)
			};

			MailMessage mailMessage = new MailMessage();

			mailMessage.From = new MailAddress(mail);
			mailMessage.To.Add(email);
			mailMessage.Subject = "Contact Us (" + subject + ")";
			mailMessage.Body = $"<h1>Dear {fullName},</h1>\r\n    <p>Thank you for reaching out to us! We appreciate your interest in The Road. Our team is here to assist you.</p>\r\n    <p><b>Your Message:</b></p>\r\n   <i><p>{message}</p></i>\r\n   <p>If you'd like to continue the conversation, please reply directly to this email. We're committed to providing timely and helpful responses.</p>\r\n  <p>We look forward to hearing from you!</p>\r\n    <p>Best regards,<b><br>The Road Support</p>.</b>";
			mailMessage.IsBodyHtml = true;


			return client.SendMailAsync(mailMessage);
		}
	}
}
