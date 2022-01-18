using UnityEngine;

namespace Sylvestris.Core.Inputs
{
    public class DriveController : MonoBehaviour
    {
        public float isDeadZone;
        public float speed = 10.0f;
        public float rotationSpeed = 100.0f;
        private Vector2 inputForce;

        private void Update()
        {
            var translation = Input.GetAxis("Vertical") * speed;
            var rotation = Input.GetAxis("Horizontal") * rotationSpeed;
            inputForce = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            if (inputForce.magnitude < isDeadZone)
                inputForce = Vector2.zero;

            translation *= Time.deltaTime;
            rotation *= Time.deltaTime;

            transform.Translate(0, 0, translation);
            transform.Rotate(0, rotation, 0);

            // Jump
            if (Input.GetButton("Fire1")) GetComponent<Rigidbody>().AddForce(0, 10, 0);
        }
    }
}