namespace DH.ModifierSystem
{
	public interface IAttachable
	{
		IAttached[] GetAllAttacheds();

		void Attach (IAttached attached);
		void Detach (IAttached attached);
	}
}