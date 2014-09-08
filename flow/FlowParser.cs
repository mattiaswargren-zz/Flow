// Copyright (c) 2014 Mattias Wargren
using System;

namespace flow
{
	public class FlowParser
	{

		Flow flowInstance;

		public FlowParser(Flow pFlow)
		{
			flowInstance = pFlow;
		}

		public void Map(string pMatch, Action<string> pAction)
		{

		}

		public void Run(string pOutput)
		{
			var l = pOutput.Split('|');


		}
	}

}

