using UnityEngine;

public class Keyboard
{
    private bool direction;
    private GameObject character;

    public Keyboard()
    {
        character = GameObject.Find("Character");
    }

    public void StairKey(Transform platform)
    {
        character.GetComponent<Animator>().Play("Jump Animation");

        DataManager.Instance.CurrentScore++;
        DataManager.Instance.BestScore();

        DataManager.Instance.Save();

        SoundManager.Instance.Sound(SoundType.Move);

        character.GetComponent<SpriteRenderer>().flipX = direction;

        if (direction == true)
        {
            platform.transform.position = new Vector3
            (
                platform.transform.position.x + 1,
                platform.transform.position.y - 0.5f,
                platform.transform.position.z
            );
        }
        else
        {
            platform.transform.position = new Vector3
            (
                platform.transform.position.x - 1,
                platform.transform.position.y - 0.5f,
                platform.transform.position.z
            );
        }
    }

    public void TurnKey()
    {
        direction = !direction;
    }
}
