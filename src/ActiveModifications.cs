using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace DH.ModifierSystem
{
    public class ActiveModifications
    {
        private Dictionary<IModifiable, List<IModifier>> activeModifications = new Dictionary<IModifiable, List<IModifier>>();

        public void Add(IModifiable modifiable, IModifier modifier)
        {
            List<IModifier> modifierList = FindOrCreateValue(modifiable);
            modifierList.Add(modifier);
        }

        public void Remove(IModifiable modifiable, IModifier modifier)
        {
            List<IModifier> modifierList = FindOrCreateValue(modifiable);
            modifierList.Remove(modifier);
        }

        public void RemoveAll(IModifiable modifiable)
        {
            List<IModifier> modifierList = FindOrCreateValue(modifiable);
            modifierList.Clear();
        }

        public IModifier[] GetModifiersOn(IModifiable modifiable)
        {
            return FindOrCreateValue(modifiable).ToArray();
        }

        List<IModifier> FindOrCreateValue(IModifiable modifiable)
        {
            List<IModifier> modifierList;

            if (!activeModifications.TryGetValue(modifiable, out modifierList))
            {
                modifierList = new List<IModifier>();
                activeModifications.Add(modifiable, modifierList);
            }

            return modifierList;
        }
    }
}
