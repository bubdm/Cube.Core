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
using System.Threading.Tasks;
using Cube.Log;

namespace Cube.Tasks
{
    /* --------------------------------------------------------------------- */
    ///
    /// TaskOperator
    ///
    /// <summary>
    /// Task の拡張メソッド用クラスです。
    /// </summary>
    ///
    /* --------------------------------------------------------------------- */
    public static class TaskOperator
    {
        /* --------------------------------------------------------------------- */
        ///
        /// Forget
        ///
        /// <summary>
        /// 実行されたタスクを待たずに終了します。
        /// 例外発生時にはログに出力します。
        /// </summary>
        ///
        /// <param name="task">Task オブジェクト</param>
        ///
        /* --------------------------------------------------------------------- */
        public static void Forget(this Task task) => task.ContinueWith(x =>
        {
            x.LogWarn(x.Exception.ToString());
        }, TaskContinuationOptions.OnlyOnFaulted);

        /* --------------------------------------------------------------------- */
        ///
        /// Timeout
        ///
        /// <summary>
        /// タスクにタイムアウトを設定します。
        /// </summary>
        ///
        /// <param name="task">Task オブジェクト</param>
        /// <param name="timeout">タイムアウト時間</param>
        ///
        /// <returns>Task オブジェクト</returns>
        ///
        /* --------------------------------------------------------------------- */
        public static async Task Timeout(this Task task, TimeSpan timeout)
        {
            var delay = Task.Delay(timeout);
            if (await Task.WhenAny(task, delay).ConfigureAwait(false) == delay)
            {
                throw new TimeoutException();
            }
        }

        /* --------------------------------------------------------------------- */
        ///
        /// Timeout
        ///
        /// <summary>
        /// タスクにタイムアウトを設定します。
        /// </summary>
        ///
        /// <param name="task">Task(T) オブジェクト</param>
        /// <param name="timeout">タイムアウト時間</param>
        ///
        /// <returns>Task(T) オブジェクト</returns>
        ///
        /* --------------------------------------------------------------------- */
        public static async Task<T> Timeout<T>(this Task<T> task, TimeSpan timeout)
        {
            await ((Task)task).Timeout(timeout);
            return await task;
        }
    }
}
