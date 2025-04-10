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
using Cube.Mixin.String;
using Forms = System.Windows.Forms;

namespace Cube.Xui.Behaviors
{
    /* --------------------------------------------------------------------- */
    ///
    /// OpenDirectoryBehavior
    ///
    /// <summary>
    /// Represents the behavior to show a dialog using an OpenDirectoryMessage.
    /// </summary>
    ///
    /* --------------------------------------------------------------------- */
    public class OpenDirectoryBehavior : MessageBehavior<OpenDirectoryMessage>
    {
        /* ----------------------------------------------------------------- */
        ///
        /// Invoke
        ///
        /// <summary>
        /// Invokes the action.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected override void Invoke(OpenDirectoryMessage e)
        {
            var view = new Forms.FolderBrowserDialog { ShowNewFolderButton = e.NewButton };

            if (e.Text.HasValue()) view.Description = e.Text;
            if (e.Value.HasValue()) view.SelectedPath = e.Value;

            e.Cancel = view.ShowDialog() != Forms.DialogResult.OK;
            if (!e.Cancel) e.Value = view.SelectedPath;
        }
    }
}
