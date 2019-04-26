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
using System;
using System.Collections.Generic;

namespace Cube.Collections
{
    /* --------------------------------------------------------------------- */
    ///
    /// ArgumentCollection
    ///
    /// <summary>
    /// Provides functionality to parse arguments.
    /// </summary>
    ///
    /// <remarks>
    /// このクラスでは、各オプションは最大 1 つの引数しか指定できないと言う
    /// 制約を設けています。それ以外の引数は全て自身のシーケンスに格納され
    /// ます。また、同じオプションが複数回指定された場合、後に指定された
    /// 内容で上書きされます。
    /// </remarks>
    ///
    /* --------------------------------------------------------------------- */
    public class ArgumentCollection : EnumerableBase<string>, IReadOnlyList<string>
    {
        #region Constructors

        /* --------------------------------------------------------------------- */
        ///
        /// ArgumentCollection
        ///
        /// <summary>
        /// Initializes a new instance of the ArgumentCollection class with
        /// the specified collection.
        /// </summary>
        ///
        /// <param name="src">Collection of arguments.</param>
        ///
        /* --------------------------------------------------------------------- */
        public ArgumentCollection(IEnumerable<string> src) : this(src, '-') { }

        /* --------------------------------------------------------------------- */
        ///
        /// ArgumentCollection
        ///
        /// <summary>
        /// Initializes a new instance of the ArgumentCollection class with
        /// the specified parameters.
        /// </summary>
        ///
        /// <param name="src">Collection of arguments.</param>
        /// <param name="prefix">Prefix of optional parameters.</param>
        ///
        /* --------------------------------------------------------------------- */
        public ArgumentCollection(IEnumerable<string> src, char prefix) :
            this(src, prefix, false) { }

        /* --------------------------------------------------------------------- */
        ///
        /// ArgumentCollection
        ///
        /// <summary>
        /// Initializes a new instance of the ArgumentCollection class with
        /// the specified parameters.
        /// </summary>
        ///
        /// <param name="src">Collection of arguments.</param>
        /// <param name="prefix">Prefix of optional parameters.</param>
        /// <param name="ignore">
        /// Value indicating whether the class ignores case of optional keys.
        /// </param>
        ///
        /* --------------------------------------------------------------------- */
        public ArgumentCollection(IEnumerable<string> src, char prefix, bool ignore)
        {
            Prefix     = prefix;
            IgnoreCase = ignore;
            _options   = ignore ?
                         new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase) :
                         new Dictionary<string, string>();
            Parse(src);
        }

        #endregion

        #region Properties

        /* --------------------------------------------------------------------- */
        ///
        /// Prefix
        ///
        /// <summary>
        /// Gets the prefix character that represents optional parameters.
        /// </summary>
        ///
        /* --------------------------------------------------------------------- */
        public char Prefix { get; }

        /* --------------------------------------------------------------------- */
        ///
        /// IgnoreCase
        ///
        /// <summary>
        /// Gets the value indicating whether the class ignores case of
        /// optional keys.
        /// </summary>
        ///
        /* --------------------------------------------------------------------- */
        public bool IgnoreCase { get; }

        /* --------------------------------------------------------------------- */
        ///
        /// Item(int)
        ///
        /// <summary>
        /// Gets the collection of arguments except for optional parameters.
        /// </summary>
        ///
        /* --------------------------------------------------------------------- */
        public string this[int index] => _primary[index];

        /* --------------------------------------------------------------------- */
        ///
        /// Count
        ///
        /// <summary>
        /// Gets the number of arguments except for optional parameters.
        /// </summary>
        ///
        /* --------------------------------------------------------------------- */
        public int Count => _primary.Count;

        /* --------------------------------------------------------------------- */
        ///
        /// Options
        ///
        /// <summary>
        /// Gets the collection of optional parameters.
        /// </summary>
        ///
        /* --------------------------------------------------------------------- */
        public IReadOnlyDictionary<string, string> Options => _options;

        #endregion

        #region Methods

        /* --------------------------------------------------------------------- */
        ///
        /// GetEnumerator
        ///
        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        ///
        /// <returns>
        /// Enumerator that can be used to iterate through the collection.
        /// </returns>
        ///
        /* --------------------------------------------------------------------- */
        public override IEnumerator<string> GetEnumerator() => _primary.GetEnumerator();

        #endregion

        #region Implementations

        /* ----------------------------------------------------------------- */
        ///
        /// Dispose
        ///
        /// <summary>
        /// Releases the unmanaged resources used by the object and
        /// optionally releases the managed resources.
        /// </summary>
        ///
        /// <param name="disposing">
        /// true to release both managed and unmanaged resources;
        /// false to release only unmanaged resources.
        /// </param>
        ///
        /* ----------------------------------------------------------------- */
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _primary.Clear();
                _options.Clear();
            }
        }

        /* --------------------------------------------------------------------- */
        ///
        /// Parse
        ///
        /// <summary>
        /// Parses the specified arguments.
        /// </summary>
        ///
        /* --------------------------------------------------------------------- */
        private void Parse(IEnumerable<string> src)
        {
            var key = string.Empty;

            foreach (var s in src)
            {
                if (!s.HasValue()) continue;

                if (s[0] == Prefix)
                {
                    if (key.HasValue()) UpdateOption(key, null);
                    key = s.TrimStart(Prefix);
                }
                else if (key.HasValue())
                {
                    UpdateOption(key, s);
                    key = string.Empty;
                }
                else _primary.Add(s);
            }

            if (key.HasValue()) UpdateOption(key, null);
        }

        /* --------------------------------------------------------------------- */
        ///
        /// UpdateOption
        ///
        /// <summary>
        /// Updates optional parameters.
        /// </summary>
        ///
        /* --------------------------------------------------------------------- */
        private void UpdateOption(string key, string value)
        {
            if (_options.ContainsKey(key)) _options[key] = value;
            else _options.Add(key, value);
        }

        #endregion

        #region Fields
        private readonly List<string> _primary = new List<string>();
        private readonly Dictionary<string, string> _options;
        #endregion
    }
}
