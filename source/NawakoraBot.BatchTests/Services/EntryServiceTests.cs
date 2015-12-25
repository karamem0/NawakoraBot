using Microsoft.VisualStudio.TestTools.UnitTesting;
using NawakoraBot.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawakoraBot.Services.Tests {

    /// <summary>
    /// <see cref="NawakoraBot.Services.EntryService"/> をテストします。
    /// </summary>
    [TestClass()]
    public class EntryServiceTests {

        /// <summary>
        /// <see cref="NawakoraBot.Services.EntryService.Load"/> をテストします。
        /// </summary>
        [TestMethod()]
        public void LoadTest() {
            var target = new EntryService();
            var actual = target.Load();
            Assert.IsNotNull(actual);
            foreach (var item in actual) {
                Debug.WriteLine(item);
            }
        }

    }

}