using UnityEngine;

public class DualObjectiveCamera : MonoBehaviour{
    public Transform leftTarget;
    public Transform rightTarget;
    public float minDistance;
    void Update() {
        float distanceBetweenTargets = Mathf.Abs(leftTarget.position.z - rightTarget.position.z);
        float centerPosition = (leftTarget.position.z + rightTarget.position.z);

        transform.position = new Vector3(centerPosition, transform.position.y,
            distanceBetweenTargets > minDistance? 
            -distanceBetweenTargets:
            -minDistance
            );
    }
}
