﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prototype
{
    class ActivityVote
    {
        private Dictionary<int, IList<string>> vote1Candidates;
        private List<string> vote2Candidates;
        private readonly int totalCount = Main.GetInstance().host.data.totalEmojis;


        public ActivityVote ()
        {
            vote1Candidates = new Dictionary<int, IList<string>>();
            vote2Candidates = new List<string>();
        }

        public Dictionary<int, IList<string>> calcVote1Candidates(List<Emoji> emojis, Dictionary<int, int> emojiResults)
        {
            //for getting a sorted list out of emojiResults
            //positive, neutral ja negative impact
            Dictionary<int, double> ranking = new Dictionary<int, double>();
            Dictionary<int, double> sortedRanking = new Dictionary<int, double>();
            double percentage = 0.0;
            double tolerance = 0.0;
            double threat = 0.0;

            foreach (KeyValuePair<int, int> answer in emojiResults)
            {
                percentage = (double)answer.Value / totalCount;
                
                if (emojis[answer.Key].Impact == "negative")
                {
                    tolerance = 0;
                }
                if (emojis[answer.Key].Impact == "neutral")
                {
                    tolerance = 0.25;
                }
                if (emojis[answer.Key].Impact == "positive")
                {
                    tolerance = 0.5;
                }

                threat = percentage - tolerance;
                Console.WriteLine("key: {0}, percentage: {1}, threat: {2}", answer.Key, percentage, threat);


                ranking.Add(answer.Key, threat);
            }

            foreach (KeyValuePair<int, double> item in ranking.OrderByDescending(key => key.Value))
            {
                sortedRanking.Add(item.Key, item.Value);
            }
            
            if(sortedRanking.Values.ElementAt(0) > 0)
            {
                foreach (KeyValuePair<int, double> item in sortedRanking)
                {
                    if (item.Value > 0)
                    {
                        vote1Candidates.Add(item.Key, emojis[item.Key].activities);
                    }
                }
            }
            if(sortedRanking.Values.ElementAt(0) <= 0)
            {
                for (int i = 0; i < 2; i++)
                {
                    vote1Candidates.Add(sortedRanking.Keys.ElementAt(i), emojis[sortedRanking.Keys.ElementAt(i)].activities);
                }
            }
            return vote1Candidates;
        }

        public List<string> calcVote2Candidates(Dictionary<string, int> vote1Results)
        {
            //for getting a sorted list out of vote1Results
            Dictionary<string, int> sorted = new Dictionary<string, int>();
            foreach (KeyValuePair<string, int> item in vote1Results.OrderByDescending(key => key.Value))
            {
                Console.WriteLine("key: {0}, value: {1}", item.Key, item.Value);
                sorted.Add(item.Key, item.Value);
            }
            
            //adding each sorted key (previously voted activities) to vote2Candidates list
            foreach (string key in sorted.Keys)
            {
                vote2Candidates.Add(key);
            }
            if(vote2Candidates.Count > 4)
            {
                vote2Candidates = vote2Candidates.GetRange(0, 4);
            }
            return vote2Candidates;
        }

        public override string ToString()
        {
            string value = "";

            
            foreach (var item in vote1Candidates)
            {
                value += $"ID: {item.Key.ToString()}, ";
                value += "Activities: [";
                foreach (var activity in item.Value)
                {
                    value += $"{activity} ";
                }
                value += "]";
                value += "\n";
            }
            /*
            foreach(var item in vote2Candidates)
            {
                value += $"Activity: {item}";
                value += "\n";
            }
            */
            return value;
        }
    }
}
