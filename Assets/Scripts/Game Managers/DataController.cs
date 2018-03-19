using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;
using System.Linq;
using System.Xml.Serialization;
using System;

public class DataController
{
    private static readonly string settingsDataFileName = "settings.xml";
    private static readonly string settingsFilePath = Path.Combine(Application.persistentDataPath, settingsDataFileName);

    private static readonly string scoresDataFileName = "scores.xml";
    private static readonly string scoresFilePath = Path.Combine(Application.persistentDataPath, scoresDataFileName);

    public static string GetUser()
    {
        XmlDocument settingsXml = GetSettingsXml();
        XmlNode userNode = settingsXml.SelectSingleNode("//user");

        return userNode.InnerText;
    }

    public static void SetUser(string newUser)
    {
        XmlDocument settingsXml = GetSettingsXml();
        XmlNode userNode = settingsXml.SelectSingleNode("//user");
        userNode.InnerText = newUser;

        settingsXml.Save(settingsFilePath);
    }

    public static string GetCharacter()
    {
        XmlDocument settingsXml = GetSettingsXml();
        XmlNode characterNode = settingsXml.SelectSingleNode("//character");

        return characterNode.InnerText;
    }

    public static void SetCharacter(string newCharacter) {
        XmlDocument settingsXml = GetSettingsXml();
        XmlNode characterNode = settingsXml.SelectSingleNode("//character");
        characterNode.InnerText = newCharacter;

        settingsXml.Save(settingsFilePath);
    }

    public static string GetSkin()
    {
        XmlDocument settingsXml = GetSettingsXml();
        XmlNode skinNode = settingsXml.SelectSingleNode("//skin");

        return skinNode.InnerText;
    }

    public static void SetSkin(string newSkin)
    {
        XmlDocument settingsXml = GetSettingsXml();
        XmlNode skinNode = settingsXml.SelectSingleNode("//skin");
        skinNode.InnerText = newSkin;

        settingsXml.Save(settingsFilePath);
    }

    private static XmlDocument GetSettingsXml()
    {
        XmlDocument xmlDoc = new XmlDocument();

        if (!File.Exists(settingsFilePath))
        {
            XmlNode docNode = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
            xmlDoc.AppendChild(docNode);

            XmlNode settingsNode = xmlDoc.CreateElement("settings");
            xmlDoc.AppendChild(settingsNode);

            XmlNode characterNode = xmlDoc.CreateElement("character");
            characterNode.InnerText = "boy"; //When it's created, it's set to BOY.
            settingsNode.AppendChild(characterNode);

            XmlNode skinNode = xmlDoc.CreateElement("skin");
            skinNode.InnerText = "rocks";
            settingsNode.AppendChild(skinNode);

            XmlNode userNode = xmlDoc.CreateElement("user");
            userNode.InnerText = "user";
            settingsNode.AppendChild(userNode);

            xmlDoc.Save(settingsFilePath);
        }
        else
        {
            xmlDoc.Load(settingsFilePath);
        }

        return xmlDoc;
    }

    public static Scores ReadScores()
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Scores));
        FileStream fileStream = new FileStream(scoresFilePath, FileMode.Open);

        Scores scores = (Scores) xmlSerializer.Deserialize(fileStream);

        return scores;
    }

    public static void AddScores()
    {
        // TODO: This is a test method.
        Scores scores = new Scores();
        string[] names = new string[] { "Pepe", "Paco", "Mario" };
        foreach (string name in names)
        {
            scores.scores.Add(new Score() {
                dateTime = DateTime.Now,
                score = 200,
                user = name
            });
        }

        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Scores));
        StreamWriter streamWriter = new StreamWriter(scoresFilePath);

        xmlSerializer.Serialize(streamWriter,scores);
        streamWriter.Close();
    }
}