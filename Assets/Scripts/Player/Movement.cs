using UnityEngine;

namespace Player {
    public class Movement : MonoBehaviour
    {
        public float sensitivity;

        [Header("Position Limits")]
        [SerializeField] private float minXPos, maxXPos;
        [SerializeField] private float minYPos, maxYPos;
        
        private void Start()
        {
            CursorLocker.Locked = true;
        }

        private void Update()
        {
            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, minXPos, maxXPos),
                Mathf.Clamp(transform.position.y, minYPos, maxYPos)
            );
            transform.position += new Vector3(Input.GetAxis("Mouse X") * sensitivity, Input.GetAxis("Mouse Y") * sensitivity);
        }
    }
}