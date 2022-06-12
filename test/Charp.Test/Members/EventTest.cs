﻿using Charp.Core.Models;
using Charp.Core.Models.Members;
using Charp.Test.Data.Classes;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Charp.Test.Members
{
    internal class EventTest : BaseTest
    {
        [Test(Description = "Ensures the <IsPublic> member of the <EventModel> type is set correctly.")]
        public void IsPublicSetCorrectly()
        {
            Assert.AreEqual(true, GetEvent(nameof(Boat), nameof(Boat.Docked)).IsPublic);
            Assert.AreEqual(true, GetEvent(nameof(Boat), nameof(Boat.PublicEvent)).IsPublic);
            Assert.AreEqual(true, GetEvent(nameof(Boat), nameof(Boat.StaticEvent)).IsPublic);
            Assert.AreEqual(true, GetEvent(nameof(Boat), nameof(Boat.UnDocked)).IsPublic);
            Assert.AreEqual(true, GetEvent(nameof(Boat), nameof(Boat.VirtualEvent)).IsPublic);
            // No private events are currently exposed
        }

        [Test(Description = "Ensures the <IsVirtual> member of the <EventModel> type is set correctly.")]
        public void IsVirtualSetCorrectly()
        {
            Assert.AreEqual(false, GetEvent(nameof(Boat), nameof(Boat.Docked)).IsVirtual);
            Assert.AreEqual(false, GetEvent(nameof(Boat), nameof(Boat.PublicEvent)).IsVirtual);
            Assert.AreEqual(false, GetEvent(nameof(Boat), nameof(Boat.StaticEvent)).IsVirtual);
            Assert.AreEqual(true, GetEvent(nameof(Boat), nameof(Boat.UnDocked)).IsVirtual);
            Assert.AreEqual(true, GetEvent(nameof(Boat), nameof(Boat.VirtualEvent)).IsVirtual);
            // Abstract events are also virtual behind the scenes it seems, but to make the docs
            // less confusing; we'll only except one or the other...
        }

        [Test(Description = "Ensures the <IsAbstract> member of the <EventModel> type is set correctly.")]
        public void IsAbstractSetCorrectly()
        {
            Assert.AreEqual(true, GetEvent(nameof(Boat), nameof(Boat.Docked)).IsAbstract);
            Assert.AreEqual(false, GetEvent(nameof(Boat), nameof(Boat.PublicEvent)).IsAbstract);
            Assert.AreEqual(false, GetEvent(nameof(Boat), nameof(Boat.StaticEvent)).IsAbstract);
            Assert.AreEqual(false, GetEvent(nameof(Boat), nameof(Boat.UnDocked)).IsAbstract);
            Assert.AreEqual(false, GetEvent(nameof(Boat), nameof(Boat.VirtualEvent)).IsAbstract);
        }

        [Test(Description = "Ensures the <IsAbstract> member of the <EventModel> type is set correctly.")]
        public void IsStaticSetCorrectly()
        {
            Assert.AreEqual(false, GetEvent(nameof(Boat), nameof(Boat.Docked)).IsStatic);
            Assert.AreEqual(false, GetEvent(nameof(Boat), nameof(Boat.PublicEvent)).IsStatic);
            Assert.AreEqual(true, GetEvent(nameof(Boat), nameof(Boat.StaticEvent)).IsStatic);
            Assert.AreEqual(false, GetEvent(nameof(Boat), nameof(Boat.UnDocked)).IsStatic);
            Assert.AreEqual(false, GetEvent(nameof(Boat), nameof(Boat.VirtualEvent)).IsStatic);
        }

        public EventModel GetEvent(string className, string eventName)
            => (Docs.Models.Root
                .Namespaces["Test"]
                .Namespaces["Data"]
                .Namespaces["Classes"]
                .Types[className]
                .Member as INestable)
            .Events
            .Single(e => e.Name == eventName);
    }
}