using Godot;

public partial class Bird2 : RigidBody2D
{
	[Export] private Label _label;
	[Export] private Timer _timer;
	
	public override void _Ready()
	{
		//_label = GetNode<Label>("%Label");
		_timer = GetNode<Timer>("Timer");
		_label.Text = "Text";

		_timer.Timeout += OnTimerTimeout;
		InputEvent += OnInputEvent;
	}

	private void OnInputEvent(Node viewport, InputEvent @event, long shapeIdx)
	{
		if (@event is InputEventMouseButton)
		{
			InputEventMouseButton ev = @event as InputEventMouseButton;
			if (ev.ButtonMask == MouseButtonMask.Left)
			{
				Position = GetGlobalMousePosition();
			}
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		_label.Text = $"{Position}";
	}

	public void OnTimerTimeout()
	{
		ApplyCentralImpulse(new Vector2(500f, -500f));
	}
}
