// We make an abstraction for 
public static class Controls
{
	public static Vector2 MoveDiagonaly()
    {
		return new Vector2(MoveRight(), MoveUp());
	}

	public static float MoveRight()
	{
		return Input.GetAxisRaw("Horizontal");
	}

	public static float MoveUp()
	{
		return Input.GetAxisRaw("Vertical")
	}
	
}