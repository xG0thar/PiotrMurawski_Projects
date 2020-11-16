using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShopManager
{
    void ShopAction(int index);
    void InjectDependencies(Builder builder);
    void SetNewManager(IShopManager newManager);
    void SetUpgrader(IUpgrader upgrader);
}
