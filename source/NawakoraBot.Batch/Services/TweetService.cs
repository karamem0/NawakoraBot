using CoreTweet;
using NawakoraBot.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawakoraBot.Services {

    /// <summary>
    /// ツイートするサービスを表します。
    /// </summary>
    public class TweetService {

        /// <summary>
        /// Twitter トークンを表します。
        /// </summary>
        private Tokens twitterToken;

        /// <summary>
        /// <see cref="NawakoraBot.Services.TweetService"/> クラスの新しいインスタンスを初期化します。
        /// </summary>
        public TweetService() {
            this.twitterToken = Tokens.Create(
                ConfigurationManager.AppSettings["ConsumerKey"],
                ConfigurationManager.AppSettings["ConsumerSecret"],
                ConfigurationManager.AppSettings["AccessToken"],
                ConfigurationManager.AppSettings["AccessTokenSecret"]
            );
        }

        /// <summary>
        /// 指定したコラムの内容をツイートします。
        /// </summary>
        /// <param name="entry"><see cref="NawakoraBot.Models.Entry"/>。</param>
        public void Tweet(Entry entry) {
            var hashTag = ConfigurationManager.AppSettings["HashTag"];
            var status = new StringBuilder();
            status.Append(" " + entry.Url);
            status.Append(" " + hashTag);
            if (entry.Title.Length + status.Length <= 140) {
                status.Insert(0, entry.Title);
            } else {
                status.Insert(0, entry.Title.Substring(0, 140 - (status.Length + 3)) + "...");
            }
            this.twitterToken.Statuses.Update(status.ToString());
        }

    }

}
