using Microsoft.VisualStudio.TestTools.UnitTesting;
using NawakoraBot.Models;
using NawakoraBot.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawakoraBot.Services.Tests {

    /// <summary>
    /// <see cref="NawakoraBot.Services.TweetService"/> をテストします。
    /// </summary>
    [TestClass()]
    public class TweetServiceTests {

        /// <summary>
        /// <see cref="NawakoraBot.Services.TweetService.Tweet"/> をテストします。
        /// </summary>
        [TestMethod()]
        public void TweetTest() {
            var expected = new Entry();
            expected.Title = string.Join("", Enumerable.Repeat("1234567890", 200));
            expected.Url = "http://www.google.co.jp";
            var target = new TweetService();
            target.Tweet(expected);
        }

    }

}