using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cairo;
using System.Diagnostics;

namespace Crow
{
	public class Rectangles : IDisposable
    {
		#region IDisposable implementation

		public void Dispose ()
		{
			Region.Dispose ();
		}

		#endregion

		public Cairo.Region Region = new Cairo.Region ();
        
        public int count { get { return Region.NumRectangles; }}

        public void AddRectangle(Rectangle r)
        {			
			Region.UnionRectangle (r);
        }
		public void stroke(Context ctx, Color c)
		{
			for (int i = 0; i < Region.NumRectangles; i++)
				ctx.Rectangle (Region.GetRectangle (i));
			
			ctx.SetSourceColor(c);

			ctx.LineWidth = 2;
			ctx.Stroke ();
		}
		public void Reset(){
			Region.Dispose ();
			Region = new Region ();
		}
        public void clearAndClip(Context ctx)
        {
			if (count == 0)
				return;
			for (int i = 0; i < Region.NumRectangles; i++)
				ctx.Rectangle (Region.GetRectangle (i));

			ctx.ClipPreserve();
			ctx.Operator = Operator.Clear;
            ctx.Fill();
            ctx.Operator = Operator.Over;
        }

        public void clip(Context ctx)
        {
			for (int i = 0; i < Region.NumRectangles; i++)
				ctx.Rectangle (Region.GetRectangle (i));
            ctx.Clip();
        }			
		public void clear(Context ctx)
        {
			for (int i = 0; i < Region.NumRectangles; i++)
				ctx.Rectangle (Region.GetRectangle (i));
			ctx.Operator = Operator.Clear;
            ctx.Fill();
            ctx.Operator = Operator.Over;
        }
    }
}
