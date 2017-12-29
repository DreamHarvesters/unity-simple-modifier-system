Abstract Modifier System

This system is the starting point for a modifier system of different projects.

IModifiable: A modifiable interface which all the modifiable classes must derive from
IModifier Modifier class interface. It has ModifierType field which returns the Type of a concrete modifier
Modifier<T>:Base class for a concrete modifier class. T is a concrete modifiable class which inherits from IModifiable
DecoratedModifier<T>: Decorater base class for a more complex modifier type. i.e. AliveModifier<T>

See MobaDemo in the repository for a brief implementation of a simple skill system which can be used in a MOBA game.
