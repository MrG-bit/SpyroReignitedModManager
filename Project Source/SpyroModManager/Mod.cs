///     Spyro Reignited Mod Manager
///     File: Mod.cs
///     Last updated: 2020/03/04
///     Created by: MR.G-bit

using System;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace SpyroModManager
{
    public class Mod
    {
        [Serializable]
        private class ModDetails
        {
            public bool m_enabled = false;
            public string m_name = "";
            public string m_author = "";
            public string m_description = "";
            public uint m_order = 0;
            public Bitmap m_image = null;
            public bool converted = false;
        }

        private class BindOverride : SerializationBinder
        {
            private static BindOverride instance;
            public static BindOverride Instance
            {
                get { if (instance == null) { instance = new BindOverride(); } return instance; }
            }

            private BindOverride() { }

            public override Type BindToType(string assemblyName, string typeName)
            {
                return assemblyName.Equals("NA") ? Type.GetType(typeName) : null;
            }

            public override void BindToName(Type serializedType, out string assemblyName, out string typeName)
            {
                assemblyName = "NA";
                typeName = serializedType.FullName;
            }
        }

        public static string EnabledPakDirectory { get; set; }
        public static string DisabledPakDirectory { get; set; }
        public static string ModDirectory { get; set; }
        public string PakDirectory { get { return Enabled ? EnabledPakDirectory : DisabledPakDirectory; } }
        public string PakFileName { get { return GetPakFileName(Name, Order); } }
        public string ModFileName { get { return GetModFileName(Name); } }

        private ModDetails m_modDetails;
        public bool Enabled { get { return m_modDetails.m_enabled; } private set { m_modDetails.m_enabled = value; } }
        public string Name { get { return m_modDetails.m_name; } set { m_modDetails.m_name = value; } }
        public string Author { get { return m_modDetails.m_author; } set { m_modDetails.m_author = value; } }
        public string Description { get { return m_modDetails.m_description; } set { m_modDetails.m_description = value; } }
        public Bitmap Image { get { return m_modDetails.m_image; } set { m_modDetails.m_image = value; } }
        public uint Order { get { return m_modDetails.m_order; } set { m_modDetails.m_order = value; } }
        public bool IsConnectedToPak { get; private set; }

        public Mod()
        {
            m_modDetails = new ModDetails();
        }

        // Save mod details using binary formatter
        public void SaveModDetails()
        {
            try
            {
                FileStream fs = new FileStream(Path.Combine(ModDirectory, ModFileName), FileMode.OpenOrCreate, FileAccess.Write);
                BinaryFormatter bf = new BinaryFormatter();
                //bf.Binder = BindOverride.Instance;
                bf.Serialize(fs, m_modDetails);
                fs.Close();
            }
            catch (Exception) { }
        }

        // Load mod details using binary formatter
        public static Mod LoadModDetails(string filePath)
        {
            Mod mod = new Mod();
            try
            {
                FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                BinaryFormatter bf = new BinaryFormatter();
                //bf.Binder = BindOverride.Instance;
                mod.m_modDetails = (ModDetails)bf.Deserialize(fs);
                fs.Close();

                /*
                if (mod.m_modDetails != null && !mod.m_modDetails.converted)
                {
                    mod.m_modDetails.converted = true;
                    mod.SaveModDetails();
                }
                */
            }
            catch (Exception) { }

            return mod;
        }

        // Copy .pak to ~mods or ~disabled folder
        public void ConnectPak(string pakPath)
        {
            File.Copy(pakPath, Path.Combine(PakDirectory, PakFileName));
            IsConnectedToPak = true;
        }

        // Check if a pak exists for this mod
        public void VerifyPak()
        {
            IsConnectedToPak = true;
            if (File.Exists(Path.Combine(EnabledPakDirectory, PakFileName))) Enabled = true;
            else if (File.Exists(Path.Combine(DisabledPakDirectory, PakFileName))) Enabled = false;
            else IsConnectedToPak = false;
        }

        // Move from ~disabled to ~mods
        public void EnableMod()
        {
            if (Enabled) return;
            File.Move(Path.Combine(DisabledPakDirectory, PakFileName), Path.Combine(EnabledPakDirectory, PakFileName));
            Enabled = true;
        }

        // Move from ~mods to ~disabled
        public void DisableMod()
        {
            if (!Enabled) return;
            File.Move(Path.Combine(EnabledPakDirectory, PakFileName), Path.Combine(DisabledPakDirectory, PakFileName));
            Enabled = false;
        }

        // Change filenames to reflect name change .srtmod, .pak and .pak
        public void ChangeName(string name)
        {
            if (name == Name) return;
            File.Move(Path.Combine(ModDirectory, ModFileName), Path.Combine(ModDirectory, GetModFileName(name)));
            File.Move(Path.Combine(PakDirectory, PakFileName), Path.Combine(PakDirectory, GetPakFileName(name, Order)));
            Name = name;
            SaveModDetails();
        }

        // Change order and update pak name
        public void ChangeOrder(uint order)
        {
            if (order == Order) return;
            File.Move(Path.Combine(PakDirectory, PakFileName), Path.Combine(PakDirectory, GetPakFileName(Name, order)));
            Order = order;
            SaveModDetails();
        }

        // Get pak file name
        private string GetPakFileName(string name, uint order) { return "X" + order + "-" + name + ".pak"; }

        // Get mod file name
        private string GetModFileName(string name) { return name + ".mod"; }

        // Mod as string representation
        public override string ToString()
        {
            return Order + "\t" + Name;
        }
    }
}
