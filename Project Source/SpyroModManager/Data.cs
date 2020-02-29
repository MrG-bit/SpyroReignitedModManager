///     Spyro Reignited Mod Manager
///     File: Data.cs
///     Last updated: 2020/02/28
///     Created by: MR.G-bit

using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SpyroModManager
{
    [Serializable]
    public class Data
    {
        public string m_spyroExePath = "";
        public string m_spyroDir = "";
        public bool m_darkTheme = false;
        public bool m_useConsoleInjector = false;
        public string m_consoleInjectorPath = "";
        public bool m_vanilla = false;
        public bool m_skipIntroCutscenes = false;
        public bool m_backupSave = false;
        public string m_savePath = "";
        public bool m_autoClose = false;
        public bool m_useDiscordRP = false;
        public int m_spyroVersion = 0;
        public int m_preferredInput = 1;
        public bool m_openedOnce = false;

        public Data() { }

        public Data(Data copy)
        {
            m_spyroExePath = copy.m_spyroExePath;
            m_spyroDir = copy.m_spyroDir;
            m_darkTheme = copy.m_darkTheme;
            m_useConsoleInjector = copy.m_useConsoleInjector;
            m_consoleInjectorPath = copy.m_consoleInjectorPath;
            m_vanilla = copy.m_vanilla;
            m_skipIntroCutscenes = copy.m_skipIntroCutscenes;
            m_backupSave = copy.m_backupSave;
            m_savePath = copy.m_savePath;
            m_autoClose = copy.m_autoClose;
            m_useDiscordRP = copy.m_useDiscordRP;
            m_spyroVersion = copy.m_spyroVersion;
            m_preferredInput = copy.m_preferredInput;
            m_openedOnce = copy.m_openedOnce;
        }

        // Save the data to file
        public void Save(string filePath)
        {
            FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, this);
            fs.Close();
        }

        // Load the data from file
        public static Data Load(string filePath)
        {
            Data data = new Data();
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            BinaryFormatter bf = new BinaryFormatter();
            data = (Data)bf.Deserialize(fs);
            fs.Close();
            return data;
        }
    }
}
