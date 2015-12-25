using NawakoraBot.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawakoraBot.Controllers {

    /// <summary>
    /// バッチ処理を実行するコントローラーを表します。
    /// </summary>
    public class BatchController {

        /// <summary>
        /// 設定情報を取得または保存するサービスを表します。
        /// </summary>
        private SettingsService settingsService;

        /// <summary>
        /// コラムを取得するサービスを表します。
        /// </summary>
        private EntryService entryService;

        /// <summary>
        /// ツイートするサービスを表します。
        /// </summary>
        private TweetService tweetService;

        /// <summary>
        /// <see cref="NawakoraBot.Controllers.BatchController"/> クラスの新しいインスタンスを初期化します。
        /// </summary>
        public BatchController() {
            this.tweetService = new TweetService();
            this.entryService = new EntryService();
            this.settingsService = new SettingsService();
        }

        /// <summary>
        /// バッチ処理を実行します。
        /// </summary>
        public void Execute() {
            var settings = this.settingsService.Load();
            var entries = this.entryService.Load()
                .Where(x => settings.LastUpdated == null || settings.LastUpdated <= x.Date)
                .OrderBy(x => x.Date);
            foreach (var entry in entries) {
                this.tweetService.Tweet(entry);
            }
            settings.LastUpdated = DateTime.Now;
            this.settingsService.Save(settings);
        }

    }

}
