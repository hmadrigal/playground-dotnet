namespace Hmadrigal.Services.VirtualKeyboard
{
	using System.Runtime.InteropServices;

	internal struct KEYBDINPUT
	{
		public ushort wVk;
		public ushort wScan;
		public uint dwFlags;
		public long time;
		public uint dwExtraInfo;
	};

	[StructLayout(LayoutKind.Explicit, Size = 28)]
	internal struct INPUT
	{
		[FieldOffset(0)]
		public uint type;
		[FieldOffset(4)]
		public KEYBDINPUT ki;
	};

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct InputKeys
	{
		public uint type;
		public uint wVk;
		public uint wScan;
		public uint dwFlags;
		public uint time;
		public uint dwExtra;
	}

	/// <summary>
	/// Class wrapper for imported DLL functions
	/// </summary>
	internal static class NativeWin32
	{
		public const uint INPUT_KEYBOARD = 1;
		public const uint KEYEVENTF_EXTENDEDKEY = 0x0001;
		public const uint KEYEVENTF_KEYUP = 0x0002;

		[DllImport("user32.dll")]
		public static extern uint SendInput(uint nInputs, ref INPUT pInputs, int cbSize);

		[DllImport("User32.DLL", EntryPoint = "SendInput")]
		public static extern uint SendInput(uint nInputs, InputKeys[] inputs, int cbSize);
	}
}