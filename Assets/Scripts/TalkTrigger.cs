using UnityEngine;

public class TalkTrigger : MonoBehaviour
{
    public Talk talk;

    public void TriggerTalk()
    {
        FindObjectOfType<TalkManager>().StartTalk(talk);
    }


}
