using UnityEngine;
namespace IdleGame.Skil
{
    public class Skillrotate : MonoBehaviour
    {
        public float rotationSpeed = 50f; // 회전 속도

        void Update()
        {
            transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime);
        }
    }
}