using UnityEngine;
using System.Collections;

public class SettingsData<T> : ScriptableObject where T : ScriptableObject
{
	private static T settings;
	public static T Settings
	{
		get
		{
			if(settings == null)
			{
				settings = (T)Resources.Load (string.Format ("Settings/{0}", typeof(T).Name));
			}
			
			return settings;
		}
	}

	public static void LoadFromResources(string path)
	{
		settings = (T)Resources.Load (path);
	}

	public static void LodFromInstance(T instance)
	{
		settings = instance;
	}
}

