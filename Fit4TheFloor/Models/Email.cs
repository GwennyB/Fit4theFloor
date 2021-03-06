﻿using Amazon;
using System;
using System.Collections.Generic;
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;
using System.Threading.Tasks;

namespace Fit4TheFloor.Models
{
    public class Email
    {
        public string Sender { get; set; } = "admin@thesiltonfoundation.org";
        public string Recipient { get; set; }
        public string ConfigSet { get; set; }
        public string Subject { get; set; }
        public string BodyHtml { get; set; }
        public string BodyText { get; set; } = "Sent on behalf of Fit4theFloor using Amazon Simple Email Service";


        /// <summary>
        /// Sends an email (specified per Email class properties) using AWS Simple Email Service
        /// </summary>
        /// <returns> email send success (boolean) </returns>
        public async Task<bool> Send()
        {
            bool status = false;

            {

                using (var client = new AmazonSimpleEmailServiceClient(RegionEndpoint.USWest2))
                {
                    var sendRequest = new SendEmailRequest
                    {
                        Source = Sender,
                        Destination = new Destination
                        {
                            ToAddresses =
                            new List<string> { Recipient }
                        },
                        Message = new Message
                        {
                            Subject = new Content(Subject),
                            Body = new Body
                            {
                                Html = new Content
                                {
                                    Charset = "UTF-8",
                                    Data = BodyHtml
                                },
                                Text = new Content
                                {
                                    Charset = "UTF-8",
                                    Data = BodyText
                                }
                            }
                        },
                        // If you are not using a configuration set, comment
                        // or remove the following line 
                        // ConfigurationSetName = ConfigSet
                    };
                    try
                    {
                        Console.WriteLine("Sending email using Amazon SES...");
                        var response = await client.SendEmailAsync(sendRequest);
                        status = true;
                        Console.WriteLine("The email was sent successfully.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("The email was not sent.");
                        Console.WriteLine("Error message: " + ex.Message);

                    }
                }
                return status;
            }
        }
    }
}
