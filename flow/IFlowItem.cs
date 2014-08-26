// Copyright (c) 2014 Mattias Wargren


namespace flow
{

	public interface IFlowItem
	{
		void Begin();

		void Update();

		void End();

		bool CheckComplete();
	}

}

