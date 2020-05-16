using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    int breakableBlocks;

    // Cached reference
    SceneLoader sceneLoader;

    void Start() {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void CountBlocks() {
        breakableBlocks += 1;
    }

    public void BlockDestroyed() {
        breakableBlocks -= 1;

        if (breakableBlocks <= 0) {
            sceneLoader.LoadNextScene();
        }
    }
}
