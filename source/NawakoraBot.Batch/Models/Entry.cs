using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawakoraBot.Models {

    /// <summary>
    /// コラムを格納します。
    /// </summary>
    public class Entry {

        /// <summary>
        /// タイトルを取得または設定します。
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// URL を取得または設定します。
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 説明を取得または設定します。
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 日付を取得または設定します。
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// <see cref="NawakoraBot.Models.Entry"/> クラスの新しいインスタンスを初期化します。
        /// </summary>
        public Entry() { }

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
