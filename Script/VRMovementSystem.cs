using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Persistence;

namespace Core.VRMovementSystem
{
    public class VRMovementSystem
    {
        /// <summary>
        /// Regresa los ejes del control
        /// </summary>
        static public Vector3 Axis
        { 
            get => new Vector3(Input.GetAxis("Horizontal"), 0f,
                Input.GetAxis("Vertical"));
        }

        /// <summary>
        /// Regresa los ejes del control multiplicados por delta time.
        /// </summary>
        public static Vector3 AxisDelta
        {
            get => new Vector3(Input.GetAxis("Horizontal"), 0f,
                Input.GetAxis("Vertical")) * Time.deltaTime;
        }

        public static Vector3 RightAxis
        {
            get => new Vector3(Input.GetAxis("RH"), 0f, 
                Input.GetAxis("RV"));
        }

        public static Vector3 RightAxisDelta
        {
            get => new Vector3(Input.GetAxis("RH"), 0f,
                Input.GetAxis("RV")) * Time.deltaTime;
        }

        /// <summary>
        /// Mueve al personaje en VR
        /// </summary>
        /// <param name="t">El transform del cuerpo que va a moverse</param>
        /// <param name="moveSpeed">La velocidad de movimiento del cuerpo</param>
        public static void VRMovement(Transform t, float moveSpeed, float rotationSpeed)
        {
            t.Translate(Vector3.forward * AxisDelta.z * moveSpeed);
            t.Rotate(Vector3.up * rotationSpeed * RightAxisDelta.x);
        }
    }
}
