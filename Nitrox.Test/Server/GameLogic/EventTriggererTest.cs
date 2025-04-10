﻿using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NitroxServer.GameLogic
{
    [TestClass]
    public class EventTriggererTest
    {
        [TestMethod]
        public void VerifyEventsOrder()
        {
            EventTriggerer eventTriggerer = new(null, 0.0, null);
            List<string> eventsOrder = new() { "Story_AuroraWarning1", "Story_AuroraWarning2", "Story_AuroraWarning3", "Story_AuroraWarning4", "Story_AuroraExplosion" };
            List<string> eventTriggererEvents = new(eventTriggerer.eventTimers.Keys);

            Assert.AreEqual(eventsOrder.Count, eventTriggererEvents.Count, "eventsOrder and eventTriggererEvents are not the same size.");
            for (int i = 0; i < eventsOrder.Count; i++)
            {
                Assert.AreEqual(eventsOrder[i], eventTriggererEvents[i], $"The {i} item of eventsOrder was not equals to eventTriggererEvents");
            }
        }

        [TestMethod]
        public void AuroraExplosionAndWarningTime()
        {
            EventTriggerer eventTriggerer = new(null, 0.0, TimeSpan.FromMinutes(40).TotalMilliseconds);
            Assert.AreEqual(eventTriggerer.eventTimers["Story_AuroraWarning4"].Interval, eventTriggerer.eventTimers["Story_AuroraExplosion"].Interval);
        }

        [TestMethod]
        public void TestTimeSkip()
        {
            EventTriggerer eventTriggerer = new(null, 480.0, null);
            double interval = eventTriggerer.eventTimers["Story_AuroraExplosion"].Interval;
            eventTriggerer.ElapsedTimeMs += TimeSpan.FromMinutes(40).TotalMilliseconds;
            Assert.AreEqual(interval - TimeSpan.FromMinutes(40).TotalMilliseconds, eventTriggerer.eventTimers["Story_AuroraExplosion"].Interval);
            interval = eventTriggerer.eventTimers["Story_AuroraExplosion"].Interval;
            eventTriggerer.ElapsedTimeMs += TimeSpan.FromMinutes(2).TotalMilliseconds;
            Assert.AreEqual(interval - TimeSpan.FromMinutes(2).TotalMilliseconds, eventTriggerer.eventTimers["Story_AuroraExplosion"].Interval);
        }
    }
}
