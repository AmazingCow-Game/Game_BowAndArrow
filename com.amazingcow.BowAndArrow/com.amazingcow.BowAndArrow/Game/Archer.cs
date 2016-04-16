﻿#region Usings
//System
using System;
using System.Diagnostics;
//Xna
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
#endregion //Usings


namespace com.amazingcow.BowAndArrow
{
    public class Archer : GameObject
    {
        #region Events
        public event EventHandler<EventArgs> OnArcherShootArrow;
        #endregion //Events


        #region Enums / Constants
        public enum BowState
        {
            Stand,  //Bow has an arrow but is not pulled.
            Armed,  //Bow has an arrow AND is pulled.
            Unarmed //Bow hasn't an arrow.
        }

        public const int kMaxArrowsCount = 2;

        private const int kChangeStateInterval = 200;
        #endregion //Enums


        #region Public Properties
        public int ArrowsCount
        { get; private set; }

        public BowState CurrentBowState
        { get; private set; }

        public Vector2 ArrowPosition
        {
            get {
                return new Vector2(this.Position.X + 47, //COWTODO: Remove magic number
                                   this.Position.Y + 41); //COWTODO: Remove magic number
            }
        }
        #endregion //Public Properties


        #region iVars
        private Clock _changeStateClock;
        #endregion //iVars


        #region CTOR
        public Archer(Vector2 position) :
            base(position, Vector2.Zero, 0)
        {
            //Init the textures.
            var resMgr = ResourcesManager.Instance;

            AliveTexturesList.Add(resMgr.GetTexture("hero_stand"));
            AliveTexturesList.Add(resMgr.GetTexture("hero_armed"));
            AliveTexturesList.Add(resMgr.GetTexture("hero_without_arrow"));

            DyingTexturesList = AliveTexturesList;

            //Init the Properties.
            CurrentBowState = BowState.Stand;
            ArrowsCount     = kMaxArrowsCount;

            //Init the timers.
            _changeStateClock = new Clock(kChangeStateInterval, 1);
            _changeStateClock.OnTick += OnChangeStateClockTick;
        }
        #endregion //CTOR


        #region Update / Draw
        public override void Update(GameTime gt)
        {
            //Arrow is already dead - Don't need to do anything else.
            if(CurrentState == State.Dead)
                return;

            //Update the timers.
            _changeStateClock.Update(gt.ElapsedGameTime.Milliseconds);


            var mouseState = Mouse.GetState();

            //Change the Bow State.
            if(mouseState.RightButton == ButtonState.Pressed)
                TryChangeBowState(BowState.Stand);
            else if(mouseState.LeftButton == ButtonState.Released)
                TryChangeBowState(BowState.Unarmed);
            else if(mouseState.LeftButton == ButtonState.Pressed)
                TryChangeBowState(BowState.Armed);

            //Try move...
            CalculateMovementSpeed();

            //Update the position.
            Position += (Speed * (gt.ElapsedGameTime.Milliseconds / 1000f));
            Position = new Vector2((int)Position.X, (int)Position.Y);
        }
        #endregion //Update / Draw


        #region Public Methods
        public override void Kill()
        {
            //Already Dead - Don't do anything else...
            if(CurrentState != State.Alive)
                return;
        }
        #endregion //Public Methods


        #region Helper Methods
        private void TryChangeBowState(BowState targetBowState)
        {
            if(_changeStateClock.IsEnabled)
                return;

            if(CurrentState == State.Dying)
                return;

            // Armed -> Unarmed
            if((CurrentBowState == BowState.Armed &&
                targetBowState  == BowState.Unarmed))
            {
                Shoot();
            }

            // Stand -> Armed
            else if(CurrentBowState == BowState.Stand &&
                    targetBowState  == BowState.Armed)
            {
                Arm();
            }

            // Unarmed -> Stand
            else if(CurrentBowState == BowState.Unarmed &&
                    targetBowState  == BowState.Stand)
            {
                Stand();
            }
        }


        private void Shoot()
        {
            if(ArrowsCount > 0)
            {
                --ArrowsCount;
                OnArcherShootArrow(this, EventArgs.Empty);

                if(ArrowsCount <= 0)
                {
                    CurrentState = State.Dying;
                }
            }


            CurrentBowState     = BowState.Unarmed;
            CurrentTextureIndex = (int)CurrentBowState;

            _changeStateClock.Start();
        }
        private void Arm()
        {
            CurrentBowState     = BowState.Armed;
            CurrentTextureIndex = (int)CurrentBowState;

            _changeStateClock.Start();
        }
        private void Stand()
        {
            CurrentBowState     = BowState.Stand;
            CurrentTextureIndex = (int)CurrentBowState;

            _changeStateClock.Start();
        }


        private void CalculateMovementSpeed()
        {
            var mouseState = Mouse.GetState();
            var keyboardState = Keyboard.GetState();

            Speed = Vector2.Zero;
            if(keyboardState.IsKeyDown(Keys.Down))
                Speed = new Vector2(0,  200);
            if(keyboardState.IsKeyDown(Keys.Up))
                Speed = new Vector2(0, -200);
            /*
            if(mouseState.LeftButton != ButtonState.Pressed)
                return;

            var targetY      = mouseState.Y;
            var windowHeight = GameManager.Instance.GraphicsDevice.Viewport.Height;

            if(targetY >= 0 && targetY <= windowHeight)
            {
                var bb = this.BoundingBox;
                if(bb.Y >= 0 && bb.Bottom <= windowHeight)
                        Speed = new Vector2(0, 200 * ((targetY < bb.Y) ? -1 : 1));
            }
            */
        }
        #endregion //Helper Methods


        #region Timers Callbacks
        private void OnChangeStateClockTick(object sender, EventArgs e)
        {
            _changeStateClock.Stop();
        }
        #endregion //Timers Callbacks
    }
}

