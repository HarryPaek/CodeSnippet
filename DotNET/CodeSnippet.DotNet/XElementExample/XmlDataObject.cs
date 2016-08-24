using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace XElementExample
{
    public class XmlDataObject
    {
        public XmlDataObject()
        {
            InitializeDataObjects();
        }

        public IList<ActivityWork> Input { get; private set; }
        public string Output { get; private set; }
        public IList<ActivityWork> Work { get; private set; }
        public string Map { get; private set; }
        public IList<ActivityUser> Users { get; private set; }

        #region Public Methods

        public void GenerateDataObject(string xmlData)
        {
            InitializeDataObjects();

            if (!string.IsNullOrWhiteSpace(xmlData))
            {
                try
                {
                    XDocument xmlDocument = XDocument.Parse(xmlData);
                    SetActivityDataObject(xmlDocument);
                }
                catch (XmlException)
                {
                    //throw;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public string GetXml()
        {
            return GetXml(SaveOptions.DisableFormatting);
        }

        public string GetXml(SaveOptions option)
        {
            return string.Format("<?xml version=\"1.0\" encoding=\"UTF-8\"?>{0}", GetActivityDataXml(option));
        }

        public void PrintDataObject()
        {
            StringBuilder dataObjectText = new StringBuilder();
            dataObjectText.AppendLine("##### %%%%% ##### %%%%% ##### %%%%% ##### %%%%% ##### %%%%% ##### %%%%% ##### %%%%% ##### %%%%% ##### %%%%% ##### %%%%% ##### %%%%% #####");
            dataObjectText.AppendLine("##### XML Data Object Information                                                                                                   #####");
            dataObjectText.AppendLine("=========================================================================================================================================");
            dataObjectText.Append(GetInputObjectText());
            dataObjectText.Append(GetOutputObjectText());
            dataObjectText.Append(GetWorkObjectText());
            dataObjectText.Append(GetMapObjectText());
            dataObjectText.Append(GetUserObjectText());
            dataObjectText.AppendLine("##### %%%%% ##### %%%%% ##### %%%%% ##### %%%%% ##### %%%%% ##### %%%%% ##### %%%%% ##### %%%%% ##### %%%%% ##### %%%%% ##### %%%%% #####");
            dataObjectText.AppendLine(string.Empty);

            Console.WriteLine(dataObjectText.ToString());
        }

        #endregion


        #region Private Method

        #region Print Methods

        private string GetInputObjectText()
        {
            if (this.Input == null || this.Input.Count == 0)
                return "\tInput is Empty\n";

            StringBuilder inputObjectText = new StringBuilder();

            for (int i = 0; i < this.Input.Count; i++)
            {
                inputObjectText.AppendFormat("\tInput[{0}] = {1}\n", i, Input[i]);
            }

            return inputObjectText.ToString();
        }

        private string GetOutputObjectText()
        {
            if(string.IsNullOrWhiteSpace(this.Output))
                return "\tOutput is Empty\n";

            return string.Format("\tOutput = [{0}]\n", this.Output);
        }

        private string GetWorkObjectText()
        {
            if (this.Work == null || this.Work.Count == 0)
                return "\tWork is Empty\n";

            StringBuilder workObjectText = new StringBuilder();

            for (int i = 0; i < this.Work.Count; i++)
            {
                workObjectText.AppendFormat("\tWork[{0}] = {1}\n", i, Work[i]);
            }

            return workObjectText.ToString();
        }

        private string GetMapObjectText()
        {
            if (string.IsNullOrWhiteSpace(this.Map))
                return "\tMap is Empty\n";

            return string.Format("\tMap = [{0}]\n", this.Map);
        }

        private string GetUserObjectText()
        {
            if (this.Users == null || this.Users.Count == 0)
                return "\tUser is Empty\n";

            StringBuilder userObjectText = new StringBuilder();

            for (int i = 0; i < this.Users.Count; i++)
            {
                userObjectText.AppendFormat("\tUser[{0}] = {1}\n", i, Users[i]);
            }

            return userObjectText.ToString();
        }

        #endregion

        private void InitializeDataObjects()
        {
            this.Input = new List<ActivityWork>();
            this.Output = null;
            this.Work = new List<ActivityWork>();
            this.Map = null;
            this.Users = new List<ActivityUser>();
        }

        #region SetActivityDataObject

        private void SetActivityDataObject(XDocument xmlDocument)
        {
            // 01. root 하위 input
            SetInputObject(xmlDocument);

            // 02. root 하위 output            
            SetOutputObject(xmlDocument);

            // 03. root 하위 work
            SetWorkObject(xmlDocument);

            // 04. root 하위 map
            SetMapObject(xmlDocument);

            // 05. root 하위 user
            SetUsersObject(xmlDocument);
        }

        private void SetInputObject(XDocument xmlDocument)
        {
            var inputWorks = xmlDocument.Descendants("input").Descendants("inputwork");

            foreach (XElement inputWork in inputWorks)
            {
                Input.Add(new ActivityWork
                {
                    Key = Int64.Parse(inputWork.Attribute("key").Value),
                    Name = inputWork.Attribute("name").Value,
                    Title = inputWork.Attribute("title").Value,
                    Table = inputWork.Attribute("table").Value
                });
            }
        }

        private void SetOutputObject(XDocument xmlDocument)
        {
            //StringBuilder innerXml = new StringBuilder();
            //var output = xmlDocument.Descendants("output");

            //foreach (XNode node in output.Nodes())
            //{
            //    // append node's xml string to innerXml
            //    innerXml.Append(node.ToString());
            //}

            //this.Output = innerXml.ToString();

            var output = xmlDocument.Element("activity").Element("output");

            if (output != null && !output.IsEmpty)
            {
                var outputReader = output.CreateReader();
                outputReader.MoveToContent();

                this.Output = outputReader.ReadInnerXml();
            }
        }

        private void SetWorkObject(XDocument xmlDocument)
        {
            var currentWorks = xmlDocument.Descendants("work").Descendants("currentwork");

            foreach (XElement currentWork in currentWorks)
            {
                Work.Add(new ActivityWork
                {
                    Key = Int64.Parse(currentWork.Attribute("key").Value),
                    Name = currentWork.Attribute("name").Value,
                    Title = currentWork.Attribute("title").Value,
                    Table = currentWork.Attribute("table").Value
                });
            }
        }

        private void SetMapObject(XDocument xmlDocument)
        {
            var map = xmlDocument.Element("activity").Element("map");

            if (map != null && !map.IsEmpty)
            {
                var mapReader = map.CreateReader();
                mapReader.MoveToContent();

                this.Map = mapReader.ReadInnerXml();
            }
        }

        private void SetUsersObject(XDocument xmlDocument)
        {
            var currentUsers = xmlDocument.Descendants("user").Descendants("currentuser");

            foreach (XElement currentUser in currentUsers)
            {
                Users.Add(new ActivityUser
                {
                    Key = currentUser.Attribute("key").Value,
                    Name = currentUser.Attribute("name").Value,
                    Title = currentUser.Attribute("title").Value,
                    Table = currentUser.Attribute("table").Value
                });
            }
        }

        private string EscapeCharForXmlText(string unEscapedText)
        {
            if (string.IsNullOrWhiteSpace(unEscapedText))
                return unEscapedText;

            return System.Security.SecurityElement.Escape(unEscapedText);
        }

        #endregion

        #region GetActivityDataXml

        private string GetActivityDataXml(SaveOptions option)
        {
            XElement rootXml = new XElement("activity");
            
            // 01. root 하위 input
            GetInputXml(rootXml);

            // 02. root 하위 output            
            GetOutputXml(rootXml);
            
            // 03. root 하위 work
            GetWorkXml(rootXml);

            // 04. root 하위 map
            GetMapXml(rootXml);
            
            // 05. root 하위 user
            GetUsersXml(rootXml);

            return rootXml.ToString(option);
        }

        private void GetInputXml(XElement rootXml)
        {
            XElement inputXml = new XElement("input");

            foreach (ActivityWork inputWork in Input)
            {
                XElement inputWorkXml = new XElement("inputwork");
                inputWorkXml.Add(new XAttribute("name", inputWork.Name), new XAttribute("key", inputWork.Key), new XAttribute("table", inputWork.Table), new XAttribute("title", inputWork.Title));
                inputXml.Add(inputWorkXml);
            }

            rootXml.Add(inputXml);
        }

        private void GetOutputXml(XElement rootXml)
        {
            rootXml.Add(new XElement("output", Output));
        }

        private void GetWorkXml(XElement rootXml)
        {
            XElement workXml = new XElement("work");

            foreach (ActivityWork currentWork in Work)
            {
                XElement currentWorkXml = new XElement("currentwork");
                currentWorkXml.Add(new XAttribute("name", currentWork.Name), new XAttribute("key", currentWork.Key), new XAttribute("table", currentWork.Table), new XAttribute("title", currentWork.Title));
                workXml.Add(currentWorkXml);
            }

            rootXml.Add(workXml);
        }

        private void GetMapXml(XElement rootXml)
        {
            rootXml.Add(new XElement("map", Map));
        }

        private void GetUsersXml(XElement rootXml)
        {
            XElement usersXml = new XElement("user");

            foreach (ActivityUser user in Users)
            {
                XElement userXml = new XElement("currentuser");
                userXml.Add(new XAttribute("name", user.Name), new XAttribute("key", user.Key), new XAttribute("table", user.Table), new XAttribute("title", user.Title));
                usersXml.Add(userXml);
            }

            rootXml.Add(usersXml);
        }


        #endregion

        #endregion
    }
}
