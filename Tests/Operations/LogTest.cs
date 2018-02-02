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
using NUnit.Framework;
using Cube.Log;

namespace Cube.Tests
{
    /* --------------------------------------------------------------------- */
    ///
    /// LogTest
    ///
    /// <summary>
    /// LogOperator のテスト用クラスです。
    /// </summary>
    ///
    /* --------------------------------------------------------------------- */
    [TestFixture]
    class LogTest
    {
        #region Tests

        /* ----------------------------------------------------------------- */
        ///
        /// LogDebug
        ///
        /// <summary>
        /// Debug 系メソッドのテストを実行します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Test]
        public void LogDebug() => Assert.DoesNotThrow(() =>
        {
            var message = nameof(LogOperator.Debug);

            try
            {
                LogOperator.Debug(typeof(LogTest), message);
                this.LogDebug($"{message} (extension)");
                throw new ArgumentException($"{message} (throw)");
            }
            catch (ArgumentException err)
            {
                Assert.That(err.Message, Does.StartWith(message));
                LogOperator.Debug(typeof(LogTest), err.Message, err);
                this.LogDebug(err.Message, err);
            }
        });

        /* ----------------------------------------------------------------- */
        ///
        /// LogInfo
        ///
        /// <summary>
        /// Info 系メソッドのテストを実行します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Test]
        public void LogInfo() => Assert.DoesNotThrow(() =>
        {
            var message = nameof(LogOperator.Info);

            try
            {
                var asm = AssemblyReader.Default.Assembly;
                LogOperator.Info(typeof(LogTest), message);
                LogOperator.Info(typeof(LogTest), asm);
                this.LogInfo($"{message} (extension)");
                this.LogInfo(asm);
                throw new ArgumentException($"{message} (throw)");
            }
            catch (ArgumentException err)
            {
                Assert.That(err.Message, Does.StartWith(message));
                LogOperator.Info(typeof(LogTest), err.Message, err);
                this.LogInfo(err.Message, err);
            }
        });

        /* ----------------------------------------------------------------- */
        ///
        /// LogWarn
        ///
        /// <summary>
        /// Warn 系メソッドのテストを実行します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Test]
        public void LogWarn() => Assert.DoesNotThrow(() =>
        {
            var message = nameof(LogOperator.Warn);

            try
            {
                LogOperator.Warn(typeof(LogTest), message);
                this.LogWarn($"{message} (extension)");
                throw new ArgumentException($"{message} (throw)");
            }
            catch (ArgumentException err)
            {
                Assert.That(err.Message, Does.StartWith(message));
                LogOperator.Warn(typeof(LogTest), err.Message, err);
                this.LogWarn(err.Message, err);
            }
        });

        /* ----------------------------------------------------------------- */
        ///
        /// LogError
        ///
        /// <summary>
        /// Error 系メソッドのテストを実行します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Test]
        public void Log_Error() => Assert.DoesNotThrow(() =>
        {
            var message = nameof(LogOperator.Error);

            try
            {
                LogOperator.Error(typeof(LogTest), message);
                this.LogError($"{message} (extension)");
                throw new ArgumentException($"{message} (throw)");
            }
            catch (ArgumentException err)
            {
                Assert.That(err.Message, Does.StartWith(message));
                LogOperator.Error(typeof(LogTest), err.Message, err);
                this.LogError(err.Message, err);
            }
        });

        /* ----------------------------------------------------------------- */
        ///
        /// LogFatal
        ///
        /// <summary>
        /// Fatal 系メソッドのテストを実行します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Test]
        public void LogFatal() => Assert.DoesNotThrow(() =>
        {
            var message = nameof(LogOperator.Fatal);

            try
            {
                LogOperator.Fatal(typeof(LogTest), message);
                this.LogFatal($"{message} (extension)");
                throw new ArgumentException($"{message} (throw)");
            }
            catch (ArgumentException err)
            {
                Assert.That(err.Message, Does.StartWith(message));
                LogOperator.Fatal(typeof(LogTest), err.Message, err);
                this.LogFatal(err.Message, err);
            }
        });

        #endregion
    }
}
