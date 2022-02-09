namespace Engine
{
    public static class Values
    {
        public const string MainMenuEnds = "to download...";
        public const string dayInputsFilePath = "dayInputsData.txt";
        public const string typeInputsFilePath = "typeInputsData.txt";
        public const string hourInputsFilePath = "hourInputsData.txt";
        public const string archiveFilePath = "archivePath.txt";
        public const string appTitle = "WEATHER ARCHIVES";
        public const string pageAdress = "http://flymet.meteopress.cz/";
        public static string folderPath;
        public static string RemoveLastCharIfItIs(this string value, char character)
        {
            char lastCharacter = value[value.Length - 1];
            if (lastCharacter == character)
            {
                return value.Remove(value.Length - 1);
            }
            return value;
        }
        public static string RemoveLastCharIfItIs(this string value, char character1, char character2)
        {
            char lastCharacter = value[value.Length - 1];
            if (lastCharacter == character1 || lastCharacter == character2)
            {
                return value.Remove(value.Length - 1);
            }
            return value;
        }
    }
}
