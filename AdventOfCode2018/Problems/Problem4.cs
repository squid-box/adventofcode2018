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

        public static int Strategy1(IList<Log> sortedLogs)
        {
            // (Guard : Total Slept minutes)
            var totalSleepLog = new Dictionary<int, int>();

            // (Guard : (Minute : TimesSlept))
            var minuteSleepLog = new Dictionary<int, Dictionary<int, int>>();

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

                    if (!minuteSleepLog.ContainsKey(currentId))
                    {
                        minuteSleepLog.Add(currentId, new Dictionary<int, int>());
                    }

                    for (var t = fellAsleep; t < wokeUp; t++)
                    {
                        if (!minuteSleepLog[currentId].ContainsKey(t))
                        {
                            minuteSleepLog[currentId].Add(t, 0);
                        }

                        minuteSleepLog[currentId][t]++;
                    }

                    if (!totalSleepLog.ContainsKey(currentId))
                    {
                        totalSleepLog.Add(currentId, 0);
                    }

                    totalSleepLog[currentId] += wokeUp - fellAsleep;
                }
            }

            var biggestSleeper = totalSleepLog.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
            var mostSleptMinute = minuteSleepLog[biggestSleeper].Aggregate((l, r) => l.Value > r.Value ? l : r).Key;


            return biggestSleeper * mostSleptMinute;
        }

        public static int Strategy2(IList<Log> sortedLogs)
        {


            return 0;
        }

        public override string Answer()
        {
            var sortedLogs = ParseInput(Input);
            return $"Strategy 1 gives: {Strategy1(sortedLogs)}";
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
}
