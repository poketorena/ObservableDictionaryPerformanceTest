using CoreTweet;

namespace ObservableDictionaryPerformanceTest.Account
{
    /// <summary>
    /// CoreTweetのトークンの保持、TwitterApiまたはローカルからのデータの取得及び保持を行います。
    /// </summary>
    public class Account
    {
        // パブリックプロパティ

        /// <summary>
        /// CoreTweetのトークン
        /// </summary>
        public Tokens Tokens { get; set; }
    }
}
