using System.Text;
using System.Security.Cryptography;

namespace _02_XX_CI_CD_Azure_DevOps.WebApp.Util
{
    public class Criptografia
    {
        public static string md5encrypt(string frase)
        {
            UTF8Encoding encoder = new UTF8Encoding();
#pragma warning disable SYSLIB0021 // Type or member is obsolete
            MD5CryptoServiceProvider md5hasher = new MD5CryptoServiceProvider();
#pragma warning restore SYSLIB0021 // Type or member is obsolete
            byte[] hashedDataBytes = md5hasher.ComputeHash(encoder.GetBytes(frase));
            return byteArrayToString(hashedDataBytes);
        }

        public static string sha1encrypt(string frase)
        {
            UTF8Encoding encoder = new UTF8Encoding();
#pragma warning disable SYSLIB0021 // Type or member is obsolete
            SHA1CryptoServiceProvider sha1hasher = new SHA1CryptoServiceProvider();
#pragma warning restore SYSLIB0021 // Type or member is obsolete
            byte[] hashedDataBytes = sha1hasher.ComputeHash(encoder.GetBytes(frase));
            return byteArrayToString(hashedDataBytes);
        }

        public static string sha256encrypt(string frase)
        {
            UTF8Encoding encoder = new UTF8Encoding();
#pragma warning disable SYSLIB0021 // Type or member is obsolete
            SHA256Managed sha256hasher = new SHA256Managed();
#pragma warning restore SYSLIB0021 // Type or member is obsolete
            byte[] hashedDataBytes = sha256hasher.ComputeHash(encoder.GetBytes(frase));
            return byteArrayToString(hashedDataBytes);
        }

        public static string sha384encrypt(string frase)
        {
            UTF8Encoding encoder = new UTF8Encoding();
#pragma warning disable SYSLIB0021 // Type or member is obsolete
            SHA384Managed sha384hasher = new SHA384Managed();
#pragma warning restore SYSLIB0021 // Type or member is obsolete
            byte[] hashedDataBytes = sha384hasher.ComputeHash(encoder.GetBytes(frase));
            return byteArrayToString(hashedDataBytes);
        }

        public static string sha512encrypt(string frase)
        {
            UTF8Encoding encoder = new UTF8Encoding();
#pragma warning disable SYSLIB0021 // Type or member is obsolete
            SHA512Managed sha512hasher = new SHA512Managed();
#pragma warning restore SYSLIB0021 // Type or member is obsolete
            byte[] hashedDataBytes = sha512hasher.ComputeHash(encoder.GetBytes(frase));
            return byteArrayToString(hashedDataBytes);
        }

        public static string byteArrayToString(byte[] inputArray)
        {
            StringBuilder output = new StringBuilder("");
            for (int i = 0; i < inputArray.Length; i++)
            {
                output.Append(inputArray[i].ToString("X2"));
            }
            return output.ToString();
        }
    }
}