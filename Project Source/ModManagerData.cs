using System;

// File: ModManagerData.cs
// Created by: MRG-bit
// Last edited: 15/09/2019

namespace SpyroModManager
{
    [Serializable]
    public class ModManagerData
    {
        // Path to spyro.exe (in Steam folders)
        public string spyroPath = null;

        // Path to the console injector
        public string injectorPath = null;

        // Whether to run the injector
        public bool useInjector = false;

        // Whether to run in vanilla or not
        public bool isVanilla = false;

        // Whether to skip intro cutscenes
        public bool skipIntro = false;
    }
}
