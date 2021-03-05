using UnityEngine;
/// <summary>
/// Makes an object throwable.
/// </summary>

[RequireComponent(typeof(Drag))]
[RequireComponent(typeof(Rigidbody))]
public class Throwable : MonoBehaviour
{
	private Drag drag;
	private Rigidbody planet;
	private Transform planetTransform;
	private bool recording = false;
	private const int NumberOfFrames = 5;
	private Vector3[] framePositions;
	private bool initialRecord = true;
	protected void Awake()
	{
		drag = GetComponent<Drag>();
		planet = GetComponent<Rigidbody>();
	}
	protected void Start()
	{
		framePositions = new Vector3[NumberOfFrames];
	}

    // Update is called once per frame
    private void Update()
	{
		if(!recording && drag.moveAllowed)
		{
			StartRecording();
		}else if( recording && drag.moveAllowed)
		{
			Record(transform.position);
		}else if (recording && !drag.moveAllowed)
		{
			Launch();
			StopRecording();
		} 
        
	}

    private void Record(Vector3 position){
		
		if (initialRecord)
		{
			for (int i = 0; i < framePositions.Length; i++) {
				framePositions[i] = position;
			}
			initialRecord = false;
		}else{
			Debug.Log("Recording");
			NextVelocity(position, framePositions);
		}
	}

    private void Launch(){
		
		Vector3 outputVelocity = new Vector3();
		for (int i = 0; i < framePositions.Length-1; i++) {
			outputVelocity += (framePositions[i+1] - framePositions[i])/Time.fixedDeltaTime;
		}
		
		outputVelocity /= NumberOfFrames;
		planet.velocity = outputVelocity;
	}

    private void StartRecording()
	{
		recording = true;
		initialRecord = true;
	}

    private void StopRecording()
	{
		recording = false;
	}
	private void NextVelocity(Vector3 position, Vector3[] positions)
	{
		//TODO there is something fishy here, previous is never used.
		Vector3 
			previous, 
			current = position;
		
		for (int i = positions.Length-1; i > 1; i--) {
			previous = positions[i];
			positions[i] = current;
			current = positions[i-1];
			// Debug.Log("Popped result"+positions[i]);
		}
		
	}
}
