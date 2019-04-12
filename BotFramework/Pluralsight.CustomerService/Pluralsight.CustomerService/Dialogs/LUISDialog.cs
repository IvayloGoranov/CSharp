using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Pluralsight.CustomerService.Models;
using Pluralsight.CustomerService.Models.Facebook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Pluralsight.CustomerService.Dialogs
{
    [LuisModel("", "", domain: "", Staging = true)]
    [Serializable]
    public class LUISDialog : LuisDialog<BugReport>
    {
        private readonly BuildFormDelegate<BugReport> NewBugReport;

        public LUISDialog(BuildFormDelegate<BugReport> newBugReport)
        {
            this.NewBugReport = newBugReport;
        }


        [LuisIntent("")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("I'm sorry I don't know what you mean.");
            context.Wait(MessageReceived);
        }

        [LuisIntent("Greeting")]
        public async Task Greeting(IDialogContext context, LuisResult result)
        {
            context.Call(new GreetingDialog(), Callback);
        }

        private async Task Callback(IDialogContext context, IAwaitable<object> result)
        {
            context.Wait(MessageReceived);
        }

        [LuisIntent("NewBugReport")]
        public async Task BugReport(IDialogContext context, LuisResult result)
        {
            var enrollmentForm = new FormDialog<BugReport>(new BugReport(), this.NewBugReport, FormOptions.PromptInStart);
            context.Call<BugReport>(enrollmentForm, Callback);
        }

        [LuisIntent("QueryBugTypes")]
        public async Task QueryBugTypes(IDialogContext context, LuisResult result)
        {
            foreach (var entity in result.Entities.Where(Entity => Entity.Type == "BugType"))
            {
                var value = entity.Entity.ToLower();
                if (Enum.GetNames(typeof(BugType)).Where(a => a.ToLower().Equals(value)).Count() > 0)
                {
                    var replyMessage = context.MakeMessage();
                    replyMessage.Text = "Yes that is a bug type!";
                    var facebookMessage = new FacebookSendMessage();
                    facebookMessage.attachment = new FacebookAttachment();
                    facebookMessage.attachment.Type = FacebookAttachmentTypes.template;
                    facebookMessage.attachment.Payload = new FacebookPayload();
                    facebookMessage.attachment.Payload.TemplateType = FacebookTemplateTypes.generic;

                    var bugType = new FacebookElement();
                    bugType.Title = value;
                    switch (value)
                    {
                        case "security":
                            bugType.ImageUrl = "https://c1.staticflickr.com/9/8604/16042227002_1d00e0771d_b.jpg";
                            bugType.Subtitle = "This is a description of the security bug type";
                            break;
                        case "crash":
                            bugType.ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/5/50/Windows_7_BSOD.png";
                            bugType.Subtitle = "This is a description of the crash bug type";
                            break;
                        case "power":
                            bugType.ImageUrl = "https://www.publicdomainpictures.net/en/view-image.php?image=1828&picture=power-button";
                            bugType.Subtitle = "This is a description of the power bug type";
                            break;
                        case "performance":
                            bugType.ImageUrl = "https://commons.wikimedia.org/wiki/File:High_Performance_Computing_Center_Stuttgart_HLRS_2015_07_Cray_XC40_Hazel_Hen_IO.jpg";
                            bugType.Subtitle = "This is a description of the performance bug type";
                            break;
                        case "usability":
                            bugType.ImageUrl = "https://commons.wikimedia.org/wiki/File:03-Pau-DevCamp-usability-testing.jpg";
                            bugType.Subtitle = "This is a description of the usability bug type";
                            break;
                        case "seriousbug":
                            bugType.ImageUrl = "https://commons.wikimedia.org/wiki/File:Computer_bug.svg";
                            bugType.Subtitle = "This is a description of the serious bug type";
                            break;
                        case "other":
                            bugType.ImageUrl = "https://commons.wikimedia.org/wiki/File:Symbol_Resin_Code_7_OTHER.svg";
                            bugType.Subtitle = "This is a description of the other bug type";
                            break;
                        default:
                            break;
                    }
                    facebookMessage.attachment.Payload.Elements = new FacebookElement[] { bugType };
                    replyMessage.ChannelData = facebookMessage;
                    await context.PostAsync(replyMessage);
                    context.Wait(MessageReceived);
                    return;
                }
                else
                {
                    await context.PostAsync("I'm sorry that is not a bug type.");
                    context.Wait(MessageReceived);
                    return;
                }
            }
            await context.PostAsync("I'm sorry that is not a bug type.");
            context.Wait(MessageReceived);
            return;
        }

    }
}