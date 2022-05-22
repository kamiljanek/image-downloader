using System;
using System.IO;
using System.Net.Mail;

namespace ImageDownloader
{
    public class EmailSender
    {
        public static void Sender(string gmailAddress, string gmailPassword)
        {
            try
            {
                SmtpClient mailServer = new SmtpClient("smtp.gmail.com", 587);
                mailServer.EnableSsl = true;

                mailServer.Credentials = new System.Net.NetworkCredential(gmailAddress, gmailPassword);

                string from = gmailAddress;
                string to = gmailAddress;
                MailMessage msg = new MailMessage(from, to);
                msg.Subject = "Flymet forecast";
                msg.Body = "Have a nice day";

                DirectoryInfo d = new DirectoryInfo(Directory.GetCurrentDirectory()); //relative folder path
                FileInfo[] Files = d.GetFiles("*.png"); //Getting all image files
                foreach (FileInfo file in Files)
                {
                    msg.Attachments.Add(new Attachment(file.Name));
                }
                mailServer.Send(msg);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to send email. Error : " + ex);
            }

        }
    }
}
