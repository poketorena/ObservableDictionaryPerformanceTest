using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using MathNet.Numerics.Random;
using MathNet.Numerics.Statistics;
using ObservableDictionaryPerformanceTest.Collections.Generic;

namespace ObservableDictionaryPerformanceTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var observableCollection4 = new ObservableCollection<Account.Account>();

            var observableDictionary4 = new ObservableDictionary<long, Account.Account>();

            var observableCollection100 = new ObservableCollection<Account.Account>();

            var observableDictionary100 = new ObservableDictionary<long, Account.Account>();

            #region コレクションにアカウントを追加（4個）

            for (var i = 0; i < 4; i++)
            {
                observableCollection4.Add
                    (
                    new Account.Account
                    {
                        Tokens = new CoreTweet.Tokens()
                        {
                            ConsumerKey = "8KGPnPgfRRWZtHMpSEDniPRak",
                            ConsumerSecret = "VF43CmAGn4gAVCYBf5P7i4yLVaJ1n6t8Q5TLCAcOq46yuOMkoR",
                            AccessToken = "2903486595-Qd36h37NhMCQnVfzijXhDk9W5GirlteqkbYleFK",
                            AccessTokenSecret = "660SAE0A6I2EY6UfSDjpk2fU5wEwOKt5KZfiSrufT8dDh",
                            UserId = 1536283409 + (i * 2357),
                            ScreenName = "Tm9PDxK4"
                        }
                    });

                observableDictionary4.Add
                    (
                    1536283409 + (i * 2357),
                    new Account.Account
                    {
                        Tokens = new CoreTweet.Tokens()
                        {
                            ConsumerKey = "8KGPnPgfRRWZtHMpSEDniPRak",
                            ConsumerSecret = "VF43CmAGn4gAVCYBf5P7i4yLVaJ1n6t8Q5TLCAcOq46yuOMkoR",
                            AccessToken = "2903486595-Qd36h37NhMCQnVfzijXhDk9W5GirlteqkbYleFK",
                            AccessTokenSecret = "660SAE0A6I2EY6UfSDjpk2fU5wEwOKt5KZfiSrufT8dDh",
                            UserId = 1536283409 + (i * 2357),
                            ScreenName = "Tm9PDxK4"
                        }
                    });
            }

            #endregion

            #region コレクションにアカウントを追加（100個）

            for (var i = 0; i < 100; i++)
            {
                observableCollection100.Add
                    (
                    new Account.Account
                    {
                        Tokens = new CoreTweet.Tokens()
                        {
                            ConsumerKey = "8KGPnPgfRRWZtHMpSEDniPRak",
                            ConsumerSecret = "VF43CmAGn4gAVCYBf5P7i4yLVaJ1n6t8Q5TLCAcOq46yuOMkoR",
                            AccessToken = "2903486595-Qd36h37NhMCQnVfzijXhDk9W5GirlteqkbYleFK",
                            AccessTokenSecret = "660SAE0A6I2EY6UfSDjpk2fU5wEwOKt5KZfiSrufT8dDh",
                            UserId = 1536283409 + (i * 2357),
                            ScreenName = "Tm9PDxK4"
                        }
                    });

                observableDictionary100.Add
                    (
                    1536283409 + (i * 2357),
                    new Account.Account
                    {
                        Tokens = new CoreTweet.Tokens()
                        {
                            ConsumerKey = "8KGPnPgfRRWZtHMpSEDniPRak",
                            ConsumerSecret = "VF43CmAGn4gAVCYBf5P7i4yLVaJ1n6t8Q5TLCAcOq46yuOMkoR",
                            AccessToken = "2903486595-Qd36h37NhMCQnVfzijXhDk9W5GirlteqkbYleFK",
                            AccessTokenSecret = "660SAE0A6I2EY6UfSDjpk2fU5wEwOKt5KZfiSrufT8dDh",
                            UserId = 1536283409 + (i * 2357),
                            ScreenName = "Tm9PDxK4"
                        }
                    });
            }

            #endregion

            #region アカウント数4で先頭のアカウントを取り出す速度を計る（10000回計る）

            // ObservableCollection

            var observableCollection4TimeSpanFirstElements = new List<TimeSpan>();

            for (var i = 0; i < 10000; i++)
            {
                var stopwatch = new Stopwatch();

                GC.Collect();

                stopwatch.Start();

                var account = observableCollection4.Single(ac => ac.Tokens.UserId == 1536283409);

                Console.WriteLine(account.Tokens.ConsumerKey);
                Console.WriteLine(account.Tokens.ConsumerSecret);
                Console.WriteLine(account.Tokens.AccessToken);
                Console.WriteLine(account.Tokens.AccessTokenSecret);
                Console.WriteLine(account.Tokens.UserId);
                Console.WriteLine(account.Tokens.ScreenName);

                stopwatch.Stop();

                observableCollection4TimeSpanFirstElements.Add(stopwatch.Elapsed);
            }

            // ObservableDictionary

            var observableDictionary4TimeSpanFirstElements = new List<TimeSpan>();

            for (var i = 0; i < 10000; i++)
            {
                var stopwatch = new Stopwatch();

                GC.Collect();

                stopwatch.Start();

                var account = observableDictionary4[1536283409];

                Console.WriteLine(account.Tokens.ConsumerKey);
                Console.WriteLine(account.Tokens.ConsumerSecret);
                Console.WriteLine(account.Tokens.AccessToken);
                Console.WriteLine(account.Tokens.AccessTokenSecret);
                Console.WriteLine(account.Tokens.UserId);
                Console.WriteLine(account.Tokens.ScreenName);

                stopwatch.Stop();

                observableDictionary4TimeSpanFirstElements.Add(stopwatch.Elapsed);
            }

            #endregion

            #region アカウント数4で末尾のアカウントを取り出す速度を計る（10000回計る）

            // ObservableCollection

            var observableCollection4TimeSpanLastElements = new List<TimeSpan>();

            for (var i = 0; i < 10000; i++)
            {
                var stopwatch = new Stopwatch();

                GC.Collect();

                stopwatch.Start();

                var account = observableCollection4.Single(ac => ac.Tokens.UserId == 1536290480);

                Console.WriteLine(account.Tokens.ConsumerKey);
                Console.WriteLine(account.Tokens.ConsumerSecret);
                Console.WriteLine(account.Tokens.AccessToken);
                Console.WriteLine(account.Tokens.AccessTokenSecret);
                Console.WriteLine(account.Tokens.UserId);
                Console.WriteLine(account.Tokens.ScreenName);

                stopwatch.Stop();

                observableCollection4TimeSpanLastElements.Add(stopwatch.Elapsed);
            }

            // ObservableDictionary

            var observableDictionary4TimeSpanLastElements = new List<TimeSpan>();

            for (var i = 0; i < 10000; i++)
            {
                var stopwatch = new Stopwatch();

                GC.Collect();

                stopwatch.Start();

                var account = observableDictionary4[1536290480];

                Console.WriteLine(account.Tokens.ConsumerKey);
                Console.WriteLine(account.Tokens.ConsumerSecret);
                Console.WriteLine(account.Tokens.AccessToken);
                Console.WriteLine(account.Tokens.AccessTokenSecret);
                Console.WriteLine(account.Tokens.UserId);
                Console.WriteLine(account.Tokens.ScreenName);

                stopwatch.Stop();

                observableDictionary4TimeSpanLastElements.Add(stopwatch.Elapsed);
            }

            #endregion

            #region アカウント数4でランダムなアカウントを取り出す速度を計る（10000回計る）

            // ObservableCollection

            var observableCollection4TimeSpanRandomElements = new List<TimeSpan>();

            for (var i = 0; i < 10000; i++)
            {
                var stopwatch = new Stopwatch();

                var mersenneTwister = new MersenneTwister();

                var randomValue = mersenneTwister.Next(0, 3);

                long id = 1536283409 + (randomValue * 2357);

                GC.Collect();

                stopwatch.Start();

                var account = observableCollection4.Single(ac => ac.Tokens.UserId == id);

                Console.WriteLine(account.Tokens.ConsumerKey);
                Console.WriteLine(account.Tokens.ConsumerSecret);
                Console.WriteLine(account.Tokens.AccessToken);
                Console.WriteLine(account.Tokens.AccessTokenSecret);
                Console.WriteLine(account.Tokens.UserId);
                Console.WriteLine(account.Tokens.ScreenName);

                stopwatch.Stop();

                observableCollection4TimeSpanRandomElements.Add(stopwatch.Elapsed);
            }

            // ObservableDictionary

            var observableDictionary4TimeSpanRandomElements = new List<TimeSpan>();

            for (var i = 0; i < 10000; i++)
            {
                var stopwatch = new Stopwatch();

                var mersenneTwister = new MersenneTwister();

                var randomValue = mersenneTwister.Next(0, 3);

                long id = 1536283409 + (randomValue * 2357);

                GC.Collect();

                stopwatch.Start();

                var account = observableDictionary4[id];

                Console.WriteLine(account.Tokens.ConsumerKey);
                Console.WriteLine(account.Tokens.ConsumerSecret);
                Console.WriteLine(account.Tokens.AccessToken);
                Console.WriteLine(account.Tokens.AccessTokenSecret);
                Console.WriteLine(account.Tokens.UserId);
                Console.WriteLine(account.Tokens.ScreenName);

                stopwatch.Stop();

                observableDictionary4TimeSpanRandomElements.Add(stopwatch.Elapsed);
            }

            #endregion

            #region アカウント数4で全列挙する速度を計る（10000回計る）

            // ObservableCollection

            var observableCollection4TimeSpanEnumerations = new List<TimeSpan>();

            for (var i = 0; i < 10000; i++)
            {
                var stopwatch = new Stopwatch();

                GC.Collect();

                stopwatch.Start();

                foreach (var account in observableCollection4)
                {
                    Console.WriteLine(account.Tokens.ConsumerKey);
                    Console.WriteLine(account.Tokens.ConsumerSecret);
                    Console.WriteLine(account.Tokens.AccessToken);
                    Console.WriteLine(account.Tokens.AccessTokenSecret);
                    Console.WriteLine(account.Tokens.UserId);
                    Console.WriteLine(account.Tokens.ScreenName);
                }

                stopwatch.Stop();

                observableCollection4TimeSpanEnumerations.Add(stopwatch.Elapsed);
            }

            // ObservableDictionary

            var observableDictionary4TimeSpanEnumerations = new List<TimeSpan>();

            for (var i = 0; i < 10000; i++)
            {
                var stopwatch = new Stopwatch();

                GC.Collect();

                stopwatch.Start();

                foreach (var account in observableDictionary4)
                {
                    Console.WriteLine(account.Value.Tokens.ConsumerKey);
                    Console.WriteLine(account.Value.Tokens.ConsumerSecret);
                    Console.WriteLine(account.Value.Tokens.AccessToken);
                    Console.WriteLine(account.Value.Tokens.AccessTokenSecret);
                    Console.WriteLine(account.Value.Tokens.UserId);
                    Console.WriteLine(account.Value.Tokens.ScreenName);
                }

                stopwatch.Stop();

                observableDictionary4TimeSpanEnumerations.Add(stopwatch.Elapsed);
            }

            #endregion

            #region アカウント数100で先頭のアカウントを取り出す速度を計る（10000回計る）

            // ObservableCollection

            var observableCollection100TimeSpanFirstElements = new List<TimeSpan>();

            for (var i = 0; i < 10000; i++)
            {
                var stopwatch = new Stopwatch();

                GC.Collect();

                stopwatch.Start();

                var account = observableCollection100.Single(ac => ac.Tokens.UserId == 1536283409);

                Console.WriteLine(account.Tokens.ConsumerKey);
                Console.WriteLine(account.Tokens.ConsumerSecret);
                Console.WriteLine(account.Tokens.AccessToken);
                Console.WriteLine(account.Tokens.AccessTokenSecret);
                Console.WriteLine(account.Tokens.UserId);
                Console.WriteLine(account.Tokens.ScreenName);

                stopwatch.Stop();

                observableCollection100TimeSpanFirstElements.Add(stopwatch.Elapsed);
            }

            // ObservableDictionary

            var observableDictionary100TimeSpanFirstElements = new List<TimeSpan>();

            for (var i = 0; i < 10000; i++)
            {
                var stopwatch = new Stopwatch();

                GC.Collect();

                stopwatch.Start();

                var account = observableDictionary100[1536283409];

                Console.WriteLine(account.Tokens.ConsumerKey);
                Console.WriteLine(account.Tokens.ConsumerSecret);
                Console.WriteLine(account.Tokens.AccessToken);
                Console.WriteLine(account.Tokens.AccessTokenSecret);
                Console.WriteLine(account.Tokens.UserId);
                Console.WriteLine(account.Tokens.ScreenName);

                stopwatch.Stop();

                observableDictionary100TimeSpanFirstElements.Add(stopwatch.Elapsed);
            }

            #endregion

            #region アカウント数100で末尾のアカウントを取り出す速度を計る（10000回計る）

            // ObservableCollection

            var observableCollection100TimeSpanLastElements = new List<TimeSpan>();

            for (var i = 0; i < 10000; i++)
            {
                var stopwatch = new Stopwatch();

                GC.Collect();

                stopwatch.Start();

                var account = observableCollection100.Single(ac => ac.Tokens.UserId == 1536516752);

                Console.WriteLine(account.Tokens.ConsumerKey);
                Console.WriteLine(account.Tokens.ConsumerSecret);
                Console.WriteLine(account.Tokens.AccessToken);
                Console.WriteLine(account.Tokens.AccessTokenSecret);
                Console.WriteLine(account.Tokens.UserId);
                Console.WriteLine(account.Tokens.ScreenName);

                stopwatch.Stop();

                observableCollection100TimeSpanLastElements.Add(stopwatch.Elapsed);
            }

            // ObservableDictionary

            var observableDictionary100TimeSpanLastElements = new List<TimeSpan>();

            for (var i = 0; i < 10000; i++)
            {
                var stopwatch = new Stopwatch();

                GC.Collect();

                stopwatch.Start();

                var account = observableDictionary100[1536516752];

                Console.WriteLine(account.Tokens.ConsumerKey);
                Console.WriteLine(account.Tokens.ConsumerSecret);
                Console.WriteLine(account.Tokens.AccessToken);
                Console.WriteLine(account.Tokens.AccessTokenSecret);
                Console.WriteLine(account.Tokens.UserId);
                Console.WriteLine(account.Tokens.ScreenName);

                stopwatch.Stop();

                observableDictionary100TimeSpanLastElements.Add(stopwatch.Elapsed);
            }

            #endregion

            #region アカウント数100でランダムなアカウントを取り出す速度を計る（10000回計る）

            // ObservableCollection

            var observableCollection100TimeSpanRandomElements = new List<TimeSpan>();

            for (var i = 0; i < 10000; i++)
            {
                var stopwatch = new Stopwatch();

                var mersenneTwister = new MersenneTwister();

                var randomValue = mersenneTwister.Next(0, 99);

                long id = 1536283409 + (randomValue * 2357);

                GC.Collect();

                stopwatch.Start();

                var account = observableCollection100.Single(ac => ac.Tokens.UserId == id);

                Console.WriteLine(account.Tokens.ConsumerKey);
                Console.WriteLine(account.Tokens.ConsumerSecret);
                Console.WriteLine(account.Tokens.AccessToken);
                Console.WriteLine(account.Tokens.AccessTokenSecret);
                Console.WriteLine(account.Tokens.UserId);
                Console.WriteLine(account.Tokens.ScreenName);

                stopwatch.Stop();

                observableCollection100TimeSpanRandomElements.Add(stopwatch.Elapsed);
            }

            // ObservableDictionary

            var observableDictionary100TimeSpanRandomElements = new List<TimeSpan>();

            for (var i = 0; i < 10000; i++)
            {
                var stopwatch = new Stopwatch();

                var mersenneTwister = new MersenneTwister();

                var randomValue = mersenneTwister.Next(0, 99);

                long id = 1536283409 + (randomValue * 2357);

                GC.Collect();

                stopwatch.Start();

                var account = observableDictionary100[id];

                Console.WriteLine(account.Tokens.ConsumerKey);
                Console.WriteLine(account.Tokens.ConsumerSecret);
                Console.WriteLine(account.Tokens.AccessToken);
                Console.WriteLine(account.Tokens.AccessTokenSecret);
                Console.WriteLine(account.Tokens.UserId);
                Console.WriteLine(account.Tokens.ScreenName);

                stopwatch.Stop();

                observableDictionary100TimeSpanRandomElements.Add(stopwatch.Elapsed);
            }

            #endregion

            #region アカウント数100で全列挙する速度を計る（10000回計る）

            // ObservableCollection

            var observableCollection100TimeSpanEnumerations = new List<TimeSpan>();

            for (var i = 0; i < 10000; i++)
            {
                var stopwatch = new Stopwatch();

                GC.Collect();

                stopwatch.Start();

                foreach (var account in observableCollection100)
                {
                    Console.WriteLine(account.Tokens.ConsumerKey);
                    Console.WriteLine(account.Tokens.ConsumerSecret);
                    Console.WriteLine(account.Tokens.AccessToken);
                    Console.WriteLine(account.Tokens.AccessTokenSecret);
                    Console.WriteLine(account.Tokens.UserId);
                    Console.WriteLine(account.Tokens.ScreenName);
                }

                stopwatch.Stop();

                observableCollection100TimeSpanEnumerations.Add(stopwatch.Elapsed);
            }

            // ObservableDictionary

            var observableDictionary100TimeSpanEnumerations = new List<TimeSpan>();

            for (var i = 0; i < 10000; i++)
            {
                var stopwatch = new Stopwatch();

                GC.Collect();

                stopwatch.Start();

                foreach (var account in observableDictionary100)
                {
                    Console.WriteLine(account.Value.Tokens.ConsumerKey);
                    Console.WriteLine(account.Value.Tokens.ConsumerSecret);
                    Console.WriteLine(account.Value.Tokens.AccessToken);
                    Console.WriteLine(account.Value.Tokens.AccessTokenSecret);
                    Console.WriteLine(account.Value.Tokens.UserId);
                    Console.WriteLine(account.Value.Tokens.ScreenName);
                }

                stopwatch.Stop();

                observableDictionary100TimeSpanEnumerations.Add(stopwatch.Elapsed);
            }

            #endregion

            Console.WriteLine("アカウント数4で先頭のアカウントを取り出す速度（10000回）");
            Console.WriteLine();

            Console.WriteLine("ObservableCollection");
            PrintStatisticsDatas(observableCollection4TimeSpanFirstElements);

            Console.WriteLine("ObservableDictionary");
            PrintStatisticsDatas(observableDictionary4TimeSpanFirstElements);
            Console.WriteLine();


            Console.WriteLine("アカウント数4で末尾のアカウントを取り出す速度（10000回）");
            Console.WriteLine();

            Console.WriteLine("ObservableCollection");
            PrintStatisticsDatas(observableCollection4TimeSpanLastElements);

            Console.WriteLine("ObservableDictionary");
            PrintStatisticsDatas(observableDictionary4TimeSpanLastElements);
            Console.WriteLine();


            Console.WriteLine("アカウント数4でランダムなアカウントを取り出す速度（10000回）");
            Console.WriteLine();

            Console.WriteLine("ObservableCollection");
            PrintStatisticsDatas(observableCollection4TimeSpanRandomElements);

            Console.WriteLine("ObservableDictionary");
            PrintStatisticsDatas(observableDictionary4TimeSpanRandomElements);
            Console.WriteLine();


            Console.WriteLine("アカウント数4で全列挙する速度（10000回）");
            Console.WriteLine();

            Console.WriteLine("ObservableCollection");
            PrintStatisticsDatas(observableCollection4TimeSpanEnumerations);

            Console.WriteLine("ObservableDictionary");
            PrintStatisticsDatas(observableDictionary4TimeSpanEnumerations);
            Console.WriteLine();


            Console.WriteLine("アカウント数100で先頭のアカウントを取り出す速度（10000回）");
            Console.WriteLine();

            Console.WriteLine("ObservableCollection");
            PrintStatisticsDatas(observableCollection100TimeSpanFirstElements);

            Console.WriteLine("ObservableDictionary");
            PrintStatisticsDatas(observableDictionary100TimeSpanFirstElements);
            Console.WriteLine();


            Console.WriteLine("アカウント数100で末尾のアカウントを取り出す速度（10000回）");
            Console.WriteLine();

            Console.WriteLine("ObservableCollection");
            PrintStatisticsDatas(observableCollection100TimeSpanLastElements);

            Console.WriteLine("ObservableDictionary");
            PrintStatisticsDatas(observableDictionary100TimeSpanLastElements);
            Console.WriteLine();


            Console.WriteLine("アカウント数100でランダムなアカウントを取り出す速度（10000回）");
            Console.WriteLine();

            Console.WriteLine("ObservableCollection");
            PrintStatisticsDatas(observableCollection100TimeSpanRandomElements);

            Console.WriteLine("ObservableDictionary");
            PrintStatisticsDatas(observableDictionary100TimeSpanRandomElements);
            Console.WriteLine();


            Console.WriteLine("アカウント数100で全列挙する速度（10000回）");
            Console.WriteLine();

            Console.WriteLine("ObservableCollection");
            PrintStatisticsDatas(observableCollection100TimeSpanEnumerations);

            Console.WriteLine("ObservableDictionary");
            PrintStatisticsDatas(observableDictionary100TimeSpanEnumerations);
            Console.WriteLine();

            Console.ReadLine();
        }

        /// <summary>
        /// 統計データを標準出力に出力します。
        /// </summary>
        /// <param name="timeSpans"></param>
        private static void PrintStatisticsDatas(List<TimeSpan> timeSpans)
        {
            Console.Write("平均 : ");
            Console.WriteLine($"{timeSpans.Average(timeSpan => timeSpan.TotalMilliseconds)}ms");
            Console.Write("中央値 : ");
            Console.WriteLine($"{timeSpans.Select(timeSpan => timeSpan.TotalMilliseconds).Median()}ms");
            Console.Write("最大 : ");
            Console.WriteLine($"{timeSpans.Max(timeSpan => timeSpan.TotalMilliseconds)}ms");
            Console.Write("最小 : ");
            Console.WriteLine($"{timeSpans.Min(timeSpan => timeSpan.TotalMilliseconds)}ms");
            Console.Write("標準偏差 : ");
            Console.WriteLine($"{timeSpans.Select(timeSpan => timeSpan.TotalMilliseconds).PopulationStandardDeviation()}");
            Console.WriteLine();
        }
    }
}
