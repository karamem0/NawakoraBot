using NawakoraBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NawakoraBot.Services {

    /// <summary>
    /// コラムを取得するサービスを表します。
    /// </summary>
    public class EntryService {

        /// <summary>
        /// フィードの URL を表します。
        /// </summary>
        private static readonly string FeedUrl = "http://el.jibun.atmarkit.co.jp/ahf/index.rdf";

        /// <summary>
        /// <see cref="NawakoraBot.Services.EntryService"/> クラスの新しいインスタンスを初期化します。
        /// </summary>
        public EntryService() { }

        /// <summary>
        /// コラムの一覧を読み込みます。
        /// </summary>
        /// <returns><see cref="NawakoraBot.Models.Entry"/> の配列。</returns>
        public Entry[] Load() {
            var ns = XNamespace.Get("http://purl.org/rss/1.0/");
            var dc = XNamespace.Get("http://purl.org/dc/elements/1.1/");
            return XDocument.Load(FeedUrl)
                .Descendants(ns + "item")
                .Select(item => new Entry() {
                    Title = (string)item.Element(ns + "title"),
                    Url = (string)item.Element(ns + "link"),
                    Description = (string)item.Element(ns + "description"),
                    Date = (DateTime)item.Element(dc + "date"),
                }).ToArray();
        }

    }

}
