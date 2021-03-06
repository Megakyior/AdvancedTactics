using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace Advanced_Tactics
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D cursor_custom;
        Vector2 spritePosition = Vector2.Zero;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // Gestion de la fenetre
            //Fenetre

            Fenetre fenetre = new Fenetre();
            fenetre.Fullscreen(true);
            

            this.Window.Title = "Advanced Tactics";
            this.graphics.ApplyChanges();

            
        }

        protected override void Initialize()
        {
            base.Initialize();            
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            cursor_custom = Content.Load<Texture2D>("Ressources//cursor");
        }

        protected override void UnloadContent()
        {
            base.UnloadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            
            GamePadState gamePadState = GamePad.GetState(PlayerIndex.One);
            KeyboardState keyboardState = Keyboard.GetState();
            

            //spritePosition.X = Mouse.GetState().X;
            //spritePosition.Y = Mouse.GetState().Y;
            

            Fenetre exit = new Fenetre();
            exit.checkExitKey(keyboardState, gamePadState);

            Fenetre mouse_pos = new Fenetre();
            spritePosition = mouse_pos.Mouse_pos(spritePosition);
            

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            spriteBatch.Begin();
            spriteBatch.Draw(cursor_custom, new Rectangle((int)spritePosition.X, (int)spritePosition.Y, 24, 24), Color.White);
            spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}
