using System;
using System.Collections;
using System.Collections.Generic;
using SharpStore.Data;
using SharpStore.Data.Models;
using SharpStore.Utils;

namespace SharpStore.Services
{
    public class MessagesService
    {
        private SharpStoreContext context;

        public MessagesService()
        {
            this.context = Data.Data.Context;
        }

        public void AddMessageFromFormData(string content)
        {
            IDictionary<string, string> formDataVariables = VariablesExtractor.ExtractVariables(content);
            Message message = new Message()
            {
                MessageText = formDataVariables["message"],
                Sender = formDataVariables["email"],
                Subject = formDataVariables["subject"]
            };

            this.context.Messages.Add(message);
            this.context.SaveChanges();
        }
    }
}
