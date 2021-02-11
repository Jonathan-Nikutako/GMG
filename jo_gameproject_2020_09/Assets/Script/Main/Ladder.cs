using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    // 始点が下、終点が上
    [SerializeField, Tooltip("始点")]
    private GameObject startLadder;

    [SerializeField, Tooltip("終点")]
    private GameObject endLadder;

    public Vector2 sp { get { return startLadder.transform.position; } }
    public Vector2 ep { get { return endLadder.transform.position; } }

    // 始点から終点の向きベクトル
    public Vector2 LadderVect { get { return (ep - sp).normalized; } }

    // Start is called before the first frame update
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(sp, new Vector3(1, 1, 1));
        Gizmos.DrawWireCube(ep, new Vector3(1, 1, 1));
        Gizmos.DrawLine(sp, ep);
    }
}
