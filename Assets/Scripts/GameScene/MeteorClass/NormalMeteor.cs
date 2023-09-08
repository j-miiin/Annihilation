using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalMeteor : Meteor
{
    public NormalMeteor() : base("NM", 3)
    {

    }

    private void Awake()
    {
        spriteRenderer.color = Color.gray;
    }
}
