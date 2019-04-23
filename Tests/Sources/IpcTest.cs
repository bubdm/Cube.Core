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
using Cube.Ipc;
using Cube.Mixin.Tasks;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Cube.Tests
{
    /* --------------------------------------------------------------------- */
    ///
    /// MessengerTest
    ///
    /// <summary>
    /// Messenger クラスのテスト用クラスです。
    /// </summary>
    ///
    /* --------------------------------------------------------------------- */
    [TestFixture]
    class MessengerTest
    {
        #region Tests

        /* ----------------------------------------------------------------- */
        ///
        /// Publish
        ///
        /// <summary>
        /// サーバにメッセージを送信するテストを実行します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Test]
        public void Publish()
        {
            var id     = nameof(MessengerTest);
            var msg    = "ClientToServer";
            var actual = string.Empty;

            using (var server = new Messenger<string>(id))
            using (var client = new MessengerClient<string>(id))
            {
                var cts = new CancellationTokenSource();
                Action<string> h = (x) =>
                {
                    actual = x;
                    server.Publish(x);
                    cts.Cancel();
                };

                IDisposable uns = null;

                try
                {
                    uns = server.Subscribe(h);
                    Task.Run(() => client.Publish(msg)).Forget();
                    Task.Delay(TimeSpan.FromSeconds(5), cts.Token).Wait();
                }
                catch (AggregateException /* err */) { uns.Dispose(); }
            }

            Assert.That(actual, Is.EqualTo(msg));
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Create_DuplicateServer_Throws
        ///
        /// <summary>
        /// サーバを 2 つ生成しようとするテストを実行します。
        /// </summary>
        ///
        /// <remarks>
        /// Messenger(T) は同一スレッド上に存在する他のサーバを検知する
        /// 事ができないので、2 つ目のサーバを生成しようとして例外が
        /// 発生します。
        /// </remarks>
        ///
        /* ----------------------------------------------------------------- */
        [Test]
        public void Create_DuplicateServer_Throws() => Assert.That(() =>
        {
            var id = nameof(MessengerTest);
            using (var s1 = new Messenger<string>(id))
            {
                Assert.That(s1.IsServer, Is.True);
                using (var s2 = new Messenger<string>(id)) { }
            }
        }, Throws.TypeOf<InvalidOperationException>());

        #endregion
    }
}
