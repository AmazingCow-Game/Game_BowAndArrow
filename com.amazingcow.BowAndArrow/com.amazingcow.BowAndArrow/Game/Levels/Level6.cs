﻿#region Usings
//System
using System;
//XNA
using Microsoft.Xna.Framework;
#endregion //Usings


namespace com.amazingcow.BowAndArrow
{
    public class Level6 : Level
    {
        #region Constants
        //COWTODO: Check the correct values.
        const int kMaxFireballsCount = 15;
        #endregion //Constants


        #region Public Properties 
        public override String PaperStringIntro 
        { get { return kPaperIntroString; } }

        public override String PaperStringGameOver
        { get { return kPaperGameOverString; } }

        public override String LevelTitle        
        { get { return kLevelTitle; } }
        #endregion //Public Properties 


        #region Init
        protected override void InitEnemies()
        {
            var viewport = GameManager.Instance.GraphicsDevice.Viewport;
            var rndGen   = GameManager.Instance.RandomNumGen;

            //Initialize the Enemies.
            int minFireballY = Fireball.kFireballHeight;
            int maxFireballY = viewport.Height - Fireball.kFireballHeight;
            //Makes the enemies came from right of screen.
            int minFireballX = viewport.Width;
            int maxFireballX = 2 * viewport.Width;

            for(int i = 0; i < kMaxFireballsCount; ++i)
            {
                var x = rndGen.Next(minFireballX, maxFireballX);
                var y = rndGen.Next(minFireballY, maxFireballY);

                var fireball = new Fireball(new Vector2(x, y));
                fireball.OnStateChangeDead  += OnEnemyStateChangeDead;
                fireball.OnStateChangeDying += OnEnemyStateChangeDying;

                Enemies.Add(fireball);
            }

            AliveEnemies = kMaxFireballsCount;
        }
        #endregion //Init


        #region Helper Methods
        protected override void LevelCompleted()
        {
            GameManager.Instance.ChangeLevel(new Level5());
        }
        #endregion


        #region Paper Strings
        //Intro 
        const String kPaperIntroString = @"
The slimes are comming!
Don't let their pass!";

        //Game Over
        const String kPaperGameOverString = @"
Game over.
";
        //Title
        const String kLevelTitle = @"Level 6";
        #endregion

    }//class Level6
}//namespace com.amazingcow.BowAndArrow
