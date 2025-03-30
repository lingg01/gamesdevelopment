using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

  [SerializeField] private bool isRepeatedMovement = false;
  //time to move from one grid to another
  [SerializeField] private float moveDuration = 0.1f;
  [SerializeField] private float gridSize = 1f;

  public BranchManager bm;
  private Camera mainCamera;

  private bool isMoving = false;

  System.Func<KeyCode, bool> inputFunction;

  void Start()
  {
    mainCamera = Camera.main;
  }

  // Update is called once per frame
  private void Update() {
    // Only one movement at a time
    if (!isMoving) {
    
      if (isRepeatedMovement) {
        inputFunction = Input.GetKey;
      } 
      
      else {
        inputFunction = Input.GetKeyDown;
      }

      //input keys
      if (inputFunction(KeyCode.UpArrow)) {
        StartCoroutine(Move(Vector2.up));
      } else if (inputFunction(KeyCode.DownArrow)) {
        StartCoroutine(Move(Vector2.down));
      } else if (inputFunction(KeyCode.LeftArrow)) {
        StartCoroutine(Move(Vector2.left));
      } else if (inputFunction(KeyCode.RightArrow)) {
        StartCoroutine(Move(Vector2.right));
      }
    }

        // Get player input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Restrict player in game screen
        RestrictPlayerWithinBounds();

        //Flip character when direction is changed
        if (inputFunction(KeyCode.RightArrow)) // Move right
        {
            Flip(true);
        }
        else if (inputFunction(KeyCode.LeftArrow)) // Movie eft
        {
            Flip(false);
        }

  }

  // Movement from one grid to another
  private IEnumerator Move(Vector2 direction) {
    // Record that we're moving so we don't accept more input.
    isMoving = true;

    // Record current position and next position
    Vector2 startPosition = transform.position;
    Vector2 endPosition = startPosition + (direction * gridSize);

    // Move in input direction in time
    float elapsedTime = 0;
    while (elapsedTime < moveDuration) {
      elapsedTime += Time.deltaTime;
      float percent = elapsedTime / moveDuration;
      transform.position = Vector2.Lerp(startPosition, endPosition, percent);
      yield return null;
    }

    // Ensure correct position
    transform.position = endPosition;

    // Another input accepted
    isMoving = false;
  }

    // Destroy branch and enemy when player collides
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Branch"))
        {
            Destroy(other.gameObject);
            bm.branchCount++;
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
    }

    void RestrictPlayerWithinBounds()
    {
        // Get the camera's viewport position
        Vector3 viewportPos = mainCamera.WorldToViewportPoint(transform.position);

        // Clamp the viewport position between 0 and 1
        viewportPos.x = Mathf.Clamp(viewportPos.x, 0.05f, 0.955f); 
        viewportPos.y = Mathf.Clamp(viewportPos.y, 0.12f, 0.9f);

        // Convert back to world space
        transform.position = mainCamera.ViewportToWorldPoint(viewportPos);
    }

    void Flip(bool isFacingRight)
    {
        // If moving right, scale is positive; if left, flip it
        Vector3 localScale = transform.localScale;
        localScale.x = isFacingRight ? Mathf.Abs(localScale.x) : -Mathf.Abs(localScale.x);
        transform.localScale = localScale;
    }

}