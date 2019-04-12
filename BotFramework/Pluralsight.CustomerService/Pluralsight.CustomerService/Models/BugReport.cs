using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pluralsight.CustomerService.Models
{
    public enum BugType
    {
        Security = 1,
        Crash = 2,
        Power = 3,
        Performance = 4,
        Usability = 5,
        SeriousBug = 6,
        Other = 7
    }

    public enum Reproducibility
    {
        Always = 1,
        Sometimes = 2,
        Rarely = 3,
        Unable = 4
    }

    [Serializable]
    public class BugReport
    {
        public string Title;
        [Prompt("Enter a description for your report")]
        public string Description;
        [Prompt("What is your first name?")]
        public string FirstName;
        [Describe("Last Name")]
        public string LastName;
        [Prompt("What is the best date and time for a callback?")]
        public DateTime? BestTimeOfDayToCall;
        [Pattern("^(\\+\\d{1,2}\\s)?\\(?\\d{3}\\)?[\\s.-]\\d{3}[\\s.-]\\d{4}$")]
        public string PhoneNumber;
        [Prompt("Please list the bug areas that best describe your issue. {||}")]
        public List<BugType> Bug;
        public Reproducibility Reproduce;
        public static IForm<BugReport> BuildForm()
        {
            return new FormBuilder<BugReport>().Build();
        }
    }
}