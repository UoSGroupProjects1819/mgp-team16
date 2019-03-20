using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunEffects : MonoBehaviour
{
    public Transform MuzzleFlashPrefab;
    public Transform Gun;

    void Effect()
    {
        Transform clone = Instantiate(MuzzleFlashPrefab, Gun.position, Gun.rotation) as Transform;
        clone.parent = Gun;
        float size = Random.Range(0.5f, 1f);
        clone.localScale = new Vector3(1, 1, 1);
        Destroy(clone, 0.05f);
    }

}
