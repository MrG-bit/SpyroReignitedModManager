using System;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Drawing;

// File: SpyroMod.cs
// Created by: MRG-bit
// Last edited: 14/09/2019

namespace SpyroModManager
{
    [Serializable]
    public class SpyroMod
    {
        public string fileName;                 // File name of the mod
        public bool locked;                     // Check if the mod is locked for editing
        public string name;                     // Name of the mod
        public string creator = "";             // Creator of the mod
        public string description = "";         // Description of the mod
        public Bitmap thumbnail;                // Thumbnail of the mod
        public bool enabled;                    // Whether the mod is enabled
        public int order;                       // The priority of the mod
        public string pakName;                  // Name of the pak (does not include path or extension)

        // Pak file name
        public string PakFileName { get { return "pakchunk" + (3 + order) + "-" + name + ".pak"; } }

        // .pak content
        public byte[] PakContent { get; private set; }
        
        // File extension of mod files
        public static readonly string fileExtension = ".srtmod";

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name">Name of the mod.</param>
        public SpyroMod(string fileName, bool locked, string name, string creator, string description)
        {
            this.fileName = fileName;
            this.locked = locked;
            this.name = name;
            this.creator = creator;
            this.description = description;
            thumbnail = null;
            enabled = false;
            order = 0;
            pakName = name;
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="copy">Copy information from.</param>
        public SpyroMod(SpyroMod copy)
        {
            fileName = string.Copy(copy.fileName);
            locked = copy.locked;
            name = string.Copy(copy.name);
            creator = string.Copy(copy.creator);
            description = string.Copy(copy.description);
            thumbnail = copy.thumbnail == null ? null : (Bitmap)copy.thumbnail.Clone();
            enabled = copy.enabled;
            order = copy.order;
            pakName = name;

            // Create the pak content array
            PakContent = new byte[copy.PakContent.Length];

            // Iterate over the pak content
            for (int i = 0; i < PakContent.Length; ++i)
            {
                // Copy the bytes
                PakContent[i] = copy.PakContent[i];
            }
        }

        /// <summary>
        /// Import a .pak file.
        /// </summary>
        /// <param name="pakPath">Path to the .pak file.</param>
        public void ImportPak(string pakPath)
        {
            // Check that the file exists and is a .pak file
            if (File.Exists(pakPath) && pakPath.ToLower().EndsWith(".pak"))
            {
                // Load all the bytes from the file
                PakContent = File.ReadAllBytes(pakPath);
            }
        }

        /// <summary>
        /// Export a .pak file.
        /// </summary>
        /// <param name="pakPath">Path to export to.</param>
        public void ExportPak(string pakPath)
        {
            // Check the path leads to a .pak file
            if (pakPath.ToLower().EndsWith(".pak"))
            {
                // Write the .pak bytes to the file
                File.WriteAllBytes(pakPath, PakContent);
            }
        }

        /// <summary>
        /// Save the mod to a given file path.
        /// Updates the filename variable on the mod.
        /// </summary>
        /// <param name="filePath">Path to save the mod to. I.e. "Documents//modname.srtmod"</param>
        /// <returns>Succeeded.</returns>
        public bool SaveToFile(string filePath)
        {           
            // Create binary formatter
            IFormatter formatter = new BinaryFormatter();

            // Create stream
            Stream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write);

            // Serialise the mod
            formatter.Serialize(stream, this);

            // Close the stream
            stream.Close();

            // Update the mod file name
            fileName = filePath.Split('\\').Last();

            return true;
        }

        /// <summary>
        /// Load a mod from a given file path.
        /// Updates the mod's file name variable.
        /// </summary>
        /// <param name="filePath">Path to load the mod from.</param>
        /// <returns>Mod from file path.</returns>
        public static SpyroMod LoadFromFile(string filePath)
        {
            // Create binary formatter
            IFormatter formatter = new BinaryFormatter();

            // Create stream
            Stream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

            // Deserialise
            SpyroMod mod = (SpyroMod)formatter.Deserialize(stream);

            // Close the stream
            stream.Close();

            // Update mod file name
            mod.fileName = filePath.Split('\\').Last();

            // Validate the pak name
            if (string.IsNullOrWhiteSpace(mod.pakName))
                mod.pakName = mod.name;

            // Return the mod
            return mod;
        }

        /// <summary>
        /// Set the thumbnail to an image file.
        /// </summary>
        /// <param name="imagePath">Path to image file.</param>
        public void SetThumbnail(string imagePath)
        {
            // Check that the image path is valid and exists
            if (!string.IsNullOrWhiteSpace(imagePath) && File.Exists(imagePath))
            {
                // Set the thumbnail
                thumbnail = new Bitmap(imagePath);
            }
        }

        /// <summary>
        /// Override the ToString method.
        /// </summary>
        /// <returns>String representation of the mod.</returns>
        public override string ToString()
        {
            return
                order + ": " +
                (enabled ? "[Enabled]" : "[Disabled]") +
                " " + name;
        }
    }
}
