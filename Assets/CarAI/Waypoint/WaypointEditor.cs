using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[InitializeOnLoad()]
public class WaypointEditor : MonoBehaviour
{
    
    [DrawGizmo(GizmoType.NonSelected | GizmoType.Selected | GizmoType.Pickable)]
    public static void OnDrawSceneGizmo(Waypoint waypoint, GizmoType gizmoType)
    {
        if((gizmoType & GizmoType.Selected) != 0)
        {
            Gizmos.color = Color.yellow;
        }
        else
        {
            Gizmos.color = Color.yellow * 0.5f;
        }

        Gizmos.DrawSphere(waypoint.transform.position, .5f);



        if (waypoint.nextWaypoint != null)
        {
            Gizmos.color = Color.green;

            foreach (Transform point in waypoint.nextWaypoint)
            {
                Gizmos.DrawLine(waypoint.transform.position, point.transform.position);
            }
        }
    }
}
