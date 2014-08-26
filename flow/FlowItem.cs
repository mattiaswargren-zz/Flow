// Copyright (c) 2014 Mattias Wargren

using System;

namespace flow
{
	public class FlowItem : IFlowItem
	{

		public Action OnBegin;
		public Action OnUpdate;
		public Action OnEnd;
		public Func<bool> OnCheckComplete = () => true;

		public void Begin()
		{
			if (OnBegin != null)
			{
				OnBegin.Invoke();
			}
		}

		public void Update()
		{
			if (OnUpdate != null)
			{
				OnUpdate.Invoke();
			}
		}

		public void End()
		{
			if (OnEnd != null)
			{
				OnEnd.Invoke();
			}
		}

		public bool CheckComplete()
		{
			return OnCheckComplete();
		}

	}

}

