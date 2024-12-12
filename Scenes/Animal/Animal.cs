using Godot;

public partial class Animal : RigidBody2D
{
	public enum AnimalState {READY, DRAG, RELEASE}
	private AudioStreamPlayer2D _stretchSound;
	private AudioStreamPlayer2D _launchSound;
	private AudioStreamPlayer2D _kickSound;
	private Sprite2D _arrow;
	private VisibleOnScreenNotifier2D _notifier;
	private Label _debugLabel;

	private AnimalState _state = AnimalState.READY;
	private float _arrowScaleX = 0.0f;
	private Vector2 _start = Vector2.Zero;
	
	public override void _Ready()
	{
		GetNodes();
		ConnectSignals();
		InitializeVariables();
	}

	public override void _PhysicsProcess(double delta)
	{
		UpdateDebugLabel();
	}

	private void UpdateDebugLabel()
	{
		_debugLabel.Text = $"St: {_state} Sl:{Sleeping}";
	}

	private void GetNodes()
	{ 
		_stretchSound = GetNode<AudioStreamPlayer2D>("StretchSound");
    	_launchSound = GetNode<AudioStreamPlayer2D>("LaunchSound");
    	_kickSound = GetNode<AudioStreamPlayer2D>("KickSound");
    	_arrow = GetNode<Sprite2D>("Arrow");
    	_notifier = GetNode<VisibleOnScreenNotifier2D>("Notifier");
    	_debugLabel = GetNode<Label>("DebugLabel");
	}

	private void InitializeVariables()
	{
		_start = Position;
		_arrowScaleX = _arrow.Scale.X;
		_arrow.Hide();
	}

	private void ConnectSignals()
	{
		InputEvent += OnInputEvent;
		SleepingStateChanged += OnSleepingStateChanged;
		_notifier.ScreenExited += OnScreenExited;
	}

	public void OnInputEvent(Node viewport, InputEvent evt, long shapeIdx)
	{
		
	}

	public void OnSleepingStateChanged()
	{
		
	}
	
	public void OnScreenExited()
	{
		GD.Print("Exited Screen");
	}
}
