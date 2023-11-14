using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace ContractManagment.Client.State.XmlProviders
{
    public class XmlProvider : IXmlProvider
    {
        private readonly XDocument _userDoc;
        private readonly XDocument _settingsDoc;
        public XmlProvider()
        {
            _userDoc = XDocument.Load("UserInfo.xml");
            _settingsDoc = XDocument.Load("appsettings.xml");

            if(_userDoc == null)
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
            if(isRemember == null)
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
                return userInfo.Element("Token").Value;
            }
            set
            {
                XElement userInfo = _userDoc.Element("userinfo");
                XElement token = userInfo.Element("Token");
                token.Value = value;
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

        public string IsRemember
        {
            get
            {
                XElement settingsInfo = _settingsDoc.Element("settings");
                return settingsInfo.Element("IsRemember").Value;
            }
            set
            {
                XElement settingsInfo = _settingsDoc.Element("settings");
                XElement isRemember = settingsInfo.Element("IsRemember");
                isRemember.Value = value;
                _settingsDoc.Save("appsettings.xml");
            }
        }
    }
}
