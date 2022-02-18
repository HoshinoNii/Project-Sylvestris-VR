using UnityEngine;

namespace Inputs {
    public class DriveController : MonoBehaviour {
        public float IsDeadZone;
        private Vector2 inputForce;
        public float speed = 10.0f;
        public float rotationSpeed = 100.0f;

        private void Update() {
            float translation = Input.GetAxis("Vertical") * speed;
            float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
            inputForce = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            if (inputForce.magnitude < IsDeadZone) inputForce = Vector2.zero;

            translation *= Time.deltaTime;
            rotation *= Time.deltaTime;

            transform.Translate(0, 0, translation);
            transform.Rotate(0, rotation, 0);

            // Jump
            if (Input.GetButton("Fire1")) {
                this.GetComponent<Rigidbody>().AddForce(0, 10, 0);
            }
        }
    }
}