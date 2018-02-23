using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace DH.ModifierSystem
{
    public class ModifierList : List<IModifier> {}
    public class ModifierMap : Dictionary<System.Type, ModifierList> {}
    
    public class ActiveModifications
    {
        private Dictionary<IModifiable, ModifierMap> activeModifications = new Dictionary<IModifiable, ModifierMap>();

        public void Add(IModifiable modifiable, IModifier modifier)
        {
            ModifierMap modifiers = FindOrCreateModifierDictionary(modifiable);
            List<IModifier> modifierList = FindOrCreateModifierList(modifiers, modifier.ModifierType);
            modifierList.Add(modifier);
        }

        public void Remove(IModifiable modifiable, IModifier modifier)
        {
            ModifierMap modifiers = FindOrCreateModifierDictionary(modifiable);
            List<IModifier> modifierList = FindOrCreateModifierList(modifiers, modifier.ModifierType);
            modifierList.Remove(modifier);
        }

        public void RemoveAll(IModifiable modifiable)
        {
            ModifierMap modifiers = FindOrCreateModifierDictionary(modifiable);
            modifiers.Clear();
        }

        public IModifier[] GetModifiersOn(IModifiable modifiable)
        {
            ModifierMap modifiers = FindOrCreateModifierDictionary(modifiable);
            List<IModifier> modifierList = new List<IModifier>();
            foreach (var modifierTypeList in modifiers)
                modifierList.AddRange(modifierTypeList.Value);

            return modifierList.ToArray();
        }

        public ModifierType[] GetModifiersOn<ModifierType>(IModifiable modifiable) where ModifierType : IModifier
        {
            ModifierMap modifiers = FindOrCreateModifierDictionary(modifiable);
            List<ModifierType> modifierList = FindOrCreateModifierList(modifiers, typeof(ModifierType)) as List<ModifierType>;
            return modifierList.ToArray();
        }

        ModifierMap FindOrCreateModifierDictionary(IModifiable modifiable)
        {
            ModifierMap modifiers;

            if (!activeModifications.TryGetValue(modifiable, out modifiers))
            {
                modifiers = new ModifierMap();
                activeModifications.Add(modifiable, modifiers);
            }

            return modifiers;
        }

        List<IModifier> FindOrCreateModifierList(ModifierMap modifiers, System.Type modifierType)
        {
            ModifierList modifierList;

            if(!modifiers.TryGetValue(modifierType, out modifierList))
            {
                modifierList = new ModifierList();
                modifiers.Add(modifierType, modifierList);
            }

            return modifierList;
        }
    }
}
