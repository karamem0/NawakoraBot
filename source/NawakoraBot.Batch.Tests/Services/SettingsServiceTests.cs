using Microsoft.VisualStudio.TestTools.UnitTesting;
using NawakoraBot.Models;
using NawakoraBot.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawakoraBot.Services.Tests {

    /// <summary>
    /// <see cref="NawakoraBot.Services.SettingsService"/> をテストします。
    /// </summary>
    [TestClass()]
    public class SettingsServiceTests {

        /// <summary>
        /// テスト クラスを初期化します。
        /// </summary>
        /// <param name="testContext"><see cref="Microsoft.VisualStudio.TestTools.UnitTesting.TestContext"/>。</param>
        [ClassInitialize()]
        public static void ClassInitialize(TestContext testContext) {
            var webRootPath = testContext.TestRunResultsDirectory;
            Environment.SetEnvironmentVariable("WEBROOT_PATH", webRootPath);
            Directory.CreateDirectory(Path.Combine(webRootPath, "App_Data"));
        }

        /// <summary>
        /// <see cref="NawakoraBot.Services.SettingsService.Load"/> をテストします。
        /// </summary>
        [TestMethod()]
        public void LoadTest() {
            var target = new SettingsService();
            var actual = target.Load();
            Assert.IsNotNull(actual);
            Debug.WriteLine(actual);
        }

        /// <summary>
        /// <see cref="NawakoraBot.Services.SettingsService.Save"/> をテストします。
        /// </summary>
        [TestMethod()]
        public void SaveTest() {
            var expected = new Settings();
            var target = new SettingsService();
            target.Save(expected);
        }

    }

}