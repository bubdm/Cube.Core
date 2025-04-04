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
using System.Windows.Forms;
using Cube.Mixin.Forms;

namespace Cube.Forms.Behaviors
{
    /* --------------------------------------------------------------------- */
    ///
    /// ActivateBehavior
    ///
    /// <summary>
    /// Provides functionality to activate the window.
    /// </summary>
    ///
    /* --------------------------------------------------------------------- */
    public class ActivateBehavior : MessageBehavior<ActivateMessage>
    {
        /* ----------------------------------------------------------------- */
        ///
        /// ActivateBehavior
        ///
        /// <summary>
        /// Initializes a new instance of the ActivateBehavior class
        /// with the specified arguments.
        /// </summary>
        ///
        /// <param name="view">Source view.</param>
        /// <param name="aggregator">Aggregator object.</param>
        ///
        /* ----------------------------------------------------------------- */
        public ActivateBehavior(Form view, IAggregator aggregator) : base(aggregator, e =>
        {
            if (view.WindowState == FormWindowState.Minimized) view.WindowState = FormWindowState.Normal;
            view.Activate();
            view.ResetTopMost();
        }) { }
    }
}
