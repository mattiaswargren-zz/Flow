// Copyright (c) 2014 Mattias Wargren

using System.Collections.Generic;
using System;

namespace flow
{
	public class Flow
	{
		List<IFlowItem> list;

		public int size { get { return list.Count; } }

		private IFlowItem current;

		public bool isCompleted { get { return current == null && list.Count == 0; } }

		public Flow()
		{
			list = new List<IFlowItem>();
		}

		public void Add(IFlowItem pItem)
		{
			list.Add(pItem);
		}

		public void AddAction(Action pAction)
		{
			Add(new FlowAction(pAction));
		}

		public void Update()
		{
			if (current == null && size > 0)
			{
				// select first in list
				current = list[0];

				// remove from list
				list.RemoveAt(0);

				// begin current
				current.Begin();
			}

			if (current != null)
			{
				// update current
				current.Update();

				// check complete
				if (current.CheckComplete())
				{
					// end current
					current.End();

					// ?
					current = null;
				}
			}
		}
	}
}

