using Microsoft.Xna.Framework;
using PoweredXNA.Extend;
namespace PoweredXNA.Entities
{
    public static class Cursor
    {
        private static Entity _cursor;
        private static bool _defaultCursorEnabled;

        public static void Initialize()
        {
            _cursor = new Entity();
            _defaultCursorEnabled = true;
        }

        public static void SetCursor(string keyNormal, string keyPushed, Pos delta = null) { SetCursor("", keyNormal, keyPushed, delta); }
        public static void SetCursor(string folder, string keyNormal, string keyPushed, Pos delta = null)
        {
            _cursor.LoadContent(PathBuilder.Build(folder, keyNormal), "", PathBuilder.Build(folder, keyPushed));
            _cursor.Delta = delta != null ? delta : new Pos();
            _defaultCursorEnabled = false;
        }

        public static void SetVisibility(bool visible)
        {
            _cursor.Visible = visible;
            _defaultCursorEnabled = false;
        }

        public static void ShowDefaultCursor()
        {
            _defaultCursorEnabled = true;
        }

        public static void SetScale(float scale)
        {
            _cursor.Scale = scale;
        }

        public static bool Update()
        {
            if (!_defaultCursorEnabled)
                _cursor.Pos = Events.GetMousePos();
            return _defaultCursorEnabled;
        }

        public static void Draw(GameTime gameTime)
        {
            _cursor.Draw(gameTime);
        }
    }
}
