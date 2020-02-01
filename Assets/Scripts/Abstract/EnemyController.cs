using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyController : MonoBehaviour
{
    public abstract bool Grounded();

    public abstract bool HittingWall();
}
