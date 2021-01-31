using UnityEngine;


namespace Game.UI
{

    public class EventScreen : MonoBehaviour
    {


        public void ClosePanel()
        {
            gameObject.SetActive(false);
        }

        public void SendBoyz()
        {
            Debug.Log("Boyz are sent");
            gameObject.SetActive(false);
        }
    }
}
