﻿#region Usings
//System
using System;
//XNA
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
#endregion //Usings


namespace com.amazingcow.BowAndArrow
{
    public abstract class Enemy : GameObject
    {
        #region CTOR
        public Enemy(Vector2 position, Vector2 speed,
                     float msToChangeTexture) :
            base(position, speed, msToChangeTexture)
        {
            //Empty...
        }
        #endregion //CTOR


        #region Public Methods
        public virtual bool CheckCollisionPlayer(Archer archer)
        {
            //Assumes that this Enemy cannot collide with player.
            return false;
        }

        public virtual bool CheckCollisionArrow(Arrow arrow)
        {
            //Arrow doesn't hit anything but alive ones.
            if(CurrentState != State.Alive)
                return false;

            return this.HitBox.Contains(arrow.HeadPoint);
        }
        #endregion //Public Methods

    }//class Enemy
}//namespace com.amazingcow.BowAndArrow

