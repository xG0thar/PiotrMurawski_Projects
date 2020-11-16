using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShopAnimationController : MonoBehaviour
{
    //Odpowiada za włączanie i wyłączanie animacji sklepu @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    public Animator animator;


    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void OnMouseDown()
    {
        animator.SetBool("ShopOpen", true);
    }

    private void OnMouseEnter()
    {
        animator.SetBool("ShopOpen", true);
    }

    private void OnMouseExit()
    {
        animator.SetBool("ShopOpen", false);
    }

    public void CloseShop()
    {
        animator.SetBool("ShopOpen", false);
    }
}
