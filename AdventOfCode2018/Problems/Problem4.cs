namespace AdventOfCode2018.Problems
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Problem4 : Problem
    {
        public Problem4() : base(4)
        {
        }

        public static List<Log> ParseInput(IList<string> input)
        {
            var output = input.Select(message => new Log(message)).ToList();
            output.Sort();

            return output;
        }

        public static SleepLog ReadLogs(IList<Log> sortedLogs)
        {
            var sleepLog = new SleepLog();

            var currentId = -1;
            var fellAsleep = -1;

            foreach (var log in sortedLogs)
            {
                if (log.Message.Contains("begins shift"))
                {
                    currentId = Convert.ToInt32(Regex.Match(log.Message, @"#(\d+) ").Groups[1].Value);
                    continue;
                }

                if (log.Message.Contains("falls asleep"))
                {
                    fellAsleep = log.TimeStamp.Minute;
                    continue;
                }

                if (log.Message.Contains("wakes up"))
                {
                    var wokeUp = log.TimeStamp.Minute;

                    if (!sleepLog.MinuteAsleep.ContainsKey(currentId))
                    {
                        sleepLog.MinuteAsleep.Add(currentId, new Dictionary<int, int>());
                    }

                    for (var t = fellAsleep; t < wokeUp; t++)
                    {
                        if (!sleepLog.MinuteAsleep[currentId].ContainsKey(t))
                        {
                            sleepLog.MinuteAsleep[currentId].Add(t, 0);
                        }

                        sleepLog.MinuteAsleep[currentId][t]++;
                    }

                    if (!sleepLog.TotalSleep.ContainsKey(currentId))
                    {
                        sleepLog.TotalSleep.Add(currentId, 0);
                    }

                    sleepLog.TotalSleep[currentId] += wokeUp - fellAsleep;
                }
            }

            return sleepLog;
        }

        public static int Strategy1(SleepLog sleepLog)
        {
            var biggestSleeper = sleepLog.TotalSleep.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
            var mostSleptMinute = sleepLog.MinuteAsleep[biggestSleeper].Aggregate((l, r) => l.Value > r.Value ? l : r).Key;

            return biggestSleeper * mostSleptMinute;
        }

        public static int Strategy2(SleepLog sleepLog)
        {
            // (Guard ID : Most frequent minute
            var guardMax = new Dictionary<int, int>();

            foreach (var guard in sleepLog.MinuteAsleep.Keys)
            {
                var mostFrequentMinute = sleepLog.MinuteAsleep[guard].Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
                guardMax.Add(guard, mostFrequentMinute);
            }

            var winner = guardMax.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;

            return winner * sleepLog.MinuteAsleep[winner].Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
            // Too low : 4424
        }

        public override string Answer()
        {
            var sortedLogs = ParseInput(Input);
            var sleepLog = ReadLogs(sortedLogs);
            return $"Strategy 1 gives: {Strategy1(sleepLog)}.\nStrategy 2 gives: {Strategy2(sleepLog)}.";
        }
    }

    public class Log : IComparable
    {
        public DateTime TimeStamp { get; }

        public string Message { get; }

        public Log(string input)
        {
            var matches = Regex.Match(input, @"\[(\d\d\d\d)-(\d\d)-(\d\d) (\d\d):(\d\d)] (.*)").Groups;
            TimeStamp = new DateTime(
                Convert.ToInt32(matches[1].Value),  // Year
                Convert.ToInt32(matches[2].Value),  // Month
                Convert.ToInt32(matches[3].Value),  // Day
                Convert.ToInt32(matches[4].Value),  // Hour
                Convert.ToInt32(matches[5].Value),  // Minute
                0                                   // Second
                );

            Message = matches[6].Value;
        }

        public override string ToString()
        {
            return $"{TimeStamp} | {Message}";
        }

        public override bool Equals(object obj)
        {
            var other = (Log)obj;
            return other.TimeStamp.Equals(TimeStamp) && other.Message.Equals(Message);
        }

        public int CompareTo(object obj)
        {
            var other = (Log) obj;
            return TimeStamp.CompareTo(other.TimeStamp);
        }
    }

    public class SleepLog
    {
        /// <summary>
        /// (Guard ID : Total Minutes Slept)
        /// </summary>
        public Dictionary<int, int> TotalSleep { get; }

        /// <summary>
        /// (Guard ID : (Minute : TimesSlept))
        /// </summary>
        public Dictionary<int, Dictionary<int, int>> MinuteAsleep { get; }

        public SleepLog()
        {
            TotalSleep = new Dictionary<int, int>();
            MinuteAsleep = new Dictionary<int, Dictionary<int, int>>();
        }
    }
}
