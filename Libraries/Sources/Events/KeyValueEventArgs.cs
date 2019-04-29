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
using System;

namespace Cube
{
    #region KeyValueEventArgs

    /* --------------------------------------------------------------------- */
    ///
    /// KeyValueEventArgs
    ///
    /// <summary>
    /// Provides methods to create a new instance of the
    /// KeyValueEventArgs(T, U) or KeyValueCancelEventArgs(T, U) classes.
    /// </summary>
    ///
    /* --------------------------------------------------------------------- */
    public static class KeyValueEventArgs
    {
        #region Methods

        /* ----------------------------------------------------------------- */
        ///
        /// Create
        ///
        /// <summary>
        /// Creates a new instance of the KeyValueEventArgs(T, U) class
        /// with the specified key and value.
        /// </summary>
        ///
        /// <param name="key">Key to use for the event.</param>
        /// <param name="value">Value to use for the event.</param>
        ///
        /* ----------------------------------------------------------------- */
        public static KeyValueEventArgs<T, U> Create<T, U>(T key, U value) =>
            new KeyValueEventArgs<T, U>(key, value);

        /* ----------------------------------------------------------------- */
        ///
        /// Create
        ///
        /// <summary>
        /// Creates a new instance of the KeyValueCancelEventArgs(T, U)
        /// class with the specified arguments.
        /// </summary>
        ///
        /// <param name="key">Key to use for the event.</param>
        /// <param name="value">Value to use for the event.</param>
        /// <param name="cancel">
        /// true to cancel the event; otherwise, false.
        /// </param>
        ///
        /* ----------------------------------------------------------------- */
        public static KeyValueCancelEventArgs<T, U> Create<T, U>(T key, U value, bool cancel) =>
            new KeyValueCancelEventArgs<T, U>(key, value, cancel);

        #endregion
    }

    #endregion

    #region KeyValueEventArgs<T, U>

    /* --------------------------------------------------------------------- */
    ///
    /// KeyValueEventArgs(T, U)
    ///
    /// <summary>
    /// Provides Key-Value data to use for events.
    /// </summary>
    ///
    /* --------------------------------------------------------------------- */
    public class KeyValueEventArgs<T, U> : ValueEventArgs<U>
    {
        #region Constructors

        /* ----------------------------------------------------------------- */
        ///
        /// KeyValueEventArgs
        ///
        /// <summary>
        /// Creates a new instance of the KeyValueEventArgs class with the
        /// specified key and value.
        /// </summary>
        ///
        /// <param name="key">Key to use for the event.</param>
        /// <param name="value">Value to use for the event.</param>
        ///
        /* ----------------------------------------------------------------- */
        public KeyValueEventArgs(T key, U value) : base(value)
        {
            Key = key;
        }

        #endregion

        #region Properties

        /* ----------------------------------------------------------------- */
        ///
        /// Key
        ///
        /// <summary>
        /// Gets a key to use for the event.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public T Key { get; }

        #endregion
    }

    #endregion

    #region KeyValueCancelEventArgs<T, U>

    /* --------------------------------------------------------------------- */
    ///
    /// KeyValueCancelEventArgs(T, U)
    ///
    /// <summary>
    /// Provides data for a cancelable event with Key-Value data.
    /// </summary>
    ///
    /* --------------------------------------------------------------------- */
    public class KeyValueCancelEventArgs<T, U> : ValueCancelEventArgs<U>
    {
        #region Constructors

        /* ----------------------------------------------------------------- */
        ///
        /// KeyValueCancelEventArgs
        ///
        /// <summary>
        /// Initializes a new instance of the KeyValueCancelEventArgs class
        /// with the specified key and value. The Cancel property is set
        /// to false.
        /// </summary>
        ///
        /// <param name="key">Key to use for the event.</param>
        /// <param name="value">Value to use for the event.</param>
        ///
        /* ----------------------------------------------------------------- */
        public KeyValueCancelEventArgs(T key, U value) : this(key, value, false) { }

        /* ----------------------------------------------------------------- */
        ///
        /// KeyValueCancelEventArgs
        ///
        /// <summary>
        /// Initializes a new instance of the KeyValueCancelEventArgs class
        /// with the specified arguments.
        /// </summary>
        ///
        /// <param name="key">Key to use for the event.</param>
        /// <param name="value">Value to use for the event.</param>
        /// <param name="cancel">
        /// true to cancel the event; otherwise, false.
        /// </param>
        ///
        /* ----------------------------------------------------------------- */
        public KeyValueCancelEventArgs(T key, U value, bool cancel) : base(value, cancel)
        {
            Key = key;
        }

        #endregion

        #region Properties

        /* ----------------------------------------------------------------- */
        ///
        /// Key
        ///
        /// <summary>
        /// Gets a key to use for the event.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public T Key { get; }

        #endregion
    }

    #endregion

    #region KeyValueEventHandlers

    /* --------------------------------------------------------------------- */
    ///
    /// KeyValueEventHandler(T, U)
    ///
    /// <summary>
    /// Represents the method to invoke an event.
    /// </summary>
    ///
    /* --------------------------------------------------------------------- */
    [Serializable]
    public delegate void KeyValueEventHandler<T, U>(object sender, KeyValueEventArgs<T, U> e);

    /* --------------------------------------------------------------------- */
    ///
    /// KeyValueCanelEventHandler(T, U)
    ///
    /// <summary>
    /// Represents the method to invoke an event.
    /// </summary>
    ///
    /* --------------------------------------------------------------------- */
    [Serializable]
    public delegate void KeyValueCanelEventHandler<T, U>(object sender, KeyValueCancelEventArgs<T, U> e);

    #endregion
}
