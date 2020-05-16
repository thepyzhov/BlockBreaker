using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // Config parameters
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] int maxHits = 1;

    // Cached reference
    Level level;
    GameSession gameSession;

    // State variables
    int timesHit;

    void Start() {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks() {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable") {
            level.CountBlocks();
        }
        gameSession = FindObjectOfType<GameSession>();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (tag == "Breakable") {
            HandleHit();
        }
    }

    private void HandleHit() {
        timesHit += 1;
        if (timesHit >= maxHits) {
            DestroyBlock();
        }
    }
    
    private void DestroyBlock() {
        PlayBlockDestroySFX();
        Destroy(gameObject);
        level.BlockDestroyed();
        TriggerSparklesVFX();
    }

    private void PlayBlockDestroySFX() {
        gameSession.AddToScore();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    }

    private void TriggerSparklesVFX() {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}
