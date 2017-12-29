namespace DH.ModifierSystem
{
	public interface IAttached
	{
		IAttachable Owner { get; }

		void OnAttached (IAttachable attachable);
		void OnDetached (IAttachable attachable);
	}
}