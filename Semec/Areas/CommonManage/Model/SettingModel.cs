using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Semec.Areas.CommonManage.Model
{
    public class SettingModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SettingID { get; set; }
        
        // SMS 
        [Display(Name = "SMS Password Recovery")]
        public bool SmsPasswordRecoveryOTP { get; set; }

        [Display(Name = "SMS Mobile Verification")]
        public bool SmsMobileVerificationOTP { get; set; }

        [Display(Name = "SMS Order Confirm")]
        public bool SmsOrderConfirm { get; set; }

        [Display(Name = "SMS Online Payment Confirm")]
        public bool SmsOnlinePaymentConfirm { get; set; }

        [Display(Name = "SMS Offline Payment Confirm")]
        public bool SmsOfflinePaymentConfirm { get; set; }

        [Display(Name = "SMS Work Progress Update")]
        public bool SmsWorkProgressUpdate { get; set; }

        [Display(Name = "SMS Manual Payment Reminder")]
        public bool SmsMaunalPaymentReminder { get; set; }

        [Display(Name = "SMS Auto Payment Reminder")]
        public bool SmsAutoPaymentReminder { get; set; }

        [Display(Name = "SMS Direct to Customer")]
        public bool SmsDirectToCustomer { get; set; }

        [Display(Name = "SMS Notice to Employee")]
        public bool SmsNoticToEmployee { get; set; }

        [Display(Name = "SMS Multiple Message for Marketing")]
        public bool SmsMultipleMarketing { get; set; }

        [Display(Name = "SMS Testing Purpose")]
        public bool SmsTestingPurpose { get; set; }


        // Email 
        [Display(Name = "Email Password Recovery")]
        public bool EmailPasswordRecoveryOTP { get; set; }

        [Display(Name = "Email Mobile Verification")]
        public bool EmailMobileVerificationOTP { get; set; }

        [Display(Name = "Email Order Confirm")]
        public bool EmailOrderConfirm { get; set; }

        [Display(Name = "Email Online Payment Confirm")]
        public bool EmailOnlinePaymentConfirm { get; set; }

        [Display(Name = "Email Offline Payment Confirm")]
        public bool EmailOfflinePaymentConfirm { get; set; }

        [Display(Name = "Email Work Progress Update")]
        public bool EmailWorkProgressUpdate { get; set; }

        [Display(Name = "Email Manual Payment Reminder")]
        public bool EmailMaunalPaymentReminder { get; set; }

        [Display(Name = "Email Auto Payment Reminder")]
        public bool EmailAutoPaymentReminder { get; set; }

        [Display(Name = "Email Direct to Customer")]
        public bool EmailDirectToCustomer { get; set; }

        [Display(Name = "Email Notice to Employee")]
        public bool EmailNoticToEmployee { get; set; }

        [Display(Name = "Email Multiple Message for Marketing")]
        public bool EmailMultipleMarketing { get; set; }

        [Display(Name = "Email Testing Purpose")]
        public bool EmailTestingPurpose { get; set; }
    }
}
