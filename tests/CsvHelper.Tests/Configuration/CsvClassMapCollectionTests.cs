﻿// Copyright 2009-2022 Josh Close
// This file is a part of CsvHelper and is dual licensed under MS-PL and Apache 2.0.
// See LICENSE.txt for details or visit http://www.opensource.org/licenses/ms-pl.html for MS-PL and http://opensource.org/licenses/Apache-2.0 for Apache 2.0.
// https://github.com/JoshClose/CsvHelper
using CsvHelper.Configuration;
using Xunit;
using System.Globalization;

namespace CsvHelper.Tests.Configuration
{
	
	public class CsvClassMapCollectionTests
	{
		[Fact]
		public void GetChildMapWhenParentIsMappedBeforeIt()
		{
			var parentMap = new ParentMap();
			var childMap = new ChildMap();
			var context = new CsvContext(new CsvConfiguration(CultureInfo.InvariantCulture));
			var c = new ClassMapCollection(context);
			c.Add(parentMap);
			c.Add(childMap);

			var map = c[typeof(Child)];
			Assert.Equal(childMap, map);
		}

		private class Parent { }

		private class Child : Parent { }

		private sealed class ParentMap : ClassMap<Parent> { }

		private sealed class ChildMap : ClassMap<Child> { }
	}
}
