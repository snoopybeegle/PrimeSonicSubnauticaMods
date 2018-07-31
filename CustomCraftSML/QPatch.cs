﻿namespace CustomCraft2SML
{
    using System;

    public static class QPatch
    {
        public static void Patch()
        {
            Logger.Log("Loading files begin");

            try
            {
                FileReaderWriter.HandleReadMeFile();

                FileReaderWriter.GenerateOriginalRecipes();

                FileReaderWriter.PatchCustomSizes();

                FileReaderWriter.PatchModifiedRecipes();

                FileReaderWriter.PatchAddedRecipes();

            }
            catch (IndexOutOfRangeException outEx)
            {
                Logger.Log(outEx.ToString());
            }

            Logger.Log("Loading files complete");
        }
    }
}