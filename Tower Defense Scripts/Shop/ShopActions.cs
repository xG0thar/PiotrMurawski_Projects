using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopActions : MonoBehaviour
{
    private IShopManager shopManager;
    private IUpgrader upgrader;
    private Builder _builder;

    private void Awake()
    {
        _builder = GetComponentInParent<Builder>();
        shopManager = new BasicShopManager();
        shopManager.InjectDependencies(_builder);
    }

    private void Action(int index)
    {
        shopManager.ShopAction(index);
    }

    public void Button1()
    {
        Action(0);
    }

    public void Button2()
    {
        Action(1);
    }

    public void Button3()
    {
        Action(2);
    }

    public void Button4()
    {
        Action(3);
    }

    public void Deconstruct()
    {
        //deconstructor.deconstruct();
        //shopManager = basic;
        
        //Zacznij dekonstrukcje
    }

}
