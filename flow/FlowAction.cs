// Copyright (c) 2014 Mattias Wargren

using System;

namespace flow
{
	public class FlowAction : FlowItem
	{
		public FlowAction(Action pAction)
		{
			OnBegin = pAction;
		}
	}

}

