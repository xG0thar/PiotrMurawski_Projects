

public class BasicShopManager : IShopManager
{
    private Builder _builder;

    public void InjectDependencies(Builder builder)
    {
        _builder = builder;
    }

    public void SetNewManager(IShopManager newManager)
    {
        throw new System.NotImplementedException();
    }

    public void SetUpgrader(IUpgrader upgrader)
    {
        throw new System.NotImplementedException();
    }

    public void ShopAction(int index)
    {
        _builder.ChooseTowerToBuild(index);
        _builder.PrepareToBuild();
    }


}
