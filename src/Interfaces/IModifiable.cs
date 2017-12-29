using UnityEngine;

namespace DH.ModifierSystem
{
	public interface IModifiable
	{
		void OnModificationApplied (IModifier modifier);
		void OnModificationReverted (IModifier modifier);
	}
}