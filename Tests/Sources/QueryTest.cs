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
using Cube.Mixin.Iteration;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading;

namespace Cube.Tests
{
    /* --------------------------------------------------------------------- */
    ///
    /// QueryTest
    ///
    /// <summary>
    /// Tests the IQuery(T, U) implemented classes.
    /// </summary>
    ///
    /* --------------------------------------------------------------------- */
    [TestFixture]
    class QueryTest
    {
        #region Tests

        /* ----------------------------------------------------------------- */
        ///
        /// Request
        ///
        /// <summary>
        /// Tests the Query(T) class.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [TestCaseSource(nameof(TestCases))]
        public bool Request(int id, IList<string> seq, SynchronizationContext ctx)
        {
            SynchronizationContext.SetSynchronizationContext(ctx);

            var src = new Query<int>(e =>
            {
                if (e.Value >= seq.Count)
                {
                    e.Cancel = true;
                    e.Value = -1;
                }
                else if (seq[e.Value] == "success") e.Cancel = true;
                else e.Value++;
            });

            var msg = Query.NewMessage(id);
            Assert.That(msg.Query,  Is.EqualTo(id));
            Assert.That(msg.Value,  Is.EqualTo(0));
            Assert.That(msg.Cancel, Is.False);

            while (!msg.Cancel) src.Request(msg);
            return msg.Value != -1;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Wrap
        ///
        /// <summary>
        /// Tests the Query.Wrap method.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Test]
        public void Wrap()
        {
            var src  = Query.Wrap("a");
            var dest = string.Empty;

            5.Times(i =>
            {
                var msg = Query.NewMessage("string");
                src.Request(msg);
                dest += msg.Value;
            });

            Assert.That(dest, Is.EqualTo("aaaaa"));
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Wrap_TwiceException
        ///
        /// <summary>
        /// Tests the Query.Wrap method and confirms the TwiceException.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Test]
        public void Wrap_TwiceException()
        {
            var src = Query.Wrap("dummy", true);
            var msg = Query.NewMessage("string");
            Assert.That(() => 5.Times(i => src.Request(msg)), Throws.TypeOf<TwiceException>());
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Create_ArgumentNullException
        ///
        /// <summary>
        /// Tests the Query(T) class with the null object.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Test]
        public void Create_ArgumentNullException()
        {
            Assert.That(() => new Query<int>(null), Throws.ArgumentNullException);
        }

        #endregion

        #region TestCases

        /* ----------------------------------------------------------------- */
        ///
        /// TestCases
        ///
        /// <summary>
        /// Gets test cases.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private static IEnumerable<TestCaseData> TestCases
        {
            get
            {
                var n = 0;

                yield return new TestCaseData(n++,
                    new List<string> { "first", "second", "success" },
                    new SynchronizationContext()
                ).Returns(true);

                yield return new TestCaseData(n++,
                    new List<string> { "first", "second", "success" },
                    new SynchronizationContext()
                ).Returns(true);

                yield return new TestCaseData(n++,
                    new List<string> { "first", "failed" },
                    default(SynchronizationContext)
                ).Returns(false);

                yield return new TestCaseData(n++,
                    new List<string> { "first", "failed" },
                    default(SynchronizationContext)
                ).Returns(false);
            }
        }

        #endregion
    }
}
