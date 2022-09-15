//INSTANT C# NOTE: Formerly VB project-level imports:
using System.Collections.Generic;
using System.Diagnostics;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System;

using System.Collections;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using BM;
using BM.Ambulance;
using BM.Area;
using BM.Core;
using BM.Helpers;
using DevExpress.Data;
using DevExpress.Data.Filtering;
using DevExpress.Images;
using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Tile;
using DevExpress.XtraGrid.Views.Tile.ViewInfo;
using DevExpress.XtraNavBar;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.Drawing;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.ViewInfo;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

public partial class frmMain
{
	public frmMain()
	{
		InitializeComponent();
	
	}

	private bool _clearfolder = true;
	private DateTime _startDate;
	private DateTime _finishDate;
	private GridControlState _gridHelper;
	private string _selectedColumn = string.Empty;
	private Type _selectedColumnType;

	/// <summary>
	///     Tests if the item is being dragged from the Gridview or from within the Tree Itself.
	/// </summary>
	private bool _dragfromGrid;

	private int _filterId;
	private GridColumn _filterColName;
	private string _filterValue;
	private readonly Dictionary<int, int> _govItems = new Dictionary<int, int>();
	private readonly Dictionary<int, string> _govParentList = new Dictionary<int, string>();
	private bool _govGridColor = false;
	private bool _trainingShortLoad = true;

	/// <summary>
	///     Load only open records for ClinicalDataSet
	/// </summary>
	private bool _clinicalShortLoad = true;

	private IOverlaySplashScreenHandle _han = null;
	private bool RefreshError {get; set;} = false;
	private TreeListViewState _treeState;
	private int _errorCount = 0;
	private int _refreshCounter = 1;
	private GridHitInfo _hitInfo;
	private string _oldCellValue;
	private int _treeItemId;
	private bool _colEdit = false;
	private int _focusedTreeNode;
	private readonly int _mapMode = 0;
	private CalView _calMainView = CalView.Courses;
	private int _dayI;
	private int _weekI;
	private int _monthI;
	private bool _showWeb = false;
	private bool _inboxDefault = true;
	private bool RefreshHold {get; set;} = false;
	private bool InvoiceRefresh {get; set;}
	private readonly DataTable _emailBs = new DataTable();
	private readonly DataTable _emailMain = new DataTable();
	private int _selectedWebCourseId;
	private Utilities.myXero.Invoice _invoice;
	private bool _invoiceCancel;
	private readonly List<int> _inValidatedShifts = new List<int>();
	private readonly bool _forceMainRefresh = false;

	/// <summary>
	///     Is the MainRefresh function active
	/// </summary>
	/// <returns></returns>
	private bool Refreshing {get; set;} = false;

	private int RefreshCount {get; set;} = 0;

	private enum CalView
	{
		Courses,
		Web
	}

	public frmMain(frmLogIn1 calling)
	{
		try
		{
			calling.Hide();
			InitializeComponent();
			StartupSub();
		}
		catch (Exception ex)
		{
			Utilities.MyError(ex);
		}
		
	}


	public void StartupSub()
	{

		SchedulerStorage.FetchOnVisibleResourcesChanged = true;
		SchedulerStorage.EnableSmartFetch = true;
	}

	private DataTable LoadEmails()
	{

		//If _refreshError Then
		// Return New BindingSource()
		//End If

		DataTable dtb = new DataTable();

		try
		{
			using (dtb)
			{

				// dtb.Columns.Clear()
				dtb.Columns.Add("ID");
				dtb.Columns.Add("Subject");
				dtb.Columns.Add("Received", Type.GetType("System.DateTime"));
				dtb.Columns.Add("Body");
				dtb.Columns.Add("Attachments", Type.GetType("System.Boolean"));
				dtb.Columns.Add("Name");
				dtb.Columns.Add("Flag", Type.GetType("System.Boolean"));
				dtb.Columns.Add("Image", Type.GetType("System.Int32"));
				dtb.Columns.Add("Type");
				dtb.Columns.Add("Email");
				dtb.Columns.Add("Seen", Type.GetType("System.Boolean"));
				dtb.Columns.Add("ParentID");
				dtb.Columns.Add("CID");

				using (DataTable dtb1 = new DataTable())
				{
					dtb1.Columns.Add("ID");
					dtb1.Columns.Add("Subject");
					dtb1.Columns.Add("Received", Type.GetType("System.DateTime"));
					dtb1.Columns.Add("Body");
					dtb1.Columns.Add("Attachments", Type.GetType("System.Boolean"));
					dtb1.Columns.Add("Name");
					dtb1.Columns.Add("Flag", Type.GetType("System.Boolean"));
					dtb1.Columns.Add("Image", Type.GetType("System.Int32"));
					dtb1.Columns.Add("Type");
					dtb1.Columns.Add("Email");
					dtb1.Columns.Add("Seen", Type.GetType("System.Boolean"));
					dtb1.Columns.Add("ParentID");
					dtb1.Columns.Add("CID");

				}
				if (RefreshError == false)
				{
					using (Utilities.Email myemail = new Utilities.Email())
					{
						dtb.Merge(myemail.GetEmails(), true, MissingSchemaAction.Ignore);

					}
				}

			}
			return dtb;
		}
		catch (Exception ex)
		{
			RefreshError = true;
			Utilities.MyError(ex);
			return new DataTable();
		}
		finally
		{

		}
	}


	private void LoadGovItems()
	{

		var sql = "SELECT ItemRef, ParentID FROM BusinessManager.Gov where not IsNull(ItemRef)";
		//Try
		_govItems.Clear();

		using (var connection = new MySqlConnection(BM.Core.MySQlHelper.ConnectionString))
		{
			using (var command = new MySqlCommand(sql, connection))
			{
				connection.Open();
				var result = command.ExecuteReader();
				if (result.HasRows)
				{
					while (result.Read())
					{
						if (_govItems.ContainsKey(Convert.ToInt32(result[0])) == false)
						{
							_govItems.Add(Convert.ToInt32(result[0]), Convert.ToInt32(result[1]));
						}

					}
				}
			}
		}
		//Catch exception1 As System.Exception
		// Utilities.MyError(exception1)
		//End Try
	}

	private void LoadGovParentsList()
	{

		var sql = "SELECT ID, Section FROM BusinessManager.Gov";
		// Try
		_govParentList.Clear();

		using (var connection = new MySqlConnection(BM.Core.MySQlHelper.ConnectionString))
		{
			using (var command = new MySqlCommand(sql, connection))
			{
				connection.Open();
				var result = command.ExecuteReader();
				if (result.HasRows)
				{
					while (result.Read())
					{
						// (" " & result(0) & " " & result(1))
						_govParentList.Add(Convert.ToInt32(result[0]), (result[1] == null ? null : Convert.ToString(result[1])));
					}
				}
			}
		}
		//Catch exception1 As System.Exception
		// Utilities.MyError(exception1)
		//End Try
	}

	private void frmMain_Load(object sender, EventArgs e)
	{
		try
		{
			//Core.Security.LogEvent("Main form Load - Start", Core.Security.LogLevel.Debug)
			//Utilities.StartTaskBarAssistant(Me)
			_treeState = new TreeListViewState(TreeList1);
			Task.Run(() => tt.Fill(PersonnellDataSet.PersonAvail));
			Ribbon.Manager.ShowScreenTipsInMenus = true;
			//FileUtilities.TryCreateShortcut(ToastNotificationsManager1)


			FillVariables_Text();


			SolutionSettings.VisibleGrid = grdMyInbox;
			Task.Run(() => SetupColumns());

			grdMyInbox.FormatRules.Clear();
			grdMyInbox.FormatRules.Add(Utilities.GridRules.GeneralRed( GridColumn7, FormatCondition.Equal, true));
			grdMyInbox.FormatRules.Add(Utilities.GridRules.GeneralBold( colSeen, FormatCondition.NotEqual, true));


			_gridHelper = new GridControlState(new GridControlState.ViewDescriptor[] {new GridControlState.ViewDescriptor(string.Empty, "ID")});

			tbDashboard.ShowTabHeader = DefaultBoolean.False;
			SplitContainerControl4.PanelVisibility = SplitPanelVisibility.Panel2;
			SplitContainerControl4.SplitterPosition = 0;

			NavBarGroup1.Expanded = true;

			tbDashboard.SelectedTabPage = tabMyHome;
			Utilities.ShowRibbonPage(rbnMyHome, RibbonControl1);
			//Core.Security.LogEvent("Main form Load - Finish", Core.Security.LogLevel.Debug)
		}
		catch (Exception ex)
		{
			Utilities.MyError(ex);
		}
	}

	private void FillVariables_Text()
	{
		Task.Run(() =>
		{
			Networking.SetupNetwork();
			if (Networking.NetworkSecure == true)
			{
				brSecurity.Caption = "Connection Secure";
				brSecurity.ImageOptions.Image = BM.Properties.Resources.lock_ssl;
			}
			else
			{
				brSecurity.Caption = "Connection NOT Secure";
				brSecure.ImageOptions.Image = BM.Properties.Resources.AuditLog_Small;
			}

			if (Networking.NetworkSharesAvailable == true)
			{
				brShares.Caption = "LAN OK";
				brShares.ImageOptions.Image = BM.Properties.Resources.network_status;
				//ToastNotificationsManager1.ShowNotification("22b11e75-e6b9-4e41-a74c-f2b476523489")
			}
			else
			{
				brShares.Caption = "No LAN Network";
				brShares.ImageOptions.Image = BM.Properties.Resources.network_status_busy;
				// ToastNotificationsManager1.ShowNotification("22b11e75-e6b9-4e41-a74c-f2b476523489")
			}

			if (Networking.IsWebSiteAvailable == true)
			{
				brWebAccess.Caption = "Website OK";
				brWebAccess.ImageOptions.Image = BM.Properties.Resources.network_cloud;
				btnShowWeb.Enabled = true;
			}
			else
			{
				//ToastNotificationsManager1.ShowNotification("b7cf0f3a-3c8f-4bfb-8fd2-b04b43d14d12")
				brWebAccess.Caption = "No Web Connection";
				brWebAccess.ImageOptions.Image = BM.Properties.Resources.network_status_busy;
				btnShowWeb.Enabled = false;
				btnShowWeb.Hint = "No connection to website.";
			}
		});

		brUser.Caption = SolutionSettings.CurrentUser.UserName;
		brIP.Caption = Networking.MyIp;
		brLoggedUsers.Caption = Networking.LoggedInUserCount + " users logged In.";
		brVersion.Caption = SolutionSettings.VersionString;
		br64.Caption = (Environment.Is64BitProcess ? "64-bit" : "32-bit") as string;
		brLocale.Caption = Security.TenantDescription;
	}

	private void SetupColumns()
	{
		//AddHandler TrainingGridView.CustomColumnDisplayText, AddressOf GridView_CustomColumnDisplayText


		if (InvokeRequired)
		{
			Invoke(new Action(() =>
			{
				Setup.PrepareTrainingColumns(TrainingGridView);
			}));
		}
		else
		{
			Setup.PrepareTrainingColumns(TrainingGridView);
		}


		//AddHandler ClinicalGridView.CustomColumnDisplayText, AddressOf GridView_CustomColumnDisplayText
		if (InvokeRequired)
		{
			Invoke(new Action(() =>
			{
				Setup.PrepareClinicalColumns(ClinicalGridView);
			}));
		}
		else
		{
			Setup.PrepareClinicalColumns(ClinicalGridView);
		}

		if (_emailBs.Columns.Count == 0)
		{
			_emailBs.Columns.Add("ID");
			_emailBs.Columns.Add("Subject");
			_emailBs.Columns.Add("Received", Type.GetType("System.DateTime"));
			_emailBs.Columns.Add("Body");
			_emailBs.Columns.Add("Attachments", Type.GetType("System.Boolean"));
			_emailBs.Columns.Add("Name");
			_emailBs.Columns.Add("Flag", Type.GetType("System.Boolean"));
			_emailBs.Columns.Add("Image", Type.GetType("System.Int32"));
			_emailBs.Columns.Add("Type");
			_emailBs.Columns.Add("Email");
			_emailBs.Columns.Add("Seen", Type.GetType("System.Boolean"));
			_emailBs.Columns.Add("ParentID");
			_emailBs.Columns.Add("CID");
		}
	}

	private void btnFlagged_ItemClick(object sender, ItemClickEventArgs e)
	{

		_han = (IOverlaySplashScreenHandle)Utilities.ShowProgressPanel(this);
		try
		{
			if (SolutionSettings.VisibleScreen == Screens.Training)
			{
				Course.Show.Flagged(TrainingGridView);
			}
			else if (SolutionSettings.VisibleScreen == Screens.Clinical)
			{
				Shifts.Show.Flagged(ClinicalGridView);
			}
		}
		catch (Exception ex)
		{
			Utilities.MyError(ex);
		}
		finally
		{
			Utilities.CloseProgressPanel(_han);
		}
	}

	private void btnOpenCourses_ItemClick(object sender, ItemClickEventArgs e)
	{
		_han = (IOverlaySplashScreenHandle)Utilities.ShowProgressPanel(this);
		InvoiceRefresh = false;
		try
		{
			if (SolutionSettings.VisibleScreen == Screens.Training)
			{
				Course.Show.OpenCourses(TrainingGridView);
			}
			else if (SolutionSettings.VisibleScreen == Screens.Clinical)
			{
				Shifts.Show.OpenShift(ClinicalGridView);
			}
		}
		catch (Exception ex)
		{
			Utilities.MyError(ex);
		}
		finally
		{
			Utilities.CloseProgressPanel(_han);
		}
	}

	private void nvTraining_LinkClicked(object sender, NavBarLinkEventArgs e)
	{
		//Try
		MoveScreen(e.Link, Screens.Training, TrainingGridView);
	}

	private void btnNextWeek_ItemClick(object sender, ItemClickEventArgs e)
	{
		_han = (IOverlaySplashScreenHandle)Utilities.ShowProgressPanel(this);
		_weekI += 1;

		if (SolutionSettings.VisibleScreen == Screens.Training)
		{
			Course.ViewBy.Week(ViewDirection.Forward, _weekI, TrainingGridView);
		}
		else if (SolutionSettings.VisibleScreen == Screens.Clinical)
		{
			Shifts.ViewBy.Week(ViewDirection.Forward, _weekI, ClinicalGridView);
		}

		Utilities.CloseProgressPanel(_han);
	}

	private void btnYesterday_ItemClick(object sender, ItemClickEventArgs e)
	{
		_han = (IOverlaySplashScreenHandle)Utilities.ShowProgressPanel(this);

		_dayI -= 1;

		if (SolutionSettings.VisibleScreen == Screens.Training)
		{
			Course.ViewBy.Day(ViewDirection.Previous, _dayI, TrainingGridView);
		}
		else if (SolutionSettings.VisibleScreen == Screens.Clinical)
		{
			Shifts.ViewBy.Day(ViewDirection.Previous, _dayI, ClinicalGridView);
		}
		Utilities.CloseProgressPanel(_han);
	}

	private void btnToday_ItemClick(object sender, ItemClickEventArgs e)
	{
		_han = (IOverlaySplashScreenHandle)Utilities.ShowProgressPanel(this);
		_dayI = 0;
		if (SolutionSettings.VisibleScreen == Screens.Training)
		{
			Course.ViewBy.Day(ViewDirection.Now, _dayI, TrainingGridView);
		}
		else if (SolutionSettings.VisibleScreen == Screens.Clinical)
		{
			Shifts.ViewBy.Day(ViewDirection.Now, _dayI, ClinicalGridView);
		}
		Utilities.CloseProgressPanel(_han);
	}

	private void btnTomorrow_ItemClick(object sender, ItemClickEventArgs e)
	{
		_han = (IOverlaySplashScreenHandle)Utilities.ShowProgressPanel(this);

		_dayI += 1;

		if (SolutionSettings.VisibleScreen == Screens.Training)
		{
			Course.ViewBy.Day(ViewDirection.Forward, _dayI, TrainingGridView);
		}
		else if (SolutionSettings.VisibleScreen == Screens.Clinical)
		{
			Shifts.ViewBy.Day(ViewDirection.Forward, _dayI, ClinicalGridView);
		}
		Utilities.CloseProgressPanel(_han);
	}

	private void btnLastWeek_ItemClick(object sender, ItemClickEventArgs e)
	{
		_han = (IOverlaySplashScreenHandle)Utilities.ShowProgressPanel(this);
		_weekI -= 1;
		if (SolutionSettings.VisibleScreen == Screens.Training)
		{
			Course.ViewBy.Week(ViewDirection.Previous, _weekI, TrainingGridView);


		}
		else if (SolutionSettings.VisibleScreen == Screens.Clinical)
		{
			Shifts.ViewBy.Week(ViewDirection.Previous, _weekI, ClinicalGridView);
		}


		Utilities.CloseProgressPanel(_han);
	}

	private void btnThisWeek_ItemClick(object sender, ItemClickEventArgs e)
	{
		_han = (IOverlaySplashScreenHandle)Utilities.ShowProgressPanel(this);
		_weekI = 0;
		if (SolutionSettings.VisibleScreen == Screens.Training)
		{
			Course.ViewBy.Week(ViewDirection.Now, _weekI, TrainingGridView);
		}
		else if (SolutionSettings.VisibleScreen == Screens.Clinical)
		{
			Shifts.ViewBy.Week(ViewDirection.Now, _weekI, ClinicalGridView);
		}
		Utilities.CloseProgressPanel(_han);
	}

	private void btnLastMonth_ItemClick(object sender, ItemClickEventArgs e)
	{
		_han = (IOverlaySplashScreenHandle)Utilities.ShowProgressPanel(this);
		_monthI -= 1;
		if (SolutionSettings.VisibleScreen == Screens.Training)
		{
			Course.ViewBy.Month(ViewDirection.Previous, _monthI, TrainingGridView);
		}
		else if (SolutionSettings.VisibleScreen == Screens.Clinical)
		{
			Shifts.ViewBy.Month(ViewDirection.Previous, _monthI, ClinicalGridView);
		}
		Utilities.CloseProgressPanel(_han);
	}

	private void btnThisMonth_ItemClick(object sender, ItemClickEventArgs e)
	{
		_han = (IOverlaySplashScreenHandle)Utilities.ShowProgressPanel(this);
		_monthI = 0;
		if (SolutionSettings.VisibleScreen == Screens.Training)
		{
			Course.ViewBy.Month(ViewDirection.Now, 0, TrainingGridView);

		}
		else if (SolutionSettings.VisibleScreen == Screens.Clinical)
		{
			Shifts.ViewBy.Month(ViewDirection.Now, 0, ClinicalGridView);
		}
		Utilities.CloseProgressPanel(_han);
	}

	private void btnNextMonth_ItemClick(object sender, ItemClickEventArgs e)
	{
		_han = (IOverlaySplashScreenHandle)Utilities.ShowProgressPanel(this);
		_monthI += 1;
		if (SolutionSettings.VisibleScreen == Screens.Training)
		{
			Course.ViewBy.Month(ViewDirection.Forward, _monthI, TrainingGridView);
		}
		else if (SolutionSettings.VisibleScreen == Screens.Clinical)
		{
			Shifts.ViewBy.Month(ViewDirection.Forward, _monthI, ClinicalGridView);
		}
		_monthI += 1;
		Utilities.CloseProgressPanel(_han);
	}

	private void btnNewCourse_ItemClick(object sender, ItemClickEventArgs e)
	{
		TrainingClass.AddNewCourse(true, this);
	}

	private void BtnAllCourses_ItemClick(object sender, ItemClickEventArgs e)
	{
		_han = (IOverlaySplashScreenHandle)Utilities.ShowProgressPanel(this);
		try
		{
			if (SolutionSettings.VisibleScreen == Screens.Training)
			{
				courseListTableAdapter.FillAll(trainDataSet.CourseList, SolutionSettings.CurrentUser.TenantLocale);
				_trainingShortLoad = false;
				Course.Show.All(TrainingGridView);
			}
			else if (SolutionSettings.VisibleScreen == Screens.Clinical)
			{
				shiftsTableAdapter.FillAll(ClinicalDataSet.Shifts, SolutionSettings.CurrentUser.TenantLocale);
				_clinicalShortLoad = false;
				Shifts.Show.All(ClinicalGridView);
			}
		}
		catch (Exception ex)
		{
			Utilities.MyError(ex);
		}
		finally
		{
			Utilities.CloseProgressPanel(_han);
		}
	}

	private void btnNotSet_ItemClick(object sender, ItemClickEventArgs e)
	{
		_han = (IOverlaySplashScreenHandle)Utilities.ShowProgressPanel(this);
		try
		{
			if (SolutionSettings.VisibleScreen == Screens.Training)
			{
				Course.Show.NotSet(TrainingGridView);
			}
			else if (SolutionSettings.VisibleScreen == Screens.Clinical)
			{
				Shifts.Show.NotSet(ClinicalGridView);
			}
		}
		catch (Exception ex)
		{
			Utilities.MyError(ex);
		}
		finally
		{
			Utilities.CloseProgressPanel(_han);
		}
	}

	private void btnNotInvoiced_ItemClick(object sender, ItemClickEventArgs e)
	{
		_han = (IOverlaySplashScreenHandle)Utilities.ShowProgressPanel(this);

		if (SolutionSettings.VisibleScreen == Screens.Training)
		{
			_trainingShortLoad = false;
			//RefreshMain(False)
			TrainingGridView.GridControl.BeginUpdate();
			shiftsTableAdapter.FillAll(ClinicalDataSet.Shifts, SolutionSettings.CurrentUser.TenantLocale);
			Course.Show.NotInvoiced(TrainingGridView);
			TrainingGridView.GridControl.EndUpdate();
		}
		else if (SolutionSettings.VisibleScreen == Screens.Clinical)
		{
			_clinicalShortLoad = false;
			ClinicalGridView.GridControl.BeginUpdate();
			shiftsTableAdapter.FillAll(ClinicalDataSet.Shifts, SolutionSettings.CurrentUser.TenantLocale);
			Shifts.Show.NotInvoiced(ClinicalGridView);
			ClinicalGridView.GridControl.EndUpdate();
		}

		Utilities.CloseProgressPanel(_han);
	}

	private void btnOptionsView_ItemClick(object sender, ItemClickEventArgs e)
	{
		try
		{
			_han = (IOverlaySplashScreenHandle)Utilities.ShowProgressPanel(this);
			frmOptions frm = new frmOptions();
			frm.Show(this);

		}
		catch (Exception ex)
		{
			Utilities.MyError(ex);
		}
		finally
		{
			Utilities.CloseProgressPanel(_han);
		}
	}

	private void btnPastNotInvoiced_ItemClick(object sender, ItemClickEventArgs e)
	{

		_han = (IOverlaySplashScreenHandle)Utilities.ShowProgressPanel(this);
		btnShowAll.PerformClick();
		InvoiceRefresh = true;
		if (SolutionSettings.VisibleScreen == Screens.Training)
		{

			_gridHelper.SaveViewInfo(ref TrainingGridView);
			TrainingGridView.ClearColumnsFilter();


			Course.Show.PastNotInvoiced(TrainingGridView);

			_gridHelper.LoadViewInfo(ref TrainingGridView);

		}
		else if (SolutionSettings.VisibleScreen == Screens.Clinical)
		{

			_gridHelper.SaveViewInfo(ref ClinicalGridView);
			ClinicalGridView.ClearColumnsFilter();
			colPrice.Visible = true;
			colInvoiceType.Visible = true;
			ClinicalGridView.BestFitColumns(true);
			shiftsTableAdapter.FillAll(ClinicalDataSet.Shifts, SolutionSettings.CurrentUser.TenantLocale);
			Shifts.Show.PastNotInvoiced(ClinicalGridView);
			_gridHelper.LoadViewInfo(ref ClinicalGridView);
		}
		RefreshHold = true;
		Utilities.CloseProgressPanel(_han);
	}

	private void btnMultiSelect_ItemClick(object sender, ItemClickEventArgs e)
	{

		if (SolutionSettings.VisibleGrid == null)
		{
			return;
			//Utilities.ShowAlert("Visible Grid Empty", "Nothing")
		}

		SolutionSettings.VisibleGrid.OptionsSelection.MultiSelect = !SolutionSettings.VisibleGrid.OptionsSelection.MultiSelect;
		RefreshHold = SolutionSettings.VisibleGrid.OptionsSelection.MultiSelect;

		if (SolutionSettings.VisibleGrid.OptionsSelection.MultiSelect == true)
		{

			SolutionSettings.VisibleGrid.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
			SolutionSettings.VisibleGrid.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DefaultBoolean.True;
			SolutionSettings.VisibleGrid.OptionsSelection.CheckBoxSelectorColumnWidth = 30;
		}
		else
		{
			RefreshMain(false, "Grid Multiselect");
			SolutionSettings.VisibleGrid.OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect;
			SolutionSettings.VisibleGrid.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DefaultBoolean.False;
			SolutionSettings.VisibleGrid.OptionsSelection.CheckBoxSelectorColumnWidth = 30;

		}

		//SolutionSettings.VisibleGrid.RefreshData()

		if (SolutionSettings.VisibleGrid.OptionsSelection.MultiSelect == false)
		{
			RibbonPageBatchUpdate.Enabled = false;
		}
	}

	private void SetItemEnabled(string buttonName, bool value)
	{

		Task.Run(() =>
		{
			NavBarControl1.Invoke(new Action(() =>
			{
				NavBarGroup currGroup = null;
				NavBarItemLink currLink = null;
				try
				{
					int I = 0;
					for (I = 0; I < NavBarControl1.Groups.Count; I++)
					{
						currGroup = NavBarControl1.Groups[I];
						for (var j = 0; j < currGroup.ItemLinks.Count; j++)
						{

							if (currGroup.ItemLinks.Any((x) => x.Caption == buttonName))
							{
								currLink = currGroup.ItemLinks.First((x) => x.Caption == buttonName);
								currLink.Item.Enabled = value;
							}
						}
					}
				}
				catch (Exception ex)
				{
					Utilities.MyError(ex);
				}
			}));
		});
	}

	public void MoveScreen(NavBarItemLink sender, Screens screenName, GridView myGrid)
	{

		if (SolutionSettings.CurrentUser.RestrictedScreens.Contains(screenName))
		{
			Utilities.MessageHelper.NoPermission();
			return;
		}


		SolutionSettings.PropertiesList.Add(new SolutionSettings.Properties()
		{
			Name = "ScreenStart",
			Value = sender.ItemName
		});
		//WriteToRegistry("HKEY_CURRENT_USER\Software\Medicore\Main", "ScreenStart", sender.ItemName())

		SetItemEnabled(sender.Caption, false);
		Timer1.Interval = 20000;
		Timer1.Enabled = false;


		//Core.Security.LogEvent($"Move Screen - Screen: { SolutionSettings.VisibleScreen}", Security.LogLevel.Debug)

		if (screenName != Screens.Personnel)
		{
			SolutionSettings.VisibleScreen = screenName;
		}


		SolutionSettings.VisibleGrid = myGrid;


		if (SolutionSettings.VisibleGrid != null)
		{
			//Core.Security.LogEvent($"Move Screen - Grid: {myGrid.Name}", Security.LogLevel.Debug)
		}
		else
		{
			//Core.Security.LogEvent($"Move Screen - Grid: Nothing", Security.LogLevel.Debug)
		}


		if (SolutionSettings.ShownScreen(screenName) == true)
		{
			MySettings(LoadOption.SaveSettings);
		}
		else
		{

		}

		try
		{
			//Core.Security.LogEvent("Move Screen - Start", Core.Security.LogLevel.Trace)
			_han = (IOverlaySplashScreenHandle)Utilities.ShowProgressPanel(this);

			//RefreshHold = True
			FilterMenu(screenName);
			SolutionSettings.RefreshedScreen.Add(new SolutionSettings.LastUpdate
			{
				ScreenName = screenName,
				MyLasts = DateTime.Now
			});
			switch (screenName)
			{

				case Screens.Clinical:
				{

					_clinicalShortLoad = true;
					tbDashboard.SelectedTabPage = tabClinical;
					Shifts.Show.OpenShift(ClinicalGridView);
					Utilities.ShowRibbonPage(rbnClinical, RibbonControl1);
					//PersonnellTableAdapter.Fill(MainDataSet.Personnell, SolutionSettings.CurrentUser.TenantLocale)


					shiftsTableAdapter.FillOpen(ClinicalDataSet.Shifts, SolutionSettings.CurrentUser.TenantLocale);


					SuperToolTip stip = new SuperToolTip();
					stip.Items.Add("This option is only available for training courses");
					btnPaid.SuperTip = stip;
					btnPaid.Enabled = false;

					if (ClinicalGridView.GroupedColumns.Count == 0)
					{
						btnGridCollapse.Enabled = false;
						btnGridExpand.Enabled = false;
					}
					else
					{
						btnGridCollapse.Enabled = true;
						btnGridExpand.Enabled = true;
					}

					break;
				}
				case Screens.MyHome:
				{
					tbDashboard.SelectedTabPage = tabMyHome;
					Utilities.ShowRibbonPage(rbnMyHome, RibbonControl1);


					if (SolutionSettings.CurrentUser.ImportEmail == true)
					{
						if (bgEmail.IsBusy == false)
						{

							bgEmail.RunWorkerAsync();
						}
					}


					break;
				}
				case Screens.Calendar:
				{
					tbDashboard.SelectedTabPage = tabCalendar;
					Utilities.ShowRibbonPage(rbnMyHome, RibbonControl1);

					schCourses.Start = DateTime.Today;
					schWebView.Start = DateTime.Today;

					schWebView.Refresh();

					if (SolutionSettings.WebSiteAccess == true)
					{
						WebUpcomingTableAdapter.Fill(WebDataSet.WebUpcoming, DateTime.Today.AddDays(- 7), DateTime.Today.AddMonths(1));

					}
					schCourses.GoToToday();

					break;
				}
				case Screens.Training:
				{
					_trainingShortLoad = true;
					Utilities.ShowRibbonPage(rbnTraining, RibbonControl1);
						courseListTableAdapter.FillOpen(trainDataSet.CourseList, SolutionSettings.CurrentUser.TenantLocale);

					tbDashboard.SelectedTabPage = tabTraining;

					if (Networking.IsWebSiteAvailable == true)
					{
						SuperToolTip stip = new SuperToolTip();
						stip.Items.Add("This shows the courses where the invoice has been paid and the course is ready to be certificated.");
						btnPaid.SuperTip = stip;
						btnPaid.Enabled = true;
					}
					else
					{
						SuperToolTip stip = new SuperToolTip();
						stip.Items.Add("This option is only available with a web connection");
						btnPaid.SuperTip = stip;
						btnPaid.Enabled = false;
					}

					if (TrainingGridView.GroupedColumns.Count == 0)
					{
						btnGridCollapse.Enabled = false;
						btnGridExpand.Enabled = false;
					}
					else
					{
						btnGridCollapse.Enabled = true;
						btnGridExpand.Enabled = true;
					}
					Course.Show.ShowCurrent(SolutionSettings.VisibleGrid);

					break;
				}
				case Screens.Personnel:
				{

					frmPeopleCentre frm = new frmPeopleCentre();
					frm.Show(this);

					break;
				}
				case Screens.Assets:
				{

					frmAsset_Main frm = new frmAsset_Main();
					frm.Show(this);

					break;
				}
				case Screens.Projects:
				{
// Dim frm As New DXApplication1.frmProject

					//frm.Show(Me)

				break;
				}
				case Screens.Leads:
				{
					ActivitiesTableAdapter.Fill(LeadsDataSet.Activities, SolutionSettings.CurrentUser.TenantLocale);
					Utilities.ShowRibbonPage(rbnLeads, RibbonControl1);
					tbDashboard.SelectedTabPage = tabLeads;
					btnOpenLeads.PerformClick();
					SystemUsersTableAdapter.Fill(MainDataSet.SystemUsers);
					Lead_ListTableAdapter.Fill(LeadsDataSet.Lead_List);
					myGrid.ExpandAllGroups();

					break;
				}
				case Screens.Governance:
				{
					LoadGovItems();
					LoadGovParentsList();

					Utilities.ShowRibbonPage(rbnGovernance, RibbonControl1);
					tbDashboard.SelectedTabPage = tabGovernance;
					//TreeList1.BeginUpdate()
					//GovTableAdapter.Fill(GovDataSet.Gov);
					//GovStandardsTableAdapter.Fill(GovDataSet.GovStandards);

//TreeList1.PopulateColumns()
//TreeList1.EndUpdate()

					break;
				}
				case Screens.Notes:
				{
					Utilities.ShowRibbonPage(rbnNotes, RibbonControl1);
					tbDashboard.SelectedTabPage = tabNotes;
					BusinessNotesTableAdapter.Fill(MainDataSet.BusinessNotes);

					break;
				}
				case Screens.Risk:
				{
					Utilities.ShowRibbonPage(rbnRisk, RibbonControl1);
					RisksTableAdapter.Fill(MainDataSet.Risks);
					tbDashboard.SelectedTabPage = tabRisk;

					break;
				}
				case Screens.Tasks:
				{
					Utilities.ShowRibbonPage(rbnTasks, RibbonControl1);
					SystemTasksTableAdapter.Fill(TaskDataSet.SystemTasks);
					SystemUsersTableAdapter.Fill(MainDataSet.SystemUsers);
					tbDashboard.SelectedTabPage = tabTasks;

					break;
				}
				case Screens.Documents:
				{
					Utilities.ShowRibbonPage(rbnDocuments, RibbonControl1);
					DocumentsTableAdapter.Fill(MainDataSet.Documents);
					tbDashboard.SelectedTabPage = tabDocuments;

					break;
				}
				case Screens.Info:
				{

				break;
				}
				case Screens.TaskList:
				{
					tbDashboard.SelectedTabPage = tabTaskList;
					TaskListTableAdapter.Fill(MainDataSet.TaskList);
					Utilities.ShowRibbonPage(rbnTaskList, RibbonControl1);

					break;
				}
				case Screens.Audit:
				{
					Utilities.ShowRibbonPage(rbnAudit, RibbonControl1);
					//AuditTableAdapter.Fill(GovDataSet.Audit);
					tbDashboard.SelectedTabPage = tabAudit;
					myGrid.ExpandAllGroups();

					break;
				}
				case Screens.Contacts:
				{

				break;
				}
				case Screens.Flagged:
				{
					//Utilities.ShowRibbonPage(rbnAudit, RibbonControl1)
					Utilities.ShowRibbonPage(rbnFlagged, RibbonControl1);
					NCRTableAdapter.Fill(MainDataSet.NCR);
					PersonnellTableAdapter1.Fill(PersonnellDataSet.Personnell, SolutionSettings.CurrentUser.TenantLocale);
					tbDashboard.SelectedTabPage = tabFlagged;
					SolutionSettings.VisibleGrid.ExpandAllGroups();

					break;
				}
				case Screens.Advisory:
				{

				break;
				}
				case Screens.Quality:
				{
					frmQuality q = new frmQuality();
					q.Show();

					break;
				}
				case Screens.Feedback:
				{

				break;
				}
			}
		}
		catch (Exception ex)
		{
			Utilities.CloseProgressPanel(_han);
			Utilities.MyError(ex);
			RefreshError = true;
		}
		finally
		{
			MySettings(LoadOption.LoadSettings);
			Security.LogEvent("Move Screen - End", Security.LogLevel.Trace);
			Utilities.CloseProgressPanel(_han);
			SetItemEnabled(sender.Caption, true);
			Timer1.Enabled = true;

		}
	}

	private void NvClinical_LinkPressed(object sender, NavBarLinkEventArgs e)
	{
		MoveScreen(e.Link, Screens.Clinical, ClinicalGridView);
	}

	private void NvHome_LinkPressed(object sender, NavBarLinkEventArgs e)
	{
		if (sender == null)
		{
			// ReSharper disable once RedundantAssignment
			sender = nvHome;
		}

		MoveScreen(e.Link, Screens.MyHome, grdMyInbox);
	}

	public void BtnRefresh_ItemClick(object sender, ItemClickEventArgs e)
	{
		if (InvokeRequired)
		{
			Invoke(new Action(() =>
			{
				RefreshMain(false, "Refresh Button - Invoke");
			}));
		}
		else
		{
			RefreshMain(false, "Refresh Button - Non Invoke");
		}
	}

	public enum LoadOption
	{
		LoadSettings,
		SaveSettings
	}

	private void MySettings(LoadOption settingOption)
	{
		switch (SolutionSettings.VisibleScreen)
		{
			case Screens.Governance:
				if (settingOption == LoadOption.LoadSettings)
				{

					TreeList1.RestoreLayoutFromRegistry("Software\\Medicore\\Dashboard\\");
					SplitContainerControl2.RestoreLayoutFromRegistry("Software\\Medicore\\Dashboard\\");
					_gridHelper.SaveViewInfo(ref GovGrid);
					GovStandardsGridControl.MainView.RestoreLayoutFromRegistry("Software\\Medicore\\Dashboard\\");
					_gridHelper.LoadViewInfo(ref GovGrid);
					_treeState.LoadState();
					TreeList1.BeginSort();
					TreeList1.Columns["Sort"].SortOrder = SortOrder.Ascending;
					TreeList1.Columns["Section"].SortOrder = SortOrder.Ascending;
					TreeList1.EndSort();
				}
				else
				{

					TreeList1.SaveLayoutToRegistry("Software\\Medicore\\Dashboard\\");
					_treeState.SaveState();
					SplitContainerControl2.SaveLayoutToRegistry("Software\\Medicore\\Dashboard\\");
					GovStandardsGridControl.MainView.SaveLayoutToRegistry("Software\\Medicore\\Dashboard\\");
				}
				break;
		}
	}

	public void RefreshMain(bool forceRefresh, string caller)
	{
		//Core.CommunicationHelper.SendMatterMost($"Max attempted logins for  on system ", "r856e7ockfrotphx36qwwccc6w")
		//Core.Security.LogEvent($"Main Refresh: {caller}", Core.Security.LogLevel.Debug)
		//Core.Security.LogEvent($"Main Refresh Required: {SolutionSettings.RefreshRequired}",Core.Security.LogLevel.Debug)


		// Stop a double call.
		if (Refreshing)
		{
			return;
		}


		if (SolutionSettings.RefreshRequired == true)
		{

			forceRefresh = true;

		}

		if (RefreshHold == true)
		{
			if (forceRefresh == false)
			{
				brInfo.Visibility = BarItemVisibility.Always;
				brInfo.Caption = "Refresh Hold";
				return;
			}
		}
		else
		{
			brInfo.Visibility = BarItemVisibility.Never;
		}



		if (_refreshCounter >= 6)
		{
			Task.Run(() =>
			{
				SuperToolTip stip = new SuperToolTip();
				stip.Items.AddTitle("Logged In Users:");
				stip.Items.Add(Utilities.PrintList(Networking.LoggedInUsers));
				brLoggedUsers.SuperTip = stip;
				brLoggedUsers.Caption = Networking.LoggedInUserCount + " users logged In.";
				_refreshCounter = 0;
			});

		}


		if (_errorCount >= 3)
		{
			Security.LogEvent($"Main Refresh:  Error Count >3", Security.LogLevel.Error);
			brInfo.Visibility = BarItemVisibility.Always;
			brInfo.Caption = "System is in error state!";
			return;
		}


		MySettings(LoadOption.SaveSettings);

		if (RefreshError == true)
		{
			Security.LogEvent($"Main Refresh: Refresh Error with Emails", Security.LogLevel.Error);
			brInfo.Visibility = BarItemVisibility.Always;
			brInfo.Caption = "Refresh Error with Emails";
		}

		if (SolutionSettings.VisibleGrid != null)
		{

			DevExpress.XtraGrid.Views.Grid.GridView tempVar = SolutionSettings.VisibleGrid;
			_gridHelper.SaveViewInfo(ref tempVar);
			SolutionSettings.VisibleGrid = tempVar;

			if (SolutionSettings.VisibleGrid.OptionsSelection.MultiSelect == true && forceRefresh == false)
			{
				Security.LogEvent($"Main Refresh HOLD SET TRUE", Security.LogLevel.Warn);
				RefreshHold = true;
			}
		}
		else
		{

			return;

		}


		brInfo.Visibility = BarItemVisibility.Never;

		if (RefreshHold == true)
		{
			if (forceRefresh == false)
			{
				brInfo.Visibility = BarItemVisibility.Always;
				brInfo.Caption = "Refresh Hold";
				return;
			}
		}
		else
		{
			brInfo.Visibility = BarItemVisibility.Never;
		}
		Task.Run(() =>
		{
			RefreshThread();
		});
	}


	private void RefreshThread()
	{

		Invoke(new Action(() =>
		{
			try
			{

				Refreshing = true;
				Timer1.Stop();

				switch (SolutionSettings.VisibleScreen)
				{
					case Screens.Training:


						if (General.ScreenNeedsUpdating(SolutionSettings.VisibleScreen))
						{


							//SolutionSettings.VisibleGrid.BeginDataUpdate()
							if (_trainingShortLoad)
							{
								courseListTableAdapter.FillOpen(trainDataSet.CourseList, SolutionSettings.CurrentUser.TenantLocale);
							}
							else
							{
								courseListTableAdapter.FillAll(trainDataSet.CourseList, SolutionSettings.CurrentUser.TenantLocale);
							}

							if (RefreshCount >= 20)
							{
								if (Networking.IsWebSiteAvailable)
								{
									Task.Run(() =>
									{
										Course.Web.ImportWebStudents();
									});

									RefreshCount = 0;
								}
								else
								{
									//
									//ToastNotificationsManager1.ShowNotification(ToastNotificationsManager1.Notifications(3))
									RefreshCount = 0;
								}
							}
							else
							{
								RefreshCount += 1;
							}

						}


						break;
					case Screens.Clinical:

						if (General.ScreenNeedsUpdating(SolutionSettings.VisibleScreen))
						{

							if (InvoiceRefresh)
							{

								shiftsTableAdapter.FillAll(ClinicalDataSet.Shifts, SolutionSettings.CurrentUser.TenantLocale);
								Shifts.Show.PastNotInvoiced(ClinicalGridView);

							}
							else
							{
								if (_clinicalShortLoad)
								{
									shiftsTableAdapter.FillOpen(ClinicalDataSet.Shifts, SolutionSettings.CurrentUser.TenantLocale);
								}
								else
								{

									shiftsTableAdapter.FillAll(ClinicalDataSet.Shifts, SolutionSettings.CurrentUser.TenantLocale);
								}

							}


						}


						break;
					case Screens.MyHome:
						if (RefreshError == false)
						{

							if (TabPane1.SelectedPage.Caption == "Inbox")
							{
								if (Utilities.Email.HasError == false)
								{
									_gridHelper.SaveViewInfo(ref grdMyInbox);

									if (bgEmail.IsBusy == false)
									{
										if (SolutionSettings.CurrentUser.ImportEmail == true)
										{
											bgEmail.RunWorkerAsync();
										}

									}
								}
							}
							else
							{

							}
						}
						else
						{

						}

						break;
					case Screens.Leads:
						ActivitiesTableAdapter.Fill(LeadsDataSet.Activities, SolutionSettings.CurrentUser.TenantLocale);
						LeadsByCourseTableAdapter.Fill(LeadsDataSet.LeadsByCourse, (BarEditItem4.EditValue == null ? null : Convert.ToString(BarEditItem4.EditValue)));


						break;
					case Screens.Governance:

						//stops refresh while text editing is happening.
						if (TreeList1.ActiveEditor == null)
						{
							if (_forceMainRefresh == true || TreeList1.Selection.Count <= 1)
							{

								TreeList1.BeginUpdate();
								_treeState.SaveState();

								if (TreeList1.Nodes.Count > 0)
								{
									int fn = 0;
									if (TreeList1.FocusedNode == null)
									{
										fn = 0;
									}
									else
									{
										fn = TreeList1.FocusedNode.Id;
									}
									_gridHelper.SaveViewInfo(ref GovGrid);
									//GovTableAdapter.Fill(GovDataSet.Gov);
									_gridHelper.LoadViewInfo(ref GovGrid);
									TreeList1.BeginSort();
									TreeList1.Columns["Sort"].SortOrder = SortOrder.Ascending;
									TreeList1.Columns["Section"].SortOrder = SortOrder.Ascending;
									TreeList1.EndSort();
									Task.Run(() =>
									{
										MySettings(LoadOption.SaveSettings);
									});

									_treeState.LoadState();
									TreeList1.FocusedNode = TreeList1.FindNodeByID(fn);
									TreeList1.EndUpdate();
								}
							}
							else
							{

							}
						}

						if (btnFindAfterDrag.Checked == true)
						{
							_gridHelper.SaveViewInfo(ref GovGrid);
						}

						GovGrid.BeginDataUpdate();
						LoadGovItems();
						LoadGovParentsList();
						//GovStandardsTableAdapter.Fill(GovDataSet.GovStandards);

						GovGrid.EndDataUpdate();
						if (btnFindAfterDrag.Checked == true)
						{
							_gridHelper.LoadViewInfo(ref GovGrid);
						}

						break;
					case Screens.Calendar:

						UpdateScheduler();

						break;
					case Screens.Personnel:

					break;
					case Screens.Assets:

					break;
					case Screens.TaskList:
						TaskListTableAdapter.Fill(MainDataSet.TaskList);

						break;
					case Screens.Notes:
						//_gridhelperGroup.SaveViewInfo(TileView1)
						TileView1.BeginDataUpdate();
						BusinessNotesTableAdapter.Fill(MainDataSet.BusinessNotes);
						//_gridhelperGroup.SaveViewInfo(TileView1)
						TileView1.EndDataUpdate();
						break;
					case Screens.Documents:

						DocumentsTableAdapter.Fill(MainDataSet.Documents);

						break;
					case Screens.Risk:

						GridView11.BeginDataUpdate();
						RisksTableAdapter.Fill(MainDataSet.Risks);

						break;
					case Screens.Info:

					break;
					case Screens.Audit:

						//_gridHelper.SaveViewInfo(grdAudit)
						grdAudit.BeginDataUpdate();
						//AuditTableAdapter.Fill(GovDataSet.Audit);
						//_gridHelper.LoadViewInfo(grdAudit)
						grdAudit.EndDataUpdate();

						break;
					case Screens.Contacts:

					break;
					case Screens.Tasks:
						DevExpress.XtraGrid.Views.Grid.GridView tempVar = SolutionSettings.VisibleGrid;
						_gridHelper.SaveViewInfo(ref tempVar);
						SolutionSettings.VisibleGrid = tempVar;
						SolutionSettings.VisibleGrid.BeginDataUpdate();
						SystemTasksTableAdapter.Fill(TaskDataSet.SystemTasks);
						DevExpress.XtraGrid.Views.Grid.GridView tempVar2 = SolutionSettings.VisibleGrid;
						_gridHelper.LoadViewInfo(ref tempVar2);
						SolutionSettings.VisibleGrid = tempVar2;
						SolutionSettings.VisibleGrid.EndDataUpdate();

						break;
					case Screens.Flagged:
						NCRTableAdapter.Fill(MainDataSet.NCR);
						break;
				}
				_errorCount = 0;
			}
			catch (Exception ex)
			{
				_errorCount += 1;
				Utilities.ShowToast("Refresh Error", "An error occurred while the refresh function was active on this computer");
				RefreshError = true;
				Utilities.MyError(ex);
			}
			finally
			{


				this.RefreshCount += 1;

				Refreshing = false;

				if (SolutionSettings.VisibleGrid != null)
				{
					//Core.Security.LogEvent($"Load Main Refresh: {SolutionSettings.VisibleGrid.Name}",Security.LogLevel.Debug)
					DevExpress.XtraGrid.Views.Grid.GridView tempVar3 = SolutionSettings.VisibleGrid;
					_gridHelper.LoadViewInfo(ref tempVar3);
					SolutionSettings.VisibleGrid = tempVar3;

				}
				else
				{
					//Core.Security.LogEvent("Main Refresh: Visible Grid is nothing", Security.LogLevel.Warn)
				}
				Timer1.Start();

			}
		}));
	}

	private void nvCalendar_LinkClicked(object sender, NavBarLinkEventArgs e)
	{

		MoveScreen(e.Link, Screens.Calendar, null);
	}

	private void schCourses_Click(object sender, EventArgs e)
	{
		try
		{

			Security.LogEvent("Scheduler Clicked", Security.LogLevel.Trace);
			if (schCourses.SelectedAppointments.Count == 1)
			{
				object o = schCourses.SelectedAppointments[0];
				if (o == null)
				{
					return;

				}

				Cursor = Cursors.Default;
				Appointment appointment = (Appointment)schCourses.SelectedAppointments[0];
				if (SolutionSettings.SchedulerSource == DataSource.General)
				{
					switch (appointment.CustomFields["ItemType"].ToString())
					{
						case "Course":

							if (SolutionSettings.CurrentUser.RestrictedScreens.Contains(Screens.Training))
							{
								Utilities.MessageHelper.NoPermission();
								return;
							}

							_han = (IOverlaySplashScreenHandle)Utilities.ShowProgressPanel(this);
							Security.LogEvent("Training Form created", Security.LogLevel.Trace);
							frmCourse_Details frm = new frmCourse_Details(this);
							Security.LogEvent("Training form Loads OK", Security.LogLevel.Trace);
							if (frm.LoadDetails(Convert.ToInt32(appointment.CustomFields["ID"]), true))
							{
								Security.LogEvent("Sanity Check OK - Show Dialog", Security.LogLevel.Trace);
								frm.Show(this);
							}
							else
							{
								throw new Exception("Course Sanity Check Error");
							}

							Utilities.CloseProgressPanel(_han);

							break;
						case "Shift":
							if (SolutionSettings.CurrentUser.RestrictedScreens.Contains(Screens.Clinical))
							{
								Utilities.MessageHelper.NoPermission();
								return;
							}
							_han = (IOverlaySplashScreenHandle)Utilities.ShowProgressPanel(this);
							frmShift_Details details2 = new frmShift_Details(this);
							details2.LoadDetails(Utilities.SafeInt(appointment.CustomFields["ID"]));
							details2.Show(this);
							Utilities.CloseProgressPanel(_han);

							break;
						case "Meeting":
							frmAppointment_Details details3 = new frmAppointment_Details(this);
							details3.LoadDetails(Convert.ToInt32(appointment.CustomFields["ID"]));

							details3.Show(this);
							break;
					}
				}
				else
				{
					if (appointment.CustomFields["Status"].ToString() == "Available")
					{
						XtraMessageBox.Show("Do you want to convert this availability to a Not Set or New Course?");
					}
					if (appointment.CustomFields["Status"].ToString() == "Not Available")
					{
						XtraMessageBox.Show("Not available");
					}
				}
			}
		}
		catch (Exception exception1)
		{

			Utilities.MyError(exception1);
		}
		finally
		{
			Cursor = Cursors.Default;
		}
	}

	private void SchedulerStorage_FetchAppointments(object sender, FetchAppointmentsEventArgs e)
	{
		try
		{
			//SchedulerControl1.ActiveView.LayoutChanged()

			_startDate = schCourses.ActiveView.GetVisibleIntervals().Start;
			_finishDate = schCourses.ActiveView.GetVisibleIntervals().End;
			//Debug.Print(_startDate.Date.AddDays(-30) & " " & _finishDate.Date.AddDays(30))
			UpcomingTableAdapter.Fill(MainDataSet.Upcoming, _startDate.Date.AddDays(- 30), _finishDate.Date.AddDays(30), SolutionSettings.CurrentUser.TenantLocale);
		}
		catch (Exception ex)
		{
			Utilities.MyError(ex);
		}
		//SchedulerControl1.ActiveView.LayoutChanged()
	}

	private void UpdateScheduler()
	{
		try
		{
			schWebView.BeginUpdate();
			SchedulerStorage.RefreshData();
		}
		catch (Exception ex)
		{
			Utilities.MyError(ex);
		}
		finally
		{
			schWebView.EndUpdate();

		}
	}

	private void btnPastOpen_ItemClick(object sender, ItemClickEventArgs e)
	{
		try
		{
			if (SolutionSettings.VisibleScreen == Screens.Clinical)
			{
				Shifts.Show.PastOpen(ClinicalGridView);
			}
			else if (SolutionSettings.VisibleScreen == Screens.Training)
			{
				Course.Show.PastOpenCourses(TrainingGridView);
			}
		}
		catch (Exception ex)
		{
			Utilities.MyError(ex);
		}
	}

	private void schCourses_AppointmentViewInfoCustomizing(object sender, AppointmentViewInfoCustomizingEventArgs e)
	{
		try
		{

			if (SolutionSettings.SchedulerSource == DataSource.General)
			{
				if (e.ViewInfo.Appointment.CustomFields["ItemType"].ToString() == "Shift")
				{

					if (e.ViewInfo.Appointment.CustomFields["Sub"].ToString() == "Static Cover")
					{
						e.ViewInfo.Appearance.BackColor = SolutionSettings.Colours.Shift;
						e.ViewInfo.Appearance.ForeColor = Color.Navy;
					}
					else
					{
						e.ViewInfo.Appearance.BackColor = SolutionSettings.Colours.AmbulanceShift;
						e.ViewInfo.Appearance.ForeColor = Color.White;
					}
				}
				if (e.ViewInfo.Appointment.CustomFields["ItemType"].ToString() == "Course")
				{
					// (e.ViewInfo.Appointment.StatusKey.ToString)
					if (e.ViewInfo.Appointment.StatusKey.ToString() == "Cancelled" || e.ViewInfo.Appointment.StatusKey.ToString() == "Deferred")
					{
						e.ViewInfo.Appearance.BackColor = SolutionSettings.Colours.Cancelled;
						e.ViewInfo.Appearance.ForeColor = Color.Navy;
						e.ViewInfo.Appearance.Font = new Font(e.ViewInfo.Appearance.Font, FontStyle.Strikeout);
					}
					else
					{
						e.ViewInfo.Appearance.BackColor = SolutionSettings.Colours.Course;
						e.ViewInfo.Appearance.ForeColor = Color.Navy;
					}

				}
				if (e.ViewInfo.Appointment.CustomFields["ItemType"].ToString() == "Meeting")
				{
					e.ViewInfo.Appearance.BackColor = SolutionSettings.Colours.Meeting;
					e.ViewInfo.Appearance.ForeColor = Color.Navy;
				}
				if (e.ViewInfo.Appointment.CustomFields["TableSort"].ToString() == "2")
				{
					e.ViewInfo.Appearance.BackColor = SolutionSettings.Colours.NotSet;
					e.ViewInfo.Appearance.ForeColor = Color.Navy;

				}

			}
			else if ((SolutionSettings.SchedulerSource == DataSource.Medic) || (SolutionSettings.SchedulerSource == DataSource.Instructors))
			{

				switch (e.ViewInfo.Appointment.StatusKey.ToString())
				{

					case "Available":

						e.ViewInfo.Appearance.BackColor = SolutionSettings.Colours.MedicAvailable;
						e.ViewInfo.Appearance.ForeColor = Color.White;
// (e.ViewInfo.Appearance.ForeColor.ToString())
						break;
					case "Not Available":

						e.ViewInfo.Appearance.BackColor = Color.FromArgb(Convert.ToInt32("#FFFFC2BE"));
						e.ViewInfo.Appearance.ForeColor = Color.WhiteSmoke;

						break;
					case "Part-Available":

						e.ViewInfo.Appearance.BackColor = Color.Orange;
						e.ViewInfo.Appearance.ForeColor = Color.Navy;

						break;
				}

			}
			else if (SolutionSettings.SchedulerSource == DataSource.Person)
			{
				if (e.ViewInfo.Appointment.CustomFields["ItemType"].ToString() == "Shift")
				{
					e.ViewInfo.Appearance.BackColor = SolutionSettings.Colours.Shift;
				}
				if (e.ViewInfo.Appointment.CustomFields["ItemType"].ToString() == "Course")
				{
					e.ViewInfo.Appearance.BackColor = SolutionSettings.Colours.Course;
				}
				if (Convert.ToString(e.ViewInfo.Appointment.CustomFields["ItemType"]) != "Calendar" && e.ViewInfo.Appointment.Subject == "Available")
				{
					e.ViewInfo.Appearance.BackColor = Color.LemonChiffon;
				}
				if (Convert.ToString(e.ViewInfo.Appointment.CustomFields["ItemType"]) != "Calendar" && e.ViewInfo.Appointment.Subject == "Not Available")
				{
					e.ViewInfo.Appearance.BackColor = SolutionSettings.Colours.Cancelled;
				}
			}
			// (e.ViewInfo.Appearance.BackColor.ToString)
		}
		catch (Exception ex)
		{
			Utilities.MyError(ex);
		}
	}

	private void ClinicalGridView_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
	{


		//Try
		//Debug.Print(ClinicalGridView.GetRowCellValue(e.RowHandle, "ID"))
		if (e.Column.Name == "DX$CheckboxSelectorColumn" || e.Column.Name == "colID")
		{
			_selectedColumn = string.Empty;

		}
		else if (e.Column.FieldName == "ID")
		{
			_selectedColumn = string.Empty;
		}
		else if (e.Column.FieldName == "Location")
		{
			_selectedColumn = "Location"; //String.Empty
		}
		else if (e.Column.FieldName == colMedicID.FieldName)
		{
			_selectedColumn = string.Empty;
			frmPersonnel_Details frm = new frmPersonnel_Details(null);
			frm.LoadDetails(Convert.ToInt32(ClinicalGridView.GetRowCellValue(e.RowHandle, "MedicID")), true);
			frm.ShowDialog();
		}
		else
		{
			_selectedColumn = e.Column.FieldName;
			_selectedColumnType = e.Column.ColumnType;
		}

		if (e.Column.FieldName == "ID")
		{
			TrainingClass.OpenShift(Convert.ToInt32(e.CellValue), this);
		}
		else if (e.Column.Name == "DX$CheckboxSelectorColumn")
		{
			if (TrainingGridView.IsRowSelected(e.RowHandle) == true)
			{
				Shifts.ClearTempCertRows(Convert.ToInt32(ClinicalGridView.GetRowCellValue(e.RowHandle, "ID")));
			}
			else
			{
				Shifts.SetTempRows(Convert.ToInt32(ClinicalGridView.GetRowCellValue(e.RowHandle, "ID")));
			}
		}

		if (e.Column.Name == "GridColumn2")
		{
			if (Convert.ToBoolean(e.CellValue) == true && Networking.NetworkSharesAvailable == true)
			{
				Utilities.FileHelper.LaunchFile(Shifts.Details.GetShiftPaperworkPath(Convert.ToInt32(ClinicalGridView.GetRowCellValue(e.RowHandle, "ID"))));
			}
		}
		//Catch ex As System.Exception
		//MyError(ex)
		//End Try
	}

	private void btnFindStudents_ItemClick(object sender, ItemClickEventArgs e)
	{
		Utilities.ScreenWait();
		frmStudentRegister frm = new frmStudentRegister();
		frm.ShowDialog();
		Utilities.CloseProgressPanel(_han);
	}

	//Private Sub nvPersonnel_LinkPressed(sender As Object, e As NavBarLinkEventArgs) Handles nvPersonnel.LinkPressed
	// ("MOve")
	// MoveScreen(e.Link, Screens.Personnel, AdvBandedGridView1)
	//End Sub

	//Private Sub btnViewbyInstructors_ItemClick(sender As Object, e As ItemClickEventArgs) _
	// Handles btnViewbyInstructors.ItemClick

	// Try
	// btnAvailabilityPerson.Enabled = False
	// Personnel.ViewBy.Instructor(btnShowInactive.EditValue, AdvBandedGridView1)
	// _mapMode = 2
	// Catch ex As System.Exception

	// End Try
	//End Sub

	private void btnViewbyMedics_ItemClick(object sender, ItemClickEventArgs e)
	{
		try
		{
			//btnAvailabilityPerson.Enabled = False
			//Personnel.ViewBy.Medic(btnShowInactive.EditValue, AdvBandedGridView1)
			//_mapMode = 1
		}
		catch (Exception ex)
		{

		}
	}

	private void brByCourse_EditValueChanged(object sender, EventArgs e)
	{
		//Try
		// PersonGridControl.BeginUpdate()
		// PersonGridControl.DataSource = Nothing
		// AdvBandedGridView1.ClearColumnsFilter()
		// PersonnellDataSet.EnforceConstraints = False
		// PeopleByCourseTableAdapter1.FillByCourse(PersonnellDataSet.PeopleByCourse, brByCourse.EditValue.ToString)
		// PersonGridControl.DataSource = PeopleByCourseBindingSource

		// 'Me.PersonnellDataSet.EnforceConstraints = True
		//Catch ex As System.Exception
		// MyError(ex)
		// 'PersonGridControl.ForceInitialize()
		//Finally
		// PersonGridControl.EndUpdate()
		//End Try
	}

	private void btnResetPersonnelView_ItemClick(object sender, ItemClickEventArgs e)
	{
		//PersonGridControl.BeginUpdate()
		//PersonGridControl.DataSource = Nothing
		//' Me.PeopleByCourseTableAdapter1.FillByCourse(Me.PersonnellDataSet.PeopleByCourse, brByCourse.EditValue.ToString)
		//PersonnellTableAdapter1.Fill(PersonnellDataSet.Personnell)
		//PersonGridControl.DataSource = PersonnellBindingSource1
		//PersonGridControl.EndUpdate()
		//brByCourse.EditValue = String.Empty
	}

	private void btnAddSingleShift_ItemClick(object sender, ItemClickEventArgs e)
	{

		try
		{
			TrainingClass.OpenShift(TrainingClass.AddSingleShift(), this);
		}
		catch (Exception ex)
		{
			Utilities.MyError(ex);
		}
	}

	private void btnBatchUpdate_ItemClick(object sender, ItemClickEventArgs e)
	{
		switch (SolutionSettings.VisibleScreen)
		{
			case Screens.Clinical:
				switch (XtraMessageBox.Show("This will update multiple Shifts." + "\r" + "\n" + "\r" + "\n" + "Please click on the cell you want to update.", "Update Rows", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
				{
					case System.Windows.Forms.DialogResult.OK:
						if (bgwCourseUpdate.IsBusy == true)
						{
							XtraMessageBox.Show("The background working Is currently working!", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Information);
						}
						else
						{
							bgwCourseUpdate.RunWorkerAsync();
						}

						break;
				}

				break;
			case Screens.Training:
				switch (XtraMessageBox.Show("This will update multiple Courses." + "\r" + "\n" + "\r" + "\n" + "Please click on the cell you want to update.", "Update Rows", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
				{
					case System.Windows.Forms.DialogResult.OK:
						if (bgwCourseUpdate.IsBusy == true)
						{
							XtraMessageBox.Show("The background working Is currently working!", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Information);
						}
						else
						{
							bgwCourseUpdate.RunWorkerAsync();
						}

						break;
				}
				break;
		}
	}

	private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
	{
		try
		{
			while (string.IsNullOrEmpty(_selectedColumn) == true)
			{
				Thread.Sleep(500);
			}

			if (_selectedColumn == null || string.IsNullOrEmpty(_selectedColumn))
			{
				brInfo.Visibility = BarItemVisibility.Always;
				brInfo.Caption = _selectedColumn + " cannot be updated";
				return;
			}

			string str = Utilities.InputHelper.InputBox(_selectedColumnType, string.Format("Update Values for {0}", _selectedColumn), "Enter the New cell values." + Environment.NewLine + " 'NULL' for Null values.");

			// "Update Column: " & _selectedColumn.ToString, String.Empty)
			//XtraInputBox.Show("Enter the new cell values." & Environment.NewLine & " 'NULL' for Null values.",
			// "Update Column: " & _selectedColumn.ToString, String.Empty) _
			//Interaction.InputBox("Please enter the value you want to update the cells to", ("Update Column: " & Me.SelectedColumn.ToString), Nothing, -1, -1)

			switch (SolutionSettings.VisibleScreen)
			{
				case Screens.Clinical:

					if (Utilities.DataHelper.IsNullOrEmpty(str) == false)
					{

						List<int> selected = new List<int>();
//INSTANT C# NOTE: The ending condition of VB 'For' loops is tested only on entry to the loop. Instant C# has created a temporary variable in order to use the initial value of ClinicalGridView.DataRowCount - 1 for every iteration:
						int tempVar = ClinicalGridView.DataRowCount - 1;
						for (var i = 0; i <= tempVar; i++)
						{

							if (ClinicalGridView.IsRowSelected(i))
							{
								selected.Add(Utilities.SafeInt(ClinicalGridView.GetRowCellValue(i, "ID")));
								//Dim sId As Integer =
								if (str == "NULL")
								{
									str = null;
								}

							}
						}
						Shifts.UpdateShiftDetails(selected, _selectedColumn, str);
						Security.LogEvent(("Batch updated: " + _selectedColumn + " to " + str), Security.AuditType.Shift, selected);

						_selectedColumn = string.Empty;
						XtraMessageBox.Show((Utilities.SafeString(selected.Count) + " shifts have been successfully updated."), "Completed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					}
					break;
				case Screens.Training:

					if (Utilities.DataHelper.IsNullOrEmpty(str) == false)
					{
						List<int> selectedId = new List<int>();
//INSTANT C# NOTE: The ending condition of VB 'For' loops is tested only on entry to the loop. Instant C# has created a temporary variable in order to use the initial value of TrainingGridView.DataRowCount - 1 for every iteration:
						int tempVar2 = TrainingGridView.DataRowCount - 1;
						for (var i = 0; i <= tempVar2; i++)
						{
							if (TrainingGridView.IsRowSelected(i))
							{
								selectedId.Add(Utilities.SafeInt(TrainingGridView.GetRowCellValue(i, "ID")));
								if (str == "NULL")
								{
									str = null;
								}
							}
						}

						Course.Details.UpdateCourseDetails(selectedId, _selectedColumn, str);
						Security.LogEvent(("Batch updated: " + _selectedColumn + " to " + str), Security.AuditType.Course, selectedId);

						_selectedColumn = string.Empty;
						XtraMessageBox.Show((Utilities.SafeString(selectedId.Count) + " courses have been successfully updated."), "Completed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					}
					break;
			}
		}
		catch (Exception ex)
		{
			Utilities.CloseProgressPanel(_han);
			Utilities.MyError(ex);
		}
		finally
		{
			Utilities.CloseProgressPanel(_han);
		}
	}

	public void LoadGridRulesFormat()
	{
		var gridFormatRule1 = new GridFormatRule();
		var gridFormatRule10 = new GridFormatRule();
		var formatConditionRuleValue1 = new FormatConditionRuleValue();
		var formatConditionRuleValue10 = new FormatConditionRuleValue();
		var gridFormatRule2 = new GridFormatRule();
		var formatConditionRuleValue2 = new FormatConditionRuleValue();
		var gridFormatRule3 = new GridFormatRule();
		var formatConditionRuleExpression1 = new FormatConditionRuleExpression();
		var gridFormatRule4 = new GridFormatRule();
		var formatConditionRuleValue3 = new FormatConditionRuleValue();
		var gridFormatRule40 = new GridFormatRule();
		var formatConditionRuleValue30 = new FormatConditionRuleValue();
		var gridFormatRule5 = new GridFormatRule();
		var formatConditionRuleExpression2 = new FormatConditionRuleExpression();
		var gridFormatRule11 = new GridFormatRule();
		var formatConditionRuleExpression11 = new FormatConditionRuleExpression();
		var gridFormatRule50 = new GridFormatRule();
		var formatConditionRuleExpression20 = new FormatConditionRuleExpression();
		var gridFormatRule51 = new GridFormatRule();

		gridFormatRule1.ApplyToRow = true;
		gridFormatRule1.Column = colInstructor;
		gridFormatRule1.Name = "Not Set";
		formatConditionRuleValue1.Appearance.BackColor = SolutionSettings.Colours.NotSet;
		formatConditionRuleValue1.Appearance.BackColor2 = Color.White;
		formatConditionRuleValue1.Appearance.ForeColor = Color.Black;
		formatConditionRuleValue1.Appearance.Options.UseBackColor = true;
		formatConditionRuleValue1.Condition = FormatCondition.Equal;
		formatConditionRuleValue1.Value1 = "NOT SET";
		gridFormatRule1.Rule = formatConditionRuleValue1;

		gridFormatRule10.ApplyToRow = true;
		gridFormatRule10.Column = colMedicID;
		gridFormatRule10.Name = "Not Set";
		formatConditionRuleValue10.Appearance.BackColor = SolutionSettings.Colours.NotSet;
		formatConditionRuleValue10.Appearance.BackColor2 = Color.White;
		formatConditionRuleValue10.Appearance.ForeColor = Color.Black;
		formatConditionRuleValue10.Appearance.Options.UseBackColor = true;
		formatConditionRuleValue10.Condition = FormatCondition.Equal;
		formatConditionRuleValue10.Value1 = "85";
		gridFormatRule10.Rule = formatConditionRuleValue10;

		gridFormatRule2.ApplyToRow = true;
		gridFormatRule2.Column = colStatus;
		gridFormatRule2.Name = "Defered";
		formatConditionRuleValue2.Appearance.BackColor = SolutionSettings.Colours.Deferred;
		formatConditionRuleValue2.Appearance.BackColor2 = Color.White;
		formatConditionRuleValue2.Appearance.ForeColor = Color.Black;
		formatConditionRuleValue2.Appearance.Options.UseBackColor = true;
		formatConditionRuleValue2.Condition = FormatCondition.Equal;
		formatConditionRuleValue2.Value1 = "Deferred";
		gridFormatRule2.Rule = formatConditionRuleValue2;

		gridFormatRule3.ApplyToRow = true;
		gridFormatRule3.Name = "Urgent";
		formatConditionRuleExpression1.Appearance.BackColor = SolutionSettings.Colours.Warning;
		formatConditionRuleExpression1.Appearance.BackColor2 = Color.White;
		formatConditionRuleExpression1.Appearance.ForeColor = Color.Black;
		formatConditionRuleExpression1.Appearance.Options.UseBackColor = true;
		formatConditionRuleExpression1.Expression = "DateDiffDay(Today(), [DateofCourse]) < 14 And [Instructor] = 'NOT SET' And [Status] = 'Waiting'";
		gridFormatRule3.Rule = formatConditionRuleExpression1;

		gridFormatRule11.ApplyToRow = true;
		gridFormatRule11.Name = "Urgent";
		formatConditionRuleExpression11.Appearance.BackColor = SolutionSettings.Colours.Warning;
		formatConditionRuleExpression11.Appearance.BackColor2 = Color.White;
		formatConditionRuleExpression11.Appearance.ForeColor = Color.Black;
		formatConditionRuleExpression11.Appearance.Options.UseBackColor = true;
		formatConditionRuleExpression11.Expression = "DateDiffDay(Today(), [DutyDate]) < 14 And [MedicID] = '85' And [Status] = 'Open'";
		gridFormatRule11.Rule = formatConditionRuleExpression11;

		gridFormatRule4.ApplyToRow = true;
		gridFormatRule4.Column = colStatus;
		gridFormatRule4.Name = "Cancelled";
		formatConditionRuleValue3.Appearance.BackColor = SolutionSettings.Colours.Cancelled;
		formatConditionRuleValue3.Appearance.BackColor2 = Color.White;
		formatConditionRuleValue3.Appearance.ForeColor = Color.Black;
		formatConditionRuleValue3.Appearance.Font = new Font("Tahoma", formatConditionRuleValue3.Appearance.Font.Size, FontStyle.Strikeout);
		formatConditionRuleValue3.Appearance.Options.UseBackColor = true;
		formatConditionRuleValue3.Appearance.Options.UseFont = true;
		formatConditionRuleValue3.Condition = FormatCondition.Equal;
		formatConditionRuleValue3.Value1 = "Cancelled";
		gridFormatRule4.Rule = formatConditionRuleValue3;

		gridFormatRule40.ApplyToRow = true;
		gridFormatRule40.Column = colStatus1;
		gridFormatRule40.Name = "Cancelled";
		formatConditionRuleValue30.Appearance.BackColor = SolutionSettings.Colours.Cancelled;
		formatConditionRuleValue30.Appearance.BackColor2 = Color.White;
		formatConditionRuleValue30.Appearance.ForeColor = Color.Black;
		formatConditionRuleValue30.Appearance.Font = new Font("Tahoma", formatConditionRuleValue3.Appearance.Font.Size, FontStyle.Strikeout);
		formatConditionRuleValue30.Appearance.Options.UseBackColor = true;
		formatConditionRuleValue30.Appearance.Options.UseFont = true;
		formatConditionRuleValue30.Condition = FormatCondition.Equal;
		formatConditionRuleValue30.Value1 = "Cancelled";
		gridFormatRule40.Rule = formatConditionRuleValue30;

		gridFormatRule5.ApplyToRow = true;
		gridFormatRule5.Column = colPath;
		gridFormatRule5.Name = "Paperwork";
		formatConditionRuleExpression2.Appearance.Font = new Font("Tahoma", formatConditionRuleValue3.Appearance.Font.Size, FontStyle.Bold);
		formatConditionRuleExpression2.Appearance.Options.UseFont = true;
		formatConditionRuleExpression2.Expression = "Iif([Path] Is Null, True, False) And DateDiffDay(Today(), [DateofCourse]) < 0 AND [Status]<>'Cancelled'";
		gridFormatRule5.Rule = formatConditionRuleExpression2;

		gridFormatRule50.ApplyToRow = true;
		gridFormatRule50.Column = colPath;
		gridFormatRule50.Name = "Paperwork";
		formatConditionRuleExpression20.Appearance.Font = new Font("Tahoma", formatConditionRuleValue3.Appearance.Font.Size, FontStyle.Bold);
		formatConditionRuleExpression20.Appearance.Options.UseFont = true;
		formatConditionRuleExpression20.Expression = "Iif([Path] Is Null, True, False) And DateDiffDay(Today(), [DutyDate]) < 0 AND [Status]<>'Cancelled'";
		gridFormatRule50.Rule = formatConditionRuleExpression20;

		TrainingGridView.FormatRules.Clear();
		TrainingGridView.FormatRules.Add(gridFormatRule1);
		TrainingGridView.FormatRules.Add(gridFormatRule2);
		TrainingGridView.FormatRules.Add(gridFormatRule3);
		TrainingGridView.FormatRules.Add(gridFormatRule51);

		TrainingGridView.FormatRules.Add(gridFormatRule5);
		TrainingGridView.FormatRules.Add(gridFormatRule4);
		TrainingGridView.FormatRules.Add(Utilities.GridRules.GeneralColour( colTableSort, FormatCondition.Equal, 4, Color.LightGreen, Color.Black));
		// (TrainingGridView.FormatRules.Count)

		ClinicalGridView.FormatRules.Add(gridFormatRule10);
		ClinicalGridView.FormatRules.Add(gridFormatRule11);
		ClinicalGridView.FormatRules.Add(gridFormatRule40);
		ClinicalGridView.FormatRules.Add(gridFormatRule50);
		// (ClinicalGridView.FormatRules.Count)
		GridView10.FormatRules.Clear();
		GridView10.FormatRules.Add(Utilities.GridRules.InactiveByName(colStatus3, "Obsolete"));

		GridView11.FormatRules.Clear();
		GridView11.FormatRules.Add(Utilities.GridRules.RiskRules.Low( colLikelihood));
		GridView11.FormatRules.Add(Utilities.GridRules.RiskRules.Moderate( colLikelihood));
		GridView11.FormatRules.Add(Utilities.GridRules.RiskRules.Significant( colLikelihood));
		GridView11.FormatRules.Add(Utilities.GridRules.RiskRules.High( colLikelihood));

		GridView11.FormatRules.Add(Utilities.GridRules.RiskRules.Low( colImpact));
		GridView11.FormatRules.Add(Utilities.GridRules.RiskRules.Moderate( colImpact));
		GridView11.FormatRules.Add(Utilities.GridRules.RiskRules.Significant( colImpact));
		GridView11.FormatRules.Add(Utilities.GridRules.RiskRules.High( colImpact));

		GridView11.FormatRules.Add(Utilities.GridRules.RiskRules.Low( colRiskScore));
		GridView11.FormatRules.Add(Utilities.GridRules.RiskRules.Moderate( colRiskScore));
		GridView11.FormatRules.Add(Utilities.GridRules.RiskRules.Significant( colRiskScore));
		GridView11.FormatRules.Add(Utilities.GridRules.RiskRules.High( colRiskScore));

	}

	private void btnBatchCerts_ItemClick(object sender, ItemClickEventArgs e)
	{
		try
		{
			frmBatchCerts frm = new frmBatchCerts(this);
			frm.ShowDialog();
		}
		catch (Exception ex)
		{

		}
	}

	private void btnClinicalStats_ItemClick(object sender, ItemClickEventArgs e)
	{
		frmClinical_Stats frm = new frmClinical_Stats();
		frm.Show(this);
	}

	private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{
		//("Worker Done")
		RefreshMain(true, "gWorker_RunWorkerCompleted");
		if (SolutionSettings.VisibleScreen == Screens.Clinical)
		{
			Shifts.ClearTempCertRows();
			ClinicalGridView.ClearSelection();
		}
		else
		{
			Course.ClearTempCertRows();
			TrainingGridView.ClearSelection();
		}
		_selectedColumn = null;

		brInfo.Visibility = BarItemVisibility.Never;
		brInfo.Caption = _selectedColumn + " cannot be updated";
	}

	private void btnClinicalReports_ItemClick(object sender, ItemClickEventArgs e)
	{
		_han = (IOverlaySplashScreenHandle)Utilities.ShowProgressPanel(this);
		frmClinical_Overview frm = new frmClinical_Overview();
		frm.LoadDetails();
		frm.Show(this);
		frm.BringToFront();
		Utilities.CloseProgressPanel(_han);
	}

	private void nvEquipment_LinkClicked(object sender, NavBarLinkEventArgs e)
	{
		MoveScreen(e.Link, Screens.Assets, null);
	}

	private void btnOpenThis_ItemClick(object sender, ItemClickEventArgs e)
	{
		Utilities.ScreenWait();

		switch (SolutionSettings.VisibleScreen)
		{
			case Screens.Training:
				Course.FilterGridTraining(ref _filterColName, (_filterValue), "Open", TrainingGridView);
				break;
			case Screens.Clinical:
				Shifts.FilterClinicalGrid(ref _filterColName, (_filterValue), "Open", ClinicalGridView);
				break;
		}
		_filterColName = null;
		_filterValue = string.Empty;
		Utilities.ScreenWait(false);
	}

	private void btnAllThis_ItemClick(object sender, ItemClickEventArgs e)
	{
		Utilities.ScreenWait();
		switch (SolutionSettings.VisibleScreen)
		{
			case Screens.Training:

				Course.FilterGridTraining(ref _filterColName, (_filterValue), "All", TrainingGridView);
				break;
			case Screens.Clinical:
				ClinicalGridView.BeginDataUpdate();
				btnShowAll.PerformClick();
				Shifts.FilterClinicalGrid(ref _filterColName, (_filterValue), "All", ClinicalGridView);
				ClinicalGridView.EndDataUpdate();
				break;
		}
		_filterColName = null;
		_filterValue = string.Empty;
		Utilities.ScreenWait(false);
	}

	private void btnClearFilter_ItemClick(object sender, ItemClickEventArgs e)
	{
		Utilities.ScreenWait();

		switch (SolutionSettings.VisibleScreen)
		{
			case Screens.Training:
				Course.Show.OpenCourses(TrainingGridView);
				break;
			case Screens.Clinical:
				Shifts.Show.OpenShift(ClinicalGridView);

				break;
			case Screens.Calendar:
				_filterId = 0;
				schCourses.ActiveView.LayoutChanged();
				schCourses.BeginUpdate();
				schCourses.DataStorage = null;
				schCourses.DataStorage = SchedulerStorage;
				SolutionSettings.SchedulerSource = DataSource.General;
				schCourses.EndUpdate();
				break;
			case Screens.Leads:
				ActivitiesGridControl.BeginUpdate();
				ActivitiesGridControl.DataSource = null;
				ActivitiesGridControl.DataSource = ActivitiesBindingSource;
				//'LeadsByCourseTableAdapter.Fill(LeadsDataSet.LeadsByCourse, )
				ActivitiesGridControl.EndUpdate();
				BarEditItem4.EditValue = string.Empty;
				break;
		}
		_filterColName = null;
		_filterValue = string.Empty;
		Utilities.ScreenWait(false);
	}

	private void ClinicalGridView_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
	{

		var view = sender as GridView;
		if (e.HitInfo.InRowCell)
		{

			view.FocusedRowHandle = e.HitInfo.RowHandle;

			btnCasualtySummary.Enabled = true;

			SuperToolTip s = new SuperToolTip();
			var args = new SuperToolTipSetupArgs();
			args.Title.Text = "Casualty Summary Report";
			args.Contents.Text = ("Provides a summary of casualties for the selected shifts");
			if (ClinicalGridView.SelectedRowsCount == 0)
			{
				btnCasualtySummary.Enabled = false;
				args.Contents.Text = ("Not available when no records selected");
			}
			else
			{
				if (ClinicalGridView.OptionsSelection.MultiSelectMode == GridMultiSelectMode.CheckBoxRowSelect)
				{
					Shifts.Summary sl = new Shifts.Summary();

					for (var i = 0; i < ClinicalGridView.DataRowCount; i++)
					{
						if (ClinicalGridView.IsRowSelected(i))
						{
							Shifts.ShiftDetails shift = new Shifts.ShiftDetails
							{
								CasCount = Convert.ToInt32(ClinicalGridView.GetRowCellValue(i, colRecords)),
								ShiftDate = Convert.ToDateTime(ClinicalGridView.GetRowCellValue(i, colDutyDate)),
								Client = ClinicalGridView.GetRowCellValue(i, colClient).ToString()
							};
							sl.ShiftList.Add(shift);
						}
					}

					if (sl.HasCasualties == false)
					{
						btnCasualtySummary.Enabled = false;
						args.Contents.Text = ("There are no casualties to report on");
					}

					if (sl.AllDatesInPast == false)
					{
						btnCasualtySummary.Enabled = false;
						args.Contents.Text = ("Cannot provide a report on shifts that havent yet happened");
					}

					if (sl.ClientsSame == false)
					{
						btnCasualtySummary.Enabled = false;
						args.Contents.Text = ("Cannot provide a report where clients are different");
					}
				}
				else
				{
					btnCasualtySummary.Enabled = false;
					args.Contents.Text = ("Cannot access the report when batch select not enabled");
				}
				s.Setup(args);
				btnCasualtySummary.SuperTip = s;

			}
			btnOpenFolder.Enabled = true;
			btnCompanyReport.Visibility = BarItemVisibility.Never;
			btnCasualtySummary.Visibility = BarItemVisibility.Always;
			puGrid.ShowPopup(view.GridControl.PointToScreen(e.Point));
			_filterColName = e.HitInfo.Column;
			_filterValue = view.GetFocusedDisplayText();

		}
		else if (e.HitInfo.InGroupRow)
		{

			// ("In row")
			PopupMenu pu = new PopupMenu(Container) {Manager = RibbonControl1.Manager};
			pu.ItemLinks.Add(btnMultiSelect);

			pu.ItemLinks.Add(btnGridExpand).BeginGroup = true;
			pu.ItemLinks.Add(btnGridCollapse);

			pu.ShowPopup(view.GridControl.PointToScreen(e.Point));
			puGrid.ShowPopup(view.GridControl.PointToScreen(e.Point));
		}
	}

	private void btnTempReport_ItemClick(object sender, ItemClickEventArgs e)
	{
		TempReport rpt = new TempReport();
		rpt.Company.Value = _filterValue;
		rpt.Company.Visible = false;
		using (ReportPrintTool printTool = new ReportPrintTool(rpt))
		{
			printTool.ShowRibbonPreviewDialog();
		}
		Course.ClearTempCertRows();
		TrainingGridView.ClearSelection();
	}

	private void GridControl1_KeyUp(object sender, KeyEventArgs e)
	{
		if (ModifierKeys == Keys.None && e.KeyCode == Keys.Delete)
		{

			switch (grdMyInbox.GetRowCellValue(grdMyInbox.FocusedRowHandle, "Type").ToString())
			{
				case "Email":
					using (Utilities.Email myemail = new Utilities.Email())
					{
						string id = grdMyInbox.GetRowCellValue(grdMyInbox.FocusedRowHandle, "ID").ToString();
						grdMyInbox.DeleteRow(grdMyInbox.FocusedRowHandle);
						myemail.DeleteEmail(id);
					}

					// CloseProgressPanel(_han)
					return;

				case "Task":
					General.TaskCompleted(Convert.ToInt32(grdMyInbox.GetRowCellValue(grdMyInbox.FocusedRowHandle, "ID").ToString()));
					grdMyInbox.DeleteSelectedRows();

					break;
			}

		}

		BtnRefresh.PerformClick();
	}

	private void btnConvertLead_ItemClick(object sender, ItemClickEventArgs e)
	{
		try
		{
			Utilities.ScreenWait();
			int h = grdMyInbox.FocusedRowHandle;
			frmLead_Details frm = new frmLead_Details(this);
			frm.LoadDetails(Leads.AddDropLead((grdMyInbox.GetRowCellValue(h, "Name") == null ? null : Convert.ToString(grdMyInbox.GetRowCellValue(h, "Name"))), DateTime.Today, (grdMyInbox.GetRowCellValue(h, "Body") == null ? null : Convert.ToString(grdMyInbox.GetRowCellValue(h, "Body"))), (grdMyInbox.GetRowCellValue(h, "Email") == null ? null : Convert.ToString(grdMyInbox.GetRowCellValue(h, "Email")))));
			frm.Show(this);
			Utilities.ScreenWait(false);
		}
		catch (Exception ex)
		{
			Utilities.MyError(ex);
		}
	}

	private void Timer1_Tick(object sender, EventArgs e)
	{
		if (SolutionSettings.LiteMode == false)
		{
			RefreshMain(false, "Main Refresh - Timer Tick");
		}
	}

	private void btnLogOff_ItemClick(object sender, ItemClickEventArgs e)
	{
		try
		{
			Security.LogEvent((SolutionSettings.CurrentUser.UserName + " logged out"), Security.AuditType.System, 0);
			Security.UserLogging(Security.LogDirection.Loggedout);
			if (_clearfolder)
			{
				Utilities.DeleteFilesFromFolder((SolutionSettings.BaseDirectory + "Temp\\"));
			}
		}
		catch (Exception ex)
		{
			Utilities.MyError(ex);
		}
		finally
		{

			//Windows.Forms.Application.Exit()
			// Environment.Exit()
		}
	}

	private void btnAuditLog_ItemClick(object sender, ItemClickEventArgs e)
	{
		Utilities.ScreenWait();
		frmAuditLog frm = new frmAuditLog();
		frm.Show();
		Utilities.ScreenWait(false);
	}

	private void btnShowWeb_ItemClick(object sender, ItemClickEventArgs e)
	{
		try
		{
			_showWeb = !_showWeb;
			if (Networking.IsWebSiteAvailable)
			{
				WebUpcomingTableAdapter.Fill(WebDataSet.WebUpcoming, DateTime.Today.AddDays(- 7), DateTime.Today.AddMonths(1));

				if (_showWeb)
				{

					SplitContainerControl4.SplitterPosition = Convert.ToInt32(SplitContainerControl4.Width / 2.0);
					SplitContainerControl4.PanelVisibility = SplitPanelVisibility.Both;
				}
				else
				{
					SplitContainerControl4.PanelVisibility = SplitPanelVisibility.Panel2;
					SplitContainerControl4.SplitterPosition = 0;
				}
			}
		}
		catch (Exception ex)
		{
			Utilities.MyError(ex);
		}
	}

	private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
	{

		if (XtraMessageBox.Show(" Are you sure you want to exit the application? ", "Exit ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
		{

			ntIconNew.Visible = false;
			ntIconNew.Dispose();
			Security.LogEvent((SolutionSettings.CurrentUser.UserName + " logged out"), Security.AuditType.System, 0);
			Security.UserLogging(Security.LogDirection.Loggedout);
			if (_clearfolder)
			{
				Utilities.DeleteFilesFromFolder((SolutionSettings.BaseDirectory + "Temp\\"));
			}
			Environment.ExitCode = 1;
			Environment.Exit(1);
		}
		else
		{
			e.Cancel = true;

		}
	}

	private void schCourses_ActiveViewChanged(object sender, EventArgs e)
	{
		try
		{
			if (SolutionSettings.SchedulerSource == DataSource.General)
			{
				SchedulerStorage_FilterAppointment(null, null);
			}
			else if (SolutionSettings.SchedulerSource == DataSource.Medic)
			{
				tt.Fill(PersonnellDataSet.PersonAvail);

			}
			else if (SolutionSettings.SchedulerSource == DataSource.Instructors)
			{
				INstructorAvailabilityTableAdapter.Fill(PersonnellDataSet.INstructorAvailability);
			}
			schCourses.ActiveView.AppointmentDisplayOptions.AutoAdjustForeColor = false;
		}
		catch (Exception ex)
		{
			Utilities.MyError(ex);
		}
	}

	private void SchedulerControl1_AppointmentViewInfoCustomizing(object sender, AppointmentViewInfoCustomizingEventArgs e)
	{
		// (e.ViewInfo.Appointment.CustomFields.Item("Published"))
		try
		{
			if (Convert.ToInt32(e.ViewInfo.Appointment.CustomFields["Published"]) == 1)
			{
				e.ViewInfo.Appearance.BackColor = Color.Khaki;
				e.ViewInfo.Appearance.ForeColor = Color.Navy;
			}
			else
			{
				e.ViewInfo.Appearance.BackColor = Color.Gainsboro;
				e.ViewInfo.Appearance.ForeColor = Color.Red;
			}
		}
		catch (Exception ex)
		{
			Utilities.MyError(ex);
		}
	}

	private void btnFilterShift_ItemClick(object sender, ItemClickEventArgs e)
	{
		_filterId = 1;
		schCourses.ActiveView.LayoutChanged();
	}

	private void btnFilterCourse_ItemClick(object sender, ItemClickEventArgs e)
	{
		_filterId = 2;
		schCourses.ActiveView.LayoutChanged();
	}

	private void btnFilterMeeting_ItemClick(object sender, ItemClickEventArgs e)
	{
		_filterId = 3;
		schCourses.ActiveView.LayoutChanged();
	}

	private void SchedulerStorage_FilterAppointment(object sender, PersistentObjectCancelEventArgs e)
	{
		try
		{
			if (!Utilities.DataHelper.IsNullOrEmpty(e))
			{
				var appointment = (Appointment)e.Object as Appointment;
				if (_filterId == 0)
				{
					e.Cancel = false;
				}
				else if (_filterId == 1)
				{
					e.Cancel = appointment.CustomFields["ItemType"].ToString() != "Shift";
				}
				else if (_filterId == 2)
				{
					e.Cancel = appointment.CustomFields["ItemType"].ToString() != "Course";
				}
				else if (_filterId == 3)
				{
					e.Cancel = appointment.CustomFields["ItemType"].ToString() != "Meeting";
				}
			}
		}
		catch (Exception ex)
		{
			Utilities.MyError(ex);
		}
	}

	private void btnConvertTask_ItemClick(object sender, ItemClickEventArgs e)
	{
		try
		{
			int h = grdMyInbox.FocusedRowHandle;
			frmTask_Details frm = new frmTask_Details(this);
			int id = General.AddSingleDropTask("Email: " + grdMyInbox.GetRowCellValue(h, "Name").ToString(), DateTime.Now, grdMyInbox.GetRowCellValue(h, "Body").ToString());
			frm.loadDetails(id);
			frm.Show(this);
		}
		catch (Exception ex)
		{
			Utilities.MyError(ex);
		}
	}

	private void btnAddTask_ItemClick(object sender, ItemClickEventArgs e)
	{
		try
		{
			frmTask_Details frm = new frmTask_Details(this);
			int id = General.AddSingleDropTask("New Task", DateTime.Now, "Task Details");
			frm.loadDetails(id);
			frm.Show(this);
		}
		catch (Exception ex)
		{
			Utilities.MyError(ex);
		}
	}

	private void btnAddLead_ItemClick(object sender, ItemClickEventArgs e)
	{
		try
		{
			// #AddLead
			frmLead_Details frm = new frmLead_Details(this);
			frm.LoadDetails(Leads.AddDropLead("New Lead", DateTime.Today, "New Details", null));
			frm.Show(this);
		}
		catch (Exception ex)
		{
			Utilities.MyError(ex);
		}
	}

	private void nvSales_LinkClicked(object sender, NavBarLinkEventArgs e)
	{
		MoveScreen(e.Link, Screens.Leads, LeadsGrid);
	}

	private void LeadsGrid_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
	{
		frmLead_Details frm = new frmLead_Details(this);
		frm.LoadDetails(Convert.ToInt32(LeadsGrid.GetRowCellValue(e.RowHandle, "ID")));
		frm.Show();
	}

	private void btnOpenLeads_ItemClick(object sender, ItemClickEventArgs e)
	{
		Leads.ShowBy.Open(LeadsGrid);
	}

	private void BarEditItem4_EditValueChanged(object sender, EventArgs e)
	{

		if (Utilities.DataHelper.IsNullOrEmpty(BarEditItem4.EditValue.ToString()) == false)
		{
			ActivitiesGridControl.BeginUpdate();
			ActivitiesGridControl.DataSource = null;
			ActivitiesGridControl.DataSource = LeadsByCourseBindingSource;
			LeadsByCourseTableAdapter.Fill(LeadsDataSet.LeadsByCourse, Convert.ToString(BarEditItem4.EditValue.ToString()));
			ActivitiesGridControl.EndUpdate();
		}
	}

	private void btnMyLeads_ItemClick(object sender, ItemClickEventArgs e)
	{
		Leads.ShowBy.Mine(LeadsGrid);
	}

	private void btnAllLeads_ItemClick(object sender, ItemClickEventArgs e)
	{
		Leads.ShowBy.All(LeadsGrid);
	}

	private void btnClosedLost_ItemClick(object sender, ItemClickEventArgs e)
	{
		Leads.ShowBy.ClosedLost(LeadsGrid);
	}

	private void btnClosedWon_ItemClick(object sender, ItemClickEventArgs e)
	{
		Leads.ShowBy.ClosedWon(LeadsGrid);
	}

	private void nvGovernance_LinkClicked(object sender, NavBarLinkEventArgs e)
	{
		//Dim TempXViews As DevExpress.XtraTreeList.Design.XViews = New DevExpress.XtraTreeList.Design.XViews(TreeList1)

		MoveScreen(e.Link, Screens.Governance, GovGrid);
	}

	private void btnEditCourse_ItemClick(object sender, ItemClickEventArgs e)
	{
		frmCourse_List frm = new frmCourse_List();
		frm.Show(this);
	}

	private void NvNotes_LinkClicked(object sender, NavBarLinkEventArgs e)
	{
		MoveScreen(e.Link, Screens.Notes, null);
		Debug.Print(nvNotes.ToString());
		//BusinessNotesTableAdapter.Fill(Me.MainDataSet.BusinessNotes)
	}

	private void GridView2_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
	{
		frmNotes frm = new frmNotes(this);
		frm.LoadDetails(Convert.ToInt32(TileView1.GetRowCellValue(e.RowHandle, "ID")));
		frm.ShowDialog();
	}

	private void btnWorkDiary_ItemClick(object sender, ItemClickEventArgs e)
	{
		WorkDiary report = new WorkDiary();

		ReportPrintTool tool = new ReportPrintTool(report);
		tool.ShowRibbonPreview();
	}

	private void schCourses_CustomDrawDayHeader(object sender, DevExpress.XtraScheduler.CustomDrawObjectEventArgs e)
	{

		HatchBrush hatch = new HatchBrush(HatchStyle.BackwardDiagonal, Color.LightGray, Color.Transparent);
		var header = e.ObjectInfo as SchedulerHeader;
		header.CaptionAppearance.TextOptions.HAlignment = HorzAlignment.Far;

		if (header.Interval.Start.Date.DayOfWeek == DayOfWeek.Monday)
		{
			header.Caption = header.Caption + " (W" + General.GetIsoWeekOfYear(header.Interval.Start.Date) + ")";
		}

		if (SolutionSettings.SystemDates.ContainsKey(header.Interval.Start.Date))
		{
			header.Cache.FillRectangle(hatch, e.Bounds);
			// e.DrawDefault()
			if (header.Interval.Start.Date.DayOfWeek == DayOfWeek.Monday)
			{
				header.Caption = SolutionSettings.SystemDates[header.Interval.Start.Date] + " " + header.Interval.Start.Date.ToString("dd") + " (W" + General.GetIsoWeekOfYear(header.Interval.Start.Date) + ")";
			}
			else
			{
				header.Caption = SolutionSettings.SystemDates[header.Interval.Start.Date] + " " + header.Interval.Start.Date.ToString("dd");
			}

			header.CaptionAppearance.FontStyleDelta = FontStyle.Bold;

			e.DrawDefault();
			Image img = BM.Properties.Resources.flag_green;
			Rectangle imgRect = header.ImageBounds;
			imgRect.Width = (header.ImageBounds.Height * img.Width) / img.Height;
			imgRect.X = header.ImageBounds.X + 3;
			e.Cache.DrawImage(img, imgRect);
			e.Handled = true;
		}
	}

	private void brWebAccess_ItemClick(object sender, ItemClickEventArgs e)
	{

		Networking.CheckWebsiteAvailable();

		if (Networking.IsWebSiteAvailable == true)
		{
			Course.Web.ImportWebStudents();
			brWebAccess.Caption = "Website OK";
			brWebAccess.ImageOptions.Image = BM.Properties.Resources.network_cloud;
			btnShowWeb.Enabled = true;
			btnPaid.Enabled = true;
		}
		else
		{
			brWebAccess.Caption = "No Web Connection";
			brWebAccess.ImageOptions.Image = BM.Properties.Resources.network_status_busy;
			btnShowWeb.Enabled = false;
			btnShowWeb.Hint = "No connection to website.";
		}
	}

	private void btnBatchExportCourse_ItemClick(object sender, ItemClickEventArgs e)
	{

		TrainingGridView.OptionsPrint.PrintSelectedRowsOnly = true;
		TrainingGridView.ExportToXlsx($"{SolutionSettings.CacheFolder} & TrainingListExport.xlsx");
	}

	private void btnMap_ItemClick(object sender, ItemClickEventArgs e)
	{
		frmMap frm = new frmMap();
		if (_mapMode == 1)
		{
			frm.LoadMap(General.MapType.Medical, null);
		}
		else
		{
			frm.LoadMap(General.MapType.Instructor, brByCourse.EditValue.ToString());
		}

		frm.Show(this);
	}


	private void bgwShiftSheetEmails_DoWork(object sender, DoWorkEventArgs e)
	{
		int listCount = 0;
		RepositoryItemProgressBar1.Step = 1;
		var peopleCount = @"Select
                Count(derivedtbl_1.MedicID) As Expr1
            From
                (Select
                     Shifts.MedicID,
                     Personnell.ID,
                     Personnell.InstructorName,
                     Personnell.Email,
                     Personnell.Med_Fac,
                     Personnell.Inactive_Med,
                     Shifts.ShiftSheet,
                     Personnell.Locale
                 From
                    Shifts Inner Join
                     Personnell On Shifts.MedicID = Personnell.ID
                 Where
                    Shifts.DutyDate Between Date_Add(Now(), Interval -7 Month) And Date_Add(Now(), Interval -7 Day) And
                     Personnell.Locale = @T
                    And
                         Shifts.Path Is Null
                 Group By
                     Shifts.MedicID,
                     Personnell.ID,
                     Personnell.InstructorName,
                     Personnell.Email,
                     Personnell.Med_Fac,
                     Personnell.Inactive_Med,
                     Shifts.ShiftSheet,
                     Personnell.Locale
                 Having
                     Not (Personnell.Email Is Null) And
                     Shifts.ShiftSheet = 0 And
                     Personnell.Med_Fac = 1 And
                     Personnell.Inactive_Med = 0) derivedtbl_1";
		var peopleList = @"Select
                    Shifts.MedicID,
                    Personnell.ID,
                    Personnell.InstructorName,
                    Personnell.Email,
                    Personnell.Med_Fac,
                    Personnell.Inactive_Med,
                    Shifts.ShiftSheet,
                    Personnell.Locale
                 From
                    Shifts Inner Join
                    Personnell On Shifts.MedicID = Personnell.ID
                 Where
                    Shifts.DutyDate Between Date_Add(Now(), Interval -7 Month) And Date_Add(Now(), Interval -7 Day) And
                    Personnell.Locale = @T
                    And
                    Shifts.Path Is Null
                 Group By
                    Shifts.MedicID,
                    Personnell.ID,
                    Personnell.InstructorName,
                    Personnell.Email,
                    Personnell.Med_Fac,
                    Personnell.Inactive_Med,
                    Shifts.ShiftSheet,
                    Personnell.Locale
                Having
                    Not (Personnell.Email Is Null) And
                    Shifts.ShiftSheet = 0 And
                    Personnell.Med_Fac = 1 And
                    Personnell.Inactive_Med = 0";
		try
		{
			int remaining = 0;
			using (var connection = new MySqlConnection(BM.Core.MySQlHelper.ConnectionString))
			{
				using (var command = new MySqlCommand(peopleCount, connection))
				{
					command.Parameters.AddWithValue("@T", SolutionSettings.CurrentUser.TenantLocale);
					connection.Open();

					listCount = Utilities.SafeInt(command.ExecuteScalar());
				}
			}

			using (var con = new MySqlConnection(BM.Core.MySQlHelper.ConnectionString))
			{
				using (var command2 = new MySqlCommand(peopleList, con))
				{
					command2.Parameters.AddWithValue("@T", SolutionSettings.CurrentUser.TenantLocale);
					con.Open();
					MySqlDataReader reader = command2.ExecuteReader();
					if (reader.HasRows)
					{
						while (reader.Read())
						{

							if (bgwShiftSheetEmails.CancellationPending)
							{
								return;
							}
							remaining += 1;

							General.ShiftSheetList(reader.GetInt32(0), reader.GetString(2), reader.GetString(3));
							Security.LogEvent("Shift Sheet Reminder Email", Security.AuditType.Shift, reader.GetInt32(0));
							bgwShiftSheetEmails.ReportProgress(Convert.ToInt32((remaining / (double)(listCount * 100))));

						}

					}

				}
				con.Close();
			}

			XtraMessageBox.Show($"{listCount} individuals received emails about overdue shifts sheets", "Emails Sent", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
		catch (Exception ex)
		{
			Utilities.MyError(ex);
		}
	}

	private void schCourses_CustomDrawTimeCell(object sender, DevExpress.XtraScheduler.CustomDrawObjectEventArgs e)
	{

		HatchBrush hatch = new HatchBrush(HatchStyle.BackwardDiagonal, Color.LightGray, Color.Transparent);
		if (e.ObjectInfo.ToString() != "DevExpress.XtraScheduler.Drawing.MonthSingleWeekCell")
		{
			return;
		}
		var header = (MonthSingleWeekCell)e.ObjectInfo;
		if (SolutionSettings.SystemDates.ContainsKey(header.Interval.Start.Date))
		{

			e.DrawDefault();
			e.Cache.FillRectangle(hatch, e.Bounds);
			e.Handled = true;
		}
	}

	private void bgwShiftSheetEmails_ProgressChanged(object sender, ProgressChangedEventArgs e)
	{

		brProgress.EditValue = e.ProgressPercentage;
	}

	private void bgwShiftSheetEmails_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{

		brProgress.Visibility = BarItemVisibility.Never;
		BtnShiftSheets.Enabled = true;
	}

	public void BtnShiftSheets_ItemClick(object sender, ItemClickEventArgs e)
	{
		switch (XtraMessageBox.Show("Do you want To send an email To all medics who have shift sheets outstanding?", "Send email?", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
		{
			case System.Windows.Forms.DialogResult.Yes:

				brProgress.Visibility = BarItemVisibility.Always;
				BtnShiftSheets.Enabled = false;
				bgwShiftSheetEmails.RunWorkerAsync();
				break;
		}
	}

	private void btnCourseExpiry_ItemClick(object sender, ItemClickEventArgs e)
	{
		switch (XtraMessageBox.Show("Do you want To send an email To all students who cert Is about To expire?", "Send email?", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
		{
			case System.Windows.Forms.DialogResult.Yes:
				brProgress.Visibility = BarItemVisibility.Always;
				bgwStudentsEmail.RunWorkerAsync();
				break;
		}
	}

	private void bgwStudentsEmail_DoWork(object sender, DoWorkEventArgs e)
	{

		object objectValue = null;
		var n = 0;
		RepositoryItemProgressBar1.Step = 1;
		var cmdText = "Select Students.ID As Students_ID, Guardians.ID As Guardians_ID, Guardians.Company, Guardians.FirstName, Guardians.LastName, Guardians.Email, Guardians.Complete, Students.Course, Students.DateofCourse, Students.ExpiryDate, Students.CourseType, Guardians.Reminded, Courses.ReminderETemplate, Courses.CourseName, Courses.EmailReminder FROM (Students INNER JOIN Guardians On Students.ID = Guardians.CseID) INNER JOIN Courses On Students.Course = Courses.CourseName WHERE ( (Guardians.Email Is Not Null) And (Guardians.Complete='pass') AND (Students.DateofCourse < NOW()) And (Students.ExpiryDate Between Date_Add(Now(),INTERVAL -90 DAY) And Date_Add(Now(),INTERVAL 70 Day)) AND (Students.CourseType<>'External') AND (Guardians.Reminded=False) AND (Courses.EmailReminder=True) )";
		var str2 = "select Count(*) From (SELECT Students.ID AS Students_ID, Guardians.ID AS Guardians_ID, Guardians.Company, Guardians.FirstName, Guardians.LastName, Guardians.Email, Guardians.Complete, Students.Course, Students.DateofCourse, Students.ExpiryDate, Students.CourseType, Guardians.Reminded, Courses.ReminderETemplate, Courses.CourseName, Courses.EmailReminder FROM (Students INNER JOIN Guardians On Students.ID = Guardians.CseID) INNER JOIN Courses On Students.Course = Courses.CourseName WHERE ( (Guardians.Email Is Not Null) And (Guardians.Complete='pass') AND (Students.DateofCourse < NOW()) And (Students.ExpiryDate Between Date_Add(Now(),INTERVAL -90 DAY) And Date_Add(Now(),INTERVAL 70 Day)) AND (Students.CourseType<>'External') AND (Guardians.Reminded=False) AND (Courses.EmailReminder=True) )) as T";
		using (var connection = new MySqlConnection(BM.Core.MySQlHelper.ConnectionString))
		{
			using (var command = new MySqlCommand(str2, connection))
			{
				connection.Open();
				objectValue = command.ExecuteScalar();
			}
		}

		try
		{
			using (var connection2 = new MySqlConnection(BM.Core.MySQlHelper.ConnectionString))
			{
				using (var command2 = new MySqlCommand(cmdText, connection2))
				{
					connection2.Open();
					using (MySqlDataReader reader = command2.ExecuteReader())
					{
						if (reader.HasRows)
						{
//INSTANT C# NOTE: There is no C# equivalent to VB's implicit 'once only' variable initialization within loops, so the following variable declaration has been placed prior to the loop:
							string str4 = null;
							string str5 = null;
							string str6 = null;
							while (reader.Read())
							{
								if (bgwStudentsEmail.CancellationPending)
								{
									return;
								}

								string str3 = reader["ReminderETemplate"].ToString();
//								Dim str4, str5, str6 As String
								DateTime time = DateTime.Parse(Convert.ToString(reader["ExpiryDate"]));
								if (!string.IsNullOrEmpty(str3))
								{
									str4 = str3.Replace("Expirydate", time.ToString("D"));
									str5 = str4.Replace("StudentName", Microsoft.VisualBasic.Strings.StrConv(Convert.ToString(reader["FirstName"]), Microsoft.VisualBasic.VbStrConv.ProperCase, 0));
									str6 = str5.Replace("CourseName", Convert.ToString(reader["Course"]));

									bgwStudentsEmail.ReportProgress(Convert.ToInt32((Left / ((double)objectValue) * 100)));
									Thread.Sleep(100);
									using (Utilities.Email myEmail = new Utilities.Email())
									{
										try
										{
											myEmail.SentTo(Convert.ToString(reader["Email"]));
											myEmail.ShowNotification = false;
											if (myEmail.SetupEmail("Course Reminder", str6.ToString(), "info@medicore.ie") == true)
											{

												myEmail.Send();
											}
											else
											{
												if (XtraMessageBox.Show("There was an error with the email function." + Environment.NewLine + Environment.NewLine + " Do you want to continue with the rest of the operation?", "Continue", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
												{
													e.Cancel = true;
													return;

												}
											}
										}
										catch (Exception ex)
										{
											if (XtraMessageBox.Show("There was an error with the email function." + Environment.NewLine + Environment.NewLine + " Do you want to continue with the rest of the operation?", "Continue", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
											{
												e.Cancel = true;
												return;

											}
										}

									}
									Course.Details.SetStudentReminded(Convert.ToInt32(reader["Guardians_ID"]));
								}
								else
								{
									n += 1;
								}
							}
						}
						else
						{
							XtraMessageBox.Show("They are no students who currently need an email reminder.", "Not Needed", MessageBoxButtons.OK, MessageBoxIcon.Information);
							return;
						}
					}
				}
			}

			if (n > 0)
			{
				switch (n)
				{
					case 1:
						XtraMessageBox.Show($"{n} Student didnt receive an email because the course email template was blank!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						break;
					default:
						XtraMessageBox.Show($@"{n}  Students Of {objectValue} didnt receive an email because the course email template was blank!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						break;
				}
			}
			else if (n == Convert.ToInt32(objectValue))
			{
				XtraMessageBox.Show("NO Students received an email because the course email template was blank!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else if (n == 0)
			{
				XtraMessageBox.Show($"{objectValue} individuals received emails about expiring courses", "Emails Sent", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}
		catch (Exception ex)
		{
			Utilities.MyError(ex);
			if (XtraMessageBox.Show("Do you want To Continue With the rest Of the operation?", "Continue", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
			{
				e.Cancel = true;
				return;

			}
		}
	}

	private void frmMain_KeyUp(object sender, KeyEventArgs e)
	{

		switch (e.KeyCode)
		{
			case Keys.Escape:
				if (bgwShiftSheetEmails.IsBusy)
				{
					bgwShiftSheetEmails.CancelAsync();
					XtraMessageBox.Show("Shift Sheet Email - Operation Cancelled!", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}

				break;
			case Keys.F12:
				DevExpress.XtraGrid.Views.Grid.GridView tempVar = SolutionSettings.VisibleGrid;
				Utilities.GridHelp.ViewFind(ref tempVar, true);
				SolutionSettings.VisibleGrid = tempVar;
				break;
		}
	}

	private void bgwStudentsEmail_ProgressChanged(object sender, ProgressChangedEventArgs e)
	{

		brProgress.EditValue = e.ProgressPercentage;
	}

	private void bgwGlobalCompliance_DoWork(object sender, DoWorkEventArgs e)
	{
		//ComplianceDoWork()
	}

//    Private Sub ComplianceDoWork()
//
//        RepositoryItemProgressBar1.Step = 1
//        Personnel.UpdatePersonalDocs()
//        Dim cmdText =
//                "Select Count(ID) As Count from Personnell Where Personnell.Med_Fac = True And Personnell.Inactive_Med = False"
//        Dim str2 = "Select ID from Personnell Where Personnell.Med_Fac = True And Personnell.Inactive_Med = False"
//        Dim xleft = 0
//        Using connection = New MySqlConnection(My.Settings.BMConnString)
//            Dim objectValue As Object
//            connection.Open()
//
//            Using command = New MySqlCommand(cmdText, connection)
//                objectValue = command.ExecuteScalar
//            End Using
//
//            Using command2 = New MySqlCommand(str2, connection)
//                Dim reader As MySqlDataReader = command2.ExecuteReader
//                If reader.HasRows Then
//                    Do While reader.Read
//                        xleft += 1
//                        bgwGlobalCompliance.ReportProgress(CType(((xleft/objectValue)*100), Integer))
//                        Personnel.ClinicalCompliance(Utilities.SafeInt(reader.GetValue(0)))
//                    Loop
//                End If
//            End Using
//        End Using
//        Security.LogEvent("Global review Of clinical compliance", Nothing, Nothing)
//        XtraMessageBox.Show(Left.ToString() & " personnel files reviewed And adjusted.", "Files Adjusted",
//                            MessageBoxButtons.OK, MessageBoxIcon.Information)
//    End Sub

	private void bgwStudentsEmail_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{

		brProgress.Visibility = BarItemVisibility.Never;
	}

	private void bgwGlobalCompliance_ProgressChanged(object sender, ProgressChangedEventArgs e)
	{

		brProgress.EditValue = e.ProgressPercentage;
	}

	private void btnGlobalCompliance_ItemClick(object sender, ItemClickEventArgs e)
	{

		switch (XtraMessageBox.Show("Do you want To carryout a Global compliance review?", "Review Compliance?", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
		{
			case System.Windows.Forms.DialogResult.Yes:
				brProgress.Visibility = BarItemVisibility.Always;
				bgwGlobalCompliance.RunWorkerAsync();

				break;
		}
	}

//    Private Sub btnSanity_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnSanity.ItemClick
//        Utilities.ScreenWait(True)
//        Utilities.StartTaskBarAssistant(Me)
//        Utilities.ScreenWaitCaption("Holidays/ Sick...")
//        Dim sql = "Select * from PersonAvailability"
//        Using connection = New MySqlConnection(My.Settings.BMConnString)
//            Using command = New MySqlCommand(sql, connection)
//                connection.Open()
//                Dim results = command.ExecuteReader()
//
//                If results.HasRows Then
//                    Do While results.Read
//                        Utilities.ScreenWaitDescription($"Updating:{results("ID").ToString}")
//                        If Utilities.DataHelper.IsNullOrEmpty(results("EndDate")) = False Then
//                            Dim d = DateDiff(DateInterval.Day, DateTime.Parse(CStr(results("StartDate"))),
//                                             DateTime.Parse(CStr(results("EndDate"))))
//                            Personnel.UpdateEventDuration(Convert.ToInt32(results("ID")), d)
//                        Else
//                            Personnel.UpdateEventDuration(Convert.ToInt32(results("ID")), 1)
//                        End If
//
//                    Loop
//                End If
//
//            End Using
//        End Using
//
//        Utilities.ScreenWaitCaption("Update Medic Compliance...")
//        Dim sqlMeds =
//                "Select Personnell.ID, Personnell.Inactive_Med From Personnell Where Personnell.Med_Fac = 1 And Personnell.Inactive_Med = 0"
//        Using connection = New MySqlConnection(My.Settings.BMConnString)
//            Using command = New MySqlCommand(sqlMeds, connection)
//                connection.Open()
//
//                Dim results = command.ExecuteReader()
//
//                If results.HasRows Then
//                    Do While results.Read
//                        Utilities.ScreenWaitDescription("Updating:" & results(0).ToString)
//                        Personnel.ClinicalCompliance(Convert.ToInt32(results(0)))
//                    Loop
//                End If
//            End Using
//        End Using
//
//        Utilities.ScreenWaitCaption("Updating Instructors")
//        Dim sqlInst =
//                "Select
//Personnell.ID,
//Personnell.InstructorName,
//Max(InstQuals.QualExp) As Max_QualExp,
//Personnell.Inst_Fac,
//Personnell.Inactive_Inst
//From
//Personnell Inner Join
//InstQuals On InstQuals.InstructorID = Personnell.ID
//Where
//Personnell.ID <> 85 And
//Personnell.Inst_Fac = 1 And
//Personnell.Inactive_Inst = 0
//Group By
//Personnell.ID,
//Personnell.InstructorName,
//Personnell.Inst_Fac,
//Personnell.Inactive_Inst
//Having
//Max(InstQuals.QualExp) < Date_Add(CurDate(), Interval -12 Month) Or
//(Max(InstQuals.QualExp) Is Null)"
//        Using connection = New MySqlConnection(My.Settings.BMConnString)
//            Using command = New MySqlCommand(sqlInst, connection)
//                connection.Open()
//                Dim results = command.ExecuteReader()
//
//                If results.HasRows Then
//                    Do While results.Read
//                        Utilities.ScreenWaitDescription("Updating:" & results(1).ToString)
//                        Personnel.SetInstructorInactive(Convert.ToInt32(results(0)))
//                        'Area.Asset.Container.UpdateBatchQty(results(0))
//                    Loop
//                End If
//            End Using
//        End Using
//
//        Utilities.ScreenWaitCaption("Updating IV Courses...")
//        Dim listId As New List(Of Integer)
//        Const ivSql = "Select ID from Students Where IVName <> ''"
//
//        Using connection = New MySqlConnection(My.Settings.BMConnString)
//            Using command = New MySqlCommand(ivSql, connection)
//                connection.Open()
//                command.Parameters.AddWithValue("@D", Today.Date)
//                Dim results = command.ExecuteReader()
//
//                If results.HasRows Then
//                    Do While results.Read
//                        listId.Add(Convert.ToInt32(results(0)))
//                    Loop
//                End If
//
//            End Using
//        End Using
//
//        Dim parmList As String = "@ID" & String.Join(",@ID", listId)
//        Dim ivUpdate = "Update Students Set Iv=True Where ID IN (" & parmList & ")"
//        Using con As New MySqlConnection(My.Settings.BMConnString)
//            Using cmd As New MySqlCommand(ivUpdate, con)
//                con.Open()
//                For Each i In listId
//                    cmd.Parameters.AddWithValue("@ID" & i, i)
//                Next
//
//                cmd.ExecuteNonQuery()
//            End Using
//        End Using
//
//        Utilities.ScreenWaitCaption("Removing Zero OOD batches...")
//        Dim sqlBatch =
//                "Select * From BatchInfo Where BatchInfo.Qty = 0 And BatchInfo.Expiry < @D Order By BusinessManager.BatchInfo.Qty"
//        Using connection = New MySqlConnection(My.Settings.BMConnString)
//            Using command = New MySqlCommand(sqlBatch, connection)
//                connection.Open()
//                command.Parameters.AddWithValue("@D", Today.Date)
//                Dim results = command.ExecuteReader()
//
//                If results.HasRows Then
//                    Do While results.Read
//                        Utilities.ScreenWaitDescription("Updating:" & results(2).ToString)
//                        Asset.Batch.DeleteBatch(results(0))
//                        'Area.Asset.Container.UpdateBatchQty(results(0))
//                    Loop
//                End If
//            End Using
//        End Using
//
//        Utilities.ScreenWaitCaption("Batch Quantities...")
//        Dim sql1 = "Select ID, BatchName from Batch"
//        Using connection = New MySqlConnection(My.Settings.BMConnString)
//            Using command = New MySqlCommand(sql1, connection)
//                connection.Open()
//                Dim results = command.ExecuteReader()
//
//                If results.HasRows Then
//                    Do While results.Read
//                        Utilities.ScreenWaitDescription("Updating:" & results(1).ToString)
//                        Asset.Container.UpdateBatchQty(Convert.ToInt32(results(0)))
//                    Loop
//                End If
//            End Using
//        End Using
//
//        Utilities.ScreenWaitCaption("Asset Quantities...")
//        Dim sql2 = "Select ID, AssetName from Assets"
//        Using connection = New MySqlConnection(My.Settings.BMConnString)
//            Using command = New MySqlCommand(sql2, connection)
//                connection.Open()
//                Dim results = command.ExecuteReader()
//                If results.HasRows Then
//                    Do While results.Read
//                        Utilities.ScreenWaitDescription("Updating:" & results(1).ToString)
//                        Asset.UpdateAssetQuantity(Convert.ToInt32(results(0)))
//                    Loop
//                End If
//            End Using
//        End Using
//
//        Utilities.ScreenWaitCaption("Purge Old Shifs...")
//        Dim sql3 = "SELECT ID FROM BusinessManager.Shifts Where DutyDate < DATE_ADD(CurDate(), INTERVAL -10 Year)"
//        Using connection = New MySqlConnection(My.Settings.BMConnString)
//            Using command = New MySqlCommand(sql3, connection)
//                connection.Open()
//                Dim results = command.ExecuteReader()
//
//                If results.HasRows Then
//                    Do While results.Read
//                        Dim shiftId As Integer = Convert.ToInt32(results(0))
//                        Utilities.ScreenWaitDescription("Removing:" & shiftId)
//                        If Shifts.Details.HasPaperwork(shiftId) Then
//
//                            If Shifts.HasClinicalRecords(shiftId) Then
//                                Shifts.GetClinicalRecords(shiftId).ForEach(Sub(x)
//                                    Shifts.ClinicalRecord.DeleteCRPaperWork(x)
//                                    Shifts.ClinicalRecord.DeleteCR(x)
//                                End Sub)
//                            End If
//
//                            Dim filepath = Shifts.Details.GetPaperWorkPath(shiftId)
//
//                            If Directory.Exists(Path.GetDirectoryName(filepath)) Then
//                                Directory.Delete(Path.GetDirectoryName(filepath), True)
//                            End If
//                            Shifts.Details.DeleteShift(shiftId)
//                        End If
//                    Loop
//                End If
//            End Using
//        End Using
//
//
//        Utilities.ScreenWaitCaption("Updating Instructor Status...")
//        Dim sql5 = "SELECT ID, QualExp  FROM BusinessManager.InstQuals Where QualExpired=0"
//        Using connection = New MySqlConnection(My.Settings.BMConnString)
//            Using command = New MySqlCommand(sql5, connection)
//                connection.Open()
//                Dim results = command.ExecuteReader()
//
//                If results.HasRows Then
//                    Do While results.Read
//                        Dim id As Integer = Convert.ToInt32(results(0))
//
//                        If Utilities.DataHelper.IsNullOrEmpty(results(1)) Then
//
//                            Utilities.ScreenWaitDescription("Expiring:" & id)
//                            Personnel.SetQualExpired(id)
//
//                        Else
//
//                            Dim exp As DateTime = DateTime.Parse(results(1).ToString)
//                            Utilities.ScreenWaitDescription("Updating:" & id)
//                            If exp < Today Then
//
//                                Utilities.ScreenWaitDescription("Expiring:" & id)
//                                Personnel.SetQualExpired(id)
//
//                            End If
//
//
//                        End If
//
//
//                    Loop
//                End If
//            End Using
//        End Using
//
//        Utilities.ScreenWaitCaption("Purge Old Courses...")
//        Dim sql6 = "SELECT ID FROM BusinessManager.Students Where DateofCourse <= DATE_ADD(CurDate(), INTERVAL -5 Year)"
//        Using connection = New MySqlConnection(My.Settings.BMConnString)
//            Using command = New MySqlCommand(sql6, connection)
//                connection.Open()
//                Dim results = command.ExecuteReader()
//
//                If results.HasRows Then
//                    Do While results.Read
//                        Dim shiftId As Integer = Convert.ToInt32(results(0))
//                        Utilities.ScreenWaitDescription("Removing:" & shiftId)
//                        If Course.Details.CourseHasPaperwork(shiftId) Then
//
//                            Dim filepath = Course.Details.GetCoursePaperworkPath(shiftId)
//
//                            If Directory.Exists(Path.GetDirectoryName(filepath)) Then
//                                Directory.Delete(Path.GetDirectoryName(filepath), True)
//                            End If
//                            Course.Details.DeleteStudents(shiftId)
//                        End If
//                        Course.Details.DeleteCourse(shiftId)
//                    Loop
//                End If
//            End Using
//        End Using
//
//        Utilities.ScreenWaitDescription("Working...")
//        Utilities.ScreenWaitCaption("Purge Directories...")
//        ProcessDirectory("Y:\Training Courses\")
//        ProcessDirectory("Y:\Clinical Shifts\")
//        Dim sql4 = "Delete FROM BusinessManager.UserActivities Where Time < DATE_ADD(CurDate(), INTERVAL -3 Year)"
//        Using connection = New MySqlConnection(My.Settings.BMConnString)
//            Using command = New MySqlCommand(sql4, connection)
//                connection.Open()
//                command.ExecuteNonQuery()
//
//            End Using
//        End Using
//
//        Utilities.ScreenWaitCaption("Clean GPS...")
//        General.CleanGPS()
//        Utilities.ScreenWait(False)
//        Utilities.StopTaskBarAssistant()
//    End Sub

	public void ProcessDirectory(string startLocation)
	{

		foreach (var directory in System.IO.Directory.GetDirectories(startLocation))
		{

			ProcessDirectory(directory);
			Utilities.ScreenWaitDescription(directory);
			if (System.IO.Directory.GetFiles(directory).Length == 0 && System.IO.Directory.GetDirectories(directory).Length == 0)
			{
				System.IO.Directory.Delete(directory, false);
			}

		}
	}

	private void ReportProg(int @int)
	{

		int xI = @int;
		int c = 0;

		if (@int >= 100)
		{

			c += 10;

			BackgroundWorker1.ReportProgress(0);

			BackgroundWorker1.ReportProgress(Convert.ToInt32(xI / (double)c));
		}
		else
		{
			BackgroundWorker1.ReportProgress(xI);
		}
	}

//    Private Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork
//        Try
//            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
//            'Dim num2 As Integer = (grdMyInbox.DataRowCount - 1)
//            'Do While (i >= 0)
//            ' ' GridView1.FocusedRowHandle = i
//            ' 'Thread.Sleep(100)
//
//            ' BackgroundWorker1.ReportProgress(c / count * 100)
//            ' c += 1
//            ' If grdMyInbox.GetRowCellValue(i, "Type").ToString = "Lead" Then
//            ' Leads.SanityCheck(grdMyInbox.GetRowCellValue(i, "ID"))
//            ' End If
//            ' i = (i + -1)
//            'Loop
//
//            BackgroundWorker1.ReportProgress(0)
//            'brProgress.EditValue = 0
//
//            Dim sql = "Select ID, Status, ExpiryDate, DateofCourse from Students Where Status<>'Expired'"
//            'Dim sql1 = "Select ID,Course, Status, Cert, ExpiryDate, DateofCourse from Students"
//
//            SplashScreenManager.Default.SetWaitFormDescription("Removing blank students & updating student count...")
//            Using con As New MySqlConnection(My.Settings.BMConnString)
//
//                'Function 1
//                Using cmd As New MySqlCommand(sql, con)
//                    con.Open()
//                    Using reader = cmd.ExecuteReader
//                        If reader.HasRows Then
//                            Dim i As Integer
//                            Do While reader.Read
//
//                                If Not reader("DateofCourse") Is DBNull.Value Then
//                                    If DateTime.Parse(CStr(reader("DateofCourse"))) < Today Then
//                                        Course.Details.RemoveBlankStudents(Convert.ToInt32(reader("ID")))
//                                        'Course.Details.SetCourseStudentCount(reader("ID"))
//                                    End If
//                                End If
//
//                                i += 1
//                                ReportProg(i)
//                            Loop
//
//                        End If
//                    End Using
//                    con.Close()
//                End Using
//
//                '''''''''''''''''''''''''''''''''''''''#########################################
//                Dim listOfCourses As List(Of String) = Course.Programme.GetListofBodyCourses("IHF")
//
//                Dim s =
//                        "SELECT Personnell.ID,Personnell.InstructorName,InstQuals.CoursesName,InstQuals.InstructorNo FROM Personnell INNER JOIN InstQuals ON Personnell.ID = InstQuals.InstructorID WHERE InstQuals.QualExpired = 0 AND InstQuals.CoursesName = @C"
//                Dim z =
//                        "SELECT Instructor_Courses.Instructor_ID, Students.Course, Instructor_Courses.CSE_ID FROM Instructor_Courses INNER JOIN Students ON Instructor_Courses.CSE_ID = Students.ID WHERE Instructor_Courses.Instructor_ID =@PID AND Students.Course = @C"
//                Dim z1 = "Update Instructor_Courses Set Inst_No=@V Where CSE_ID=@CSEID"
//                'Get a list of all the IHF Courses
//                SplashScreenManager.Default.SetWaitFormDescription("Updating Instructors Numbers on old courses...")
//                For Each course As String In listOfCourses
//
//                    'Get a list of all the people who teach that course
//                    Using cmd As New MySqlCommand(s, con)
//                        cmd.Parameters.Clear()
//                        cmd.Parameters.AddWithValue("@C", course.ToString())
//                        Using reader = cmd.ExecuteReader()
//
//                            If reader.HasRows Then
//                                Do While reader.Read()
//                                    'Get a list of all the specific courses that the instructor has thought.
//                                    Using con1 As New MySqlConnection(My.Settings.BMConnString)
//                                        Using cmd1 As New MySqlCommand(z, con1)
//                                            con1.Open()
//                                            cmd1.Parameters.Clear()
//                                            cmd1.Parameters.AddWithValue("@C", course.ToString())
//                                            cmd1.Parameters.AddWithValue("@PID", reader("ID").ToString)
//
//                                            Using courses = cmd1.ExecuteReader()
//
//                                                If courses.HasRows Then
//
//                                                    Dim i As Integer
//                                                    Do While courses.Read()
//
//                                                        Using con2 As New MySqlConnection(My.Settings.BMConnString)
//                                                            Using cmd3 As New MySqlCommand(z1, con2)
//                                                                con2.Open()
//                                                                cmd3.Parameters.Clear()
//                                                                cmd3.Parameters.AddWithValue("@V",
//                                                                                             reader("InstructorNo").
//                                                                                                ToString())
//                                                                cmd3.Parameters.AddWithValue("@CSEID",
//                                                                                             courses("CSE_ID").ToString())
//                                                                cmd3.ExecuteNonQuery()
//                                                            End Using
//                                                            i += 1
//                                                            ReportProg(i)
//                                                        End Using
//                                                    Loop
//                                                End If
//                                            End Using
//                                        End Using
//                                    End Using
//                                Loop
//                            End If
//                        End Using
//                        con.Close()
//                    End Using
//
//                Next
//
//            End Using
//        Catch ex As Exception
//            Utilities.MyError(ex)
//        Finally
//            SplashScreenManager.CloseForm(False)
//        End Try
//    End Sub

	private void bgwGlobalCompliance_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{

		brProgress.Visibility = BarItemVisibility.Never;
		brProgress.EditValue = 0;
		BtnRefresh.PerformClick();
	}

	private void BackgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
	{

		brProgress.EditValue = e.ProgressPercentage;
	}

	private void btnFilterTask_ItemClick(object sender, ItemClickEventArgs e)
	{
		General.Filter.ShowTasks(grdMyInbox);
	}

	private void btnFilterLead_ItemClick(object sender, ItemClickEventArgs e)
	{
		General.Filter.ShowLeads(grdMyInbox);
	}

	private void btnFilterEmail_ItemClick(object sender, ItemClickEventArgs e)
	{
		General.Filter.ShowEmails(grdMyInbox);
	}

	private void BarButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
	{
		General.Filter.ShowAll(grdMyInbox);
	}

	private void GovGrid_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
	{

		// (e.Column.Name)
		if (e.Column.Name == "colType2" || e.Column.FieldName == "Reference")
		{
			if (GovGrid.GetFocusedRowCellValue("Type").ToString() == "Policy")
			{
				_han = (IOverlaySplashScreenHandle)Utilities.ShowProgressPanel(this);
				frmPolicy_Edit frm = new frmPolicy_Edit(this, chkCaptureCopy.Checked);
				frm.LoadDetails(Convert.ToInt32(GovGrid.GetRowCellValue(e.RowHandle, "ID")));
				frm.Show(this);
				Utilities.CloseProgressPanel(_han);
			}
			else
			{

				_han = (IOverlaySplashScreenHandle)Utilities.ShowProgressPanel(this);
				frmGov_Details frm = new frmGov_Details(this, chkCaptureCopy.Checked);
				frm.LoadDetails(Convert.ToInt32(GovGrid.GetRowCellValue(e.RowHandle, "ID")));
				frm.Show(this);
				Utilities.CloseProgressPanel(_han);
			}

		}
		else if (e.Column.Name == "GridColumn15")
		{
			RepositoryItemCheckEdit12_Click(null, null);
		}
	}

	private void GovGrid_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
	{

		if (e.HitInfo.InRowCell)
		{

			GovGrid.FocusedRowHandle = e.HitInfo.RowHandle;

			if (Convert.ToBoolean(GovGrid.GetRowCellValue(GovGrid.FocusedRowHandle, "Included")) == true)
			{
				btnFindReferences.Enabled = true;
			}
			else
			{
				btnFindReferences.Enabled = false;
			}

			if (GovGrid.GetRowCellValue(GovGrid.FocusedRowHandle, "Status").ToString() == "Applicable")
			{
				btnGovApplicapable.Enabled = false;
				btnGovNotApplicable.Enabled = true;
			}
			else
			{
				btnGovApplicapable.Enabled = true;
				btnGovNotApplicable.Enabled = false;
			}

			Popup.ShowPopup(GovGrid.GridControl.PointToScreen(e.Point));
		}
	}

	private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{

		brProgress.Visibility = BarItemVisibility.Never;
		brProgress.EditValue = 0;
	}

	private void btnOpenGov_ItemClick(object sender, ItemClickEventArgs e)
	{
		frmGov_Details frm = new frmGov_Details(this, chkCaptureCopy.Checked);
		frm.LoadDetails(Convert.ToInt32(GovGrid.GetRowCellValue(GovGrid.FocusedRowHandle, "ThenID")));
		frm.Show(this);
	}

	private void TreeList1_DoubleClick(object sender, EventArgs e)
	{
		try
		{

			TreeListHitInfo hitinfo = TreeList1.CalcHitInfo(TreeList1.PointToClient(System.Windows.Forms.Cursor.Position));

			if (hitinfo.HitInfoType == HitInfoType.Button)
			{
				return;
			}

			if ((TreeList1.FocusedNode.GetValue("ItemRef") == null) || (TreeList1.FocusedNode.GetValue("ItemRef") == DBNull.Value))
			{
				// XtraMessageBox.Show("This item has no parent.", "No Parent", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
			}
			else
			{
				_han = (IOverlaySplashScreenHandle)Utilities.ShowProgressPanel(this);
				frmGov_Details detail = new frmGov_Details(this, chkCaptureCopy.Checked);
				detail.LoadDetails(Utilities.SafeInt(TreeList1.FocusedNode.GetValue("ItemRef")));
				detail.ShowDialog(this);
				Utilities.CloseProgressPanel(_han);
			}
		}
		catch (Exception exception1)
		{
			Utilities.MyError(exception1);
		}
	}

	private void btnOpenItem_ItemClick(object sender, ItemClickEventArgs e)
	{
		frmGov_Details detail = new frmGov_Details(this, chkCaptureCopy.Checked);
		detail.LoadDetails(_treeItemId);
		detail.ShowDialog(this);
	}

	private void btnOpenFile_ItemClick(object sender, ItemClickEventArgs e)
	{
		try
		{
			Gov.ViewGovFile(Utilities.SafeInt(TreeList1.FocusedNode.GetValue("ItemRef")));
		}
		catch (Exception exception1)
		{
			Utilities.MyError(exception1);
		}
	}

	private void btnRename_ItemClick(object sender, ItemClickEventArgs e)
	{
		try
		{
			_colEdit = true;
			TreeListNode focusedNode = TreeList1.FocusedNode;
			_oldCellValue = Utilities.SafeString(focusedNode.GetValue("Section"));
			TreeList1.ShowEditor();
		}
		catch (Exception ex)
		{
			Utilities.MyError(ex);
		}
	}

	private void btnCopyItem_ItemClick(object sender, ItemClickEventArgs e)
	{
		try
		{
			Clipboard.SetText((TreeList1.FocusedNode.GetValue("Section") == null ? null : Convert.ToString(TreeList1.FocusedNode.GetValue("Section"))));
		}
		catch (Exception ex)
		{
			Utilities.MyError(ex);
		}
	}

	private void btnNewSection_ItemClick(object sender, ItemClickEventArgs e)
	{
		//Try
		TreeListNode focusedNode = TreeList1.FocusedNode;
		object obj2 = Gov.AddGov(General.GovType.Section, Utilities.SafeInt(focusedNode.GetValue("ID")));
		//GovTableAdapter.Fill(GovDataSet.Gov);
		TreeList1.FocusedNode = TreeList1.FindNodeByKeyID(obj2);
		_colEdit = true;
		_oldCellValue = Utilities.SafeString(focusedNode.GetValue("Section"));
		TreeList1.ShowEditor();
		//Catch ex As Exception
		// MyError(ex)
		//End Try
	}

	private void btnRemoveItemGov_ItemClick(object sender, ItemClickEventArgs e)
	{
		if (Convert.ToBoolean(TreeList1.FocusedNode.GetValue("Fixed")) == true)
		{
			XtraMessageBox.Show("You cannot remove this section. It is a fixed Section", "Not Possible", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
		else if (TreeList1.FocusedNode.HasChildren)
		{
			XtraMessageBox.Show("You cannot remove a section without first removing its sub sections. Remove them first and try again", "Not Possible", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
		else
		{
			var textArray1 = new string[] {"'", TreeList1.FocusedNode.ParentNode.GetValue("Section").ToString() + "\\" + TreeList1.FocusedNode.GetValue("Section").ToString(), "'", Environment.NewLine, Environment.NewLine, "Do you want to remove this item from the Tree?"};
			switch (XtraMessageBox.Show(string.Concat(textArray1), "Remove Item", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation))
			{
				case System.Windows.Forms.DialogResult.Yes:
					try
					{
						// _treeState.SaveState()
						Gov.RemoveGov(Utilities.SafeInt(TreeList1.FocusedNode.GetValue("ID")));
						TreeList1.FocusedNode.Remove();
						//Me.TreeList1.FocusedNode = Me.TreeList1.FindNodeByKeyID(keyID)
						if (Utilities.DataHelper.IsNull(TreeList1.FocusedNode.GetValue("ItemRef")) == false)
						{
							Gov.GovNotAssigned(Utilities.SafeInt(TreeList1.FocusedNode.GetValue("ItemRef")));
						}
						else
						{

						}
						TreeList1.ClearColumnsFilter();
						//RefreshMain(False)

						// TreeList1.FocusedNode = n.ParentNode
					}
					catch (Exception ex)
					{
						Utilities.MyError(ex);
					}
					break;
			}
		}
	}

	private void btnMoveUp_ItemClick(object sender, ItemClickEventArgs e)
	{
		MoveNode(General.MoveDirection.Up);
	}

	private void btnMoveDown_ItemClick(object sender, ItemClickEventArgs e)
	{
		// Me.TreeState.SaveState()
		// Dim focusedNode As TreeListNode = Me.TreeList1.FocusedNode
		// Dim myID As Integer = Utilities.SafeInt(focusedNode.GetValue("ID"))
		// Gov.MoveGovItem(Direction.Down, myID, Utilities.SafeInt(focusedNode.GetValue("ParentID")), Utilities.SafeString(focusedNode.GetValue("Type")))
		// Me.TreeState.SaveState()
		// Me.GovTableAdapter.Fill(Me.GovDataSet.Gov)
		// Me.TreeState.LoadState()
		// Me.TreeList1.FocusedNode = Me.TreeList1.FindNodeByKeyID(myID)
		MoveNode(General.MoveDirection.Down);
	}

	private void btnExpandTree_ItemClick(object sender, ItemClickEventArgs e)
	{
		TreeList1.FocusedNode.ExpandAll();
	}

	private void btnCollapseTree_ItemClick(object sender, ItemClickEventArgs e)
	{
		TreeList1.FocusedNode.Expanded = false;
	}

	private void btnRemoveItem_ItemClick(object sender, ItemClickEventArgs e)
	{

		switch (XtraMessageBox.Show(GovGrid.GetRowCellValue(GovGrid.FocusedRowHandle, "Statement").ToString() + Environment.NewLine + Environment.NewLine + "Do you want to delete this item? This cannot be un-done!", "Delete Item", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation))
		{
			case System.Windows.Forms.DialogResult.Yes:
				var cmdText = "Delete from GovStandards Where ID=@ID";
				using (var connection = new MySqlConnection(BM.Core.MySQlHelper.ConnectionString))
				{
					connection.Open();
					using (var command = new MySqlCommand(cmdText, connection))
					{
						command.Parameters.AddWithValue("@ID", GovGrid.GetRowCellValue(GovGrid.FocusedRowHandle, "ID"));
						command.ExecuteNonQuery();
					}
				}
				BtnRefresh.PerformClick();
				break;
		}
	}

	private void btnFindReferences_ItemClick(object sender, ItemClickEventArgs e)
	{

		//TreeList1.OptionsBehavior.EnableFiltering = True
		//TreeList1.OptionsFilter.FilterMode = FilterMode.Extended
		//Dim num As Integer = Utilities.SafeInt(GovGrid.GetRowCellValue(GovGrid.FocusedRowHandle, "ID"))
		//Dim condition As New XtraTreeList.FilterCondition(FilterConditionEnum.NotEquals, colItemRef, num)

		//TreeList1.FilterConditions.Clear()
		//TreeList1.FilterConditions.Add(condition)
		//btnClearTreeFilter.Enabled = True
		// (GovGrid.GetRowCellValue(GovGrid.FocusedRowHandle, "ID"))
		TreeList1.OptionsSelection.MultiSelect = true;
		var n = TreeList1.FindNodeByFieldValue("ItemRef", GovGrid.GetRowCellValue(GovGrid.FocusedRowHandle, "ID"));
		if (n == null)
		{

			//("Noithing")
		}
		else
		{
			TreeList1.OptionsSelection.EnableAppearanceFocusedRow = false;
			TreeList1.FocusedNode = n;
			TreeList1.Selection.Clear();
			TreeList1.Selection.Add(n);

		}
	}

	private void TreeList1_MouseUp(object sender, MouseEventArgs e)
	{
	}

	private void btnAddEvidence_ItemClick(object sender, ItemClickEventArgs e)
	{
		try
		{
			//_treeState.SaveState()
			TreeListNode focusedNode = TreeList1.FocusedNode;
			object obj2 = Gov.AddGov(General.GovType.Evidence, Utilities.SafeInt(focusedNode.GetValue("ID")));
			//GovTableAdapter.Fill(GovDataSet.Gov)
			RefreshMain(false, "Main Refresh - Add Evidence");
			//_treeState.LoadState()
			TreeList1.FocusedNode = TreeList1.FindNodeByKeyID(obj2);
		}
		catch (Exception exception1)
		{
			Utilities.MyError(exception1);
		}
	}

	private void btnAddGovTask_ItemClick(object sender, ItemClickEventArgs e)
	{
		try
		{
			_treeState.SaveState();
			TreeListNode focusedNode = TreeList1.FocusedNode;
			object obj2 = Gov.AddGov(General.GovType.Task, Utilities.SafeInt(focusedNode.GetValue("ID")));
			//GovTableAdapter.Fill(GovDataSet.Gov);
			_treeState.LoadState();
			TreeList1.FocusedNode = TreeList1.FindNodeByKeyID(obj2);
		}
		catch (Exception exception1)
		{
			Utilities.MyError(exception1);
		}
	}

	private void btnAddGuideline_ItemClick(object sender, ItemClickEventArgs e)
	{
		//Try
		_treeState.SaveState();
		TreeListNode focusedNode = TreeList1.FocusedNode;
		object obj2 = Gov.AddGov(General.GovType.Guideline, Utilities.SafeInt(focusedNode.GetValue("ID")));
		//GovTableAdapter.Fill(GovDataSet.Gov);
		_treeState.LoadState();
		TreeList1.FocusedNode = TreeList1.FindNodeByKeyID(obj2);
		_colEdit = true;

		_oldCellValue = Utilities.SafeString(focusedNode.GetValue("Section"));
		TreeList1.ShowEditor();
		//Catch exception1 As System.Exception
		// MyError(exception1)
		//End Try
	}

	private void btnAddItem_ItemClick(object sender, ItemClickEventArgs e)
	{
		_han = (IOverlaySplashScreenHandle)Utilities.ShowProgressPanel(this);

		XtraInputBoxArgs args = new XtraInputBoxArgs();
		args.Caption = "Governance Type";
		args.Prompt = "Select Type";
		args.DefaultButtonIndex = 0;
		ComboBoxEdit editor = new ComboBoxEdit();
		editor.Properties.Items.AddRange(new[] {"Policy", "Standard", "Evidence", "KPI"});
		args.Editor = editor;
		args.DefaultResponse = editor.Properties.Items[0];
		var result = XtraInputBox.Show(args);

		if (result != null && result.ToString().Length > 0)
		{
			frmGov_Details frm = new frmGov_Details(this, chkCaptureCopy.Checked);
			frm.LoadDetails(Gov.AddGovItem((result == null ? null : Convert.ToString(result))));
			frm.Show(this);
			//GovStandardsTableAdapter.Fill(GovDataSet.GovStandards);
			Utilities.CloseProgressPanel(_han);
		}
	}

	private void btnAddLegislation_ItemClick(object sender, ItemClickEventArgs e)
	{

		try
		{
			_treeState.SaveState();
			TreeListNode focusedNode = TreeList1.FocusedNode;
			object obj2 = Gov.AddGov(General.GovType.Legislation, Utilities.SafeInt(focusedNode.GetValue("ID")));
			//GovTableAdapter.Fill(GovDataSet.Gov);
			_treeState.LoadState();
			TreeList1.FocusedNode = TreeList1.FindNodeByKeyID(obj2);
		}
		catch (Exception exception1)
		{
			Utilities.MyError(exception1);
		}
	}

	private void btnAddPolicy_ItemClick(object sender, ItemClickEventArgs e)
	{
		try
		{
			_treeState.SaveState();
			TreeListNode focusedNode = TreeList1.FocusedNode;
			object obj2 = Gov.AddGov(General.GovType.Policy, Utilities.SafeInt(focusedNode.GetValue("ID")));
			//GovTableAdapter.Fill(GovDataSet.Gov);
			_treeState.LoadState();
			TreeList1.FocusedNode = TreeList1.FindNodeByKeyID(obj2);
		}
		catch (Exception exception1)
		{
			Utilities.MyError(exception1);
		}
	}

	private void btnAddKPI_ItemClick(object sender, ItemClickEventArgs e)
	{
		try
		{
			_treeState.SaveState();
			TreeListNode focusedNode = TreeList1.FocusedNode;
			object obj2 = Gov.AddGov(General.GovType.Kpi, Utilities.SafeInt(focusedNode.GetValue("ID")));
			//GovTableAdapter.Fill(GovDataSet.Gov);
			_treeState.LoadState();
			TreeList1.FocusedNode = TreeList1.FindNodeByKeyID(obj2);
		}
		catch (Exception exception1)
		{
			Utilities.MyError(exception1);
		}
	}

	private void btnAddStandard_ItemClick(object sender, ItemClickEventArgs e)
	{
		try
		{
			_treeState.SaveState();
			TreeListNode focusedNode = TreeList1.FocusedNode;
			object obj2 = Gov.AddGov(General.GovType.Standard, Utilities.SafeInt(focusedNode.GetValue("ID")));
			//GovTableAdapter.Fill(GovDataSet.Gov);
			_treeState.LoadState();
			TreeList1.FocusedNode = TreeList1.FindNodeByKeyID(obj2);
		}
		catch (Exception exception1)
		{
			Utilities.MyError(exception1);
		}
	}

	private void TreeList1_AfterCollapse(object sender, NodeEventArgs e)
	{
		if (e.Node.StateImageIndex == 1)
		{
			e.Node.StateImageIndex = 0;
		}
	}

	private void TreeList1_AfterExpand(object sender, NodeEventArgs e)
	{
		if (e.Node.StateImageIndex == 0)
		{
			e.Node.StateImageIndex = 1;
		}
	}

	private void TreeList1_BeforeDragNode(object sender, BeforeDragNodeEventArgs e)
	{
		if (e.Node != null)
		{

			if (Utilities.SafeBoolean(e.Node.GetValue("Fixed")) == true)
			{
				e.CanDrag = false;
			}
			else
			{
				e.CanDrag = true;
			}
		}
	}

	private void TreeList1_CellValueChanged(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
	{

		try
		{
			TreeListNode focusedNode = TreeList1.FocusedNode;
			if (string.IsNullOrEmpty(Utilities.SafeString(e.Value)))
			{
				XtraMessageBox.Show("Name cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				e.Value = _oldCellValue;
				focusedNode.SetValue("Section", _oldCellValue);
			}
			else
			{
				Gov.RenameGov(e.Value, Convert.ToInt32(focusedNode.GetValue("ID")));
			}
			_colEdit = false;
		}
		catch (Exception exception1)
		{
			Utilities.MyError(exception1);
		}
	}

	private void TreeList1_CompareNodeValues(object sender, CompareNodeValuesEventArgs e)
	{

		if (e.Node1.HasChildren && e.Node2.HasChildren)
		{
			if (e.SortOrder == SortOrder.Ascending)
			{
				e.Result = - 1;
			}
			else
			{
				e.Result = 1;
			}
		}
		else
		{
			e.Result = string.Compare((e.NodeValue1 == null ? null : Convert.ToString(e.NodeValue1)), (e.NodeValue2 == null ? null : Convert.ToString(e.NodeValue2)));
		}
	}

	private void TreeList1_DragDrop(object sender, DragEventArgs e)
	{
		var list = (TreeList)sender;
		Point pt = list.PointToClient(new Point(e.X, e.Y));
		TreeListNode targetNode = list.CalcHitInfo(pt).Node;

		if (_dragfromGrid == false)
		{

			if (TreeList1.Selection.Count == 1)
			{
				if (XtraMessageBox.Show(string.Format("Are you sure you want to move {0} to {1}", TreeList1.FocusedNode.GetValue("Section"), targetNode.GetValue("Section")), "Move Item?", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
				{
					int selectedNode = Utilities.SafeInt(TreeList1.FocusedNode.GetValue("ID"));
					var data = (TreeListNode)e.Data.GetData(typeof(TreeListNode));
					list.SetNodeIndex(data, list.GetNodeIndex(targetNode));
					Gov.MoveGovParent(selectedNode, targetNode.GetValue("ID"));
					e.Effect = DragDropEffects.None;

					TreeList1.FocusedNode = TreeList1.FindNodeByKeyID(selectedNode);
				}
			}
			else
			{
				if (XtraMessageBox.Show(string.Format("Are you sure you want to move {0} items to {1}", TreeList1.Selection.Count, targetNode.GetValue("Section")), "Move Multiple Items?", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
				{

					foreach (TreeListNode selnode in TreeList1.Selection)
					{
						TreeList1.SetNodeIndex((TreeListNode)e.Data.GetData(typeof(TreeListNode)), list.GetNodeIndex(targetNode));
						Gov.MoveGovParent(Utilities.SafeInt(selnode.GetValue("ID")), targetNode.GetValue("ID"));

					}

					e.Effect = DragDropEffects.None;

				}

			}
		}
		else
		{

			var str = (GovGrid.GetRowCellValue(GovGrid.FocusedRowHandle, "ID") == null ? null : Convert.ToString(GovGrid.GetRowCellValue(GovGrid.FocusedRowHandle, "ID")));
			if (str == null)
			{
				//("Focused row ID is nothing")
				return;
			}
			else
			{

				if (targetNode == null)
				{
					e.Effect = DragDropEffects.None;
				}
				else
				{
					if (targetNode.GetValue("Section") == GovGrid.GetRowCellValue(GovGrid.FocusedRowHandle, "Type"))
					{
						int rh = GovGrid.FocusedRowHandle;
						var n = Gov.AddNewDragGov(Convert.ToInt32(targetNode.GetValue("ID")), GovGrid.GetRowCellValue(rh, "Type").ToString(), int.Parse(str), $@"{GovGrid.GetRowCellValue(rh, "Reference")} {GovGrid.GetRowCellValue(rh, "Name")} {GovGrid.GetRowCellValue(rh, "ID")}", Convert.ToInt32(GovGrid.GetRowCellValue(rh, "ID")));
						TreeList1.FocusedNode = TreeList1.FindNodeByKeyID(n);

						//node2.Expanded = True
						TreeList1.HideEditor();
					}
					else
					{

					}

				}
			}

		}
		_dragfromGrid = false;
		RefreshMain(true, "Main Refresh - Treelist Drag");
	}

	private void TreeList1_DragOver(object sender, DragEventArgs e)
	{
		var list = (TreeList)sender;
		Point pt = list.PointToClient(new Point(e.X, e.Y));

		TreeListNode focusedNode = TreeList1.FocusedNode;
		//Dim num As Integer = Utilities.SafeInt(focusedNode.GetValue("ID"))
		//Dim data As TreeListNode = DirectCast(e.Data.GetData(GetType(TreeListNode)), TreeListNode)
		TreeListNode node = list.CalcHitInfo(pt).Node;
		if (node == null)
		{
			e.Effect = DragDropEffects.None;
		}
		else if (!_dragfromGrid)
		{
			if (node.GetValue("Type").ToString() != "Section" && (node.GetValue("Type").ToString() == focusedNode.GetValue("Type").ToString()))
			{
				e.Effect = DragDropEffects.None;
			}
			else
			{
				e.Effect = DragDropEffects.Move;
			}
		}
		else
		{
			e.Effect = DragDropEffects.Copy;
		}
	}

	private void TreeList1_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
	{

		//Try
		_colEdit = false;

		TreeListNode node = e.Node;
		if (node != null)
		{
			_focusedTreeNode = Convert.ToInt32(node.GetValue("ID"));
			if (node.GetValue("ItemRef") is int)
			{

				txtGovInfo.Text = Gov.GetStatement(Convert.ToInt32(node.GetValue("ItemRef")));
			}
			else
			{
				txtGovInfo.Text = string.Empty;

			}
		}
		else
		{
			txtGovInfo.Text = string.Empty;
		}

		//Catch exception1 As System.Exception
		// MyError(exception1)
		//End Try
	}

	private void TreeList1_KeyDown(object sender, KeyEventArgs e)
	{
		// ("Tree " & e.KeyValue.ToString)
		switch (e.KeyValue)
		{

			case (System.Int32)Keys.Delete:
				btnRemoveItemGov_ItemClick(this, null);
				_colEdit = false;

				break;
			case (System.Int32)Keys.Escape:
				_colEdit = false;

				break;
			case (System.Int32)Keys.Return:
				_colEdit = false;

				break;
			case (System.Int32)Keys.PageUp:

				e.Handled = true;
				MoveNode(General.MoveDirection.Up);

				break;
			case (System.Int32)Keys.PageDown:

				e.Handled = true;
				MoveNode(General.MoveDirection.Down);

				break;
			case (System.Int32)Keys.Insert:
				e.Handled = true;
				TreeListNode focusedNode = TreeList1.FocusedNode;
				object obj2 = Gov.AddGov(General.GovType.Section, Utilities.SafeInt(focusedNode.GetValue("ID")));
				RefreshMain(false, "Main Refresh - Treelist Key");
				TreeList1.FocusedNode = TreeList1.FindNodeByKeyID(obj2);
				_colEdit = true;
				_oldCellValue = Utilities.SafeString(focusedNode.GetValue("Section"));
				TreeList1.ShowEditor();

				break;
			case (System.Int32)Keys.Right:
				e.Handled = true;
				TreeList1.FocusedNode.Expand();

				break;
			case (System.Int32)Keys.Left:
				e.Handled = true;
				TreeList1.FocusedNode.Collapse();

				break;
		}

		_colEdit = false;
	}

	private void TreeList1_MouseMove(object sender, MouseEventArgs e)
	{
		KeyPreview = false;
		var list = sender as TreeList;
		if (((e.Button == System.Windows.Forms.MouseButtons.Right) && (ModifierKeys == Keys.None)) && (list.State == TreeListState.Regular))
		{
			Point pt = list.PointToClient(MousePosition);
			TreeListHitInfo info = list.CalcHitInfo(pt);
			if (info.HitInfoType == HitInfoType.Cell)
			{
				//_savedFocused = list.FocusedNode
				list.FocusedNode = info.Node;
				//_needRestoreFocused = True
				if (Convert.IsDBNull(list.FocusedNode.GetValue("ItemRef")))
				{
					btnOpenItem.Enabled = false;
					btnOpenFile.Enabled = false;
				}
				else
				{
					if (Gov.GovHasFile(Utilities.SafeInt(list.FocusedNode.GetValue("ItemRef"))))
					{
						btnOpenFile.Enabled = true;
					}
					_treeItemId = Utilities.SafeInt(list.FocusedNode.GetValue("ItemRef"));
					btnOpenItem.Enabled = true;
				}
				puGov.ShowPopup(MousePosition);
			}
		}
	}

	private void btnFilterStandards_ItemClick(object sender, ItemClickEventArgs e)
	{

		Gov.Show.Filter(General.GovType.Standard, GovGrid);
	}

	private void btnFilterPolicies_ItemClick(object sender, ItemClickEventArgs e)
	{

		Gov.Show.Filter(General.GovType.Policy, GovGrid, colReviewDate1);
	}

	private void btnFilterEvidence_ItemClick(object sender, ItemClickEventArgs e)
	{

		Gov.Show.Filter(General.GovType.Evidence, GovGrid);
	}

	private void btnFilterKPI_ItemClick(object sender, ItemClickEventArgs e)
	{
		Gov.Show.Filter(General.GovType.Kpi, GovGrid);
	}

	private void btnFilterViewAll_ItemClick(object sender, ItemClickEventArgs e)
	{
		Gov.Show.Filter(General.GovType.All, GovGrid);
	}

	private void btnExpandAll_ItemClick(object sender, ItemClickEventArgs e)
	{
		TreeList1.ExpandAll();
	}

	private void TreeList1_ShowingEditor(object sender, CancelEventArgs e)
	{

		if (_colEdit == false)
		{
			e.Cancel = true;
		}
	}

	private void ClincalGridControl_DragDrop(object sender, DragEventArgs e)
	{
		try
		{

			Point pt = ClincalGridControl.PointToClient(new Point(e.X, e.Y));
			var info = (GridHitInfo)ClincalGridControl.MainView.CalcHitInfo(pt);
			int rowHandle = info.RowHandle;
			object objectValue = ClinicalGridView.GetRowCellValue(rowHandle, "ID");
			if (ClinicalGridView.IsValidRowHandle(info.RowHandle) == true)
			{
				if (objectValue != null || objectValue != DBNull.Value)
				{
					if (e.Data.GetDataPresent(DataFormats.FileDrop))
					{
						var files = (string[])e.Data.GetData(DataFormats.FileDrop);
						if (files.Length > 1)
						{
							XtraMessageBox.Show("You are trying to drop more than 1 file into this record. " + Environment.NewLine + "You can only drop 1 file per student." + Environment.NewLine + Environment.NewLine + "Select 1 file and try again.", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						}
						else
						{
							Shifts.Details.AddPaperWorkDrop(Convert.ToInt32(objectValue.ToString()), files[0]);
							BtnRefresh.PerformClick();
						}
					}
					else if (e.Data.GetDataPresent("FileGroupDescriptor"))
					{
						Shifts.Details.AddPaperWorkDrop(Convert.ToInt32(objectValue.ToString()), Utilities.DDHelper.DragEmailFile(e).FullName);
						BtnRefresh.PerformClick();

					}
				}
			}
		}
		catch (Exception ex)
		{
			Utilities.MyError(ex);
		}
	}

	private void btnShowInactive_EditValueChanged(object sender, EventArgs e)
	{

		SolutionSettings.ShowInactivePerson = bool.Parse(btnShowInactive.EditValue.ToString());
	}

	private void btn7DayReport_ItemClick(object sender, ItemClickEventArgs e)
	{
		CompanyReport r = new CompanyReport();
		r.Company.Value = _filterValue;
		r.Company.Visible = false;
		DateTime today = DateTime.Today;
		int dayIndex = (int)today.DayOfWeek;
		if (dayIndex < (int)DayOfWeek.Monday)
		{
			dayIndex += 7; //Monday is first day of week, no day of week should have a smaller index
		}
		int dayDiff = dayIndex - (int)DayOfWeek.Monday;
		DateTime startdate = today.AddDays(- dayDiff);

		r.Start.Value = startdate.AddDays(7);
		r.Start.Visible = false;
		r.Finish.Value = startdate.AddDays(14).AddSeconds(- 1);

		r.Finish.Visible = false;
		using (ReportPrintTool printTool = new ReportPrintTool(r))
		{
			printTool.ShowRibbonPreviewDialog();
		}
	}

	private void btnSummaryReport_ItemClick(object sender, ItemClickEventArgs e)
	{
	}

	private void btnDetailReport_ItemClick(object sender, ItemClickEventArgs e)
	{
	}

	private void btnThisMonthReport_ItemClick(object sender, ItemClickEventArgs e)
	{

		CompanyReport r = new CompanyReport();
		r.Company.Value = _filterValue;
		r.Company.Visible = false;
		DateTime mytoday = DateTime.Today;

		var time = new DateTime(mytoday.Year, mytoday.Month, 1);
		DateTime time2 = time.AddMonths(1).AddSeconds(- 1);

		r.Start.Value = time;
		r.Start.Visible = false;
		r.Finish.Value = time2;
		r.Finish.Visible = false;
		using (ReportPrintTool printTool = new ReportPrintTool(r))
		{
			printTool.ShowRibbonPreviewDialog();
		}
	}

	private void btnMonthReportLast_ItemClick(object sender, ItemClickEventArgs e)
	{

		CompanyReport r = new CompanyReport();
		r.Company.Value = _filterValue;
		r.Company.Visible = false;
		DateTime mytoday = DateTime.Today.AddMonths(- 1);

		var time = new DateTime(mytoday.Year, mytoday.Month, 1);
		DateTime time2 = time.AddMonths(1).AddSeconds(- 1);

		r.Start.Value = time;
		r.Start.Visible = false;
		r.Finish.Value = time2;
		r.Finish.Visible = false;
		using (ReportPrintTool printTool = new ReportPrintTool(r))
		{
			printTool.ShowRibbonPreviewDialog();
		}
	}

	private void btnMonthReportNext_ItemClick(object sender, ItemClickEventArgs e)
	{

		CompanyReport r = new CompanyReport();
		r.Company.Value = _filterValue;
		r.Company.Visible = false;
		DateTime mytoday = DateTime.Today.AddMonths(1);

		var time = new DateTime(mytoday.Year, mytoday.Month, 1);
		DateTime time2 = time.AddMonths(1).AddSeconds(- 1);

		r.Start.Value = time;
		r.Start.Visible = false;
		r.Finish.Value = time2;
		r.Finish.Visible = false;
		using (ReportPrintTool printTool = new ReportPrintTool(r))
		{
			printTool.ShowRibbonPreviewDialog();
		}
	}

	private void btnShiftTemplate_ItemClick(object sender, ItemClickEventArgs e)
	{
		frmShiftTemplate frm = new frmShiftTemplate(this);
		frm.ShowDialog();
	}

	private void schCourses_MouseMove(object sender, MouseEventArgs e)
	{
		try
		{
			_calMainView = CalView.Courses;
		}
		catch (Exception ex)
		{
			Utilities.MyError(ex);
		}
	}

	private void ClincalGridControl_DragOver(object sender, DragEventArgs e)
	{
		if (e.Data.GetDataPresent(DataFormats.FileDrop) | e.Data.GetDataPresent("FileGroupDescriptor"))
		{

			e.Effect = DragDropEffects.Copy;
		}
		else
		{
			e.Effect = DragDropEffects.None;
		}
	}

	private void SchedulerControl1_MouseMove(object sender, MouseEventArgs e)
	{
		_calMainView = CalView.Web;
	}

	//Private Sub RepositoryItemHyperLinkEdit1_OpenLink(sender As Object, e As OpenLinkEventArgs) _
	// Handles RepositoryItemHyperLinkEdit1.OpenLink

	// If String.IsNullOrEmpty(e.EditValue.ToString) Then
	// Exit Sub
	// End If
	// Const mailPrefix = "mailto:"

	// If Not e.EditValue.ToString().ToLower().StartsWith(mailPrefix) Then
	// e.EditValue = mailPrefix + e.EditValue.ToString()
	// End If
	//End Sub

	private void btnAddNote_ItemClick(object sender, ItemClickEventArgs e)
	{
		switch (XtraMessageBox.Show("Do you want to create a new note?", "Add Note?", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk))
		{
			case System.Windows.Forms.DialogResult.Yes:
				using (MySqlConnection connection = new MySqlConnection(BM.Core.MySQlHelper.ConnectionString))
				{
					connection.Open();
					var cmdText = "INSERT INTO BusinessNotes (CreatedBy, Title, Body) VALUES(@User, @Title, @Body)";
					using (MySqlCommand command = new MySqlCommand(cmdText, connection))
					{
						command.Parameters.AddWithValue("@User", SolutionSettings.CurrentUser.UserName);
						command.Parameters.AddWithValue("@Title", "New Note");
						command.Parameters.AddWithValue("@Body", string.Empty);
						command.ExecuteNonQuery();
					}
					int itemId = 0;
					MySqlCommand command2 = new MySqlCommand("Select MAX(ID) As MaxID From BusinessNotes Where (CreatedBy = @User)", connection);
					command2.Parameters.AddWithValue("@User", SolutionSettings.CurrentUser.UserName);
					itemId = Utilities.SafeInt(command2.ExecuteScalar());
					Security.LogEvent("Note Created", Security.AuditType.Note, itemId);
					frmNotes details = new frmNotes(this);
					details.LoadDetails(Convert.ToInt32(itemId));
					details.Show();

				}

				break;
		}
	}

	private void NvRisk_LinkClicked(object sender, NavBarLinkEventArgs e)
	{
		MoveScreen(e.Link, Screens.Risk, GridView11);
	}

	private void schCourses_PopupMenuShowing(object sender, DevExpress.XtraScheduler.PopupMenuShowingEventArgs e)
	{
		try
		{
			if (SolutionSettings.SchedulerSource == DataSource.General)
			{
				e.Menu.RemoveMenuItem(SchedulerMenuItemId.NewAppointment);
				e.Menu.RemoveMenuItem(SchedulerMenuItemId.NewAllDayEvent);
				e.Menu.Items.Add(new SchedulerMenuItem("New Appointment", newItem_Click, BM.Properties.Resources.outlook_new_meeting));
			}
			else
			{
				e.Menu.RemoveMenuItem(SchedulerMenuItemId.NewAppointment);
				e.Menu.RemoveMenuItem(SchedulerMenuItemId.NewAllDayEvent);
			}
		}
		catch (Exception ex)
		{
			Utilities.MyError(ex);
		}
	}

	private void newItem_Click(object sender, EventArgs e)
	{
		DateTime sd = default(DateTime);
		object o = schCourses.SelectedInterval.Start;

		if (o == null)
		{
			sd = DateTime.Today;
		}
		else
		{
			if (schCourses.SelectedAppointments.Count >= 1)
			{
				Appointment appointment = (Appointment)schCourses.SelectedAppointments[0];
				sd = appointment.Start;
			}
			else
			{

				sd = schCourses.SelectedInterval.Start;
			}

		}

		if (sd.Equals(DateTime.MinValue))
		{
			return;
		}

		switch (XtraMessageBox.Show("Do you want to create a new appointment on the " + DateTime.Parse(Convert.ToString(sd)).ToString("ddd, dd MMM yy"), "New Appointment", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
		{
			case System.Windows.Forms.DialogResult.Yes:
				General.AddAppointment(sd);
				BtnRefresh.PerformClick();

				break;
		}
	}

	private void btnStats_ItemClick(object sender, ItemClickEventArgs e)
	{
		Utilities.ScreenWait(true, "Loading Stats");
		FrmTrainingStats frm = new FrmTrainingStats();
		frm.Show(this);
		Utilities.CloseProgressPanel(_han);
	}

	//Private Sub BarButtonItem11_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem11.ItemClick
	// AdvBandedGridView1.ShowPrintPreview()
	//End Sub

	private void navDocuments_LinkClicked(object sender, NavBarLinkEventArgs e)
	{
		MoveScreen(e.Link, Screens.Documents, GridView10);
	}

	private void GridView10_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
	{
		try
		{

//INSTANT C# NOTE: The following VB 'Select Case' included either a non-ordinal switch expression or non-ordinal, range-type, or non-constant 'Case' expressions and was converted to C# 'if-else' logic:
//			Select Case e.Column.FieldName
//ORIGINAL LINE: Case "ID"
			if (e.Column.FieldName == "ID")
			{
				frmDocument_Details frm = new frmDocument_Details(this);
				frm.LoadDetails(Convert.ToInt32(GridView10.GetRowCellValue(e.RowHandle, "ID")));
				frm.Show(this);
			}
//ORIGINAL LINE: Case "GridColumn29"
			else if (e.Column.FieldName == "GridColumn29")
			{
				RepositoryItemCheckEdit18_Click(null, null);

			}
//ORIGINAL LINE: Case colViewDocument.FieldName
			else if (e.Column.FieldName == colViewDocument.FieldName)
			{
				Utilities.FileHelper.LaunchFile((GridView10.GetRowCellValue(e.RowHandle, "Path") == null ? null : Convert.ToString(GridView10.GetRowCellValue(e.RowHandle, "Path"))));
			}
		}
		catch (Exception ex)
		{

		}
	}

	private void btnAddDocument_ItemClick(object sender, ItemClickEventArgs e)
	{
		switch (XtraMessageBox.Show("Do you want to add a new document?", "New Document", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
		{
			case System.Windows.Forms.DialogResult.Yes:
				frmDocument_Details frm = new frmDocument_Details(this);
				frm.LoadDetails(BM.Area.Document.AddNewDocumentRecord());
				frm.Show(this);
				DocumentsTableAdapter.Fill(MainDataSet.Documents);
				break;
		}
	}

	private void BarButtonItem13_ItemClick(object sender, ItemClickEventArgs e)
	{
		BM.Area.Document.Show.Current(GridView10);
	}

	private void BarButtonItem14_ItemClick(object sender, ItemClickEventArgs e)
	{
		BM.Area.Document.Show.All(GridView10);
	}

	private void GridView11_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
	{

		if (e.Column.FieldName == "ID")
		{
			Utilities.ScreenWait();
			frmRisk_Details frm = new frmRisk_Details(this);
			frm.LoadDetails(Convert.ToInt32(GridView11.GetRowCellValue(e.RowHandle, "ID")));
			frm.Show(this);
			Utilities.CloseProgressPanel(_han);
		}
	}

	private void BarButtonItem15_ItemClick(object sender, ItemClickEventArgs e)
	{
		var sql = "Insert into Risks (Risk, Identified, ReviewDate) values ('New Risk',@T,@T)";
		using (MySqlConnection con = new MySqlConnection(BM.Core.MySQlHelper.ConnectionString))
		{
			using (MySqlCommand cmd = new MySqlCommand(sql, con))
			{
				con.Open();
				cmd.Parameters.AddWithValue("@T", DateTime.Today);
				cmd.ExecuteNonQuery();
			}
			con.Close();
		}

		RisksTableAdapter.Fill(MainDataSet.Risks);
	}

	private void TabPane1_SelectedPageChanged(object sender, SelectedPageChangedEventArgs e)
	{

		if (e.Page.Caption == "My Inbox")
		{
		}
		else
		{

		}
	}

	private void btnViewFilter_ItemClick(object sender, ItemClickEventArgs e)
	{
		DevExpress.XtraGrid.Views.Grid.GridView tempVar = SolutionSettings.VisibleGrid;
		Utilities.GridHelp.ViewFilter(ref tempVar);
		SolutionSettings.VisibleGrid = tempVar;
	}

	private void btnFooterFilter_ItemClick(object sender, ItemClickEventArgs e)
	{
		DevExpress.XtraGrid.Views.Grid.GridView tempVar = SolutionSettings.VisibleGrid;
		Utilities.GridHelp.ViewActiveFilter(ref tempVar);
		SolutionSettings.VisibleGrid = tempVar;
	}

	private void btnViewFind_ItemClick(object sender, ItemClickEventArgs e)
	{
		DevExpress.XtraGrid.Views.Grid.GridView tempVar = SolutionSettings.VisibleGrid;
		Utilities.GridHelp.ViewFind(ref tempVar);
		SolutionSettings.VisibleGrid = tempVar;
	}

	private void btnViewFooter_ItemClick(object sender, ItemClickEventArgs e)
	{
		DevExpress.XtraGrid.Views.Grid.GridView tempVar = SolutionSettings.VisibleGrid;
		Utilities.GridHelp.ViewFooter(ref tempVar);
		SolutionSettings.VisibleGrid = tempVar;
	}

	private void btnHorLines_ItemClick(object sender, ItemClickEventArgs e)
	{
		DevExpress.XtraGrid.Views.Grid.GridView tempVar = SolutionSettings.VisibleGrid;
		Utilities.GridHelp.HorizontalLines(ref tempVar);
		SolutionSettings.VisibleGrid = tempVar;
	}

	private void btnCellMerge_ItemClick(object sender, ItemClickEventArgs e)
	{
		DevExpress.XtraGrid.Views.Grid.GridView tempVar = SolutionSettings.VisibleGrid;
		Utilities.GridHelp.AllowCellMerge(ref tempVar);
		SolutionSettings.VisibleGrid = tempVar;
	}

	private void frmMain_Resize(object sender, EventArgs e)
	{
		if (Networking.IsWebSiteAvailable == true)
		{
			if (_showWeb)
			{
				SplitContainerControl4.SplitterPosition = Convert.ToInt32(SplitContainerControl4.Width / 2.0);
				SplitContainerControl4.PanelVisibility = SplitPanelVisibility.Both;
			}
			else
			{
				SplitContainerControl4.PanelVisibility = SplitPanelVisibility.Panel2;
				SplitContainerControl4.SplitterPosition = 0;
			}

		}
	}

	private void SchedulerControl1_CustomDrawDayHeader(object sender, DevExpress.XtraScheduler.CustomDrawObjectEventArgs e)
	{

		HatchBrush hatch = new HatchBrush(HatchStyle.BackwardDiagonal, Color.LightGray, Color.Transparent);
		var header = e.ObjectInfo as SchedulerHeader;
		if (SolutionSettings.SystemDates.ContainsKey(header.Interval.Start.Date))
		{
			header.Cache.FillRectangle(hatch, e.Bounds);
			// e.DrawDefault()

			header.Caption = SolutionSettings.SystemDates[header.Interval.Start.Date] + " " + header.Interval.Start.Date.ToString("dd");
			e.DrawDefault();
			Image img = BM.Properties.Resources.flag_green;
			Rectangle imgRect = header.ImageBounds;
			imgRect.Width = (header.ImageBounds.Height * img.Width) / img.Height;
			imgRect.X = header.ImageBounds.X + 3;
			e.Cache.DrawImage(img, imgRect);
			e.Handled = true;
		}
	}

	private void btnAddInfo_ItemClick(object sender, ItemClickEventArgs e)
	{
		switch (XtraMessageBox.Show("Do you want to add a new information record", "New Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
		{
			case System.Windows.Forms.DialogResult.Yes:
				var sql = "Insert into Info (Name) Values ('New Record')";
				using (MySqlConnection con = new MySqlConnection(BM.Core.MySQlHelper.ConnectionString))
				{
					using (MySqlCommand cmd = new MySqlCommand(sql, con))
					{
						con.Open();
						cmd.ExecuteNonQuery();
						InfoTableAdapter.Fill(MainDataSet.Info);
					}
					con.Close();
				}
				break;
		}
	}

	private void grdMyInbox_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
	{
		try
		{

			Utilities.ScreenWait();

			if (e.Button == System.Windows.Forms.MouseButtons.Left)
			{
				object obj = grdMyInbox.GetRowCellValue(e.RowHandle, "ID");
				if (obj == null || obj == DBNull.Value)
				{
				}
				else
				{

					switch (grdMyInbox.GetRowCellValue(e.RowHandle, "Type").ToString())
					{
						case "Lead":
						{
							frmLead_Details frm = new frmLead_Details(this);
							frm.LoadDetails(Convert.ToInt32(obj.ToString()));
							frm.Show(this);
							break;
						}
						case "Task":
						{
							if (grdMyInbox.GetRowCellValue(e.RowHandle, "Image").ToString() == "5")
							{
								if (XtraMessageBox.Show("This is a task completion notification, there is nothing to see." + Environment.NewLine + Environment.NewLine + "Do you want to remove this?", "Task Completed", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
								{
									General.MarkTaskSeen(Convert.ToInt32(obj.ToString()));
								}
							}
							else
							{
								frmTask_Details frm = new frmTask_Details(this);
								frm.loadDetails(Convert.ToInt32(obj.ToString()));
								frm.Show(this);
							}

							break;
						}
						case "Audit":
						{
							frmAudit_Details frm = new frmAudit_Details(this);
							frm.loadDetails(Convert.ToInt32(obj));
							frm.Show(this);

							break;
						}
						case "Risk":
						{
							frmRisk_Details frm = new frmRisk_Details(this);
							frm.LoadDetails(Convert.ToInt32(obj));
							frm.Show(this);

							break;
						}
						case "Policy":
						{

							frmGov_Details frm = new frmGov_Details(this, chkCaptureCopy.Checked);
							frm.LoadDetails(Convert.ToInt32(obj));
							frm.Show(this);

							break;
						}
						case "Project":
						{
							XtraMessageBox.Show("This is a project milestone and cannot be access from the inbox" + Environment.NewLine + Environment.NewLine + "It can be accessed from Planning>Projects", "Not accessible", MessageBoxButtons.OK, MessageBoxIcon.Information);

							break;
						}
					}

				}
			}
		}
		catch (Exception ex)
		{
			Utilities.MyError(ex);
		}
		finally
		{
			Utilities.CloseProgressPanel(_han);
		}
	}

	private void grdMyInbox_GroupRowCollapsing(object sender, RowAllowEventArgs e)
	{
		e.Allow = false;
	}

	private void btnShowGrouped_ItemClick(object sender, ItemClickEventArgs e)
	{

		DevExpress.XtraGrid.Views.Grid.GridView tempVar = SolutionSettings.VisibleGrid;
		Utilities.GridHelp.ShowGroupedColumns(ref tempVar);
		SolutionSettings.VisibleGrid = tempVar;
	}

	private void nvQuality_LinkClicked(object sender, NavBarLinkEventArgs e)
	{
		MoveScreen(e.Link, Screens.Audit, grdAudit);
	}

	private void BarButtonItem18_ItemClick(object sender, ItemClickEventArgs e)
	{
		switch (XtraMessageBox.Show("Do you want to add a new audit record", "New Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
		{
			case System.Windows.Forms.DialogResult.Yes:
				var sql = "Insert into Audit (Scope) Values ('New Audit')";
				using (MySqlConnection con = new MySqlConnection(BM.Core.MySQlHelper.ConnectionString))
				{
					using (MySqlCommand cmd = new MySqlCommand(sql, con))
					{
						con.Open();
						cmd.ExecuteNonQuery();
						//AuditTableAdapter.Fill(GovDataSet.Audit);
					}
					con.Close();
				}
				break;
		}
	}

	private void GridView1_RowCellClick_1(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
	{
		if (e.Column.FieldName == "ID")
		{
			frmAudit_Details frm = new frmAudit_Details(this);
			frm.loadDetails(Convert.ToInt32(grdAudit.GetRowCellValue(e.RowHandle, "ID")));
			frm.Show(this);

		}
		else if (e.Column.FieldName == "GridColumn28")
		{
			//Call RepositoryItemCheckEdit17_Click(Nothing, Nothing)
		}
	}

	private void SchedulerControl1_CustomDrawTimeCell(object sender, DevExpress.XtraScheduler.CustomDrawObjectEventArgs e)
	{

		HatchBrush hatch = new HatchBrush(HatchStyle.BackwardDiagonal, Color.LightGray, Color.Transparent);
		if (e.ObjectInfo.ToString() != "DevExpress.XtraScheduler.Drawing.MonthSingleWeekCell")
		{
			return;
		}
		var header = (MonthSingleWeekCell)e.ObjectInfo;
		if (SolutionSettings.SystemDates.ContainsKey(header.Interval.Start.Date))
		{

			e.DrawDefault();
			e.Cache.FillRectangle(hatch, e.Bounds);
			e.Handled = true;
		}
	}

	private void btnVerticalLInes_ItemClick(object sender, ItemClickEventArgs e)
	{

		DevExpress.XtraGrid.Views.Grid.GridView tempVar = SolutionSettings.VisibleGrid;
		Utilities.GridHelp.VerticalLines(ref tempVar);
		SolutionSettings.VisibleGrid = tempVar;
	}

	private void btnForReview_ItemClick(object sender, ItemClickEventArgs e)
	{
		Gov.Show.ForReview(GovGrid);
		if (XtraMessageBox.Show("Do you want to highlight items that are assigned to you?", "Show Assigned", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
		{
			GovGrid.FormatRules.Add(Utilities.GridRules.GeneralColour( colResponsible, FormatCondition.Equal, SolutionSettings.CurrentUser.UserName, SolutionSettings.Colours.NotSet));
		}
		else
		{
			GovGrid.FormatRules.Clear();
		}
	}

	private void XtraTabControl_Click(object sender, EventArgs e)
	{
	}

	private void btnCollapseAll_ItemClick(object sender, ItemClickEventArgs e)
	{
		TreeList1.CollapseAll();
	}

	private void GovStandardsGridControl_MouseDown(object sender, MouseEventArgs e)
	{
		_hitInfo = GovGrid.CalcHitInfo(new Point(e.X, e.Y));
	}

	private void MoveNode(General.MoveDirection direction)
	{

		_treeState.SaveState();
		TreeListNode focusedNode = TreeList1.FocusedNode;

		int myId = Convert.ToInt32(focusedNode.GetValue("ID"));
		Gov.MoveGovItem((General.Direction)direction, myId, Utilities.SafeInt(focusedNode.GetValue("ParentID")), Utilities.SafeString(focusedNode.GetValue("Type")));
		//GovTableAdapter.Fill(GovDataSet.Gov);
		_treeState.LoadState();

		TreeList1.FocusedNode = TreeList1.FindNodeByFieldValue("ID", _focusedTreeNode);
	}

	private void BarButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
	{

		//grdInfo.BeginDataUpdate()

		//grdInfo.ClearColumnsFilter()
		//Dim info As New ColumnFilterInfo(New BinaryOperator("StartDate", Today, BinaryOperatorType.GreaterOrEqual))
		//grdInfo.Columns.Item("StartDate").FilterInfo = info
		//'SortGrid(MyGrid)
		//grdInfo.EndDataUpdate()
	}

	private void XtraTabControl_DragOver(object sender, DragEventArgs e)
	{
		if (e.Data.GetDataPresent(DataFormats.FileDrop))
		{
			e.Effect = DragDropEffects.Copy;
		}
		else
		{
			e.Effect = DragDropEffects.None;
		}
	}

	private void GovStandardsGridControl_MouseMove(object sender, MouseEventArgs e)
	{

		if (_hitInfo != null && e.Button == System.Windows.Forms.MouseButtons.Left)
		{
			_dragfromGrid = true;
			Rectangle rectangle = new Rectangle(new Point(Convert.ToInt32((_hitInfo.HitPoint.X - (SystemInformation.DragSize.Width / 2.0))), Convert.ToInt32((_hitInfo.HitPoint.Y - (SystemInformation.DragSize.Height / 2.0)))), SystemInformation.DragSize);
			if ((_hitInfo.RowHandle != - 2147483648) && !rectangle.Contains(new Point(e.X, e.Y)))
			{
				object objectValue = GovGrid.GetRow(_hitInfo.RowHandle);
				if (objectValue != null)
				{

					GovStandardsGridControl.DoDragDrop(objectValue, DragDropEffects.Copy);
				}
				else
				{

				}
			}
		}
	}

	private void btnGridCollapse_ItemClick(object sender, ItemClickEventArgs e)
	{

		if (SolutionSettings.VisibleGrid == null)
		{
			return;
		}

		SolutionSettings.VisibleGrid.CollapseAllGroups();
	}

	private void btnGridExportHtml_ItemClick(object sender, ItemClickEventArgs e)
	{
		if (SolutionSettings.VisibleGrid == null)
		{
			return;
		}

		string s = SolutionSettings.BaseDirectory + SolutionSettings.TempDirectory + "Business Manager - DashBoard Export.html";
		//VisibleGrid.OptionsPrint.PrintSelectedRowsOnly = False
		//VisibleGrid.OptionsPrint.AutoWidth = False
		SolutionSettings.VisibleGrid.ExportToHtml(s);
		if (File.Exists(s))
		{
			switch (XtraMessageBox.Show("Do you want to open the exported file?", "Open File", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
			{
				case System.Windows.Forms.DialogResult.Yes:
					Utilities.FileHelper.LaunchFile(s);
					break;
			}
		}
	}

	private void btnGridExportPDF_ItemClick(object sender, ItemClickEventArgs e)
	{
		if (SolutionSettings.VisibleGrid == null)
		{
			return;
		}

		string s = SolutionSettings.BaseDirectory + SolutionSettings.TempDirectory + "Business Manager - DashBoard Export.pdf";
		SolutionSettings.VisibleGrid.OptionsPrint.PrintSelectedRowsOnly = btnExportSelected.Checked;
		SolutionSettings.VisibleGrid.OptionsPrint.AutoWidth = true;
		PdfExportOptions d = new PdfExportOptions();
		d.DocumentOptions.Author = "Dashboard - Business Manager";
		d.DocumentOptions.Producer = "Medicore Medical Services";
		d.ImageQuality = PdfJpegImageQuality.High;

		SolutionSettings.VisibleGrid.ExportToPdf(s, d);
		if (File.Exists(s))
		{
			switch (XtraMessageBox.Show("Do you want to open the exported file?", "Open File", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
			{
				case System.Windows.Forms.DialogResult.Yes:
					Utilities.FileHelper.LaunchFile(s);
					break;
			}
		}
	}

	private void btnGridExportCSV_ItemClick(object sender, ItemClickEventArgs e)
	{
		if (SolutionSettings.VisibleGrid == null)
		{
			return;
		}

		string s = SolutionSettings.BaseDirectory + SolutionSettings.TempDirectory + "\\Business Manager - DashBoard Export.csv";
		SolutionSettings.VisibleGrid.OptionsPrint.PrintSelectedRowsOnly = btnExportSelected.Checked;
		SolutionSettings.VisibleGrid.OptionsPrint.AutoWidth = false;
		SolutionSettings.VisibleGrid.ExportToCsv(s);
		if (File.Exists(s))
		{
			switch (XtraMessageBox.Show("Do you want to open the exported file?", "Open File", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
			{
				case System.Windows.Forms.DialogResult.Yes:
					Utilities.FileHelper.LaunchFile(s);
					break;
			}
		}
	}

	private void btnGridExportExcel_ItemClick(object sender, ItemClickEventArgs e)
	{
		if (SolutionSettings.VisibleGrid == null)
		{
			return;
		}

		string s = SolutionSettings.BaseDirectory + SolutionSettings.TempDirectory + "\\Business Manager - DashBoard Export.xlsx";
		SolutionSettings.VisibleGrid.OptionsPrint.PrintSelectedRowsOnly = btnExportSelected.Checked;
		SolutionSettings.VisibleGrid.OptionsPrint.AutoWidth = false;
		SolutionSettings.VisibleGrid.ExportToXlsx(s);
		if (File.Exists(s))
		{
			switch (XtraMessageBox.Show("Do you want to open the exported file?", "Open File", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
			{
				case System.Windows.Forms.DialogResult.Yes:
					Utilities.FileHelper.LaunchFile(s);
					break;
			}
		}
	}

	private void btnGridPrint_ItemClick(object sender, ItemClickEventArgs e)
	{
		if (SolutionSettings.VisibleGrid == null)
		{
			return;
		}

		GridControl c = SolutionSettings.VisibleGrid.GridControl;
		if (!c.IsPrintingAvailable)
		{
			XtraMessageBox.Show("You are not allowed to print this Grid", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Stop);
			return;
		}

		// Opens the Preview window.
		c.ShowRibbonPrintPreview();
	}

	private void btnExpandGrid_ItemClick(object sender, ItemClickEventArgs e)
	{
		if (SolutionSettings.VisibleGrid == null)
		{
			return;
		}

		SolutionSettings.VisibleGrid.ExpandAllGroups();
	}

	private void btnOddRow_ItemClick(object sender, ItemClickEventArgs e)
	{
		if (SolutionSettings.VisibleGrid == null)
		{
			return;
		}

		SolutionSettings.VisibleGrid.OptionsView.EnableAppearanceOddRow = !SolutionSettings.VisibleGrid.OptionsView.EnableAppearanceOddRow;
	}

	private void ToolTipController1_GetActiveObjectInfo(object sender, ToolTipControllerGetActiveObjectInfoEventArgs e)
	{

		var tree = e.SelectedControl as TreeList;
		if (tree != null)
		{

			TreeListHitInfo hit = tree.CalcHitInfo(e.ControlMousePosition);

			if (hit.HitInfoType == HitInfoType.Cell)
			{

				if (Utilities.DataHelper.IsNull(hit.Node.GetValue("ItemRef")))
				{

					object cellInfo = new TreeListCellToolTipInfo(hit.Node, hit.Column, null);

					string toolTip = string.Format("{0}", hit.Node[hit.Column]);

					e.Info = new ToolTipControlInfo(cellInfo, toolTip);
				}
				else
				{

					object cellInfo = new TreeListCellToolTipInfo(hit.Node, hit.Column, null);

					string toolTip = string.Format("{0}, {1}", hit.Node[hit.Column], Gov.GetStatement(Convert.ToInt32(hit.Node.GetValue("ItemRef"))));

					e.Info = new ToolTipControlInfo(cellInfo, toolTip);
				}
			}

		}
	}

	private void ClinicalGridView_CustomDrawEmptyForeground(object sender, DevExpress.XtraGrid.Views.Base.CustomDrawEventArgs e)
	{

		Utilities.GridHelp.EmptyForeGround(e);
	}

	private void LeadsGrid_CustomDrawEmptyForeground(object sender, DevExpress.XtraGrid.Views.Base.CustomDrawEventArgs e)
	{

		Utilities.GridHelp.EmptyForeGround(e, "There are no items to show");
	}

	private void GovGrid_CustomDrawEmptyForeground(object sender, DevExpress.XtraGrid.Views.Base.CustomDrawEventArgs e)
	{

		Utilities.GridHelp.EmptyForeGround(e, "There are no items to show");
	}

	private void GridView2_CustomDrawEmptyForeground(object sender, DevExpress.XtraGrid.Views.Base.CustomDrawEventArgs e)
	{

		Utilities.GridHelp.EmptyForeGround(e, "There are no items to show");
	}

	private void GridView3_CustomDrawEmptyForeground(object sender, DevExpress.XtraGrid.Views.Base.CustomDrawEventArgs e)
	{

		Utilities.GridHelp.EmptyForeGround(e, "There are no items to show");
	}

	private void GridView11_CustomDrawEmptyForeground(object sender, DevExpress.XtraGrid.Views.Base.CustomDrawEventArgs e)
	{

		Utilities.GridHelp.EmptyForeGround(e, "There are no items to show");
	}

	private void GridView10_CustomDrawEmptyForeground(object sender, DevExpress.XtraGrid.Views.Base.CustomDrawEventArgs e)
	{

		Utilities.GridHelp.EmptyForeGround(e, "There are no items to show");
	}

	private void grdAudit_CustomDrawEmptyForeground(object sender, DevExpress.XtraGrid.Views.Base.CustomDrawEventArgs e)
	{

		Utilities.GridHelp.EmptyForeGround(e, "There are no items to show");
	}

	private void TrainingGridView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
	{
		if (e.Column.Name == "DX$CheckboxSelectorColumn")
		{
			Utilities.ScreenWait();
			Course.SetTempCertRows(Convert.ToInt32(TrainingGridView.GetRowCellValue(e.RowHandle, "ID")));
			Utilities.ScreenWait(false);
		}
	}

	private void TrainingGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		Course.ClearTempCertRows();

		if (TrainingGridView.SelectedRowsCount == 0)
		{
			RibbonPageBatchUpdate.Enabled = false;
		}
		else
		{
			RibbonPageBatchUpdate.Enabled = true;
		}

		for (var i = 0; i < TrainingGridView.DataRowCount; i++)
		{
			if (TrainingGridView.IsRowSelected(i))
			{
				Course.SetTempCertRows(Convert.ToInt32(TrainingGridView.GetRowCellValue(i, "ID")));
			}
		}
	}

	private void TrainingGridView_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
	{
		//TrainingGridView.RowHeight += 1
		// Debug.Print(TrainingGridView.RowHeight)
		_han = (IOverlaySplashScreenHandle)Utilities.ShowProgressPanel(this);
		try
		{
			if (e.Column.Name == "DX$CheckboxSelectorColumn")
			{
				_selectedColumn = string.Empty;
				if (TrainingGridView.IsRowSelected(e.RowHandle) == true)
				{
					Course.ClearTempCertRows(Convert.ToInt32(TrainingGridView.GetRowCellValue(e.RowHandle, "ID")));
				}
				else
				{
					Course.SetTempCertRows(Convert.ToInt32(TrainingGridView.GetRowCellValue(e.RowHandle, "ID")));
				}

			}
			else if (e.Column.Name == "colID")
			{
				_selectedColumn = string.Empty;
				if (Refreshing)
				{
					//ToastNotificationsManager1.ShowNotification(3)
				}

				Form tempVar = this;
				TrainingClass.OpenCourse(Convert.ToInt32(e.CellValue), ref tempVar);

			}
			else if (e.Column.FieldName == "IntRef")
			{
				_selectedColumn = e.Column.FieldName;
			}
			else
			{
				_selectedColumn = e.Column.FieldName;
			}
		}
		catch (Exception ex)
		{
			Utilities.MyError(ex);
		}
		finally
		{
			Utilities.CloseProgressPanel(_han);
		}
	}

	private void TrainingGridView_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
	{

		if (e.HitInfo.InRowCell)
		{
			var view = sender as GridView;
			view.FocusedRowHandle = e.HitInfo.RowHandle;
			puGrid.ShowPopup(view.GridControl.PointToScreen(e.Point));

			btnCompanyReport.Enabled = e.HitInfo.Column.FieldName == "Company";

			btnCasualtySummary.Visibility = BarItemVisibility.Never;
			btnOpenFolder.Enabled = true;
			_filterColName = e.HitInfo.Column;
			_filterValue = view.GetFocusedDisplayText();
		}
	}

	private void btnCopyValue_ItemClick(object sender, ItemClickEventArgs e)
	{
		DevExpress.XtraGrid.Views.Grid.GridView tempVar = SolutionSettings.VisibleGrid;
		Utilities.Copy(ref tempVar);
		SolutionSettings.VisibleGrid = tempVar;
	}

	//Private Sub AdvBandedGridView1_PopupMenuShowing(sender As Object,
	// e As XtraGrid.Views.Grid.PopupMenuShowingEventArgs) _
	// Handles AdvBandedGridView1.PopupMenuShowing
	// If e.HitInfo.InRowCell Then
	// puCopy.ShowPopup(MousePosition)
	// End If
	//End Sub

	private void btnCourseCurrent_ItemClick(object sender, ItemClickEventArgs e)
	{
		_han = (IOverlaySplashScreenHandle)Utilities.ShowProgressPanel(this);
		try
		{

			Course.Show.ShowCurrent(TrainingGridView);
		}
		catch (Exception ex)
		{
			Utilities.MyError(ex);
		}
		finally
		{
			Utilities.CloseProgressPanel(_han);
		}
	}

	private void grdMyInbox_CustomDrawEmptyForeground(object sender, DevExpress.XtraGrid.Views.Base.CustomDrawEventArgs e)
	{

		Utilities.GridHelp.EmptyForeGround(e);
	}

	private void GridView3_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
	{
		if (e.Column.FieldName == "ID")
		{
			Utilities.ScreenWait(true, "Loading", "Loading task details...");
			frmTask_Setup frm = new frmTask_Setup(this);

			List<string> l = new List<string>();

			foreach (BarItem c in Ribbon.Manager.Items.ToList())
			{
				if (c.GetType().ToString() == "DevExpress.XtraBars.BarButtonItem")
				{

					l.Add(c.Name);

				}
			}

			frm.LoadDetails(Convert.ToInt32(GridView3.GetRowCellValue(e.RowHandle, "ID")), l);
			frm.Show(this);
			Utilities.CloseProgressPanel(_han);
		}
	}

	private void btnStaffCompliance_ItemClick(object sender, ItemClickEventArgs e)
	{

		frmPerson_Gov frm = new frmPerson_Gov();
		frm.Show(this);
	}

	private void bgEmail_DoWork(object sender, DoWorkEventArgs e)
	{
		// Try


		e.Cancel = !SolutionSettings.CurrentUser.ImportEmail;


		if (_inboxDefault == true)
		{

			Invoke(new Action(() =>
			{
				_emailBs.Clear();

				//Using bs = LoadOther()
				//    If bs IsNot Nothing AndAlso bs.Rows.Count > 0 Then
				//        _emailBs.Merge(bs)
				//    End If
				//End Using

				using (var bs = LoadEmails())
				{
					if (bs != null && bs.Rows.Count > 0)
					{
						_emailBs.Merge(bs);
					}
				}
			}));
		}

		//Else

		//_emailBs = LoadFutureTasks()

		//If _emailBs.Count = 0 Then
		// XtraMessageBox.Show(
		// "There are no future tasks to show." & Environment.NewLIne & Environment.NewLIne &
		// "This view will return to default inbox", "Nothing to Show", MessageBoxButtons.OK,
		// MessageBoxIcon.Information)
		// _inboxDefault = True
		// _emailBs = LoadEmails()
		//End If
		//End If
		//Catch ex As System.Exception
		// _refreshError = True
		// MyError(ex)
		//End Try
	}

	private void btnNoPaperworkShow_ItemClick(object sender, ItemClickEventArgs e)
	{

		_han = (IOverlaySplashScreenHandle)Utilities.ShowProgressPanel(this);
		if (SolutionSettings.VisibleScreen == Screens.Training)
		{
			Course.Show.PastNoPaperwork(TrainingGridView);
		}
		else if (SolutionSettings.VisibleScreen == Screens.Clinical)
		{
			Shifts.Show.PastNoPaperwork(ClinicalGridView);
		}
		Utilities.CloseProgressPanel(_han);
	}

	private void btnFutureTasks_ItemClick(object sender, ItemClickEventArgs e)
	{
		_inboxDefault = false;
		BtnRefresh.PerformClick();
	}

	private void btnResetInbox_ItemClick(object sender, ItemClickEventArgs e)
	{
		_inboxDefault = true;
		BtnRefresh.PerformClick();
	}

	private void btnInstructorsReminders_ItemClick(object sender, ItemClickEventArgs e)
	{

		if (XtraMessageBox.Show("Do you want to send an email to all instructors?", "Send Email", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
		{

			var sql = @"SELECT
Students.ID,
Students.Instructor,
Personnell.ID,
Personnell.Email
FROM Students
INNER JOIN Instructor_Courses
ON Students.ID = Instructor_Courses.CSE_ID
INNER JOIN Personnell
ON Instructor_Courses.Instructor_ID = Personnell.ID
WHERE Students.DateofCourse BETWEEN @s AND @f
AND Students.Instructor <> 'NOT SET'
GROUP BY Students.Instructor";

			var sql1 = @"SELECT
Instructor_Courses.Instructor_ID,
Students.Course,
Students.Location,
Students.DateofCourse,
Students.Instructor,
Students.ID
FROM BusinessManager.Students
INNER JOIN BusinessManager.Instructor_Courses
ON Students.ID = Instructor_Courses.CSE_ID
WHERE Students.DateofCourse BETWEEN @s AND @f
AND Instructor_Courses.Instructor_ID = @ID
Order by DateofCourse ASC";

			//Dim provider As CultureInfo = CultureInfo.InvariantCulture

			DateTime time = MyDates.NextMonday;
			DateTime time2 = MyDates.NextMonday.AddDays(7);

			Dictionary<int, Course.Instructor> instructorList = new Dictionary<int, Course.Instructor>();

			using (MySqlConnection con = new MySqlConnection(BM.Core.MySQlHelper.ConnectionString))
			{
				using (MySqlCommand cmd = new MySqlCommand(sql, con))
				{
					con.Open();

					cmd.Parameters.AddWithValue("@s", time);
					cmd.Parameters.AddWithValue("@f", time2);
					using (MySqlDataReader reader = cmd.ExecuteReader())
					{
						if (reader.HasRows)
						{
							while (reader.Read())
							{
								instructorList.Add(Convert.ToInt32(reader[0]), new Course.Instructor
								{
									Name = (reader[1] == null ? null : Convert.ToString(reader[1])),
									Id = Convert.ToInt32(reader[2]),
									Email = (reader[3] == null ? null : Convert.ToString(reader[3]))
								});
							}
						}
					}
					con.Close();
				}

				using (MySqlCommand cmd = new MySqlCommand(sql1, con))
				{
					foreach (var item in instructorList)
					{
						cmd.Parameters.Clear();
						cmd.Parameters.AddWithValue("@s", time);
						cmd.Parameters.AddWithValue("@f", time2);
						cmd.Parameters.AddWithValue("@ID", item.Value.Id);

						using (MySqlDataReader reader = cmd.ExecuteReader())
						{
							if (reader.HasRows)
							{
								if (Utilities.DataHelper.IsNullOrEmpty(item.Value.Name) == false && Utilities.DataHelper.IsNullOrEmpty(item.Value.Email) == false)
								{

									using (Utilities.Email myemail = new Utilities.Email())
									{
										var head1 = "<HTML><HEAD><BODY>";
										head1 = head1 + "Hi " + Utilities.SplitbySpaceFirstString(item.Value.Name) + ",<br><br>";
										head1 = head1 + "This is a reminder of your upcoming courses taking place between <b>" + time.ToLongDateString() + "</b> and <b>" + time2.AddSeconds(- 1).ToLongDateString() + "</b>.<br>";
										head1 = head1 + "Can you please review the list below for any mistakes or errors.<br><br>";
										while (reader.Read())
										{
											string s = DateTime.Parse((reader[3] == null ? null : Convert.ToString(reader[3]))).ToString("HH:mm, dddd dd MMM");
											head1 = head1 + s + " - " + reader[1].ToString() + ", " + reader[2].ToString() + "<br>";
											Course.Details.ReminderSent(Convert.ToInt32(reader[5]));
										}
										head1 = head1 + "<br>Please give the office a call if you have any problems.<br><br>Regards,<br><br>" + Utilities.SplitbySpaceFirstString(SolutionSettings.CurrentUser.UserName);
										head1 = head1 + "<br>Medicore Medical Services. Nationwide provider of medical based training courses and pre-hospital services.<br>www.medicore.ie<br>Tel: 01-6854466<br></p></BODY></HTML>";
										myemail.ShowNotification = false;
										myemail.SentTo(item.Value.Email);
										if (myemail.SetupEmail("Course Reminders", head1, "info@medicore.ie") == true)
										{
											myemail.Send();
										}

									}
								}
							}
						}
					}
				}
			}

		}
	}

	private void NavBarItem2_LinkClicked(object sender, NavBarLinkEventArgs e)
	{
		MoveScreen(e.Link, Screens.Flagged, grdFlagged);
	}

	private void grdFlagged_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
	{
		// (e.Column.FieldName & " " & e.Column.Name)
		switch (e.Column.FieldName)
		{
			case "ItemID":
			{
				var i = (grdFlagged.GetRowCellValue(grdFlagged.FocusedRowHandle, "Source") == null ? null : Convert.ToString(grdFlagged.GetRowCellValue(grdFlagged.FocusedRowHandle, "Source")));

				switch (i)
				{
					case "Course":
					{
						_han = (IOverlaySplashScreenHandle)Utilities.ShowProgressPanel(this);
						frmCourse_Details frm = new frmCourse_Details(this);
						if (frm.LoadDetails(Convert.ToInt32(e.CellValue), true) == true)
						{

							frm.Show(this);
						}
						else
						{

						}

						Utilities.CloseProgressPanel(_han);
						break;
					}
					case "Shift":
					{
						_han = (IOverlaySplashScreenHandle)Utilities.ShowProgressPanel(this);
						frmShift_Details frm = new frmShift_Details(this);
						frm.LoadDetails(Convert.ToInt32(e.CellValue));
						frm.Show(this);
						Utilities.CloseProgressPanel(_han);
						break;
					}
					case "PCR":
					{

					break;
					}
				}
				break;
			}
			case "View":
			{
				var i = (grdFlagged.GetRowCellValue(grdFlagged.FocusedRowHandle, "Source") == null ? null : Convert.ToString(grdFlagged.GetRowCellValue(grdFlagged.FocusedRowHandle, "Source")));

				switch (i)
				{

					case "Vehicle Checklist":
					{
						_han = (IOverlaySplashScreenHandle)Utilities.ShowProgressPanel(this);
						var id = grdFlagged.GetRowCellValue(grdFlagged.FocusedRowHandle, "ItemID");
						var s = Asset.AssetShiftCheck(Convert.ToInt32(id));

						if (string.IsNullOrEmpty(s))
						{
							XtraMessageBox.Show("There is Not file To open");
						}
						else
						{
							Utilities.FileHelper.LaunchFile(s);
						}

						Utilities.CloseProgressPanel(_han);
						break;
					}
					case "Course":
					{
						_han = (IOverlaySplashScreenHandle)Utilities.ShowProgressPanel(this);
						frmCourse_Details frm = new frmCourse_Details(this);
						if (frm.LoadDetails(Convert.ToInt32(e.CellValue), true) == true)
						{

							frm.Show(this);
						}
						else
						{

						}

						Utilities.CloseProgressPanel(_han);
						break;
					}
					case "Shift":
					{
						_han = (IOverlaySplashScreenHandle)Utilities.ShowProgressPanel(this);
						frmShift_Details frm = new frmShift_Details(this);
						frm.LoadDetails(Convert.ToInt32(e.CellValue));
						frm.Show(this);
						Utilities.CloseProgressPanel(_han);
						break;
					}
					case "PCR":
					{

					break;
					}
				}
				break;
			}
			case "ID":
			{
				_han = (IOverlaySplashScreenHandle)Utilities.ShowProgressPanel(this);
				frmFlagged_Details frm = new frmFlagged_Details();
				frm.LoadDetails(Convert.ToInt32(e.CellValue));
				frm.Show(this);
				Utilities.CloseProgressPanel(_han);
				break;
			}
		}
	}

	private void bgemail_runworkercompleted(object sender, RunWorkerCompletedEventArgs e)
	{
		try
		{
			//_gridHelper.SaveViewInfo(grdMyInbox)
			//grdMyInbox.BeginDataUpdate()
			_emailMain.Clear();
			_emailMain.Merge(_emailBs);

			EmailGridControl.DataSource = _emailMain;

			Utilities.Email.ProcessTrainingEmails(_emailMain);
			grdMyInbox.ExpandAllGroups();

			_emailBs.Clear();
			//_gridHelper.LoadViewInfo(grdMyInbox)


			//SetupTree()
			Cursor = Cursors.Default;
		}
		catch (Exception ex)
		{
			Utilities.MyError(ex);
		}
		finally
		{
			//grdMyInbox.EndDataUpdate()
		}


		//Utilities.Email.ProcessTrainingEmails()
	}

	private void SchedulerControl1_PopupMenuShowing(object sender, DevExpress.XtraScheduler.PopupMenuShowingEventArgs e)
	{

		if (schWebView.SelectedAppointments.Count == 1)
		{
			object o = schWebView.SelectedAppointments[0];
			if (o == null)
			{
				return;
			}
			var appointment = o as Appointment;
			_selectedWebCourseId = Convert.ToInt32(appointment.CustomFields["ID"].ToString());

			e.Menu.Items.Clear();

			SchedulerMenuItem s = new SchedulerMenuItem
			{
				Caption = "Open Course",
				Image = ImageResourceCache.Default.GetImage("images/actions/open2_16x16.png")
			};
			var stip = new SuperToolTip();
			s.SuperTip = stip;
			s.Click += Cseopen;

			if (Course.Details.WebExists(_selectedWebCourseId) == false)
			{
				s.Enabled = true;
				stip.Items.AddTitle("Opens the course on the general training list");
				s.Tag = false;
			}
			else
			{
				s.Tag = true;
				s.Enabled = false;
				stip.Items.AddTitle("This course is already opened.");
			}
			e.Menu.Items.Add(s);
			e.Menu.Items.Add(new SchedulerMenuItem("Publish Course", CsePublish, ImageResourceCache.Default.GetImage("images/actions/show_16x16.png")));
			e.Menu.Items.Add(new SchedulerMenuItem("Hide Course", CseHide, ImageResourceCache.Default.GetImage("images/actions/hide_16x16.png")));
		}
		else
		{
			e.Menu.Items.Clear();
		}
	}

	private void Cseopen(object sender, EventArgs e)
	{


		var sql = @"SELECT
                med_eb_events.title,
                med_eb_event_categories.category_id AS CatID,
                med_eb_events.id AS EventID,
                med_eb_events.location_id,
                med_eb_locations.name,
                med_eb_events.event_date
                FROM med_eb_events
                INNER JOIN med_eb_event_categories
                ON med_eb_events.id = med_eb_event_categories.event_id
                INNER JOIN med_eb_locations
                ON med_eb_events.location_id = med_eb_locations.id
                WHERE (med_eb_events.event_date > DATE_ADD(NOW(), INTERVAL -1 DAY)
                OR med_eb_events.event_date > NOW()
                OR med_eb_events.event_date > NOW()
                OR med_eb_events.event_date > NOW())
                AND med_eb_events.id = @ID";

		using (MySqlConnection con = new MySqlConnection(BM.Properties.Settings.Default.WebConString))
		{
			using (MySqlCommand cmd = new MySqlCommand(sql, con))
			{
				con.Open();
				cmd.Parameters.AddWithValue("@ID", _selectedWebCourseId);
				var reader = cmd.ExecuteReader();
				if (reader.HasRows)
				{
					while (reader.Read())
					{
						Course.Web.OpenCourse(Convert.ToInt32(reader[2]), (reader[4] == null ? null : Convert.ToString(reader[4])), Convert.ToDateTime(reader[5]), Convert.ToInt32(reader[1]));
					}
				}
			}
			con.Close();
		}
	}

	public void CsePublish(object sender, EventArgs e)
	{

		General.Web.PublishCourse(_selectedWebCourseId);
		WebUpcomingTableAdapter.Fill(WebDataSet.WebUpcoming, schWebView.ActiveView.Control.SelectedInterval.Start, schWebView.ActiveView.Control.SelectedInterval.End);
	}

	public void CseHide(object sender, EventArgs e)
	{
		General.Web.HideCourse(_selectedWebCourseId);
		WebUpcomingTableAdapter.Fill(WebDataSet.WebUpcoming, schWebView.ActiveView.Control.SelectedInterval.Start, schWebView.ActiveView.Control.SelectedInterval.End);
	}

	private void btnPersonClinicalReport_ItemClick(object sender, ItemClickEventArgs e)
	{

		DateTime start = default(DateTime);
		DateTime finish = default(DateTime);

		start = MyDates.LastMonth.AddMonths(- 2);
		finish = MyDates.LastMonth.AddDays(- 1);

		var sql = @"select `Personnell`.`ID`, `Personnell`.`InstructorName`,
`Personnell`.`Company`, `Personnell`.`Email`,
`Personnell`.`Medical Qualification`,
`Personnell`.`PractitionerStatus`,
`Personnell`.`Business Phone`, `Personnell`.`PrivillageStatus`,
count(`ClinicalRecords`.`ID`) as `ClinicalRecords_ID`,
`Personnell`.`Clinical_Grade`
from ((`Personnell` `Personnell`
inner join `Shifts` `Shifts`
on (`Shifts`.`MedicID` = `Personnell`.`ID`))
inner join `ClinicalRecords` `ClinicalRecords`
on (`ClinicalRecords`.`ShiftID` = `Shifts`.`ID`))
where ((`Personnell`.`Med_Fac` = 1)
and (`Personnell`.`Inactive_Med` = 0) and ((@Start <= `Shifts`.`DutyDate`) and (`Shifts`.`DutyDate` <=@Finish)) )
group by `Personnell`.`ID`, `Personnell`.`InstructorName`,
`Personnell`.`Company`, `Personnell`.`Email`,
`Personnell`.`Medical Qualification`,
`Personnell`.`PractitionerStatus`,
`Personnell`.`Business Phone`, `Personnell`.`PrivillageStatus`,
`Personnell`.`Clinical_Grade`
";
		using (MySqlConnection con = new MySqlConnection(BM.Core.MySQlHelper.ConnectionString))
		{
			using (MySqlCommand cmd = new MySqlCommand(sql, con))
			{
				cmd.Parameters.AddWithValue("@Start", start);
				cmd.Parameters.AddWithValue("@Finish", finish);
				con.Open();
				using (MySqlDataReader reader = cmd.ExecuteReader())
				{
					if (reader.HasRows)
					{
						while (reader.Read())
						{
							InsufficientInfoReport report = new InsufficientInfoReport();
							PdfExportOptions opts = report.ExportOptions.Pdf;
	
							report.MedicID.Value = reader["ID"];
							report.Start.Value = start;
							report.Finish.Value = finish;
							string s = SolutionSettings.BaseDirectory + SolutionSettings.TempDirectory + reader["InstructorName"].ToString() + " ClinicalDataSet Feedback " + DateTime.Today.ToString("MMM-yy") + ".pdf";
	
							opts.ImageQuality = PdfJpegImageQuality.High;
							opts.PdfACompatibility = PdfACompatibility.PdfA3b;
	
							report.ExportToPdf(s.ToString(), opts);
	
							using (Utilities.Email myemail = new Utilities.Email())
							{
								myemail.AddAttachement(s);
								string str = "<HTML><HEAD><BODY>Hi " + Utilities.SplitbySpaceFirstString((reader["InstructorName"] == null ? null : Convert.ToString(reader["InstructorName"]))) + ", <br><br>This is a new email To all practitioners regarding Patient Care Reports.<br><br>We have decided to start giving feedback reports to all practitioners who have handed In PCR's. This is designed to gauge the completness of the reports and the apparentl clinical care provided.<br><br>It is not meant as criticism towards any one person in particular, rather just a way to ensure that we reach a consistent standard when it comes to documenting clinical care.<br><br>This report should be used as a guide to help improve documentation standards.";
								var str2 = "<br>Give the office a call if you have any questions or queries.<br>";
								str2 = (((((str2 + "<br>" + "Regards,<br><br>") + Utilities.SplitbySpaceFirstString(SolutionSettings.CurrentUser.UserName) + "<br>") + "_________________________<br>" + "Medicore Medical Services. Nationwide provider of medical based training courses and pre-hospital services.<br>") + "www.medicore.ie<br>" + "Tel 01-6854466<br></p>") + "</BODY>" + "</HTML>");
								myemail.SentTo((reader["email"] == null ? null : Convert.ToString(reader["email"])));
								myemail.ShowNotification = false;
								if (myemail.SetupEmail("Clinical Feedback", str + str2, "info@medicore.ie") == true)
								{
									myemail.Send();
								}
	
							}
							Personnel.Documents.AddPersonFileDocument(Convert.ToInt32(reader["ID"]), s, "Clinical\\Feedback", DateTime.Today);
						}
					}
				}
				con.Close();
			}
		}
	}

	private void SchedulerControl1_Click(object sender, EventArgs e)
	{
		try
		{
			if (schWebView.SelectedAppointments.Count == 1)
			{
				object o = schWebView.SelectedAppointments[0];
				if (o == null)
				{
					return;
				}
				var appointment = o as Appointment;
				_selectedWebCourseId = Convert.ToInt32(appointment.CustomFields["ID"].ToString());

			}
		}
		catch (Exception ex)
		{
			Utilities.MyError(ex);
		}
	}

	private void RepositoryItemCheckEdit18_Click(object sender, EventArgs e)
	{

		object o = GridView10.GetRowCellValue(GridView10.FocusedRowHandle, "Path");

		if (Utilities.DataHelper.IsNull(o) == false)
		{
			Utilities.FileHelper.LaunchFile(o.ToString());
		}
	}

//    Private Sub BarEditItem6_EditValueChanged(sender As Object, e As EventArgs) Handles BarEditItem6.EditValueChanged
//
//        Dim fontsize As Single = DefaultFont.Size
//        If Convert.ToInt32(BarEditItem6.EditValue.ToString) = 0 Then
//            fontsize = DefaultFont.Size
//        Else
//            fontsize += Convert.ToInt32(BarEditItem6.EditValue.ToString)
//        End If
//
//        'Dim fnt = New Font(grdMyInbox.Appearance.Row.Font.Name, fontsize)
//        'grdMyInbox.Appearance.HeaderPanel.Font = fnt
//        'grdMyInbox.Appearance.Row.Font = fnt
//        'SolutionSettings.FontSize = CDec(fnt.Size)
//    End Sub

//    Private Sub BarButtonItem6_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem6.ItemClick
//        General.TaskCompleted(Convert.ToInt32(grdMyInbox.GetRowCellValue(grdMyInbox.FocusedRowHandle, "ID")))
//        grdMyInbox.DeleteSelectedRows()
//    End Sub

//    Private Sub BarButtonItem5_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem5.ItemClick
//        Dim frm As New frmShiftCalculator
//        frm.Show(Me)
//    End Sub

	private void ttTraining_GetActiveObjectInfo(object sender, ToolTipControllerGetActiveObjectInfoEventArgs e)
	{
		if (e.Info == null && e.SelectedControl == TrainingGrid)
		{

			var view = TrainingGrid.FocusedView as GridView;
			GridHitInfo info = view.CalcHitInfo(e.ControlMousePosition);
			if (info.InRowCell)
			{

				DataRow dr = view.GetDataRow(info.RowHandle);
				string s = string.Empty;

				if (!Utilities.DataHelper.IsNull(dr["DateofCourse"]))
				{

					if (Utilities.DataHelper.IsNull(dr["Path"]) && (Convert.ToDateTime(dr["DateofCourse"]) < DateTime.Today) == true)
					{

						s = "No Paperwork";

					}
				}

				if (!Utilities.DataHelper.IsNull(dr["Course"]))
				{
					if (s.Length == 0)
					{
						s = (dr["Course"] == null ? null : Convert.ToString(dr["Course"]));
					}
					else
					{
						s = s + ": " + dr["Course"].ToString();
					}

					string cellKey = info.RowHandle.ToString() + " - " + info.Column.ToString();
					e.Info = new ToolTipControlInfo(cellKey, s);
				}
			}

		}
	}

	private void TrainingGridView_CustomDrawEmptyForeground_1(object sender, DevExpress.XtraGrid.Views.Base.CustomDrawEventArgs e)
	{
		Utilities.GridHelp.EmptyForeGround(e);
	}

	private void btnTrainingReturns_ItemClick(object sender, ItemClickEventArgs e)
	{
		_han = (IOverlaySplashScreenHandle)Utilities.ShowProgressPanel(this);
		frmTrainingReturns frm = new frmTrainingReturns();
		frm.Show(this);
		Utilities.CloseProgressPanel(_han);
	}

	private void btnRestart_ItemClick(object sender, ItemClickEventArgs e)
	{
		try
		{
			Directory.CreateDirectory((int)Environment.SpecialFolder.MyDocuments + "\\Business Manager");
			using (XmlWriter writer = XmlWriter.Create(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Business Manager\\settings.xml"))
			{
				writer.WriteStartDocument();
				writer.WriteStartElement("Settings");
				writer.WriteElementString("User", Utilities.Crypto.AES_Encrypt(SolutionSettings.CurrentUser.UserName, "password"));
				writer.WriteElementString("UserID", Utilities.Crypto.AES_Encrypt(SolutionSettings.CurrentUser.ID.ToString(), "password"));
				writer.WriteElementString("Point", Location.ToString());
				writer.WriteElementString("WinForm", Convert.ToInt32(WindowState).ToString());
				writer.WriteElementString("Size", Size.ToString());
				writer.WriteEndElement();
				writer.WriteEndDocument();
			}

			_clearfolder = false;
			//'''

			//If File.Exists("Support Files\AppHelper.exe") Then
			Application.Exit();
			//Else
			// XtraMessageBox.Show("Cannot find helper file")
			//End If

			//Windows.Forms.Application.Exit()
		}
		catch (Exception ex)
		{

			Utilities.MyError(ex);
		}
	}

	private async void btnInvoice_ItemClick(object sender, ItemClickEventArgs e)
	{
		_invoiceCancel = true;
		int i = 0;
		string invType = null;
		string invBill = null;
		//SolutionSettings.CurrentUser.XeroOrganisation = nothing


		try
		{

			if (Utilities.myXero.XeroCloud.ReconnectRequired())
			{


				Utilities.myXero.XeroCloud.ShowReconnect();


			}

			var exp = await Utilities.myXero.XeroCloud.TokenExpiredAsync();
			if (exp)
			{
				return;

			}


			switch (SolutionSettings.VisibleScreen)
			{
				case Screens.Training:
				{

#region IBox

					if (TrainingGridView.SelectedRowsCount == 1)
					{
						invType = "1 Invoice - 1 Course";
					}
					else
					{
						XtraInputBoxArgs args = new XtraInputBoxArgs
						{
							Caption = "Invoice Type",
							Prompt = "Select Type",
							DefaultButtonIndex = 0
						};
						ComboBoxEdit editor = new ComboBoxEdit();
						editor.Properties.Items.Add("1 Invoice - 1 Course");
						editor.Properties.Items.Add("1 Invoice - Multiple Courses");
						args.Editor = editor;
						args.DefaultResponse = "1 Invoice - 1 Course";
						invType = (XtraInputBox.Show(args) == null ? null : Convert.ToString(XtraInputBox.Show(args)));
					}
					if (Utilities.DataHelper.IsNullOrEmpty(invType))
					{
						return;
					}

					XtraInputBoxArgs args1 = new XtraInputBoxArgs
					{
						Caption = "Invoice Type",
						Prompt = "Select Type",
						DefaultButtonIndex = 0
					};
					ComboBoxEdit editor1 = new ComboBoxEdit();
					editor1.Properties.Items.Add("Bill Per Course");
					editor1.Properties.Items.Add("Bill Per Student");
					args1.Editor = editor1;
					args1.DefaultResponse = "Bill Per Course";
					invBill = (XtraInputBox.Show(args1) == null ? null : Convert.ToString(XtraInputBox.Show(args1)));

#endregion

					if (Utilities.DataHelper.IsNullOrEmpty(invBill))
					{
						return;
					}
					int num2 = 0;
					if (invType == "1 Invoice - 1 Course")
					{

#region 1 Invoice - 1 Course

						Utilities.myXero.Invoice invoice = new Utilities.myXero.Invoice {InvoiceType = Utilities.myXero.DocumentType.Invoice};
						TrainingGridView.OptionsView.ShowGroupedColumns = true;
						List<Utilities.myXero.Invoice.InvoiceItems> items = new List<Utilities.myXero.Invoice.InvoiceItems>();
						for (var y = 0; y < TrainingGridView.DataRowCount; y++)
						{
							if (TrainingGridView.IsRowSelected(y))
							{

								if (Utilities.DataHelper.IsNull(TrainingGridView.GetRowCellValue(y, colCompany)) == false)
								{
									invoice.Contact = Convert.ToString(TrainingGridView.GetRowCellValue(y, colCompany));
								}
								else
								{
									invoice.Contact = Convert.ToString(TrainingGridView.GetRowCellValue(y, colInstructor));
								}

								if (Utilities.DataHelper.IsNull(TrainingGridView.GetRowCellValue(y, colCourse)) == false)
								{
									if (items.Any((x) => x.ItemName == TrainingGridView.GetRowCellValue(y, colCourse).ToString()) == false)
									{
										items.Add(new Utilities.myXero.Invoice.InvoiceItems
										{
											ItemName = TrainingGridView.GetRowCellValue(y, colCourse).ToString(),
											ItemCost = (decimal)0.00
										});
									}
								}
							}

						}

						Utilities.ScreenWait();
						frmCourseInvoice frm = new frmCourseInvoice(this);
						frm.LoadDetails(invoice, items);
						Utilities.CloseProgressPanel(_han);
						frm.ShowDialog();
						if (_invoiceCancel == true)
						{
							XtraMessageBox.Show("Creating the invoice was cancelled", "Operation Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
							return;
						}
						Utilities.ScreenWait(true, "Setting up invoice");
						_selectedColumn = colIntRef.FieldName;
						invoice.Items = items;
						for (i = 0; i < TrainingGridView.DataRowCount; i++)
						{
							if (TrainingGridView.IsRowSelected(i))
							{
								Utilities.myXero.Invoice i2 = new Utilities.myXero.Invoice();
								invoice.InvoiceLineItems.Clear();
								i2.Contact = invoice.Contact;
								i2.InvoiceDate = invoice.InvoiceDate;
								i2.DueDate = invoice.DueDate;
								i2.MainAccountingCode = invoice.MainAccountingCode;
								i2.Email = invoice.Email;
								i2.DocStatus = invoice.DocStatus;
								i2.InvoiceType = invoice.InvoiceType;

								if (string.IsNullOrEmpty(invoice.Reference) == false && !Utilities.DataHelper.IsNull(TrainingGridView.GetRowCellValue(i, colExternalRef)))
								{
									i2.Reference = (TrainingGridView.GetRowCellValue(i, colExternalRef) == null ? null : Convert.ToString(TrainingGridView.GetRowCellValue(i, colExternalRef)));
								}

								DateTime dt = DateTime.Parse((TrainingGridView.GetRowCellValue(i, colDateofCourse) == null ? null : Convert.ToString(TrainingGridView.GetRowCellValue(i, colDateofCourse))));
								var finalcost = (decimal)(invoice.Items.Any((x) => x.ItemName == (TrainingGridView.GetRowCellValue(i, colCourse) == null ? null : Convert.ToString(TrainingGridView.GetRowCellValue(i, colCourse)))) ? invoice.Items.FirstOrDefault((x) => x.ItemName == (TrainingGridView.GetRowCellValue(i, colCourse) == null ? null : Convert.ToString(TrainingGridView.GetRowCellValue(i, colCourse)))).ItemCost : _invoice.MainPrice);

								switch (invBill)
								{
									case "Bill Per Course":
										i2.InvoiceLineItems.Add(new Utilities.myXero.Invoice.InvoiceLine()
										{
											AccountCode = i2.MainAccountingCode,
											Description = TrainingGridView.GetRowCellValue(i, colCourse).ToString() + " (" + TrainingGridView.GetRowCellValue(i, "ID").ToString() + ") - " + dt.ToString("ddd dd MMM yy"),
											Quantity = 1,
											UnitAmount = finalcost
										});
										break;
									default:
										i2.InvoiceLineItems.Add(new Utilities.myXero.Invoice.InvoiceLine()
										{
											AccountCode = i2.MainAccountingCode,
											Description = TrainingGridView.GetRowCellValue(i, colCourse).ToString() + " (" + TrainingGridView.GetRowCellValue(i, "ID").ToString() + ") - " + dt.ToString("ddd dd MMM yy"),
											Quantity = Convert.ToDecimal(TrainingGridView.GetRowCellValue(i, colStudents)),
											UnitAmount = finalcost
										});
										break;
								}

								var invoiceId = i2.CreateInvoiceReturnInvNumber();
								num2 += 1;
								i2.InvoiceLineItems.Clear();
								Course.Details.UpdateCourseDetails(new List<int>() {Convert.ToInt32(TrainingGridView.GetRowCellValue(i, "ID"))}, _selectedColumn, invoiceId);
								Security.LogEvent(("Batch updated: " + _selectedColumn + " to " + invoiceId), Security.AuditType.Course, TrainingGridView.GetRowCellValue(i, "ID"));
							}
						}

						Utilities.ShowAlert(this, "Completed", (Utilities.SafeString(num2) + " course invoices have been successfully added."));
						_selectedColumn = string.Empty;

						var b = RefreshHold;
						RefreshHold = false;
						RefreshMain(true, "Main Refresh - New Invoice");
						RefreshHold = b;

#endregion

					}
					else
					{

#region MultiLine Invoice

						Utilities.myXero.Invoice invoice = new Utilities.myXero.Invoice {InvoiceType = Utilities.myXero.DocumentType.Invoice};

						List<int> selectedId = new List<int>();
						TrainingGridView.OptionsView.ShowGroupedColumns = true;
						object co = TrainingGridView.GetFocusedRowCellValue(colCompany);
						if (!Utilities.DataHelper.IsNull(co))
						{
							invoice.Contact = (TrainingGridView.GetFocusedRowCellValue(colCompany) == null ? null : Convert.ToString(TrainingGridView.GetFocusedRowCellValue(colCompany)));
						}
						List<Utilities.myXero.Invoice.InvoiceItems> items = new List<Utilities.myXero.Invoice.InvoiceItems>();
						for (var iz = 0; iz < TrainingGridView.DataRowCount; iz++)
						{
							if (TrainingGridView.IsRowSelected(iz))
							{
								if (TrainingGridView.IsRowSelected(iz))
								{
									if (!Utilities.DataHelper.IsNull(TrainingGridView.GetRowCellValue(iz, colCompany)))
									{
										invoice.Contact = Convert.ToString(TrainingGridView.GetRowCellValue(iz, colCompany));
									}
									else
									{
										invoice.Contact = Convert.ToString(TrainingGridView.GetRowCellValue(iz, colInstructor));
									}

									if (!Utilities.DataHelper.IsNull(TrainingGridView.GetRowCellValue(iz, colExternalRef)))
									{
										invoice.Reference = Convert.ToString(TrainingGridView.GetRowCellValue(iz, colExternalRef));
									}

									if (Utilities.DataHelper.IsNull(TrainingGridView.GetRowCellValue(iz, colCourse)) == false)
									{

										if (items.Any((x) => x.ItemName == TrainingGridView.GetRowCellValue(iz, colCourse).ToString()) == false)
										{
											items.Add(new Utilities.myXero.Invoice.InvoiceItems
											{
												ItemName = TrainingGridView.GetRowCellValue(iz, colCourse).ToString(),
												ItemCost = (decimal)0.00
											});
										}

									}

								}

							}
						}

						frmCourseInvoice frm = new frmCourseInvoice(this);
						frm.LoadDetails(invoice, items);
						frm.ShowDialog();

						if (_invoiceCancel == true)
						{
							XtraMessageBox.Show("Creating the invoice was cancelled", "Operation Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
							return;
						}
						Utilities.ScreenWait(true, "Setting up invoice");
						_selectedColumn = colIntRef.FieldName;
						//invoice.InvoiceLineItems = New List(Of .XeroInvoice.InvoiceLine)

						for (i = 0; i < TrainingGridView.DataRowCount; i++)
						{
							if (TrainingGridView.IsRowSelected(i))
							{
								if (Utilities.DataHelper.IsNull(invoice.Contact))
								{
									if (Utilities.DataHelper.IsNull(TrainingGridView.GetRowCellValue(i, colCompany)) == false)
									{
										invoice.Contact = (TrainingGridView.GetRowCellValue(i, colCompany) == null ? null : Convert.ToString(TrainingGridView.GetRowCellValue(i, colCompany)));
									}
									else
									{
										invoice.Contact = (TrainingGridView.GetRowCellValue(i, colInstructor) == null ? null : Convert.ToString(TrainingGridView.GetRowCellValue(i, colInstructor)));
									}
								}
								else
								{

								}
								DateTime dt = DateTime.Parse((TrainingGridView.GetRowCellValue(i, colDateofCourse) == null ? null : Convert.ToString(TrainingGridView.GetRowCellValue(i, colDateofCourse))));
								if (Utilities.DataHelper.IsNullOrEmpty(invoice.Reference))
								{
									if (!Utilities.DataHelper.IsNull(TrainingGridView.GetRowCellValue(i, colExternalRef)))
									{
										invoice.Reference = (TrainingGridView.GetRowCellValue(i, colExternalRef) == null ? null : Convert.ToString(TrainingGridView.GetRowCellValue(i, colExternalRef)));
									}
								}

								var finalcost = (decimal)(invoice.Items.Any((x) => x.ItemName == TrainingGridView.GetRowCellValue(i, colCourse).ToString()) ? invoice.Items.FirstOrDefault((x) => x.ItemName == TrainingGridView.GetRowCellValue(i, colCourse).ToString()).ItemCost : _invoice.MainPrice);

								if (invBill == "Bill Per Course")
								{
									invoice.InvoiceLineItems.Add(new Utilities.myXero.Invoice.InvoiceLine()
									{
										AccountCode = invoice.MainAccountingCode,
										Description = TrainingGridView.GetRowCellValue(i, colCourse).ToString() + " (" + TrainingGridView.GetRowCellValue(i, "ID").ToString() + ") - " + dt.ToString("ddd dd MMM yy") + (string)((Utilities.SafeString(TrainingGridView.GetRowCellValue(i, "ExternalRef").ToString()).Length > 0) ? " PO: (" + TrainingGridView.GetRowCellValue(i, "ExternalRef").ToString() + ")" : ""),
										Quantity = 1,
										UnitAmount = finalcost
									});
								}
								else
								{
									invoice.InvoiceLineItems.Add(new Utilities.myXero.Invoice.InvoiceLine()
									{
										AccountCode = invoice.MainAccountingCode,
										Description = TrainingGridView.GetRowCellValue(i, colCourse).ToString() + " (" + TrainingGridView.GetRowCellValue(i, "ID").ToString() + ") - " + dt.ToString("ddd dd MMM yy") + (string)((Utilities.SafeString(TrainingGridView.GetRowCellValue(i, "ExternalRef")).Length > 0) ? " PO: (" + TrainingGridView.GetRowCellValue(i, "ExternalRef").ToString() + ")" : ""),
										Quantity = Convert.ToDecimal(TrainingGridView.GetRowCellValue(i, colStudents)),
										UnitAmount = finalcost
									});
								}

							}

						}

						if (XtraMessageBox.Show("Invoice total is currently: " + string.Format("{0:C}", invoice.InvoiceTotal).ToString() + Environment.NewLine + Environment.NewLine + "Is this correct?", "Confirm Invoice Total", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
						{

							//Dim s As String = 
							//  Debug.Print(s)
							//Dim root = JObject.Parse(s)
							string invoiceId = invoice.CreateInvoiceReturnInvNumber();
							//CStr(root.Item("InvoiceNumber"))
							for (var z = 0; z < TrainingGridView.DataRowCount; z++)
							{
								if (TrainingGridView.IsRowSelected(z))
								{
									selectedId.Add(Convert.ToInt32(TrainingGridView.GetRowCellValue(z, "ID")));

								}
							}

							Course.Details.UpdateCourseDetails(selectedId, _selectedColumn, invoiceId);
							Security.LogEvent(("Batch updated: " + _selectedColumn + " to " + invoiceId), Security.AuditType.Course, selectedId);

							Utilities.ShowAlert(this, "Completed", (Utilities.SafeString(num2) + " course invoices have been successfully added."));
							_selectedColumn = string.Empty;

							var b = RefreshHold;
							RefreshHold = false;
							RefreshMain(true, "Main Refresh - Add Invoice");
							RefreshHold = b;
						}
						else
						{
							XtraMessageBox.Show("Invoice has been cancelled!", "Not completed", MessageBoxButtons.OK, MessageBoxIcon.Information);

						}

#endregion

					}

					break;
				}
				case Screens.Clinical:
				{
					frmShift_Invoices frm = new frmShift_Invoices(this);
					_invoice = new Utilities.myXero.Invoice
					{
						InvoiceType = Utilities.myXero.DocumentType.Invoice,
						DueDate = DateTime.Today.AddDays(14),
						InvoiceDate = DateTime.Today,
						LineAmountType = Utilities.myXero.AmountTypes.Inclusive,
						BillingType = Utilities.myXero.BillingTypes.PerLine
					};

					for (var y = 0; y < ClinicalGridView.DataRowCount; y++)
					{
						if (ClinicalGridView.IsRowSelected(y))
						{
							if (Utilities.DataHelper.IsNull(ClinicalGridView.GetRowCellValue(y, colClient)) == false)
							{
								_invoice.Contact = Utilities.SafeString(ClinicalGridView.GetRowCellValue(y, colClient));
							}
							else
							{
								_invoice.Contact = Utilities.SafeString(ClinicalGridView.GetRowCellValue(y, colLocation));
							}

							if (Utilities.DataHelper.IsNull(ClinicalGridView.GetRowCellValue(y, colPO)) == false)
							{
								_invoice.Reference = Utilities.SafeString(ClinicalGridView.GetRowCellValue(y, colPO));
							}
							else
							{
								_invoice.Reference = ("Week " + ClinicalGridView.GetRowCellValue(y, "Week").ToString());
							}

						}
					}
					_invoice.LineDesc = "Medical Cover - {date}";
					frm.LoadDetails(_invoice);
					frm.ShowDialog();
					if (_invoiceCancel)
					{
						XtraMessageBox.Show("Creating the invoice was cancelled", "Operation Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}
					Utilities.ScreenWait(true, "Setting up invoice");

					if (_invoice.BillingType == Utilities.myXero.BillingTypes.PerLine)
					{

//INSTANT C# NOTE: There is no C# equivalent to VB's implicit 'once only' variable initialization within loops, so the following variable declaration has been placed prior to the loop:
						decimal qty = 0M;
						for (i = 0; i < ClinicalGridView.DataRowCount; i++)
						{
							if (ClinicalGridView.IsRowSelected(i))
							{
								DateTime dt = DateTime.Parse((ClinicalGridView.GetRowCellValue(i, colDutyDate) == null ? null : Convert.ToString(ClinicalGridView.GetRowCellValue(i, colDutyDate))));
//								Dim qty As Decimal
								if (Utilities.DataHelper.IsNullOrEmpty(ClinicalGridView.GetRowCellValue(i, colHours)))
								{
									qty = 1M;
								}
								else
								{
									qty = Convert.ToDecimal(ClinicalGridView.GetRowCellValue(i, colHours));
								}
								_invoice.InvoiceLineItems.Add(new Utilities.myXero.Invoice.InvoiceLine()
								{
									AccountCode = _invoice.MainAccountingCode,
									ItemCode = "EMC",
									Description = _invoice.LineDesc.Replace("{date}", dt.ToString("ddd dd MMM yy")),
									Quantity = qty,
									UnitAmount = _invoice.MainPrice
								});
							}
						}

					}
					else if (_invoice.BillingType == Utilities.myXero.BillingTypes.FixedPrice)
					{

						List<DateTime> sameDate = new List<DateTime>();

						for (i = 0; i < ClinicalGridView.DataRowCount; i++)
						{
							if (ClinicalGridView.IsRowSelected(i))
							{
								sameDate.Add(DateTime.Parse((ClinicalGridView.GetRowCellValue(i, colDutyDate) == null ? null : Convert.ToString(ClinicalGridView.GetRowCellValue(i, colDutyDate)))));
							}

						}

						if (sameDate.Any((x) => x.Date != sameDate.First()))
						{

							var invoicetext = new StringBuilder();


							for (i = 0; i < ClinicalGridView.DataRowCount; i++)
							{
								if (ClinicalGridView.IsRowSelected(i))
								{


									DateTime dt = DateTime.Parse((ClinicalGridView.GetRowCellValue(i, colDutyDate) == null ? null : Convert.ToString(ClinicalGridView.GetRowCellValue(i, colDutyDate))));
									invoicetext.AppendLine("Medical Cover - " + dt.ToString("ddd dd MMM yy"));


								}

							}
							_invoice.InvoiceLineItems.Add(new Utilities.myXero.Invoice.InvoiceLine()
							{
								AccountCode = _invoice.MainAccountingCode,
								ItemCode = "EMC",
								Description = invoicetext.ToString(),
								Quantity = 1,
								UnitAmount = _invoice.MainPrice
							});
						}
						else
						{
//INSTANT C# NOTE: There is no C# equivalent to VB's implicit 'once only' variable initialization within loops, so the following variable declaration has been placed prior to the loop:
							decimal qty = 0M;
							for (i = 0; i < ClinicalGridView.DataRowCount; i++)
							{
								if (ClinicalGridView.IsRowSelected(i))
								{

//									Dim qty As Decimal
									DateTime dt = DateTime.Parse((ClinicalGridView.GetRowCellValue(i, colDutyDate) == null ? null : Convert.ToString(ClinicalGridView.GetRowCellValue(i, colDutyDate))));
									qty = 1M;
									_invoice.InvoiceLineItems.Add(new Utilities.myXero.Invoice.InvoiceLine()
									{
										AccountCode = _invoice.MainAccountingCode,
										ItemCode = "EMC",
										Description = _invoice.LineDesc.Replace("{date}", dt.ToString("ddd dd MMM yy")),
										Quantity = qty,
										UnitAmount = _invoice.MainPrice
									});
									break;
								}

							}
						}

					}
					else if (_invoice.BillingType == Utilities.myXero.BillingTypes.FixedLine)
					{
						for (i = 0; i < ClinicalGridView.DataRowCount; i++)
						{
							if (ClinicalGridView.IsRowSelected(i))
							{
								DateTime dt = DateTime.Parse((ClinicalGridView.GetRowCellValue(i, colDutyDate) == null ? null : Convert.ToString(ClinicalGridView.GetRowCellValue(i, colDutyDate))));
								decimal qty = 1M;

								_invoice.InvoiceLineItems.Add(new Utilities.myXero.Invoice.InvoiceLine()
								{
									AccountCode = _invoice.MainAccountingCode,
									ItemCode = "EMC",
									Description = _invoice.LineDesc.Replace("{date}", dt.ToString("ddd dd MMM yy")),
									Quantity = qty,
									UnitAmount = _invoice.MainPrice
								});

							}

						}
					}

					if (_invoice.Email != null)
					{
						_invoice.Email = _invoice.Email;
					}
					else
					{
						_invoice.Email = null;
					}

					//Dim s As String = '_invoice.CreateInvoice()
					//  Debug.Print(s)

					//If DataHelper.IsNullOrEmpty(s) Then
					//    Throw New System.Exception("Error creating the invoice.")
					//End If

					//Dim root = JObject.Parse(s)
					string invoiceId = _invoice.CreateInvoiceReturnInvNumber(); //CStr(root.Item("InvoiceNumber"))
					_selectedColumn = colInvoice.FieldName;
					int num2 = 0;

					var i2 = 0;
					for (i = 0; i < ClinicalGridView.DataRowCount; i++)
					{
						if (ClinicalGridView.IsRowSelected(i))
						{
							num2 += 1;
							int sId = Utilities.SafeInt(ClinicalGridView.GetRowCellValue(i2, "ID"));
							Shifts.UpdateShiftDetails(sId, _selectedColumn, invoiceId);
							Security.LogEvent(("Batch updated: " + _selectedColumn + " to " + invoiceId), Security.AuditType.Shift, sId);
						}
						i2 += 1;
					}

					_selectedColumn = string.Empty;

					Utilities.ShowAlert(this, "Completed", (Utilities.SafeString(num2) + " shift invoice have been successfully added."));

					break;
				}
			}

			// RefreshMain(True)
		}
		catch (Exception ex)
		{
			Utilities.MyError(ex);
		}
		finally
		{
			Utilities.CloseProgressPanel(_han);
			Utilities.ScreenWait(false);
			var b = RefreshHold;
			RefreshHold = false;
			RefreshMain(true, "Main Refresh - New Invoice End");
			RefreshHold = b;
		}
	}

	public void UpdateInvoice(Utilities.myXero.Invoice i)
	{
		if (i == null)
		{

			_invoiceCancel = true;
		}
		else
		{
			_invoiceCancel = false;
			_invoice = i;
		}
	}

	private void btnCopy_ItemClick(object sender, ItemClickEventArgs e)
	{
		DevExpress.XtraGrid.Views.Grid.GridView tempVar = SolutionSettings.VisibleGrid;
		Utilities.Copy(ref tempVar);
		SolutionSettings.VisibleGrid = tempVar;
	}

	private void grdMyInbox_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
	{
		if (e.HitInfo.InRowCell)
		{
			btnReplyWith.Enabled = grdMyInbox.GetRowCellValue(grdMyInbox.FocusedRowHandle, "Type").ToString() == "Email";
			switch (grdMyInbox.GetRowCellValue(grdMyInbox.FocusedRowHandle, "Type").ToString())
			{

				case "Email":
					BarButtonItem6.Visibility = BarItemVisibility.Always;
					btnConvertLead.Visibility = BarItemVisibility.Always;
					btnConvertTask.Visibility = BarItemVisibility.Always;

					BarButtonItem6.Visibility = BarItemVisibility.Never;
					puEmail.ShowPopup(EmailGridControl.PointToScreen(e.Point));
					break;
				case "Task":
					BarButtonItem6.Visibility = BarItemVisibility.Always;
					btnConvertLead.Visibility = BarItemVisibility.Never;
					btnConvertTask.Visibility = BarItemVisibility.Never;
					puEmail.ShowPopup(EmailGridControl.PointToScreen(e.Point));

					break;
				default:
					BarButtonItem6.Visibility = BarItemVisibility.Never;
					btnConvertLead.Visibility = BarItemVisibility.Never;
					btnConvertTask.Visibility = BarItemVisibility.Never;
					puEmail.ShowPopup(EmailGridControl.PointToScreen(e.Point));
					break;
			}
		}
	}

	private void btnMedicRegister_ItemClick(object sender, ItemClickEventArgs e)
	{
		Utilities.ScreenWait(true, "Loading report...");
		repMedicRegister r = new repMedicRegister();

		ReportPrintTool t = new ReportPrintTool(r);
		t.ShowRibbonPreview();
		Utilities.ScreenWait(false);
	}

	//Private Sub ttPersonnell_GetActiveObjectInfo(sender As Object, e As ToolTipControllerGetActiveObjectInfoEventArgs) _
	// Handles ttPersonnell.GetActiveObjectInfo
	// If e.Info Is Nothing AndAlso e.SelectedControl Is PersonGridControl Then
	// Dim view = TryCast(PersonGridControl.FocusedView, GridView)
	// Dim info As GridHitInfo = view.CalcHitInfo(e.ControlMousePosition)
	// If info.InRowCell Then
	// Dim toolText As String = view.GetRowCellDisplayText(info.RowHandle, info.Column)
	// Select Case info.Column.Name.ToString()

	// Case "BandedGridColumn1"
	// toolText = "Shows if the medics earliest expiry has passed"
	// Case "colCompliance"
	// toolText = "How compliant the medic is with admin documents"
	// Case "colMed_Fac"
	// toolText = "Shows if the medics earliest expiry has passed"

	// Case "colComplianceExpiry"
	// toolText = "When the medics compliance rating drops i.e Certs Expire etc"

	// Case "colTimeStamp2"
	// toolText = "The last time the persons file was updated"

	// End Select

	// Dim cellKey As String = info.RowHandle.ToString() & " - " & info.Column.ToString()
	// e.Info = New ToolTipControlInfo(cellKey, toolText)
	// End If
	// End If
	//End Sub

	private void FilterMenu(Screens screenName)
	{

		var barManager = new BarManager {Form = this};

		Task.Run(() =>
		{
			btnFilterBy.ClearLinks();


			switch (screenName)
			{
				case Screens.Clinical:
				{

				break;
				}
				case Screens.MyHome:
				{
					barManager.Images = imgEmail;
					//Dim menu As New BarSubItem()
					Dictionary<string, int> d = new Dictionary<string, int>();

					for (var i = 0; i <= grdMyInbox.DataRowCount; i++)
					{
						object o = grdMyInbox.GetRowCellValue(i, "Type");
						if (Utilities.DataHelper.IsNull(o) == false)
						{
							if (d.ContainsKey((o == null ? null : Convert.ToString(o))) == false)
							{
								d.Add(Convert.ToString(grdMyInbox.GetRowCellValue(i, "Type")), Convert.ToInt32(grdMyInbox.GetRowCellValue(i, "Image")));
							}
						}
					}

					foreach (var item in d)
					{
						var btn = new BarButtonItem(barManager, item.Key, item.Value);
						btnFilterBy.AddItem(btn);
					}
					d.Clear();
					break;
				}
				case Screens.Calendar:
				{

				break;
				}
				case Screens.Training:
				{

				break;
				}
				case Screens.Personnel:
				{
					var sql = "SELECT Personnell.RegBody FROM Personnell GROUP BY Personnell.RegBody, Personnell.RegBody HAVING Personnell.RegBody<>'' ORDER BY Personnell.RegBody";
					var sql1 = @"Select
                            Personnell.Clinical_Grade,
                            Personnell.RegBody
                        From
                            Personnell
                        Where
                            Personnell.Locale = @T
                        Group By
                            Personnell.Clinical_Grade,
                            Personnell.RegBody,
                            Personnell.Locale
                        Having
                            Personnell.Clinical_Grade <> '' And
                            Personnell.RegBody <> ''";

					Dictionary<string, string> subItems = new Dictionary<string, string>();

					using (MySqlConnection con = new MySqlConnection(BM.Core.MySQlHelper.ConnectionString))
					{
						using (MySqlCommand cmd = new MySqlCommand(sql1, con))
						{
							cmd.Parameters.AddWithValue("@T", SolutionSettings.CurrentUser.TenantLocale);
							con.Open();
							using (var reader = cmd.ExecuteReader())
							{
								if (reader.HasRows)
								{
									while (reader.Read())
									{
										var regbody = (reader[1] == null ? null : Convert.ToString(reader[1]));
										var grade = (reader[0] == null ? null : Convert.ToString(reader[0]));
										subItems.Add(grade, regbody);
									}
								}
							}

						}

						using (MySqlCommand cmd = new MySqlCommand(sql, con))
						{
							using (var reader = cmd.ExecuteReader())
							{
								if (reader.HasRows)
								{
									while (reader.Read())
									{
										var regBody = (reader[0] == null ? null : Convert.ToString(reader[0]));
										var mmenu = new BarSubItem(barManager, (reader[0] == null ? null : Convert.ToString(reader[0]))) {Tag = "Main"};

										btnFilterBy.AddItem(mmenu);
										foreach (var item in subItems)
										{
											if (item.Value == regBody)
											{
												var btn = new BarButtonItem(barManager, item.Key) {Tag = "Sub"};

												mmenu.AddItem(btn);
											}
										}
									}
								}
							}
						}
						con.Close();
					}
					var mmenu1 = new BarButtonItem(barManager, "Ambulance Crew") {Tag = "AC"};
					//mmenu1.Links(0).BeginGroup = True
					btnFilterBy.AddItem(mmenu1);

					var d = new BarSubItem(barManager, "C Licence Driver") {Tag = "CDL"};

					btnFilterBy.AddItem(d);

					break;
				}
				case Screens.Assets:
				{

				break;
				}
				case Screens.Leads:
				{

				break;
				}
				case Screens.Governance:
				{
					var sql = "SELECT Body FROM GovStandards Where Body <>'' GROUP BY Body ";
					var sql1 = "SELECT Scope, Body FROM GovStandards Where Body=@Body GROUP BY Scope, Body Having Scope<>''";
					Dictionary<string, string> subItems = new Dictionary<string, string>();

					List<string> bodies = new List<string>();

					using (MySqlConnection con = new MySqlConnection(BM.Core.MySQlHelper.ConnectionString))
					{

						using (MySqlCommand cmd = new MySqlCommand(sql, con))
						{
							con.Open();
							using (var reader = cmd.ExecuteReader())
							{
								if (reader.HasRows)
								{
									while (reader.Read())
									{
										bodies.Add((reader[0] == null ? null : Convert.ToString(reader[0])));
									}
								}
							}
						}

						foreach (var body in bodies)
						{

							using (MySqlCommand cmd = new MySqlCommand(sql1, con))
							{
								cmd.Parameters.Clear();
								cmd.Parameters.AddWithValue("@Body", body.ToString());

								using (var reader = cmd.ExecuteReader())
								{
									if (reader.HasRows)
									{
										while (reader.Read())
										{
											var b = (reader[1] == null ? null : Convert.ToString(reader[1]));
											var scope = (reader[0] == null ? null : Convert.ToString(reader[0]));
											subItems.Add(scope, b);
										}
									}
								}
							}

							var mmenu = new BarSubItem(barManager, body) {Tag = "Main"};
							btnFilterBy.AddItem(mmenu);

							foreach (var item in subItems)
							{
								if (item.Value == body)
								{
									var btn = new BarButtonItem(barManager, item.Key) {Tag = "Sub"};

									mmenu.AddItem(btn);
								}
							}

							subItems.Clear();

						}
						con.Close();
					}

					break;
				}
				case Screens.Notes:
				{

				break;
				}
				case Screens.Risk:
				{

				break;
				}
				case Screens.Tasks:
				{

				break;
				}
				case Screens.Documents:
				{

					var sql = "Select Sender from Documents Group by Sender";
					var sql1 = "SELECT Author, Sender from Documents Group By Author, Sender";
					Dictionary<string, string> subItems = new Dictionary<string, string>();

					using (MySqlConnection con = new MySqlConnection(BM.Core.MySQlHelper.ConnectionString))
					{
						using (MySqlCommand cmd = new MySqlCommand(sql1, con))
						{
							con.Open();
							using (var reader = cmd.ExecuteReader())
							{
								if (reader.HasRows)
								{
									while (reader.Read())
									{
										if (Utilities.DataHelper.IsNull(reader[0]) == false)
										{
											if (Utilities.DataHelper.IsNull(reader[1]) == false)
											{
												subItems.Add((reader[0] == null ? null : Convert.ToString(reader[0])), (reader[1] == null ? null : Convert.ToString(reader[1])));
											}
										}
									}
								}
							}
						}

						using (MySqlCommand cmd = new MySqlCommand(sql, con))
						{
							using (var reader = cmd.ExecuteReader())
							{
								if (reader.HasRows)
								{
									while (reader.Read())
									{
										if (Utilities.DataHelper.IsNull(reader[0]) == false)
										{
											var catId = (reader[0] == null ? null : Convert.ToString(reader[0]));
											var mymenu = new BarSubItem(barManager, (reader[0] == null ? null : Convert.ToString(reader[0]))) {Tag = "Main"};

											btnFilterBy.AddItem(mymenu);
											foreach (var item in subItems)
											{
												if (item.Value == catId)
												{
													var btn = new BarButtonItem(barManager, item.Key) {Tag = "Sub"};
													mymenu.AddItem(btn);
												}
											}
										}
									}
								}
							}
						}
						con.Close();
					}

					break;
				}
				case Screens.Info:
				{
					var sql = "SELECT Type from Info Group By Type Order By Type Asc";
					using (MySqlConnection con = new MySqlConnection(BM.Core.MySQlHelper.ConnectionString))
					{
						using (MySqlCommand cmd = new MySqlCommand(sql, con))
						{
							con.Open();
							using (var reader = cmd.ExecuteReader())
							{
								if (reader.HasRows)
								{
									while (reader.Read())
									{
										var mmenu = new BarButtonItem(barManager, (reader[0] == null ? null : Convert.ToString(reader[0])));
										btnFilterBy.AddItem(mmenu);
									}
								}
							}
						}
						con.Close();
					}

					break;
				}
				case Screens.Audit:
				{
					barManager.Images = imgEmail;
					var sql = "Select Type from Audit Group by Type";
					using (MySqlConnection con = new MySqlConnection(BM.Core.MySQlHelper.ConnectionString))
					{
						using (MySqlCommand cmd = new MySqlCommand(sql, con))
						{
							con.Open();
							var reader = cmd.ExecuteReader();

							if (reader.HasRows)
							{
								while (reader.Read())
								{
									if (Utilities.DataHelper.IsNull(reader[0]) == false)
									{
										var btn = new BarButtonItem(barManager, (reader[0] == null ? null : Convert.ToString(reader[0])));
										btnFilterBy.AddItem(btn);
									}
								}
							}
						}
						con.Close();
					}

					break;
				}
				case Screens.Contacts:
				{
//barManager.Images = imgEmail

//Dim d As New Dictionary(Of String, String)

//For i = 0 To grdContacts.DataRowCount
// Dim o As Object = grdContacts.GetRowCellValue(i, "Group")
// If DataHelper.IsNull(o) = False Then
// If d.ContainsKey(o) = False Then
// d.Add(grdContacts.GetRowCellValue(i, "Group"), grdContacts.GetRowCellValue(i, "Group"))
// End If
// End If
//Next

//For Each item In d
// Dim btn = New BarButtonItem(barManager, item.Key)
// btnFilterBy.AddItem(btn)
//Next
//d.Clear()

				break;
				}
				case Screens.Flagged:
				{

				break;
				}
			}
			barManager.ItemClick += FilterMenuEvent;
		});
	}

	private void grdMyInbox_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
	{
		var view = sender as GridView;

		if (e.IsForGroupRow && view.GetRowLevel(e.GroupRowHandle) == 1)
		{
			// e.DisplayText = String.Empty

		}
	}


	private void FilterMenuEvent(object sender, ItemClickEventArgs e)
	{
		switch (SolutionSettings.VisibleScreen)
		{
			case Screens.Clinical:

			break;
			case Screens.MyHome:
				General.Filter.ShowByType(grdMyInbox, e.Item.Caption);
				break;
			case Screens.Calendar:
			break;
			case Screens.Training:
			break;
			case Screens.Personnel:
			break;
			case Screens.Assets:
			break;
			case Screens.Leads:
			break;
			case Screens.Governance:

				if (e.Item.Tag.ToString() == "Main")
				{
					Gov.Show.ShowByBody(e.Item.Caption, GovGrid);
				}
				else
				{
					Gov.Show.ShowByScope(e.Item.Links[0].Caption, e.Link.OwnerItem.Caption, GovGrid);
				}

				break;
			case Screens.Notes:
			break;
			case Screens.Risk:
			break;
			case Screens.Tasks:
			break;
			case Screens.Documents:
				if (e.Item.Tag.ToString() == "Sub")
				{
					BM.Area.Document.Show.ShowByAuthor(GridView10, e.Item.Caption);
				}
				else if (e.Item.Tag.ToString() == "Main")
				{

					BM.Area.Document.Show.ShowBySender(GridView10, e.Item.Caption);

				}
				break;
			case Screens.Info:
//Dim _
// info As _
// New ColumnFilterInfo(New BinaryOperator("Type", e.Item.Caption.ToString,
// BinaryOperatorType.Equal))
//grdInfo.Columns.Item("Type").FilterInfo = info

			break;
			case Screens.Audit:
				Gov.Show.ShowByType(grdAudit, e.Item.Caption);

				break;
			case Screens.Contacts:

//Dim grid As GridView = grdContacts
//grid.ClearColumnsFilter()
//Dim info As New ColumnFilterInfo(New BinaryOperator("Group", e.Item.Caption, BinaryOperatorType.Equal))
//grid.Columns.Item("Group").FilterInfo = info
//grid.RefreshData()
//grid.ExpandAllGroups()

			break;
			case Screens.Flagged:

			break;
		}
	}

	private void btnViewOverview_ItemClick(object sender, ItemClickEventArgs e)
	{
		Utilities.ScreenWait();
		frmGovOverview frm = new frmGovOverview();
		frm.Show(this);
		Utilities.ScreenWait(false);
	}

	private void GovGrid_MouseMove(object sender, MouseEventArgs e)
	{
		KeyPreview = false;
		if (_hitInfo != null && e.Button == System.Windows.Forms.MouseButtons.Left)
		{
			_dragfromGrid = true;
			Rectangle rectangle = new Rectangle(new Point(Convert.ToInt32((_hitInfo.HitPoint.X - (SystemInformation.DragSize.Width / 2.0))), Convert.ToInt32((_hitInfo.HitPoint.Y - (SystemInformation.DragSize.Height / 2.0)))), SystemInformation.DragSize);
			if ((_hitInfo.RowHandle != - 2147483648) && !rectangle.Contains(new Point(e.X, e.Y)))
			{
				object objectValue = GovGrid.GetRow(_hitInfo.RowHandle);
				if (objectValue != null)
				{

					GovStandardsGridControl.DoDragDrop(objectValue, DragDropEffects.Copy);
					//GovGrid.ExpandAllGroups()
				}
				else
				{

				}
			}
		}
	}

	private void GovGrid_MouseDown(object sender, MouseEventArgs e)
	{
		_hitInfo = GovGrid.CalcHitInfo(new Point(e.X, e.Y));
	}

	private void btnCasualtySummary_ItemClick(object sender, ItemClickEventArgs e)
	{
		_han = (IOverlaySplashScreenHandle)Utilities.ShowProgressPanel(this);
		repCasualtyReport r = new repCasualtyReport();
		ReportPrintTool t = new ReportPrintTool(r);
		t.ShowRibbonPreviewDialog();
		Utilities.CloseProgressPanel(_han);
	}

	private void ClinicalGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		Shifts.ClearTempCertRows();

		if (ClinicalGridView.SelectedRowsCount == 0)
		{
			RibbonPageBatchUpdate.Enabled = false;
		}
		else
		{
			RibbonPageBatchUpdate.Enabled = true;
		}

		for (var i = 0; i < ClinicalGridView.DataRowCount; i++)
		{
			if (ClinicalGridView.IsRowSelected(i))
			{
				Shifts.SetTempCertRows(Convert.ToInt32(ClinicalGridView.GetRowCellValue(i, "ID")));
			}
		}
	}

	private void TrainingGridView_EndGrouping(object sender, EventArgs e)
	{
		if (TrainingGridView.GroupedColumns.Count == 0)
		{
			btnGridCollapse.Enabled = false;
			btnGridExpand.Enabled = false;
		}
		else
		{
			btnGridCollapse.Enabled = true;
			btnGridExpand.Enabled = true;
		}
	}

	private void ClinicalGridView_EndGrouping(object sender, EventArgs e)
	{
		if (ClinicalGridView.GroupedColumns.Count == 0)
		{
			btnGridCollapse.Enabled = false;
			btnGridExpand.Enabled = false;
		}
		else
		{
			btnGridCollapse.Enabled = true;
			btnGridExpand.Enabled = true;
		}
	}

	private void btnAmbulanceControl_ItemClick(object sender, ItemClickEventArgs e)
	{

		frmAmbMain amain = new frmAmbMain();
		_han = (IOverlaySplashScreenHandle)Utilities.ShowProgressPanel(this);
		if (Utilities.FormHelper.IsFormOpen(amain) == false)
		{
			amain.Show();
		}
		Utilities.CloseProgressPanel(_han);
		RefreshHold = true;
	}

	private void MultiGrid_ColumnFilterChanged(object sender, EventArgs e)
	{

		var t = Utilities.GridRules.GeneralColour(ClinicalGridView.Columns["Validate"], FormatCondition.Equal, true, Color.DarkRed);

		//Debug.Print(ClinicalGridView.FormatRules.Contains(r.First))
		if (ClinicalGridView.FormatRules.Contains(ClinicalGridView.FormatRules[t.Name]))
		{
			Debug.Print("Removed");
			ClinicalGridView.FormatRules.Remove(ClinicalGridView.FormatRules[t.Name]);
			//ClinicalGridView.FormatRules.RemoveAt(i)

		}
	}

	private void MouseClickGrid(object sender, MouseEventArgs e)
	{

		switch (e.Button)
		{
			case System.Windows.Forms.MouseButtons.XButton1:
				if (File.Exists(SolutionSettings.VisibleGrid.Name + " View1.xml"))
				{
					SolutionSettings.VisibleGrid.GridControl.MainView.RestoreLayoutFromXml(SolutionSettings.VisibleGrid.Name + " View1.xml");
				}

				break;
			case System.Windows.Forms.MouseButtons.XButton2:
				if (File.Exists(SolutionSettings.VisibleGrid.Name + " View1.xml"))
				{
					SolutionSettings.VisibleGrid.GridControl.MainView.RestoreLayoutFromXml(SolutionSettings.VisibleGrid.Name + " View1.xml");

				}
				break;
		}
	}

	private void RepositoryItemHyperLinkEdit19_OpenLink(object sender, OpenLinkEventArgs e)
	{

		if (TrainingGridView.GetFocusedDisplayText() == "Public")
		{
			XtraMessageBox.Show("You cannot check the invoice status of a Public Course.", "Not Possible", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
		else
		{
			Utilities.ScreenWait(true, "Checking Invoice...");
			Utilities.myXero.Invoice.GetInvoiceStatus(TrainingGridView.GetFocusedDisplayText());
			Utilities.ScreenWait(false);
		}
	}

	private void grdMyInbox_DoubleClick(object sender, EventArgs e)
	{
		//Dim app As Object
		//Dim ns As Object
		//Dim msg As MailItem
		//'Try
		//Dim view = CType(sender, GridView)
		//Dim pt As Point = view.GridControl.PointToClient(MousePosition)

		//Dim info As GridHitInfo = view.CalcHitInfo(pt)
		//If info.InRow OrElse info.InRowCell Then

		//    If grdMyInbox.GetRowCellValue(info.RowHandle, "Type") = "Email" Then

		//        ScreenWait()
		//        app = CreateObject("Outlook.Application")
		//        ns = app.GetNamespace("MAPI")
		//        msg = ns.GetItemFromID(grdMyInbox.GetRowCellValue(info.RowHandle, "ID"))
		//        msg.Reply()
		//        msg.Display()

		//        ScreenWait(False)
		//    Else
		//        If info.InRowCell Then
		//            Call grdMyInbox_RowCellClick(Nothing, Nothing)
		//        End If

		//    End If

		//End If
		//'Catch ex As System.Exception
		//' MyError(ex)
		//'Finally
		//' ReSharper disable once RedundantAssignment
		//' ReSharper disable once RedundantAssignment
		//app = Nothing
		//' ReSharper disable once RedundantAssignment
		//ns = Nothing
		//' ReSharper disable once RedundantAssignment
		//msg = Nothing

		// End Try
	}

	private void GovGrid_CustomDrawFooterCell(object sender, FooterCellCustomDrawEventArgs e)
	{
		e.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
	}

	private void TreeList1_MouseLeave(object sender, EventArgs e)
	{
		KeyPreview = true;
	}

	private void BarButtonItem23_ItemClick(object sender, ItemClickEventArgs e)
	{
		_treeState.LoadState();
	}

	private void btnGovReportOverview_ItemClick(object sender, ItemClickEventArgs e)
	{
		var sql = "Select Body from GovStandards Group by Body";

		XtraInputBoxArgs args = new XtraInputBoxArgs
		{
			Caption = "Select Governance Body",
			DefaultButtonIndex = 0
		};
		ComboBoxEdit editor = new ComboBoxEdit();
		using (MySqlConnection con = new MySqlConnection(BM.Core.MySQlHelper.ConnectionString))
		{
			using (MySqlCommand cmd = new MySqlCommand(sql, con))
			{
				con.Open();

				var reader = cmd.ExecuteReader();

				if (reader.HasRows)
				{
					while (reader.Read())
					{
						editor.Properties.Items.Add(reader[0]);
					}
				}
			}
			con.Close();
		}

		args.Editor = editor;
		var results = XtraInputBox.Show(args).ToString();
		if (string.IsNullOrEmpty(results) == false)
		{
			Utilities.ScreenWait();
			repGov r = new repGov();
			r.pBody.Value = results;
			r.pBody.Visible = false;

			ReportPrintTool t = new ReportPrintTool(r);
			t.ShowRibbonPreviewDialog();
			Utilities.ScreenWait(false);
		}
	}

	private void btnGovReportDetails_ItemClick(object sender, ItemClickEventArgs e)
	{
		var sql = "Select Body from GovStandards Group by Body";

		XtraInputBoxArgs args = new XtraInputBoxArgs
		{
			Caption = "Select Governance Body",
			DefaultButtonIndex = 0
		};
		ComboBoxEdit editor = new ComboBoxEdit();
		using (MySqlConnection con = new MySqlConnection(BM.Core.MySQlHelper.ConnectionString))
		{
			using (MySqlCommand cmd = new MySqlCommand(sql, con))
			{
				con.Open();

				var reader = cmd.ExecuteReader();

				if (reader.HasRows)
				{
					while (reader.Read())
					{
						editor.Properties.Items.Add(reader[0]);
					}
				}
			}
			con.Close();
		}

		args.Editor = editor;

		var results = XtraInputBox.Show(args).ToString();
		if (string.IsNullOrEmpty(results) == false)
		{
			Utilities.ScreenWait();
			repGovDetails r = new repGovDetails();
			r.pBody.Value = results;
			r.pBody.Visible = false;

			ReportPrintTool t = new ReportPrintTool(r);
			t.ShowRibbonPreviewDialog();
			Utilities.ScreenWait(false);
		}
	}

	private void BarButtonItem24_ItemClick_1(object sender, ItemClickEventArgs e)
	{
		Gov.Show.Applicable(GovGrid);
	}

	//Private Sub AdvBandedGridView1_CustomRowFilter(sender As Object, e As RowFilterEventArgs) Handles AdvBandedGridView1.CustomRowFilter
	// Try
	// Dim pFindPanel As PropertyInfo = GridView1.GetType().GetProperty("FindPanel", BindingFlags.NonPublic Or BindingFlags.Instance)
	// Dim findPanel As FindControl = CType(pFindPanel.GetValue(GridView1, Nothing), FindControl)
	// If findPanel IsNot Nothing Then
	// (findPanel.FindEdit.Text)
	// End If

	// Catch ex As Exception
	// MyError(ex)
	// End Try
	//End Sub

	private void btnPaid_ItemClick(object sender, ItemClickEventArgs e)
	{
		try
		{
			RefreshHold = true;
			Course.Show.PastOpenCourses(TrainingGridView);
			TrainingGridView.ExpandAllGroups();
			SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
			for (int i = TrainingGridView.RowCount - 1; i >= 0; i--)
			{

				if (Utilities.SafeString(TrainingGridView.GetRowCellValue(i, colIntRef)) == "Deferred")
				{
					continue;
				}

				if (Utilities.DataHelper.IsNullOrEmpty(TrainingGridView.GetRowCellValue(i, colIntRef)))
				{
					TrainingGridView.DeleteRow(i);
				}
				else
				{
					var inv = (TrainingGridView.GetRowCellValue(i, colIntRef) == null ? null : Convert.ToString(TrainingGridView.GetRowCellValue(i, colIntRef)));
					if (inv != "Stripe")
					{

						SplashScreenManager.Default.SetWaitFormDescription("Getting status of Course " + TrainingGridView.GetRowCellValue(i, "ID").ToString());

						if (DateTime.Parse(TrainingGridView.GetRowCellValue(i, "DateofCourse").ToString()) < DateTime.Today && TrainingGridView.GetRowCellValue(i, "Status").ToString() == "Waiting")
						{

							if (Utilities.myXero.Invoice.InvoicePaid(inv) == true)
							{
								//TrainingGridView.DeleteRow(i)


								Course.SetPaid(Convert.ToInt32(TrainingGridView.GetRowCellValue(i, "ID")));
								Security.LogEvent("Marked - Cert Ready", Security.AuditType.Course, TrainingGridView.GetRowCellValue(i, "ID"));
							}


							//debug.Print(TrainingGridView.GetRowCellValue(i, "ID"))
						}
					}
					else
					{
						//debug.Print(TrainingGridView.GetRowCellValue(i, "ID"))
						//Course.SetPaid(Convert.ToInt32(TrainingGridView.GetRowCellValue(i, "ID")))
						//Core.Security.LogEvent("Marked - Cert Ready", Core.Security.AuditType.Course,TrainingGridView.GetRowCellValue(i, "ID"))
					}
				}
				//Windows.Forms.Application.DoEvents()
			}
		}
		catch (Exception ex)
		{
			Utilities.MyError(ex);
		}
		finally
		{
			SplashScreenManager.CloseForm(false);
		}
	}

//    Private Sub SetupTree()
//
//        Dim uRead = 0
//        Dim read = 0
//        Dim uTask = 0
//        Dim task = 0
//        Dim policy = 0
//        Dim audit = 0
//        Dim lead = 0
//
//        If _emailBs Is Nothing Then
//            Return
//        End If
//
//        For Each row As DataRow In _emailMain.Rows
//            'For i As Integer = grdMyInbox.DataRowCount - 1 To 0 Step -1
//            ' (grdMyInbox.GetRowCellValue(i, "Type") & " " & grdMyInbox.GetRowCellValue(i, "Seen"))
//
//            Dim seen As Boolean = Convert.ToBoolean(row.Item("Seen"))
//
//            Select Case row.Item("Type").ToString
//                Case "Email"
//
//                    If seen Then
//                        read += 1
//                    Else
//                        uRead += 1
//                    End If
//                Case "Task"
//                    If seen Then
//                        task += 1
//                    Else
//                        uTask += 1
//                    End If
//
//                Case "Lead"
//                    lead += 1
//
//                Case "Policy"
//                    policy += 1
//
//                Case "Audit"
//                    audit += 1
//            End Select
//
//        Next
//
//        TaskTree.BeginUnboundLoad()
//        TaskTree.Columns.Clear()
//        TaskTree.Nodes.Clear()
//        Dim col1 As TreeListColumn = TaskTree.Columns.Add()
//        col1.Caption = "Type"
//        col1.VisibleIndex = 0
//
//        Dim parentForRootNodes As TreeListNode = Nothing
//        Dim emailsnode As TreeListNode = TaskTree.AppendNode(New Object() {"Emails"}, parentForRootNodes)
//        Dim taskNode As TreeListNode = TaskTree.AppendNode(New Object() {"Tasks"}, parentForRootNodes)
//
//        If uRead > 0 Then
//            TaskTree.AppendNode(New Object() {"Unread emails: " & uRead}, emailsnode.Id, 0, 0, 0)
//            TaskTree.AppendNode(New Object() {"Read emails: " & read}, emailsnode.Id, 1, 1, 1)
//        Else
//
//            TaskTree.AppendNode(New Object() {"Read emails: " & read}, emailsnode.Id, 1, 1, 1)
//        End If
//
//        If uTask > 0 Then
//            TaskTree.AppendNode(New Object() {"Read Tasks: " & task}, taskNode.Id, 3, 3, 3, 3)
//            TaskTree.AppendNode(New Object() {"Unread Tasks: " & uTask}, taskNode.Id, 3, 3, 3, 3)
//        Else
//            TaskTree.AppendNode(New Object() {"Read Tasks: " & task}, taskNode.Id, 3, 3, 3, 3)
//        End If
//
//        If lead > 0 Then
//            Dim leadNode As TreeListNode = TaskTree.AppendNode(New Object() {"Leads"}, parentForRootNodes)
//            TaskTree.AppendNode(New Object() {"Leads: " & lead}, leadNode.Id, 4, 4, 4, 4)
//        End If
//
//        If policy > 0 Then
//            Dim policynode As TreeListNode = TaskTree.AppendNode(New Object() {"Policys"}, parentForRootNodes)
//            TaskTree.AppendNode(New Object() {"Policys: " & policy}, policynode.Id, 9, 9, 9, 9)
//        End If
//
//        If audit > 0 Then
//            Dim auditnode As TreeListNode = TaskTree.AppendNode(New Object() {"Audit"}, parentForRootNodes)
//            TaskTree.AppendNode(New Object() {"Audit: " & audit}, auditnode.Id, 7, 7, 7, 7)
//        End If
//
//        TaskTree.ExpandAll()
//        TaskTree.EndUnboundLoad()
//    End Sub

	private void GovGrid_MouseLeave(object sender, EventArgs e)
	{
		KeyPreview = true;
	}

	private void GovGrid_KeyDown(object sender, KeyEventArgs e)
	{
		// ("Grid " & e.KeyValue.ToString)
		// (TreeList1.FocusedNode.GetValue("Section"))
		switch (e.KeyValue)
		{
			case (System.Int32)Keys.End:

				Gov.NotApplicable(Convert.ToInt32(GovGrid.GetRowCellValue(GovGrid.FocusedRowHandle, "ID")));
				RefreshMain(false, "Main Refresh - Gov Key Down");

				break;
			case (System.Int32)Keys.Insert:
				if (TreeList1.FocusedNode != null)
				{
					int rh = GovGrid.FocusedRowHandle;
					var str = (GovGrid.GetRowCellValue(GovGrid.FocusedRowHandle, "ID") == null ? null : Convert.ToString(GovGrid.GetRowCellValue(GovGrid.FocusedRowHandle, "ID")));
					TreeListNode node2 = TreeList1.FocusedNode;

					TreeList1.FocusedNode = TreeList1.FindNodeByKeyID(Gov.AddNewDragGov(Convert.ToInt32(node2.GetValue("ID")), GovGrid.GetRowCellValue(rh, "Type").ToString(), int.Parse(str), GovGrid.GetRowCellValue(rh, "Reference").ToString() + " " + GovGrid.GetRowCellValue(rh, "Name").ToString(), Utilities.SafeInt(GovGrid.GetRowCellValue(rh, "ID"))));
					node2.Expanded = true;
					RefreshMain(false, "Main Refresh - Gov Grd Press");
				}

				break;
			case (System.Int32)Keys.Home:
				Gov.SetLocked(Utilities.SafeInt(GovGrid.GetRowCellValue(GovGrid.FocusedRowHandle, "ID")));
				RefreshMain(false, "Main Refresh - Gov Grid");

				break;
		}
	}

	private void TaskTree_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
	{
		// (e.Node.GetValue("Type"))
	}

	private void btnGovNotApplicable_ItemClick(object sender, ItemClickEventArgs e)
	{
		Gov.SetApplicable(false, GovGrid.GetRowCellValue(GovGrid.FocusedRowHandle, "ID"));
		RefreshMain(false, "Main Refresh - BtnGov NA");
	}

	private void TaskTree_NodeCellStyle(object sender, GetCustomNodeCellStyleEventArgs e)
	{
		if (e.Node.GetValue("Type").ToString().Contains("Unread"))
		{
			e.Appearance.Font = new Font(TreeList1.Appearance.Row.Font, FontStyle.Bold);
		}
	}

	private void btnClinicalKPI_ItemClick(object sender, ItemClickEventArgs e)
	{
		frmClinicalKPI frm = new frmClinicalKPI();
		frm.Show(this);
	}

	private void btnBatchImport_ItemClick(object sender, ItemClickEventArgs e)
	{
		try
		{

			Utilities.ScreenWait(true, "Loading Tool");
			frmImportStudents frm = new frmImportStudents(this, "Course");
			frm.ShowDialog();
			Utilities.ScreenWait(false);
			RefreshMain(false, "Main Refresh - Batch Import");
		}
		catch (Exception ex)
		{
			Utilities.MyError(ex);
		}
	}

	private void btnZoomIn_ItemClick(object sender, ItemClickEventArgs e)
	{
		Utilities.ShowAlert(this, "Test", "Test Txt");
		schCourses.ActiveView.ZoomIn();
	}

	private void BtnZoomOut_ItemClick(object sender, ItemClickEventArgs e)
	{
		schCourses.ActiveView.ZoomOut();
	}

	private void TaskTree_Click(object sender, EventArgs e)
	{

		string s = Utilities.SafeString(TaskTree.FocusedNode.GetValue("Type"));

		if (s.ToLower().Contains("emails"))
		{
			if (s.ToLower().Contains("unread emails"))
			{
				General.Filter.ShowByType(grdMyInbox, "Email");
			}
			else
			{
				General.Filter.ShowByType(grdMyInbox, "Email");
			}

		}
		else if (s.ToLower().Contains("tasks"))
		{
			if (s.ToLower().Contains("unread tasks"))
			{
				General.Filter.ShowByType(grdMyInbox, "Task");
			}
			else
			{
				General.Filter.ShowByType(grdMyInbox, "Task");
			}

		}
		else if (s.ToLower().Contains("policy"))
		{
			General.Filter.ShowByType(grdMyInbox, "Policy");

		}
		else if (s.ToLower().Contains("audit"))
		{
			General.Filter.ShowByType(grdMyInbox, "Audit");

		}
	}

	//Private Sub BarButtonItem24_ItemClick_2(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem24.ItemClick
	// Export.ExportMoodle(AdvBandedGridView1)

	//End Sub

	private void btnClinicalAudits_ItemClick(object sender, ItemClickEventArgs e)
	{
		frmClinicalAudit frm = new frmClinicalAudit();
		frm.Show(this);
	}

	private void brShares_ItemClick(object sender, ItemClickEventArgs e)
	{

		Networking.CheckNetworkAvailable();

		if (Networking.NetworkSharesAvailable == true)
		{
			brShares.Caption = "LAN OK";
			brShares.ImageOptions.Image = BM.Properties.Resources.network_status;
		}
		else
		{
			brShares.Caption = "No LAN Network";
			brShares.ImageOptions.Image = BM.Properties.Resources.network_status_busy;
		}
	}

	private void btnPhonebook_ItemClick(object sender, ItemClickEventArgs e)
	{
		var sql = "Select Id, InstructorName, `Mobile Phone` as Mobile from BusinessManager.Personnell where Not (`Mobile Phone` is null) ";

		Personnel.AddressBook add = new Personnel.AddressBook();

		using (MySqlConnection con = new MySqlConnection(BM.Core.MySQlHelper.ConnectionString))
		{
			using (MySqlCommand cmd = new MySqlCommand(sql, con))
			{
				con.Open();
				var results = cmd.ExecuteReader();
				if (results.HasRows)
				{
					while (results.Read())
					{
						Personnel.AddressBook.Contact c = new Personnel.AddressBook.Contact
						{
							FirstName = Utilities.SplitbySpaceFirstString((results["InstructorName"] == null ? null : Convert.ToString(results["InstructorName"]))),
							LastName = Utilities.SplitbySpaceLastString(results["InstructorName"]),
							ID = Convert.ToInt32(results["ID"])
						};
						c.Phone.phonenumber = (results["Mobile"] == null ? null : Convert.ToString(results["Mobile"]));
						add.Contacts.Add(c);
					}
				}
			}
			con.Close();
		}

		var f = "Z:\\PhoneBook\\phone.xml";

		Utilities.FileHelper.Serialize(add, f);

		if (File.Exists(f))
		{
			XtraMessageBox.Show(string.Format("{0}{1}Has been created", f, Environment.NewLine), "File Exported", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
		else
		{
			XtraMessageBox.Show(string.Format("{0}{1}Count not be created", f, Environment.NewLine), "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}

	private void BarButtonItem26_ItemClick_1(object sender, ItemClickEventArgs e)
	{
		//Dim l As New List(Of String)
		//For z As Integer = 0 To AdvBandedGridView1.DataRowCount - 1
		// If Not DataHelper.IsNullOrEmpty(AdvBandedGridView1.GetRowCellValue(z, "Email")) Then
		// l.Add(AdvBandedGridView1.GetRowCellValue(z, "Email"))
		// End If

		//Next
		//'XtraMessageBox.Show(String.Join(",", l.ToArray))
		//Dim file As StreamWriter
		//IO.File.WriteAllText("Y:\Temp\EmailList.csv", String.Empty)
		//file = My.Computer.FileSystem.OpenTextFileWriter("Y:\Temp\EmailList.csv", True)

		//l.ForEach(Sub(x) file.WriteLine(x))

		//'file.WriteLine(l.tolist)
		//file.Close()
		//file.Dispose()
	}

	private void btnIndentRow_ItemClick(object sender, ItemClickEventArgs e)
	{
		if (SolutionSettings.VisibleGrid.LevelIndent == - 1)
		{
			SolutionSettings.VisibleGrid.LevelIndent = 0;
		}
		else
		{
			if (SolutionSettings.VisibleGrid.Columns[0].Fixed == FixedStyle.Left)
			{
				SolutionSettings.VisibleGrid.Columns[0].Fixed = FixedStyle.None;
			}
			SolutionSettings.VisibleGrid.LevelIndent = - 1;

		}
	}

	private void btnGovApplicapable_ItemClick(object sender, ItemClickEventArgs e)
	{
		Gov.SetApplicable(true, GovGrid.GetRowCellValue(GovGrid.FocusedRowHandle, "ID"));
		RefreshMain(false, "Main Refresh - BTN GOV NA");
	}

	private void btnPrintGovList_ItemClick(object sender, ItemClickEventArgs e)
	{
		_han = (IOverlaySplashScreenHandle)Utilities.ShowProgressPanel(this);

		repPolicyList r = new repPolicyList();
		r.ParentG.Value = TreeList1.FocusedNode.GetValue("ID");
		r.ParentG.Visible = false;

		ReportPrintTool t = new ReportPrintTool(r);
		t.ShowRibbonPreview();
		Utilities.CloseProgressPanel(_han);
	}

	private void btnGroupColour_ItemClick(object sender, ItemClickEventArgs e)
	{

		SolutionSettings.VisibleGrid.OptionsLayout.StoreFormatRules = true;
		if (SolutionSettings.ColouredGrid.Contains(SolutionSettings.VisibleGrid.Name))
		{
			SolutionSettings.VisibleGrid.RowStyle -= Utilities.GridHelp.ColourGroupRows;
			SolutionSettings.VisibleGrid.CustomDrawGroupRow -= Utilities.GridHelp.CustomDrawMyGroup;
			SolutionSettings.ColouredGrid.Remove(SolutionSettings.VisibleGrid.Name);
			SolutionSettings.VisibleGrid.OptionsView.EnableAppearanceOddRow = true;
			SolutionSettings.VisibleGrid.OptionsView.EnableAppearanceEvenRow = false;
			SolutionSettings.VisibleGrid.RestoreLayoutFromRegistry(string.Format("Software\\Medicore\\Dashboard\\{0}\\", SolutionSettings.VisibleGrid.Name));
		}
		else
		{
			SolutionSettings.VisibleGrid.SaveLayoutToRegistry(string.Format("Software\\Medicore\\Dashboard\\{0}\\", SolutionSettings.VisibleGrid.Name));
			SolutionSettings.VisibleGrid.FormatRules.Clear();
			SolutionSettings.VisibleGrid.RowStyle += Utilities.GridHelp.ColourGroupRows;
			SolutionSettings.VisibleGrid.CustomDrawGroupRow += Utilities.GridHelp.CustomDrawMyGroup;
			SolutionSettings.ColouredGrid.Add(SolutionSettings.VisibleGrid.Name);
			SolutionSettings.VisibleGrid.OptionsView.EnableAppearanceOddRow = false;
			SolutionSettings.VisibleGrid.OptionsView.EnableAppearanceEvenRow = false;

		}
	}

	private void btnGoToToday_ItemClick(object sender, ItemClickEventArgs e)
	{
		schCourses.Start = DateTime.Today;
	}

	private void btnClearTreeFilter_ItemClick(object sender, ItemClickEventArgs e)
	{
		TreeList1.ClearColumnsFilter();
		btnClearTreeFilter.Enabled = false;
	}

	//Private Sub AdvBandedGridView1_RowCellClick(sender As Object, e As XtraGrid.Views.Grid.RowCellClickEventArgs) Handles AdvBandedGridView1.RowCellClick
	// If e.Button = MouseButtons.Right Then
	// e.Handled = True
	// Return
	// End If

	// If e.Column.Name = "colAttachments1" Then
	// ScreenWait(True, "Loading", "Loading person details...")
	// Dim frm As New frmPersonnel_Details(Me)
	// frm.LoadDetails(AdvBandedGridView1.GetRowCellValue(e.RowHandle, "ID"), True)
	// frm.Show(me)
	// CloseProgressPanel(_han)
	// End If
	//End Sub

	private void btnViewGroupStandards_ItemClick(object sender, ItemClickEventArgs e)
	{
		_han = (IOverlaySplashScreenHandle)Utilities.ShowProgressPanel(this);

		var l = Gov.GetListofStandards(Convert.ToInt32(TreeList1.FocusedNode.GetValue("ID")));

		if (TreeList1.FocusedNode.HasChildren)
		{

			foreach (TreeListNode n in TreeList1.FocusedNode.Nodes)
			{

				if (n.HasChildren)
				{
					l.AddRange(Gov.GetListofStandards(Convert.ToInt32(n.GetValue("ID"))));
					// (n.getvalue("Section"))
				}

			}

		}

		if (l.Count == 0)
		{
			XtraMessageBox.Show("Nothing to show");
		}
		else
		{
			//_l.ForEach(Sub(x) (x))
			// GovGrid.ActiveFilter.Clear()
			StringBuilder s = new StringBuilder();

			l.ForEach((x) => s.Append(string.Format("[ID]={0} OR ", x.ToString())));

			// (s.ToString().Substring(0, s.Length - 3))
			GovGrid.ActiveFilter.Clear();
			GovGrid.ActiveFilter.Add(new ViewColumnFilterInfo(colID14, new ColumnFilterInfo(s.ToString().Substring(0, s.Length - 3))));
			GovGrid.ExpandAllGroups();

		}

		Utilities.CloseProgressPanel(_han);
	}

	private void btnCopyFiles_ItemClick(object sender, ItemClickEventArgs e)
	{
		DataObject dataObject = new DataObject();
		ArrayList tempFileArray = new ArrayList();

		for (var i = 0; i < SolutionSettings.VisibleGrid.DataRowCount; i++)
		{

			if (SolutionSettings.VisibleGrid.IsRowSelected(i))
			{

				if (Utilities.DataHelper.IsNullOrEmpty(SolutionSettings.VisibleGrid.GetRowCellValue(i, "Path")))
				{
					Utilities.ShowAlert(this, string.Format("Item {0} file could not be found", SolutionSettings.VisibleGrid.GetRowCellValue(i, "ID")), "Not Found!");
				}
				else
				{

					tempFileArray.Add(SolutionSettings.VisibleGrid.GetRowCellValue(i, "Path"));
					// (VisibleGrid.GetRowCellValue(i, "Path"))
				}
			}

		}
		//tempFileArray.ForEach(Sub(x) (x.ToString()))
		dataObject.SetData(DataFormats.FileDrop, false, (string[])tempFileArray.ToArray(typeof(string)));
		Clipboard.SetDataObject(dataObject);
	}

	private void TrainingGrid_DragDrop(object sender, DragEventArgs e)
	{
		try
		{

			Point pt = TrainingGrid.PointToClient(new Point(e.X, e.Y));
			var info = (GridHitInfo)TrainingGrid.MainView.CalcHitInfo(pt);
			int rowHandle = info.RowHandle;
			object objectValue = TrainingGridView.GetRowCellValue(rowHandle, "ID");
			if (TrainingGridView.IsValidRowHandle(info.RowHandle) == true)
			{
				if (objectValue != null || objectValue != DBNull.Value)
				{
					if (e.Data.GetDataPresent(DataFormats.FileDrop))
					{
						var files = (string[])e.Data.GetData(DataFormats.FileDrop);
						if (files.Length > 1)
						{
							XtraMessageBox.Show("You are trying to drop more than 1 file into this record. " + Environment.NewLine + "You can only drop 1 file per record." + Environment.NewLine + Environment.NewLine + "Select 1 file and try again.", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						}
						else
						{
							Course.Details.AddCourseSignInDrag(Convert.ToInt32(objectValue.ToString()), files[0]);
							BtnRefresh.PerformClick();
						}
					}
					else if (e.Data.GetDataPresent("FileGroupDescriptor"))
					{
						Course.Details.AddCourseSignInDrag(Convert.ToInt32(objectValue.ToString()), Utilities.DDHelper.DragEmailFile(e).FullName);
						BtnRefresh.PerformClick();

					}
				}
			}
		}
		catch (Exception ex)
		{
			Utilities.MyError(ex);
		}
	}

	private void TrainingGrid_DragOver(object sender, DragEventArgs e)
	{
		if (e.Data.GetDataPresent(DataFormats.FileDrop) | e.Data.GetDataPresent("FileGroupDescriptor"))
		{

			e.Effect = DragDropEffects.Copy;
		}
		else
		{
			e.Effect = DragDropEffects.None;
		}
	}

	private void btnOpenFolder_ItemClick(object sender, ItemClickEventArgs e)
	{
		if (SolutionSettings.VisibleGrid.Name == TrainingGridView.Name || SolutionSettings.VisibleGrid.Name == ClinicalGridView.Name)
		{

			if (SolutionSettings.VisibleGrid.IsValidRowHandle(SolutionSettings.VisibleGrid.GetSelectedRows().FirstOrDefault()) == true)
			{
				string f = null;
				var i = SolutionSettings.VisibleGrid.GetRowCellValue(Convert.ToInt32(SolutionSettings.VisibleGrid.GetSelectedRows().First().ToString()), "ID");
				if (SolutionSettings.VisibleGrid.Name == TrainingGridView.Name)
				{
					f = Course.CourseDirectory.GetDir(Convert.ToInt32(i));
				}
				else
				{
					f = Shifts.Directory.GetShiftDir(Convert.ToInt32(i));
				}
				// (f)
				if (Directory.Exists(f))
				{
					Utilities.FileHelper.LaunchFile(f);
				}
				else
				{
					XtraMessageBox.Show("The folder could not be opened. The network location may be unavailable or the folder may not have been created.", "Not available", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			else
			{
				// ("invalid")
			}
		}
		else
		{
			XtraMessageBox.Show("This function is not available");
		}
	}

	private void btnCopyStandards_ItemClick(object sender, ItemClickEventArgs e)
	{
		var l = Gov.GetListofStandardsRef(Convert.ToInt32(TreeList1.FocusedNode.GetValue("ID")));

		if (l.Count == 0)
		{
			XtraMessageBox.Show("Nothing to show");
		}
		else
		{
			StringBuilder s = new StringBuilder();
			l.Sort();
			l.ForEach((x) => s.Append(x + " / "));
			Clipboard.SetText(s.ToString());
		}
	}

	private void btnShowGroupSummary_ItemClick(object sender, ItemClickEventArgs e)
	{
		SolutionSettings.VisibleGrid.OptionsMenu.ShowGroupSummaryEditorItem = true;
	}

	private void btnTrainingAction_ItemClick(object sender, ItemClickEventArgs e)
	{
		Course.Show.OpenCourses(TrainingGridView);
		RefreshHold = true;

		SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
		for (int i = TrainingGridView.RowCount - 1; i >= 0; i--)
		{
			var keep = false;
			SplashScreenManager.Default.SetWaitFormDescription("Getting status of Course " + TrainingGridView.GetRowCellValue(i, "ID").ToString());

			if (!Utilities.DataHelper.IsNullOrEmpty(TrainingGridView.GetRowCellValue(i, "Company")) && Convert.ToString(TrainingGridView.GetRowCellValue(i, "Company")) == "TTM Healthcare" && DateTime.Parse((TrainingGridView.GetRowCellValue(i, "DateofCourse") == null ? null : Convert.ToString(TrainingGridView.GetRowCellValue(i, "DateofCourse")))) < DateTime.Today.Date && Convert.ToString(TrainingGridView.GetRowCellValue(i, "Status")) == "Waiting")
			{
				keep = true;
			}

			if (!Utilities.DataHelper.IsNullOrEmpty(TrainingGridView.GetRowCellValue(i, colIntRef)))
			{
				if (Utilities.myXero.Invoice.InvoicePaid((TrainingGridView.GetRowCellValue(i, colIntRef) == null ? null : Convert.ToString(TrainingGridView.GetRowCellValue(i, colIntRef)))) == true || Convert.ToString(TrainingGridView.GetRowCellValue(i, colIntRef)) == "Stripe")
				{
					keep = true;
				}

				if (DateTime.Parse((TrainingGridView.GetRowCellValue(i, "DateofCourse") == null ? null : Convert.ToString(TrainingGridView.GetRowCellValue(i, "DateofCourse")))) <= DateTime.Today.Date && Utilities.DataHelper.IsNullOrEmpty(TrainingGridView.GetRowCellValue(i, colIntRef)))
				{
					keep = true;
				}
			}

			if (DateTime.Parse((TrainingGridView.GetRowCellValue(i, "DateofCourse") == null ? null : Convert.ToString(TrainingGridView.GetRowCellValue(i, "DateofCourse")))).Date < DateTime.Today.AddDays(14) && Convert.ToString(TrainingGridView.GetRowCellValue(i, "InstructorName")) == "Not Set")
			{
				keep = true;
			}

			if (keep == false)
			{
				TrainingGridView.DeleteRow(i);
				Application.DoEvents();
			}

		}
		SplashScreenManager.CloseForm(false);
	}

	private void btnCopyCol_ItemClick(object sender, ItemClickEventArgs e)
	{
		DevExpress.XtraGrid.Views.Grid.GridView tempVar = SolutionSettings.VisibleGrid;
		Utilities.CopyCol(ref tempVar);
		SolutionSettings.VisibleGrid = tempVar;
	}

	//    Private Sub btnTest_ItemClick(sender As Object, e As ItemClickEventArgs)
	//        For i = 0 To SolutionSettings.VisibleGrid.DataRowCount - 1
	//            Shifts.CheckShiftAsset(CDate(SolutionSettings.VisibleGrid.GetRowCellValue(i, "DutyDate")),
	//                                   CStr(SolutionSettings.VisibleGrid.GetRowCellValue(i, "Location")))
	//        Next
	//    End Sub

	private void schCourses_VisibleChanged(object sender, EventArgs e)
	{
		try
		{
			if ((int)_calMainView == 0)
			{

				TimeInterval interval = new TimeInterval(schCourses.ActiveView.GetVisibleIntervals().Start, schCourses.ActiveView.GetVisibleIntervals().End);
				TimeIntervalCollection intervals = new TimeIntervalCollection() {interval};
				if (SolutionSettings.WebSiteAccess)
				{
					WebUpcomingTableAdapter.Fill(WebDataSet.WebUpcoming, schCourses.ActiveView.GetVisibleIntervals().Start, schCourses.ActiveView.GetVisibleIntervals().End);
				}

				schWeb.GetAppointments(intervals);
				schWebView.ActiveView.SetVisibleIntervals(intervals);

			}
		}
		catch (Exception ex)
		{
			Utilities.MyError(ex);
		}
		finally
		{

		}
	}

	private void schWebView_VisibleIntervalChanged(object sender, EventArgs e)
	{
		try
		{
			if (_calMainView == (frmMain.CalView)1)
			{

				TimeInterval interval = new TimeInterval(schWebView.ActiveView.GetVisibleIntervals().Start, schWebView.ActiveView.GetVisibleIntervals().End);
				TimeIntervalCollection intervals = new TimeIntervalCollection() {interval};
				SchedulerStorage.GetAppointments(intervals);
				//UpcomingTableAdapter.Fill(MainDataSet.Upcoming, schWebView.ActiveView.GetVisibleIntervals.Start,schWebView.ActiveView.GetVisibleIntervals.End)
				schCourses.ActiveView.SetVisibleIntervals(intervals);
				WebUpcomingTableAdapter.Fill(WebDataSet.WebUpcoming, schCourses.ActiveView.GetVisibleIntervals().Start, schCourses.ActiveView.GetVisibleIntervals().End);

			}
		}
		catch (Exception ex)
		{
			Utilities.MyError(ex);
		}
		finally
		{

		}
	}

	private void btnMedicsAvailability_ItemClick(object sender, ItemClickEventArgs e)
	{
		schCourses.BeginUpdate();
		schCourses.DataStorage = null;
		schCourses.DataStorage = schStorageMedics;
		SolutionSettings.SchedulerSource = DataSource.Medic;
		schCourses.EndUpdate();
		schCourses.RefreshData();
	}

	// Private Sub btnAvailabilityPerson_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnAvailabilityPerson.ItemClick

	// For i As Integer = 0 To AdvBandedGridView1.DataRowCount - 1

	// Using email As New .Utilities.Email
	// Dim b As String

	// b = String.Format("<HEAD><BODY> Hi {0}<br> <br>Can you please send back, by way of return email your availability for the next 7 days.<br>
	//<style>
	//table {{
	// font-family: arial, sans-serif;
	// border-collapse: collapse;
	// width: 100%;
	//}}

	//td, th {{
	// border: 1px solid #dddddd;
	// text-align: left;
	// padding: 6px;
	//}}

	//tr:nth-child(even) {{
	// background-color: #dddddd;
	//}}
	//</style> <!DOCTYPE html><html><head>
	//<body>
	//<table id=""Rows"">
	// <tr>
	// <th>Date</th>
	// <th>Availability</th>
	// </tr>
	// <tr>
	// <td>{1}</td>
	// <td></td>
	// </tr>
	// <tr>
	// <td>{2}</td>
	// <td></td>
	// </tr>
	// <tr>
	// <td>{3}</td>
	// <td></td>
	// </tr>
	// <tr>
	// <td>{4}</td>
	// <td></td>
	// </tr>
	// <tr>
	// <td>{5}</td>
	// <td></td>
	// </tr>
	// <tr>
	// <td>{6}</td>
	// <td></td>
	// </tr>
	// <tr>
	// <td>{7}</td>
	// <td></td>
	// </tr>
	//</table>
	//</body>
	//</html>", .Utilities.SplitbySpaceFirstString(AdvBandedGridView1.GetRowCellValue(i, colInstructorName)), .MyDates.NextMonday.ToString("ddd dd MMMM"), .MyDates.NextMonday.AddDays(1).ToString("ddd dd MMMM"), .MyDates.NextMonday.AddDays(2).ToString("ddd dd MMMM"), .MyDates.NextMonday.AddDays(3).ToString("ddd dd MMMM"), .MyDates.NextMonday.AddDays(4).ToString("ddd dd MMMM"), .MyDates.NextMonday.AddDays(5).ToString("ddd dd MMMM"), .MyDates.NextMonday.AddDays(6).ToString("ddd dd MMMM"))

	// email.SetupEmail(String.Format("Availability from {0}", .MyDates.NextMonday.ToString("ddd dd MMMM")), b, Email.GetDefaultEmail)
	// email.SentTo(AdvBandedGridView1.GetRowCellValue(i, colEmail1).ToString)
	// email.ShowNotification = False
	// email.Send()
	// End Using

	// Next
	// End Sub

	// Private Sub AdvBandedGridView1_ColumnFilterChanged(sender As Object, e As EventArgs) Handles AdvBandedGridView1.ColumnFilterChanged

	// btnAvailabilityPerson.Enabled = AdvBandedGridView1.ActiveFilterString.ToString = "[AC] = True And [Inactive_Med] = False"

	// End Sub

	private void ttScheduler_BeforeShow(object sender, ToolTipControllerShowEventArgs e)
	{
		var controller = sender as ToolTipController;
		var aptViewInfo = controller.ActiveObject as AppointmentViewInfo;
		if (aptViewInfo == null)
		{

			return;
		}

		if (ttScheduler.ToolTipType == ToolTipType.Standard)
		{
			e.IconType = ToolTipIconType.Information;
			e.ToolTip = aptViewInfo.Description;
		}
	}

	private void schCourses_InitAppointmentDisplayText(object sender, AppointmentDisplayTextEventArgs e)
	{
		if (SolutionSettings.SchedulerSource == DataSource.Medic)
		{

			switch (e.Appointment.StatusKey.ToString())
			{

				case "Available":

				break;
				case "Not Available":

				break;
				case "Part-Available":

					e.Text = e.Appointment.Subject + " - " + Personnel.GetAvailabilityNote(e.Appointment.Start.Date, Convert.ToInt32(e.Appointment.CustomFields["PersonID"]));
					break;
			}
		}
	}

	private void RepositoryItemCheckEdit12_Click(object sender, EventArgs e)
	{
		try
		{
			if (!Utilities.DataHelper.IsNullOrEmpty(GovGrid.GetFocusedRowCellValue(colPath2)))
			{
				Utilities.FileHelper.LaunchFile(GovGrid.GetFocusedRowCellValue(colPath2).ToString());
			}
		}
		catch (Exception ex)
		{
			Utilities.MyError(ex);
		}
	}

	private void btnGovFindAll_ItemClick(object sender, ItemClickEventArgs e)
	{
		Utilities.GridHelp.FilterGrid.Filter("Theme", Convert.ToBoolean(GovGrid.GetFocusedRowCellValue("Theme")), true, GovGrid);
	}

	private void TrainingGridView_PrintInitialize(object sender, PrintInitializeEventArgs e)
	{
		var pb = (PrintingSystemBase)e.PrintingSystem;
		pb.PageSettings.Landscape = true;
	}

	private void GovGrid_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
	{
		if (e.Column.FieldName == GridColumn31.FieldName)
		{
			if (Utilities.DataHelper.IsNullOrEmpty(GovGrid.GetListSourceRowCellValue(e.ListSourceRowIndex, "Reference")) == false)
			{
				var itemref = (GovGrid.GetListSourceRowCellValue(e.ListSourceRowIndex, "Reference") == null ? null : Convert.ToString(GovGrid.GetListSourceRowCellValue(e.ListSourceRowIndex, "Reference")));

				if (Utilities.CanSplitString(itemref, "."))
				{
					// (itemref & " " & Utilities.SplitbyString(itemref, "."))
					e.Value = Utilities.SplitbyString(itemref, ".");
				}
				else
				{
					e.Value = "None";
				}
			}
			else
			{
				e.Value = "None";
			}

		}
		else if (e.Column.Name == colParent.Name)
		{

			if (Utilities.DataHelper.IsNullOrEmpty(GovGrid.GetListSourceRowCellValue(e.ListSourceRowIndex, "ID")) == false)
			{
				int itemref = Convert.ToInt32(GovGrid.GetListSourceRowCellValue(e.ListSourceRowIndex, "ID"));
				// (itemref & " " & GovItems.ContainsKey(itemref) & " " & GovItems(itemref))
				if (_govItems.ContainsKey(itemref))
				{

					var k = _govItems[itemref];
					if (_govParentList.ContainsKey(k))
					{
						var v = _govParentList[k];
						// (v & " " & k)
						e.Value = v;
					}
					else
					{
						e.Value = "None";
					}
				}
			}
			else
			{
				e.Value = "None";
			}
		}
	}

	private void btnGovTemplate_ItemClick(object sender, ItemClickEventArgs e)
	{
		try
		{
			Utilities.FileHelper.LaunchFile(SolutionSettings.GovTemplate);
		}
		catch (Exception ex)
		{
			Utilities.MyError(ex);
		}
	}

	private void btnInstAvailability_ItemClick(object sender, ItemClickEventArgs e)
	{
		schCourses.BeginUpdate();
		schCourses.DataStorage = null;

		schCourses.DataStorage = schInstructors;
		SolutionSettings.SchedulerSource = DataSource.Instructors;
		schCourses.EndUpdate();
		schCourses.RefreshData();
	}

	private void puEmail_Popup(object sender, EventArgs e)
	{
		var barManager = new BarManager {Form = this};
		btnReplyWith.ItemLinks.Clear();
		var sql = "Select Name from Email_Template";
		using (MySqlConnection con = new MySqlConnection(BM.Core.MySQlHelper.ConnectionString))
		{
			using (MySqlCommand cmd = new MySqlCommand(sql, con))
			{
				con.Open();
				var reader = cmd.ExecuteReader();

				if (reader.HasRows)
				{
					while (reader.Read())
					{
						if (Utilities.DataHelper.IsNull(reader[0]) == false)
						{
							// (reader(0))
							var btn = new BarButtonItem(barManager, (reader[0] == null ? null : Convert.ToString(reader[0])));
							btnReplyWith.AddItem(btn);
						}
					}
				}
			}
			con.Close();
		}
		barManager.ItemClick += ReplyWith;
	}

	private void ReplyWith(object sender, ItemClickEventArgs e)
	{

		//Dim sql = "Select Body from Email_Template Where Name=@N"
		//Using con As New MySqlConnection(My.Settings.BMConnString)
		//    Using cmd As New MySqlCommand(sql, con)
		//        con.Open()
		//        cmd.Parameters.AddWithValue("@N", e.Item.Caption)

		//        Dim reader = cmd.ExecuteScalar()

		//        If Not DataHelper.IsNullOrEmpty(reader) Then
		//            Dim msg As MailItem
		//            Dim app = New Microsoft.Office.Interop.Outlook.Application
		//            Dim ns = app.GetNamespace("MAPI")

		//            msg = ns.GetItemFromID(grdMyInbox.GetRowCellValue(grdMyInbox.FocusedRowHandle, "ID"))

		//            Dim r As MailItem = msg.Reply()
		//            ' ((reader))
		//            r.HTMLBody = r.HTMLBody.Insert(0, reader.ToString & Environment.NewLine)
		//            r.Display()
		//        End If

		//    End Using
		//    con.Close()
		//End Using
	}

	private void TreeList1_PopupMenuShowing(object sender, DevExpress.XtraTreeList.PopupMenuShowingEventArgs e)
	{
		var list = sender as TreeList;
		//If _
		// (((e.Button = MouseButtons.Right) AndAlso (ModifierKeys = Keys.None)) AndAlso
		// (list.State = TreeListState.Regular)) Then
		Point pt = list.PointToClient(MousePosition);
		TreeListHitInfo info = list.CalcHitInfo(pt);
		if (info.HitInfoType == HitInfoType.Cell)
		{
			//_savedFocused = list.FocusedNode
			list.FocusedNode = info.Node;
			//_needRestoreFocused = True
			if (Convert.IsDBNull(list.FocusedNode.GetValue("ItemRef")))
			{
				btnOpenItem.Enabled = false;
				btnOpenFile.Enabled = false;
			}
			else
			{
				if (Gov.GovHasFile(Convert.ToInt32(list.FocusedNode.GetValue("ItemRef"))) && Networking.NetworkSharesAvailable == true)
				{
					btnOpenFile.Enabled = true;
					btnOpenFileLocation.Enabled = true;
				}
				_treeItemId = Utilities.SafeInt(list.FocusedNode.GetValue("ItemRef"));
				btnOpenItem.Enabled = true;
			}

			btnTaskCompleted.Enabled = list.FocusedNode.GetValue("Type").ToString() == "Task";

			btnShowGrouped.Enabled = list.FocusedNode.GetValue("Type").ToString() == "Policy";
			btnPrintGovList.Enabled = list.FocusedNode.GetValue("Type").ToString() == "Policy";
			puGov.ShowPopup(MousePosition);
		}
		//End If
	}

	private void GovStandardsGridControl_DragLeave(object sender, EventArgs e)
	{
		_dragfromGrid = true;
	}

	private void ChartControl2_BoundDataChanged_1(object sender, EventArgs e)
	{
		if (ChartControl2.Series.Count > 0)
		{

			// (ChartControl2.Series.Count)

			for (var i = 0; i < ChartControl2.Series.Count; i++)
			{
				// (ChartControl2.Series(i).Name)
//INSTANT C# NOTE: The following VB 'Select Case' included either a non-ordinal switch expression or non-ordinal, range-type, or non-constant 'Case' expressions and was converted to C# 'if-else' logic:
//				Select Case ChartControl2.Series(i).Name

//ORIGINAL LINE: Case "High"
				if ((ChartControl2.Series[i].Name) == "High")
				{
					ChartControl2.Series[i].View.Color = Color.Orange;
				}
//ORIGINAL LINE: Case "Low"
				else if ((ChartControl2.Series[i].Name) == "Low")
				{
					ChartControl2.Series[i].View.Color = Color.LightGreen;
				}
//ORIGINAL LINE: Case "Significant"
				else if ((ChartControl2.Series[i].Name) == "Significant")
				{
					ChartControl2.Series[i].View.Color = Color.Red;

				}
//ORIGINAL LINE: Case String.Empty
				else if (string.IsNullOrEmpty((ChartControl2.Series[i].Name)))
				{
					ChartControl2.Series[i].View.Color = Color.Gray;

				}
//ORIGINAL LINE: Case "Moderate"
				else if ((ChartControl2.Series[i].Name) == "Moderate")
				{
					ChartControl2.Series[i].View.Color = Color.Yellow;

				}
//ORIGINAL LINE: Case Else
				else
				{
					// (ChartControl2.Series(i).Name.Length)
					ChartControl2.Series[i].View.Color = Color.Pink;
				}

			}
		}
	}

	private void BarEditItem7_EditValueChanged(object sender, EventArgs e)
	{
		_govGridColor = false;
		//RemoveHandler GovGrid.CustomDrawGroupRow, AddressOf .Utilities.GridHelp.CustomDrawMyGroupRed
		if (Convert.ToString(BarEditItem7.EditValue) == "CHKS NA-NU")
		{
			GovGrid.ActiveFilterString = "[Body] = 'CHKS' And [Status] = 'Not Applicable' And [Kocked] = False";
		}
		else if (Convert.ToString(BarEditItem7.EditValue) == "CHKS Parent View")
		{
			_govGridColor = true;
			//AddHandler GovGrid.CustomDrawGroupRow, AddressOf .Utilities.GridHelp.CustomDrawMyGroupRed
			colParent.GroupIndex = 0;
			GovGrid.ActiveFilterString = "[Body] = 'CHKS' And [Status] = 'Applicable'";
		}
		else
		{
			GovGrid.ActiveFilterString = string.Empty;
		}
	}

	private void btnImportInvoices_ItemClick(object sender, ItemClickEventArgs e)
	{
		frmInvoice_Import frm = new frmInvoice_Import();
		frm.Show(this);
	}

	private void TreeList1_DragObjectStart(object sender, DevExpress.XtraTreeList.DragObjectStartEventArgs e)
	{
		_dragfromGrid = false;
	}

	private void frmMain_Shown(object sender, EventArgs e)
	{
		Utilities.ScreenHelper.HelpMe(this);

		var themeString = SolutionSettings.LookupPersonalOption("Theme");

		if (Utilities.FileHelper.IsValidJson(themeString))
		{

			SolutionSettings.CurrentUser.myTheme = (BM.Theme)JsonConvert.DeserializeObject<Theme>(themeString);

		}
		else
		{
			SolutionSettings.CurrentUser.myTheme = new Theme
			{
				Compact = true,
				SkinName = "WXI",
				Palette = "Clearness"
			};
			SolutionSettings.SetPersonalOption("Theme", JsonConvert.SerializeObject(SolutionSettings.CurrentUser.myTheme, Newtonsoft.Json.Formatting.None));

		}


		if (SolutionSettings.CurrentUser.myTheme.Compact)
		{

			UserLookAndFeel.ForceCompactUIMode(true, true);
			WindowsFormsSettings.CompactUIMode = DefaultBoolean.True;
		}

		if (Utilities.DataHelper.IsNullOrEmpty(SolutionSettings.CurrentUser.myTheme.Palette))
		{


			UserLookAndFeel.Default.SetSkinStyle(SolutionSettings.CurrentUser.myTheme.SkinName);

		}
		else
		{

			UserLookAndFeel.Default.SetSkinStyle(SolutionSettings.CurrentUser.myTheme.SkinName, SolutionSettings.CurrentUser.myTheme.Palette);

		}


		Debug.Print(UserLookAndFeel.Default.ActiveSkinName + " " + UserLookAndFeel.Default.ActiveSvgPaletteName + " " + (int)UserLookAndFeel.Default.CompactUIMode + " " + (int)WindowsFormsSettings.CompactUIMode);


		LoadGridRulesFormat();
		//Dim o = .SolutionSettings.ReadFromRegistry("HKEY_CURRENT_USER\Software\Medicore\Main", "ScreenStart")

		//If .Utilities.DataHelper.IsNullOrEmpty(o) Then
		// VisibleScreen = Screens.MyHome
		//Else

		// For Each bar As NavBarGroup In NavBarControl1.Groups
		// If bar.ItemLinks.Any(Function(x) x.ItemName = o) Then
		// bar.ItemLinks.Group.Expanded = True
		// Dim b = bar.ItemLinks.Where(Function(x) x.ItemName = o)
		// b(0).PerformClick()
		// End If
		// Next
		//End If
		TileView1.Appearance.ItemNormal.BackColor = SolutionSettings.Colours.NotSet;
		//DevExpress.Data.Filtering.CriteriaOperator.GetCustomFunction(Utilities.GridHelp.IsInPastFunction.FunctionName)
		//Utilities.GridHelp.IsInPastFunction.Register()

		if (SolutionSettings.DebugMode == true)
		{
			Utilities.ShowToast("Debug Mode Enabled", "Business Manager is currently in Debug Mode. Performance may be negatively affected.");
		}
		Utilities.StopTaskBarAssistant();
		RepositoryItemLookUpEdit6.DataSource = Personnel.Data.GetPeople();
	}

	private void btn100Percent_ItemClick(object sender, ItemClickEventArgs e)
	{
		Gov.FullPercent(Convert.ToInt32(GovGrid.GetRowCellValue(GovGrid.FocusedRowHandle, "ID")));
		RefreshMain(false, "Main Refresh - 100%");
	}

	private void puGov_BeforePopup(object sender, CancelEventArgs e)
	{
		// ("Stop")
		Timer1.Stop();
	}

	private void puGov_CloseUp(object sender, EventArgs e)
	{
		// ("Start")
		Timer1.Start();
	}

	private void nvMyDashBoard_LinkClicked(object sender, NavBarLinkEventArgs e)
	{
		frmDashboard frm = new frmDashboard();
		frm.Show(this);
	}

	private void nvVehicles_LinkClicked(object sender, NavBarLinkEventArgs e)
	{
		frmVehicles frm = new frmVehicles();
		frm.Show(this);
	}

	private void btnTaskCompleted_ItemClick(object sender, ItemClickEventArgs e)
	{
		General.TaskCompleted(Convert.ToInt32(TreeList1.FocusedNode.GetValue("ID")));
		RefreshMain(false, "Task Completed");
	}

	private void btnOpenFileLocation_ItemClick(object sender, ItemClickEventArgs e)
	{
		Gov.ViewGovFilePath(Utilities.SafeInt(TreeList1.FocusedNode.GetValue("ItemRef")));
	}

	private void btnFlaggedReport_ItemClick(object sender, ItemClickEventArgs e)
	{
		_han = (IOverlaySplashScreenHandle)Utilities.ShowProgressPanel(this);
		repFlagIssues rpt = new repFlagIssues();
		rpt.Start.Value = new DateTime(2020, 1, 1);
		rpt.EndDate.Value = new DateTime(2021, 1, 1);

		// Dim sql = "Select Count(ID) from Shifts Where DutyDate is Between @A and @B"

		rpt.Start.Visible = false;
		rpt.EndDate.Visible = false;
		rpt.ShiftCount.Value = Shifts.GetShiftCount(new DateTime(2018, 1, 1), new DateTime(2019, 1, 1));
		rpt.ShiftCount.Visible = false;
		rpt.PCRCount.Value = Shifts.GetRecordCount(new DateTime(2018, 1, 1), new DateTime(2019, 1, 1));
		rpt.PCRCount.Visible = false;
		ReportPrintTool printTool = new ReportPrintTool(rpt);
		printTool.ShowRibbonPreview();
		Utilities.CloseProgressPanel(_han);
	}

	private void nvPersonnel_LinkClicked(object sender, NavBarLinkEventArgs e)
	{
		MoveScreen(e.Link, Screens.Personnel, null);
	}

	private void TileView1_ItemClick(object sender, TileViewItemClickEventArgs e)
	{

		var view = sender as TileView;
		Point pt = view.GridControl.PointToClient(System.Windows.Forms.Cursor.Position);
		TileViewHitInfo hitInfo = view.CalcHitInfo(pt);
		if (hitInfo.InItem)
		{

			if (hitInfo.ItemInfo != null)
			{
				_han = (IOverlaySplashScreenHandle)Utilities.ShowProgressPanel(this);
				frmNotes frm = new frmNotes(this);
				frm.LoadDetails(Convert.ToInt32(hitInfo.ItemInfo.Item.Elements[2].Text));
				frm.Show(this);
				Utilities.CloseProgressPanel(_han);
			}

		}
	}

	private void NvTaskList_LinkClicked(object sender, NavBarLinkEventArgs e)
	{
		MoveScreen(e.Link, Screens.TaskList, GridView2);
	}

	private void BarButtonItem30_ItemClick(object sender, ItemClickEventArgs e)
	{
		frmTask_List_Details frm = new frmTask_List_Details(this);
		frm.LoadDetails(TaskList.AddTask());
		frm.Show(this);
	}

	private void GridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
	{
		if (e.Column.FieldName == "ID")
		{
			frmTask_List_Details frm = new frmTask_List_Details(this);
			frm.LoadDetails(Convert.ToInt32(e.CellValue));
			frm.Show(this);
		}
	}

	private void GridControl3_Click(object sender, EventArgs e)
	{
	}

	private void btnValidateFiles_ItemClick(object sender, ItemClickEventArgs e)
	{
		_han = (IOverlaySplashScreenHandle)Utilities.ShowProgressPanel(this);
		for (var i = 0; i < GovGrid.DataRowCount; i++)
		{
			if (Convert.ToBoolean(GovGrid.IsRowVisible(i)))
			{
				Gov.ValidateFile(Convert.ToInt32(GovGrid.GetRowCellValue(i, "ID")));
			}
		}
		Utilities.CloseProgressPanel(_han);
	}

	private void btnWebImport_ItemClick(object sender, ItemClickEventArgs e)
	{

		Task.Run(() =>
		{
			var i = Course.Web.ImportWebStudents();
			//("No" & i)
			Utilities.ShowAlert(this, i + "Students Imported", "Web Students Imported");
		});
	}

	private void nvProjects_LinkClicked(object sender, NavBarLinkEventArgs e)
	{
		MoveScreen(e.Link, Screens.Projects, null);
	}

	private void BarButtonItem31_ItemClick(object sender, ItemClickEventArgs e)
	{
		frmProcess frm = new frmProcess();
		frm.Show(this);
	}

	private void ClinicalGridView_CustomDrawGroupRow(object sender, RowObjectCustomDrawEventArgs e)
	{
		object val = ClinicalGridView.GetGroupRowValue(e.RowHandle);
		if (Utilities.DataHelper.IsNullOrEmpty(val) || val.ToString().Length == 0)
		{
			//Debug.Print(val.ToString)
			var info = (GridGroupRowInfo)e.Info;
			info.GroupText = "None";
		}
	}

	private async void btnCleanGPS_ItemClickAsync(object sender, ItemClickEventArgs e)
	{

		Utilities.StartTaskBarAssistant(this);
		int r = 0;
		//Dim ts = TaskScheduler.FromCurrentSynchronizationContext
		try
		{
			await Task.Run(() =>
			{
				r = General.CleanGPS().Result;
			});

			// Debug.Print(r)

			Utilities.ShowToast("GPS Records Cleaned", r.ToString("N0", CultureInfo.InvariantCulture) + " records over 8 days have been deleted.");
		}
		catch (Exception ex)
		{

			Utilities.MyError(ex);
		}
		finally
		{
			Utilities.StopTaskBarAssistant();
		}
	}

	private void nvReportCentre_LinkClicked_1(object sender, NavBarLinkEventArgs e)
	{
		frmAnalytics frm = new frmAnalytics();
		frm.Show(this);
	}

	private void GridView10_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
	{
		//Dim rect = e.Bounds

		if (e.Column.FieldName == "Status")
		{
			if (Utilities.SafeString(e.CellValue) == "Current")
			{
				Utilities.GridHelp.DrawRoundRectangle(e.Cache, SolutionSettings.Colours.ButtonGreen, e.Bounds);
				e.Appearance.ForeColor = Color.White;
			}
			else
			{
				Utilities.GridHelp.DrawRoundRectangle(e.Cache, SolutionSettings.Colours.ButtonRed, e.Bounds);
				e.Appearance.ForeColor = Color.White;
			}
		}
	}

	private void GovGrid_CustomDrawGroupRow(object sender, RowObjectCustomDrawEventArgs e)
	{

		if (_govGridColor == true)
		{
			var info = e.Info as GridGroupRowInfo;
			// (GovGrid.GetGroupSummaryText(e.RowHandle))
			if (GovGrid.GetGroupSummaryText(e.RowHandle).Contains("AVG 100%") == false)
			{

				//Dim quantity As Integer = Convert.ToInt32(view.GetGroupRowValue(e.RowHandle, info.Column))
				//Dim colorName As String = getColorName(quantity)
				info.Appearance.BackColor = Color.Red;
				info.Appearance.ForeColor = Color.White;
			}
			else
			{
				info.Appearance.BackColor = Color.ForestGreen;
				info.Appearance.ForeColor = Color.White;

			}
		}
	}

	private void TrainingGridView_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
	{
		if (e.Column.FieldName == "Status")
		{
			switch (e.CellValue)
			{


				case "Cert Ready":
					Utilities.GridHelp.DrawRoundRectangle(e.Cache, SolutionSettings.Colours.ButtonGreen, e.Bounds);
					e.Appearance.ForeColor = Color.White;


					break;
				case "Paperwork Ready":
					Utilities.GridHelp.DrawRoundRectangle(e.Cache, Color.SkyBlue, e.Bounds);
					e.Appearance.ForeColor = Color.Black;

					break;
			}
		}
	}

	private void btnFlag_Add_ItemClick(object sender, ItemClickEventArgs e)
	{
		if (XtraMessageBox.Show("Do you want to create a new Issue", "Create Issue", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
		{
			frmFlagged_Details frm = new frmFlagged_Details();
			frm.LoadDetails(Flagged.AddFlag());
			frm.Show(this);

		}
	}

	private void ClinicalGridView_ShowFilterPopupDate(object sender, DevExpress.XtraGrid.Views.Grid.FilterPopupDateEventArgs e)
	{
		Utilities.GridHelp.DatePopupFilter(e);
	}

	private void grdFlagged_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
	{
		if (e.Column.FieldName == "Status")
		{

			if (Convert.ToString(e.CellValue) == "Open")
			{
				// Dim rect = e.Bounds
				Utilities.GridHelp.DrawRoundRectangle(e.Cache, SolutionSettings.Colours.ButtonRed, e.Bounds);
				e.Appearance.ForeColor = Color.White;
			}
		}
	}

	private void btnRiskRecategorise_ItemClick(object sender, ItemClickEventArgs e)
	{

		for (var i = 0; i < GridView11.DataRowCount; i++)
		{
			string c = string.Empty;
//INSTANT C# NOTE: The following VB 'Select Case' included either a non-ordinal switch expression or non-ordinal, range-type, or non-constant 'Case' expressions and was converted to C# 'if-else' logic:
//			Select Case Decimal.ToInt32(CDec(GridView11.GetRowCellValue(i, colRiskScore)))
//ORIGINAL LINE: Case 0 To 3
			if (decimal.ToInt32(Convert.ToDecimal(GridView11.GetRowCellValue(i, colRiskScore))) >= 0 && decimal.ToInt32(Convert.ToDecimal(GridView11.GetRowCellValue(i, colRiskScore))) <= 3)
			{
				c = "Low";
			}
//ORIGINAL LINE: Case 4 To 6
			else if (decimal.ToInt32(Convert.ToDecimal(GridView11.GetRowCellValue(i, colRiskScore))) >= 4 && decimal.ToInt32(Convert.ToDecimal(GridView11.GetRowCellValue(i, colRiskScore))) <= 6)
			{
				c = "Moderate";
			}
//ORIGINAL LINE: Case 8 To 12
			else if (decimal.ToInt32(Convert.ToDecimal(GridView11.GetRowCellValue(i, colRiskScore))) >= 8 && decimal.ToInt32(Convert.ToDecimal(GridView11.GetRowCellValue(i, colRiskScore))) <= 12)
			{
				c = "Significant";
			}
//ORIGINAL LINE: Case 15 To 25
			else if (decimal.ToInt32(Convert.ToDecimal(GridView11.GetRowCellValue(i, colRiskScore))) >= 15 && decimal.ToInt32(Convert.ToDecimal(GridView11.GetRowCellValue(i, colRiskScore))) <= 25)
			{
				c = "High";
			}

			Risk.UpdateRiskClass(Convert.ToInt32(GridView11.GetRowCellValue(i, "ID")), c);

		}

		RefreshMain(false, "Main Refresh - Risk Calc");
	}

	private void GridView10_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
	{
		try
		{
		}
		catch (Exception ex)
		{
			Utilities.MyError(ex);
		}
	}

	private void RibbonGalleryBarItem2_GalleryItemClick(object sender, GalleryItemClickEventArgs e)
	{
		try
		{
			BM.Area.Document.setDocumentStatus(Convert.ToInt32(GridView10.GetFocusedRowCellValue("ID")), e.Item.Caption);
			RefreshMain(true, "Main Refresh - Ribbon Gallery Press");
		}
		catch (Exception ex)
		{
			Utilities.MyError(ex);
		}
	}

	private void nvQuality_LinkClicked_1(object sender, NavBarLinkEventArgs e)
	{
		MoveScreen(e.Link, Screens.Quality, null);
	}

	private void rbnViewGallery_GalleryItemClick(object sender, GalleryItemClickEventArgs e)
	{
		try
		{

			switch (e.Item.Caption)
			{
				case "PHECC":
					//TrainingGridView.ActiveFilterString = "[Cert] = 'PHECC' And [DateofCourse] > #2021-02-02# And [Status] In ('Cancelled', 'Cert Ready', 'Certified', 'On-Hold')"

					GridView grid = TrainingGridView;
					grid.BeginDataUpdate();
					grid.ClearColumnsFilter();
					var operands = new CriteriaOperator[]
					{
						new BinaryOperator("DateofCourse", DateTime.Today.AddMonths(- 6), BinaryOperatorType.Greater),
						new BinaryOperator("Cert", "PHECC", BinaryOperatorType.Equal),
						new BinaryOperator("Status", "Cancelled", BinaryOperatorType.NotEqual),
						new BinaryOperator("Status", "Waiting", BinaryOperatorType.NotEqual),
						new BinaryOperator("Status", "Deferred", BinaryOperatorType.NotEqual)
					};
					string filterString = (new GroupOperator(GroupOperatorType.And, operands)).ToString();
					ColumnFilterInfo info = new ColumnFilterInfo(filterString, "PHECC Filter");
					// info.fil
					grid.Columns["Status"].FilterInfo = info;

					//Debug.Print(info.DisplayText)
					grid.BeginSort();
					try
					{
						grid.ClearSorting();
						// grid.Columns.Item("Course").SortMode = ColumnSortMode.Custom
						//grid.Columns.Item("Course").SortOrder = ColumnSortOrder.Descending
						grid.Columns["DateofCourse"].SortMode = ColumnSortMode.Custom;
						grid.Columns["DateofCourse"].SortOrder = ColumnSortOrder.Descending;
					}
					finally
					{
						grid.EndSort();
						grid.EndDataUpdate();
					}

					break;
				case "IHF":
					TrainingGridView.ActiveFilterString = "[Cert] = 'IHF' And [DateofCourse] > #2021-02-02# And [Status] In ('Cancelled', 'Cert Ready', 'Certified', 'On-Hold')";
					//TrainingGridView.ActiveFilter.DisplayText = "as"
					break;
			}
		}
		catch (Exception ex)
		{
			Utilities.MyError(ex);
		}
	}

	private void BtnCheckInvoice_ItemClick(object sender, ItemClickEventArgs e)
	{
		Utilities.ScreenWait(true, "Checking Invoice...");
		Utilities.myXero.Invoice.GetInvoiceStatus(Utilities.InputHelper.InputBox("Invoice Number", "Check Invoice"));
		Utilities.ScreenWait(false);
	}

	private void btnSendMattermost_ItemClick(object sender, ItemClickEventArgs e)
	{
		try
		{
			DateTime dt = default(DateTime);
			StringBuilder msg = new StringBuilder();

			for (var i = 0; i < ClinicalGridView.DataRowCount; i++)
			{
				// Debug.Print(ClinicalGridView.GetRowCellValue(i, colMedicID.FieldName))
				//Debug.Print(RepositoryItemLookUpEdit6.GetDisplayText(ClinicalGridView.GetRowCellValue(i, colMedicID.FieldName)))
				if (i == 0)
				{
					dt = Convert.ToDateTime(ClinicalGridView.GetRowCellValue(i, colDutyDate.FieldName));
				}

				if (DateTime.Parse(Convert.ToString(ClinicalGridView.GetRowCellValue(i, colDutyDate.FieldName))) != dt)
				{
					XtraMessageBox.Show("All the dates must be the same to send to mattermost.", "Not Possible", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					msg.Clear();
					return;
				}

			}

			msg.Append("### Crew Setup for " + dt.ToShortDateString() + Environment.NewLine);
			msg.Append("|Name|Location|Start|" + Environment.NewLine);
			msg.Append("|----|----|----|" + Environment.NewLine);

			for (var i = 0; i < ClinicalGridView.DataRowCount; i++)
			{

				msg.Append(string.Format("|{0}|{1}|{2}|" + Environment.NewLine, RepositoryItemLookUpEdit6.GetDisplayText(ClinicalGridView.GetRowCellValue(i, colMedicID.FieldName)), ClinicalGridView.GetRowCellValue(i, colLocation.FieldName), Utilities.SafeDate(ClinicalGridView.GetRowCellValue(i, colStart.FieldName)).ToShortTimeString()));

			}
			CommunicationHelper.SendMatterMost(msg.ToString(), SolutionSettings.LookupOption("MatterMostDashBoard"), "dashboard-notifications");
			msg.Clear();
			Utilities.ShowToast("Message Sent.", "The crew setup has been sent to Mattermost.");
		}
		catch (Exception ex)
		{
			Utilities.MyError(ex);
		}
	}

 private void btnValidateShifts_ItemClick(object sender, ItemClickEventArgs e)
 {
		try
		{
			_inValidatedShifts.Clear();
			List<int> weeks = new List<int>();
			for (var i = 0; i < ClinicalGridView.DataRowCount; i++)
			{
				if (weeks.Count == 0)
				{
					weeks.Add(Convert.ToInt32(ClinicalGridView.GetRowCellValue(i, "Week")));
				}
				// Debug.Print(ClinicalGridView.GetRowCellValue(i, "ID"))
				if (weeks.Contains(Convert.ToInt32(ClinicalGridView.GetRowCellValue(i, "Week"))))
				{
					weeks.Add(Convert.ToInt32(ClinicalGridView.GetRowCellValue(i, "Week")));
				}
				else
				{
					//Debug.Print("Not Integer" & ClinicalGridView.GetRowCellValue(i, "Week"))
					XtraMessageBox.Show("You can only perform this operation when the shifts are group by week and only a single week is visible." + Environment.NewLine + Environment.NewLine + "Reoranise the shifts to match the requirements and try again.", "Not Possible", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}
			}

			_inValidatedShifts.AddRange(Personnel.ValidateWeeklyHours(Convert.ToInt32(ClinicalGridView.GetRowCellValue(0, "Week")), Convert.ToInt32(ClinicalGridView.GetRowCellValue(0, "Year"))));

			if (_inValidatedShifts.Count > 0)
			{
				Utilities.ShowToast("Shift Validation Failed.", _inValidatedShifts.Count + " shifts have failed validation for no times, or overlapping shifts.");

				if (ClinicalGridView.FormatRules.Contains(ClinicalGridView.FormatRules[Utilities.GridRules.GeneralColour( ClinicalGridView.Columns["Validate"], FormatCondition.Equal, Convert.ToInt32(true), Color.DarkRed, Color.White).Name]) == false)
				{
					ClinicalGridView.FormatRules.Add(Utilities.GridRules.GeneralColour( ClinicalGridView.Columns["Validate"], FormatCondition.Equal, Convert.ToInt32(true), Color.DarkRed, Color.White));
					//ClinicalGridView.FormatRules.RemoveAt(i)

				}

				ClinicalGridView.RefreshData();
			}
			else
			{
				Utilities.ShowToast("Shift Validation Passed.", "All shifts have passed validation for the selected week.");
			}

			Debug.Print(ClinicalGridView.FilterPanelText);
		}
		catch (Exception ex)
		{
			Utilities.MyError(ex);
		}
	}

	private void ClinicalGridView_CustomUnboundColumnData(dynamic sender, CustomColumnDataEventArgs e)
	{
		if (!e.IsSetData)
		{

			//If e.Column.FieldName = "Client" Then


			//    e.Value = SafeString(sender.GetListSourceRowCellValue(e.ListSourceRowIndex, "Client"))
			//End If


			if (e.Column.FieldName == "Validate")
			{

				var shiftId = (ClinicalGridView.GetListSourceRowCellValue(e.ListSourceRowIndex, "ID") == null ? null : Convert.ToString(ClinicalGridView.GetListSourceRowCellValue(e.ListSourceRowIndex, "ID")));
				//Debug.Print(importedList.Contains(ref))
				//Debug.Print(CallsGrid.GetListSourceRowCellValue(e.ListSourceRowIndex, "incident_status").ToString = "register")
				if (_inValidatedShifts.Contains(Convert.ToInt32(shiftId)))
				{

					e.Value = true;
					//#importedList(CallsGrid.GetListSourceRowCellValue(e.ListSourceRowIndex, "incident_id"))
				}
				else
				{
					e.Value = false;
				}
			}

			Calendar calendar = new GregorianCalendar();
			object calDate = sender.GetListSourceRowCellValue(e.ListSourceRowIndex, "DutyDate");
			if (calDate == null || calDate == DBNull.Value)
			{
			}
			else
			{
				// Debug.Print(e.Column.Name)
				DateTime dt = DateTime.Parse(calDate.ToString());
				if (e.Column.FieldName == "Week")
				{
					e.Value = Setup.GetIsoWeekOfYear(dt);
				}
				if (e.Column.FieldName == "Month")
				{
					e.Value = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(calendar.GetMonth(dt));
				}
				if (e.Column.FieldName == "Day")
				{
					e.Value = calendar.GetDayOfMonth(dt);
				}
				if (e.Column.FieldName == "Year")
				{
					e.Value = calendar.GetYear(dt);
				}


			}
		}
	}

	private void btnPersonValidate_ItemClick(object sender, ItemClickEventArgs e)
	{
		try
		{
			Utilities.StartTaskBarAssistant(this);
			_inValidatedShifts.Clear();
			//Dim weeks As New List(Of Integer)
			//For i As Integer = 0 To ClinicalGridView.DataRowCount - 1
			//    If weeks.Count = 0 Then
			//        weeks.Add(ClinicalGridView.GetRowCellValue(i, "Week"))
			//    End If
			//    ' Debug.Print(ClinicalGridView.GetRowCellValue(i, "ID"))
			//    If weeks.Contains(ClinicalGridView.GetRowCellValue(i, "Week")) Then
			//        weeks.Add(ClinicalGridView.GetRowCellValue(i, "Week"))
			//    Else
			//        'Debug.Print("Not Integer" & ClinicalGridView.GetRowCellValue(i, "Week"))
			//        XtraMessageBox.Show("You can only perform this operation when the shifts are group by week and only a single week is visible." & Environment.NewLine & Environment.NewLine & "Reoranise the shifts to match the requirements and try again.", "Not Possible", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			//        Exit Sub
			//    End If
			//Next

			_inValidatedShifts.AddRange(Personnel.ValidateMedic12Weeks(Convert.ToInt32(ClinicalGridView.GetFocusedRowCellValue("MedicID")), General.GetIsoWeekOfYear(DateTime.Today), DateTime.Today.Year));
			if (_inValidatedShifts.Count > 0)
			{

				ClinicalGridView.BeginDataUpdate();
				btnShowAll.PerformClick();
				Utilities.GridHelp.FilterGrid.Filter("MedicID", ClinicalGridView.GetRowCellDisplayText(ClinicalGridView.FocusedRowHandle, "MedicID"), BinaryOperatorType.Equal, true, ClinicalGridView);
				ClinicalGridView.EndDataUpdate();
				Utilities.DebugPrintList(_inValidatedShifts);
				Utilities.ShowToast("Shift Validation Failed.", _inValidatedShifts.Count + " shifts for " + ClinicalGridView.GetRowCellDisplayText(ClinicalGridView.FocusedRowHandle, "MedicID") + " have failed validation for no times, or overlappting shifts.");

				if (ClinicalGridView.FormatRules.Contains(ClinicalGridView.FormatRules[Utilities.GridRules.GeneralColour( ClinicalGridView.Columns["Validate"], FormatCondition.Equal, Convert.ToInt32(true), Color.DarkRed, Color.White).Name]) == false)
				{
					ClinicalGridView.FormatRules.Add(Utilities.GridRules.GeneralColour( ClinicalGridView.Columns["Validate"], FormatCondition.Equal, Convert.ToInt32(true), Color.DarkRed, Color.White));
					//ClinicalGridView.FormatRules.RemoveAt(i)

				}
				ClinicalGridView.Columns["Validate"].GroupIndex = 0;
				ClinicalGridView.Columns["Validate"].SortOrder = ColumnSortOrder.Descending;
				ClinicalGridView.ExpandAllGroups();

				//ClinicalGridView.RefreshData()
			}
			else
			{
				Utilities.ShowToast("Shift Validation Passed.", "All shifts for " + ClinicalGridView.GetRowCellDisplayText(ClinicalGridView.FocusedRowHandle, "MedicID") + " have passed validation.");
			}

			// Debug.Print(ClinicalGridView.FilterPanelText)
		}
		catch (Exception ex)
		{
			Utilities.MyError(ex);
		}
		finally
		{
			Utilities.StopTaskBarAssistant();
		}
	}

	private void brLocale_ItemDoubleClick(object sender, ItemClickEventArgs e)
	{
		if (SolutionSettings.CurrentUser.MultiTenant == true)
		{
			Cursor = Cursors.WaitCursor;

			var barManager = new BarManager {Form = this};
			barManager.Items.Clear();
			PopupMenu pu = new PopupMenu(barManager);
			foreach (var t in Security.TenantList())
			{
				pu.ItemLinks.Add(new BarButtonItem(barManager, t));
			}
			pu.ShowPopup(System.Windows.Forms.Cursor.Position);
			Cursor = Cursors.Default;
			barManager.ItemClick += ChangeTenant;
		}
	}

	private void ChangeTenant(object sender, ItemClickEventArgs e)
	{
		Security.LogEvent($"Current User Locale Changed from {SolutionSettings.CurrentUser.TenantLocale} to {e.Item.Caption}", Security.LogLevel.Info);
		SolutionSettings.CurrentUser.TenantLocale = e.Item.Caption;
		SolutionSettings.loadVariables();
		SolutionSettings.CurrentUser.ReloadSettings();
		FillVariables_Text();
		Utilities.ShowToast("Locale Changed", "Your locale has been changed to: " + SolutionSettings.CurrentUser.TenantLocale);
		RefreshMain(true, "Main Refresh Tenant Change");
	}

	private void btnNewLead_ItemClick(object sender, ItemClickEventArgs e)
	{
		frmLead_Details frm = new frmLead_Details();
		frm.LoadDetails(Leads.AddLead());
		frm.Show();
	}

	private void LeadsGrid_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
	{
		if (e.Column.FieldName == "Stage")
		{
			switch (Utilities.SafeString(e.CellValue))
			{


				case "Closed - Won":
					Utilities.GridHelp.DrawRoundRectangle(e.Cache, SolutionSettings.Colours.ButtonGreen, e.Bounds);
					e.Appearance.ForeColor = Color.White;
					break;
				case "Closed - Lost":
					Utilities.GridHelp.DrawRoundRectangle(e.Cache, Color.DarkGray, e.Bounds);
					e.Appearance.ForeColor = Color.Black;


					break;
				case "Potential Sale":
					Utilities.GridHelp.DrawRoundRectangle(e.Cache, Color.LightSkyBlue, e.Bounds);
					e.Appearance.ForeColor = Color.Black;


					break;
				case "Expected Booking":
					Utilities.GridHelp.DrawRoundRectangle(e.Cache, Color.LightGreen, e.Bounds);
					e.Appearance.ForeColor = Color.Black;

					break;
				case "Deferred":
					Utilities.GridHelp.DrawRoundRectangle(e.Cache, Color.Orange, e.Bounds);
					e.Appearance.ForeColor = Color.Black;
					break;
			}
		}
	}

	private void btnRiskRegister_ItemClick(object sender, ItemClickEventArgs e)
	{
		rptRiskRegister rpt = new rptRiskRegister();
		rpt.Name = "Risk Register";
		ReportPrintTool r = new ReportPrintTool(rpt);
		r.ShowRibbonPreview();
	}

	private void BarButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
	{
		frmCreateBill frm = new frmCreateBill();
		frm.Show();
	}

	private void BtnColourGroupRow_ItemClick(object sender, ItemClickEventArgs e)
	{
		var visibleGrid = SolutionSettings.VisibleGrid;
		visibleGrid.OptionsLayout.StoreFormatRules = true;

		if (SolutionSettings.ColouredGrid.Contains(visibleGrid.Name))
		{
			//RemoveHandler VisibleGrid.RowStyle, AddressOf GridHelp.ColourGroupRows
			visibleGrid.CustomDrawGroupRow -= Utilities.GridHelp.CustomDrawMyGroup;
			SolutionSettings.ColouredGrid.Remove(visibleGrid.Name);
			visibleGrid.OptionsView.EnableAppearanceOddRow = true;
			visibleGrid.OptionsView.EnableAppearanceEvenRow = false;
			visibleGrid.RestoreLayoutFromRegistry(string.Format("Software\\Medicore\\Dashboard\\{0}\\", visibleGrid.Name));
		}
		else
		{
			visibleGrid.SaveLayoutToRegistry(string.Format("Software\\Medicore\\Dashboard\\{0}\\", visibleGrid.Name));
			visibleGrid.FormatRules.Clear();
			//AddHandler VisibleGrid.RowStyle, AddressOf GridHelp.ColourGroupRows
			visibleGrid.CustomDrawGroupRow += Utilities.GridHelp.CustomDrawMyGroup;
			SolutionSettings.ColouredGrid.Add(visibleGrid.Name);
			visibleGrid.OptionsView.EnableAppearanceOddRow = false;
			visibleGrid.OptionsView.EnableAppearanceEvenRow = false;

		}
	}

	private void btnBugFile_ItemClick(object sender, ItemClickEventArgs e)
	{
		try
		{
			Utilities.Jira.FileJira(this);
		}
		catch (Exception ex)
		{
			Utilities.MyError(ex);
		}
	}

	private void ChartControl3_BoundDataChanged(object sender, EventArgs e)
	{
		if (ChartControl3.Series.Count > 0)
		{

			// (ChartControl2.Series.Count)

			for (var i = 0; i < ChartControl3.Series.Count; i++)
			{

				switch (ChartControl3.Series[i].Name)
				{

					case "Level 1":
						ChartControl3.Series[i].View.Color = Color.LightGray;
						break;
					case "Level 2":
						ChartControl3.Series[i].View.Color = Color.Yellow;
						break;
					case "Level 3":
						ChartControl3.Series[i].View.Color = Color.Red;

						break;
					case "Level 0":
						ChartControl3.Series[i].View.Color = Color.LightBlue;
						break;
				}

			}
		}
	}

	private void TreeList1_MouseDown(object sender, MouseEventArgs e)
	{
		_dragfromGrid = false;
	}

	private void ClinicalGridView_QueryCustomFunctions(object sender, DevExpress.XtraGrid.Views.Grid.CustomFunctionEventArgs e)
	{

		if (e.PropertyType == typeof(DateTime))
		{
			e.Add(Utilities.GridHelp.IsInPastFunction.FunctionName);
		}
	}
}