﻿/* ------------------------------------------------------------------------- */
//
// Copyright (c) 2010 CubeSoft, Inc.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//  http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
/* ------------------------------------------------------------------------- */
using System.Windows;

namespace Cube.Xui.Behaviors
{
    /* --------------------------------------------------------------------- */
    ///
    /// ActivateBehavior
    ///
    /// <summary>
    /// Represents the behavior when an ActivateMessage is received.
    /// </summary>
    ///
    /* --------------------------------------------------------------------- */
    public class ActivateBehavior : MessageBehavior<ActivateMessage>
    {
        #region Methods

        /* ----------------------------------------------------------------- */
        ///
        /// Invoke
        ///
        /// <summary>
        /// Invokes the action.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected override void Invoke(ActivateMessage e)
        {
            if (AssociatedObject is Window w)
            {
                if (w.WindowState == WindowState.Minimized) w.WindowState = WindowState.Normal;
                _ = w.Activate();
                ResetTopMost(w);
            }
        }

        #endregion

        #region Implementations

        /* ----------------------------------------------------------------- */
        ///
        /// ResetTopMost
        ///
        /// <summary>
        /// Resets the value of Topmost property.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void ResetTopMost(Window src)
        {
            var current = src.Topmost;
            src.Topmost = false;
            src.Topmost = true;
            src.Topmost = current;
        }

        #endregion
    }
}
