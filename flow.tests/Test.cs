// Copyright (c) 2014 Mattias Wargren

using NUnit.Framework;
using System;

namespace flow.tests
{
	[TestFixture()]
	public class Test
	{
		[Test()]
		public void TestCreation()
		{
			var flow = new Flow();

			Assert.AreEqual(0, flow.size);
			Assert.AreEqual(true, flow.isCompleted);
		}

		[Test()]
		public void TestAddItems()
		{
			var flow = new Flow();
			flow.Add(new FlowItem());
			flow.Add(new FlowItem());
			flow.Add(new FlowItem());

			Assert.AreEqual(3, flow.size);
			Assert.AreEqual(false, flow.isCompleted);
		}

		[Test()]
		public void TestUpdateAndCompleteSingleItem()
		{
			var flow = new Flow();
			flow.Add(new FlowItem());

			Assert.AreEqual(1, flow.size);

			flow.Update();

			Assert.AreEqual(0, flow.size);
			Assert.AreEqual(true, flow.isCompleted);
		}

		[Test()]
		public void TestUpdateAndCompleteMultipleItems()
		{
			var flow = new Flow();
			flow.Add(new FlowItem());
			flow.Add(new FlowItem());
			flow.Add(new FlowItem());

			Assert.AreEqual(3, flow.size);

			flow.Update();
			flow.Update();

			Assert.AreEqual(1, flow.size);

			flow.Update();

			Assert.AreEqual(0, flow.size);
			Assert.AreEqual(true, flow.isCompleted);
		}

		[Test()]
		public void TestActions()
		{
			var output = 0;
			var flow = new Flow();

			flow.AddAction(() => { output++; });
			flow.AddAction(() => { output++; });

			flow.Update();
			flow.Update();

			Assert.AreEqual(2, output);
			Assert.AreEqual(0, flow.size);
			Assert.AreEqual(true, flow.isCompleted);
		}

		[Test()]
		public void TestCustomItem()
		{
			var output = "";
			var flow = new Flow();

			flow.Add(new FlowItem(){
				OnBegin = () => output += "OnBegin",
				OnUpdate = () => output += ">OnUpdate",
				OnEnd = () => output += ">OnEnd"
			});

			flow.Update();

			Assert.AreEqual("OnBegin>OnUpdate>OnEnd", output);
		}
	}
}

