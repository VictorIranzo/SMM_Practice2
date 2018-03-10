using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;
using System.Linq;

public class DataController
{
    private static readonly string settingsDataFileName = "settings.xml";
    private static readonly string settingsFilePath = Path.Combine(Application.streamingAssetsPath, settingsDataFileName);

    public static string GetCharacter()
    {
        XmlDocument settingsXml = GetSettingsXml();
        XmlNode characterNode = settingsXml.SelectSingleNode("/character");

        return characterNode.InnerText;
    }

    public static void SetCharacter(string newCharacter) {
        XmlDocument settingsXml = GetSettingsXml();
        XmlNode characterNode = settingsXml.SelectSingleNode("/character");
        characterNode.InnerText = newCharacter;

        settingsXml.Save(settingsFilePath);
    }

    private static XmlDocument GetSettingsXml()
    {
        XmlDocument xmlDoc = new XmlDocument();

        if (!File.Exists(settingsFilePath))
        {
            XmlNode docNode = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
            xmlDoc.AppendChild(docNode);

            XmlNode characterNode = xmlDoc.CreateElement("character");
            characterNode.InnerText = "boy"; //When it's created, it's set to BOY.
            xmlDoc.AppendChild(characterNode);

            xmlDoc.Save(settingsFilePath);
        }
        else
        {
            xmlDoc.Load(settingsFilePath);
        }

        return xmlDoc;
    }
}
