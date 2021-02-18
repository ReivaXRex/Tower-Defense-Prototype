using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<EnemyMovement>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        AimWeapon(target);
    }

    void AimWeapon(Transform aimTarget)
    {
        target = aimTarget;
        weapon.LookAt(aimTarget);

    }
}
