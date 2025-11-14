public interface IInventory
{
    public void Initialize();

    public void HandlePickUp(ItemPickUpEvent eventData);

    public void ThrowObj();

    public void DropObj();

    public void StartCooldown();
}
