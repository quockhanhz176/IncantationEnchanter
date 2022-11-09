using UnityEngine;
using Pathfinding;

public class NoticeRadius : MonoBehaviour
{
  void OnTriggerEnter2D(Collider2D collider)
  {
    if (collider.gameObject.tag == "Player")
    {
      var pathFinder = GetComponentInParent<AIPath>();
      pathFinder.canMove = true;
    }
  }
}
