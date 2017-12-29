using UnityEngine;
using System.Collections;

namespace DH.ModifierSystem
{
    public abstract class Modifier<ModifiableType> : IModifier where ModifiableType : IModifiable
    {
        public System.Type ModifierType { get { return GetType(); }}

        public abstract void Modify(ModifiableType modifiable);
        public abstract void Revert(ModifiableType modifiable);
    }
}
