using NawakoraBot.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawakoraBot.Services {

    /// <summary>
    /// 設定情報を取得または保存するサービスを表します。
    /// </summary>
    public class SettingsService {

        /// <summary>
        /// ファイル名を表します。
        /// </summary>
        private static readonly string FileName = @"App_Data\settings.json";

        /// <summary>
        /// <see cref="NawakoraBot.Services.SettingsService"/> クラスの新しいインスタンスを初期化します。
        /// </summary>
        public SettingsService() { }

        /// <summary>
        /// 設定情報を読み込みます。
        /// </summary>
        /// <returns><see cref="NawakoraBot.Models.Settings"/>。</returns>
        public Settings Load() {
            var path = Path.Combine(Environment.GetEnvironmentVariable("WEBROOT_PATH"), FileName);
            if (File.Exists(path) == true) {
                var serializer = new JsonSerializer();
                using (var stream = File.Open(path, FileMode.Open, FileAccess.Read))
                using (var reader = new StreamReader(stream)) {
                    return serializer.Deserialize<Settings>(new JsonTextReader(reader));
                }
            }
            return new Settings();
        }

        /// <summary>
        /// 指定した設定情報を保存します。
        /// </summary>
        /// <param name="value"><see cref="NawakoraBot.Models.Settings"/>。</param>
        public void Save(Settings value) {
            var path = Path.Combine(Environment.GetEnvironmentVariable("WEBROOT_PATH"), FileName);
            var serializer = new JsonSerializer();
            using (var stream = File.Open(path, FileMode.Create, FileAccess.Write))
            using (var writer = new StreamWriter(stream)) {
                serializer.Serialize(writer, value);
            }
        }

    }

}
