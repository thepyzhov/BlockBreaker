using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    int breakableBlocks;

    public void CountBreakableBlocks() {
        breakableBlocks += 1;
        Debug.Log("Breakable blocks: " + breakableBlocks);
    }
}
