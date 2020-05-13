using UnityEngine;
using UnityEngine.UI;

public class Player: MonoBehaviour
{
    [SerializeField] private Rigidbody2D _player;
    [SerializeField] private float _jumpSpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private Animator _animator;
    [SerializeField] private GameManager _gameManager;

    [SerializeField] private Text _scoreText, _bestScore;
    public int ScoreAmount;
    

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            _player.velocity = Vector2.zero;
            _player.AddForce(Vector2.up * _jumpSpeed,ForceMode2D.Impulse);

            var rotationVector = transform.rotation.eulerAngles;
            rotationVector.z = 15;
            transform.rotation = Quaternion.Euler(rotationVector);
        }

        if (_player.velocity.y > 8f)
        {
            _player.velocity = Vector2.zero;
        }

        if (_player.velocity.y > 0f)
        {
            _animator.SetBool("isForced", true);
        }

        if (_player.velocity.y < 0) 
        {
            transform.Rotate(0, 0, -_rotationSpeed * Time.deltaTime);
            _animator.SetBool("isForced", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Column")
        {
            _gameManager.GameOver(); 
        }

        if (other.tag == "ScoreArea")
        {
            
            ScoreAmount++;
            _scoreText.text = ScoreAmount.ToString();
        }
    }
}
