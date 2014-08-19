using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using PoweredXNA.Extend;
using System.IO;

namespace PoweredXNA.Backend
{
    public static class Resources
    {
        private static ContentManager _content;

        public static void Load(ContentManager content)
        {
            _content = content;
            LoadDirectory<Texture2D>(PathBuilder.Build(content.RootDirectory, Options.ImagesFolder, ""));
            LoadDirectory<Song>(PathBuilder.Build(content.RootDirectory, Options.MusicsFolder, ""));
            LoadDirectory<SpriteFont>(PathBuilder.Build(content.RootDirectory, Options.SpriteFontsFolder, ""));
        }

        private static void LoadDirectory<T>(string path)
        {
            string[] folders;
            try { folders = Directory.GetDirectories(path, "*", SearchOption.AllDirectories); }
            catch { return; }
            LoadFilesInDirectory<T>(path);
            foreach (string folder in folders)
                LoadFilesInDirectory<T>(PathBuilder.Build(folder, ""));
        }

        private static void LoadFilesInDirectory<T>(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            if (!dir.Exists)
                throw new DirectoryNotFoundException();

            FileInfo[] files = dir.GetFiles("*.*");
            foreach (FileInfo file in files)
            {
                string filePath = path.Remove(0, _content.RootDirectory.Length + 1) + Path.GetFileNameWithoutExtension(file.Name);
                _content.Load<T>(filePath);
            }
        }

        public static Texture2D Image(string path)
        {
            return _content.Load<Texture2D>(PathBuilder.Build(Options.ImagesFolder, path));
        }

        public static SpriteFont SpriteFont(string path)
        {
            return _content.Load<SpriteFont>(PathBuilder.Build(Options.SpriteFontsFolder, path));
        }

        public static Song Song(string path)
        {
            return _content.Load<Song>(PathBuilder.Build(Options.MusicsFolder, path));
        }
    }
}
