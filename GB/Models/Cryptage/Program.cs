using GB.Models.Static;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace GB.Models.Cryptage
{
    public static class Program
    {
        //  Call this function to remove the key from memory after use for security
        [System.Runtime.InteropServices.DllImport("KERNEL32.DLL", EntryPoint = "RtlZeroMemory")]
        public static extern bool ZeroMemory(IntPtr Destination, int Length);
        private static byte[] _salt = Encoding.ASCII.GetBytes("o6806642kbM7c5");

        /// <summary>
        /// Encrypt the given string using AES.  The string can be decrypted using 
        /// </summary>
        /// <param name="plainText">The text to encrypt.</param>
        public static string EncryptStringAES(string plainText)
        {
            if (string.IsNullOrEmpty(plainText))
                throw new ArgumentNullException("plainText");

            string outStr = null;                       // Encrypted string to return
            RijndaelManaged aesAlg = null;              // RijndaelManaged object used to encrypt the data.

            try
            {
                // generate the key from the shared secret and the salt
                Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(AppSettings.ENCRYPTION_KEY_AES, _salt);

                // Create a RijndaelManaged object
                aesAlg = new RijndaelManaged();
                aesAlg.Key = key.GetBytes(aesAlg.KeySize / 8);

                // Create a decryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    // prepend the IV
                    msEncrypt.Write(BitConverter.GetBytes(aesAlg.IV.Length), 0, sizeof(int));
                    msEncrypt.Write(aesAlg.IV, 0, aesAlg.IV.Length);
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                    }
                    outStr = Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
            finally
            {
                // Clear the RijndaelManaged object.
                if (aesAlg != null)
                    aesAlg.Clear();
            }

            // Return the encrypted bytes from the memory stream.
            return outStr;
        }

        /// <summary>
        /// Decrypt the given string.  Assumes the string was encrypted using 
        /// </summary>
        /// <param name="cipherText">The text to decrypt.</param>
        public static string DecryptStringAES(string cipherText)
        {
            if (string.IsNullOrEmpty(cipherText))
                throw new ArgumentNullException("cipherText");

            // Declare the RijndaelManaged object
            // used to decrypt the data.
            RijndaelManaged aesAlg = null;

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            try
            {
                // generate the key from the shared secret and the salt
                Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(AppSettings.ENCRYPTION_KEY_AES, _salt);

                // Create the streams used for decryption.                
                byte[] bytes = Convert.FromBase64String(
                                    Correction_Base64(cipherText)
                               );
                using (MemoryStream msDecrypt = new MemoryStream(bytes))
                {
                    // Create a RijndaelManaged object
                    // with the specified key and IV.
                    aesAlg = new RijndaelManaged();
                    aesAlg.Key = key.GetBytes(aesAlg.KeySize / 8);
                    // Get the initialization vector from the encrypted stream
                    aesAlg.IV = ReadByteArray(msDecrypt);
                    // Create a decrytor to perform the stream transform.
                    ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                    }
                }
            }
            finally
            {
                // Clear the RijndaelManaged object.
                if (aesAlg != null)
                    aesAlg.Clear();
            }

            return plaintext;
        }

        private static byte[] ReadByteArray(Stream s)
        {
            byte[] rawLength = new byte[sizeof(int)];
            if (s.Read(rawLength, 0, rawLength.Length) != rawLength.Length)
            {
                throw new SystemException("Stream did not contain properly formatted byte array");
            }

            byte[] buffer = new byte[BitConverter.ToInt32(rawLength, 0)];
            if (s.Read(buffer, 0, buffer.Length) != buffer.Length)
            {
                throw new SystemException("Did not read byte array properly");
            }

            return buffer;
        }

        // Function to Generate a 64 bits Key.
        static string GenerateKey()
        {
            // Create an instance of Symetric Algorithm. Key and IV is generated automatically.
            DESCryptoServiceProvider desCrypto = (DESCryptoServiceProvider)DESCryptoServiceProvider.Create();

            // Use the Automatically generated key for Encryption. 
            return ASCIIEncoding.ASCII.GetString(desCrypto.Key);
        }

        public static void EncryptFile(string sInputFilename,
           string sOutputFilename,
           string sKey)
        {
            FileStream fsInput = new FileStream(sInputFilename,
               FileMode.Open,
               FileAccess.Read);

            FileStream fsEncrypted = new FileStream(sOutputFilename,
               FileMode.Create,
               FileAccess.Write);
            DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
            DES.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            DES.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
            ICryptoTransform desencrypt = DES.CreateEncryptor();
            CryptoStream cryptostream = new CryptoStream(fsEncrypted,
               desencrypt,
               CryptoStreamMode.Write);

            byte[] bytearrayinput = new byte[fsInput.Length];
            fsInput.Read(bytearrayinput, 0, bytearrayinput.Length);
            cryptostream.Write(bytearrayinput, 0, bytearrayinput.Length);
            cryptostream.Close();
            fsInput.Close();
            fsEncrypted.Close();
        }

        public static void DecryptFile(string sInputFilename,
           string sOutputFilename,
           string sKey)
        {
            DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
            //A 64 bit key and IV is required for this provider.
            //Set secret key For DES algorithm.
            DES.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            //Set initialization vector.
            DES.IV = ASCIIEncoding.ASCII.GetBytes(sKey);

            //Create a file stream to read the encrypted file back.
            FileStream fsread = new FileStream(sInputFilename,
               FileMode.Open,
               FileAccess.Read);
            //Create a DES decryptor from the DES instance.
            ICryptoTransform desdecrypt = DES.CreateDecryptor();
            //Create crypto stream set to read and do a 
            //DES decryption transform on incoming bytes.
            CryptoStream cryptostreamDecr = new CryptoStream(fsread,
               desdecrypt,
               CryptoStreamMode.Read);
            //Print the contents of the decrypted file.
            StreamWriter fsDecrypted = new StreamWriter(sOutputFilename);
            fsDecrypted.Write(new StreamReader(cryptostreamDecr).ReadToEnd());
            fsDecrypted.Flush();
            fsDecrypted.Close();
        }

        #region Teste de methodes de cryptage
        /*
        private static void Main(string[] args)
        {
            // Must be 64 bits, 8 bytes.
            // Distribute this key to the user who will decrypt this file.
            string sSecretKey;

            // Get the Key for the file to Encrypt.
            sSecretKey = GenerateKey();

            // For additional security Pin the key.
            GCHandle gch = GCHandle.Alloc(sSecretKey, GCHandleType.Pinned);

            // Encrypt the file.        
            EncryptFile(@"E:\MyData.txt",
               @"E:\Encrypted.txt",
               sSecretKey);

            // Decrypt the file.
            DecryptFile(@"E:\Encrypted.txt",
               @"E:\Decrypted.txt",
               sSecretKey);

            // Remove the Key from memory. 
            ZeroMemory(gch.AddrOfPinnedObject(), sSecretKey.Length * 2);
            gch.Free();
        }
        */
        #endregion

        public static string EncryptString(string inputString)
        {
            MemoryStream memStream = null;
            try
            {
                byte[] key = { };
                byte[] IV = { 12, 21, 43, 17, 57, 35, 67, 27 };
                string encryptKey = "aXb2uy4z"; // MUST be 8 characters
                key = Encoding.UTF8.GetBytes(encryptKey);
                byte[] byteInput = Encoding.UTF8.GetBytes(inputString);
                DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
                memStream = new MemoryStream();
                ICryptoTransform transform = provider.CreateEncryptor(key, IV);
                CryptoStream cryptoStream = new CryptoStream(memStream, transform, CryptoStreamMode.Write);
                cryptoStream.Write(byteInput, 0, byteInput.Length);
                cryptoStream.FlushFinalBlock();
            }
            catch (Exception ex)
            {
                // -- Log -- //
                GBClass.Log.Error(ex);

                throw new Exception(ex.Message);
            }
            return Convert.ToBase64String(memStream.ToArray());
        }

        public static string DecryptString(string inputString)
        {
            MemoryStream memStream = null;
            try
            {
                byte[] key = { };
                byte[] IV = { 12, 21, 43, 17, 57, 35, 67, 27 };
                string encryptKey = "aXb2uy4z"; // MUST be 8 characters
                key = Encoding.UTF8.GetBytes(encryptKey);
                byte[] byteInput = new byte[inputString.Length];
                byteInput = Convert.FromBase64String(inputString);
                DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
                memStream = new MemoryStream();
                ICryptoTransform transform = provider.CreateDecryptor(key, IV);
                CryptoStream cryptoStream = new CryptoStream(memStream, transform, CryptoStreamMode.Write);
                cryptoStream.Write(byteInput, 0, byteInput.Length);
                cryptoStream.FlushFinalBlock();
            }
            catch (Exception ex)
            {
                // -- Log -- //
                GBClass.Log.Error(ex);

                throw new Exception(ex.Message);
            }

            Encoding encoding1 = Encoding.UTF8;
            return encoding1.GetString(memStream.ToArray());
        }

        private static string Correction_Base64(string value)
        {
            string dummyData = value.Trim().Replace(" ", "+");
            if (dummyData.Length % 4 > 0)
                dummyData = dummyData.PadRight(dummyData.Length + 4 - dummyData.Length % 4, '=');

            return dummyData;
        }
    }
}