using UnityEngine;
using System.Collections;


public class DebugDrawCollisions : MonoBehaviour 
{
	public float normalScale = 1.0f;
	public Color contactNormalColor = Color.yellow;

	void OnCollisionStay( Collision collisionInfo )
	{
		foreach ( ContactPoint cp in collisionInfo.contacts )
		{
			Debug.DrawRay( cp.point, normalScale * cp.normal, contactNormalColor, 0.0f, false );
		}
	}
}
