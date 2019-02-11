using OpenSSL.PrivateKeyDecoder;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Ancorupt
{
    class RSAHelper
    {
        // RSA ключ сгенерированный с помощью OpenSSL
        private readonly string rsaKey = @"YOUR RSA PRIVATE KEY";
        private RSACryptoServiceProvider ServerRSA { get; set; }

        public RSAHelper()
        {
            // IOpenSSLPrivateKeyDecoder декодирует строку с ключем сгенерированным библиотекой OpenSSL
            // в RSACryptoServiceProvider (.NET реализация RSA)
            IOpenSSLPrivateKeyDecoder decoder = new OpenSSLPrivateKeyDecoder();
            ServerRSA = decoder.Decode(rsaKey);
        }

        /// <summary>
        /// Расшифровывает входную строку
        /// </summary>
        /// <param name="message">Зашифрованная строка</param>
        /// <param name="base64mode">True - если строка message зашифрована дополнительно base64</param>
        /// <returns>Возвращает string результат дешифрования</returns>
        public string Decrypt(string message, bool base64mode = false)
        {
            byte[] fromBase64 = Encoding.UTF8.GetBytes(message.Replace("\"", ""));
            if (base64mode)
            {
                fromBase64 = Convert.FromBase64String(message.Replace("\"", ""));
            }
            return Encoding.UTF8.GetString(ServerRSA.Decrypt(fromBase64, false));
        }
    }
}
