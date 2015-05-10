using Microsoft.Xna.Framework;
using PoweredXNA.Entities;
using PoweredXNA.GameStates;
using System.Collections.Generic;

namespace PoweredXNA
{
    public abstract class GameState
    {
        private static Stack<GameState> States = new Stack<GameState>();

        public static int CountInstances()
        {
            return States.Count;
        }

        public static void PushInstance(GameState instance)
        {
            States.Push(instance);
        }

        internal static void AddEntityOnTop(Entity entity)
        {
            States.Peek().AddEntity(entity);
        }

        internal static void DrawAll(GameTime gameTime)
        {
            if (States.Count == 0)
                return;

            Stack<GameState> buffer = new Stack<GameState>();

            while (States.Count != 1 && !States.Peek().IsFullScreen)
                buffer.Push(States.Pop());
            buffer.Push(States.Pop());
            while (buffer.Count != 0)
            {
                GameState gameState = buffer.Peek();
                gameState.DrawInternal(gameTime);
                gameState.Draw(gameTime);
                States.Push(buffer.Pop());
            }
        }

        internal static void UpdateLast(GameTime gameTime)
        {
            if (States.Count == 0)
                return;
            GameState current = States.Peek();
            while (States.Count > 0 && current.State == State.Exit)
                States.Pop();
            if (States.Count == 0)
                return;
            if (current.State == State.Reload)
            {
                current.Initialize(gameTime);
                current.State = State.Run;
            }

            current.UpdateInternal(gameTime);
            current.Update(gameTime);
        }

        protected State State = State.Reload;
        protected bool IsFullScreen = true;

        private List<Entity> _entities = new List<Entity>();

        internal void AddEntity(Entity entity)
        {
            _entities.Add(entity);
        }

        internal void UpdateInternal(GameTime gameTime)
        {
            _entities.SortByZIndex();
            foreach (Entity entity in _entities)
                entity.Update(gameTime);
        }

        internal void DrawInternal(GameTime gameTime)
        {
            _entities.SortByZIndex();
            foreach (Entity entity in _entities)
                entity.Draw(gameTime);
        }

        public virtual void Initialize(GameTime gameTime) { }
        public virtual void Draw(GameTime gameTime) { }
        public virtual void Update(GameTime gameTime) { }
    }
}
