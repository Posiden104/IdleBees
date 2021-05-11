using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Helpers
{
    public class BackgroundScript : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            Resize();
        }

        public void Resize()
        {
            SpriteRenderer sr = GetComponent<SpriteRenderer>();

            float worldScreenHeight = Camera.main.orthographicSize * 2;
            float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

            transform.localScale = new Vector3(
                worldScreenWidth / sr.sprite.bounds.size.x,
                worldScreenHeight / sr.sprite.bounds.size.y, 1);

        }

    }
}