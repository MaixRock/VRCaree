using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {
        private CarController m_Car; // the car controller we want to use


        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
        }


        private void FixedUpdate()
        {
            // pass the input to the car!
            //float h = Input.GetAxis("Horizontal");
            //float v = Input.GetAxis("Vertical");

            Vector2 input = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
            m_Car.Move(input.x, input.y, input.y, 0f);

            //#if !MOBILE_INPUT
            //            float handbrake = CrossPlatformInputManager.GetAxis("Jump");
            //            m_Car.Move(h, v, v, handbrake);
            //#else
            //m_Car.Move(h, v, v, 0f);
            //#endif
        }
    }
}
