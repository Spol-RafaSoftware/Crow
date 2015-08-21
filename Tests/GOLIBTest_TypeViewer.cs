#define MONO_CAIRO_DEBUG_DISPOSE


using System;
using System.Runtime.InteropServices;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

using System.Diagnostics;

//using GGL;
using go;
using System.Threading;
using System.Reflection;


namespace test
{
	class GOLIBTest_TypeViewer : OpenTKGameWindow
	{
		public GOLIBTest_TypeViewer ()
			: base(1024, 600,"test")
		{}

		VerticalStack g;
		TypeContainer type;

		protected override void OnLoad (EventArgs e)
		{
			base.OnLoad (e);
			type = new TypeContainer(typeof (GraphicObject));

			this.AddWidget(Interface.Load ("Interfaces/testTypeViewer.goml", type));
			//LoadInterface("Interfaces/testTypeViewer.goml", out g);
		}

		protected override void OnRenderFrame (FrameEventArgs e)
		{
			GL.Clear (ClearBufferMask.ColorBufferBit);
			base.OnRenderFrame (e);
			SwapBuffers ();

			MemberInfo mi;

		}

		[STAThread]
		static void Main ()
		{
			Console.WriteLine ("starting example");

			using (GOLIBTest_TypeViewer win = new GOLIBTest_TypeViewer( )) {
				win.Run (30.0);
			}
		}
	}
	public class TypeContainer
	{
		public Type Type;
		public TypeContainer(Type _type){
			Type = _type;
		}
		public string Name {
			get { return Type.Name; }
		}
		public MemberInfo[] Members {
			get { return Type.GetProperties (BindingFlags.Public | BindingFlags.Instance); }
		}
	}
}