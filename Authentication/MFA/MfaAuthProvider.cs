using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Text;
using System.Security.Cryptography;

namespace Authentication.MFA
{
    public class MfaAuthProvider
    {
        private PfAuthParams pfAuthParams = new PfAuthParams();
        public bool useSha1 = true;

        public MfaAuthProvider(PfAuthParams pfAuthParams)
        {
            this.pfAuthParams = pfAuthParams;
        }

        public bool Auth()
        {
            string otp = "";
            int callStatus = 0;
            int errorId = 0;

            // note that the phone number contains no dashes, spaces, or any other
            // special characters.
         
            if (pfAuthParams.Mode == pf_auth.MODE_PIN || pfAuthParams.Mode == pf_auth.MODE_SMS_TWO_WAY_OTP_PLUS_PIN || pfAuthParams.Mode == pf_auth.MODE_PHONE_APP_PIN)
            {
                if (useSha1)
                {
                    // Generate a random string for the salt
                    byte[] randomArray = new byte[8];
                    string randomString;
                    RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
                    rng.GetBytes(randomArray);
                    randomString = Convert.ToBase64String(randomArray);

                    string pin = pfAuthParams.Pin;
                    string salt = randomString;
                    byte[] saltedPinByteArray = Encoding.UTF8.GetBytes(pin + salt);
                    SHA1CryptoServiceProvider sha1CryptoServiceProvider = new SHA1CryptoServiceProvider();
                    string sha1PinHash = BitConverter.ToString(sha1CryptoServiceProvider.ComputeHash(saltedPinByteArray)).Replace("-", "").ToLower();
                    pfAuthParams.Sha1PinHash = sha1PinHash;
                    pfAuthParams.Sha1Salt = salt;
                }
               
            }            
            pfAuthParams.Hostname = "TestHostName";
            pfAuthParams.IpAddress = "255.255.255.255";
            pfAuthParams.CertFilePath = "C:\\Users\\javiersa\\OneDrive\\visual studio\\Point of Sales\\PoS\\Authentication\\cert_key.p12";

            return pf_auth.pf_authenticate(pfAuthParams, out otp, out callStatus, out errorId);

            
        }
    }
}
