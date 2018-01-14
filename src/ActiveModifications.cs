using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace DH.ModifierSystem
{
    public class ActiveModifications
    {
        private Dictionary<IModifiable, Dictionary<System.Type, List<IModifier>>> activeModifications = new Dictionary<IModifiable, Dictionary<System.Type, List<IModifier>>>();

        public void Add(IModifiable modifiable, IModifier modifier)
        {
            Dictionary<System.Type, List<IModifier>> modifiers = FindOrCreateModifierDictionary(modifiable);
            List<IModifier> modifierList = FindOrCreateModifierList(modifiers, modifier.ModifierType);
            modifierList.Add(modifier);
        }

        public void Remove(IModifiable modifiable, IModifier modifier)
        {
            Dictionary<System.Type, List<IModifier>> modifiers = FindOrCreateModifierDictionary(modifiable);
            List<IModifier> modifierList = FindOrCreateModifierList(modifiers, modifier.ModifierType);
            modifierList.Remove(modifier);
        }

        public void RemoveAll(IModifiable modifiable)
        {
            Dictionary<System.Type, List<IModifier>> modifiers = FindOrCreateModifierDictionary(modifiable);
            modifiers.Clear();
        }

        public IModifier[] GetModifiersOn(IModifiable modifiable)
        {
            Dictionary<System.Type, List<IModifier>> modifiers = FindOrCreateModifierDictionary(modifiable);
            List<IModifier> modifierList = new List<IModifier>();
            foreach (var modifierTypeList in modifiers)
                modifierList.AddRange(modifierTypeList.Value);

            return modifierList.ToArray();
        }

        public ModifierType[] GetModifiersOn<ModifierType>(IModifiable modifiable) where ModifierType : class, IModifier
        {
            Dictionary<System.Type, List<IModifier>> modifiers = FindOrCreateModifierDictionary(modifiable);
            List<ModifierType> modifierList = FindOrCreateModifierList(modifiers, typeof(ModifierType)) as List<ModifierType>;
            return modifierList.ToArray();
        }

        Dictionary<System.Type, List<IModifier>> FindOrCreateModifierDictionary(IModifiable modifiable)
        {
            Dictionary<System.Type, List<IModifier>> modifiers;

            if (!activeModifications.TryGetValue(modifiable, out modifiers))
            {
                modifiers = new Dictionary<System.Type, List<IModifier>>();
                activeModifications.Add(modifiable, modifiers);
            }

            return modifiers;
        }

        List<IModifier> FindOrCreateModifierList(Dictionary<System.Type, List<IModifier>> modifiers, System.Type modifierType)
        {
            List<IModifier> modifierList;

            if(!modifiers.TryGetValue(modifierType, out modifierList))
            {
                modifierList = new List<IModifier>();
                modifiers.Add(modifierType, modifierList);
            }

            return modifierList;
        }
    }
}
