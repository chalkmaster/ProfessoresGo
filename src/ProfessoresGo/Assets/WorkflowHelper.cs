using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets
{
    public class gState
    {
        public string Last { get; set; }
        public DateTime StartedAt { get; set; }
    }
    public static class WorkflowHelper
    {
        public static GameObject Camera { get; set; }
        public static gState State { get; set; }
        public static List<string> Read { get; set; }
        public static bool ShowCamera { get; set; }
        public static GameObject CamButtons { get; set; }

        public static void Initialize()
        {
            Read = Read ?? new List<string>();
            State = State ?? new gState
            {
                StartedAt = DateTime.Now,
                Last = "",
            };
        }
    }
}
