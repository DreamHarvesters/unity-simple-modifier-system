using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StateTracker<T, Y> where T : class where Y : class
{
	public class StateData
	{
		public T stateOwner;
		public Y state;
	}

	private List<StateData> stateData = new List<StateData>();

	public void AddState(T stateOwner, Y state)
	{
		StateData data = new StateData ();
		data.stateOwner = stateOwner;
		data.state = state;
		stateData.Add (data);
	}

	public void RemoveState(T stateOwner, Y state)
	{
		StateData data = stateData.Find (d => d.stateOwner == stateOwner && d.state == state);
		stateData.Remove (data);
	}

	public void RemoveAllStatesOf(T stateOwner)
	{
		stateData.RemoveAll (d => d.stateOwner == stateOwner);
	}

	public void Clear()
	{
		stateData.Clear ();
	}

	public StateData[] GetState(T stateOwner)
	{
		return stateData.FindAll (d => d.stateOwner == stateOwner).ToArray ();
	}
}

