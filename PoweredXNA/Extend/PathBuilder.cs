namespace PoweredXNA.Extend
{
    internal static class PathBuilder
    {
        private static string AddSlash(this string folder)
        {
            if (folder != "" && folder[folder.Length - 1] != '/')
                return folder + '/';
            return folder;
        }

        internal static string Build(string folder1, string folder2, string folder3, string folder4, string folder5, string folder6, string folder7, string folder8, string last)
        {
            return folder1.AddSlash()
                 + folder2.AddSlash()
                 + folder3.AddSlash()
                 + folder4.AddSlash()
                 + folder5.AddSlash()
                 + folder6.AddSlash()
                 + folder7.AddSlash()
                 + folder8.AddSlash()
                 + last;
        }

        internal static string Build(string folder1, string folder2, string folder3, string folder4, string folder5, string folder6, string folder7, string last)
        {
            return Build(folder1, folder2, folder3, folder4, folder5, folder6, folder7, "", last);
        }

        internal static string Build(string folder1, string folder2, string folder3, string folder4, string folder5, string folder6, string last)
        {
            return Build(folder1, folder2, folder3, folder4, folder5, folder6, "", "", last);
        }

        internal static string Build(string folder1, string folder2, string folder3, string folder4, string folder5, string last)
        {
            return Build(folder1, folder2, folder3, folder4, folder5, "", "", "", last);
        }

        internal static string Build(string folder1, string folder2, string folder3, string folder4, string last)
        {
            return Build(folder1, folder2, folder3, folder4, "", "", "", "", last);
        }

        internal static string Build(string folder1, string folder2, string folder3, string last)
        {
            return Build(folder1, folder2, folder3, "", "", "", "", "", last);
        }

        internal static string Build(string folder1, string folder2, string last)
        {
            return Build(folder1, folder2, "", "", "", "", "", "", last);
        }

        internal static string Build(string folder, string last)
        {
            return Build(folder, "", "", "", "", "", "", "", last);
        }
    }
}
