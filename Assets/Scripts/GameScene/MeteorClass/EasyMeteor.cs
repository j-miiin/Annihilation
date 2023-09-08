using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyMeteor : Meteor
{
    public EasyMeteor() : base("EM", 1)
    {
    }

    private void Awake()
    {
        spriteRenderer.color = Color.white;
    }
}
