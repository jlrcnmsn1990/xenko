﻿// Copyright (c) 2014 Silicon Studio Corp. (http://siliconstudio.co.jp)
// This file is distributed under GPL v3. See LICENSE.md for details.
using System.Threading.Tasks;

using NUnit.Framework;

using SiliconStudio.Xenko.UI.Controls;

namespace SiliconStudio.Xenko.UI.Tests.Regression
{
    /// <summary>
    /// Class for rendering tests on the <see cref="Button"/> 
    /// </summary>
    public class ButtonTest : UITestGameBase
    {
        private Button button;

        public ButtonTest()
        {
            CurrentVersion = 5;
        }

        protected override async Task LoadContent()
        {
            await base.LoadContent();

            button = new Button();
            ApplyButtonDefaultStyle(button);

            UIComponent.RootElement = button;
        }

        protected override void RegisterTests()
        {
            base.RegisterTests();

            FrameGameSystem.DrawOrder = -1;
            FrameGameSystem.TakeScreenshot();
            FrameGameSystem.Draw(DrawTest1).TakeScreenshot();
        }

        public void DrawTest1()
        {
            button.RaiseTouchDownEvent(new TouchEventArgs());
        }

        [Test]
        public void RunButtonTest()
        {
            RunGameTest(new ButtonTest());
        }

        /// <summary>
        /// Launch the Image test.
        /// </summary>
        public static void Main()
        {
            using (var game = new ButtonTest())
                game.Run();
        }
    }
}
