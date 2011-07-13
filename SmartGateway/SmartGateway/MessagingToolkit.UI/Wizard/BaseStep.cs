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
using System.Security.Permissions;

namespace MessagingToolkit.UI
{
	/// <summary>
	/// Summary description for BaseStep.
	/// </summary>
	[DefaultEvent("ShowStep")]
	public class BaseStep : System.Windows.Forms.UserControl
	{
		// objects to serve as event keys
		private static object stepTitleChanged = new object();
		private static object stepDescriptionChanged = new object();
		private static object previousStepChanged = new object();
		private static object nextStepChanged = new object();
		private static object showStep = new object();
		private static object sideBarImageChanged = new object();
		private static object sideBarLogoChanged = new object();
		private static object logoChanged = new object();
		private static object resetStep = new object();
		private static object validateStep = new object();
		private static object pageLayoutChanged = new object();

		protected static Size DefaultExteriorPageSize = new Size(324, 313);
		protected static Size DefaultInteriorPageSize = new Size(472, 236);

		/// <summary>
		/// The magic step name to signify that clicking next
		/// will finish the wizard
		/// </summary>
		public const string FinishStep = "FINISHED";

		private string title = "";
		private BaseWizard wizard = null;
		private string previousStep = "";
		private string nextStep = "";
		private Image sideBarLogo = null;
		private Image sideBarImage = null;
		private Image logo = null;
		private PageLayout pageLayout = PageLayout.InteriorPage;
		protected System.Windows.Forms.Label Description;
		private int numLinesToDraw = 3;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
	
		public BaseStep()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Description = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// Description
			// 
			this.Description.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.Description.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Description.Location = new System.Drawing.Point(8, 8);
			this.Description.Name = "Description";
			this.Description.Size = new System.Drawing.Size(456, 72);
			this.Description.TabIndex = 0;
			this.Description.Text = "Enter Step Description Here";
			// 
			// BaseStep
			// 
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.Description});
			this.Name = "BaseStep";
			this.Size = new System.Drawing.Size(472, 236);
			this.ResumeLayout(false);

		}
		#endregion

		#region Public Properties

		#region StepTitle Property
		[Browsable(true)]
		[Category("Wizard Step")]
		[Description("Gets/Sets the text that will be displayed in the white portion above the step")]
		[DefaultValue("Step Title")]
		public string StepTitle
		{
			get
			{
				return title;
			}
			set
			{
				title = value;

				OnStepTitleChanged(EventArgs.Empty);
			}
		}
		#endregion

		#region StepDescription
		public string StepDescription
		{
			get
			{
				return this.Description.Text;
			}
			set
			{
				Description.Text = value;

				OnStepDescriptionChanged(EventArgs.Empty);
			}
		}
		#endregion

		#region PreviousStep Property
		[Browsable(true)]
		[Category("Wizard Step")]
		[Description("Gets/Sets the previous step in the wizard process")]
		[DefaultValue("")]
		public string PreviousStep
		{
			get
			{
				return previousStep;
			}
			set
			{
				previousStep = value;

				OnPreviousStepChanged(EventArgs.Empty);
			}
		}
		#endregion

		#region Next Step Property
		[Browsable(true)]
		[Category("Wizard Step")]
		[Description("Gets/Sets the next step in the wizard process")]
		[DefaultValue("")]
		public string NextStep
		{
			get
			{
				return nextStep;
			}
			set
			{
				nextStep = value;

				OnNextStepChanged(EventArgs.Empty);
			}
		}
		#endregion

		#region Wizard
		[Browsable(false)]
		public BaseWizard Wizard
		{
			get
			{
				return wizard;
			}
			set
			{
				if( wizard != null )
				{
					DetachWizard();
				}

				wizard = value;

				if( value != null )
					AttachWizard();
			}
		}

		#region DetachWizard
		private void DetachWizard()
		{
			Wizard.NextClicked -= new EventHandler(Wizard_OnNextClicked);
			Wizard.BackClicked -= new EventHandler(Wizard_OnBackClicked);
			Wizard.FinishClicked -= new EventHandler(Wizard_OnFinishClicked);
		}
		#endregion

		#region AttachWizard
		private void AttachWizard()
		{
			Wizard.NextClicked += new EventHandler(Wizard_OnNextClicked);
			Wizard.BackClicked += new EventHandler(Wizard_OnBackClicked);
			Wizard.FinishClicked += new EventHandler(Wizard_OnFinishClicked);
		}
		#endregion

		#endregion
		
		#region IsFinished
		[Browsable(true)]
		[Category("Wizard Step")]
		[Description("Gets/Sets whether this is the last step of the wizard")]
		[DefaultValue(false)]
		public bool IsFinished
		{
			get
			{
				return nextStep == BaseStep.FinishStep;
			}
			set
			{
				if( value == true )
					nextStep = BaseStep.FinishStep;
				else
					nextStep = "";
			}
		}
		#endregion

		#region PageLayout
		[Browsable(true)]
		[Category("Wizard Step")]
		[Description("Gets/Sets the page layout for this step")]
		[DefaultValue(PageLayout.InteriorPage)]
		public PageLayout PageLayout
		{
			get
			{
				return pageLayout;
			}
			set
			{
				pageLayout = value;

				UpdateLayout(pageLayout);

				OnPageLayoutChanged(EventArgs.Empty);
			}
		}
		#endregion

		#region Logo
		/// <summary>
		///		Gets or sets the custom logo for this step,
		///		if this is <c>null</c> then the logo defined by the 
		///		<see cref="Wizard"/> will be used
		/// </summary>
		[Browsable(true)]
		[Category("Wizard Step")]
		[Description("Gets/Sets the custom logo for this step")]
		[DefaultValue(null)]
		public Image Logo
		{
			get
			{
				return logo;
			}
			set
			{
				logo = value;

				OnLogoChanged(EventArgs.Empty);
			}
		}
		#endregion

		#region SideBarLogo
		/// <summary>
		///		Gets or sets the small image to be displayed in the sidebar
		/// </summary>
		/// <remarks>
		///		If this value is <c>null</c> then the 
		///		<see cref="BaseWizard.SideBarLogo"/> specified by the wizard
		///		will be used
		/// </remarks>
		[Browsable(true)]
		[Category("Wizard Step")]
		[Description("Gets/Sets the logo to be displayed in the sidebar")]
		[DefaultValue(null)]
		public Image SideBarLogo
		{
			get
			{
				return sideBarLogo;
			}
			set
			{
				sideBarLogo = value;

				OnSideBarLogoChanged(EventArgs.Empty);
			}
		}
		#endregion

		#region SideBarImage
		/// <summary>
		///		Gets or sets the large image to be displayed in the sidebar
		/// </summary>
		/// <remarks>
		///		If this value is <c>null</c> then the 
		///		<see cref="BaseWizard.SideBarImage"/> specified by the wizard
		///		will be used
		/// </remarks>
		[Browsable(true)]
		[Category("Wizard Step")]
		[Description("Gets/Sets the image to display in the sidebar for exterior pages")]
		[DefaultValue(null)]
		public Image SideBarImage
		{
			get
			{
				return sideBarImage;
			}
			set
			{
				sideBarImage = value;

				OnSideBarImageChanged(EventArgs.Empty);
			}
		}
		#endregion

		#endregion

		#region Protected Properties
		[Browsable(true)]
		[Category("Design")]
		[Description("The number of lines to draw on the outside to help with placing controls, not used at runtime")]
		[DefaultValue(3)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual int NumLinesToDraw
		{
			get
			{
				return numLinesToDraw;
			}
			set
			{
				numLinesToDraw = value;

				Invalidate();
				Refresh();
			}
		}
		#endregion

		#region Events

		#region NextStepChanged
		[Browsable(true)]
		[Category("Wizard Step")]
		[Description("Fired when the NextStep property has changed")]
		public event EventHandler NextStepChanged
		{
			add
			{
				Events.AddHandler(BaseStep.nextStepChanged, value);
			}
			remove
			{
				Events.RemoveHandler(BaseStep.nextStepChanged, value);
			}
		}

		protected virtual void OnNextStepChanged(EventArgs e)
		{
			EventHandler handler = (EventHandler) Events[BaseStep.nextStepChanged];

			if( handler != null )
			{
				handler(this, e);
			}
		}
		#endregion

		#region PreviousStepChanged
		[Browsable(true)]
		[Category("Wizard Step")]
		[Description("Fired when the PreviousStep property has changed")]
		public event EventHandler PreviousStepChanged
		{
			add
			{
				Events.AddHandler(BaseStep.previousStepChanged, value);
			}
			remove
			{
				Events.RemoveHandler(BaseStep.previousStepChanged, value);
			}
		}

		protected virtual void OnPreviousStepChanged(EventArgs e)
		{
			EventHandler handler = (EventHandler) Events[BaseStep.previousStepChanged];

			if( handler != null )
			{
				handler(this, e);
			}
		}
		#endregion

		#region StepTitleChanged
		[Browsable(true)]
		[Category("Wizard Step")]
		[Description("Fired when the StepTitle property has changed")]
		public event EventHandler StepTitleChanged
		{
			add
			{
				Events.AddHandler(BaseStep.stepTitleChanged, value);
			}
			remove
			{
				Events.RemoveHandler(BaseStep.stepTitleChanged, value);
			}
		}

		protected virtual void OnStepTitleChanged(EventArgs e)
		{
			EventHandler handler = (EventHandler) Events[BaseStep.stepTitleChanged];

			if( handler != null )
			{
				handler(this, e);
			}
		}
		#endregion

		#region StepDescriptionChanged
		[Browsable(true)]
		[Category("Wizard Step")]
		[Description("Fired when the StepDescription property has changed")]
		public event EventHandler StepDescriptionChanged
		{
			add
			{
				Events.AddHandler(BaseStep.stepDescriptionChanged, value);
			}
			remove
			{
				Events.RemoveHandler(BaseStep.stepDescriptionChanged, value);
			}
		}

		protected virtual void OnStepDescriptionChanged(EventArgs e)
		{
			EventHandler handler = (EventHandler) Events[BaseStep.stepDescriptionChanged];

			if( handler != null )
			{
				handler(this, e);
			}
		}
		#endregion

		#region ShowStep - Updated to include step direction by Ken Ostrin [kostrin@myway.com] 
		/// <summary>
		/// Event that fires when the step is shown in the wizard
		/// </summary>
		[Browsable(true)]
		[Category("Wizard")]
		[Description("Fired every time the step is shown in the wizard")]
		public event ShowStepEventHandler ShowStep
		{
			add
			{
				Events.AddHandler(BaseStep.showStep, value);
			}
			remove
			{
				Events.RemoveHandler(BaseStep.showStep, value);
			}
		}

		protected virtual void OnShowStep(ShowStepEventArgs e)
		{
			ShowStepEventHandler handler = (ShowStepEventHandler) Events[BaseStep.showStep];

			if( handler != null )
			{
				handler(this, e);
			}
		}
		#endregion

		#region ResetStep
		/// <summary>
		/// Event that fires when the steps should be reset back to their default values
		/// </summary>
		[Browsable(true)]
		[Category("Wizard")]
		[Description("Fired when the step needs to reset itself, this is fired when the wizard is reset and when the wizard is first shown")]
		public event EventHandler ResetStep
		{
			add
			{
				Events.AddHandler(BaseStep.resetStep, value);
			}
			remove
			{
				Events.RemoveHandler(BaseStep.resetStep, value);
			}
		}

		protected virtual void OnResetStep(EventArgs e)
		{
			EventHandler handler = (EventHandler) Events[BaseStep.resetStep];

			if( handler != null )
			{
				handler(this, e);
			}
		}
		#endregion

		#region ValidateStep - Courtesy of Chris Defour [cdufour@epcanada.com]
		/// <summary>
		///		Fires when the step should validate its data (before moving to the next step)
		/// </summary>
		[Browsable(true)]
		[Category("Wizard Step")]
		[Description("Fired when moving to the next step")]
		public event System.ComponentModel.CancelEventHandler ValidateStep 
		{
			add
			{
				Events.AddHandler(BaseStep.validateStep, value);
			}
			remove
			{
				Events.RemoveHandler(BaseStep.validateStep, value);
			}
		}

		protected virtual void OnValidateStep(CancelEventArgs e)
		{
			System.ComponentModel.CancelEventHandler handler = (System.ComponentModel.CancelEventHandler) Events[BaseStep.validateStep];

			if( handler != null )
			{
				handler(this, e);
			}
		}
		#endregion

		#region PageLayoutChanged
		/// <summary>
		/// Event that fires when the steps should be reset back to their default values
		/// </summary>
		[Browsable(true)]
		[Category("Wizard")]
		[Description("Fired when the PageLayout property has changed")]
		public event EventHandler PageLayoutChanged
		{
			add
			{
				Events.AddHandler(BaseStep.pageLayoutChanged, value);
			}
			remove
			{
				Events.RemoveHandler(BaseStep.pageLayoutChanged, value);
			}
		}

		protected virtual void OnPageLayoutChanged(EventArgs e)
		{
			EventHandler handler = (EventHandler) Events[BaseStep.pageLayoutChanged];
		
			if( handler != null )
			{
				handler(this, e);
			}
		}
		#endregion

		#region LogoChanged
		/// <summary>
		/// Event that fires when the <see cref="Logo"/> property has changed
		/// </summary>
		[Browsable(true)]
		[Category("Wizard Step")]
		[Description("Fired when the Logo property has changed")]
		public event EventHandler LogoChanged
		{
			add
			{
				Events.AddHandler(BaseStep.logoChanged, value);
			}
			remove
			{
				Events.RemoveHandler(BaseStep.logoChanged, value);
			}
		}

		protected virtual void OnLogoChanged(EventArgs e)
		{
			EventHandler handler = (EventHandler) Events[BaseStep.logoChanged];
		
			if( handler != null )
			{
				handler(this, e);
			}
		}
		#endregion

		#region SideBarLogoChanged
		/// <summary>
		/// Event that fires when the <see cref="SideBarLogo"/> property has changed
		/// </summary>
		[Browsable(true)]
		[Category("Wizard Step")]
		[Description("Fired when the SideBarLogo property has changed")]
		public event EventHandler SideBarLogoChanged
		{
			add
			{
				Events.AddHandler(BaseStep.sideBarLogoChanged, value);
			}
			remove
			{
				Events.RemoveHandler(BaseStep.sideBarLogoChanged, value);
			}
		}

		protected virtual void OnSideBarLogoChanged(EventArgs e)
		{
			EventHandler handler = (EventHandler) Events[BaseStep.sideBarLogoChanged];
		
			if( handler != null )
			{
				handler(this, e);
			}
		}
		#endregion

		#region SideBarImageChanged
		/// <summary>
		/// Event that fires when the <see cref="SideBarImage"/> property has changed
		/// </summary>
		[Browsable(true)]
		[Category("Wizard Step")]
		[Description("Fired when the SideBarImage property has changed")]
		public event EventHandler SideBarImageChanged
		{
			add
			{
				Events.AddHandler(BaseStep.sideBarImageChanged, value);
			}
			remove
			{
				Events.RemoveHandler(BaseStep.sideBarImageChanged, value);
			}
		}

		protected virtual void OnSideBarImageChanged(EventArgs e)
		{
			EventHandler handler = (EventHandler) Events[BaseStep.sideBarImageChanged];
		
			if( handler != null )
			{
				handler(this, e);
			}
		}
		#endregion

		#endregion

		#region Event Handlers
		private void Wizard_OnNextClicked(object o, EventArgs e)
		{
			OnNext();
		}

		private void Wizard_OnBackClicked(object o, EventArgs e)
		{
			OnBack();
		}

		private void Wizard_OnFinishClicked(object o, EventArgs e)
		{
			OnFinish();
		}
		
		// Updated May 20, 2003, switched from event handler to overriding the protected method
		protected override void OnLoad(System.EventArgs e)
		{
			base.OnLoad(e);

			UpdateLayout(pageLayout);

			UIPermission uiP = new UIPermission(UIPermissionWindow.AllWindows);
			uiP.Demand();
		}

		// Updated May 23, 2003 - Added guidelines for Wizard97 specs
		protected override void OnPaint(PaintEventArgs e)
		{
			if( DesignMode )
			{
				Point p1 = new Point(8, 0);
				Point p2 = new Point(8, Height);

				Graphics g = e.Graphics;

				using( Pen p = new Pen(SystemColors.ControlText))
				{
					p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;

					for(int i = 0; i < numLinesToDraw; i++)
					{
						g.DrawLine(p, p1, p2);
						p1.Offset(16, 0);
						p2.Offset(16, 0);
					}

					p1 = new Point( Width - 8, 0 );
					p2 = new Point( Width - 8, Height );

					for(int i = 0; i < numLinesToDraw; i++)
					{
						g.DrawLine(p, p1, p2);
						p1.Offset(-16, 0);
						p2.Offset(-16, 0);
					}
				}
			}
		}
		#endregion

		#region Protected Methods
		#region Updated by Chris Defour [cdufour@epcanada.com]
		// ValidateStep event fires when you click Next
		#endregion
		protected virtual void OnNext()
		{
			// Validate step before advancing
			CancelEventArgs e = new CancelEventArgs();
			OnValidateStep(e);
	
			if( !e.Cancel )
			{
				Wizard.MoveNext();
			}
		}

		protected virtual void OnBack()
		{
			Wizard.MoveBack();
		}

		#region Bug fix by Chris Storah [http://www.codeproject.com/cs/miscctrl/TSWizard.asp?msg=480888#xx480888xx]
		// The the ValidateStep event wouldn't fire if you clicked Finish
		#endregion
		#region Bug found by Urs Enzler [http://www.codeproject.com/cs/miscctrl/TSWizard.asp?msg=367657#xx367657xx]
		// AllowClose.AskIfNotFinish wasn't needed, the solution is to set
		// DialogResult to OK then check for that in the Closing event
		#endregion
		protected virtual void OnFinish()
		{
			CancelEventArgs e = new CancelEventArgs();
			OnValidateStep(e);
	
			if( !e.Cancel )
			{
				Wizard.DialogResult = DialogResult.OK;
				Wizard.Close();
			}
		}

		#region UpdateLayout
		/// <summary>
		///		Changes the layout of the user control to match the preferred
		///		format
		/// </summary>
		/// <param name="layout">The layout to change to</param>
		protected virtual void UpdateLayout(PageLayout layout)
		{
			if( layout == PageLayout.None )
				return;

			switch(layout)
			{
				case PageLayout.ExteriorPage:
					BackColor = Color.White;
					Description.Visible = true;
					break;
				case PageLayout.InteriorPage:
					BackColor = SystemColors.Control;
					Description.Visible = false;
					break;
			}
		}
		#endregion

		#endregion

		#region Internal methods
		internal void FireShowEvent(ShowStepEventArgs e)
		{
			OnShowStep(e);
		}

		internal void FireResetStepEvent()
		{
			OnResetStep(EventArgs.Empty);
		}
		#endregion
	}
}
