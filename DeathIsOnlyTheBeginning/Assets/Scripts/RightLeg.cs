using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightLeg : Leg
{
    public override void GrabLeg()
    {
        // TODO why do we have separate classes for right and left AND the tag?
        player.AddToAttachments(this.tag, leg);
        Debug.Log("this.tag = " + this.tag);
        if (tag == "RightLeg")
            player.SpawnRightLeg();
        
    }
}
