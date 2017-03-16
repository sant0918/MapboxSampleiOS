//
// ---------------
// 
// Copyright (c) 2008-2014 PhoneFactor, Inc.
// 
// Permission is hereby granted, free of charge, to any person
// obtaining  a copy of this software and associated documentation
// files (the "Software"),  to deal in the Software without
// restriction, including without limitation the  rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or
// sell copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following
// conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT  SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,  ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER  DEALINGS IN THE SOFTWARE.
// 
// ---------------
//

using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Security.Cryptography;

public partial class example : System.Web.UI.Page
{
  protected void btnTest_Click(object sender, EventArgs e)
  {
    string otp = "";
    int callStatus = 0;
    int errorId = 0;

    // note that the phone number contains no dashes, spaces, or any other
    // special characters.
    PfAuthParams pfAuthParams = new PfAuthParams();
    pfAuthParams.Username = txtUsername.Text;
    pfAuthParams.Phone = txtPhone.Text;
    pfAuthParams.Extension = txtExtension.Text;
    pfAuthParams.ApplicationName = txtApplicationName.Text;
    pfAuthParams.DeviceToken = txtDeviceToken.Text;
    if (rbApns.Checked) pfAuthParams.NotificationType = pf_auth.NOTIFICATION_TYPE_APNS;
    if (rbC2dm.Checked) pfAuthParams.NotificationType = pf_auth.NOTIFICATION_TYPE_C2DM;
    if (rbGcm.Checked) pfAuthParams.NotificationType = pf_auth.NOTIFICATION_TYPE_GCM;
    if (rbMpns.Checked) pfAuthParams.NotificationType = pf_auth.NOTIFICATION_TYPE_MPNS;
    if (rbBps.Checked) pfAuthParams.NotificationType = pf_auth.NOTIFICATION_TYPE_BPS;
    pfAuthParams.AccountName = txtAccountName.Text;
    if (rbStandard.Checked) pfAuthParams.Mode = pf_auth.MODE_STANDARD;
    if (rbPin.Checked) pfAuthParams.Mode = pf_auth.MODE_PIN;
    if (rbVoiceprint.Checked) pfAuthParams.Mode = pf_auth.MODE_VOICEPRINT;
    if (rbSmsTwoWayOtp.Checked) pfAuthParams.Mode = pf_auth.MODE_SMS_TWO_WAY_OTP;
    if (rbSmsTwoWayOtpPlusPin.Checked) pfAuthParams.Mode = pf_auth.MODE_SMS_TWO_WAY_OTP_PLUS_PIN;
    if (rbSmsOneWayOtp.Checked) pfAuthParams.Mode = pf_auth.MODE_SMS_ONE_WAY_OTP;
    if (rbSmsOneWayOtpPlusPin.Checked) pfAuthParams.Mode = pf_auth.MODE_SMS_ONE_WAY_OTP_PLUS_PIN;
    if (rbPhoneAppStandard.Checked) pfAuthParams.Mode = pf_auth.MODE_PHONE_APP_STANDARD;
    if (rbPhoneAppPin.Checked) pfAuthParams.Mode = pf_auth.MODE_PHONE_APP_PIN;
    if (rbPin.Checked || rbSmsTwoWayOtpPlusPin.Checked || rbPhoneAppPin.Checked)
    {
      if (rbSha1.Checked)
      {
        // Generate a random string for the salt
        byte[] randomArray = new byte[8];
        string randomString;
        RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
        rng.GetBytes(randomArray);
        randomString = Convert.ToBase64String(randomArray);

        string pin = txtPin.Text;
        string salt = randomString;
        byte[] saltedPinByteArray = Encoding.UTF8.GetBytes(pin + salt);
        SHA1CryptoServiceProvider sha1CryptoServiceProvider = new SHA1CryptoServiceProvider();
        string sha1PinHash = BitConverter.ToString(sha1CryptoServiceProvider.ComputeHash(saltedPinByteArray)).Replace("-", "").ToLower();
        pfAuthParams.Sha1PinHash = sha1PinHash;
        pfAuthParams.Sha1Salt = salt;
      }
      else
      {
        pfAuthParams.Pin = txtPin.Text;
      }
    }
    if (rbSmsTwoWayOtp.Checked) pfAuthParams.SmsText = "<$otp$>\nReply with this verification code to complete your sign in verification.";
    if (rbSmsTwoWayOtpPlusPin.Checked) pfAuthParams.SmsText = "<$otp$>\nReply with this verification code and your PIN to complete your sign in verification.";
    if (rbSmsOneWayOtp.Checked) pfAuthParams.SmsText = "<$otp$>\nEnter this verification code when prompted by your application to complete your sign in verification.";
    if (rbSmsOneWayOtpPlusPin.Checked) pfAuthParams.SmsText = "<$otp$>\nEnter this verification code and your PIN when prompted by your application to complete your sign in verification.";
    pfAuthParams.Hostname = "TestHostName";
    pfAuthParams.IpAddress = "255.255.255.255";
    pfAuthParams.CertFilePath = "C:\\cert_key.p12";

    bool res = pf_auth.pf_authenticate(pfAuthParams, out otp, out callStatus, out errorId);

    // the return value from the above function is a boolean that is the result of
    // the authentication.  Two out arguments are also returned.  The first is the
    // result of the phonecall itself, the second is the result of the connection
    // with the PhoneFactor backend.  See call_results.txt for a list of call results
    // and descriptions that correspond to value returned.
    Label1.Text = res.ToString();
    Label2.Text = otp;
    Label3.Text = callStatus.ToString();
    Label4.Text = errorId.ToString();
  }

  protected void btnResetVoiceprint_Click(object sender, EventArgs e)
  {
    int result = 0;
    int errorId = 0;

    ResetVoiceprintParams resetVoiceprintParams = new ResetVoiceprintParams();
    resetVoiceprintParams.Username = txtUsername.Text;
    resetVoiceprintParams.Hostname = "TestHostName";
    resetVoiceprintParams.IpAddress = "255.255.255.255";
    resetVoiceprintParams.CertFilePath = "C:\\cert_key.p12";

    bool res = pf_auth.reset_voiceprint(resetVoiceprintParams, out result, out errorId);

    // the return value from the above function is a boolean that is the result of
    // the reset voiceprint.  Two out arguments are also returned.  The first is the
    // result of the reset itself, the second is the result of the connection
    // with the PhoneFactor backend.
    // Results:
    // 1 - Success
    // 2 - Voiceprint Already Reset
    // 3 - Server Error
    Label5.Text = res.ToString();
    Label6.Text = result.ToString();
    Label7.Text = errorId.ToString();
  }

  protected void btnValidateDeviceToken_Click(object sender, EventArgs e)
  {
    int result = 0;
    int errorId = 0;

    ValidateDeviceTokenParams validateDeviceTokenParams = new ValidateDeviceTokenParams();
    validateDeviceTokenParams.Username = txtUsername.Text;
    validateDeviceTokenParams.DeviceToken = txtDeviceToken.Text;
    if (rbApns.Checked) validateDeviceTokenParams.NotificationType = pf_auth.NOTIFICATION_TYPE_APNS;
    if (rbC2dm.Checked) validateDeviceTokenParams.NotificationType = pf_auth.NOTIFICATION_TYPE_C2DM;
    if (rbGcm.Checked) validateDeviceTokenParams.NotificationType = pf_auth.NOTIFICATION_TYPE_GCM;
    if (rbMpns.Checked) validateDeviceTokenParams.NotificationType = pf_auth.NOTIFICATION_TYPE_MPNS;
    if (rbBps.Checked) validateDeviceTokenParams.NotificationType = pf_auth.NOTIFICATION_TYPE_BPS;
    validateDeviceTokenParams.AccountName = txtAccountName.Text;
    validateDeviceTokenParams.Hostname = "TestHostName";
    validateDeviceTokenParams.IpAddress = "255.255.255.255";
    validateDeviceTokenParams.CertFilePath = "C:\\cert_key.p12";

    bool res = pf_auth.validate_device_token(validateDeviceTokenParams, out result, out errorId);

    // the return value from the above function is a boolean that is the result of
    // the validate device token.  Two out arguments are also returned.  The first is the
    // result of the validation itself, the second is the result of the connection
    // with the PhoneFactor backend.
    // Results:
    // 1 - Device Valid
    // 2 - Device Invalid
    // 3 - Time Out
    // 4 - User Blocked  
    Label8.Text = res.ToString();
    Label9.Text = result.ToString();
    Label10.Text = errorId.ToString();
  }
}
