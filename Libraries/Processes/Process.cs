﻿/* ------------------------------------------------------------------------- */
///
/// Copyright (c) 2010 CubeSoft, Inc.
/// 
/// Licensed under the Apache License, Version 2.0 (the "License");
/// you may not use this file except in compliance with the License.
/// You may obtain a copy of the License at
///
///  http://www.apache.org/licenses/LICENSE-2.0
///
/// Unless required by applicable law or agreed to in writing, software
/// distributed under the License is distributed on an "AS IS" BASIS,
/// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
/// See the License for the specific language governing permissions and
/// limitations under the License.
///
/* ------------------------------------------------------------------------- */
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Cube.Processes
{
    /* --------------------------------------------------------------------- */
    ///
    /// Process
    /// 
    /// <summary>
    /// プロセスを扱うクラスです。
    /// </summary>
    ///
    /* --------------------------------------------------------------------- */
    public static class Process
    {
        #region Methods

        /* ----------------------------------------------------------------- */
        ///
        /// StartAsActiveUser
        ///
        /// <summary>
        /// アクティブユーザ権限でプログラムを実行します。
        /// </summary>
        /// 
        /// <param name="program">実行プログラムのパス</param>
        /// <param name="arguments">プログラムの引数</param>
        /// 
        /// <returns>実行に成功した <c>Process</c> オブジェクト</returns>
        ///
        /* ----------------------------------------------------------------- */
        public static System.Diagnostics.Process StartAsActiveUser(string program, string[] arguments)
            => StartAsActiveUser(string.Empty, program, arguments);

        /* ----------------------------------------------------------------- */
        ///
        /// StartAsActiveUser
        ///
        /// <summary>
        /// アクティブユーザ権限でプログラムを実行します。
        /// </summary>
        /// 
        /// <param name="username">ユーザ名</param>
        /// <param name="program">実行プログラムのパス</param>
        /// <param name="arguments">プログラムの引数</param>
        /// 
        /// <returns>実行に成功した <c>Process</c> オブジェクト</returns>
        ///
        /* ----------------------------------------------------------------- */
        public static System.Diagnostics.Process StartAsActiveUser(
            string username, string program, string[] arguments)
            => StartAsActiveUser(username, CreateCmdLine(program, arguments));

        /* ----------------------------------------------------------------- */
        ///
        /// StartAsActiveUser
        ///
        /// <summary>
        /// アクティブユーザ権限でプログラムを実行します。
        /// </summary>
        /// 
        /// <param name="cmdline">実行するコマンドライン</param>
        /// 
        /// <returns>実行に成功した <c>Process</c> オブジェクト</returns>
        ///
        /* ----------------------------------------------------------------- */
        public static System.Diagnostics.Process StartAsActiveUser(string cmdline)
            => StartAsActiveUser(string.Empty, cmdline);

        /* ----------------------------------------------------------------- */
        ///
        /// StartAsActiveUser
        ///
        /// <summary>
        /// アクティブユーザ権限でプログラムを実行します。
        /// </summary>
        /// 
        /// <param name="username">ユーザ名</param>
        /// <param name="cmdline">実行するコマンドライン</param>
        /// 
        /// <returns>実行に成功した <c>Process</c> オブジェクト</returns>
        ///
        /* ----------------------------------------------------------------- */
        public static System.Diagnostics.Process StartAsActiveUser(string username, string cmdline)
            => StartAs(GetActiveSessionToken(username), cmdline);

        /* ----------------------------------------------------------------- */
        ///
        /// StartAs
        ///
        /// <summary>
        /// 指定されたトークンの権限でプログラムを実行します。
        /// </summary>
        /// 
        /// <param name="token">実行ユーザのトークン</param>
        /// <param name="program">実行プログラムのパス</param>
        /// <param name="arguments">プログラムの引数</param>
        /// 
        /// <returns>実行に成功した <c>Process</c> オブジェクト</returns>
        ///
        /* ----------------------------------------------------------------- */
        public static System.Diagnostics.Process StartAs(IntPtr token,
            string program, string[] arguments)
            => StartAs(token, CreateCmdLine(program, arguments));

        /* ----------------------------------------------------------------- */
        ///
        /// StartAsActiveUser
        ///
        /// <summary>
        /// 指定されたトークンの権限でプログラムを実行します。
        /// </summary>
        /// 
        /// <param name="token">実行ユーザのトークン</param>
        /// <param name="cmdline">実行するコマンドライン</param>
        /// 
        /// <returns>実行に成功した <c>Process</c> オブジェクト</returns>
        ///
        /* ----------------------------------------------------------------- */
        public static System.Diagnostics.Process StartAs(IntPtr token, string cmdline)
        {
            var env = IntPtr.Zero;

            try
            {
                if (token == IntPtr.Zero) throw new ArgumentException("PrimaryToken");

                env = GetEnvironmentBlock(token);
                if (env == IntPtr.Zero) throw new ArgumentException("EnvironmentBlock");

                return CreateProcessAsUser(cmdline, token, env);
            }
            finally
            {
                if (env != IntPtr.Zero) UserEnv.NativeMethods.DestroyEnvironmentBlock(env);
                CloseHandle(token);
            }
        }

        #endregion

        #region Implementations

        /* ----------------------------------------------------------------- */
        ///
        /// CreateCmdLine
        ///
        /// <summary>
        /// コマンドライン用の文字列を生成します。
        /// </summary>
        /// 
        /* ----------------------------------------------------------------- */
        private static string CreateCmdLine(string program, string[] arguments)
            => arguments == null ?
            $"\"{program}\"" :
            arguments.Aggregate($"\"{program}\"", (s, x) => s + " " + $"\"{x}\"");

        /* ----------------------------------------------------------------- */
        ///
        /// CreateProcessAsUser
        ///
        /// <summary>
        /// Win32 API の CreateProcessAsUser を実行します。
        /// </summary>
        /// 
        /* ----------------------------------------------------------------- */
        private static System.Diagnostics.Process CreateProcessAsUser(string cmdline, IntPtr token, IntPtr env)
        {
            var si = new STARTUPINFO
            {
                lpDesktop   = @"WinSta0\Default",
                wShowWindow = 0x05,  // SW_SHOW
                dwFlags     = 0x01 | // STARTF_USESHOWWINDOW 
                              0x40,  // STARTF_FORCEONFEEDBACK
            };
            si.cb = (uint)Marshal.SizeOf(si);

            var sa = new SECURITY_ATTRIBUTES();
            sa.nLength = (uint)Marshal.SizeOf(sa);

            var thread = new SECURITY_ATTRIBUTES();
            thread.nLength = (uint)Marshal.SizeOf(thread);

            var pi = new PROCESS_INFORMATION();
            try
            {
                if (!AdvApi32.NativeMethods.CreateProcessAsUser(
                    token,
                    null,
                    cmdline,
                    ref sa,
                    ref thread,
                    false,
                    0x0400, // CREATE_UNICODE_ENVIRONMENT
                    env,
                    null,
                    ref si,
                    out pi
                )) Win32Error("CreateProcessAsUser");

                return System.Diagnostics.Process.GetProcessById((int)pi.dwProcessId);
            }
            finally
            {
                CloseHandle(pi.hProcess);
                CloseHandle(pi.hThread);
            }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// GetActiveSessionId
        ///
        /// <summary>
        /// 現在ログオン中のユーザに対応するセッション ID を取得します。
        /// </summary>
        /// 
        /// <param name="username">ユーザ名</param>
        /// 
        /* ----------------------------------------------------------------- */
        private static uint GetActiveSessionId(string username)
        {
            var ptr = IntPtr.Zero;
            var count = 0u;

            try
            {
                if (!WtsApi32.NativeMethods.WTSEnumerateSessions(
                    (IntPtr)0, // WTS_CURRENT_SERVER_HANDLE
                    0,
                    1,
                    ref ptr,
                    ref count
                )) Win32Error("WTSEnumerateSessions");

                var sessions = new List<WTS_SESSION_INFO>();

                for (var i = 0; i < count; ++i)
                {
                    var info = (WTS_SESSION_INFO)Marshal.PtrToStructure(
                        ptr + i * Marshal.SizeOf(typeof(WTS_SESSION_INFO)),
                        typeof(WTS_SESSION_INFO)
                    );

                    if (info.State == WTS_CONNECTSTATE_CLASS.WTSActive) sessions.Add(info);
                }

                if (sessions.Count <= 0) throw new ArgumentException("Active session not found");
                else if (sessions.Count == 1) return sessions[0].SessionID;
                else return sessions.Select(x => x.SessionID).First(x => GetUserName(x) == username);
            }
            finally { if (ptr != IntPtr.Zero) WtsApi32.NativeMethods.WTSFreeMemory(ptr); }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// GetActiveSessionToken
        ///
        /// <summary>
        /// アクティブなセッションに対応するトークンを取得します。
        /// </summary>
        /// 
        /// <param name="username">ユーザ名</param>
        /// 
        /* ----------------------------------------------------------------- */
        private static IntPtr GetActiveSessionToken(string username)
        {
            var id = GetActiveSessionId(username);
            var token = IntPtr.Zero;

            if (!WtsApi32.NativeMethods.WTSQueryUserToken(id, out token)) Win32Error("WTSQueryUserToken");
            try { return GetPrimaryToken(token, SECURITY_IMPERSONATION_LEVEL.SecurityImpersonation); }
            finally { CloseHandle(token); }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// GetPrimaryToken
        ///
        /// <summary>
        /// プライマリトークンを取得します。
        /// </summary>
        /// 
        /* ----------------------------------------------------------------- */
        private static IntPtr GetPrimaryToken(IntPtr token, SECURITY_IMPERSONATION_LEVEL level)
        {
            var dest = IntPtr.Zero;
            var attr = new SECURITY_ATTRIBUTES();
            attr.nLength = (uint)Marshal.SizeOf(attr);
            var result = AdvApi32.NativeMethods.DuplicateTokenEx(
                token,
                0x0001 | // TOKEN_ASSIGN_PRIMARY
                0x0002 | // TOKEN_DUPLICATE
                0x0004 | // TOKEN_IMPERSONATE
                0x0008,  // TOKEN_QUERY
                ref attr,
                (int)level,
                (int)TOKEN_TYPE.TokenPrimary,
                ref dest
            );

            AdvApi32.NativeMethods.RevertToSelf();

            if (!result) Win32Error("DuplicateTokenEx");
            return dest;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// GetUserName
        ///
        /// <summary>
        /// ユーザ名を取得します。
        /// </summary>
        /// 
        /* ----------------------------------------------------------------- */
        private static string GetUserName(uint id)
        {
            var handle = IntPtr.Zero;
            var buffer = IntPtr.Zero;
            var result = 0u;

            try
            {
                return WtsApi32.NativeMethods.WTSQuerySessionInformation(
                           handle,
                           (int)id,
                           WTS_INFO_CLASS.WTSUserName,
                           out buffer,
                           out result
                       ) ? Marshal.PtrToStringAnsi(buffer) : string.Empty;
            }
            finally { WtsApi32.NativeMethods.WTSFreeMemory(buffer); }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// GetEnvironmentBlock
        ///
        /// <summary>
        /// 環境ブロックを取得します。
        /// </summary>
        /// 
        /* ----------------------------------------------------------------- */
        private static IntPtr GetEnvironmentBlock(IntPtr token)
        {
            var dest = IntPtr.Zero;
            var result = UserEnv.NativeMethods.CreateEnvironmentBlock(ref dest, token, false);
            if (!result) Win32Error("CreateEnvironmentBlock");
            return dest;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// CloseHandle
        ///
        /// <summary>
        /// ハンドルを閉じます。
        /// </summary>
        /// 
        /* ----------------------------------------------------------------- */
        private static void CloseHandle(IntPtr handle)
        {
            if (handle == IntPtr.Zero) return;
            Kernel32.NativeMethods.CloseHandle(handle);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Win32Error
        ///
        /// <summary>
        /// Win32 Error の値を持つ例外を送出します。
        /// </summary>
        /// 
        /* ----------------------------------------------------------------- */
        private static void Win32Error(string message)
        {
            throw new Win32Exception(Marshal.GetLastWin32Error(), message);
        }

        #endregion
    }
}
