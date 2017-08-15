using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets
{
    public class gState
    {
        public string Last { get; set; }
        public DateTime StartedAt { get; set; }
        public int elapsedTime { get; set; }
    }
    public static class WorkflowHelper
    {
        public static GameObject Camera { get; set; }
        public static gState State { get; set; }
        public static List<string> Read { get; set; }
        public static bool ShowCamera { get; set; }
        public static GameObject CamButtons { get; set; }
        public static DateTime lastTimeUpdate { get; set; }
        public static GameObject Timer { get; internal set; }
        public static GameObject Pistas { get; internal set; }

        public static void Initialize()
        {            
            Read = Read ?? new List<string>();
            State = State ?? new gState
            {
                StartedAt = DateTime.Now,
                Last = "",
                elapsedTime = 0,
            };
        }

        internal static void UpdateTime()
        {
            var now = DateTime.Now;
            if (now.Subtract(lastTimeUpdate).TotalSeconds > 1)
            {
                Timer.GetComponent<Text>().text = new DateTime(0).AddSeconds(State.elapsedTime++).ToString("HH:mm:ss");
                lastTimeUpdate = now;
            }
        }
    }
}
