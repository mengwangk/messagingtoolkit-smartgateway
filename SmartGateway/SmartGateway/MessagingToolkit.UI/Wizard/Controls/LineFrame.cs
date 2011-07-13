//===============================================================================
// OSML - Open Source Messaging Library
//
//===============================================================================
// Copyright © TWIT88.COM.  All rights reserved.
//
// This file is part of Open Source Messaging Library.
//
// Open Source Messaging Library is free software: you can redistribute it 
// and/or modify it under the terms of the GNU General Public License version 3.
//
// Open Source Messaging Library is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this software.  If not, see <http://www.gnu.org/licenses/>.
//===============================================================================
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace MessagingToolkit.UI.Controls
{
	/// <summary>
	/// Summary description for LineFrame.
	/// </summary>
	public class EtchedLine : System.Windows.Forms.Control
	{
		public EtchedLine()
		{
		}

		protected override void OnPaint(PaintEventArgs pe)
		{
			// TODO: Add custom paint code here
			Graphics g = pe.Graphics;
			using(Pen p = new Pen(Color.FromArgb(128, 128, 128)))
			{
				g.DrawLine(p, new Point(0, 0), new Point(Width, 0));
			}
			g.DrawLine(Pens.White, new Point(0, 1), new Point(Width, 1));

			// Calling the base class OnPaint
			base.OnPaint(pe);
		}

		protected override Size DefaultSize
		{
			get
			{
				return new Size(75, 2);
			}
		}

		[Browsable(true)]
		[Category("Layout")]
		[Description("Gets/Sets the width of the line")]
		public new int Width
		{
			get
			{
				return Size.Width;
			}
			set
			{
				Size = new Size(value, 2);
			}
		}
	}
}
