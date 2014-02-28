﻿using System;
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
        public static GraphicsDevice gd;

        Texture2D cursor_custom;
        Vector2 spritePosition = Vector2.Zero;

        SoundEffect click;
        Song musicMenu;

        MouseState mouseStatePrevious, mouseStateCurrent;
        Menu menu;


        bool checkExitKey(KeyboardState keyboardState, GamePadState gamePadState)
        {
            if (keyboardState.IsKeyDown(Keys.Escape) || gamePadState.Buttons.Back == ButtonState.Pressed)
            {
                Exit();
                return true;
            }
            return false;
        }

        void Game1_Exiting(object sender, EventArgs e)
        {
            // Add any code that must execute before the game ends. => Rien
        }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // Gestion de la fenetre
            graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            graphics.IsFullScreen = true;

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
            cursor_custom = Content.Load<Texture2D>("Ressources//cursortransp");

            gd = this.GraphicsDevice;
            menu = new Menu(Content.Load<Texture2D>("MenuJouer"), Content.Load<Texture2D>("MenuOptions"), Content.Load<Texture2D>("MenuQuitter"));
            click = Content.Load<SoundEffect>("click1");
            musicMenu = Content.Load<Song>("Russian Red Army Choir");
            MediaPlayer.Play(musicMenu);
        }


        protected override void UnloadContent()
        {
            base.UnloadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            if (menu.IsExit)  //quitte le jeu � partir du menu    //sinon appuyer sur �chap
            {
                base.Exit();
            }

            GamePadState gamePadState = GamePad.GetState(PlayerIndex.One);
            KeyboardState keyboardState = Keyboard.GetState();
            if (checkExitKey(keyboardState, gamePadState))
            {
                base.Update(gameTime);
                return;
            }

            spritePosition.X = Mouse.GetState().X;
            spritePosition.Y = Mouse.GetState().Y;

            menu.Update(gameTime);
            mouseStateCurrent = Mouse.GetState();

            if (mouseStateCurrent.LeftButton == ButtonState.Pressed)  //son � chaque clic gauche
            {
               click.Play();
            }
            mouseStatePrevious = mouseStateCurrent;

            if (menu.InGame && !menu.MenuPrincipal)
            {
                MediaPlayer.Stop();
            }


            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.Draw(cursor_custom, new Rectangle((int)spritePosition.X, (int)spritePosition.Y, 24, 24), Color.White);
            spriteBatch.End();

            if (!menu.InGame && menu.MenuPrincipal)
            {
                menu.Draw(spriteBatch);
            }
            if (menu.InGame == true && menu.MenuPrincipal == false)
            {
                //lancement du jeu
            }

            base.Draw(gameTime);
        }
    }
}
