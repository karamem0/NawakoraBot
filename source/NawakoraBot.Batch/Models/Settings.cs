using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawakoraBot.Models {

    /// <summary>
    /// 設定情報を格納します。
    /// </summary>
    public class Settings {

        /// <summary>
        /// 最終更新時刻を取得または設定します。
        /// </summary>
        public DateTime? LastUpdated { get; set; }

        /// <summary>
        /// <see cref="NawakoraBot.Models.Settings"/> クラスの新しいインスタンスを初期化します。
        /// </summary>
        public Settings() { }

        /// <summary>
        /// 現在のインスタンスの文字列表現を返します。
        /// </summary>
        /// <returns>現在のインスタンスの文字列表現を示す <see cref="System.String"/>。</returns>
        public override string ToString() {
            var serializer = new JsonSerializer();
            using (var stream = new MemoryStream())
            using (var writer = new StreamWriter(stream)) {
                serializer.Serialize(writer, this);
                writer.Flush();
                stream.Position = 0;
                using (var reader = new StreamReader(stream)) {
                    return reader.ReadToEnd();
                }
            }
        }

    }

}
