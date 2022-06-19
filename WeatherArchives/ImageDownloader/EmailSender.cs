﻿using Flymet;
using Model;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;

namespace ImageDownloader
{
    public class EmailSender
    {
        private readonly IFileOperation _fileOperation;

        public EmailSender(IFileOperation fileOperation)
        {
            _fileOperation = fileOperation;
        }
        public void SendEmail(IGenerate forecastPage)
        {
            var gmailFileReaded = _fileOperation.FileReader<string>(ConstantValue.GmailFilePath);
            var gmailAddress = gmailFileReaded[0];
            var emailPassword = gmailFileReaded[1];
            var extencion = forecastPage.GenerateUrl().Split('.').Last();
            try
            {
                SmtpClient mailServer = new SmtpClient("smtp.gmail.com", 587);
                mailServer.EnableSsl = true;

                mailServer.Credentials = new NetworkCredential(gmailAddress, emailPassword);

                string from = gmailAddress;
                string to = gmailAddress;
                MailMessage msg = new MailMessage(from, to);
                msg.Subject = forecastPage.Name;
                msg.Body = "Have a nice day";

                DirectoryInfo d = new DirectoryInfo(Directory.GetCurrentDirectory()); //relative folder path
                FileInfo[] Files = d.GetFiles($"*{extencion}"); //Getting all image files
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
