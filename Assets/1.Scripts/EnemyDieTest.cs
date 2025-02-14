using UnityEngine;

namespace My
{
    public class EnemyDieTest : MonoBehaviour
    {
        #region Variables

        #endregion

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if ( collision.tag == "Hero")
            {
                Destroy(gameObject);  
            }
        }
    }
}