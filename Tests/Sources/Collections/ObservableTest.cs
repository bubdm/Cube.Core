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
using Cube.Collections;
using NUnit.Framework;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;

namespace Cube.Tests
{
    /* --------------------------------------------------------------------- */
    ///
    /// ObservableTest
    ///
    /// <summary>
    /// Represents the test for the ObservableBase(T) collection.
    /// </summary>
    ///
    /* --------------------------------------------------------------------- */
    [TestFixture]
    class ObservableTest
    {
        #region

        /* ----------------------------------------------------------------- */
        ///
        /// Invoke
        ///
        /// <summary>
        /// Executes the test to confirm that CollectinChanged events are
        /// raised.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Test]
        public void Invoke()
        {
            var src = new TestCollection<int>();
            Assert.That(src.Context, Is.Null);
            src.Context = new SynchronizationContext();

            var count = 0;
            src.CollectionChanged += (s, e) => ++count;

            for (var i = 0; i < 10; ++i) src.Add(i);
            Assert.That(count,       Is.EqualTo(10), "CollectionChanged");
            Assert.That(src.Count(), Is.EqualTo(10), "Count");
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Invoke_Null
        ///
        /// <summary>
        /// Executes the test to confirm that CollectinChanged events are
        /// raised when the Context property is null.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Test]
        public void Invoke_Null()
        {
            var src = new TestCollection<int>();
            Assert.That(src.Context, Is.Null);

            var count = 0;
            src.CollectionChanged += (s, e) => ++count;

            for (var i = 0; i < 5; ++i) src.Add(i);
            Assert.That(count,       Is.EqualTo(5), "CollectionChanged");
            Assert.That(src.Count(), Is.EqualTo(5), "Count");
        }

        #endregion
    }

    /* --------------------------------------------------------------------- */
    ///
    /// TestCollection
    ///
    /// <summary>
    /// Represents the dummy collection that implements IEnumerable(T)
    /// and INotifiCollectionChanged interfaces.
    /// </summary>
    ///
    /* --------------------------------------------------------------------- */
    class TestCollection<T> : ObservableBase<T>
    {
        #region Constructors

        /* ----------------------------------------------------------------- */
        ///
        /// TestCollection
        ///
        /// <summary>
        /// Initializes a new instance of the TestCollection class.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public TestCollection()
        {
            _inner.CollectionChanged += (s, e) => OnCollectionChanged(e);
        }

        #endregion

        #region Methods

        /* ----------------------------------------------------------------- */
        ///
        /// Add
        ///
        /// <summary>
        /// Add the specified value.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public void Add(T value) => _inner.Add(value);

        /* --------------------------------------------------------------------- */
        ///
        /// GetEnumerator
        ///
        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        ///
        /* --------------------------------------------------------------------- */
        public override IEnumerator<T> GetEnumerator() => _inner.GetEnumerator();

        #endregion

        #region Fields
        private readonly ObservableCollection<T> _inner = new ObservableCollection<T>();
        #endregion
    }
}
