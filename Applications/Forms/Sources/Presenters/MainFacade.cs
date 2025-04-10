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
using System.Reflection;

namespace Cube.Forms.Demo
{
    /* --------------------------------------------------------------------- */
    ///
    /// MainFacade
    ///
    /// <summary>
    /// Represents the facade model to communicate with the MainViewModel
    /// object.
    /// </summary>
    ///
    /* --------------------------------------------------------------------- */
    public class MainFacade
    {
        /* --------------------------------------------------------------------- */
        ///
        /// Assembly
        ///
        /// <summary>
        /// Gets the assembly object.
        /// </summary>
        ///
        /* --------------------------------------------------------------------- */
        public Assembly Assembly { get; } = Assembly.GetExecutingAssembly();

        /* --------------------------------------------------------------------- */
        ///
        /// Notice
        ///
        /// <summary>
        /// Gets the model for notice component.
        /// </summary>
        ///
        /* --------------------------------------------------------------------- */
        public NoticeFacade Notice { get; } = new();
    }
}
