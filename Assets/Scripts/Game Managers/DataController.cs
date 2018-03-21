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

    private static string user = null;
    private static string skin = null;
    private static string character = null;
    private static Scores scoresCache = null;

    public static string GetUser()
    {
        if (user != null) return user;

        XmlDocument settingsXml = GetSettingsXml();
        XmlNode userNode = settingsXml.SelectSingleNode("//user");

        user = userNode.InnerText;
        return userNode.InnerText;
    }

    public static void SetUser(string newUser)
    {
        XmlDocument settingsXml = GetSettingsXml();
        XmlNode userNode = settingsXml.SelectSingleNode("//user");
        userNode.InnerText = newUser;

        settingsXml.Save(settingsFilePath);

        user = newUser;
    }

    public static string GetCharacter()
    {
        if (character != null) return character;

        XmlDocument settingsXml = GetSettingsXml();
        XmlNode characterNode = settingsXml.SelectSingleNode("//character");

        character = characterNode.InnerText;
        return characterNode.InnerText;
    }

    public static void SetCharacter(string newCharacter) {
        XmlDocument settingsXml = GetSettingsXml();
        XmlNode characterNode = settingsXml.SelectSingleNode("//character");
        characterNode.InnerText = newCharacter;

        settingsXml.Save(settingsFilePath);

        character = newCharacter;
    }

    public static string GetSkin()
    {
        if (skin != null) return skin;

        XmlDocument settingsXml = GetSettingsXml();
        XmlNode skinNode = settingsXml.SelectSingleNode("//skin");

        skin = skinNode.InnerText;
        return skinNode.InnerText;
    }

    public static void SetSkin(string newSkin)
    {
        XmlDocument settingsXml = GetSettingsXml();
        XmlNode skinNode = settingsXml.SelectSingleNode("//skin");
        skinNode.InnerText = newSkin;

        settingsXml.Save(settingsFilePath);

        skin = newSkin;
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

    public static Scores GetScores()
    {
        if (scoresCache != null) return scoresCache;

        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Scores));

        if (!File.Exists(scoresFilePath)) {
            Scores emptyScores = new Scores();
            StreamWriter streamWriter = new StreamWriter(scoresFilePath);
            xmlSerializer.Serialize(streamWriter, emptyScores);
            streamWriter.Close();
        }

        FileStream fileStream = new FileStream(scoresFilePath, FileMode.Open);

        Scores scores = (Scores) xmlSerializer.Deserialize(fileStream);
        fileStream.Close();

        scoresCache = scores;
        return scores;
    }

    public static void AddScore(int points)
    {
        Scores scores = GetScores();
        string user = DataController.GetUser();

        scores.scores.Add(new Score() {
            user = user,
            dateTime = DateTime.Now,
            score = points
        });

        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Scores));
        StreamWriter streamWriter = new StreamWriter(scoresFilePath);

        xmlSerializer.Serialize(streamWriter,scores);
        streamWriter.Close();

        scoresCache = scores;
    }
}