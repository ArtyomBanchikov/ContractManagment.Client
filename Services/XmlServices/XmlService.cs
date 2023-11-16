using ContractManagment.Client.State;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Windows.Xps.Serialization;
using System.Xml.Linq;

namespace ContractManagment.Client.Services.XmlServices
{
    public class XmlService : IXmlService
    {
        private readonly XDocument _userDoc;
        private readonly XDocument _settingsDoc;
        public XmlService()
        {
            _userDoc = XDocument.Load("UserInfo.xml");
            _settingsDoc = XDocument.Load("appsettings.xml");

            if (_userDoc == null)
            {
                _userDoc = new XDocument();
            }
            XElement userInfo = _userDoc.Element("userinfo");
            if (userInfo == null)
            {
                userInfo = new XElement("userinfo");
                _userDoc.Add(userInfo);
            }
            XElement token = userInfo.Element("Token");
            if (token == null)
            {
                token = new XElement("Token");
                userInfo.Add(token);
            }


            if (_settingsDoc == null)
            {
                _settingsDoc = new XDocument();
            }
            XElement settingsInfo = _settingsDoc.Element("settings");
            if (settingsInfo == null)
            {
                settingsInfo = new XElement("settings");
                _settingsDoc.Add(settingsInfo);
            }
            XElement isRemember = settingsInfo.Element("IsRemember");
            if (isRemember == null)
            {
                isRemember = new XElement("IsRemember");
                settingsInfo.Add(isRemember);
            }
            XElement serverAddress = settingsInfo.Element("ServerAddress");
            if (serverAddress == null)
            {
                serverAddress = new XElement("ServerAddress");
                settingsInfo.Add(serverAddress);
            }


            _userDoc.Save("UserInfo.xml");
            _settingsDoc.Save("appsettings.xml");
        }

        public string Token
        {
            get
            {
                XElement userInfo = _userDoc.Element("userinfo");
                string token = userInfo.Element("Token").Value;

                if (!string.IsNullOrEmpty(token))
                {
                    byte[] encodedBytes = token.InByteArray();
                    byte[] plaintextBytes = ProtectedData.Unprotect(encodedBytes, null, DataProtectionScope.CurrentUser);

                    return plaintextBytes.ToHexString();
                }
                else
                    return token;
            }
            set
            {
                XElement userInfo = _userDoc.Element("userinfo");
                XElement token = userInfo.Element("Token");

                if (!string.IsNullOrEmpty(value))
                {
                    byte[] plaintextBytes = value.ToByteArray();
                    byte[] encodedBytes = ProtectedData.Protect(plaintextBytes, null, DataProtectionScope.CurrentUser);

                    token.Value = encodedBytes.InString();
                }
                else
                    token.Value = "";
                
                _userDoc.Save("UserInfo.xml");
             }
        }

        public string ServerAddress
        {
            get
            {
                XElement settingsInfo = _settingsDoc.Element("settings");
                return settingsInfo.Element("ServerAddress").Value;
            }
            set
            {
                XElement settingsInfo = _settingsDoc.Element("settings");
                XElement serverAddress = settingsInfo.Element("ServerAddress");
                serverAddress.Value = value;
                _settingsDoc.Save("appsettings.xml");
            }
        }

        public bool IsRemember
        {
            get
            {
                XElement settingsInfo = _settingsDoc.Element("settings");
                bool succes = false;
                bool.TryParse(settingsInfo.Element("IsRemember").Value, out succes);
                return succes;
            }
            set
            {
                XElement settingsInfo = _settingsDoc.Element("settings");
                XElement isRemember = settingsInfo.Element("IsRemember");
                isRemember.Value = value.ToString();
                _settingsDoc.Save("appsettings.xml");
            }
        }
    }
}
