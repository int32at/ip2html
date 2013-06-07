using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace int32.Util
{
    public class InfoPath2Html
    {
        public string Generate(XmlDocument InfoPathData, XmlDocument XsltStyleSheet)
        {
            var xsltProcessor = new XslCompiledTransform();

            using(var writer = new StringWriter())
            using (var xmlWriter = new XmlTextWriter(writer))
            {
                XPathNavigator ipForm = InfoPathData.CreateNavigator();
                xsltProcessor.Load(XsltStyleSheet);
                xsltProcessor.Transform(InfoPathData, xmlWriter);

                return writer.ToString();
            }
        }
    }
}
