﻿using System.IO;
using System.Linq;
using System.Net;
using Itinero.LocalGeo;
using Itinero.LocalGeo.IO;
using NUnit.Framework;

namespace Itinero.Test.LocalGeo.Operations
{
    [TestFixture]
    public class PolygonIntersectionTest
    {
        [Test]
        public void TestSimple()
        {
            var a = "points.polygon1.geojson".LoadTestStream().LoadTestPolygon();
            Assert.IsTrue(a.IsClockwise());
            Assert.IsTrue(a.ExteriorRing[0].Equals(a.ExteriorRing.Last()));
            var b = "points.polygon2.geojson".LoadTestStream().LoadTestPolygon();
            var c = a.IntersectionsWith(b);
            File.WriteAllText("/home/pietervdvn/Desktop/output.geojson", c.ToGeoJson());
        }
    }
}