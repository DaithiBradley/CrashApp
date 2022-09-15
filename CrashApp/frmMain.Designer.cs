using System.Collections;
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
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Tile;
using DevExpress.XtraGrid.Views.Tile.ViewInfo;
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

//INSTANT C# NOTE: Formerly VB project-level imports:
using DevExpress;
using System.Collections.Generic;
using System.Diagnostics;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Xml.Linq;
using System;

using System.ComponentModel;
using System.Timers;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraNavBar;
using DevExpress.XtraTab;


public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
{
	/// <summary>
	/// Required designer variable.
	/// </summary>
	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	//Required by the Windows Form Designer
	private IContainer components;

#region Windows Form Designer generated code

	/// <summary>
	/// Required method for Designer support - do not modify
	/// the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent()
	{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem3 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem3 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip4 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem4 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem4 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip5 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem5 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem5 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip6 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem6 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem6 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip7 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem7 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip8 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem8 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip9 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem9 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem7 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Skins.SkinPaddingEdges skinPaddingEdges1 = new DevExpress.Skins.SkinPaddingEdges();
            DevExpress.XtraBars.Ribbon.GalleryItemGroup galleryItemGroup1 = new DevExpress.XtraBars.Ribbon.GalleryItemGroup();
            DevExpress.XtraBars.Ribbon.GalleryItem galleryItem1 = new DevExpress.XtraBars.Ribbon.GalleryItem();
            DevExpress.Utils.SuperToolTip superToolTip10 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem8 = new DevExpress.Utils.ToolTipItem();
            DevExpress.XtraBars.Ribbon.GalleryItem galleryItem2 = new DevExpress.XtraBars.Ribbon.GalleryItem();
            DevExpress.Utils.SuperToolTip superToolTip11 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem9 = new DevExpress.Utils.ToolTipItem();
            DevExpress.XtraBars.Ribbon.GalleryItem galleryItem3 = new DevExpress.XtraBars.Ribbon.GalleryItem();
            DevExpress.Utils.SuperToolTip superToolTip12 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem10 = new DevExpress.Utils.ToolTipItem();
            DevExpress.XtraBars.Ribbon.GalleryItem galleryItem4 = new DevExpress.XtraBars.Ribbon.GalleryItem();
            DevExpress.Utils.SuperToolTip superToolTip13 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem11 = new DevExpress.Utils.ToolTipItem();
            DevExpress.XtraBars.Ribbon.GalleryItemGroup galleryItemGroup2 = new DevExpress.XtraBars.Ribbon.GalleryItemGroup();
            DevExpress.XtraBars.Ribbon.GalleryItem galleryItem5 = new DevExpress.XtraBars.Ribbon.GalleryItem();
            DevExpress.Utils.SuperToolTip superToolTip14 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem12 = new DevExpress.Utils.ToolTipItem();
            DevExpress.XtraBars.Ribbon.GalleryItem galleryItem6 = new DevExpress.XtraBars.Ribbon.GalleryItem();
            DevExpress.Utils.SuperToolTip superToolTip15 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem13 = new DevExpress.Utils.ToolTipItem();
            DevExpress.XtraBars.Ribbon.GalleryItem galleryItem7 = new DevExpress.XtraBars.Ribbon.GalleryItem();
            DevExpress.Utils.SuperToolTip superToolTip16 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem14 = new DevExpress.Utils.ToolTipItem();
            DevExpress.XtraBars.Ribbon.GalleryItem galleryItem8 = new DevExpress.XtraBars.Ribbon.GalleryItem();
            DevExpress.Utils.SuperToolTip superToolTip17 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem15 = new DevExpress.Utils.ToolTipItem();
            DevExpress.XtraBars.Ribbon.GalleryItem galleryItem9 = new DevExpress.XtraBars.Ribbon.GalleryItem();
            DevExpress.Utils.SuperToolTip superToolTip18 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem16 = new DevExpress.Utils.ToolTipItem();
            DevExpress.XtraBars.Ribbon.GalleryItem galleryItem10 = new DevExpress.XtraBars.Ribbon.GalleryItem();
            DevExpress.Utils.SuperToolTip superToolTip19 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem17 = new DevExpress.Utils.ToolTipItem();
            DevExpress.XtraBars.Ribbon.GalleryItem galleryItem11 = new DevExpress.XtraBars.Ribbon.GalleryItem();
            DevExpress.Utils.SuperToolTip superToolTip20 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem18 = new DevExpress.Utils.ToolTipItem();
            DevExpress.XtraBars.Ribbon.GalleryItem galleryItem12 = new DevExpress.XtraBars.Ribbon.GalleryItem();
            DevExpress.Utils.SuperToolTip superToolTip21 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem19 = new DevExpress.Utils.ToolTipItem();
            DevExpress.XtraBars.Ribbon.GalleryItemGroup galleryItemGroup3 = new DevExpress.XtraBars.Ribbon.GalleryItemGroup();
            DevExpress.XtraBars.Ribbon.GalleryItem galleryItem13 = new DevExpress.XtraBars.Ribbon.GalleryItem();
            DevExpress.Utils.SuperToolTip superToolTip22 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem20 = new DevExpress.Utils.ToolTipItem();
            DevExpress.XtraBars.Ribbon.GalleryItem galleryItem14 = new DevExpress.XtraBars.Ribbon.GalleryItem();
            DevExpress.Utils.SuperToolTip superToolTip23 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem21 = new DevExpress.Utils.ToolTipItem();
            DevExpress.XtraBars.Ribbon.GalleryItem galleryItem15 = new DevExpress.XtraBars.Ribbon.GalleryItem();
            DevExpress.Utils.SuperToolTip superToolTip24 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem22 = new DevExpress.Utils.ToolTipItem();
            DevExpress.XtraBars.Ribbon.GalleryItem galleryItem16 = new DevExpress.XtraBars.Ribbon.GalleryItem();
            DevExpress.Utils.SuperToolTip superToolTip25 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem23 = new DevExpress.Utils.ToolTipItem();
            DevExpress.XtraBars.Ribbon.GalleryItem galleryItem17 = new DevExpress.XtraBars.Ribbon.GalleryItem();
            DevExpress.Utils.SuperToolTip superToolTip26 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem24 = new DevExpress.Utils.ToolTipItem();
            DevExpress.XtraBars.Ribbon.GalleryItem galleryItem18 = new DevExpress.XtraBars.Ribbon.GalleryItem();
            DevExpress.Utils.SuperToolTip superToolTip27 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem25 = new DevExpress.Utils.ToolTipItem();
            DevExpress.XtraBars.Ribbon.GalleryItem galleryItem19 = new DevExpress.XtraBars.Ribbon.GalleryItem();
            DevExpress.Utils.SuperToolTip superToolTip28 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem26 = new DevExpress.Utils.ToolTipItem();
            DevExpress.XtraBars.Ribbon.GalleryItem galleryItem20 = new DevExpress.XtraBars.Ribbon.GalleryItem();
            DevExpress.Utils.SuperToolTip superToolTip29 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem27 = new DevExpress.Utils.ToolTipItem();
            DevExpress.XtraBars.Ribbon.GalleryItem galleryItem21 = new DevExpress.XtraBars.Ribbon.GalleryItem();
            DevExpress.Utils.SuperToolTip superToolTip30 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem28 = new DevExpress.Utils.ToolTipItem();
            DevExpress.XtraBars.Ribbon.GalleryItem galleryItem22 = new DevExpress.XtraBars.Ribbon.GalleryItem();
            DevExpress.Utils.SuperToolTip superToolTip31 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem29 = new DevExpress.Utils.ToolTipItem();
            DevExpress.XtraBars.Ribbon.GalleryItem galleryItem23 = new DevExpress.XtraBars.Ribbon.GalleryItem();
            DevExpress.Utils.SuperToolTip superToolTip32 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem30 = new DevExpress.Utils.ToolTipItem();
            DevExpress.XtraBars.Ribbon.GalleryItem galleryItem24 = new DevExpress.XtraBars.Ribbon.GalleryItem();
            DevExpress.Utils.SuperToolTip superToolTip33 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem31 = new DevExpress.Utils.ToolTipItem();
            DevExpress.XtraBars.Ribbon.GalleryItem galleryItem25 = new DevExpress.XtraBars.Ribbon.GalleryItem();
            DevExpress.Utils.SuperToolTip superToolTip34 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem32 = new DevExpress.Utils.ToolTipItem();
            DevExpress.XtraBars.Ribbon.GalleryItem galleryItem26 = new DevExpress.XtraBars.Ribbon.GalleryItem();
            DevExpress.Utils.SuperToolTip superToolTip35 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem33 = new DevExpress.Utils.ToolTipItem();
            DevExpress.XtraBars.Ribbon.GalleryItem galleryItem27 = new DevExpress.XtraBars.Ribbon.GalleryItem();
            DevExpress.Utils.SuperToolTip superToolTip36 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem34 = new DevExpress.Utils.ToolTipItem();
            DevExpress.XtraBars.Ribbon.GalleryItemGroup galleryItemGroup4 = new DevExpress.XtraBars.Ribbon.GalleryItemGroup();
            DevExpress.XtraBars.Ribbon.GalleryItem galleryItem28 = new DevExpress.XtraBars.Ribbon.GalleryItem();
            DevExpress.Utils.SuperToolTip superToolTip37 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem35 = new DevExpress.Utils.ToolTipItem();
            DevExpress.XtraBars.Ribbon.GalleryItem galleryItem29 = new DevExpress.XtraBars.Ribbon.GalleryItem();
            DevExpress.Utils.SuperToolTip superToolTip38 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem36 = new DevExpress.Utils.ToolTipItem();
            DevExpress.XtraBars.Ribbon.GalleryItem galleryItem30 = new DevExpress.XtraBars.Ribbon.GalleryItem();
            DevExpress.Utils.SuperToolTip superToolTip39 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem37 = new DevExpress.Utils.ToolTipItem();
            DevExpress.XtraBars.Ribbon.GalleryItem galleryItem31 = new DevExpress.XtraBars.Ribbon.GalleryItem();
            DevExpress.Utils.SuperToolTip superToolTip40 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem38 = new DevExpress.Utils.ToolTipItem();
            DevExpress.XtraBars.Ribbon.GalleryItem galleryItem32 = new DevExpress.XtraBars.Ribbon.GalleryItem();
            DevExpress.Utils.SuperToolTip superToolTip41 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem39 = new DevExpress.Utils.ToolTipItem();
            DevExpress.XtraBars.Ribbon.GalleryItem galleryItem33 = new DevExpress.XtraBars.Ribbon.GalleryItem();
            DevExpress.Utils.SuperToolTip superToolTip42 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem40 = new DevExpress.Utils.ToolTipItem();
            DevExpress.XtraBars.Ribbon.GalleryItem galleryItem34 = new DevExpress.XtraBars.Ribbon.GalleryItem();
            DevExpress.Utils.SuperToolTip superToolTip43 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem41 = new DevExpress.Utils.ToolTipItem();
            DevExpress.XtraBars.Ribbon.GalleryItem galleryItem35 = new DevExpress.XtraBars.Ribbon.GalleryItem();
            DevExpress.Utils.SuperToolTip superToolTip44 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem42 = new DevExpress.Utils.ToolTipItem();
            DevExpress.XtraBars.Ribbon.GalleryItem galleryItem36 = new DevExpress.XtraBars.Ribbon.GalleryItem();
            DevExpress.Utils.SuperToolTip superToolTip45 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem43 = new DevExpress.Utils.ToolTipItem();
            DevExpress.XtraBars.Ribbon.GalleryItem galleryItem37 = new DevExpress.XtraBars.Ribbon.GalleryItem();
            DevExpress.Utils.SuperToolTip superToolTip46 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem44 = new DevExpress.Utils.ToolTipItem();
            DevExpress.XtraBars.Ribbon.GalleryItem galleryItem38 = new DevExpress.XtraBars.Ribbon.GalleryItem();
            DevExpress.Utils.SuperToolTip superToolTip47 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem45 = new DevExpress.Utils.ToolTipItem();
            DevExpress.XtraBars.Ribbon.GalleryItem galleryItem39 = new DevExpress.XtraBars.Ribbon.GalleryItem();
            DevExpress.Utils.SuperToolTip superToolTip48 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem46 = new DevExpress.Utils.ToolTipItem();
            DevExpress.XtraBars.Ribbon.GalleryItem galleryItem40 = new DevExpress.XtraBars.Ribbon.GalleryItem();
            DevExpress.Utils.SuperToolTip superToolTip49 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem47 = new DevExpress.Utils.ToolTipItem();
            DevExpress.XtraBars.Ribbon.GalleryItemGroup galleryItemGroup5 = new DevExpress.XtraBars.Ribbon.GalleryItemGroup();
            DevExpress.XtraBars.Ribbon.GalleryItem galleryItem41 = new DevExpress.XtraBars.Ribbon.GalleryItem();
            DevExpress.Utils.SuperToolTip superToolTip50 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem48 = new DevExpress.Utils.ToolTipItem();
            DevExpress.XtraBars.Ribbon.GalleryItem galleryItem42 = new DevExpress.XtraBars.Ribbon.GalleryItem();
            DevExpress.Utils.SuperToolTip superToolTip51 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem49 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip52 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem50 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip53 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem10 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem51 = new DevExpress.Utils.ToolTipItem();
            DevExpress.XtraBars.Ribbon.ReduceOperation reduceOperation1 = new DevExpress.XtraBars.Ribbon.ReduceOperation();
            DevExpress.XtraScheduler.TimeRuler timeRuler1 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraScheduler.TimeRuler timeRuler2 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraScheduler.TimeRuler timeRuler3 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue1 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraScheduler.TimeRuler timeRuler4 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraScheduler.TimeRuler timeRuler5 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraScheduler.TimeRuler timeRuler6 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule2 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue2 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule3 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue3 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule4 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression1 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule5 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue4 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule6 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression2 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule7 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue5 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraTreeList.StyleFormatConditions.TreeListFormatRule treeListFormatRule1 = new DevExpress.XtraTreeList.StyleFormatConditions.TreeListFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue6 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule8 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleDataBar formatConditionRuleDataBar1 = new DevExpress.XtraEditors.FormatConditionRuleDataBar();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule9 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue7 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraEditors.TableLayout.TableColumnDefinition tableColumnDefinition1 = new DevExpress.XtraEditors.TableLayout.TableColumnDefinition();
            DevExpress.XtraEditors.TableLayout.TableColumnDefinition tableColumnDefinition2 = new DevExpress.XtraEditors.TableLayout.TableColumnDefinition();
            DevExpress.XtraEditors.TableLayout.TableColumnDefinition tableColumnDefinition3 = new DevExpress.XtraEditors.TableLayout.TableColumnDefinition();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition1 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition2 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition3 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            DevExpress.XtraEditors.TableLayout.TableSpan tableSpan1 = new DevExpress.XtraEditors.TableLayout.TableSpan();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement1 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement2 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement3 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraCharts.CrosshairFreePosition crosshairFreePosition1 = new DevExpress.XtraCharts.CrosshairFreePosition();
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.StackedBarSeriesView stackedBarSeriesView1 = new DevExpress.XtraCharts.StackedBarSeriesView();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.PieSeriesView pieSeriesView1 = new DevExpress.XtraCharts.PieSeriesView();
            DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.PieSeriesLabel pieSeriesLabel1 = new DevExpress.XtraCharts.PieSeriesLabel();
            DevExpress.XtraCharts.PieSeriesView pieSeriesView2 = new DevExpress.XtraCharts.PieSeriesView();
            DevExpress.XtraCharts.SeriesTitle seriesTitle1 = new DevExpress.XtraCharts.SeriesTitle();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule10 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleIconSet formatConditionRuleIconSet1 = new DevExpress.XtraEditors.FormatConditionRuleIconSet();
            DevExpress.XtraEditors.FormatConditionIconSet formatConditionIconSet1 = new DevExpress.XtraEditors.FormatConditionIconSet();
            DevExpress.XtraEditors.FormatConditionIconSetIcon formatConditionIconSetIcon1 = new DevExpress.XtraEditors.FormatConditionIconSetIcon();
            DevExpress.XtraEditors.FormatConditionIconSetIcon formatConditionIconSetIcon2 = new DevExpress.XtraEditors.FormatConditionIconSetIcon();
            DevExpress.XtraEditors.FormatConditionIconSetIcon formatConditionIconSetIcon3 = new DevExpress.XtraEditors.FormatConditionIconSetIcon();
            DevExpress.XtraCharts.Series series3 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.PieSeriesView pieSeriesView3 = new DevExpress.XtraCharts.PieSeriesView();
            DevExpress.XtraCharts.XYDiagram xyDiagram2 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.SeriesKeyColorColorizer seriesKeyColorColorizer1 = new DevExpress.XtraCharts.SeriesKeyColorColorizer();
            DevExpress.XtraCharts.StackedBarSeriesView stackedBarSeriesView2 = new DevExpress.XtraCharts.StackedBarSeriesView();
            DevExpress.XtraCharts.XYDiagram xyDiagram3 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.StackedBarSeriesLabel stackedBarSeriesLabel1 = new DevExpress.XtraCharts.StackedBarSeriesLabel();
            DevExpress.XtraCharts.StackedBarSeriesView stackedBarSeriesView3 = new DevExpress.XtraCharts.StackedBarSeriesView();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule11 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue8 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule12 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue9 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule13 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue10 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraBars.Ribbon.GalleryItemGroup galleryItemGroup6 = new DevExpress.XtraBars.Ribbon.GalleryItemGroup();
            this.colSeen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInstructor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPath = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTableSort = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCompleted = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colPercent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RepositoryItemCheckEdit11 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colTitle = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.RepositoryItemHyperLinkEdit15 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.colCreatedBy2 = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.colID5 = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.NCRBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.MainDataSet = new BM.MainDataSet();
            this.colLevel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repFlaggedCategory = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.svgFlagged = new DevExpress.Utils.SvgImageCollection(this.components);
            this.colStatus7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RepositoryItemCheckEdit8 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repShowInactive = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.RepositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repByCourse = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.RepositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.RepositoryItemLookUpEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.RepositoryItemProgressBar1 = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.RepositoryItemTextEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.RepositoryItemDuration1 = new DevExpress.XtraScheduler.UI.RepositoryItemDuration();
            this.RepositoryItemZoomTrackBar1 = new DevExpress.XtraEditors.Repository.RepositoryItemZoomTrackBar();
            this.RepositoryItemSpinEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.RepositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.RepositoryItemHyperLinkEdit6 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.RepositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.RepositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.RepositoryItemHyperLinkEdit19 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.RepositoryItemCheckEdit19 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.RepositoryItemHyperLinkEdit7 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.RepositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.RepositoryItemCheckEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.RepositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.PersonnellBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.RepositoryItemHyperLinkEdit14 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.RepositoryItemLookUpEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.RepositoryItemImageComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.imgGov = new DevExpress.Utils.ImageCollection(this.components);
            this.RepositoryItemCheckEdit12 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.RepositoryItemCheckEdit13 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.RepositoryItemCheckEdit16 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.RepositoryItemLookUpEdit5 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.RepositoryItemRichTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit();
            this.RepositoryItemHyperLinkEdit9 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.RepositoryItemImageComboBox3 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.grdImageList = new DevExpress.Utils.ImageCollection(this.components);
            this.RepositoryItemCheckEdit18 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.RepositoryItemHyperLinkEdit13 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.RepositoryItemHyperLinkEdit17 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.RepositoryItemHyperLinkEdit18 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.RepositoryItemCheckEdit20 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.RepositoryItemTextEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colCreatedTime = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.imgEmail = new DevExpress.Utils.ImageCollection(this.components);
            this.RibbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.ApplicationMenu1 = new DevExpress.XtraBars.Ribbon.ApplicationMenu(this.components);
            this.btnOptionsView = new DevExpress.XtraBars.BarButtonItem();
            this.btnAuditLog = new DevExpress.XtraBars.BarButtonItem();
            this.btnCleanGPS = new DevExpress.XtraBars.BarButtonItem();
            this.btnLogOff = new DevExpress.XtraBars.BarButtonItem();
            this.btnRestart = new DevExpress.XtraBars.BarButtonItem();
            this.btnBugFile = new DevExpress.XtraBars.BarButtonItem();
            this.btnNewCourse = new DevExpress.XtraBars.BarButtonItem();
            this.btnEditCourse = new DevExpress.XtraBars.BarButtonItem();
            this.btnMultiAddCourse = new DevExpress.XtraBars.BarButtonItem();
            this.btnMultiSelect = new DevExpress.XtraBars.BarButtonItem();
            this.btnBatchCerts = new DevExpress.XtraBars.BarButtonItem();
            this.btnBatchUpdate = new DevExpress.XtraBars.BarButtonItem();
            this.btnBatchExportCourse = new DevExpress.XtraBars.BarButtonItem();
            this.btnFindStudents = new DevExpress.XtraBars.BarButtonItem();
            this.btnImportStudents = new DevExpress.XtraBars.BarButtonItem();
            this.BtnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.btnOpenCourses = new DevExpress.XtraBars.BarButtonItem();
            this.puOpen = new DevExpress.XtraBars.PopupMenu(this.components);
            this.btnPastOpen = new DevExpress.XtraBars.BarButtonItem();
            this.btnNotInvoiced = new DevExpress.XtraBars.BarButtonItem();
            this.btnPastNotInvoiced = new DevExpress.XtraBars.BarButtonItem();
            this.btnPaid = new DevExpress.XtraBars.BarButtonItem();
            this.btnNoPaperworkShow = new DevExpress.XtraBars.BarButtonItem();
            this.BtnAllCourses = new DevExpress.XtraBars.BarButtonItem();
            this.btnNotSet = new DevExpress.XtraBars.BarButtonItem();
            this.btnFlagged = new DevExpress.XtraBars.BarButtonItem();
            this.btnYesterday = new DevExpress.XtraBars.BarButtonItem();
            this.btnToday = new DevExpress.XtraBars.BarButtonItem();
            this.btnTomorrow = new DevExpress.XtraBars.BarButtonItem();
            this.btnLastWeek = new DevExpress.XtraBars.BarButtonItem();
            this.btnNextWeek = new DevExpress.XtraBars.BarButtonItem();
            this.btnThisWeek = new DevExpress.XtraBars.BarButtonItem();
            this.btnLastMonth = new DevExpress.XtraBars.BarButtonItem();
            this.btnThisMonth = new DevExpress.XtraBars.BarButtonItem();
            this.btnNextMonth = new DevExpress.XtraBars.BarButtonItem();
            this.btnTrainingReturns = new DevExpress.XtraBars.BarButtonItem();
            this.btnStats = new DevExpress.XtraBars.BarButtonItem();
            this.brUser = new DevExpress.XtraBars.BarStaticItem();
            this.brIP = new DevExpress.XtraBars.BarStaticItem();
            this.brLoggedUsers = new DevExpress.XtraBars.BarStaticItem();
            this.brSecurity = new DevExpress.XtraBars.BarStaticItem();
            this.brSecure = new DevExpress.XtraBars.BarStaticItem();
            this.brShares = new DevExpress.XtraBars.BarStaticItem();
            this.brVersion = new DevExpress.XtraBars.BarStaticItem();
            this.brWebAccess = new DevExpress.XtraBars.BarStaticItem();
            this.btnClinicalAdd = new DevExpress.XtraBars.BarSubItem();
            this.btnAddSingleShift = new DevExpress.XtraBars.BarButtonItem();
            this.btnShiftTemplate = new DevExpress.XtraBars.BarButtonItem();
            this.btnClinicalAudits = new DevExpress.XtraBars.BarButtonItem();
            this.btnClinicalReports = new DevExpress.XtraBars.BarButtonItem();
            this.btnViewbyMedics = new DevExpress.XtraBars.BarButtonItem();
            this.btnViewbyInstructors = new DevExpress.XtraBars.BarButtonItem();
            this.BarEditItem1 = new DevExpress.XtraBars.BarEditItem();
            this.BarSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.btnShowInactive = new DevExpress.XtraBars.BarEditItem();
            this.BarEditItem2 = new DevExpress.XtraBars.BarEditItem();
            this.brByCourse = new DevExpress.XtraBars.BarEditItem();
            this.btnResetPersonnelView = new DevExpress.XtraBars.BarButtonItem();
            this.btnClinicalStats = new DevExpress.XtraBars.BarButtonItem();
            this.btnCopy = new DevExpress.XtraBars.BarButtonItem();
            this.btnOpenThis = new DevExpress.XtraBars.BarButtonItem();
            this.btnAllThis = new DevExpress.XtraBars.BarButtonItem();
            this.btnClearFilter = new DevExpress.XtraBars.BarButtonItem();
            this.btnCompanyReport = new DevExpress.XtraBars.BarSubItem();
            this.btn7DayReport = new DevExpress.XtraBars.BarButtonItem();
            this.btnSummaryReport = new DevExpress.XtraBars.BarButtonItem();
            this.btnDetailReport = new DevExpress.XtraBars.BarButtonItem();
            this.btnTempReport = new DevExpress.XtraBars.BarButtonItem();
            this.BarSubItem3 = new DevExpress.XtraBars.BarSubItem();
            this.btnThisMonthReport = new DevExpress.XtraBars.BarButtonItem();
            this.btnMonthReportLast = new DevExpress.XtraBars.BarButtonItem();
            this.btnMonthReportNext = new DevExpress.XtraBars.BarButtonItem();
            this.btnConvertLead = new DevExpress.XtraBars.BarButtonItem();
            this.btnConvertTask = new DevExpress.XtraBars.BarButtonItem();
            this.brInfo = new DevExpress.XtraBars.BarStaticItem();
            this.btnAddTask = new DevExpress.XtraBars.BarButtonItem();
            this.btnAddLead = new DevExpress.XtraBars.BarButtonItem();
            this.BtnShiftSheets = new DevExpress.XtraBars.BarButtonItem();
            this.btnCourseExpiry = new DevExpress.XtraBars.BarButtonItem();
            this.btnStaffCompliance = new DevExpress.XtraBars.BarButtonItem();
            this.btnGlobalCompliance = new DevExpress.XtraBars.BarButtonItem();
            this.BarEditItem3 = new DevExpress.XtraBars.BarEditItem();
            this.btnShowWeb = new DevExpress.XtraBars.BarButtonItem();
            this.btnAvailability = new DevExpress.XtraBars.BarSubItem();
            this.btnMedicsAvailability = new DevExpress.XtraBars.BarButtonItem();
            this.btnInstAvailability = new DevExpress.XtraBars.BarButtonItem();
            this.btnFilter = new DevExpress.XtraBars.BarSubItem();
            this.btnFilterShift = new DevExpress.XtraBars.BarButtonItem();
            this.btnFilterCourse = new DevExpress.XtraBars.BarButtonItem();
            this.btnFilterMeeting = new DevExpress.XtraBars.BarButtonItem();
            this.btnOpenLeads = new DevExpress.XtraBars.BarButtonItem();
            this.btnNewLead = new DevExpress.XtraBars.BarButtonItem();
            this.btnAllLeads = new DevExpress.XtraBars.BarButtonItem();
            this.btnClosedLost = new DevExpress.XtraBars.BarButtonItem();
            this.btnClosedWon = new DevExpress.XtraBars.BarButtonItem();
            this.btnMyLeads = new DevExpress.XtraBars.BarButtonItem();
            this.BarEditItem4 = new DevExpress.XtraBars.BarEditItem();
            this.btnReport = new DevExpress.XtraBars.BarButtonItem();
            this.btnAddItem = new DevExpress.XtraBars.BarButtonItem();
            this.btnFilterStandards = new DevExpress.XtraBars.BarButtonItem();
            this.btnFilterPolicies = new DevExpress.XtraBars.BarButtonItem();
            this.btnFilterEvidence = new DevExpress.XtraBars.BarButtonItem();
            this.btnFilterKPI = new DevExpress.XtraBars.BarButtonItem();
            this.btnFilterViewAll = new DevExpress.XtraBars.BarButtonItem();
            this.btnExpandAll = new DevExpress.XtraBars.BarButtonItem();
            this.btnCollapseAll = new DevExpress.XtraBars.BarButtonItem();
            this.btnWorkDiary = new DevExpress.XtraBars.BarButtonItem();
            this.btnSortName = new DevExpress.XtraBars.BarButtonItem();
            this.btnSortLocation = new DevExpress.XtraBars.BarButtonItem();
            this.btnMap = new DevExpress.XtraBars.BarButtonItem();
            this.brProgress = new DevExpress.XtraBars.BarEditItem();
            this.btnGridExpand = new DevExpress.XtraBars.BarButtonItem();
            this.btnSanity = new DevExpress.XtraBars.BarButtonItem();
            this.btnFilterTask = new DevExpress.XtraBars.BarButtonItem();
            this.btnFilterLead = new DevExpress.XtraBars.BarButtonItem();
            this.btnFilterEmail = new DevExpress.XtraBars.BarButtonItem();
            this.BarButtonItem9 = new DevExpress.XtraBars.BarButtonItem();
            this.btnOpenGov = new DevExpress.XtraBars.BarButtonItem();
            this.btnRemoveItem = new DevExpress.XtraBars.BarButtonItem();
            this.btnFindReferences = new DevExpress.XtraBars.BarButtonItem();
            this.btnOpenItem = new DevExpress.XtraBars.BarButtonItem();
            this.btnOpenFile = new DevExpress.XtraBars.BarButtonItem();
            this.btnRename = new DevExpress.XtraBars.BarButtonItem();
            this.btnCopyItem = new DevExpress.XtraBars.BarButtonItem();
            this.btnNewSection = new DevExpress.XtraBars.BarButtonItem();
            this.btnRemoveItemGov = new DevExpress.XtraBars.BarButtonItem();
            this.BarEditItem5 = new DevExpress.XtraBars.BarEditItem();
            this.BarSubItem2 = new DevExpress.XtraBars.BarSubItem();
            this.btnAddStandard = new DevExpress.XtraBars.BarButtonItem();
            this.btnAddPolicy = new DevExpress.XtraBars.BarButtonItem();
            this.btnAddLegislation = new DevExpress.XtraBars.BarButtonItem();
            this.btnAddGuideline = new DevExpress.XtraBars.BarButtonItem();
            this.btnAddEvidence = new DevExpress.XtraBars.BarButtonItem();
            this.btnAddKPI = new DevExpress.XtraBars.BarButtonItem();
            this.btnAddGovTask = new DevExpress.XtraBars.BarButtonItem();
            this.BarSubItem4 = new DevExpress.XtraBars.BarSubItem();
            this.btnMoveUp = new DevExpress.XtraBars.BarButtonItem();
            this.btnMoveDown = new DevExpress.XtraBars.BarButtonItem();
            this.BarSubItem5 = new DevExpress.XtraBars.BarSubItem();
            this.btnExpandTree = new DevExpress.XtraBars.BarButtonItem();
            this.btnCollapseTree = new DevExpress.XtraBars.BarButtonItem();
            this.BarButtonItem10 = new DevExpress.XtraBars.BarButtonItem();
            this.BarButtonItem11 = new DevExpress.XtraBars.BarButtonItem();
            this.btnAddNote = new DevExpress.XtraBars.BarButtonItem();
            this.EditAppointmentQueryItem1 = new DevExpress.XtraScheduler.UI.EditAppointmentQueryItem();
            this.EditOccurrenceUICommandItem1 = new DevExpress.XtraScheduler.UI.EditOccurrenceUICommandItem();
            this.EditSeriesUICommandItem1 = new DevExpress.XtraScheduler.UI.EditSeriesUICommandItem();
            this.DeleteAppointmentsItem1 = new DevExpress.XtraScheduler.UI.DeleteAppointmentsItem();
            this.DeleteOccurrenceItem1 = new DevExpress.XtraScheduler.UI.DeleteOccurrenceItem();
            this.DeleteSeriesItem1 = new DevExpress.XtraScheduler.UI.DeleteSeriesItem();
            this.SplitAppointmentItem1 = new DevExpress.XtraScheduler.UI.SplitAppointmentItem();
            this.ChangeAppointmentStatusItem1 = new DevExpress.XtraScheduler.UI.ChangeAppointmentStatusItem();
            this.ChangeAppointmentLabelItem1 = new DevExpress.XtraScheduler.UI.ChangeAppointmentLabelItem();
            this.ToggleRecurrenceItem1 = new DevExpress.XtraScheduler.UI.ToggleRecurrenceItem();
            this.ChangeAppointmentReminderItem1 = new DevExpress.XtraScheduler.UI.ChangeAppointmentReminderItem();
            this.btnAddAppointment = new DevExpress.XtraBars.BarButtonItem();
            this.btnAddDocument = new DevExpress.XtraBars.BarButtonItem();
            this.BarButtonItem13 = new DevExpress.XtraBars.BarButtonItem();
            this.BarButtonItem14 = new DevExpress.XtraBars.BarButtonItem();
            this.BarButtonItem15 = new DevExpress.XtraBars.BarButtonItem();
            this.btnViewOptions = new DevExpress.XtraBars.BarSubItem();
            this.btnViewFooter = new DevExpress.XtraBars.BarButtonItem();
            this.btnViewFilter = new DevExpress.XtraBars.BarButtonItem();
            this.btnFooterFilter = new DevExpress.XtraBars.BarButtonItem();
            this.btnViewFind = new DevExpress.XtraBars.BarButtonItem();
            this.btnHorLines = new DevExpress.XtraBars.BarButtonItem();
            this.btnVerticalLInes = new DevExpress.XtraBars.BarButtonItem();
            this.btnCellMerge = new DevExpress.XtraBars.BarButtonItem();
            this.btnShowGrouped = new DevExpress.XtraBars.BarButtonItem();
            this.btnIndentRow = new DevExpress.XtraBars.BarButtonItem();
            this.btnOddRow = new DevExpress.XtraBars.BarButtonItem();
            this.btnGroupColour = new DevExpress.XtraBars.BarCheckItem();
            this.btnShowGroupSummary = new DevExpress.XtraBars.BarButtonItem();
            this.BtnColourGroupRow = new DevExpress.XtraBars.BarButtonItem();
            this.btnAddInfo = new DevExpress.XtraBars.BarButtonItem();
            this.BarButtonItem18 = new DevExpress.XtraBars.BarButtonItem();
            this.btnForReview = new DevExpress.XtraBars.BarButtonItem();
            this.btnViewOpen = new DevExpress.XtraBars.BarButtonItem();
            this.btnShowAll = new DevExpress.XtraBars.BarButtonItem();
            this.BarListItem1 = new DevExpress.XtraBars.BarListItem();
            this.BarButtonItem19 = new DevExpress.XtraBars.BarButtonItem();
            this.btnGridCollapse = new DevExpress.XtraBars.BarButtonItem();
            this.btnGridExport = new DevExpress.XtraBars.BarSubItem();
            this.btnExportSelected = new DevExpress.XtraBars.BarToggleSwitchItem();
            this.btnGridExportPDF = new DevExpress.XtraBars.BarButtonItem();
            this.btnGridExportCSV = new DevExpress.XtraBars.BarButtonItem();
            this.btnGridExportExcel = new DevExpress.XtraBars.BarButtonItem();
            this.btnGridExportHtml = new DevExpress.XtraBars.BarButtonItem();
            this.BarButtonItem24 = new DevExpress.XtraBars.BarButtonItem();
            this.BarButtonItem26 = new DevExpress.XtraBars.BarButtonItem();
            this.btnGridExportXLXS = new DevExpress.XtraBars.BarButtonItem();
            this.btnGridExportWord = new DevExpress.XtraBars.BarButtonItem();
            this.btnGridPrint = new DevExpress.XtraBars.BarButtonItem();
            this.BarButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.btnCopyValue = new DevExpress.XtraBars.BarButtonItem();
            this.btnCourseCurrent = new DevExpress.XtraBars.BarButtonItem();
            this.btnFilterBy = new DevExpress.XtraBars.BarSubItem();
            this.BarButtonItem20 = new DevExpress.XtraBars.BarButtonItem();
            this.BarSubItem6 = new DevExpress.XtraBars.BarSubItem();
            this.btnPersonClinicalReport = new DevExpress.XtraBars.BarButtonItem();
            this.btnFutureTasks = new DevExpress.XtraBars.BarButtonItem();
            this.btnResetInbox = new DevExpress.XtraBars.BarButtonItem();
            this.btnMedicReminders = new DevExpress.XtraBars.BarButtonItem();
            this.btnInstructorsReminders = new DevExpress.XtraBars.BarButtonItem();
            this.BarButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.BarButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.BarEditItem6 = new DevExpress.XtraBars.BarEditItem();
            this.BarButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            this.BarButtonItem7 = new DevExpress.XtraBars.BarButtonItem();
            this.btnInvoice = new DevExpress.XtraBars.BarButtonItem();
            this.btnMedicsReport = new DevExpress.XtraBars.BarButtonItem();
            this.BarSubItem7 = new DevExpress.XtraBars.BarSubItem();
            this.btnMedicRegister = new DevExpress.XtraBars.BarButtonItem();
            this.btnMedicCompliance = new DevExpress.XtraBars.BarButtonItem();
            this.btnCaptureCopy = new DevExpress.XtraBars.BarButtonItem();
            this.chkCaptureCopy = new DevExpress.XtraBars.BarCheckItem();
            this.btnViewOverview = new DevExpress.XtraBars.BarButtonItem();
            this.btnCasualtySummary = new DevExpress.XtraBars.BarButtonItem();
            this.btnAmbulanceControl = new DevExpress.XtraBars.BarButtonItem();
            this.BarButtonItem22 = new DevExpress.XtraBars.BarButtonItem();
            this.BarButtonItem23 = new DevExpress.XtraBars.BarButtonItem();
            this.btnGovReporting = new DevExpress.XtraBars.BarSubItem();
            this.btnGovReportOverview = new DevExpress.XtraBars.BarButtonItem();
            this.btnGovReportDetails = new DevExpress.XtraBars.BarButtonItem();
            this.btnGovShowApplicable = new DevExpress.XtraBars.BarButtonItem();
            this.br64 = new DevExpress.XtraBars.BarStaticItem();
            this.BarButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.BarSubItem8 = new DevExpress.XtraBars.BarSubItem();
            this.btnGovApplicapable = new DevExpress.XtraBars.BarButtonItem();
            this.btnGovNotApplicable = new DevExpress.XtraBars.BarButtonItem();
            this.btn100Percent = new DevExpress.XtraBars.BarButtonItem();
            this.btnClinicalKPI = new DevExpress.XtraBars.BarButtonItem();
            this.btnBatchImport = new DevExpress.XtraBars.BarButtonItem();
            this.btnGoToToday = new DevExpress.XtraBars.BarButtonItem();
            this.btnZoomIn = new DevExpress.XtraBars.BarButtonItem();
            this.BtnZoomOut = new DevExpress.XtraBars.BarButtonItem();
            this.BarButtonItem27 = new DevExpress.XtraBars.BarButtonItem();
            this.BarButtonItem25 = new DevExpress.XtraBars.BarButtonItem();
            this.btnPhonebook = new DevExpress.XtraBars.BarButtonItem();
            this.btnPrintGovList = new DevExpress.XtraBars.BarButtonItem();
            this.BarToggleSwitchItem1 = new DevExpress.XtraBars.BarToggleSwitchItem();
            this.btnClearTreeFilter = new DevExpress.XtraBars.BarButtonItem();
            this.SkinDropDownButtonItem1 = new DevExpress.XtraBars.SkinDropDownButtonItem();
            this.btnViewGroupStandards = new DevExpress.XtraBars.BarButtonItem();
            this.btnCopyFiles = new DevExpress.XtraBars.BarButtonItem();
            this.btnOpenFolder = new DevExpress.XtraBars.BarButtonItem();
            this.btnCopyStandards = new DevExpress.XtraBars.BarButtonItem();
            this.btnTrainingAction = new DevExpress.XtraBars.BarButtonItem();
            this.btnCopyCol = new DevExpress.XtraBars.BarButtonItem();
            this.BarButtonItem28 = new DevExpress.XtraBars.BarButtonItem();
            this.btnAvailabilityPerson = new DevExpress.XtraBars.BarButtonItem();
            this.SwitchToDayViewItem1 = new DevExpress.XtraScheduler.UI.SwitchToDayViewItem();
            this.SwitchToWorkWeekViewItem1 = new DevExpress.XtraScheduler.UI.SwitchToWorkWeekViewItem();
            this.SwitchToWeekViewItem1 = new DevExpress.XtraScheduler.UI.SwitchToWeekViewItem();
            this.SwitchToFullWeekViewItem1 = new DevExpress.XtraScheduler.UI.SwitchToFullWeekViewItem();
            this.SwitchToMonthViewItem1 = new DevExpress.XtraScheduler.UI.SwitchToMonthViewItem();
            this.SwitchToTimelineViewItem1 = new DevExpress.XtraScheduler.UI.SwitchToTimelineViewItem();
            this.SwitchToGanttViewItem1 = new DevExpress.XtraScheduler.UI.SwitchToGanttViewItem();
            this.SwitchToAgendaViewItem1 = new DevExpress.XtraScheduler.UI.SwitchToAgendaViewItem();
            this.SwitchTimeScalesItem1 = new DevExpress.XtraScheduler.UI.SwitchTimeScalesItem();
            this.ChangeScaleWidthItem1 = new DevExpress.XtraScheduler.UI.ChangeScaleWidthItem();
            this.SwitchTimeScalesCaptionItem1 = new DevExpress.XtraScheduler.UI.SwitchTimeScalesCaptionItem();
            this.SwitchCompressWeekendItem1 = new DevExpress.XtraScheduler.UI.SwitchCompressWeekendItem();
            this.SwitchShowWorkTimeOnlyItem1 = new DevExpress.XtraScheduler.UI.SwitchShowWorkTimeOnlyItem();
            this.SwitchCellsAutoHeightItem1 = new DevExpress.XtraScheduler.UI.SwitchCellsAutoHeightItem();
            this.ChangeSnapToCellsUIItem1 = new DevExpress.XtraScheduler.UI.ChangeSnapToCellsUIItem();
            this.btnGovTemplate = new DevExpress.XtraBars.BarButtonItem();
            this.BarButtonItem8 = new DevExpress.XtraBars.BarButtonItem();
            this.btnReplyWith = new DevExpress.XtraBars.BarSubItem();
            this.btnFlag = new DevExpress.XtraBars.BarButtonItem();
            this.BarEditItem7 = new DevExpress.XtraBars.BarEditItem();
            this.btnImportInvoices = new DevExpress.XtraBars.BarButtonItem();
            this.btnFindAfterDrag = new DevExpress.XtraBars.BarToggleSwitchItem();
            this.btnTaskCompleted = new DevExpress.XtraBars.BarButtonItem();
            this.btnOpenFileLocation = new DevExpress.XtraBars.BarButtonItem();
            this.btnFlaggedReport = new DevExpress.XtraBars.BarButtonItem();
            this.SkinRibbonGalleryBarItem3 = new DevExpress.XtraBars.SkinRibbonGalleryBarItem();
            this.SkinPaletteRibbonGalleryBarItem3 = new DevExpress.XtraBars.SkinPaletteRibbonGalleryBarItem();
            this.BarButtonItem29 = new DevExpress.XtraBars.BarButtonItem();
            this.BarButtonItem30 = new DevExpress.XtraBars.BarButtonItem();
            this.btnValidateFiles = new DevExpress.XtraBars.BarButtonItem();
            this.btnWebImport = new DevExpress.XtraBars.BarButtonItem();
            this.BarButtonItem31 = new DevExpress.XtraBars.BarButtonItem();
            this.btnFlag_Add = new DevExpress.XtraBars.BarButtonItem();
            this.btnRiskRecategorise = new DevExpress.XtraBars.BarButtonItem();
            this.RibbonGalleryBarItem1 = new DevExpress.XtraBars.RibbonGalleryBarItem();
            this.RibbonGalleryBarItem2 = new DevExpress.XtraBars.RibbonGalleryBarItem();
            this.RibbonGalleryBarItem3 = new DevExpress.XtraBars.RibbonGalleryBarItem();
            this.RibbonGalleryBarItem4 = new DevExpress.XtraBars.RibbonGalleryBarItem();
            this.rbnViewGallery = new DevExpress.XtraBars.RibbonGalleryBarItem();
            this.RibbonGalleryBarItem5 = new DevExpress.XtraBars.RibbonGalleryBarItem();
            this.brLocale = new DevExpress.XtraBars.BarStaticItem();
            this.BtnCheckInvoice = new DevExpress.XtraBars.BarButtonItem();
            this.btnSendMattermost = new DevExpress.XtraBars.BarButtonItem();
            this.btnValidateShifts = new DevExpress.XtraBars.BarButtonItem();
            this.btnPersonValidate = new DevExpress.XtraBars.BarButtonItem();
            this.btnRiskRegister = new DevExpress.XtraBars.BarButtonItem();
            this.BarButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.rbnMyHome = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.RibbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.RibbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.RibbonPageGroup20 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.RibbonPageGroup21 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.RibbonPageGroup30 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.RibbonPageGroup33 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.RibbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.RibbonPageGroup18 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.RibbonPageGroup73 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbnTraining = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.RibbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.RibbonPageGroup42 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.RibbonPageGroup55 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.RibbonPageBatchUpdate = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.RibbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.RibbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.RibbonPageGroup7 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.RibbonPageGroup8 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.RibbonPageGroup9 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.RibbonPageGroup10 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.RibbonPageGroup74 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbnPersonnel = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.RibbonPageGroup34 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.RibbonPageGroup19 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.RibbonPageGroup68 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.RibbonPageGroup31 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.RibbonPageGroup32 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.RibbonPageGroup35 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.RibbonPageGroup66 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.RibbonPageGroup71 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.RibbonPageGroup72 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbnClinical = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.RibbonPageGroup11 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.RibbonPageGroup12 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.RibbonPageGroup43 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.RibbonPageGroup56 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.RibbonPageGroup13 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.RibbonPageGroup14 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.RibbonPageGroup15 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.RibbonPageGroup16 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.RibbonPageGroup17 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbnLeads = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.RibbonPageGroup23 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.RibbonPageGroup44 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.RibbonPageGroup22 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.RibbonPageGroup24 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.RibbonPageGroup25 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbnTasks = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.RibbonPageGroup57 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.RibbonPageGroup45 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.RibbonPageGroup58 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbnRisk = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.RibbonPageGroup39 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.RibbonPageGroup47 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.RibbonPageGroup60 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.RibbonPageGroup59 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbnGovernance = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.RibbonPageGroup27 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.RibbonPageGroup28 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.RibbonPageGroup70 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.RibbonPageGroup29 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.RibbonPageGroup48 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.RibbonPageGroup61 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.RibbonPageGroup26 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.RibbonPageGroup69 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.RibbonPageGroup50 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbnDocuments = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.RibbonPageGroup37 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.RibbonPageGroup38 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.RibbonPageGroup49 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.RibbonPageGroup62 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.RibbonPageGroup63 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbnAudit = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.RibbonPageGroup41 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.RibbonPageGroup51 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.RibbonPageGroup64 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.RibbonPageGroup67 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbnContacts = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.RibbonPageGroup53 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.RibbonPageGroup54 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.RibbonPageGroup65 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ViewRibbonPage1 = new DevExpress.XtraScheduler.UI.ViewRibbonPage();
            this.ActiveViewRibbonPageGroup1 = new DevExpress.XtraScheduler.UI.ActiveViewRibbonPageGroup();
            this.TimeScaleRibbonPageGroup1 = new DevExpress.XtraScheduler.UI.TimeScaleRibbonPageGroup();
            this.LayoutRibbonPageGroup1 = new DevExpress.XtraScheduler.UI.LayoutRibbonPageGroup();
            this.rbnFlagged = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.RibbonPageGroup36 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.RibbonPageGroup52 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbnNotes = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.RibbonPageGroup40 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbnTaskList = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.RibbonPageGroup46 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.RibbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.PersonnellDataSet = new PersonnellDataSet();
            this.GridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RepositoryItemCheckEdit10 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.LeadListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.LeadsDataSet = new LeadsDataSet();
            this.RepositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.RepositoryItemCheckEdit9 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.ttTree = new DevExpress.Utils.ToolTipController(this.components);
            this.RibbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.NavBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.nvMyDashBoard = new DevExpress.XtraNavBar.NavBarItem();
            this.nvHome = new DevExpress.XtraNavBar.NavBarItem();
            this.nvCalendar = new DevExpress.XtraNavBar.NavBarItem();
            this.nvNotes = new DevExpress.XtraNavBar.NavBarItem();
            this.nvTraining = new DevExpress.XtraNavBar.NavBarItem();
            this.nvClinical = new DevExpress.XtraNavBar.NavBarItem();
            this.nvPersonnel = new DevExpress.XtraNavBar.NavBarItem();
            this.nvEquipment = new DevExpress.XtraNavBar.NavBarItem();
            this.nvVehicles = new DevExpress.XtraNavBar.NavBarItem();
            this.nvReportCentre = new DevExpress.XtraNavBar.NavBarItem();
            this.nvSales = new DevExpress.XtraNavBar.NavBarItem();
            this.nvDocuments = new DevExpress.XtraNavBar.NavBarItem();
            this.nvAudit = new DevExpress.XtraNavBar.NavBarItem();
            this.nvRisk = new DevExpress.XtraNavBar.NavBarItem();
            this.nvGovernance = new DevExpress.XtraNavBar.NavBarItem();
            this.schWeb = new DevExpress.XtraScheduler.SchedulerStorage(this.components);
            this.WebUpcomingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.WebDataSet = new WebDataSet();
            this.SchedulerStorage = new DevExpress.XtraScheduler.SchedulerStorage(this.components);
            this.UpcomingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PersonnellBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.ActivitiesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SystemUsersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BusinessNotesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SystemTasksBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TaskDataSet = new TaskDataSet();
            this.TasksBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.UpcomingTableAdapter = new BM.MainDataSetTableAdapters.UpcomingTableAdapter();
            this.PersonnellTableAdapter = new BM.MainDataSetTableAdapters.PersonnellTableAdapter();
            this.PersonnellTableAdapter1 = new PersonnellDataSetTableAdapters.PersonnellTableAdapter();
            this.colID2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colInstructorName = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colCompany1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colEmail = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colHomePhone = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colMobilePhone = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colAttachments = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colClinical_Grade = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.PeopleByCourseTableAdapter1 = new PersonnellDataSetTableAdapters.PeopleByCourseTableAdapter();
            this.PeopleByCourseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bgwCourseUpdate = new System.ComponentModel.BackgroundWorker();
            this.puGrid = new DevExpress.XtraBars.PopupMenu(this.components);
            this.puEmail = new DevExpress.XtraBars.PopupMenu(this.components);
            this.Timer1 = new System.Windows.Forms.Timer(this.components);
            this.ClinicalDataSet = new BM.Clinical.ClinicalData();
            this.WebUpcomingTableAdapter = new WebDataSetTableAdapters.WebUpcomingTableAdapter();
            this.ActivitiesTableAdapter = new LeadsDataSetTableAdapters.ActivitiesTableAdapter();
            this.TableAdapterManager = new LeadsDataSetTableAdapters.TableAdapterManager();
            this.Lead_ListTableAdapter = new LeadsDataSetTableAdapters.Lead_ListTableAdapter();
            this.LeadsByCourseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.LeadsByCourseTableAdapter = new LeadsDataSetTableAdapters.LeadsByCourseTableAdapter();
            this.SystemUsersTableAdapter = new BM.MainDataSetTableAdapters.SystemUsersTableAdapter();
            this.GovTableAdapter = new GovDataSetTableAdapters.GovTableAdapter();
            this.GovStandardsTableAdapter = new GovDataSetTableAdapters.GovStandardsTableAdapter();
            this.TableAdapterManager1 = new GovDataSetTableAdapters.TableAdapterManager();
            this.BusinessNotesTableAdapter = new BM.MainDataSetTableAdapters.BusinessNotesTableAdapter();
            this.TableAdapterManager2 = new BM.MainDataSetTableAdapters.TableAdapterManager();
            this.bgRefresh = new System.ComponentModel.BackgroundWorker();
            this.bgwShiftSheetEmails = new System.ComponentModel.BackgroundWorker();
            this.bgwStudentsEmail = new System.ComponentModel.BackgroundWorker();
            this.bgwGlobalCompliance = new System.ComponentModel.BackgroundWorker();
            this.BackgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.Popup = new DevExpress.XtraBars.PopupMenu(this.components);
            this.puGov = new DevExpress.XtraBars.PopupMenu(this.components);
            this.TasksTableAdapter = new TaskDataSetTableAdapters.TasksTableAdapter();
            this.SystemTasksTableAdapter = new TaskDataSetTableAdapters.SystemTasksTableAdapter();
            this.SchedulerBarController1 = new DevExpress.XtraScheduler.UI.SchedulerBarController(this.components);
            this.schWebView = new DevExpress.XtraScheduler.SchedulerControl();
            this.ttScheduler = new DevExpress.Utils.ToolTipController(this.components);
            this.puScheduler = new DevExpress.XtraBars.PopupMenu(this.components);
            this.ttTraining = new DevExpress.Utils.ToolTipController(this.components);
            this.ttPersonnell = new DevExpress.Utils.ToolTipController(this.components);
            this.RisksBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TaskPriorityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DocumentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.AuditBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ImageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.ContactsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.InfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.AssetShiftBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.imgTree = new DevExpress.Utils.ImageCollection(this.components);
            this.NavBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.NavBarGroup2 = new DevExpress.XtraNavBar.NavBarGroup();
            this.nvTaskList = new DevExpress.XtraNavBar.NavBarItem();
            this.nvFlagged = new DevExpress.XtraNavBar.NavBarItem();
            this.nvProjects = new DevExpress.XtraNavBar.NavBarItem();
            this.nvQuality = new DevExpress.XtraNavBar.NavBarItem();
            this.nvFeedback = new DevExpress.XtraNavBar.NavBarItem();
            this.SplitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.tbDashboard = new DevExpress.XtraTab.XtraTabControl();
            this.tabMyHome = new DevExpress.XtraTab.XtraTabPage();
            this.TabPane1 = new DevExpress.XtraBars.Navigation.TabPane();
            this.TabNavigationPage3 = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.SplitContainerControl3 = new DevExpress.XtraEditors.SplitContainerControl();
            this.TaskTree = new DevExpress.XtraTreeList.TreeList();
            this.EmailGridControl = new DevExpress.XtraGrid.GridControl();
            this.grdMyInbox = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.GridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridColumn30 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RepositoryItemRichTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit();
            this.GridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabCalendar = new DevExpress.XtraTab.XtraTabPage();
            this.SplitContainerControl4 = new DevExpress.XtraEditors.SplitContainerControl();
            this.schCourses = new DevExpress.XtraScheduler.SchedulerControl();
            this.tabTraining = new DevExpress.XtraTab.XtraTabPage();
            this.TrainingGrid = new DevExpress.XtraGrid.GridControl();
            this.TrainingGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStudents = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCourse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExternalRef = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCourseContact = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCompany = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCourseTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTimeStamp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNotEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RepositoryItemCheckEdit7 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colKPI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFlag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIntRef = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDateofCourse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNCR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCourseType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNotEmail2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCert = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RepositoryItemCheckEdit14 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.RepositoryItemColorEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemColorEdit();
            this.RepositoryItemCalcEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            this.tabClinical = new DevExpress.XtraTab.XtraTabPage();
            this.ClincalGridControl = new DevExpress.XtraGrid.GridControl();
            this.shiftsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ClinicalGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShiftAttending = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocation1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDutyType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNotes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExpID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHours = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDutyDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRecords = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRecordCreated = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedBY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRecordClosed = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLinkID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTimeStamp1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShiftSheet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAddType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShiftSheetReceived = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNotified = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHaveShiftSheet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RepositoryItemCheckEdit5 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colNotEmail1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMedicID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RepositoryItemLookUpEdit6 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colPin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRole = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTableSort1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPath1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTemp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStart = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFinish = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShiftscol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLicenceExpiry = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCPGVersion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInvoice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrgExport = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFlag1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RepositoryItemCheckEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colSP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colClient = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInvoiceType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabLeads = new DevExpress.XtraTab.XtraTabPage();
            this.ActivitiesGridControl = new DevExpress.XtraGrid.GridControl();
            this.LeadsGrid = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTimeStamp3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colComplete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContactID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAssignedTo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit7 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.SystemUsersBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.colPriority = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreated = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedBy1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMemo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPhone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmail2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrg = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRef = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmailMemo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSource = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLeadSeen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActivitiescol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrg1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabGovernance = new DevExpress.XtraTab.XtraTabPage();
            this.SplitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.TreeList1 = new DevExpress.XtraTreeList.TreeList();
            this.colSection = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colSort = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colTimestamp4 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colImage = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colType1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colItemRef = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colFixed1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colID13 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.SplitContainerControl5 = new DevExpress.XtraEditors.SplitContainerControl();
            this.GovStandardsGridControl = new DevExpress.XtraGrid.GridControl();
            this.GovGrid = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colParent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridColumn31 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReviewDate1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBody = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colScope = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReference = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatement = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTheme = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colType2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPath2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIncluded = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colID14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKocked = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResponsible = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtGovInfo = new DevExpress.XtraEditors.MemoEdit();
            this.tabNotes = new DevExpress.XtraTab.XtraTabPage();
            this.BusinessNotesGridControl = new DevExpress.XtraGrid.GridControl();
            this.TileView1 = new DevExpress.XtraGrid.Views.Tile.TileView();
            this.colBody1 = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.colModified = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.tabTasks = new DevExpress.XtraTab.XtraTabPage();
            this.TasksGridControl = new DevExpress.XtraGrid.GridControl();
            this.GridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDue1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFreq = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPriority1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNotes1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPolicy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTimeStamp5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEstTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOwnerType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOwnerID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStartDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSystemTaskscol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAutoTask = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProcName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFrmName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCmdName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActionType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabRisk = new DevExpress.XtraTab.XtraTabPage();
            this.LayoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.ChartControl2 = new DevExpress.XtraCharts.ChartControl();
            this.ChartControl3 = new DevExpress.XtraCharts.ChartControl();
            this.ChartControl1 = new DevExpress.XtraCharts.ChartControl();
            this.RisksGridControl = new DevExpress.XtraGrid.GridControl();
            this.GridView11 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRisk = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLikelihood = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImpact = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRiskClass = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRiskScore = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRiskOwner = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPriority2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBusinessArea = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAffectedParty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIdentified = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMitigationLevel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReviewDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTimeStamp6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCategory1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RepositoryItemLookUpEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.LayoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.LayoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.LayoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.LayoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.LayoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.tabDocuments = new DevExpress.XtraTab.XtraTabPage();
            this.DocumentsGridControl = new DevExpress.XtraGrid.GridControl();
            this.GridView10 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colViewDocument = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RepositoryItemCheckEdit6 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.GridColumn29 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colID7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPath3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedBy3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExtRef = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOwner = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDocDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAuthor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colType3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSender = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFileStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabAudit = new DevExpress.XtraTab.XtraTabPage();
            this.AuditGridControl = new DevExpress.XtraGrid.GridControl();
            this.grdAudit = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colType5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAuditor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVerifier = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPolicy1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colScope1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridColumn28 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFilePath = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTimeStamp8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNotes2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridColumn25 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResult = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RepositoryItemRatingControl1 = new DevExpress.XtraEditors.Repository.RepositoryItemRatingControl();
            this.tabFlagged = new DevExpress.XtraTab.XtraTabPage();
            this.LayoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.ChartControl6 = new DevExpress.XtraCharts.ChartControl();
            this.ChartControl5 = new DevExpress.XtraCharts.ChartControl();
            this.ChartControl4 = new DevExpress.XtraCharts.ChartControl();
            this.GridControl1 = new DevExpress.XtraGrid.GridControl();
            this.grdFlagged = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colItemID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colItemType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colItemPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RepositoryItemLookUpEdit8 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.PersonnellBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.colRootCause = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colItemDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActionDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreated2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTimeStamp9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSource1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCategory2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNotifiable = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActionBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LayoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.LayoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.LayoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.LayoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.LayoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.SplitterItem1 = new DevExpress.XtraLayout.SplitterItem();
            this.SplitterItem3 = new DevExpress.XtraLayout.SplitterItem();
            this.SplitterItem4 = new DevExpress.XtraLayout.SplitterItem();
            this.tabTaskList = new DevExpress.XtraTab.XtraTabPage();
            this.GridControl3 = new DevExpress.XtraGrid.GridControl();
            this.TaskListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.GridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStandard = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRef1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFindings = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTimeStamp2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RepositoryItemHypertextLabel1 = new DevExpress.XtraEditors.Repository.RepositoryItemHypertextLabel();
            this.TaskListTableAdapter = new BM.MainDataSetTableAdapters.TaskListTableAdapter();
            this.DocumentsTableAdapter = new BM.MainDataSetTableAdapters.DocumentsTableAdapter();
            this.RisksTableAdapter = new BM.MainDataSetTableAdapters.RisksTableAdapter();
            this.TaskPriorityTableAdapter = new TaskDataSetTableAdapters.TaskPriorityTableAdapter();
            this.InfoTableAdapter = new BM.MainDataSetTableAdapters.InfoTableAdapter();
            this.AuditTableAdapter = new GovDataSetTableAdapters.AuditTableAdapter();
            this.ContactsTableAdapter = new BM.MainDataSetTableAdapters.ContactsTableAdapter();
            this.ntIconNew = new System.Windows.Forms.NotifyIcon(this.components);
            this.puCopy = new DevExpress.XtraBars.PopupMenu(this.components);
            this.bgEmail = new System.ComponentModel.BackgroundWorker();
            this.NCRTableAdapter = new BM.MainDataSetTableAdapters.NCRTableAdapter();
            this.schStorageMedics = new DevExpress.XtraScheduler.SchedulerDataStorage(this.components);
            this.PersonAvailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tt = new PersonnellDataSetTableAdapters.PersonAvailTableAdapter();
            this.schInstructors = new DevExpress.XtraScheduler.SchedulerDataStorage(this.components);
            this.InstructorAvailabilityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.INstructorAvailabilityTableAdapter = new PersonnellDataSetTableAdapters.INstructorAvailabilityTableAdapter();
            this.PopupMenu5 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.GridControl2 = new DevExpress.XtraGrid.GridControl();
            this.GridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.GalleryDropDown2 = new DevExpress.XtraBars.Ribbon.GalleryDropDown(this.components);
            this.shiftsTableAdapter = new BM.Clinical.ClinicalDataTableAdapters.ShiftsTableAdapter();
            this.trainDataSet = new BM.Training.TrainDataSet();
            this.courseListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.courseListTableAdapter = new BM.Training.TrainDataSetTableAdapters.CourseListTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemCheckEdit11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemHyperLinkEdit15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NCRBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repFlaggedCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.svgFlagged)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemCheckEdit8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repShowInactive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repByCourse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemLookUpEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemProgressBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemTextEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemDuration1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemZoomTrackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemSpinEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemHyperLinkEdit6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemHyperLinkEdit19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemCheckEdit19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemHyperLinkEdit7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemCheckEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PersonnellBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemHyperLinkEdit14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemLookUpEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemImageComboBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgGov)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemCheckEdit12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemCheckEdit13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemCheckEdit16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemLookUpEdit5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemRichTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemHyperLinkEdit9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemImageComboBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdImageList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemCheckEdit18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemHyperLinkEdit13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemHyperLinkEdit17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemHyperLinkEdit18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemCheckEdit20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemTextEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ApplicationMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.puOpen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PersonnellDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemCheckEdit10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeadListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeadsDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemImageComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemCheckEdit9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schWeb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WebUpcomingBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WebDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SchedulerStorage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpcomingBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PersonnellBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ActivitiesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SystemUsersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BusinessNotesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SystemTasksBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TaskDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TasksBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PeopleByCourseBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.puGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.puEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClinicalDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeadsByCourseBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Popup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.puGov)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SchedulerBarController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schWebView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.puScheduler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RisksBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TaskPriorityBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DocumentsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AuditBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContactsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InfoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AssetShiftBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NavBarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerControl1.Panel1)).BeginInit();
            this.SplitContainerControl1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerControl1.Panel2)).BeginInit();
            this.SplitContainerControl1.Panel2.SuspendLayout();
            this.SplitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbDashboard)).BeginInit();
            this.tbDashboard.SuspendLayout();
            this.tabMyHome.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TabPane1)).BeginInit();
            this.TabPane1.SuspendLayout();
            this.TabNavigationPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerControl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerControl3.Panel1)).BeginInit();
            this.SplitContainerControl3.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerControl3.Panel2)).BeginInit();
            this.SplitContainerControl3.Panel2.SuspendLayout();
            this.SplitContainerControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TaskTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmailGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMyInbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemRichTextEdit1)).BeginInit();
            this.tabCalendar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerControl4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerControl4.Panel1)).BeginInit();
            this.SplitContainerControl4.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerControl4.Panel2)).BeginInit();
            this.SplitContainerControl4.Panel2.SuspendLayout();
            this.SplitContainerControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.schCourses)).BeginInit();
            this.tabTraining.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrainingGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrainingGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemCheckEdit7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemCheckEdit14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemColorEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemCalcEdit1)).BeginInit();
            this.tabClinical.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ClincalGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shiftsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClinicalGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemCheckEdit5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemLookUpEdit6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemCheckEdit3)).BeginInit();
            this.tabLeads.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ActivitiesGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeadsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SystemUsersBindingSource1)).BeginInit();
            this.tabGovernance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerControl2.Panel1)).BeginInit();
            this.SplitContainerControl2.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerControl2.Panel2)).BeginInit();
            this.SplitContainerControl2.Panel2.SuspendLayout();
            this.SplitContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TreeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerControl5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerControl5.Panel1)).BeginInit();
            this.SplitContainerControl5.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerControl5.Panel2)).BeginInit();
            this.SplitContainerControl5.Panel2.SuspendLayout();
            this.SplitContainerControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GovStandardsGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GovGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGovInfo.Properties)).BeginInit();
            this.tabNotes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BusinessNotesGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TileView1)).BeginInit();
            this.tabTasks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TasksGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView3)).BeginInit();
            this.tabRisk.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl1)).BeginInit();
            this.LayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChartControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(stackedBarSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartControl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RisksGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemLookUpEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItem3)).BeginInit();
            this.tabDocuments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DocumentsGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemCheckEdit6)).BeginInit();
            this.tabAudit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AuditGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAudit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemRatingControl1)).BeginInit();
            this.tabFlagged.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl2)).BeginInit();
            this.LayoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChartControl6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartControl5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(stackedBarSeriesView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartControl4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(stackedBarSeriesLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(stackedBarSeriesView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFlagged)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemLookUpEdit8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PersonnellBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitterItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitterItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitterItem4)).BeginInit();
            this.tabTaskList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridControl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TaskListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemHypertextLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.puCopy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schStorageMedics)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PersonAvailBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schInstructors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InstructorAvailabilityBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PopupMenu5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GalleryDropDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trainDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.courseListBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // colSeen
            // 
            this.colSeen.Caption = "GridColumn26";
            this.colSeen.FieldName = "Seen";
            this.colSeen.MinWidth = 68;
            this.colSeen.Name = "colSeen";
            this.colSeen.Width = 260;
            // 
            // colInstructor
            // 
            this.colInstructor.FieldName = "Instructor";
            this.colInstructor.MaxWidth = 612;
            this.colInstructor.MinWidth = 68;
            this.colInstructor.Name = "colInstructor";
            this.colInstructor.OptionsColumn.AllowEdit = false;
            this.colInstructor.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Instructor", "{0} Courses")});
            this.colInstructor.Visible = true;
            this.colInstructor.VisibleIndex = 1;
            this.colInstructor.Width = 255;
            // 
            // colStatus
            // 
            this.colStatus.AppearanceCell.Options.UseTextOptions = true;
            this.colStatus.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStatus.AppearanceHeader.Options.UseTextOptions = true;
            this.colStatus.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStatus.FieldName = "Status";
            this.colStatus.MaxWidth = 270;
            this.colStatus.MinWidth = 68;
            this.colStatus.Name = "colStatus";
            this.colStatus.OptionsColumn.AllowEdit = false;
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 8;
            this.colStatus.Width = 112;
            // 
            // colPath
            // 
            this.colPath.FieldName = "Path";
            this.colPath.MinWidth = 68;
            this.colPath.Name = "colPath";
            this.colPath.OptionsColumn.AllowEdit = false;
            this.colPath.Width = 206;
            // 
            // colTableSort
            // 
            this.colTableSort.FieldName = "TableSort";
            this.colTableSort.MinWidth = 68;
            this.colTableSort.Name = "colTableSort";
            this.colTableSort.OptionsColumn.AllowEdit = false;
            this.colTableSort.Width = 260;
            // 
            // colCompleted
            // 
            this.colCompleted.FieldName = "Completed";
            this.colCompleted.MinWidth = 60;
            this.colCompleted.Name = "colCompleted";
            this.colCompleted.Width = 224;
            // 
            // colPercent
            // 
            this.colPercent.AppearanceCell.Options.UseTextOptions = true;
            this.colPercent.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPercent.AppearanceHeader.Options.UseTextOptions = true;
            this.colPercent.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPercent.DisplayFormat.FormatString = "{0:n0}%";
            this.colPercent.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colPercent.FieldName = "Percent";
            this.colPercent.MaxWidth = 350;
            this.colPercent.MinWidth = 68;
            this.colPercent.Name = "colPercent";
            this.colPercent.OptionsColumn.AllowEdit = false;
            this.colPercent.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Average, "Percent", "AVG {0:n0}%")});
            this.colPercent.Visible = true;
            this.colPercent.VisibleIndex = 6;
            this.colPercent.Width = 282;
            // 
            // colStatus2
            // 
            this.colStatus2.Caption = "App";
            this.colStatus2.ColumnEdit = this.RepositoryItemCheckEdit11;
            this.colStatus2.FieldName = "Status";
            this.colStatus2.MaxWidth = 122;
            this.colStatus2.MinWidth = 68;
            this.colStatus2.Name = "colStatus2";
            this.colStatus2.OptionsColumn.AllowEdit = false;
            this.colStatus2.Visible = true;
            this.colStatus2.VisibleIndex = 9;
            this.colStatus2.Width = 102;
            // 
            // RepositoryItemCheckEdit11
            // 
            this.RepositoryItemCheckEdit11.AutoHeight = false;
            this.RepositoryItemCheckEdit11.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            this.RepositoryItemCheckEdit11.Name = "RepositoryItemCheckEdit11";
            this.RepositoryItemCheckEdit11.ValueChecked = "Applicable";
            this.RepositoryItemCheckEdit11.ValueUnchecked = "Not Applicable";
            // 
            // colTitle
            // 
            this.colTitle.ColumnEdit = this.RepositoryItemHyperLinkEdit15;
            this.colTitle.FieldName = "Title";
            this.colTitle.MinWidth = 68;
            this.colTitle.Name = "colTitle";
            this.colTitle.OptionsColumn.AllowEdit = false;
            this.colTitle.Visible = true;
            this.colTitle.VisibleIndex = 1;
            this.colTitle.Width = 260;
            // 
            // RepositoryItemHyperLinkEdit15
            // 
            this.RepositoryItemHyperLinkEdit15.AutoHeight = false;
            this.RepositoryItemHyperLinkEdit15.Name = "RepositoryItemHyperLinkEdit15";
            // 
            // colCreatedBy2
            // 
            this.colCreatedBy2.FieldName = "CreatedBy";
            this.colCreatedBy2.MaxWidth = 524;
            this.colCreatedBy2.MinWidth = 68;
            this.colCreatedBy2.Name = "colCreatedBy2";
            this.colCreatedBy2.OptionsColumn.AllowEdit = false;
            this.colCreatedBy2.Visible = true;
            this.colCreatedBy2.VisibleIndex = 3;
            this.colCreatedBy2.Width = 260;
            // 
            // colID5
            // 
            this.colID5.FieldName = "ID";
            this.colID5.MinWidth = 68;
            this.colID5.Name = "colID5";
            this.colID5.OptionsColumn.AllowEdit = false;
            this.colID5.Visible = true;
            this.colID5.VisibleIndex = 0;
            this.colID5.Width = 260;
            // 
            // NCRBindingSource
            // 
            this.NCRBindingSource.DataMember = "NCR";
            this.NCRBindingSource.DataSource = this.MainDataSet;
            // 
            // MainDataSet
            // 
            this.MainDataSet.DataSetName = "MainDataSet";
            this.MainDataSet.Locale = new System.Globalization.CultureInfo("en-IE");
            this.MainDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // colLevel
            // 
            this.colLevel.ColumnEdit = this.repFlaggedCategory;
            this.colLevel.FieldName = "Level";
            this.colLevel.MinWidth = 60;
            this.colLevel.Name = "colLevel";
            this.colLevel.Visible = true;
            this.colLevel.VisibleIndex = 7;
            this.colLevel.Width = 265;
            // 
            // repFlaggedCategory
            // 
            this.repFlaggedCategory.AutoHeight = false;
            this.repFlaggedCategory.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repFlaggedCategory.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("A1 : Near Miss (Organised)", "A1", 1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("A2 : Near Miss (Chance)", "A2", 1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("B1 : No Harm (Detected)", "B1", 2),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("B2: No Harm (Chance)", "B2", 2),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("C: Harmful", "C", 3)});
            this.repFlaggedCategory.Name = "repFlaggedCategory";
            this.repFlaggedCategory.SmallImages = this.svgFlagged;
            // 
            // svgFlagged
            // 
            this.svgFlagged.Add("Blue Flag", ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("svgFlagged.Blue Flag"))));
            this.svgFlagged.Add("Green Flag", ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("svgFlagged.Green Flag"))));
            this.svgFlagged.Add("Organge Flag", ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("svgFlagged.Organge Flag"))));
            this.svgFlagged.Add("Red Flag", ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("svgFlagged.Red Flag"))));
            // 
            // colStatus7
            // 
            this.colStatus7.FieldName = "Status";
            this.colStatus7.MaxWidth = 374;
            this.colStatus7.MinWidth = 60;
            this.colStatus7.Name = "colStatus7";
            this.colStatus7.OptionsColumn.AllowEdit = false;
            this.colStatus7.Visible = true;
            this.colStatus7.VisibleIndex = 4;
            this.colStatus7.Width = 85;
            // 
            // colStatus6
            // 
            this.colStatus6.AppearanceCell.Options.UseTextOptions = true;
            this.colStatus6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStatus6.FieldName = "Status";
            this.colStatus6.MaxWidth = 254;
            this.colStatus6.MinWidth = 68;
            this.colStatus6.Name = "colStatus6";
            this.colStatus6.OptionsColumn.AllowEdit = false;
            this.colStatus6.Visible = true;
            this.colStatus6.VisibleIndex = 4;
            this.colStatus6.Width = 85;
            // 
            // RepositoryItemCheckEdit8
            // 
            this.RepositoryItemCheckEdit8.AutoHeight = false;
            this.RepositoryItemCheckEdit8.Name = "RepositoryItemCheckEdit8";
            // 
            // repShowInactive
            // 
            this.repShowInactive.AutoHeight = false;
            this.repShowInactive.Name = "repShowInactive";
            // 
            // RepositoryItemTextEdit2
            // 
            this.RepositoryItemTextEdit2.AutoHeight = false;
            this.RepositoryItemTextEdit2.Name = "RepositoryItemTextEdit2";
            // 
            // repByCourse
            // 
            this.repByCourse.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.repByCourse.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repByCourse.DisplayMember = "CoursesName";
            this.repByCourse.DropDownRows = 12;
            this.repByCourse.Name = "repByCourse";
            this.repByCourse.NullText = "";
            this.repByCourse.ValueMember = "CoursesName";
            // 
            // RepositoryItemMemoEdit1
            // 
            this.RepositoryItemMemoEdit1.Name = "RepositoryItemMemoEdit1";
            // 
            // RepositoryItemLookUpEdit2
            // 
            this.RepositoryItemLookUpEdit2.AutoHeight = false;
            this.RepositoryItemLookUpEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RepositoryItemLookUpEdit2.DisplayMember = "ItemName";
            this.RepositoryItemLookUpEdit2.Name = "RepositoryItemLookUpEdit2";
            this.RepositoryItemLookUpEdit2.NullText = "";
            this.RepositoryItemLookUpEdit2.ValueMember = "ItemName";
            // 
            // RepositoryItemProgressBar1
            // 
            this.RepositoryItemProgressBar1.Name = "RepositoryItemProgressBar1";
            this.RepositoryItemProgressBar1.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid;
            this.RepositoryItemProgressBar1.ShowTitle = true;
            // 
            // RepositoryItemTextEdit3
            // 
            this.RepositoryItemTextEdit3.AutoHeight = false;
            this.RepositoryItemTextEdit3.Name = "RepositoryItemTextEdit3";
            // 
            // RepositoryItemDuration1
            // 
            this.RepositoryItemDuration1.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.RepositoryItemDuration1.AutoHeight = false;
            this.RepositoryItemDuration1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RepositoryItemDuration1.DisabledStateText = null;
            this.RepositoryItemDuration1.Name = "RepositoryItemDuration1";
            this.RepositoryItemDuration1.ShowEmptyItem = true;
            this.RepositoryItemDuration1.ValidateOnEnterKey = true;
            // 
            // RepositoryItemZoomTrackBar1
            // 
            this.RepositoryItemZoomTrackBar1.LargeChange = 1;
            this.RepositoryItemZoomTrackBar1.Maximum = 6;
            this.RepositoryItemZoomTrackBar1.Middle = 3;
            this.RepositoryItemZoomTrackBar1.Name = "RepositoryItemZoomTrackBar1";
            // 
            // RepositoryItemSpinEdit2
            // 
            this.RepositoryItemSpinEdit2.AutoHeight = false;
            this.RepositoryItemSpinEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RepositoryItemSpinEdit2.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.RepositoryItemSpinEdit2.MaxValue = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.RepositoryItemSpinEdit2.MinValue = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.RepositoryItemSpinEdit2.Name = "RepositoryItemSpinEdit2";
            // 
            // RepositoryItemComboBox1
            // 
            this.RepositoryItemComboBox1.AutoHeight = false;
            this.RepositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RepositoryItemComboBox1.Items.AddRange(new object[] {
            "NA",
            "CHKS NA-NU",
            "CHKS Parent View"});
            this.RepositoryItemComboBox1.Name = "RepositoryItemComboBox1";
            // 
            // RepositoryItemHyperLinkEdit6
            // 
            this.RepositoryItemHyperLinkEdit6.AutoHeight = false;
            this.RepositoryItemHyperLinkEdit6.Name = "RepositoryItemHyperLinkEdit6";
            // 
            // RepositoryItemCheckEdit2
            // 
            this.RepositoryItemCheckEdit2.AutoHeight = false;
            this.RepositoryItemCheckEdit2.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.Custom;
            this.RepositoryItemCheckEdit2.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            this.RepositoryItemCheckEdit2.ImageOptions.SvgImageChecked = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("RepositoryItemCheckEdit2.ImageOptions.SvgImageChecked")));
            this.RepositoryItemCheckEdit2.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.RepositoryItemCheckEdit2.Name = "RepositoryItemCheckEdit2";
            // 
            // RepositoryItemCheckEdit1
            // 
            this.RepositoryItemCheckEdit1.AutoHeight = false;
            this.RepositoryItemCheckEdit1.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            this.RepositoryItemCheckEdit1.ImageOptions.SvgImageChecked = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("RepositoryItemCheckEdit1.ImageOptions.SvgImageChecked")));
            this.RepositoryItemCheckEdit1.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1";
            // 
            // RepositoryItemHyperLinkEdit19
            // 
            this.RepositoryItemHyperLinkEdit19.AutoHeight = false;
            this.RepositoryItemHyperLinkEdit19.Name = "RepositoryItemHyperLinkEdit19";
            this.RepositoryItemHyperLinkEdit19.OpenLink += new DevExpress.XtraEditors.Controls.OpenLinkEventHandler(this.RepositoryItemHyperLinkEdit19_OpenLink);
            // 
            // RepositoryItemCheckEdit19
            // 
            this.RepositoryItemCheckEdit19.AutoHeight = false;
            this.RepositoryItemCheckEdit19.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            this.RepositoryItemCheckEdit19.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.RepositoryItemCheckEdit19.Name = "RepositoryItemCheckEdit19";
            // 
            // RepositoryItemHyperLinkEdit7
            // 
            this.RepositoryItemHyperLinkEdit7.AutoHeight = false;
            this.RepositoryItemHyperLinkEdit7.Name = "RepositoryItemHyperLinkEdit7";
            // 
            // RepositoryItemDateEdit1
            // 
            this.RepositoryItemDateEdit1.AutoHeight = false;
            this.RepositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RepositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RepositoryItemDateEdit1.DisplayFormat.FormatString = "ddd, dd MMM yy";
            this.RepositoryItemDateEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.RepositoryItemDateEdit1.Mask.EditMask = "ddd, dd MMM yy";
            this.RepositoryItemDateEdit1.Mask.UseMaskAsDisplayFormat = true;
            this.RepositoryItemDateEdit1.Name = "RepositoryItemDateEdit1";
            // 
            // RepositoryItemCheckEdit4
            // 
            this.RepositoryItemCheckEdit4.AutoHeight = false;
            this.RepositoryItemCheckEdit4.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.Custom;
            this.RepositoryItemCheckEdit4.CheckBoxOptions.SvgColorChecked = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.RepositoryItemCheckEdit4.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            this.RepositoryItemCheckEdit4.ImageOptions.SvgImageChecked = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("RepositoryItemCheckEdit4.ImageOptions.SvgImageChecked")));
            this.RepositoryItemCheckEdit4.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.Full;
            this.RepositoryItemCheckEdit4.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.RepositoryItemCheckEdit4.Name = "RepositoryItemCheckEdit4";
            // 
            // RepositoryItemLookUpEdit1
            // 
            this.RepositoryItemLookUpEdit1.AutoHeight = false;
            this.RepositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RepositoryItemLookUpEdit1.DataSource = this.PersonnellBindingSource;
            this.RepositoryItemLookUpEdit1.DisplayMember = "InstructorName";
            this.RepositoryItemLookUpEdit1.Name = "RepositoryItemLookUpEdit1";
            this.RepositoryItemLookUpEdit1.ValueMember = "ID";
            // 
            // PersonnellBindingSource
            // 
            this.PersonnellBindingSource.DataMember = "Personnell";
            this.PersonnellBindingSource.DataSource = this.MainDataSet;
            // 
            // RepositoryItemHyperLinkEdit14
            // 
            this.RepositoryItemHyperLinkEdit14.AutoHeight = false;
            this.RepositoryItemHyperLinkEdit14.Name = "RepositoryItemHyperLinkEdit14";
            // 
            // RepositoryItemLookUpEdit3
            // 
            this.RepositoryItemLookUpEdit3.AutoHeight = false;
            this.RepositoryItemLookUpEdit3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RepositoryItemLookUpEdit3.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("UserName", "User Name", 75, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.RepositoryItemLookUpEdit3.DisplayMember = "UserName";
            this.RepositoryItemLookUpEdit3.Name = "RepositoryItemLookUpEdit3";
            this.RepositoryItemLookUpEdit3.ValueMember = "ID";
            // 
            // RepositoryItemImageComboBox2
            // 
            this.RepositoryItemImageComboBox2.AutoHeight = false;
            this.RepositoryItemImageComboBox2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RepositoryItemImageComboBox2.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Policy", "Policy", 2),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Evidence", "Evidence", 4),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Standard", "Standard", 5),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("KPI", "KPI", 10),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Legislation", "Legislation", 12),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Task", "Task", 13),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Guideline", "Guideline", 6)});
            this.RepositoryItemImageComboBox2.Name = "RepositoryItemImageComboBox2";
            this.RepositoryItemImageComboBox2.SmallImages = this.imgGov;
            // 
            // imgGov
            // 
            this.imgGov.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgGov.ImageStream")));
            // 
            // RepositoryItemCheckEdit12
            // 
            this.RepositoryItemCheckEdit12.AutoHeight = false;
            this.RepositoryItemCheckEdit12.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            this.RepositoryItemCheckEdit12.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.RepositoryItemCheckEdit12.Name = "RepositoryItemCheckEdit12";
            this.RepositoryItemCheckEdit12.Click += new System.EventHandler(this.RepositoryItemCheckEdit12_Click);
            // 
            // RepositoryItemCheckEdit13
            // 
            this.RepositoryItemCheckEdit13.AutoHeight = false;
            this.RepositoryItemCheckEdit13.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            this.RepositoryItemCheckEdit13.Name = "RepositoryItemCheckEdit13";
            // 
            // RepositoryItemCheckEdit16
            // 
            this.RepositoryItemCheckEdit16.AutoHeight = false;
            this.RepositoryItemCheckEdit16.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.Custom;
            this.RepositoryItemCheckEdit16.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.RepositoryItemCheckEdit16.Name = "RepositoryItemCheckEdit16";
            // 
            // RepositoryItemLookUpEdit5
            // 
            this.RepositoryItemLookUpEdit5.AutoHeight = false;
            this.RepositoryItemLookUpEdit5.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RepositoryItemLookUpEdit5.DisplayMember = "UserName";
            this.RepositoryItemLookUpEdit5.Name = "RepositoryItemLookUpEdit5";
            this.RepositoryItemLookUpEdit5.NullText = "";
            this.RepositoryItemLookUpEdit5.ValueMember = "ID";
            // 
            // RepositoryItemRichTextEdit2
            // 
            this.RepositoryItemRichTextEdit2.DocumentFormat = DevExpress.XtraRichEdit.DocumentFormat.Rtf;
            this.RepositoryItemRichTextEdit2.Name = "RepositoryItemRichTextEdit2";
            this.RepositoryItemRichTextEdit2.ShowCaretInReadOnly = false;
            // 
            // RepositoryItemHyperLinkEdit9
            // 
            this.RepositoryItemHyperLinkEdit9.AutoHeight = false;
            this.RepositoryItemHyperLinkEdit9.Name = "RepositoryItemHyperLinkEdit9";
            // 
            // RepositoryItemImageComboBox3
            // 
            this.RepositoryItemImageComboBox3.AutoHeight = false;
            this.RepositoryItemImageComboBox3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RepositoryItemImageComboBox3.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Normal", 1, 0),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Medium", 2, 2),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("High", 3, 1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Immediate", 4, 4)});
            this.RepositoryItemImageComboBox3.Name = "RepositoryItemImageComboBox3";
            this.RepositoryItemImageComboBox3.SmallImages = this.grdImageList;
            // 
            // grdImageList
            // 
            this.grdImageList.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("grdImageList.ImageStream")));
            // 
            // RepositoryItemCheckEdit18
            // 
            this.RepositoryItemCheckEdit18.AutoHeight = false;
            this.RepositoryItemCheckEdit18.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            this.RepositoryItemCheckEdit18.Name = "RepositoryItemCheckEdit18";
            this.RepositoryItemCheckEdit18.Click += new System.EventHandler(this.RepositoryItemCheckEdit18_Click);
            // 
            // RepositoryItemHyperLinkEdit13
            // 
            this.RepositoryItemHyperLinkEdit13.AutoHeight = false;
            this.RepositoryItemHyperLinkEdit13.Name = "RepositoryItemHyperLinkEdit13";
            // 
            // RepositoryItemHyperLinkEdit17
            // 
            this.RepositoryItemHyperLinkEdit17.AutoHeight = false;
            this.RepositoryItemHyperLinkEdit17.Name = "RepositoryItemHyperLinkEdit17";
            // 
            // RepositoryItemHyperLinkEdit18
            // 
            this.RepositoryItemHyperLinkEdit18.AutoHeight = false;
            this.RepositoryItemHyperLinkEdit18.Name = "RepositoryItemHyperLinkEdit18";
            // 
            // RepositoryItemCheckEdit20
            // 
            this.RepositoryItemCheckEdit20.AutoHeight = false;
            this.RepositoryItemCheckEdit20.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.RepositoryItemCheckEdit20.Name = "RepositoryItemCheckEdit20";
            // 
            // RepositoryItemTextEdit4
            // 
            this.RepositoryItemTextEdit4.AutoHeight = false;
            this.RepositoryItemTextEdit4.Name = "RepositoryItemTextEdit4";
            // 
            // colCreatedTime
            // 
            this.colCreatedTime.FieldName = "CreatedTime";
            this.colCreatedTime.MaxWidth = 260;
            this.colCreatedTime.MinWidth = 68;
            this.colCreatedTime.Name = "colCreatedTime";
            this.colCreatedTime.OptionsColumn.AllowEdit = false;
            this.colCreatedTime.Visible = true;
            this.colCreatedTime.VisibleIndex = 4;
            this.colCreatedTime.Width = 260;
            // 
            // imgEmail
            // 
            this.imgEmail.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgEmail.ImageStream")));
            // 
            // RibbonControl1
            // 
            this.RibbonControl1.ApplicationButtonDropDownControl = this.ApplicationMenu1;
            this.RibbonControl1.CaptionBarItemLinks.Add(this.btnBugFile);
            this.RibbonControl1.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(90);
            this.RibbonControl1.ExpandCollapseItem.Id = 0;
            this.RibbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnBugFile,
            this.RibbonControl1.ExpandCollapseItem,
            this.RibbonControl1.SearchEditItem,
            this.btnNewCourse,
            this.btnEditCourse,
            this.btnMultiAddCourse,
            this.btnMultiSelect,
            this.btnBatchCerts,
            this.btnBatchUpdate,
            this.btnBatchExportCourse,
            this.btnFindStudents,
            this.btnImportStudents,
            this.BtnRefresh,
            this.btnOpenCourses,
            this.BtnAllCourses,
            this.btnNotSet,
            this.btnFlagged,
            this.btnYesterday,
            this.btnToday,
            this.btnTomorrow,
            this.btnLastWeek,
            this.btnNextWeek,
            this.btnThisWeek,
            this.btnLastMonth,
            this.btnThisMonth,
            this.btnNextMonth,
            this.btnTrainingReturns,
            this.btnStats,
            this.btnPastOpen,
            this.btnNotInvoiced,
            this.btnPastNotInvoiced,
            this.brUser,
            this.brIP,
            this.brLoggedUsers,
            this.brSecurity,
            this.brSecure,
            this.brShares,
            this.brVersion,
            this.brWebAccess,
            this.btnOptionsView,
            this.btnClinicalAdd,
            this.btnClinicalAudits,
            this.btnClinicalReports,
            this.btnViewbyMedics,
            this.btnViewbyInstructors,
            this.BarEditItem1,
            this.BarSubItem1,
            this.BarEditItem2,
            this.btnShowInactive,
            this.brByCourse,
            this.btnResetPersonnelView,
            this.btnAddSingleShift,
            this.btnClinicalStats,
            this.btnCopy,
            this.btnOpenThis,
            this.btnAllThis,
            this.btnClearFilter,
            this.btnCompanyReport,
            this.btn7DayReport,
            this.btnSummaryReport,
            this.btnTempReport,
            this.BarSubItem3,
            this.btnThisMonthReport,
            this.btnMonthReportLast,
            this.btnMonthReportNext,
            this.btnDetailReport,
            this.btnConvertLead,
            this.btnConvertTask,
            this.btnLogOff,
            this.brInfo,
            this.btnAddTask,
            this.btnAddLead,
            this.BtnShiftSheets,
            this.btnCourseExpiry,
            this.btnStaffCompliance,
            this.btnAuditLog,
            this.btnGlobalCompliance,
            this.BarEditItem3,
            this.btnShowWeb,
            this.btnAvailability,
            this.btnMedicsAvailability,
            this.btnInstAvailability,
            this.btnFilter,
            this.btnFilterShift,
            this.btnFilterCourse,
            this.btnFilterMeeting,
            this.btnOpenLeads,
            this.btnNewLead,
            this.btnAllLeads,
            this.btnClosedLost,
            this.btnClosedWon,
            this.btnMyLeads,
            this.BarEditItem4,
            this.btnReport,
            this.btnAddItem,
            this.btnFilterStandards,
            this.btnFilterPolicies,
            this.btnFilterEvidence,
            this.btnFilterKPI,
            this.btnFilterViewAll,
            this.btnExpandAll,
            this.btnCollapseAll,
            this.btnWorkDiary,
            this.btnSortName,
            this.btnSortLocation,
            this.btnMap,
            this.brProgress,
            this.btnGridExpand,
            this.btnSanity,
            this.btnFilterTask,
            this.btnFilterLead,
            this.btnFilterEmail,
            this.BarButtonItem9,
            this.btnOpenGov,
            this.btnRemoveItem,
            this.btnFindReferences,
            this.btnOpenItem,
            this.btnOpenFile,
            this.btnRename,
            this.btnCopyItem,
            this.btnNewSection,
            this.btnRemoveItemGov,
            this.BarEditItem5,
            this.BarSubItem2,
            this.BarSubItem4,
            this.BarSubItem5,
            this.btnAddStandard,
            this.btnAddPolicy,
            this.btnAddLegislation,
            this.btnAddGuideline,
            this.btnAddEvidence,
            this.btnAddKPI,
            this.btnMoveUp,
            this.btnMoveDown,
            this.btnExpandTree,
            this.btnCollapseTree,
            this.btnAddGovTask,
            this.BarButtonItem10,
            this.btnShiftTemplate,
            this.BarButtonItem11,
            this.btnAddNote,
            this.EditAppointmentQueryItem1,
            this.EditOccurrenceUICommandItem1,
            this.EditSeriesUICommandItem1,
            this.DeleteAppointmentsItem1,
            this.DeleteOccurrenceItem1,
            this.DeleteSeriesItem1,
            this.SplitAppointmentItem1,
            this.ChangeAppointmentStatusItem1,
            this.ChangeAppointmentLabelItem1,
            this.ToggleRecurrenceItem1,
            this.ChangeAppointmentReminderItem1,
            this.btnAddAppointment,
            this.btnAddDocument,
            this.BarButtonItem13,
            this.BarButtonItem14,
            this.BarButtonItem15,
            this.btnViewOptions,
            this.btnViewFooter,
            this.btnViewFilter,
            this.btnFooterFilter,
            this.btnViewFind,
            this.btnHorLines,
            this.btnVerticalLInes,
            this.btnCellMerge,
            this.btnAddInfo,
            this.btnShowGrouped,
            this.BarButtonItem18,
            this.btnForReview,
            this.btnViewOpen,
            this.btnShowAll,
            this.BarListItem1,
            this.BarButtonItem19,
            this.btnGridCollapse,
            this.btnGridExport,
            this.btnGridExportPDF,
            this.btnGridExportXLXS,
            this.btnGridExportExcel,
            this.btnGridExportCSV,
            this.btnGridExportHtml,
            this.btnExportSelected,
            this.btnGridExportWord,
            this.btnGridPrint,
            this.btnOddRow,
            this.BarButtonItem5,
            this.btnCopyValue,
            this.btnCourseCurrent,
            this.btnFilterBy,
            this.BarButtonItem20,
            this.BarSubItem6,
            this.btnPersonClinicalReport,
            this.btnNoPaperworkShow,
            this.btnFutureTasks,
            this.btnResetInbox,
            this.btnMedicReminders,
            this.btnInstructorsReminders,
            this.BarButtonItem3,
            this.BarButtonItem4,
            this.BarEditItem6,
            this.BarButtonItem6,
            this.BarButtonItem7,
            this.btnRestart,
            this.btnInvoice,
            this.btnMedicsReport,
            this.BarSubItem7,
            this.btnMedicRegister,
            this.btnMedicCompliance,
            this.btnCaptureCopy,
            this.chkCaptureCopy,
            this.btnViewOverview,
            this.btnCasualtySummary,
            this.btnAmbulanceControl,
            this.BarButtonItem22,
            this.BarButtonItem23,
            this.btnGovReporting,
            this.btnGovReportOverview,
            this.btnGovReportDetails,
            this.btnGovShowApplicable,
            this.btnPaid,
            this.br64,
            this.BarButtonItem1,
            this.BarSubItem8,
            this.btnGovApplicapable,
            this.btnGovNotApplicable,
            this.btnClinicalKPI,
            this.btnBatchImport,
            this.btnGoToToday,
            this.btnZoomIn,
            this.BtnZoomOut,
            this.BarButtonItem27,
            this.BarButtonItem24,
            this.BarButtonItem25,
            this.btnPhonebook,
            this.BarButtonItem26,
            this.btnIndentRow,
            this.btnPrintGovList,
            this.BarToggleSwitchItem1,
            this.btnGroupColour,
            this.btnClearTreeFilter,
            this.SkinDropDownButtonItem1,
            this.btnViewGroupStandards,
            this.btnCopyFiles,
            this.btnOpenFolder,
            this.btnCopyStandards,
            this.btnShowGroupSummary,
            this.btnTrainingAction,
            this.btnCopyCol,
            this.BarButtonItem28,
            this.btnAvailabilityPerson,
            this.SwitchToDayViewItem1,
            this.SwitchToWorkWeekViewItem1,
            this.SwitchToWeekViewItem1,
            this.SwitchToFullWeekViewItem1,
            this.SwitchToMonthViewItem1,
            this.SwitchToTimelineViewItem1,
            this.SwitchToGanttViewItem1,
            this.SwitchToAgendaViewItem1,
            this.SwitchTimeScalesItem1,
            this.ChangeScaleWidthItem1,
            this.SwitchTimeScalesCaptionItem1,
            this.SwitchCompressWeekendItem1,
            this.SwitchShowWorkTimeOnlyItem1,
            this.SwitchCellsAutoHeightItem1,
            this.ChangeSnapToCellsUIItem1,
            this.btnGovTemplate,
            this.BarButtonItem8,
            this.btnReplyWith,
            this.btnFlag,
            this.BarEditItem7,
            this.btnImportInvoices,
            this.btnFindAfterDrag,
            this.btn100Percent,
            this.btnTaskCompleted,
            this.btnOpenFileLocation,
            this.btnFlaggedReport,
            this.SkinRibbonGalleryBarItem3,
            this.SkinPaletteRibbonGalleryBarItem3,
            this.BarButtonItem29,
            this.BarButtonItem30,
            this.btnValidateFiles,
            this.btnWebImport,
            this.BarButtonItem31,
            this.btnCleanGPS,
            this.btnFlag_Add,
            this.btnRiskRecategorise,
            this.RibbonGalleryBarItem1,
            this.RibbonGalleryBarItem2,
            this.RibbonGalleryBarItem3,
            this.RibbonGalleryBarItem4,
            this.rbnViewGallery,
            this.RibbonGalleryBarItem5,
            this.brLocale,
            this.BtnCheckInvoice,
            this.btnSendMattermost,
            this.btnValidateShifts,
            this.btnPersonValidate,
            this.btnRiskRegister,
            this.BarButtonItem2,
            this.BtnColourGroupRow});
            this.RibbonControl1.Location = new System.Drawing.Point(0, 0);
            this.RibbonControl1.Margin = new System.Windows.Forms.Padding(8);
            this.RibbonControl1.MaxItemId = 108;
            this.RibbonControl1.Name = "RibbonControl1";
            this.RibbonControl1.OptionsMenuMinWidth = 990;
            this.RibbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rbnMyHome,
            this.rbnTraining,
            this.rbnPersonnel,
            this.rbnClinical,
            this.rbnLeads,
            this.rbnTasks,
            this.rbnRisk,
            this.rbnGovernance,
            this.rbnDocuments,
            this.rbnAudit,
            this.rbnContacts,
            this.ViewRibbonPage1,
            this.rbnFlagged,
            this.rbnNotes,
            this.rbnTaskList});
            this.RibbonControl1.Size = new System.Drawing.Size(1839, 201);
            this.RibbonControl1.StatusBar = this.RibbonStatusBar1;
            // 
            // ApplicationMenu1
            // 
            this.ApplicationMenu1.ItemLinks.Add(this.btnOptionsView, "O");
            this.ApplicationMenu1.ItemLinks.Add(this.btnAuditLog, "V");
            this.ApplicationMenu1.ItemLinks.Add(this.btnCleanGPS, true);
            this.ApplicationMenu1.ItemLinks.Add(this.btnLogOff, true, "L");
            this.ApplicationMenu1.ItemLinks.Add(this.btnRestart);
            this.ApplicationMenu1.Name = "ApplicationMenu1";
            this.ApplicationMenu1.Ribbon = this.RibbonControl1;
            // 
            // btnOptionsView
            // 
            this.btnOptionsView.Caption = "Options";
            this.btnOptionsView.Id = 81;
            this.btnOptionsView.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnOptionsView.ImageOptions.SvgImage")));
            this.btnOptionsView.Name = "btnOptionsView";
            this.btnOptionsView.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOptionsView_ItemClick);
            // 
            // btnAuditLog
            // 
            this.btnAuditLog.Caption = "View Audit Log";
            this.btnAuditLog.Id = 247;
            this.btnAuditLog.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAuditLog.ImageOptions.Image")));
            this.btnAuditLog.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnAuditLog.ImageOptions.LargeImage")));
            this.btnAuditLog.Name = "btnAuditLog";
            this.btnAuditLog.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAuditLog_ItemClick);
            // 
            // btnCleanGPS
            // 
            this.btnCleanGPS.Caption = "Clean GPS Records";
            this.btnCleanGPS.Id = 83;
            this.btnCleanGPS.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnCleanGPS.ImageOptions.SvgImage")));
            this.btnCleanGPS.ItemAppearance.Normal.Options.UseFont = true;
            this.btnCleanGPS.Name = "btnCleanGPS";
            this.btnCleanGPS.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCleanGPS_ItemClickAsync);
            // 
            // btnLogOff
            // 
            this.btnLogOff.Caption = "Log Off";
            this.btnLogOff.Id = 238;
            this.btnLogOff.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnLogOff.ImageOptions.SvgImage")));
            this.btnLogOff.Name = "btnLogOff";
            this.btnLogOff.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLogOff_ItemClick);
            // 
            // btnRestart
            // 
            this.btnRestart.Caption = "Restart Application";
            this.btnRestart.Id = 398;
            this.btnRestart.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnRestart.ImageOptions.SvgImage")));
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRestart_ItemClick);
            // 
            // btnBugFile
            // 
            this.btnBugFile.Caption = "Report Bug / Feature";
            this.btnBugFile.Id = 107;
            this.btnBugFile.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnBugFile.ImageOptions.SvgImage")));
            this.btnBugFile.Name = "btnBugFile";
            this.btnBugFile.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.btnBugFile.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBugFile_ItemClick);
            // 
            // btnNewCourse
            // 
            this.btnNewCourse.Caption = "Add Course";
            this.btnNewCourse.Id = 1;
            this.btnNewCourse.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnNewCourse.ImageOptions.SvgImage")));
            this.btnNewCourse.Name = "btnNewCourse";
            this.btnNewCourse.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNewCourse_ItemClick);
            // 
            // btnEditCourse
            // 
            this.btnEditCourse.Caption = "Edit Course";
            this.btnEditCourse.Id = 2;
            this.btnEditCourse.Name = "btnEditCourse";
            this.btnEditCourse.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.btnEditCourse.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEditCourse_ItemClick);
            // 
            // btnMultiAddCourse
            // 
            this.btnMultiAddCourse.Caption = "Multi-Add";
            this.btnMultiAddCourse.Id = 3;
            this.btnMultiAddCourse.Name = "btnMultiAddCourse";
            this.btnMultiAddCourse.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            // 
            // btnMultiSelect
            // 
            this.btnMultiSelect.Caption = "Multi Select";
            this.btnMultiSelect.Id = 4;
            this.btnMultiSelect.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnMultiSelect.ImageOptions.SvgImage")));
            this.btnMultiSelect.Name = "btnMultiSelect";
            this.btnMultiSelect.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.btnMultiSelect.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMultiSelect_ItemClick);
            // 
            // btnBatchCerts
            // 
            this.btnBatchCerts.Caption = "Batch Certs";
            this.btnBatchCerts.Id = 5;
            this.btnBatchCerts.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnBatchCerts.ImageOptions.LargeImage")));
            this.btnBatchCerts.Name = "btnBatchCerts";
            this.btnBatchCerts.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBatchCerts_ItemClick);
            // 
            // btnBatchUpdate
            // 
            this.btnBatchUpdate.Caption = "Batch Update";
            this.btnBatchUpdate.Id = 6;
            this.btnBatchUpdate.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnBatchUpdate.ImageOptions.SvgImage")));
            this.btnBatchUpdate.Name = "btnBatchUpdate";
            this.btnBatchUpdate.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBatchUpdate_ItemClick);
            // 
            // btnBatchExportCourse
            // 
            this.btnBatchExportCourse.Caption = "Batch Export";
            this.btnBatchExportCourse.Id = 7;
            this.btnBatchExportCourse.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnBatchExportCourse.ImageOptions.SvgImage")));
            this.btnBatchExportCourse.Name = "btnBatchExportCourse";
            this.btnBatchExportCourse.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.btnBatchExportCourse.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBatchExportCourse_ItemClick);
            // 
            // btnFindStudents
            // 
            this.btnFindStudents.Caption = "Find Students";
            this.btnFindStudents.Id = 8;
            this.btnFindStudents.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnFindStudents.ImageOptions.SvgImage")));
            this.btnFindStudents.Name = "btnFindStudents";
            this.btnFindStudents.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFindStudents_ItemClick);
            // 
            // btnImportStudents
            // 
            this.btnImportStudents.Caption = "Import Students";
            this.btnImportStudents.Id = 9;
            this.btnImportStudents.Name = "btnImportStudents";
            this.btnImportStudents.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // BtnRefresh
            // 
            this.BtnRefresh.Caption = "Refresh";
            this.BtnRefresh.Id = 10;
            this.BtnRefresh.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnRefresh.ImageOptions.SvgImage")));
            this.BtnRefresh.Name = "BtnRefresh";
            this.BtnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnRefresh_ItemClick);
            // 
            // btnOpenCourses
            // 
            this.btnOpenCourses.ActAsDropDown = true;
            this.btnOpenCourses.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.btnOpenCourses.Caption = "Show Open";
            this.btnOpenCourses.DropDownControl = this.puOpen;
            this.btnOpenCourses.Id = 11;
            this.btnOpenCourses.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnOpenCourses.ImageOptions.SvgImage")));
            this.btnOpenCourses.Name = "btnOpenCourses";
            this.btnOpenCourses.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOpenCourses_ItemClick);
            // 
            // puOpen
            // 
            this.puOpen.ItemLinks.Add(this.btnPastOpen, true, "PA");
            this.puOpen.ItemLinks.Add(this.btnNotInvoiced, true, "N");
            this.puOpen.ItemLinks.Add(this.btnPastNotInvoiced);
            this.puOpen.ItemLinks.Add(this.btnPaid);
            this.puOpen.ItemLinks.Add(this.btnNoPaperworkShow, true);
            this.puOpen.Name = "puOpen";
            this.puOpen.Ribbon = this.RibbonControl1;
            // 
            // btnPastOpen
            // 
            this.btnPastOpen.Caption = "Past Open";
            this.btnPastOpen.Id = 27;
            this.btnPastOpen.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnPastOpen.ImageOptions.SvgImage")));
            this.btnPastOpen.Name = "btnPastOpen";
            this.btnPastOpen.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPastOpen_ItemClick);
            // 
            // btnNotInvoiced
            // 
            this.btnNotInvoiced.Caption = "Not Invoiced";
            this.btnNotInvoiced.Id = 28;
            this.btnNotInvoiced.Name = "btnNotInvoiced";
            this.btnNotInvoiced.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNotInvoiced_ItemClick);
            // 
            // btnPastNotInvoiced
            // 
            this.btnPastNotInvoiced.Caption = "Past - Not Invoiced";
            this.btnPastNotInvoiced.Id = 29;
            this.btnPastNotInvoiced.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnPastNotInvoiced.ImageOptions.SvgImage")));
            this.btnPastNotInvoiced.Name = "btnPastNotInvoiced";
            this.btnPastNotInvoiced.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPastNotInvoiced_ItemClick);
            // 
            // btnPaid
            // 
            this.btnPaid.Caption = "Paid - Cert Ready";
            this.btnPaid.Id = 13;
            this.btnPaid.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnPaid.ImageOptions.SvgImage")));
            this.btnPaid.Name = "btnPaid";
            toolTipTitleItem1.Text = "Show certificate ready courses";
            toolTipItem1.LeftIndent = 6;
            toolTipItem1.Text = "This shows the courses where the invoice has been paid and the course is ready to" +
    " be certificated.";
            superToolTip1.Items.Add(toolTipTitleItem1);
            superToolTip1.Items.Add(toolTipItem1);
            this.btnPaid.SuperTip = superToolTip1;
            this.btnPaid.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPaid_ItemClick);
            // 
            // btnNoPaperworkShow
            // 
            this.btnNoPaperworkShow.Caption = "No Paperwork";
            this.btnNoPaperworkShow.Id = 334;
            this.btnNoPaperworkShow.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNoPaperworkShow.ImageOptions.Image")));
            this.btnNoPaperworkShow.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnNoPaperworkShow.ImageOptions.LargeImage")));
            this.btnNoPaperworkShow.Name = "btnNoPaperworkShow";
            this.btnNoPaperworkShow.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNoPaperworkShow_ItemClick);
            // 
            // BtnAllCourses
            // 
            this.BtnAllCourses.Caption = "Show All";
            this.BtnAllCourses.Id = 12;
            this.BtnAllCourses.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnAllCourses.ImageOptions.SvgImage")));
            this.BtnAllCourses.Name = "BtnAllCourses";
            this.BtnAllCourses.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.BtnAllCourses.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnAllCourses_ItemClick);
            // 
            // btnNotSet
            // 
            this.btnNotSet.Caption = "Not Set";
            this.btnNotSet.Id = 13;
            this.btnNotSet.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnNotSet.ImageOptions.SvgImage")));
            this.btnNotSet.Name = "btnNotSet";
            this.btnNotSet.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.btnNotSet.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNotSet_ItemClick);
            // 
            // btnFlagged
            // 
            this.btnFlagged.Caption = "Flagged";
            this.btnFlagged.Id = 14;
            this.btnFlagged.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnFlagged.ImageOptions.SvgImage")));
            this.btnFlagged.Name = "btnFlagged";
            this.btnFlagged.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.btnFlagged.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFlagged_ItemClick);
            // 
            // btnYesterday
            // 
            this.btnYesterday.Caption = "Back";
            this.btnYesterday.Id = 15;
            this.btnYesterday.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnYesterday.ImageOptions.SvgImage")));
            this.btnYesterday.Name = "btnYesterday";
            this.btnYesterday.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.btnYesterday.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnYesterday_ItemClick);
            // 
            // btnToday
            // 
            this.btnToday.Caption = "Today";
            this.btnToday.Id = 16;
            this.btnToday.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnToday.ImageOptions.SvgImage")));
            this.btnToday.Name = "btnToday";
            this.btnToday.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.btnToday.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnToday_ItemClick);
            // 
            // btnTomorrow
            // 
            this.btnTomorrow.Caption = "Forward";
            this.btnTomorrow.Id = 17;
            this.btnTomorrow.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnTomorrow.ImageOptions.SvgImage")));
            this.btnTomorrow.Name = "btnTomorrow";
            this.btnTomorrow.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.btnTomorrow.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTomorrow_ItemClick);
            // 
            // btnLastWeek
            // 
            this.btnLastWeek.Caption = "Back";
            this.btnLastWeek.Id = 18;
            this.btnLastWeek.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnLastWeek.ImageOptions.SvgImage")));
            this.btnLastWeek.Name = "btnLastWeek";
            this.btnLastWeek.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.btnLastWeek.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLastWeek_ItemClick);
            // 
            // btnNextWeek
            // 
            this.btnNextWeek.Caption = "Forward";
            this.btnNextWeek.Id = 19;
            this.btnNextWeek.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnNextWeek.ImageOptions.SvgImage")));
            this.btnNextWeek.Name = "btnNextWeek";
            this.btnNextWeek.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.btnNextWeek.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNextWeek_ItemClick);
            // 
            // btnThisWeek
            // 
            this.btnThisWeek.Caption = "This Week";
            this.btnThisWeek.Id = 20;
            this.btnThisWeek.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnThisWeek.ImageOptions.SvgImage")));
            this.btnThisWeek.Name = "btnThisWeek";
            this.btnThisWeek.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.btnThisWeek.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThisWeek_ItemClick);
            // 
            // btnLastMonth
            // 
            this.btnLastMonth.Caption = "Back";
            this.btnLastMonth.Id = 21;
            this.btnLastMonth.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnLastMonth.ImageOptions.SvgImage")));
            this.btnLastMonth.Name = "btnLastMonth";
            this.btnLastMonth.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.btnLastMonth.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLastMonth_ItemClick);
            // 
            // btnThisMonth
            // 
            this.btnThisMonth.Caption = "This Month";
            this.btnThisMonth.Id = 22;
            this.btnThisMonth.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnThisMonth.ImageOptions.SvgImage")));
            this.btnThisMonth.Name = "btnThisMonth";
            this.btnThisMonth.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.btnThisMonth.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThisMonth_ItemClick);
            // 
            // btnNextMonth
            // 
            this.btnNextMonth.Caption = "Forward";
            this.btnNextMonth.Id = 23;
            this.btnNextMonth.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnNextMonth.ImageOptions.SvgImage")));
            this.btnNextMonth.Name = "btnNextMonth";
            this.btnNextMonth.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.btnNextMonth.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNextMonth_ItemClick);
            // 
            // btnTrainingReturns
            // 
            this.btnTrainingReturns.Caption = "Returns";
            this.btnTrainingReturns.Id = 24;
            this.btnTrainingReturns.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnTrainingReturns.ImageOptions.SvgImage")));
            this.btnTrainingReturns.Name = "btnTrainingReturns";
            this.btnTrainingReturns.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.btnTrainingReturns.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTrainingReturns_ItemClick);
            // 
            // btnStats
            // 
            this.btnStats.Caption = "Stats";
            this.btnStats.Id = 25;
            this.btnStats.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnStats.ImageOptions.SvgImage")));
            this.btnStats.Name = "btnStats";
            this.btnStats.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.btnStats.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnStats_ItemClick);
            // 
            // brUser
            // 
            this.brUser.Caption = "Username";
            this.brUser.Id = 61;
            this.brUser.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("brUser.ImageOptions.SvgImage")));
            this.brUser.Name = "brUser";
            this.brUser.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // brIP
            // 
            this.brIP.Caption = "IPAddress";
            this.brIP.Id = 62;
            this.brIP.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("brIP.ImageOptions.SvgImage")));
            this.brIP.Name = "brIP";
            this.brIP.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // brLoggedUsers
            // 
            this.brLoggedUsers.Caption = "Users";
            this.brLoggedUsers.Id = 63;
            this.brLoggedUsers.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("brLoggedUsers.ImageOptions.SvgImage")));
            this.brLoggedUsers.Name = "brLoggedUsers";
            this.brLoggedUsers.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // brSecurity
            // 
            this.brSecurity.Caption = "Secure NOT Connection";
            this.brSecurity.Id = 64;
            this.brSecurity.Name = "brSecurity";
            // 
            // brSecure
            // 
            this.brSecure.Caption = "Secure Connection";
            this.brSecure.Id = 65;
            this.brSecure.Name = "brSecure";
            // 
            // brShares
            // 
            this.brShares.Caption = "Shares";
            this.brShares.Id = 67;
            this.brShares.Name = "brShares";
            this.brShares.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.brShares_ItemClick);
            // 
            // brVersion
            // 
            this.brVersion.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.brVersion.Caption = "Version";
            this.brVersion.Id = 70;
            this.brVersion.Name = "brVersion";
            // 
            // brWebAccess
            // 
            this.brWebAccess.Caption = "WebAccess";
            this.brWebAccess.Id = 72;
            this.brWebAccess.Name = "brWebAccess";
            this.brWebAccess.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.brWebAccess_ItemClick);
            // 
            // btnClinicalAdd
            // 
            this.btnClinicalAdd.Caption = "Add Shift";
            this.btnClinicalAdd.Id = 92;
            this.btnClinicalAdd.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnClinicalAdd.ImageOptions.SvgImage")));
            this.btnClinicalAdd.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAddSingleShift),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnShiftTemplate)});
            this.btnClinicalAdd.Name = "btnClinicalAdd";
            // 
            // btnAddSingleShift
            // 
            this.btnAddSingleShift.Caption = "Single Shift";
            this.btnAddSingleShift.Id = 143;
            this.btnAddSingleShift.Name = "btnAddSingleShift";
            this.btnAddSingleShift.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAddSingleShift_ItemClick);
            // 
            // btnShiftTemplate
            // 
            this.btnShiftTemplate.Caption = "Template";
            this.btnShiftTemplate.Id = 423;
            this.btnShiftTemplate.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnShiftTemplate.ImageOptions.SvgImage")));
            this.btnShiftTemplate.Name = "btnShiftTemplate";
            this.btnShiftTemplate.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnShiftTemplate_ItemClick);
            // 
            // btnClinicalAudits
            // 
            this.btnClinicalAudits.Caption = "Clinical Audits";
            this.btnClinicalAudits.Id = 93;
            this.btnClinicalAudits.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnClinicalAudits.ImageOptions.SvgImage")));
            this.btnClinicalAudits.Name = "btnClinicalAudits";
            this.btnClinicalAudits.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClinicalAudits_ItemClick);
            // 
            // btnClinicalReports
            // 
            this.btnClinicalReports.Caption = "Clinical Reports";
            this.btnClinicalReports.Id = 94;
            this.btnClinicalReports.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnClinicalReports.ImageOptions.SvgImage")));
            this.btnClinicalReports.Name = "btnClinicalReports";
            this.btnClinicalReports.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClinicalReports_ItemClick);
            // 
            // btnViewbyMedics
            // 
            this.btnViewbyMedics.Caption = "Medics";
            this.btnViewbyMedics.Id = 120;
            this.btnViewbyMedics.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnViewbyMedics.ImageOptions.LargeImage")));
            this.btnViewbyMedics.Name = "btnViewbyMedics";
            this.btnViewbyMedics.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnViewbyMedics_ItemClick);
            // 
            // btnViewbyInstructors
            // 
            this.btnViewbyInstructors.Caption = "Instructors";
            this.btnViewbyInstructors.Id = 121;
            this.btnViewbyInstructors.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnViewbyInstructors.ImageOptions.LargeImage")));
            this.btnViewbyInstructors.Name = "btnViewbyInstructors";
            // 
            // BarEditItem1
            // 
            this.BarEditItem1.Caption = "Show Inactive";
            this.BarEditItem1.Edit = this.RepositoryItemCheckEdit8;
            this.BarEditItem1.Id = 127;
            this.BarEditItem1.Name = "BarEditItem1";
            // 
            // BarSubItem1
            // 
            this.BarSubItem1.Caption = "View By Options";
            this.BarSubItem1.Id = 128;
            this.BarSubItem1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BarSubItem1.ImageOptions.SvgImage")));
            this.BarSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnShowInactive)});
            this.BarSubItem1.Name = "BarSubItem1";
            // 
            // btnShowInactive
            // 
            this.btnShowInactive.Caption = "Show Inactive";
            this.btnShowInactive.Edit = this.repShowInactive;
            this.btnShowInactive.Id = 130;
            this.btnShowInactive.Name = "btnShowInactive";
            this.btnShowInactive.EditValueChanged += new System.EventHandler(this.btnShowInactive_EditValueChanged);
            // 
            // BarEditItem2
            // 
            this.BarEditItem2.Caption = "BarEditItem2";
            this.BarEditItem2.Edit = this.RepositoryItemTextEdit2;
            this.BarEditItem2.Id = 129;
            this.BarEditItem2.Name = "BarEditItem2";
            // 
            // brByCourse
            // 
            this.brByCourse.Caption = "By Course";
            this.brByCourse.Edit = this.repByCourse;
            this.brByCourse.EditWidth = 120;
            this.brByCourse.Id = 136;
            this.brByCourse.Name = "brByCourse";
            this.brByCourse.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.brByCourse.EditValueChanged += new System.EventHandler(this.brByCourse_EditValueChanged);
            // 
            // btnResetPersonnelView
            // 
            this.btnResetPersonnelView.Caption = "Reset View";
            this.btnResetPersonnelView.Id = 141;
            this.btnResetPersonnelView.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnResetPersonnelView.ImageOptions.SvgImage")));
            this.btnResetPersonnelView.Name = "btnResetPersonnelView";
            this.btnResetPersonnelView.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnResetPersonnelView_ItemClick);
            // 
            // btnClinicalStats
            // 
            this.btnClinicalStats.Caption = "Stats";
            this.btnClinicalStats.Id = 152;
            this.btnClinicalStats.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnClinicalStats.ImageOptions.SvgImage")));
            this.btnClinicalStats.Name = "btnClinicalStats";
            this.btnClinicalStats.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClinicalStats_ItemClick);
            // 
            // btnCopy
            // 
            this.btnCopy.Caption = "Copy";
            this.btnCopy.Id = 158;
            this.btnCopy.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnCopy.ImageOptions.SvgImage")));
            this.btnCopy.Name = "btnCopy";
            toolTipTitleItem2.Text = "Copy";
            toolTipItem2.LeftIndent = 6;
            toolTipItem2.Text = "Copies the cell value to the clipboard.";
            superToolTip2.Items.Add(toolTipTitleItem2);
            superToolTip2.Items.Add(toolTipItem2);
            this.btnCopy.SuperTip = superToolTip2;
            this.btnCopy.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCopy_ItemClick);
            // 
            // btnOpenThis
            // 
            this.btnOpenThis.Caption = "Show OPEN like this";
            this.btnOpenThis.Id = 160;
            this.btnOpenThis.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnOpenThis.ImageOptions.SvgImage")));
            this.btnOpenThis.Name = "btnOpenThis";
            this.btnOpenThis.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOpenThis_ItemClick);
            // 
            // btnAllThis
            // 
            this.btnAllThis.Caption = "Show ALL like this";
            this.btnAllThis.Id = 161;
            this.btnAllThis.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnAllThis.ImageOptions.SvgImage")));
            this.btnAllThis.Name = "btnAllThis";
            this.btnAllThis.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAllThis_ItemClick);
            // 
            // btnClearFilter
            // 
            this.btnClearFilter.Caption = "Clear Filter";
            this.btnClearFilter.Id = 162;
            this.btnClearFilter.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnClearFilter.ImageOptions.SvgImage")));
            this.btnClearFilter.Name = "btnClearFilter";
            this.btnClearFilter.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClearFilter_ItemClick);
            // 
            // btnCompanyReport
            // 
            this.btnCompanyReport.Caption = "Company Report";
            this.btnCompanyReport.Id = 163;
            this.btnCompanyReport.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnCompanyReport.ImageOptions.SvgImage")));
            this.btnCompanyReport.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btn7DayReport),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnSummaryReport, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDetailReport),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnTempReport),
            new DevExpress.XtraBars.LinkPersistInfo(this.BarSubItem3, true)});
            this.btnCompanyReport.Name = "btnCompanyReport";
            // 
            // btn7DayReport
            // 
            this.btn7DayReport.Caption = "7 Day Report";
            this.btn7DayReport.Id = 164;
            this.btn7DayReport.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn7DayReport.ImageOptions.Image")));
            this.btn7DayReport.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btn7DayReport.ImageOptions.LargeImage")));
            this.btn7DayReport.Name = "btn7DayReport";
            this.btn7DayReport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn7DayReport_ItemClick);
            // 
            // btnSummaryReport
            // 
            this.btnSummaryReport.Caption = "Summary Report";
            this.btnSummaryReport.Id = 165;
            this.btnSummaryReport.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSummaryReport.ImageOptions.SvgImage")));
            this.btnSummaryReport.Name = "btnSummaryReport";
            this.btnSummaryReport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSummaryReport_ItemClick);
            // 
            // btnDetailReport
            // 
            this.btnDetailReport.Caption = "Detailed Report";
            this.btnDetailReport.Id = 171;
            this.btnDetailReport.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDetailReport.ImageOptions.SvgImage")));
            this.btnDetailReport.Name = "btnDetailReport";
            this.btnDetailReport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDetailReport_ItemClick);
            // 
            // btnTempReport
            // 
            this.btnTempReport.Caption = "Temp Report";
            this.btnTempReport.Id = 166;
            this.btnTempReport.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnTempReport.ImageOptions.SvgImage")));
            this.btnTempReport.Name = "btnTempReport";
            this.btnTempReport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTempReport_ItemClick);
            // 
            // BarSubItem3
            // 
            this.BarSubItem3.Caption = "Monthly Report";
            this.BarSubItem3.Id = 167;
            this.BarSubItem3.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BarSubItem3.ImageOptions.SvgImage")));
            this.BarSubItem3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnThisMonthReport),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnMonthReportLast, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnMonthReportNext)});
            this.BarSubItem3.Name = "BarSubItem3";
            // 
            // btnThisMonthReport
            // 
            this.btnThisMonthReport.Caption = "This Month";
            this.btnThisMonthReport.Id = 168;
            this.btnThisMonthReport.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnThisMonthReport.ImageOptions.SvgImage")));
            this.btnThisMonthReport.Name = "btnThisMonthReport";
            this.btnThisMonthReport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThisMonthReport_ItemClick);
            // 
            // btnMonthReportLast
            // 
            this.btnMonthReportLast.Caption = "Last Month";
            this.btnMonthReportLast.Id = 169;
            this.btnMonthReportLast.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnMonthReportLast.ImageOptions.SvgImage")));
            this.btnMonthReportLast.Name = "btnMonthReportLast";
            this.btnMonthReportLast.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMonthReportLast_ItemClick);
            // 
            // btnMonthReportNext
            // 
            this.btnMonthReportNext.Caption = "Next Month";
            this.btnMonthReportNext.Id = 170;
            this.btnMonthReportNext.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnMonthReportNext.ImageOptions.SvgImage")));
            this.btnMonthReportNext.Name = "btnMonthReportNext";
            this.btnMonthReportNext.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMonthReportNext_ItemClick);
            // 
            // btnConvertLead
            // 
            this.btnConvertLead.Caption = "Convert to Lead";
            this.btnConvertLead.Id = 223;
            this.btnConvertLead.Name = "btnConvertLead";
            this.btnConvertLead.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnConvertLead_ItemClick);
            // 
            // btnConvertTask
            // 
            this.btnConvertTask.Caption = "Convert to Task";
            this.btnConvertTask.Id = 224;
            this.btnConvertTask.Name = "btnConvertTask";
            this.btnConvertTask.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnConvertTask_ItemClick);
            // 
            // brInfo
            // 
            this.brInfo.Caption = "Info";
            this.brInfo.Id = 240;
            this.brInfo.Name = "brInfo";
            this.brInfo.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // btnAddTask
            // 
            this.btnAddTask.Caption = "Add Task";
            this.btnAddTask.Id = 242;
            this.btnAddTask.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnAddTask.ImageOptions.SvgImage")));
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAddTask_ItemClick);
            // 
            // btnAddLead
            // 
            this.btnAddLead.Caption = "Add Lead";
            this.btnAddLead.Id = 243;
            this.btnAddLead.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnAddLead.ImageOptions.SvgImage")));
            this.btnAddLead.Name = "btnAddLead";
            this.btnAddLead.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAddLead_ItemClick);
            // 
            // BtnShiftSheets
            // 
            this.BtnShiftSheets.Caption = "Shift Sheet Email";
            this.BtnShiftSheets.Id = 244;
            this.BtnShiftSheets.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnShiftSheets.ImageOptions.Image")));
            this.BtnShiftSheets.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BtnShiftSheets.ImageOptions.LargeImage")));
            this.BtnShiftSheets.Name = "BtnShiftSheets";
            this.BtnShiftSheets.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnShiftSheets_ItemClick);
            // 
            // btnCourseExpiry
            // 
            this.btnCourseExpiry.Caption = "Course Expiry";
            this.btnCourseExpiry.Enabled = false;
            this.btnCourseExpiry.Id = 245;
            this.btnCourseExpiry.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnCourseExpiry.ImageOptions.SvgImage")));
            this.btnCourseExpiry.Name = "btnCourseExpiry";
            this.btnCourseExpiry.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCourseExpiry_ItemClick);
            // 
            // btnStaffCompliance
            // 
            this.btnStaffCompliance.Caption = "Staff Compliance";
            this.btnStaffCompliance.Id = 246;
            this.btnStaffCompliance.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnStaffCompliance.ImageOptions.Image")));
            this.btnStaffCompliance.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnStaffCompliance.ImageOptions.LargeImage")));
            this.btnStaffCompliance.Name = "btnStaffCompliance";
            toolTipTitleItem3.Text = "Staff Compliance";
            toolTipItem3.LeftIndent = 6;
            toolTipItem3.Text = "Send each medic an email detailing the items missing from their file.";
            superToolTip3.Items.Add(toolTipTitleItem3);
            superToolTip3.Items.Add(toolTipItem3);
            this.btnStaffCompliance.SuperTip = superToolTip3;
            this.btnStaffCompliance.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnStaffCompliance_ItemClick);
            // 
            // btnGlobalCompliance
            // 
            this.btnGlobalCompliance.Caption = "Global Compliance";
            this.btnGlobalCompliance.Id = 249;
            this.btnGlobalCompliance.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnGlobalCompliance.ImageOptions.SvgImage")));
            this.btnGlobalCompliance.Name = "btnGlobalCompliance";
            toolTipTitleItem4.Text = "Global Compliance";
            toolTipItem4.LeftIndent = 6;
            toolTipItem4.Text = "Updated medics compliance % rating. This action is carried out for all Medics who" +
    " are not inactive.";
            superToolTip4.Items.Add(toolTipTitleItem4);
            superToolTip4.Items.Add(toolTipItem4);
            this.btnGlobalCompliance.SuperTip = superToolTip4;
            this.btnGlobalCompliance.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGlobalCompliance_ItemClick);
            // 
            // BarEditItem3
            // 
            this.BarEditItem3.Caption = "BarEditItem3";
            this.BarEditItem3.Edit = this.RepositoryItemMemoEdit1;
            this.BarEditItem3.Id = 250;
            this.BarEditItem3.Name = "BarEditItem3";
            // 
            // btnShowWeb
            // 
            this.btnShowWeb.Caption = "Show Web Courses";
            this.btnShowWeb.Id = 251;
            this.btnShowWeb.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnShowWeb.ImageOptions.SvgImage")));
            this.btnShowWeb.Name = "btnShowWeb";
            this.btnShowWeb.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnShowWeb_ItemClick);
            // 
            // btnAvailability
            // 
            this.btnAvailability.Caption = "Availability";
            this.btnAvailability.Id = 252;
            this.btnAvailability.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnAvailability.ImageOptions.SvgImage")));
            this.btnAvailability.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnMedicsAvailability),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnInstAvailability)});
            this.btnAvailability.Name = "btnAvailability";
            // 
            // btnMedicsAvailability
            // 
            this.btnMedicsAvailability.Caption = "Medics";
            this.btnMedicsAvailability.Id = 253;
            this.btnMedicsAvailability.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnMedicsAvailability.ImageOptions.Image")));
            this.btnMedicsAvailability.Name = "btnMedicsAvailability";
            this.btnMedicsAvailability.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMedicsAvailability_ItemClick);
            // 
            // btnInstAvailability
            // 
            this.btnInstAvailability.Caption = "Instructors";
            this.btnInstAvailability.Id = 254;
            this.btnInstAvailability.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnInstAvailability.ImageOptions.Image")));
            this.btnInstAvailability.Name = "btnInstAvailability";
            this.btnInstAvailability.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnInstAvailability_ItemClick);
            // 
            // btnFilter
            // 
            this.btnFilter.Caption = "Filter";
            this.btnFilter.Id = 259;
            this.btnFilter.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnFilter.ImageOptions.SvgImage")));
            this.btnFilter.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnFilterShift),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnFilterCourse),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnFilterMeeting),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnClearFilter, true)});
            this.btnFilter.Name = "btnFilter";
            // 
            // btnFilterShift
            // 
            this.btnFilterShift.Caption = "Shift";
            this.btnFilterShift.Id = 260;
            this.btnFilterShift.Name = "btnFilterShift";
            this.btnFilterShift.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFilterShift_ItemClick);
            // 
            // btnFilterCourse
            // 
            this.btnFilterCourse.Caption = "Course";
            this.btnFilterCourse.Id = 261;
            this.btnFilterCourse.Name = "btnFilterCourse";
            this.btnFilterCourse.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFilterCourse_ItemClick);
            // 
            // btnFilterMeeting
            // 
            this.btnFilterMeeting.Caption = "Meeting";
            this.btnFilterMeeting.Id = 262;
            this.btnFilterMeeting.Name = "btnFilterMeeting";
            this.btnFilterMeeting.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFilterMeeting_ItemClick);
            // 
            // btnOpenLeads
            // 
            this.btnOpenLeads.Caption = "Open Leads";
            this.btnOpenLeads.Id = 274;
            this.btnOpenLeads.Name = "btnOpenLeads";
            this.btnOpenLeads.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOpenLeads_ItemClick);
            // 
            // btnNewLead
            // 
            this.btnNewLead.Caption = "New Lead";
            this.btnNewLead.Id = 277;
            this.btnNewLead.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNewLead.ImageOptions.Image")));
            this.btnNewLead.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnNewLead.ImageOptions.LargeImage")));
            this.btnNewLead.Name = "btnNewLead";
            this.btnNewLead.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNewLead_ItemClick);
            // 
            // btnAllLeads
            // 
            this.btnAllLeads.Caption = "All Leads";
            this.btnAllLeads.Id = 278;
            this.btnAllLeads.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnAllLeads.ImageOptions.SvgImage")));
            this.btnAllLeads.Name = "btnAllLeads";
            this.btnAllLeads.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAllLeads_ItemClick);
            // 
            // btnClosedLost
            // 
            this.btnClosedLost.Caption = "Closed Lost";
            this.btnClosedLost.Id = 279;
            this.btnClosedLost.Name = "btnClosedLost";
            this.btnClosedLost.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClosedLost_ItemClick);
            // 
            // btnClosedWon
            // 
            this.btnClosedWon.Caption = "Closed Won";
            this.btnClosedWon.Id = 280;
            this.btnClosedWon.Name = "btnClosedWon";
            this.btnClosedWon.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClosedWon_ItemClick);
            // 
            // btnMyLeads
            // 
            this.btnMyLeads.Caption = "My Leads";
            this.btnMyLeads.Id = 282;
            this.btnMyLeads.Name = "btnMyLeads";
            this.btnMyLeads.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMyLeads_ItemClick);
            // 
            // BarEditItem4
            // 
            this.BarEditItem4.Caption = "By Course";
            this.BarEditItem4.Edit = this.RepositoryItemLookUpEdit2;
            this.BarEditItem4.EditWidth = 120;
            this.BarEditItem4.Id = 283;
            this.BarEditItem4.Name = "BarEditItem4";
            this.BarEditItem4.EditValueChanged += new System.EventHandler(this.BarEditItem4_EditValueChanged);
            // 
            // btnReport
            // 
            this.btnReport.ActAsDropDown = true;
            this.btnReport.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.btnReport.Caption = "Report";
            this.btnReport.Id = 304;
            this.btnReport.Name = "btnReport";
            // 
            // btnAddItem
            // 
            this.btnAddItem.ActAsDropDown = true;
            this.btnAddItem.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.btnAddItem.Caption = "Add Item";
            this.btnAddItem.Id = 305;
            this.btnAddItem.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnAddItem.ImageOptions.SvgImage")));
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAddItem_ItemClick);
            // 
            // btnFilterStandards
            // 
            this.btnFilterStandards.Caption = "Standards";
            this.btnFilterStandards.Id = 306;
            this.btnFilterStandards.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnFilterStandards.ImageOptions.Image")));
            this.btnFilterStandards.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnFilterStandards.ImageOptions.LargeImage")));
            this.btnFilterStandards.Name = "btnFilterStandards";
            this.btnFilterStandards.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFilterStandards_ItemClick);
            // 
            // btnFilterPolicies
            // 
            this.btnFilterPolicies.Caption = "Policies";
            this.btnFilterPolicies.Id = 307;
            this.btnFilterPolicies.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnFilterPolicies.ImageOptions.Image")));
            this.btnFilterPolicies.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnFilterPolicies.ImageOptions.LargeImage")));
            this.btnFilterPolicies.Name = "btnFilterPolicies";
            this.btnFilterPolicies.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFilterPolicies_ItemClick);
            // 
            // btnFilterEvidence
            // 
            this.btnFilterEvidence.Caption = "Evidence";
            this.btnFilterEvidence.Id = 308;
            this.btnFilterEvidence.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnFilterEvidence.ImageOptions.Image")));
            this.btnFilterEvidence.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnFilterEvidence.ImageOptions.LargeImage")));
            this.btnFilterEvidence.Name = "btnFilterEvidence";
            this.btnFilterEvidence.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFilterEvidence_ItemClick);
            // 
            // btnFilterKPI
            // 
            this.btnFilterKPI.Caption = "KPI";
            this.btnFilterKPI.Id = 309;
            this.btnFilterKPI.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnFilterKPI.ImageOptions.SvgImage")));
            this.btnFilterKPI.Name = "btnFilterKPI";
            this.btnFilterKPI.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFilterKPI_ItemClick);
            // 
            // btnFilterViewAll
            // 
            this.btnFilterViewAll.Caption = "View All";
            this.btnFilterViewAll.Id = 310;
            this.btnFilterViewAll.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnFilterViewAll.ImageOptions.SvgImage")));
            this.btnFilterViewAll.Name = "btnFilterViewAll";
            this.btnFilterViewAll.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFilterViewAll_ItemClick);
            // 
            // btnExpandAll
            // 
            this.btnExpandAll.Caption = "Expand All";
            this.btnExpandAll.Id = 311;
            this.btnExpandAll.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExpandAll.ImageOptions.Image")));
            this.btnExpandAll.Name = "btnExpandAll";
            this.btnExpandAll.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.btnExpandAll.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExpandAll_ItemClick);
            // 
            // btnCollapseAll
            // 
            this.btnCollapseAll.Caption = "Collapse All";
            this.btnCollapseAll.Id = 312;
            this.btnCollapseAll.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCollapseAll.ImageOptions.Image")));
            this.btnCollapseAll.Name = "btnCollapseAll";
            this.btnCollapseAll.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.btnCollapseAll.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCollapseAll_ItemClick);
            // 
            // btnWorkDiary
            // 
            this.btnWorkDiary.Caption = "Work Diary";
            this.btnWorkDiary.Id = 326;
            this.btnWorkDiary.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnWorkDiary.ImageOptions.SvgImage")));
            this.btnWorkDiary.Name = "btnWorkDiary";
            this.btnWorkDiary.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnWorkDiary_ItemClick);
            // 
            // btnSortName
            // 
            this.btnSortName.Caption = "Name";
            this.btnSortName.Id = 334;
            this.btnSortName.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSortName.ImageOptions.SvgImage")));
            this.btnSortName.Name = "btnSortName";
            // 
            // btnSortLocation
            // 
            this.btnSortLocation.Caption = "County";
            this.btnSortLocation.Id = 335;
            this.btnSortLocation.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSortLocation.ImageOptions.SvgImage")));
            this.btnSortLocation.Name = "btnSortLocation";
            // 
            // btnMap
            // 
            this.btnMap.Caption = "View Map";
            this.btnMap.Id = 336;
            this.btnMap.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnMap.ImageOptions.SvgImage")));
            this.btnMap.Name = "btnMap";
            this.btnMap.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMap_ItemClick);
            // 
            // brProgress
            // 
            this.brProgress.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.brProgress.Caption = "Progress";
            this.brProgress.Edit = this.RepositoryItemProgressBar1;
            this.brProgress.EditWidth = 150;
            this.brProgress.Id = 342;
            this.brProgress.Name = "brProgress";
            this.brProgress.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // btnGridExpand
            // 
            this.btnGridExpand.Caption = "Expand";
            this.btnGridExpand.Id = 357;
            this.btnGridExpand.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGridExpand.ImageOptions.Image")));
            this.btnGridExpand.Name = "btnGridExpand";
            this.btnGridExpand.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.btnGridExpand.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExpandGrid_ItemClick);
            // 
            // btnSanity
            // 
            this.btnSanity.Caption = "Sanity Check";
            this.btnSanity.Id = 360;
            this.btnSanity.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSanity.ImageOptions.SvgImage")));
            this.btnSanity.Name = "btnSanity";
            // 
            // btnFilterTask
            // 
            this.btnFilterTask.Caption = "Task";
            this.btnFilterTask.Id = 364;
            this.btnFilterTask.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnFilterTask.ImageOptions.SvgImage")));
            this.btnFilterTask.Name = "btnFilterTask";
            this.btnFilterTask.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFilterTask_ItemClick);
            // 
            // btnFilterLead
            // 
            this.btnFilterLead.Caption = "Lead";
            this.btnFilterLead.Id = 365;
            this.btnFilterLead.Name = "btnFilterLead";
            this.btnFilterLead.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFilterLead_ItemClick);
            // 
            // btnFilterEmail
            // 
            this.btnFilterEmail.Caption = "Email";
            this.btnFilterEmail.Id = 366;
            this.btnFilterEmail.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnFilterEmail.ImageOptions.SvgImage")));
            this.btnFilterEmail.Name = "btnFilterEmail";
            this.btnFilterEmail.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFilterEmail_ItemClick);
            // 
            // BarButtonItem9
            // 
            this.BarButtonItem9.Caption = "Show All";
            this.BarButtonItem9.Id = 367;
            this.BarButtonItem9.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BarButtonItem9.ImageOptions.SvgImage")));
            this.BarButtonItem9.Name = "BarButtonItem9";
            this.BarButtonItem9.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.BarButtonItem9.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItem9_ItemClick);
            // 
            // btnOpenGov
            // 
            this.btnOpenGov.Caption = "Open";
            this.btnOpenGov.Id = 372;
            this.btnOpenGov.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnOpenGov.ImageOptions.SvgImage")));
            this.btnOpenGov.Name = "btnOpenGov";
            this.btnOpenGov.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOpenGov_ItemClick);
            // 
            // btnRemoveItem
            // 
            this.btnRemoveItem.Caption = "Remove Item";
            this.btnRemoveItem.Id = 373;
            this.btnRemoveItem.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnRemoveItem.ImageOptions.SvgImage")));
            this.btnRemoveItem.Name = "btnRemoveItem";
            this.btnRemoveItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRemoveItem_ItemClick);
            // 
            // btnFindReferences
            // 
            this.btnFindReferences.Caption = "Find References";
            this.btnFindReferences.Id = 374;
            this.btnFindReferences.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnFindReferences.ImageOptions.SvgImage")));
            this.btnFindReferences.Name = "btnFindReferences";
            this.btnFindReferences.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFindReferences_ItemClick);
            // 
            // btnOpenItem
            // 
            this.btnOpenItem.Caption = "Open Item";
            this.btnOpenItem.Id = 375;
            this.btnOpenItem.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnOpenItem.ImageOptions.SvgImage")));
            this.btnOpenItem.Name = "btnOpenItem";
            this.btnOpenItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOpenItem_ItemClick);
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Caption = "Open File";
            this.btnOpenFile.Id = 376;
            this.btnOpenFile.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenFile.ImageOptions.Image")));
            this.btnOpenFile.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnOpenFile.ImageOptions.LargeImage")));
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOpenFile_ItemClick);
            // 
            // btnRename
            // 
            this.btnRename.Caption = "Rename";
            this.btnRename.Id = 377;
            this.btnRename.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnRename.ImageOptions.SvgImage")));
            this.btnRename.Name = "btnRename";
            this.btnRename.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRename_ItemClick);
            // 
            // btnCopyItem
            // 
            this.btnCopyItem.Caption = "Copy";
            this.btnCopyItem.Id = 378;
            this.btnCopyItem.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnCopyItem.ImageOptions.SvgImage")));
            this.btnCopyItem.Name = "btnCopyItem";
            this.btnCopyItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCopyItem_ItemClick);
            // 
            // btnNewSection
            // 
            this.btnNewSection.Caption = "New Section";
            this.btnNewSection.Id = 379;
            this.btnNewSection.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnNewSection.ImageOptions.SvgImage")));
            this.btnNewSection.Name = "btnNewSection";
            this.btnNewSection.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNewSection_ItemClick);
            // 
            // btnRemoveItemGov
            // 
            this.btnRemoveItemGov.Caption = "Remove Item";
            this.btnRemoveItemGov.Id = 380;
            this.btnRemoveItemGov.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnRemoveItemGov.ImageOptions.SvgImage")));
            this.btnRemoveItemGov.Name = "btnRemoveItemGov";
            this.btnRemoveItemGov.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRemoveItemGov_ItemClick);
            // 
            // BarEditItem5
            // 
            this.BarEditItem5.Caption = "BarEditItem5";
            this.BarEditItem5.Edit = this.RepositoryItemTextEdit3;
            this.BarEditItem5.Id = 381;
            this.BarEditItem5.Name = "BarEditItem5";
            // 
            // BarSubItem2
            // 
            this.BarSubItem2.Caption = "Add / New";
            this.BarSubItem2.Id = 382;
            this.BarSubItem2.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BarSubItem2.ImageOptions.SvgImage")));
            this.BarSubItem2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAddStandard),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAddPolicy),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAddLegislation),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAddGuideline),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAddEvidence),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAddKPI),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAddGovTask)});
            this.BarSubItem2.Name = "BarSubItem2";
            // 
            // btnAddStandard
            // 
            this.btnAddStandard.Caption = "Assign Standard";
            this.btnAddStandard.Id = 385;
            this.btnAddStandard.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAddStandard.ImageOptions.Image")));
            this.btnAddStandard.Name = "btnAddStandard";
            this.btnAddStandard.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAddStandard_ItemClick);
            // 
            // btnAddPolicy
            // 
            this.btnAddPolicy.Caption = "Add Policy";
            this.btnAddPolicy.Id = 386;
            this.btnAddPolicy.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAddPolicy.ImageOptions.Image")));
            this.btnAddPolicy.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnAddPolicy.ImageOptions.LargeImage")));
            this.btnAddPolicy.Name = "btnAddPolicy";
            this.btnAddPolicy.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAddPolicy_ItemClick);
            // 
            // btnAddLegislation
            // 
            this.btnAddLegislation.Caption = "New Legislation";
            this.btnAddLegislation.Id = 387;
            this.btnAddLegislation.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAddLegislation.ImageOptions.Image")));
            this.btnAddLegislation.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnAddLegislation.ImageOptions.LargeImage")));
            this.btnAddLegislation.Name = "btnAddLegislation";
            this.btnAddLegislation.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAddLegislation_ItemClick);
            // 
            // btnAddGuideline
            // 
            this.btnAddGuideline.Caption = "New Guideline";
            this.btnAddGuideline.Id = 388;
            this.btnAddGuideline.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnAddGuideline.ImageOptions.SvgImage")));
            this.btnAddGuideline.Name = "btnAddGuideline";
            this.btnAddGuideline.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAddGuideline_ItemClick);
            // 
            // btnAddEvidence
            // 
            this.btnAddEvidence.Caption = "Add Evidence";
            this.btnAddEvidence.Id = 389;
            this.btnAddEvidence.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAddEvidence.ImageOptions.Image")));
            this.btnAddEvidence.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnAddEvidence.ImageOptions.LargeImage")));
            this.btnAddEvidence.Name = "btnAddEvidence";
            this.btnAddEvidence.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAddEvidence_ItemClick);
            // 
            // btnAddKPI
            // 
            this.btnAddKPI.Caption = "New KPI";
            this.btnAddKPI.Id = 390;
            this.btnAddKPI.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnAddKPI.ImageOptions.SvgImage")));
            this.btnAddKPI.Name = "btnAddKPI";
            this.btnAddKPI.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAddKPI_ItemClick);
            // 
            // btnAddGovTask
            // 
            this.btnAddGovTask.Caption = "New Task";
            this.btnAddGovTask.Id = 396;
            this.btnAddGovTask.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnAddGovTask.ImageOptions.SvgImage")));
            this.btnAddGovTask.Name = "btnAddGovTask";
            this.btnAddGovTask.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAddGovTask_ItemClick);
            // 
            // BarSubItem4
            // 
            this.BarSubItem4.Caption = "Move Item";
            this.BarSubItem4.Id = 383;
            this.BarSubItem4.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BarSubItem4.ImageOptions.Image")));
            this.BarSubItem4.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BarSubItem4.ImageOptions.LargeImage")));
            this.BarSubItem4.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnMoveUp),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnMoveDown)});
            this.BarSubItem4.Name = "BarSubItem4";
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Caption = "Move Up";
            this.btnMoveUp.Id = 392;
            this.btnMoveUp.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnMoveUp.ImageOptions.SvgImage")));
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMoveUp_ItemClick);
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Caption = "Move Down";
            this.btnMoveDown.Id = 393;
            this.btnMoveDown.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnMoveDown.ImageOptions.SvgImage")));
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMoveDown_ItemClick);
            // 
            // BarSubItem5
            // 
            this.BarSubItem5.Caption = "Expand / Collapse";
            this.BarSubItem5.Id = 384;
            this.BarSubItem5.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BarSubItem5.ImageOptions.SvgImage")));
            this.BarSubItem5.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnExpandTree),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnCollapseTree)});
            this.BarSubItem5.Name = "BarSubItem5";
            // 
            // btnExpandTree
            // 
            this.btnExpandTree.Caption = "Expand";
            this.btnExpandTree.Id = 394;
            this.btnExpandTree.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnExpandTree.ImageOptions.SvgImage")));
            this.btnExpandTree.Name = "btnExpandTree";
            this.btnExpandTree.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExpandTree_ItemClick);
            // 
            // btnCollapseTree
            // 
            this.btnCollapseTree.Caption = "Collapse";
            this.btnCollapseTree.Id = 395;
            this.btnCollapseTree.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCollapseTree.ImageOptions.Image")));
            this.btnCollapseTree.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnCollapseTree.ImageOptions.LargeImage")));
            this.btnCollapseTree.Name = "btnCollapseTree";
            this.btnCollapseTree.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCollapseTree_ItemClick);
            // 
            // BarButtonItem10
            // 
            this.BarButtonItem10.Caption = "New User";
            this.BarButtonItem10.Id = 403;
            this.BarButtonItem10.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BarButtonItem10.ImageOptions.LargeImage")));
            this.BarButtonItem10.Name = "BarButtonItem10";
            // 
            // BarButtonItem11
            // 
            this.BarButtonItem11.Caption = "Print Grid";
            this.BarButtonItem11.Id = 427;
            this.BarButtonItem11.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BarButtonItem11.ImageOptions.SvgImage")));
            this.BarButtonItem11.Name = "BarButtonItem11";
            // 
            // btnAddNote
            // 
            this.btnAddNote.Caption = "Add Note";
            this.btnAddNote.Id = 434;
            this.btnAddNote.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnAddNote.ImageOptions.SvgImage")));
            this.btnAddNote.Name = "btnAddNote";
            this.btnAddNote.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAddNote_ItemClick);
            // 
            // EditAppointmentQueryItem1
            // 
            this.EditAppointmentQueryItem1.Id = 440;
            this.EditAppointmentQueryItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.EditOccurrenceUICommandItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.EditSeriesUICommandItem1)});
            this.EditAppointmentQueryItem1.Name = "EditAppointmentQueryItem1";
            this.EditAppointmentQueryItem1.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // EditOccurrenceUICommandItem1
            // 
            this.EditOccurrenceUICommandItem1.Id = 441;
            this.EditOccurrenceUICommandItem1.Name = "EditOccurrenceUICommandItem1";
            // 
            // EditSeriesUICommandItem1
            // 
            this.EditSeriesUICommandItem1.Id = 442;
            this.EditSeriesUICommandItem1.Name = "EditSeriesUICommandItem1";
            // 
            // DeleteAppointmentsItem1
            // 
            this.DeleteAppointmentsItem1.Id = 443;
            this.DeleteAppointmentsItem1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("DeleteAppointmentsItem1.ImageOptions.SvgImage")));
            this.DeleteAppointmentsItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.DeleteOccurrenceItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.DeleteSeriesItem1)});
            this.DeleteAppointmentsItem1.Name = "DeleteAppointmentsItem1";
            this.DeleteAppointmentsItem1.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // DeleteOccurrenceItem1
            // 
            this.DeleteOccurrenceItem1.Id = 444;
            this.DeleteOccurrenceItem1.Name = "DeleteOccurrenceItem1";
            // 
            // DeleteSeriesItem1
            // 
            this.DeleteSeriesItem1.Id = 445;
            this.DeleteSeriesItem1.Name = "DeleteSeriesItem1";
            // 
            // SplitAppointmentItem1
            // 
            this.SplitAppointmentItem1.Id = 446;
            this.SplitAppointmentItem1.Name = "SplitAppointmentItem1";
            // 
            // ChangeAppointmentStatusItem1
            // 
            this.ChangeAppointmentStatusItem1.Id = 447;
            this.ChangeAppointmentStatusItem1.Name = "ChangeAppointmentStatusItem1";
            // 
            // ChangeAppointmentLabelItem1
            // 
            this.ChangeAppointmentLabelItem1.Id = 448;
            this.ChangeAppointmentLabelItem1.Name = "ChangeAppointmentLabelItem1";
            // 
            // ToggleRecurrenceItem1
            // 
            this.ToggleRecurrenceItem1.Id = 449;
            this.ToggleRecurrenceItem1.Name = "ToggleRecurrenceItem1";
            // 
            // ChangeAppointmentReminderItem1
            // 
            this.ChangeAppointmentReminderItem1.Edit = this.RepositoryItemDuration1;
            this.ChangeAppointmentReminderItem1.Id = 450;
            this.ChangeAppointmentReminderItem1.Name = "ChangeAppointmentReminderItem1";
            // 
            // btnAddAppointment
            // 
            this.btnAddAppointment.Caption = "Add Appointment";
            this.btnAddAppointment.Id = 452;
            this.btnAddAppointment.Name = "btnAddAppointment";
            // 
            // btnAddDocument
            // 
            this.btnAddDocument.Caption = "Add Document";
            this.btnAddDocument.Id = 457;
            this.btnAddDocument.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnAddDocument.ImageOptions.SvgImage")));
            this.btnAddDocument.Name = "btnAddDocument";
            this.btnAddDocument.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAddDocument_ItemClick);
            // 
            // BarButtonItem13
            // 
            this.BarButtonItem13.Caption = "Current";
            this.BarButtonItem13.Id = 460;
            this.BarButtonItem13.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BarButtonItem13.ImageOptions.SvgImage")));
            this.BarButtonItem13.Name = "BarButtonItem13";
            this.BarButtonItem13.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItem13_ItemClick);
            // 
            // BarButtonItem14
            // 
            this.BarButtonItem14.Caption = "Show All";
            this.BarButtonItem14.Id = 461;
            this.BarButtonItem14.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BarButtonItem14.ImageOptions.SvgImage")));
            this.BarButtonItem14.Name = "BarButtonItem14";
            this.BarButtonItem14.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItem14_ItemClick);
            // 
            // BarButtonItem15
            // 
            this.BarButtonItem15.Caption = "Add Risk";
            this.BarButtonItem15.Id = 469;
            this.BarButtonItem15.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BarButtonItem15.ImageOptions.SvgImage")));
            this.BarButtonItem15.Name = "BarButtonItem15";
            this.BarButtonItem15.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItem15_ItemClick);
            // 
            // btnViewOptions
            // 
            this.btnViewOptions.Caption = "Grid Options";
            this.btnViewOptions.Id = 496;
            this.btnViewOptions.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnViewOptions.ImageOptions.SvgImage")));
            this.btnViewOptions.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnViewFooter),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnViewFilter),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnFooterFilter),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnViewFind),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnHorLines),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnVerticalLInes),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnCellMerge),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnShowGrouped),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnIndentRow),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnOddRow),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnGroupColour),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnShowGroupSummary),
            new DevExpress.XtraBars.LinkPersistInfo(this.BtnColourGroupRow)});
            this.btnViewOptions.Name = "btnViewOptions";
            // 
            // btnViewFooter
            // 
            this.btnViewFooter.Caption = "View Footer";
            this.btnViewFooter.Id = 497;
            this.btnViewFooter.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnViewFooter.ImageOptions.SvgImage")));
            this.btnViewFooter.Name = "btnViewFooter";
            this.btnViewFooter.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnViewFooter_ItemClick);
            // 
            // btnViewFilter
            // 
            this.btnViewFilter.Caption = "View Filter";
            this.btnViewFilter.Id = 498;
            this.btnViewFilter.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnViewFilter.ImageOptions.SvgImage")));
            this.btnViewFilter.Name = "btnViewFilter";
            this.btnViewFilter.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnViewFilter_ItemClick);
            // 
            // btnFooterFilter
            // 
            this.btnFooterFilter.Caption = "View Footer Filter";
            this.btnFooterFilter.Id = 499;
            this.btnFooterFilter.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnFooterFilter.ImageOptions.SvgImage")));
            this.btnFooterFilter.Name = "btnFooterFilter";
            this.btnFooterFilter.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFooterFilter_ItemClick);
            // 
            // btnViewFind
            // 
            this.btnViewFind.Caption = "View Find";
            this.btnViewFind.Id = 500;
            this.btnViewFind.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnViewFind.ImageOptions.SvgImage")));
            this.btnViewFind.Name = "btnViewFind";
            this.btnViewFind.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnViewFind_ItemClick);
            // 
            // btnHorLines
            // 
            this.btnHorLines.Caption = "Horizontal Lines";
            this.btnHorLines.Id = 502;
            this.btnHorLines.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnHorLines.ImageOptions.SvgImage")));
            this.btnHorLines.Name = "btnHorLines";
            this.btnHorLines.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnHorLines_ItemClick);
            // 
            // btnVerticalLInes
            // 
            this.btnVerticalLInes.Caption = "Vertical Lines";
            this.btnVerticalLInes.Id = 503;
            this.btnVerticalLInes.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnVerticalLInes.ImageOptions.SvgImage")));
            this.btnVerticalLInes.Name = "btnVerticalLInes";
            this.btnVerticalLInes.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnVerticalLInes_ItemClick);
            // 
            // btnCellMerge
            // 
            this.btnCellMerge.Caption = "Cell Merge";
            this.btnCellMerge.Id = 511;
            this.btnCellMerge.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnCellMerge.ImageOptions.SvgImage")));
            this.btnCellMerge.Name = "btnCellMerge";
            this.btnCellMerge.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCellMerge_ItemClick);
            // 
            // btnShowGrouped
            // 
            this.btnShowGrouped.Caption = "Show Grouped Columns";
            this.btnShowGrouped.Id = 518;
            this.btnShowGrouped.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnShowGrouped.ImageOptions.SvgImage")));
            this.btnShowGrouped.Name = "btnShowGrouped";
            this.btnShowGrouped.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnShowGrouped_ItemClick);
            // 
            // btnIndentRow
            // 
            this.btnIndentRow.Caption = "Indent Group Rows";
            this.btnIndentRow.Id = 29;
            this.btnIndentRow.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnIndentRow.ImageOptions.SvgImage")));
            this.btnIndentRow.Name = "btnIndentRow";
            this.btnIndentRow.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnIndentRow_ItemClick);
            // 
            // btnOddRow
            // 
            this.btnOddRow.Caption = "Odd Row Colour";
            this.btnOddRow.Id = 569;
            this.btnOddRow.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnOddRow.ImageOptions.SvgImage")));
            this.btnOddRow.Name = "btnOddRow";
            this.btnOddRow.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOddRow_ItemClick);
            // 
            // btnGroupColour
            // 
            this.btnGroupColour.Caption = "Colour Groupings";
            this.btnGroupColour.Id = 32;
            this.btnGroupColour.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnGroupColour.ImageOptions.SvgImage")));
            this.btnGroupColour.Name = "btnGroupColour";
            this.btnGroupColour.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGroupColour_ItemClick);
            // 
            // btnShowGroupSummary
            // 
            this.btnShowGroupSummary.Caption = "Show Group Summary";
            this.btnShowGroupSummary.Id = 41;
            this.btnShowGroupSummary.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnShowGroupSummary.ImageOptions.SvgImage")));
            this.btnShowGroupSummary.Name = "btnShowGroupSummary";
            this.btnShowGroupSummary.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnShowGroupSummary_ItemClick);
            // 
            // BtnColourGroupRow
            // 
            this.BtnColourGroupRow.Caption = "Colour Group Row";
            this.BtnColourGroupRow.Id = 99;
            this.BtnColourGroupRow.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnColourGroupRow.ImageOptions.SvgImage")));
            this.BtnColourGroupRow.Name = "BtnColourGroupRow";
            this.BtnColourGroupRow.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnColourGroupRow_ItemClick);
            // 
            // btnAddInfo
            // 
            this.btnAddInfo.Caption = "Add Record";
            this.btnAddInfo.Id = 514;
            this.btnAddInfo.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnAddInfo.ImageOptions.SvgImage")));
            this.btnAddInfo.Name = "btnAddInfo";
            this.btnAddInfo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAddInfo_ItemClick);
            // 
            // BarButtonItem18
            // 
            this.BarButtonItem18.Caption = "Add Audit";
            this.BarButtonItem18.Id = 522;
            this.BarButtonItem18.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BarButtonItem18.ImageOptions.SvgImage")));
            this.BarButtonItem18.Name = "BarButtonItem18";
            this.BarButtonItem18.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItem18_ItemClick);
            // 
            // btnForReview
            // 
            this.btnForReview.Caption = "For Review";
            this.btnForReview.Id = 533;
            this.btnForReview.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnForReview.ImageOptions.LargeImage")));
            this.btnForReview.Name = "btnForReview";
            this.btnForReview.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnForReview_ItemClick);
            // 
            // btnViewOpen
            // 
            this.btnViewOpen.Caption = "Open";
            this.btnViewOpen.Id = 539;
            this.btnViewOpen.Name = "btnViewOpen";
            this.btnViewOpen.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItem3_ItemClick);
            // 
            // btnShowAll
            // 
            this.btnShowAll.Caption = "Show All";
            this.btnShowAll.Id = 540;
            this.btnShowAll.Name = "btnShowAll";
            // 
            // BarListItem1
            // 
            this.BarListItem1.Caption = "BarListItem1";
            this.BarListItem1.Id = 542;
            this.BarListItem1.Name = "BarListItem1";
            // 
            // BarButtonItem19
            // 
            this.BarButtonItem19.Caption = "Card View";
            this.BarButtonItem19.Id = 548;
            this.BarButtonItem19.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BarButtonItem19.ImageOptions.Image")));
            this.BarButtonItem19.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BarButtonItem19.ImageOptions.LargeImage")));
            this.BarButtonItem19.Name = "BarButtonItem19";
            // 
            // btnGridCollapse
            // 
            this.btnGridCollapse.Caption = "Collapse";
            this.btnGridCollapse.Id = 551;
            this.btnGridCollapse.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGridCollapse.ImageOptions.Image")));
            this.btnGridCollapse.Name = "btnGridCollapse";
            this.btnGridCollapse.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGridCollapse_ItemClick);
            // 
            // btnGridExport
            // 
            this.btnGridExport.Caption = "Export";
            this.btnGridExport.Id = 552;
            this.btnGridExport.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnGridExport.ImageOptions.SvgImage")));
            this.btnGridExport.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnExportSelected),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnGridExportPDF, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnGridExportCSV),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnGridExportExcel),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnGridExportHtml),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.KeyTip, this.btnBatchExportCourse, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.Standard, "", ""),
            new DevExpress.XtraBars.LinkPersistInfo(this.BarButtonItem24, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.BarButtonItem26)});
            this.btnGridExport.Name = "btnGridExport";
            // 
            // btnExportSelected
            // 
            this.btnExportSelected.BindableChecked = true;
            this.btnExportSelected.Caption = "Selected Only";
            this.btnExportSelected.Checked = true;
            this.btnExportSelected.Hint = "Export only items selected with the Grid Checkbox";
            this.btnExportSelected.Id = 558;
            this.btnExportSelected.Name = "btnExportSelected";
            // 
            // btnGridExportPDF
            // 
            this.btnGridExportPDF.Caption = "Export PDF";
            this.btnGridExportPDF.Id = 553;
            this.btnGridExportPDF.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGridExportPDF.ImageOptions.Image")));
            this.btnGridExportPDF.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnGridExportPDF.ImageOptions.LargeImage")));
            this.btnGridExportPDF.Name = "btnGridExportPDF";
            this.btnGridExportPDF.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGridExportPDF_ItemClick);
            // 
            // btnGridExportCSV
            // 
            this.btnGridExportCSV.Caption = "Export CSV";
            this.btnGridExportCSV.Id = 556;
            this.btnGridExportCSV.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGridExportCSV.ImageOptions.Image")));
            this.btnGridExportCSV.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnGridExportCSV.ImageOptions.LargeImage")));
            this.btnGridExportCSV.Name = "btnGridExportCSV";
            this.btnGridExportCSV.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGridExportCSV_ItemClick);
            // 
            // btnGridExportExcel
            // 
            this.btnGridExportExcel.Caption = "Export Excel";
            this.btnGridExportExcel.Id = 555;
            this.btnGridExportExcel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGridExportExcel.ImageOptions.Image")));
            this.btnGridExportExcel.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnGridExportExcel.ImageOptions.LargeImage")));
            this.btnGridExportExcel.Name = "btnGridExportExcel";
            this.btnGridExportExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGridExportExcel_ItemClick);
            // 
            // btnGridExportHtml
            // 
            this.btnGridExportHtml.Caption = "Export Html";
            this.btnGridExportHtml.Id = 557;
            this.btnGridExportHtml.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGridExportHtml.ImageOptions.Image")));
            this.btnGridExportHtml.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnGridExportHtml.ImageOptions.LargeImage")));
            this.btnGridExportHtml.Name = "btnGridExportHtml";
            this.btnGridExportHtml.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGridExportHtml_ItemClick);
            // 
            // BarButtonItem24
            // 
            this.BarButtonItem24.Caption = "Moodle Format";
            this.BarButtonItem24.Id = 25;
            this.BarButtonItem24.Name = "BarButtonItem24";
            // 
            // BarButtonItem26
            // 
            this.BarButtonItem26.Caption = "Email List";
            this.BarButtonItem26.Id = 28;
            this.BarButtonItem26.Name = "BarButtonItem26";
            this.BarButtonItem26.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItem26_ItemClick_1);
            // 
            // btnGridExportXLXS
            // 
            this.btnGridExportXLXS.Caption = "Export .XLXS";
            this.btnGridExportXLXS.Id = 554;
            this.btnGridExportXLXS.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGridExportXLXS.ImageOptions.Image")));
            this.btnGridExportXLXS.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnGridExportXLXS.ImageOptions.LargeImage")));
            this.btnGridExportXLXS.Name = "btnGridExportXLXS";
            // 
            // btnGridExportWord
            // 
            this.btnGridExportWord.Caption = "Export Word";
            this.btnGridExportWord.Id = 559;
            this.btnGridExportWord.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGridExportWord.ImageOptions.Image")));
            this.btnGridExportWord.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnGridExportWord.ImageOptions.LargeImage")));
            this.btnGridExportWord.Name = "btnGridExportWord";
            // 
            // btnGridPrint
            // 
            this.btnGridPrint.Caption = "Print";
            this.btnGridPrint.Id = 562;
            this.btnGridPrint.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnGridPrint.ImageOptions.SvgImage")));
            this.btnGridPrint.Name = "btnGridPrint";
            this.btnGridPrint.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.btnGridPrint.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGridPrint_ItemClick);
            // 
            // BarButtonItem5
            // 
            this.BarButtonItem5.Caption = "Calculator";
            this.BarButtonItem5.Id = 572;
            this.BarButtonItem5.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BarButtonItem5.ImageOptions.SvgImage")));
            this.BarButtonItem5.Name = "BarButtonItem5";
            // 
            // btnCopyValue
            // 
            this.btnCopyValue.Caption = "Copy";
            this.btnCopyValue.Id = 306;
            this.btnCopyValue.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnCopyValue.ImageOptions.SvgImage")));
            this.btnCopyValue.Name = "btnCopyValue";
            this.btnCopyValue.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCopyValue_ItemClick);
            // 
            // btnCourseCurrent
            // 
            this.btnCourseCurrent.Caption = "Current";
            this.btnCourseCurrent.Id = 308;
            this.btnCourseCurrent.Name = "btnCourseCurrent";
            this.btnCourseCurrent.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCourseCurrent_ItemClick);
            // 
            // btnFilterBy
            // 
            this.btnFilterBy.Caption = "Filter";
            this.btnFilterBy.Id = 317;
            this.btnFilterBy.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnFilterBy.ImageOptions.SvgImage")));
            this.btnFilterBy.Name = "btnFilterBy";
            this.btnFilterBy.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            // 
            // BarButtonItem20
            // 
            this.BarButtonItem20.ActAsDropDown = true;
            this.BarButtonItem20.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.BarButtonItem20.Caption = "Personnel Reports";
            this.BarButtonItem20.Id = 320;
            this.BarButtonItem20.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BarButtonItem20.ImageOptions.LargeImage")));
            this.BarButtonItem20.Name = "BarButtonItem20";
            // 
            // BarSubItem6
            // 
            this.BarSubItem6.Caption = "Personnel Reports";
            this.BarSubItem6.Id = 323;
            this.BarSubItem6.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BarSubItem6.ImageOptions.SvgImage")));
            this.BarSubItem6.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnPersonClinicalReport)});
            this.BarSubItem6.Name = "BarSubItem6";
            // 
            // btnPersonClinicalReport
            // 
            this.btnPersonClinicalReport.Caption = "Insufficient Information";
            this.btnPersonClinicalReport.Id = 324;
            this.btnPersonClinicalReport.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnPersonClinicalReport.ImageOptions.SvgImage")));
            this.btnPersonClinicalReport.Name = "btnPersonClinicalReport";
            this.btnPersonClinicalReport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPersonClinicalReport_ItemClick);
            // 
            // btnFutureTasks
            // 
            this.btnFutureTasks.Caption = "Future Tasks";
            this.btnFutureTasks.Id = 358;
            this.btnFutureTasks.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnFutureTasks.ImageOptions.SvgImage")));
            this.btnFutureTasks.Name = "btnFutureTasks";
            this.btnFutureTasks.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFutureTasks_ItemClick);
            // 
            // btnResetInbox
            // 
            this.btnResetInbox.Caption = "Reset";
            this.btnResetInbox.Id = 359;
            this.btnResetInbox.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnResetInbox.ImageOptions.SvgImage")));
            this.btnResetInbox.Name = "btnResetInbox";
            this.btnResetInbox.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.btnResetInbox.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnResetInbox_ItemClick);
            // 
            // btnMedicReminders
            // 
            this.btnMedicReminders.Caption = "Medic Reminders";
            this.btnMedicReminders.Id = 365;
            this.btnMedicReminders.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnMedicReminders.ImageOptions.LargeImage")));
            this.btnMedicReminders.Name = "btnMedicReminders";
            toolTipTitleItem5.Text = "Medics Reminders";
            toolTipItem5.LeftIndent = 6;
            toolTipItem5.Text = "Send an email reminder to the medics about the shifts they have coming up from th" +
    "e following Monday - Sunday inclusive.";
            superToolTip5.Items.Add(toolTipTitleItem5);
            superToolTip5.Items.Add(toolTipItem5);
            this.btnMedicReminders.SuperTip = superToolTip5;
            // 
            // btnInstructorsReminders
            // 
            this.btnInstructorsReminders.Caption = "Instructor Reminders";
            this.btnInstructorsReminders.Id = 366;
            this.btnInstructorsReminders.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnInstructorsReminders.ImageOptions.LargeImage")));
            this.btnInstructorsReminders.Name = "btnInstructorsReminders";
            toolTipTitleItem6.Text = "Instructors Reminders";
            toolTipItem6.LeftIndent = 6;
            toolTipItem6.Text = "Send an email reminder to the instructors about the courses they have coming up f" +
    "rom the following Monday - Sunday inclusive.";
            superToolTip6.Items.Add(toolTipTitleItem6);
            superToolTip6.Items.Add(toolTipItem6);
            this.btnInstructorsReminders.SuperTip = superToolTip6;
            this.btnInstructorsReminders.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnInstructorsReminders_ItemClick);
            // 
            // BarButtonItem3
            // 
            this.BarButtonItem3.Caption = "BarButtonItem3";
            this.BarButtonItem3.Id = 380;
            this.BarButtonItem3.Name = "BarButtonItem3";
            // 
            // BarButtonItem4
            // 
            this.BarButtonItem4.Caption = "C/ Action";
            this.BarButtonItem4.Id = 393;
            this.BarButtonItem4.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BarButtonItem4.ImageOptions.SvgImage")));
            this.BarButtonItem4.Name = "BarButtonItem4";
            this.BarButtonItem4.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            // 
            // BarEditItem6
            // 
            this.BarEditItem6.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.BarEditItem6.Caption = "Zoom";
            this.BarEditItem6.Edit = this.RepositoryItemZoomTrackBar1;
            this.BarEditItem6.Id = 394;
            this.BarEditItem6.Name = "BarEditItem6";
            // 
            // BarButtonItem6
            // 
            this.BarButtonItem6.Caption = "Task - Completed";
            this.BarButtonItem6.Id = 395;
            this.BarButtonItem6.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BarButtonItem6.ImageOptions.SvgImage")));
            this.BarButtonItem6.Name = "BarButtonItem6";
            // 
            // BarButtonItem7
            // 
            this.BarButtonItem7.Caption = "Web Course";
            this.BarButtonItem7.Id = 396;
            this.BarButtonItem7.Name = "BarButtonItem7";
            // 
            // btnInvoice
            // 
            this.btnInvoice.Caption = "Invoice";
            this.btnInvoice.Id = 399;
            this.btnInvoice.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnInvoice.ImageOptions.SvgImage")));
            this.btnInvoice.Name = "btnInvoice";
            this.btnInvoice.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnInvoice_ItemClick);
            // 
            // btnMedicsReport
            // 
            this.btnMedicsReport.Caption = "Medics";
            this.btnMedicsReport.Id = 401;
            this.btnMedicsReport.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnMedicsReport.ImageOptions.Image")));
            this.btnMedicsReport.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnMedicsReport.ImageOptions.LargeImage")));
            this.btnMedicsReport.Name = "btnMedicsReport";
            // 
            // BarSubItem7
            // 
            this.BarSubItem7.Caption = "Medics Report";
            this.BarSubItem7.Id = 402;
            this.BarSubItem7.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BarSubItem7.ImageOptions.LargeImage")));
            this.BarSubItem7.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnMedicRegister),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnMedicCompliance)});
            this.BarSubItem7.Name = "BarSubItem7";
            // 
            // btnMedicRegister
            // 
            this.btnMedicRegister.Caption = "Medics Register";
            this.btnMedicRegister.Id = 403;
            this.btnMedicRegister.Name = "btnMedicRegister";
            this.btnMedicRegister.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMedicRegister_ItemClick);
            // 
            // btnMedicCompliance
            // 
            this.btnMedicCompliance.Caption = "Medics Compliance";
            this.btnMedicCompliance.Id = 404;
            this.btnMedicCompliance.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnMedicCompliance.ImageOptions.SvgImage")));
            this.btnMedicCompliance.Name = "btnMedicCompliance";
            // 
            // btnCaptureCopy
            // 
            this.btnCaptureCopy.Caption = "Capture Copy";
            this.btnCaptureCopy.Id = 2;
            this.btnCaptureCopy.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCaptureCopy.ImageOptions.Image")));
            this.btnCaptureCopy.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnCaptureCopy.ImageOptions.LargeImage")));
            this.btnCaptureCopy.Name = "btnCaptureCopy";
            // 
            // chkCaptureCopy
            // 
            this.chkCaptureCopy.Caption = "Capture Copy";
            this.chkCaptureCopy.CheckBoxVisibility = DevExpress.XtraBars.CheckBoxVisibility.BeforeText;
            this.chkCaptureCopy.Id = 3;
            this.chkCaptureCopy.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("chkCaptureCopy.ImageOptions.Image")));
            this.chkCaptureCopy.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("chkCaptureCopy.ImageOptions.LargeImage")));
            this.chkCaptureCopy.Name = "chkCaptureCopy";
            // 
            // btnViewOverview
            // 
            this.btnViewOverview.Caption = "Gov Overview";
            this.btnViewOverview.Id = 4;
            this.btnViewOverview.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnViewOverview.ImageOptions.SvgImage")));
            this.btnViewOverview.Name = "btnViewOverview";
            this.btnViewOverview.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnViewOverview_ItemClick);
            // 
            // btnCasualtySummary
            // 
            this.btnCasualtySummary.Caption = "Casualty Summary";
            this.btnCasualtySummary.Enabled = false;
            this.btnCasualtySummary.Id = 5;
            this.btnCasualtySummary.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCasualtySummary.ImageOptions.Image")));
            this.btnCasualtySummary.Name = "btnCasualtySummary";
            this.btnCasualtySummary.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCasualtySummary_ItemClick);
            // 
            // btnAmbulanceControl
            // 
            this.btnAmbulanceControl.Caption = "Ambulance Control";
            this.btnAmbulanceControl.Id = 6;
            this.btnAmbulanceControl.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnAmbulanceControl.ImageOptions.SvgImage")));
            this.btnAmbulanceControl.ItemInMenuAppearance.Hovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnAmbulanceControl.ItemInMenuAppearance.Hovered.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnAmbulanceControl.ItemInMenuAppearance.Hovered.Options.UseBackColor = true;
            this.btnAmbulanceControl.ItemInMenuAppearance.Hovered.Options.UseForeColor = true;
            this.btnAmbulanceControl.Name = "btnAmbulanceControl";
            this.btnAmbulanceControl.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.btnAmbulanceControl.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAmbulanceControl_ItemClick);
            // 
            // BarButtonItem22
            // 
            this.BarButtonItem22.Caption = "Sign In Equip";
            this.BarButtonItem22.Id = 7;
            this.BarButtonItem22.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BarButtonItem22.ImageOptions.SvgImage")));
            this.BarButtonItem22.Name = "BarButtonItem22";
            // 
            // BarButtonItem23
            // 
            this.BarButtonItem23.Caption = "BarButtonItem23";
            this.BarButtonItem23.Id = 8;
            this.BarButtonItem23.Name = "BarButtonItem23";
            this.BarButtonItem23.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItem23_ItemClick);
            // 
            // btnGovReporting
            // 
            this.btnGovReporting.Caption = "Reporting";
            this.btnGovReporting.Id = 9;
            this.btnGovReporting.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnGovReporting.ImageOptions.SvgImage")));
            this.btnGovReporting.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnGovReportOverview),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnGovReportDetails)});
            this.btnGovReporting.Name = "btnGovReporting";
            // 
            // btnGovReportOverview
            // 
            this.btnGovReportOverview.Caption = "Overview Report";
            this.btnGovReportOverview.Id = 10;
            this.btnGovReportOverview.Name = "btnGovReportOverview";
            this.btnGovReportOverview.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGovReportOverview_ItemClick);
            // 
            // btnGovReportDetails
            // 
            this.btnGovReportDetails.Caption = "Detail Report";
            this.btnGovReportDetails.Id = 11;
            this.btnGovReportDetails.Name = "btnGovReportDetails";
            this.btnGovReportDetails.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGovReportDetails_ItemClick);
            // 
            // btnGovShowApplicable
            // 
            this.btnGovShowApplicable.Caption = "Show Applicable";
            this.btnGovShowApplicable.Id = 12;
            this.btnGovShowApplicable.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnGovShowApplicable.ImageOptions.SvgImage")));
            this.btnGovShowApplicable.Name = "btnGovShowApplicable";
            this.btnGovShowApplicable.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItem24_ItemClick_1);
            // 
            // br64
            // 
            this.br64.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.br64.Caption = "64Bit";
            this.br64.Id = 14;
            this.br64.Name = "br64";
            // 
            // BarButtonItem1
            // 
            this.BarButtonItem1.Caption = "Status";
            this.BarButtonItem1.Id = 15;
            this.BarButtonItem1.Name = "BarButtonItem1";
            // 
            // BarSubItem8
            // 
            this.BarSubItem8.Caption = "Status";
            this.BarSubItem8.Id = 16;
            this.BarSubItem8.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BarSubItem8.ImageOptions.SvgImage")));
            this.BarSubItem8.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnGovApplicapable),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnGovNotApplicable),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn100Percent)});
            this.BarSubItem8.Name = "BarSubItem8";
            // 
            // btnGovApplicapable
            // 
            this.btnGovApplicapable.Caption = "Applicable";
            this.btnGovApplicapable.Id = 17;
            this.btnGovApplicapable.Name = "btnGovApplicapable";
            this.btnGovApplicapable.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGovApplicapable_ItemClick);
            // 
            // btnGovNotApplicable
            // 
            this.btnGovNotApplicable.Caption = "Not applicable";
            this.btnGovNotApplicable.Id = 18;
            this.btnGovNotApplicable.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGovNotApplicable.ImageOptions.Image")));
            this.btnGovNotApplicable.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnGovNotApplicable.ImageOptions.LargeImage")));
            this.btnGovNotApplicable.Name = "btnGovNotApplicable";
            this.btnGovNotApplicable.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGovNotApplicable_ItemClick);
            // 
            // btn100Percent
            // 
            this.btn100Percent.Caption = "100% Completed";
            this.btn100Percent.Id = 72;
            this.btn100Percent.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn100Percent.ImageOptions.SvgImage")));
            this.btn100Percent.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.btn100Percent.Name = "btn100Percent";
            this.btn100Percent.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn100Percent_ItemClick);
            // 
            // btnClinicalKPI
            // 
            this.btnClinicalKPI.Caption = "KPI";
            this.btnClinicalKPI.Id = 19;
            this.btnClinicalKPI.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnClinicalKPI.ImageOptions.SvgImage")));
            this.btnClinicalKPI.Name = "btnClinicalKPI";
            this.btnClinicalKPI.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClinicalKPI_ItemClick);
            // 
            // btnBatchImport
            // 
            this.btnBatchImport.Caption = "Import Courses";
            this.btnBatchImport.Id = 20;
            this.btnBatchImport.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnBatchImport.ImageOptions.SvgImage")));
            this.btnBatchImport.Name = "btnBatchImport";
            this.btnBatchImport.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.btnBatchImport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBatchImport_ItemClick);
            // 
            // btnGoToToday
            // 
            this.btnGoToToday.Caption = "Go To Today";
            this.btnGoToToday.Id = 21;
            this.btnGoToToday.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnGoToToday.ImageOptions.SvgImage")));
            this.btnGoToToday.Name = "btnGoToToday";
            this.btnGoToToday.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGoToToday_ItemClick);
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.Caption = "Zoom In";
            this.btnZoomIn.Id = 22;
            this.btnZoomIn.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnZoomIn.ImageOptions.SvgImage")));
            this.btnZoomIn.Name = "btnZoomIn";
            toolTipTitleItem7.Text = "Zoom in (Ctrl + Subtract)";
            superToolTip7.Items.Add(toolTipTitleItem7);
            this.btnZoomIn.SuperTip = superToolTip7;
            this.btnZoomIn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnZoomIn_ItemClick);
            // 
            // BtnZoomOut
            // 
            this.BtnZoomOut.Caption = "Zoom Out";
            this.BtnZoomOut.Id = 23;
            this.BtnZoomOut.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnZoomOut.ImageOptions.SvgImage")));
            this.BtnZoomOut.Name = "BtnZoomOut";
            toolTipTitleItem8.Text = "Zoome Out (Ctrl + Subtract)";
            superToolTip8.Items.Add(toolTipTitleItem8);
            this.BtnZoomOut.SuperTip = superToolTip8;
            this.BtnZoomOut.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnZoomOut_ItemClick);
            // 
            // BarButtonItem27
            // 
            this.BarButtonItem27.Caption = "BarButtonItem27";
            this.BarButtonItem27.Id = 24;
            this.BarButtonItem27.Name = "BarButtonItem27";
            // 
            // BarButtonItem25
            // 
            this.BarButtonItem25.Caption = "Phonebook";
            this.BarButtonItem25.Id = 26;
            this.BarButtonItem25.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BarButtonItem25.ImageOptions.Image")));
            this.BarButtonItem25.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BarButtonItem25.ImageOptions.LargeImage")));
            this.BarButtonItem25.Name = "BarButtonItem25";
            // 
            // btnPhonebook
            // 
            this.btnPhonebook.Caption = "Phone Book";
            this.btnPhonebook.Id = 27;
            this.btnPhonebook.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnPhonebook.ImageOptions.SvgImage")));
            this.btnPhonebook.Name = "btnPhonebook";
            this.btnPhonebook.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPhonebook_ItemClick);
            // 
            // btnPrintGovList
            // 
            this.btnPrintGovList.Caption = "Print Policy Standards";
            this.btnPrintGovList.Id = 30;
            this.btnPrintGovList.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnPrintGovList.ImageOptions.SvgImage")));
            this.btnPrintGovList.Name = "btnPrintGovList";
            this.btnPrintGovList.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPrintGovList_ItemClick);
            // 
            // BarToggleSwitchItem1
            // 
            this.BarToggleSwitchItem1.Caption = "BarToggleSwitchItem1";
            this.BarToggleSwitchItem1.Id = 31;
            this.BarToggleSwitchItem1.Name = "BarToggleSwitchItem1";
            // 
            // btnClearTreeFilter
            // 
            this.btnClearTreeFilter.Caption = "Clear Tree Filter";
            this.btnClearTreeFilter.Id = 33;
            this.btnClearTreeFilter.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnClearTreeFilter.ImageOptions.SvgImage")));
            this.btnClearTreeFilter.Name = "btnClearTreeFilter";
            this.btnClearTreeFilter.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClearTreeFilter_ItemClick);
            // 
            // SkinDropDownButtonItem1
            // 
            this.SkinDropDownButtonItem1.Id = 34;
            this.SkinDropDownButtonItem1.Name = "SkinDropDownButtonItem1";
            // 
            // btnViewGroupStandards
            // 
            this.btnViewGroupStandards.Caption = "View Group Standards";
            this.btnViewGroupStandards.Id = 37;
            this.btnViewGroupStandards.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnViewGroupStandards.ImageOptions.Image")));
            this.btnViewGroupStandards.Name = "btnViewGroupStandards";
            this.btnViewGroupStandards.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnViewGroupStandards_ItemClick);
            // 
            // btnCopyFiles
            // 
            this.btnCopyFiles.Caption = "Copy Files";
            this.btnCopyFiles.Id = 38;
            this.btnCopyFiles.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCopyFiles.ImageOptions.Image")));
            this.btnCopyFiles.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnCopyFiles.ImageOptions.LargeImage")));
            this.btnCopyFiles.Name = "btnCopyFiles";
            this.btnCopyFiles.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCopyFiles_ItemClick);
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.Caption = "Open Folder";
            this.btnOpenFolder.Enabled = false;
            this.btnOpenFolder.Id = 39;
            this.btnOpenFolder.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnOpenFolder.ImageOptions.SvgImage")));
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOpenFolder_ItemClick);
            // 
            // btnCopyStandards
            // 
            this.btnCopyStandards.Caption = "Copy Standards";
            this.btnCopyStandards.Id = 40;
            this.btnCopyStandards.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCopyStandards.ImageOptions.Image")));
            this.btnCopyStandards.Name = "btnCopyStandards";
            this.btnCopyStandards.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCopyStandards_ItemClick);
            // 
            // btnTrainingAction
            // 
            this.btnTrainingAction.Caption = "Quick Action";
            this.btnTrainingAction.Id = 42;
            this.btnTrainingAction.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnTrainingAction.ImageOptions.LargeImage")));
            this.btnTrainingAction.Name = "btnTrainingAction";
            this.btnTrainingAction.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTrainingAction_ItemClick);
            // 
            // btnCopyCol
            // 
            this.btnCopyCol.Caption = "Copy Column";
            this.btnCopyCol.Id = 43;
            this.btnCopyCol.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnCopyCol.ImageOptions.SvgImage")));
            this.btnCopyCol.Name = "btnCopyCol";
            this.btnCopyCol.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCopyCol_ItemClick);
            // 
            // BarButtonItem28
            // 
            this.BarButtonItem28.Caption = "BarButtonItem28";
            this.BarButtonItem28.Id = 45;
            this.BarButtonItem28.Name = "BarButtonItem28";
            // 
            // btnAvailabilityPerson
            // 
            this.btnAvailabilityPerson.Caption = "Availability";
            this.btnAvailabilityPerson.Enabled = false;
            this.btnAvailabilityPerson.Id = 46;
            this.btnAvailabilityPerson.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnAvailabilityPerson.ImageOptions.SvgImage")));
            this.btnAvailabilityPerson.Name = "btnAvailabilityPerson";
            toolTipTitleItem9.Text = "Email Availability";
            toolTipItem7.LeftIndent = 6;
            toolTipItem7.Text = "Sends an email to all the ambulance crew requesting their availability for the ne" +
    "xt 7 days starting from \'Next Monday\'";
            superToolTip9.Items.Add(toolTipTitleItem9);
            superToolTip9.Items.Add(toolTipItem7);
            this.btnAvailabilityPerson.SuperTip = superToolTip9;
            // 
            // SwitchToDayViewItem1
            // 
            this.SwitchToDayViewItem1.Id = 47;
            this.SwitchToDayViewItem1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("SwitchToDayViewItem1.ImageOptions.SvgImage")));
            this.SwitchToDayViewItem1.Name = "SwitchToDayViewItem1";
            // 
            // SwitchToWorkWeekViewItem1
            // 
            this.SwitchToWorkWeekViewItem1.Id = 48;
            this.SwitchToWorkWeekViewItem1.Name = "SwitchToWorkWeekViewItem1";
            // 
            // SwitchToWeekViewItem1
            // 
            this.SwitchToWeekViewItem1.Id = 49;
            this.SwitchToWeekViewItem1.Name = "SwitchToWeekViewItem1";
            // 
            // SwitchToFullWeekViewItem1
            // 
            this.SwitchToFullWeekViewItem1.Id = 50;
            this.SwitchToFullWeekViewItem1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("SwitchToFullWeekViewItem1.ImageOptions.SvgImage")));
            this.SwitchToFullWeekViewItem1.Name = "SwitchToFullWeekViewItem1";
            // 
            // SwitchToMonthViewItem1
            // 
            this.SwitchToMonthViewItem1.Id = 51;
            this.SwitchToMonthViewItem1.Name = "SwitchToMonthViewItem1";
            // 
            // SwitchToTimelineViewItem1
            // 
            this.SwitchToTimelineViewItem1.Id = 52;
            this.SwitchToTimelineViewItem1.Name = "SwitchToTimelineViewItem1";
            // 
            // SwitchToGanttViewItem1
            // 
            this.SwitchToGanttViewItem1.Id = 53;
            this.SwitchToGanttViewItem1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("SwitchToGanttViewItem1.ImageOptions.SvgImage")));
            this.SwitchToGanttViewItem1.Name = "SwitchToGanttViewItem1";
            // 
            // SwitchToAgendaViewItem1
            // 
            this.SwitchToAgendaViewItem1.Id = 54;
            this.SwitchToAgendaViewItem1.Name = "SwitchToAgendaViewItem1";
            // 
            // SwitchTimeScalesItem1
            // 
            this.SwitchTimeScalesItem1.Id = 55;
            this.SwitchTimeScalesItem1.Name = "SwitchTimeScalesItem1";
            // 
            // ChangeScaleWidthItem1
            // 
            this.ChangeScaleWidthItem1.Edit = this.RepositoryItemSpinEdit2;
            this.ChangeScaleWidthItem1.Id = 56;
            this.ChangeScaleWidthItem1.Name = "ChangeScaleWidthItem1";
            this.ChangeScaleWidthItem1.UseCommandCaption = true;
            // 
            // SwitchTimeScalesCaptionItem1
            // 
            this.SwitchTimeScalesCaptionItem1.Id = 57;
            this.SwitchTimeScalesCaptionItem1.Name = "SwitchTimeScalesCaptionItem1";
            // 
            // SwitchCompressWeekendItem1
            // 
            this.SwitchCompressWeekendItem1.Id = 58;
            this.SwitchCompressWeekendItem1.Name = "SwitchCompressWeekendItem1";
            // 
            // SwitchShowWorkTimeOnlyItem1
            // 
            this.SwitchShowWorkTimeOnlyItem1.Id = 59;
            this.SwitchShowWorkTimeOnlyItem1.Name = "SwitchShowWorkTimeOnlyItem1";
            // 
            // SwitchCellsAutoHeightItem1
            // 
            this.SwitchCellsAutoHeightItem1.Id = 60;
            this.SwitchCellsAutoHeightItem1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("SwitchCellsAutoHeightItem1.ImageOptions.SvgImage")));
            this.SwitchCellsAutoHeightItem1.Name = "SwitchCellsAutoHeightItem1";
            // 
            // ChangeSnapToCellsUIItem1
            // 
            this.ChangeSnapToCellsUIItem1.Id = 61;
            this.ChangeSnapToCellsUIItem1.Name = "ChangeSnapToCellsUIItem1";
            // 
            // btnGovTemplate
            // 
            this.btnGovTemplate.Caption = "Document Template";
            this.btnGovTemplate.Id = 65;
            this.btnGovTemplate.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnGovTemplate.ImageOptions.SvgImage")));
            this.btnGovTemplate.Name = "btnGovTemplate";
            this.btnGovTemplate.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGovTemplate_ItemClick);
            // 
            // BarButtonItem8
            // 
            this.BarButtonItem8.Caption = "BarButtonItem8";
            this.BarButtonItem8.Id = 66;
            this.BarButtonItem8.Name = "BarButtonItem8";
            // 
            // btnReplyWith
            // 
            this.btnReplyWith.Caption = "Reply With:";
            this.btnReplyWith.Id = 67;
            this.btnReplyWith.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnReplyWith.ImageOptions.SvgImage")));
            this.btnReplyWith.Name = "btnReplyWith";
            // 
            // btnFlag
            // 
            this.btnFlag.Caption = "Flag";
            this.btnFlag.Id = 68;
            this.btnFlag.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnFlag.ImageOptions.SvgImage")));
            this.btnFlag.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.btnFlag.Name = "btnFlag";
            // 
            // BarEditItem7
            // 
            this.BarEditItem7.Caption = "Views";
            this.BarEditItem7.Edit = this.RepositoryItemComboBox1;
            this.BarEditItem7.EditWidth = 85;
            this.BarEditItem7.Id = 69;
            this.BarEditItem7.Name = "BarEditItem7";
            this.BarEditItem7.EditValueChanged += new System.EventHandler(this.BarEditItem7_EditValueChanged);
            // 
            // btnImportInvoices
            // 
            this.btnImportInvoices.Caption = "Import Invoices";
            this.btnImportInvoices.Id = 70;
            this.btnImportInvoices.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnImportInvoices.ImageOptions.SvgImage")));
            this.btnImportInvoices.Name = "btnImportInvoices";
            this.btnImportInvoices.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnImportInvoices_ItemClick);
            // 
            // btnFindAfterDrag
            // 
            this.btnFindAfterDrag.Caption = "Find After Drag";
            this.btnFindAfterDrag.Id = 71;
            this.btnFindAfterDrag.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnFindAfterDrag.ImageOptions.SvgImage")));
            this.btnFindAfterDrag.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.btnFindAfterDrag.Name = "btnFindAfterDrag";
            // 
            // btnTaskCompleted
            // 
            this.btnTaskCompleted.Caption = "Task Completed";
            this.btnTaskCompleted.Id = 73;
            this.btnTaskCompleted.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnTaskCompleted.ImageOptions.SvgImage")));
            this.btnTaskCompleted.Name = "btnTaskCompleted";
            this.btnTaskCompleted.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTaskCompleted_ItemClick);
            // 
            // btnOpenFileLocation
            // 
            this.btnOpenFileLocation.Caption = "Open File Location";
            this.btnOpenFileLocation.Id = 74;
            this.btnOpenFileLocation.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnOpenFileLocation.ImageOptions.SvgImage")));
            this.btnOpenFileLocation.Name = "btnOpenFileLocation";
            this.btnOpenFileLocation.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOpenFileLocation_ItemClick);
            // 
            // btnFlaggedReport
            // 
            this.btnFlaggedReport.Caption = "Annual Report";
            this.btnFlaggedReport.Id = 75;
            this.btnFlaggedReport.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnFlaggedReport.ImageOptions.SvgImage")));
            this.btnFlaggedReport.Name = "btnFlaggedReport";
            this.btnFlaggedReport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFlaggedReport_ItemClick);
            // 
            // SkinRibbonGalleryBarItem3
            // 
            this.SkinRibbonGalleryBarItem3.Caption = "SkinRibbonGalleryBarItem3";
            // 
            // 
            // 
            this.SkinRibbonGalleryBarItem3.Gallery.AllowHoverImages = true;
            this.SkinRibbonGalleryBarItem3.Gallery.ColumnCount = 4;
            this.SkinRibbonGalleryBarItem3.Gallery.FixedHoverImageSize = false;
            this.SkinRibbonGalleryBarItem3.Gallery.ImageSize = new System.Drawing.Size(48, 48);
            this.SkinRibbonGalleryBarItem3.Gallery.ItemCheckMode = DevExpress.XtraBars.Ribbon.Gallery.ItemCheckMode.SingleRadio;
            this.SkinRibbonGalleryBarItem3.Gallery.ItemImageLayout = DevExpress.Utils.Drawing.ImageLayoutMode.Squeeze;
            this.SkinRibbonGalleryBarItem3.Gallery.ItemImageLocation = DevExpress.Utils.Locations.Top;
            skinPaddingEdges1.Left = 24;
            skinPaddingEdges1.Right = 24;
            this.SkinRibbonGalleryBarItem3.Gallery.ItemImagePadding = skinPaddingEdges1;
            this.SkinRibbonGalleryBarItem3.Id = 76;
            this.SkinRibbonGalleryBarItem3.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("SkinRibbonGalleryBarItem3.ImageOptions.SvgImage")));
            this.SkinRibbonGalleryBarItem3.Name = "SkinRibbonGalleryBarItem3";
            // 
            // SkinPaletteRibbonGalleryBarItem3
            // 
            this.SkinPaletteRibbonGalleryBarItem3.Caption = "SkinPaletteRibbonGalleryBarItem3";
            // 
            // 
            // 
            this.SkinPaletteRibbonGalleryBarItem3.Gallery.AllowHtmlText = true;
            this.SkinPaletteRibbonGalleryBarItem3.Gallery.ColumnCount = 4;
            galleryItemGroup1.Caption = "General";
            galleryItem1.Caption = "Default";
            toolTipItem8.Text = "Default";
            superToolTip10.Items.Add(toolTipItem8);
            galleryItem1.SuperTip = superToolTip10;
            galleryItem1.Tag = "DefaultSkinPalette";
            galleryItem1.Value = "DefaultSkinPalette";
            galleryItem2.Caption = "Art House";
            toolTipItem9.Text = "Art House";
            superToolTip11.Items.Add(toolTipItem9);
            galleryItem2.SuperTip = superToolTip11;
            galleryItem2.Tag = "Art House";
            galleryItem2.Value = "Art House";
            galleryItem3.Caption = "Twenty";
            toolTipItem10.Text = "Twenty";
            superToolTip12.Items.Add(toolTipItem10);
            galleryItem3.SuperTip = superToolTip12;
            galleryItem3.Tag = "Twenty";
            galleryItem3.Value = "Twenty";
            galleryItem4.Caption = "Twenty Gold";
            toolTipItem11.Text = "Twenty Gold";
            superToolTip13.Items.Add(toolTipItem11);
            galleryItem4.SuperTip = superToolTip13;
            galleryItem4.Tag = "Twenty Gold";
            galleryItem4.Value = "Twenty Gold";
            galleryItemGroup1.Items.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItem[] {
            galleryItem1,
            galleryItem2,
            galleryItem3,
            galleryItem4});
            galleryItemGroup2.Caption = "Inspired";
            galleryItem5.Caption = "Office Colorful";
            galleryItem5.Checked = true;
            toolTipItem12.Text = "Office Colorful";
            superToolTip14.Items.Add(toolTipItem12);
            galleryItem5.SuperTip = superToolTip14;
            galleryItem5.Tag = "Office Colorful";
            galleryItem5.Value = "Office Colorful";
            galleryItem6.Caption = "Office Black";
            toolTipItem13.Text = "Office Black";
            superToolTip15.Items.Add(toolTipItem13);
            galleryItem6.SuperTip = superToolTip15;
            galleryItem6.Tag = "Office Black";
            galleryItem6.Value = "Office Black";
            galleryItem7.Caption = "Office White";
            toolTipItem14.Text = "Office White";
            superToolTip16.Items.Add(toolTipItem14);
            galleryItem7.SuperTip = superToolTip16;
            galleryItem7.Tag = "Office White";
            galleryItem7.Value = "Office White";
            galleryItem8.Caption = "Office Dark Gray";
            toolTipItem15.Text = "Office Dark Gray";
            superToolTip17.Items.Add(toolTipItem15);
            galleryItem8.SuperTip = superToolTip17;
            galleryItem8.Tag = "Office Dark Gray";
            galleryItem8.Value = "Office Dark Gray";
            galleryItem9.Caption = "VS Light";
            toolTipItem16.Text = "VS Light";
            superToolTip18.Items.Add(toolTipItem16);
            galleryItem9.SuperTip = superToolTip18;
            galleryItem9.Tag = "VS Light";
            galleryItem9.Value = "VS Light";
            galleryItem10.Caption = "VS Blue";
            toolTipItem17.Text = "VS Blue";
            superToolTip19.Items.Add(toolTipItem17);
            galleryItem10.SuperTip = superToolTip19;
            galleryItem10.Tag = "VS Blue";
            galleryItem10.Value = "VS Blue";
            galleryItem11.Caption = "VS Dark";
            toolTipItem18.Text = "VS Dark";
            superToolTip20.Items.Add(toolTipItem18);
            galleryItem11.SuperTip = superToolTip20;
            galleryItem11.Tag = "VS Dark";
            galleryItem11.Value = "VS Dark";
            galleryItem12.Caption = "VS 2019 Blue";
            toolTipItem19.Text = "VS 2019 Blue";
            superToolTip21.Items.Add(toolTipItem19);
            galleryItem12.SuperTip = superToolTip21;
            galleryItem12.Tag = "VS 2019 Blue";
            galleryItem12.Value = "VS 2019 Blue";
            galleryItemGroup2.Items.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItem[] {
            galleryItem5,
            galleryItem6,
            galleryItem7,
            galleryItem8,
            galleryItem9,
            galleryItem10,
            galleryItem11,
            galleryItem12});
            galleryItemGroup3.Caption = "Light";
            galleryItem13.Caption = "Leaf Rustle";
            toolTipItem20.Text = "Leaf Rustle";
            superToolTip22.Items.Add(toolTipItem20);
            galleryItem13.SuperTip = superToolTip22;
            galleryItem13.Tag = "Leaf Rustle";
            galleryItem13.Value = "Leaf Rustle";
            galleryItem14.Caption = "Neon Lollipop";
            toolTipItem21.Text = "Neon Lollipop";
            superToolTip23.Items.Add(toolTipItem21);
            galleryItem14.SuperTip = superToolTip23;
            galleryItem14.Tag = "Neon Lollipop";
            galleryItem14.Value = "Neon Lollipop";
            galleryItem15.Caption = "Tokyo";
            toolTipItem22.Text = "Tokyo";
            superToolTip24.Items.Add(toolTipItem22);
            galleryItem15.SuperTip = superToolTip24;
            galleryItem15.Tag = "Tokyo";
            galleryItem15.Value = "Tokyo";
            galleryItem16.Caption = "Grasshopper";
            toolTipItem23.Text = "Grasshopper";
            superToolTip25.Items.Add(toolTipItem23);
            galleryItem16.SuperTip = superToolTip25;
            galleryItem16.Tag = "Grasshopper";
            galleryItem16.Value = "Grasshopper";
            galleryItem17.Caption = "BW";
            toolTipItem24.Text = "BW";
            superToolTip26.Items.Add(toolTipItem24);
            galleryItem17.SuperTip = superToolTip26;
            galleryItem17.Tag = "BW";
            galleryItem17.Value = "BW";
            galleryItem18.Caption = "Norwegian Wood";
            toolTipItem25.Text = "Norwegian Wood";
            superToolTip27.Items.Add(toolTipItem25);
            galleryItem18.SuperTip = superToolTip27;
            galleryItem18.Tag = "Norwegian Wood";
            galleryItem18.Value = "Norwegian Wood";
            galleryItem19.Caption = "Date Fruit";
            toolTipItem26.Text = "Date Fruit";
            superToolTip28.Items.Add(toolTipItem26);
            galleryItem19.SuperTip = superToolTip28;
            galleryItem19.Tag = "Date Fruit";
            galleryItem19.Value = "Date Fruit";
            galleryItem20.Caption = "Dragonfly";
            toolTipItem27.Text = "Dragonfly";
            superToolTip29.Items.Add(toolTipItem27);
            galleryItem20.SuperTip = superToolTip29;
            galleryItem20.Tag = "Dragonfly";
            galleryItem20.Value = "Dragonfly";
            galleryItem21.Caption = "Plastic Space";
            toolTipItem28.Text = "Plastic Space";
            superToolTip30.Items.Add(toolTipItem28);
            galleryItem21.SuperTip = superToolTip30;
            galleryItem21.Tag = "Plastic Space";
            galleryItem21.Value = "Plastic Space";
            galleryItem22.Caption = "Gloom Gloom";
            toolTipItem29.Text = "Gloom Gloom";
            superToolTip31.Items.Add(toolTipItem29);
            galleryItem22.SuperTip = superToolTip31;
            galleryItem22.Tag = "Gloom Gloom";
            galleryItem22.Value = "Gloom Gloom";
            galleryItem23.Caption = "Aquarelle";
            toolTipItem30.Text = "Aquarelle";
            superToolTip32.Items.Add(toolTipItem30);
            galleryItem23.SuperTip = superToolTip32;
            galleryItem23.Tag = "Aquarelle";
            galleryItem23.Value = "Aquarelle";
            galleryItem24.Caption = "Oxygen 3";
            toolTipItem31.Text = "Oxygen 3";
            superToolTip33.Items.Add(toolTipItem31);
            galleryItem24.SuperTip = superToolTip33;
            galleryItem24.Tag = "Oxygen 3";
            galleryItem24.Value = "Oxygen 3";
            galleryItem25.Caption = "Moray Eel";
            toolTipItem32.Text = "Moray Eel";
            superToolTip34.Items.Add(toolTipItem32);
            galleryItem25.SuperTip = superToolTip34;
            galleryItem25.Tag = "Moray Eel";
            galleryItem25.Value = "Moray Eel";
            galleryItem26.Caption = "Blackberry Shake";
            toolTipItem33.Text = "Blackberry Shake";
            superToolTip35.Items.Add(toolTipItem33);
            galleryItem26.SuperTip = superToolTip35;
            galleryItem26.Tag = "Blackberry Shake";
            galleryItem26.Value = "Blackberry Shake";
            galleryItem27.Caption = "Vacuum";
            toolTipItem34.Text = "Vacuum";
            superToolTip36.Items.Add(toolTipItem34);
            galleryItem27.SuperTip = superToolTip36;
            galleryItem27.Tag = "Vacuum";
            galleryItem27.Value = "Vacuum";
            galleryItemGroup3.Items.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItem[] {
            galleryItem13,
            galleryItem14,
            galleryItem15,
            galleryItem16,
            galleryItem17,
            galleryItem18,
            galleryItem19,
            galleryItem20,
            galleryItem21,
            galleryItem22,
            galleryItem23,
            galleryItem24,
            galleryItem25,
            galleryItem26,
            galleryItem27});
            galleryItemGroup4.Caption = "Dark";
            galleryItem28.Caption = "Fireball";
            toolTipItem35.Text = "Fireball";
            superToolTip37.Items.Add(toolTipItem35);
            galleryItem28.SuperTip = superToolTip37;
            galleryItem28.Tag = "Fireball";
            galleryItem28.Value = "Fireball";
            galleryItem29.Caption = "Crambe";
            toolTipItem36.Text = "Crambe";
            superToolTip38.Items.Add(toolTipItem36);
            galleryItem29.SuperTip = superToolTip38;
            galleryItem29.Tag = "Crambe";
            galleryItem29.Value = "Crambe";
            galleryItem30.Caption = "Cherry Ink";
            toolTipItem37.Text = "Cherry Ink";
            superToolTip39.Items.Add(toolTipItem37);
            galleryItem30.SuperTip = superToolTip39;
            galleryItem30.Tag = "Cherry Ink";
            galleryItem30.Value = "Cherry Ink";
            galleryItem31.Caption = "Starshine";
            toolTipItem38.Text = "Starshine";
            superToolTip40.Items.Add(toolTipItem38);
            galleryItem31.SuperTip = superToolTip40;
            galleryItem31.Tag = "Starshine";
            galleryItem31.Value = "Starshine";
            galleryItem32.Caption = "Dark Turquoise";
            toolTipItem39.Text = "Dark Turquoise";
            superToolTip41.Items.Add(toolTipItem39);
            galleryItem32.SuperTip = superToolTip41;
            galleryItem32.Tag = "Dark Turquoise";
            galleryItem32.Value = "Dark Turquoise";
            galleryItem33.Caption = "Prometheus";
            toolTipItem40.Text = "Prometheus";
            superToolTip42.Items.Add(toolTipItem40);
            galleryItem33.SuperTip = superToolTip42;
            galleryItem33.Tag = "Prometheus";
            galleryItem33.Value = "Prometheus";
            galleryItem34.Caption = "Ghost Shark";
            toolTipItem41.Text = "Ghost Shark";
            superToolTip43.Items.Add(toolTipItem41);
            galleryItem34.SuperTip = superToolTip43;
            galleryItem34.Tag = "Ghost Shark";
            galleryItem34.Value = "Ghost Shark";
            galleryItem35.Caption = "Blue Velvet";
            toolTipItem42.Text = "Blue Velvet";
            superToolTip44.Items.Add(toolTipItem42);
            galleryItem35.SuperTip = superToolTip44;
            galleryItem35.Tag = "Blue Velvet";
            galleryItem35.Value = "Blue Velvet";
            galleryItem36.Caption = "Milk Snake";
            toolTipItem43.Text = "Milk Snake";
            superToolTip45.Items.Add(toolTipItem43);
            galleryItem36.SuperTip = superToolTip45;
            galleryItem36.Tag = "Milk Snake";
            galleryItem36.Value = "Milk Snake";
            galleryItem37.Caption = "Mercury Ice";
            toolTipItem44.Text = "Mercury Ice";
            superToolTip46.Items.Add(toolTipItem44);
            galleryItem37.SuperTip = superToolTip46;
            galleryItem37.Tag = "Mercury Ice";
            galleryItem37.Value = "Mercury Ice";
            galleryItem38.Caption = "Volcano";
            toolTipItem45.Text = "Volcano";
            superToolTip47.Items.Add(toolTipItem45);
            galleryItem38.SuperTip = superToolTip47;
            galleryItem38.Tag = "Volcano";
            galleryItem38.Value = "Volcano";
            galleryItem39.Caption = "Witch Rave";
            toolTipItem46.Text = "Witch Rave";
            superToolTip48.Items.Add(toolTipItem46);
            galleryItem39.SuperTip = superToolTip48;
            galleryItem39.Tag = "Witch Rave";
            galleryItem39.Value = "Witch Rave";
            galleryItem40.Caption = "Nebula";
            toolTipItem47.Text = "Nebula";
            superToolTip49.Items.Add(toolTipItem47);
            galleryItem40.SuperTip = superToolTip49;
            galleryItem40.Tag = "Nebula";
            galleryItem40.Value = "Nebula";
            galleryItemGroup4.Items.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItem[] {
            galleryItem28,
            galleryItem29,
            galleryItem30,
            galleryItem31,
            galleryItem32,
            galleryItem33,
            galleryItem34,
            galleryItem35,
            galleryItem36,
            galleryItem37,
            galleryItem38,
            galleryItem39,
            galleryItem40});
            galleryItemGroup5.Caption = "Accessibility";
            galleryItem41.Caption = "High Contrast White";
            toolTipItem48.Text = "High Contrast White";
            superToolTip50.Items.Add(toolTipItem48);
            galleryItem41.SuperTip = superToolTip50;
            galleryItem41.Tag = "High Contrast White";
            galleryItem41.Value = "High Contrast White";
            galleryItem42.Caption = "High Contrast Black";
            toolTipItem49.Text = "High Contrast Black";
            superToolTip51.Items.Add(toolTipItem49);
            galleryItem42.SuperTip = superToolTip51;
            galleryItem42.Tag = "High Contrast Black";
            galleryItem42.Value = "High Contrast Black";
            galleryItemGroup5.Items.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItem[] {
            galleryItem41,
            galleryItem42});
            this.SkinPaletteRibbonGalleryBarItem3.Gallery.Groups.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItemGroup[] {
            galleryItemGroup1,
            galleryItemGroup2,
            galleryItemGroup3,
            galleryItemGroup4,
            galleryItemGroup5});
            this.SkinPaletteRibbonGalleryBarItem3.Gallery.ImageSize = new System.Drawing.Size(240, 168);
            this.SkinPaletteRibbonGalleryBarItem3.Gallery.ItemCheckMode = DevExpress.XtraBars.Ribbon.Gallery.ItemCheckMode.SingleRadio;
            this.SkinPaletteRibbonGalleryBarItem3.Gallery.ItemImageLayout = DevExpress.Utils.Drawing.ImageLayoutMode.Stretch;
            this.SkinPaletteRibbonGalleryBarItem3.Gallery.MinimumColumnCount = 2;
            this.SkinPaletteRibbonGalleryBarItem3.Id = 77;
            this.SkinPaletteRibbonGalleryBarItem3.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("SkinPaletteRibbonGalleryBarItem3.ImageOptions.SvgImage")));
            this.SkinPaletteRibbonGalleryBarItem3.Name = "SkinPaletteRibbonGalleryBarItem3";
            toolTipItem50.Text = "Office Colorful";
            superToolTip52.Items.Add(toolTipItem50);
            this.SkinPaletteRibbonGalleryBarItem3.SuperTip = superToolTip52;
            // 
            // BarButtonItem29
            // 
            this.BarButtonItem29.Caption = "Add Note";
            this.BarButtonItem29.Id = 78;
            this.BarButtonItem29.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BarButtonItem29.ImageOptions.SvgImage")));
            this.BarButtonItem29.Name = "BarButtonItem29";
            // 
            // BarButtonItem30
            // 
            this.BarButtonItem30.Caption = "Add Task";
            this.BarButtonItem30.Id = 79;
            this.BarButtonItem30.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BarButtonItem30.ImageOptions.SvgImage")));
            this.BarButtonItem30.Name = "BarButtonItem30";
            this.BarButtonItem30.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItem30_ItemClick);
            // 
            // btnValidateFiles
            // 
            this.btnValidateFiles.Caption = "Validate Files";
            this.btnValidateFiles.Id = 80;
            this.btnValidateFiles.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnValidateFiles.ImageOptions.SvgImage")));
            this.btnValidateFiles.Name = "btnValidateFiles";
            this.btnValidateFiles.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnValidateFiles_ItemClick);
            // 
            // btnWebImport
            // 
            this.btnWebImport.Caption = "Import Students";
            this.btnWebImport.Id = 81;
            this.btnWebImport.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnWebImport.ImageOptions.SvgImage")));
            this.btnWebImport.Name = "btnWebImport";
            this.btnWebImport.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.btnWebImport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnWebImport_ItemClick);
            // 
            // BarButtonItem31
            // 
            this.BarButtonItem31.Caption = "Processes";
            this.BarButtonItem31.Id = 82;
            this.BarButtonItem31.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BarButtonItem31.ImageOptions.SvgImage")));
            this.BarButtonItem31.Name = "BarButtonItem31";
            this.BarButtonItem31.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItem31_ItemClick);
            // 
            // btnFlag_Add
            // 
            this.btnFlag_Add.Caption = "Add Issue";
            this.btnFlag_Add.Id = 84;
            this.btnFlag_Add.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnFlag_Add.ImageOptions.SvgImage")));
            this.btnFlag_Add.Name = "btnFlag_Add";
            this.btnFlag_Add.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFlag_Add_ItemClick);
            // 
            // btnRiskRecategorise
            // 
            this.btnRiskRecategorise.Caption = "Recategorise";
            this.btnRiskRecategorise.Id = 85;
            this.btnRiskRecategorise.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnRiskRecategorise.ImageOptions.SvgImage")));
            this.btnRiskRecategorise.Name = "btnRiskRecategorise";
            this.btnRiskRecategorise.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRiskRecategorise_ItemClick);
            // 
            // RibbonGalleryBarItem1
            // 
            this.RibbonGalleryBarItem1.Id = 101;
            this.RibbonGalleryBarItem1.Name = "RibbonGalleryBarItem1";
            // 
            // RibbonGalleryBarItem2
            // 
            this.RibbonGalleryBarItem2.Id = 102;
            this.RibbonGalleryBarItem2.Name = "RibbonGalleryBarItem2";
            this.RibbonGalleryBarItem2.GalleryItemClick += new DevExpress.XtraBars.Ribbon.GalleryItemClickEventHandler(this.RibbonGalleryBarItem2_GalleryItemClick);
            // 
            // RibbonGalleryBarItem3
            // 
            this.RibbonGalleryBarItem3.Id = 103;
            this.RibbonGalleryBarItem3.Name = "RibbonGalleryBarItem3";
            // 
            // RibbonGalleryBarItem4
            // 
            this.RibbonGalleryBarItem4.Id = 104;
            this.RibbonGalleryBarItem4.Name = "RibbonGalleryBarItem4";
            // 
            // rbnViewGallery
            // 
            this.rbnViewGallery.Id = 105;
            this.rbnViewGallery.Name = "rbnViewGallery";
            this.rbnViewGallery.GalleryItemClick += new DevExpress.XtraBars.Ribbon.GalleryItemClickEventHandler(this.rbnViewGallery_GalleryItemClick);
            // 
            // RibbonGalleryBarItem5
            // 
            this.RibbonGalleryBarItem5.Id = 106;
            this.RibbonGalleryBarItem5.Name = "RibbonGalleryBarItem5";
            // 
            // brLocale
            // 
            this.brLocale.Id = 92;
            this.brLocale.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("brLocale.ImageOptions.SvgImage")));
            this.brLocale.Name = "brLocale";
            this.brLocale.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.brLocale.ItemDoubleClick += new DevExpress.XtraBars.ItemClickEventHandler(this.brLocale_ItemDoubleClick);
            // 
            // BtnCheckInvoice
            // 
            this.BtnCheckInvoice.Caption = "Check Invoice";
            this.BtnCheckInvoice.Id = 93;
            this.BtnCheckInvoice.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnCheckInvoice.ImageOptions.SvgImage")));
            this.BtnCheckInvoice.Name = "BtnCheckInvoice";
            this.BtnCheckInvoice.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnCheckInvoice_ItemClick);
            // 
            // btnSendMattermost
            // 
            this.btnSendMattermost.Caption = "Mattermost";
            this.btnSendMattermost.Id = 94;
            this.btnSendMattermost.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSendMattermost.ImageOptions.SvgImage")));
            this.btnSendMattermost.Name = "btnSendMattermost";
            toolTipTitleItem10.Text = "Send to Mattermost";
            toolTipItem51.Text = "Send crew details to Mattermost Chat Group";
            superToolTip53.Items.Add(toolTipTitleItem10);
            superToolTip53.Items.Add(toolTipItem51);
            this.btnSendMattermost.SuperTip = superToolTip53;
            this.btnSendMattermost.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSendMattermost_ItemClick);
            // 
            // btnValidateShifts
            // 
            this.btnValidateShifts.Caption = "Validate Shifts";
            this.btnValidateShifts.Id = 95;
            this.btnValidateShifts.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnValidateShifts.ImageOptions.SvgImage")));
            this.btnValidateShifts.Name = "btnValidateShifts";
            this.btnValidateShifts.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnValidateShifts_ItemClick);
            // 
            // btnPersonValidate
            // 
            this.btnPersonValidate.Caption = "Validate Shifts";
            this.btnPersonValidate.Id = 96;
            this.btnPersonValidate.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnPersonValidate.ImageOptions.SvgImage")));
            this.btnPersonValidate.Name = "btnPersonValidate";
            this.btnPersonValidate.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPersonValidate_ItemClick);
            // 
            // btnRiskRegister
            // 
            this.btnRiskRegister.Caption = "Risk Register";
            this.btnRiskRegister.Id = 97;
            this.btnRiskRegister.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnRiskRegister.ImageOptions.SvgImage")));
            this.btnRiskRegister.Name = "btnRiskRegister";
            this.btnRiskRegister.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRiskRegister_ItemClick);
            // 
            // BarButtonItem2
            // 
            this.BarButtonItem2.Caption = "Create Bill";
            this.BarButtonItem2.Id = 98;
            this.BarButtonItem2.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BarButtonItem2.ImageOptions.SvgImage")));
            this.BarButtonItem2.Name = "BarButtonItem2";
            this.BarButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItem2_ItemClick);
            // 
            // rbnMyHome
            // 
            this.rbnMyHome.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.RibbonPageGroup1,
            this.RibbonPageGroup2,
            this.RibbonPageGroup20,
            this.RibbonPageGroup21,
            this.RibbonPageGroup30,
            this.RibbonPageGroup33,
            this.RibbonPageGroup4,
            this.RibbonPageGroup18,
            this.RibbonPageGroup73});
            this.rbnMyHome.KeyTip = "M";
            this.rbnMyHome.Name = "rbnMyHome";
            this.rbnMyHome.Text = "My Home";
            // 
            // RibbonPageGroup1
            // 
            this.RibbonPageGroup1.ItemLinks.Add(this.btnShowWeb, "SH");
            this.RibbonPageGroup1.ItemLinks.Add(this.btnAvailability, "AV");
            this.RibbonPageGroup1.ItemLinks.Add(this.btnFilter, "F");
            this.RibbonPageGroup1.KeyTip = "CA";
            this.RibbonPageGroup1.Name = "RibbonPageGroup1";
            this.RibbonPageGroup1.Text = "Calendar";
            // 
            // RibbonPageGroup2
            // 
            this.RibbonPageGroup2.ItemLinks.Add(this.btnFilterBy);
            this.RibbonPageGroup2.ItemLinks.Add(this.BarButtonItem9);
            this.RibbonPageGroup2.ItemLinks.Add(this.btnResetInbox);
            this.RibbonPageGroup2.ItemLinks.Add(this.btnFutureTasks);
            this.RibbonPageGroup2.ItemLinks.Add(this.BtnRefresh, true, "RE");
            this.RibbonPageGroup2.KeyTip = "V";
            this.RibbonPageGroup2.Name = "RibbonPageGroup2";
            this.RibbonPageGroup2.Text = "View";
            // 
            // RibbonPageGroup20
            // 
            this.RibbonPageGroup20.ItemLinks.Add(this.btnAddTask, "AT");
            this.RibbonPageGroup20.ItemLinks.Add(this.btnAddLead, "AL");
            this.RibbonPageGroup20.KeyTip = "AD";
            this.RibbonPageGroup20.Name = "RibbonPageGroup20";
            this.RibbonPageGroup20.Text = "Admin";
            // 
            // RibbonPageGroup21
            // 
            this.RibbonPageGroup21.ItemLinks.Add(this.BtnShiftSheets, "SI");
            this.RibbonPageGroup21.ItemLinks.Add(this.btnCourseExpiry, "CO");
            this.RibbonPageGroup21.ItemLinks.Add(this.btnStaffCompliance, "ST");
            this.RibbonPageGroup21.ItemLinks.Add(this.btnInstructorsReminders, true);
            this.RibbonPageGroup21.ItemLinks.Add(this.btnMedicReminders);
            this.RibbonPageGroup21.ItemLinks.Add(this.btnGlobalCompliance, true, "G");
            this.RibbonPageGroup21.ItemLinks.Add(this.btnPhonebook);
            this.RibbonPageGroup21.KeyTip = "TS";
            this.RibbonPageGroup21.Name = "RibbonPageGroup21";
            this.RibbonPageGroup21.Text = "Tasks";
            // 
            // RibbonPageGroup30
            // 
            this.RibbonPageGroup30.ItemLinks.Add(this.btnWorkDiary, "W");
            this.RibbonPageGroup30.KeyTip = "RP";
            this.RibbonPageGroup30.Name = "RibbonPageGroup30";
            this.RibbonPageGroup30.Text = "Report";
            // 
            // RibbonPageGroup33
            // 
            this.RibbonPageGroup33.ItemLinks.Add(this.btnSanity, "SA");
            this.RibbonPageGroup33.KeyTip = "M";
            this.RibbonPageGroup33.Name = "RibbonPageGroup33";
            this.RibbonPageGroup33.Text = "Master";
            // 
            // RibbonPageGroup4
            // 
            this.RibbonPageGroup4.ItemLinks.Add(this.BarButtonItem22);
            this.RibbonPageGroup4.Name = "RibbonPageGroup4";
            this.RibbonPageGroup4.Text = "Quick Fire";
            // 
            // RibbonPageGroup18
            // 
            this.RibbonPageGroup18.ItemLinks.Add(this.btnGoToToday);
            this.RibbonPageGroup18.ItemLinks.Add(this.btnZoomIn);
            this.RibbonPageGroup18.ItemLinks.Add(this.BtnZoomOut);
            this.RibbonPageGroup18.Name = "RibbonPageGroup18";
            this.RibbonPageGroup18.Text = "Calendar";
            // 
            // RibbonPageGroup73
            // 
            this.RibbonPageGroup73.ItemLinks.Add(this.BtnCheckInvoice);
            this.RibbonPageGroup73.ItemLinks.Add(this.BarButtonItem2);
            this.RibbonPageGroup73.Name = "RibbonPageGroup73";
            this.RibbonPageGroup73.Text = "Tools";
            // 
            // rbnTraining
            // 
            this.rbnTraining.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.RibbonPageGroup3,
            this.RibbonPageGroup42,
            this.RibbonPageGroup55,
            this.RibbonPageBatchUpdate,
            this.RibbonPageGroup5,
            this.RibbonPageGroup6,
            this.RibbonPageGroup7,
            this.RibbonPageGroup8,
            this.RibbonPageGroup9,
            this.RibbonPageGroup10,
            this.RibbonPageGroup74});
            this.rbnTraining.KeyTip = "TR";
            this.rbnTraining.Name = "rbnTraining";
            this.rbnTraining.Text = "Training";
            // 
            // RibbonPageGroup3
            // 
            this.RibbonPageGroup3.ItemLinks.Add(this.btnNewCourse, "A");
            this.RibbonPageGroup3.ItemLinks.Add(this.btnEditCourse, "ED");
            this.RibbonPageGroup3.ItemLinks.Add(this.btnMultiAddCourse, "MU");
            this.RibbonPageGroup3.ItemLinks.Add(this.BarButtonItem7);
            this.RibbonPageGroup3.KeyTip = "CO";
            this.RibbonPageGroup3.Name = "RibbonPageGroup3";
            this.RibbonPageGroup3.Text = "Admin";
            // 
            // RibbonPageGroup42
            // 
            this.RibbonPageGroup42.AllowTextClipping = false;
            this.RibbonPageGroup42.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
            this.RibbonPageGroup42.ItemLinks.Add(this.BtnRefresh);
            this.RibbonPageGroup42.ItemLinks.Add(this.btnViewOptions);
            this.RibbonPageGroup42.ItemLinks.Add(this.btnMultiSelect);
            this.RibbonPageGroup42.ItemLinks.Add(this.btnGridExpand);
            this.RibbonPageGroup42.ItemLinks.Add(this.btnGridCollapse);
            this.RibbonPageGroup42.Name = "RibbonPageGroup42";
            this.RibbonPageGroup42.Text = "Grid";
            // 
            // RibbonPageGroup55
            // 
            this.RibbonPageGroup55.ItemLinks.Add(this.btnGridExport);
            this.RibbonPageGroup55.ItemLinks.Add(this.btnGridPrint);
            this.RibbonPageGroup55.ItemLinks.Add(this.btnBatchImport);
            this.RibbonPageGroup55.ItemLinks.Add(this.btnWebImport);
            this.RibbonPageGroup55.Name = "RibbonPageGroup55";
            this.RibbonPageGroup55.Text = "Data";
            // 
            // RibbonPageBatchUpdate
            // 
            this.RibbonPageBatchUpdate.Enabled = false;
            this.RibbonPageBatchUpdate.ItemLinks.Add(this.btnBatchUpdate, "BT");
            this.RibbonPageBatchUpdate.ItemLinks.Add(this.btnBatchCerts, "BH");
            this.RibbonPageBatchUpdate.ItemLinks.Add(this.btnInvoice);
            this.RibbonPageBatchUpdate.KeyTip = "BA";
            this.RibbonPageBatchUpdate.Name = "RibbonPageBatchUpdate";
            this.RibbonPageBatchUpdate.Text = "Batch";
            // 
            // RibbonPageGroup5
            // 
            this.RibbonPageGroup5.ItemLinks.Add(this.btnFindStudents, "FI");
            this.RibbonPageGroup5.KeyTip = "ST";
            this.RibbonPageGroup5.Name = "RibbonPageGroup5";
            this.RibbonPageGroup5.Text = "Students";
            // 
            // RibbonPageGroup6
            // 
            this.RibbonPageGroup6.ItemLinks.Add(this.btnTrainingAction, true);
            this.RibbonPageGroup6.ItemLinks.Add(this.btnOpenCourses, false, "SH", "", true);
            this.RibbonPageGroup6.ItemLinks.Add(this.btnCourseCurrent);
            this.RibbonPageGroup6.ItemLinks.Add(this.BtnAllCourses, "SO");
            this.RibbonPageGroup6.ItemLinks.Add(this.btnNotSet);
            this.RibbonPageGroup6.ItemLinks.Add(this.btnFlagged, true, "FL");
            this.RibbonPageGroup6.ItemLinks.Add(this.BarButtonItem4);
            this.RibbonPageGroup6.KeyTip = "VI";
            this.RibbonPageGroup6.Name = "RibbonPageGroup6";
            this.RibbonPageGroup6.State = DevExpress.XtraBars.Ribbon.RibbonPageGroupState.Expanded;
            this.RibbonPageGroup6.Text = "View";
            // 
            // RibbonPageGroup7
            // 
            this.RibbonPageGroup7.ItemLinks.Add(this.btnYesterday, "Y");
            this.RibbonPageGroup7.ItemLinks.Add(this.btnToday, "TO");
            this.RibbonPageGroup7.ItemLinks.Add(this.btnTomorrow, "TM");
            this.RibbonPageGroup7.KeyTip = "VE";
            this.RibbonPageGroup7.Name = "RibbonPageGroup7";
            this.RibbonPageGroup7.Text = "View Days";
            // 
            // RibbonPageGroup8
            // 
            this.RibbonPageGroup8.ItemLinks.Add(this.btnLastWeek, "LA");
            this.RibbonPageGroup8.ItemLinks.Add(this.btnThisWeek, "TH");
            this.RibbonPageGroup8.ItemLinks.Add(this.btnNextWeek, "NE");
            this.RibbonPageGroup8.KeyTip = "VW";
            this.RibbonPageGroup8.Name = "RibbonPageGroup8";
            this.RibbonPageGroup8.Text = "View Weeks";
            // 
            // RibbonPageGroup9
            // 
            this.RibbonPageGroup9.ItemLinks.Add(this.btnLastMonth, "LS");
            this.RibbonPageGroup9.ItemLinks.Add(this.btnThisMonth, "TI");
            this.RibbonPageGroup9.ItemLinks.Add(this.btnNextMonth, "NX");
            this.RibbonPageGroup9.KeyTip = "VM";
            this.RibbonPageGroup9.Name = "RibbonPageGroup9";
            this.RibbonPageGroup9.Text = "View Months";
            // 
            // RibbonPageGroup10
            // 
            this.RibbonPageGroup10.ItemLinks.Add(this.btnTrainingReturns, "RT");
            this.RibbonPageGroup10.ItemLinks.Add(this.btnStats, "SS");
            this.RibbonPageGroup10.KeyTip = "SA";
            this.RibbonPageGroup10.Name = "RibbonPageGroup10";
            this.RibbonPageGroup10.Text = "Statistics";
            // 
            // RibbonPageGroup74
            // 
            this.RibbonPageGroup74.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.True;
            this.RibbonPageGroup74.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            this.RibbonPageGroup74.ItemLinks.Add(this.rbnViewGallery, true);
            this.RibbonPageGroup74.Name = "RibbonPageGroup74";
            this.RibbonPageGroup74.State = DevExpress.XtraBars.Ribbon.RibbonPageGroupState.Expanded;
            this.RibbonPageGroup74.Text = "Filter && Views";
            // 
            // rbnPersonnel
            // 
            this.rbnPersonnel.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.RibbonPageGroup34,
            this.RibbonPageGroup19,
            this.RibbonPageGroup68,
            this.RibbonPageGroup31,
            this.RibbonPageGroup32,
            this.RibbonPageGroup35,
            this.RibbonPageGroup66,
            this.RibbonPageGroup71,
            this.RibbonPageGroup72});
            this.rbnPersonnel.KeyTip = "P";
            this.rbnPersonnel.Name = "rbnPersonnel";
            this.rbnPersonnel.Text = "Personnel";
            // 
            // RibbonPageGroup34
            // 
            this.RibbonPageGroup34.ItemLinks.Add(this.BarButtonItem10);
            this.RibbonPageGroup34.Name = "RibbonPageGroup34";
            this.RibbonPageGroup34.Text = "Admin";
            // 
            // RibbonPageGroup19
            // 
            this.RibbonPageGroup19.ItemLinks.Add(this.btnViewbyMedics, "M");
            this.RibbonPageGroup19.ItemLinks.Add(this.btnViewbyInstructors, "I");
            this.RibbonPageGroup19.ItemLinks.Add(this.BarSubItem1, "VE");
            this.RibbonPageGroup19.ItemLinks.Add(this.brByCourse, "B");
            this.RibbonPageGroup19.ItemLinks.Add(this.btnResetPersonnelView, "RE");
            this.RibbonPageGroup19.ItemLinks.Add(this.btnMap, true, "VW");
            this.RibbonPageGroup19.KeyTip = "VIE";
            this.RibbonPageGroup19.Name = "RibbonPageGroup19";
            this.RibbonPageGroup19.Text = "View By";
            // 
            // RibbonPageGroup68
            // 
            this.RibbonPageGroup68.Name = "RibbonPageGroup68";
            this.RibbonPageGroup68.Text = "Reports";
            // 
            // RibbonPageGroup31
            // 
            this.RibbonPageGroup31.ItemLinks.Add(this.btnSortName, "N");
            this.RibbonPageGroup31.ItemLinks.Add(this.btnSortLocation, "C");
            this.RibbonPageGroup31.KeyTip = "S";
            this.RibbonPageGroup31.Name = "RibbonPageGroup31";
            this.RibbonPageGroup31.Text = "Sort By";
            // 
            // RibbonPageGroup32
            // 
            this.RibbonPageGroup32.ItemLinks.Add(this.BtnRefresh, "RF");
            this.RibbonPageGroup32.ItemLinks.Add(this.btnViewOptions);
            this.RibbonPageGroup32.ItemLinks.Add(this.btnMultiSelect);
            this.RibbonPageGroup32.KeyTip = "VIW";
            this.RibbonPageGroup32.Name = "RibbonPageGroup32";
            this.RibbonPageGroup32.Text = "Grid";
            // 
            // RibbonPageGroup35
            // 
            this.RibbonPageGroup35.ItemLinks.Add(this.btnGridExport);
            this.RibbonPageGroup35.ItemLinks.Add(this.btnGridPrint);
            this.RibbonPageGroup35.Name = "RibbonPageGroup35";
            this.RibbonPageGroup35.Text = "Data";
            // 
            // RibbonPageGroup66
            // 
            this.RibbonPageGroup66.ItemLinks.Add(this.btnFilterBy);
            this.RibbonPageGroup66.Name = "RibbonPageGroup66";
            this.RibbonPageGroup66.Text = "View";
            // 
            // RibbonPageGroup71
            // 
            this.RibbonPageGroup71.ItemLinks.Add(this.btnAvailabilityPerson);
            this.RibbonPageGroup71.Name = "RibbonPageGroup71";
            this.RibbonPageGroup71.Text = "Tasks";
            // 
            // RibbonPageGroup72
            // 
            this.RibbonPageGroup72.ItemLinks.Add(this.btnImportInvoices);
            this.RibbonPageGroup72.Name = "RibbonPageGroup72";
            this.RibbonPageGroup72.Text = "Invoices";
            // 
            // rbnClinical
            // 
            this.rbnClinical.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.RibbonPageGroup11,
            this.RibbonPageGroup12,
            this.RibbonPageGroup43,
            this.RibbonPageGroup56,
            this.RibbonPageGroup13,
            this.RibbonPageGroup14,
            this.RibbonPageGroup15,
            this.RibbonPageGroup16,
            this.RibbonPageGroup17});
            this.rbnClinical.KeyTip = "C";
            this.rbnClinical.Name = "rbnClinical";
            this.rbnClinical.Text = "Clinical";
            // 
            // RibbonPageGroup11
            // 
            this.RibbonPageGroup11.ItemLinks.Add(this.btnClinicalAdd, "A");
            this.RibbonPageGroup11.ItemLinks.Add(this.BarButtonItem5);
            this.RibbonPageGroup11.ItemLinks.Add(this.btnAmbulanceControl);
            this.RibbonPageGroup11.KeyTip = "SH";
            this.RibbonPageGroup11.Name = "RibbonPageGroup11";
            this.RibbonPageGroup11.Text = "Admin";
            // 
            // RibbonPageGroup12
            // 
            this.RibbonPageGroup12.ItemLinks.Add(this.btnClinicalAudits, "C");
            this.RibbonPageGroup12.ItemLinks.Add(this.btnClinicalReports, "VI");
            this.RibbonPageGroup12.ItemLinks.Add(this.btnClinicalStats);
            this.RibbonPageGroup12.ItemLinks.Add(this.BarSubItem6);
            this.RibbonPageGroup12.ItemLinks.Add(this.btnClinicalKPI);
            this.RibbonPageGroup12.KeyTip = "RE";
            this.RibbonPageGroup12.Name = "RibbonPageGroup12";
            this.RibbonPageGroup12.Text = "Reports";
            // 
            // RibbonPageGroup43
            // 
            this.RibbonPageGroup43.ItemLinks.Add(this.BtnRefresh);
            this.RibbonPageGroup43.ItemLinks.Add(this.btnViewOptions);
            this.RibbonPageGroup43.ItemLinks.Add(this.btnMultiSelect);
            this.RibbonPageGroup43.ItemLinks.Add(this.btnGridExpand);
            this.RibbonPageGroup43.ItemLinks.Add(this.btnGridCollapse);
            this.RibbonPageGroup43.Name = "RibbonPageGroup43";
            this.RibbonPageGroup43.Text = "Grid";
            // 
            // RibbonPageGroup56
            // 
            this.RibbonPageGroup56.ItemLinks.Add(this.btnGridExport);
            this.RibbonPageGroup56.ItemLinks.Add(this.btnGridPrint);
            this.RibbonPageGroup56.Name = "RibbonPageGroup56";
            this.RibbonPageGroup56.Text = "Data";
            // 
            // RibbonPageGroup13
            // 
            this.RibbonPageGroup13.ItemLinks.Add(this.btnBatchUpdate, "BC");
            this.RibbonPageGroup13.ItemLinks.Add(this.btnInvoice);
            this.RibbonPageGroup13.ItemLinks.Add(this.btnSendMattermost);
            this.RibbonPageGroup13.ItemLinks.Add(this.btnValidateShifts);
            this.RibbonPageGroup13.KeyTip = "BA";
            this.RibbonPageGroup13.Name = "RibbonPageGroup13";
            this.RibbonPageGroup13.Text = "Batch";
            // 
            // RibbonPageGroup14
            // 
            this.RibbonPageGroup14.ItemLinks.Add(this.btnOpenCourses, "SO");
            this.RibbonPageGroup14.ItemLinks.Add(this.BtnAllCourses, "SW");
            this.RibbonPageGroup14.ItemLinks.Add(this.btnNotSet, "NO");
            this.RibbonPageGroup14.ItemLinks.Add(this.btnFlagged, "F");
            this.RibbonPageGroup14.KeyTip = "VE";
            this.RibbonPageGroup14.Name = "RibbonPageGroup14";
            this.RibbonPageGroup14.State = DevExpress.XtraBars.Ribbon.RibbonPageGroupState.Expanded;
            this.RibbonPageGroup14.Text = "View";
            // 
            // RibbonPageGroup15
            // 
            this.RibbonPageGroup15.ItemLinks.Add(this.btnYesterday, "Y");
            this.RibbonPageGroup15.ItemLinks.Add(this.btnToday, "TO");
            this.RibbonPageGroup15.ItemLinks.Add(this.btnTomorrow, "TM");
            this.RibbonPageGroup15.KeyTip = "VW";
            this.RibbonPageGroup15.Name = "RibbonPageGroup15";
            this.RibbonPageGroup15.Text = "View Day";
            // 
            // RibbonPageGroup16
            // 
            this.RibbonPageGroup16.ItemLinks.Add(this.btnLastWeek, "LA");
            this.RibbonPageGroup16.ItemLinks.Add(this.btnThisWeek, "TH");
            this.RibbonPageGroup16.ItemLinks.Add(this.btnNextWeek, "NE");
            this.RibbonPageGroup16.KeyTip = "VK";
            this.RibbonPageGroup16.Name = "RibbonPageGroup16";
            this.RibbonPageGroup16.Text = "View Week";
            // 
            // RibbonPageGroup17
            // 
            this.RibbonPageGroup17.ItemLinks.Add(this.btnLastMonth, "LS");
            this.RibbonPageGroup17.ItemLinks.Add(this.btnThisMonth, "TI");
            this.RibbonPageGroup17.ItemLinks.Add(this.btnNextMonth, "NX");
            this.RibbonPageGroup17.KeyTip = "VM";
            this.RibbonPageGroup17.Name = "RibbonPageGroup17";
            this.RibbonPageGroup17.Text = "View Month";
            // 
            // rbnLeads
            // 
            this.rbnLeads.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.RibbonPageGroup23,
            this.RibbonPageGroup44,
            this.RibbonPageGroup22,
            this.RibbonPageGroup24,
            this.RibbonPageGroup25});
            this.rbnLeads.KeyTip = "L";
            this.rbnLeads.Name = "rbnLeads";
            this.rbnLeads.Text = "Leads";
            // 
            // RibbonPageGroup23
            // 
            this.RibbonPageGroup23.ItemLinks.Add(this.btnNewLead);
            this.RibbonPageGroup23.KeyTip = "AD";
            this.RibbonPageGroup23.Name = "RibbonPageGroup23";
            this.RibbonPageGroup23.Text = "Admin";
            // 
            // RibbonPageGroup44
            // 
            this.RibbonPageGroup44.ItemLinks.Add(this.BtnRefresh);
            this.RibbonPageGroup44.ItemLinks.Add(this.btnViewOptions);
            this.RibbonPageGroup44.ItemLinks.Add(this.btnMultiSelect);
            this.RibbonPageGroup44.ItemLinks.Add(this.btnGridExpand);
            this.RibbonPageGroup44.ItemLinks.Add(this.btnGridCollapse);
            this.RibbonPageGroup44.Name = "RibbonPageGroup44";
            this.RibbonPageGroup44.Text = "Grid";
            // 
            // RibbonPageGroup22
            // 
            this.RibbonPageGroup22.ItemLinks.Add(this.btnGridExport);
            this.RibbonPageGroup22.ItemLinks.Add(this.btnGridPrint);
            this.RibbonPageGroup22.KeyTip = "V";
            this.RibbonPageGroup22.Name = "RibbonPageGroup22";
            this.RibbonPageGroup22.Text = "Data";
            // 
            // RibbonPageGroup24
            // 
            this.RibbonPageGroup24.ItemLinks.Add(this.btnAllLeads, "AL");
            this.RibbonPageGroup24.ItemLinks.Add(this.btnClosedLost, "CL");
            this.RibbonPageGroup24.ItemLinks.Add(this.btnClosedWon, "CO");
            this.RibbonPageGroup24.ItemLinks.Add(this.btnOpenLeads, "O");
            this.RibbonPageGroup24.ItemLinks.Add(this.btnMyLeads, "M");
            this.RibbonPageGroup24.KeyTip = "F";
            this.RibbonPageGroup24.Name = "RibbonPageGroup24";
            this.RibbonPageGroup24.Text = "Find";
            // 
            // RibbonPageGroup25
            // 
            this.RibbonPageGroup25.ItemLinks.Add(this.BarEditItem4, "BC");
            this.RibbonPageGroup25.ItemLinks.Add(this.btnClearFilter, "CE");
            this.RibbonPageGroup25.KeyTip = "BY";
            this.RibbonPageGroup25.Name = "RibbonPageGroup25";
            this.RibbonPageGroup25.Text = "By Interest";
            // 
            // rbnTasks
            // 
            this.rbnTasks.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.RibbonPageGroup57,
            this.RibbonPageGroup45,
            this.RibbonPageGroup58});
            this.rbnTasks.KeyTip = "TA";
            this.rbnTasks.Name = "rbnTasks";
            this.rbnTasks.Text = "Tasks";
            // 
            // RibbonPageGroup57
            // 
            this.RibbonPageGroup57.Name = "RibbonPageGroup57";
            this.RibbonPageGroup57.Text = "Admin";
            // 
            // RibbonPageGroup45
            // 
            this.RibbonPageGroup45.ItemLinks.Add(this.BtnRefresh);
            this.RibbonPageGroup45.ItemLinks.Add(this.btnViewOptions);
            this.RibbonPageGroup45.ItemLinks.Add(this.btnMultiSelect);
            this.RibbonPageGroup45.ItemLinks.Add(this.btnGridExpand);
            this.RibbonPageGroup45.ItemLinks.Add(this.btnGridCollapse);
            this.RibbonPageGroup45.Name = "RibbonPageGroup45";
            this.RibbonPageGroup45.Text = "Grid";
            // 
            // RibbonPageGroup58
            // 
            this.RibbonPageGroup58.ItemLinks.Add(this.btnGridExport);
            this.RibbonPageGroup58.ItemLinks.Add(this.btnGridPrint);
            this.RibbonPageGroup58.Name = "RibbonPageGroup58";
            this.RibbonPageGroup58.Text = "Data";
            // 
            // rbnRisk
            // 
            this.rbnRisk.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.RibbonPageGroup39,
            this.RibbonPageGroup47,
            this.RibbonPageGroup60,
            this.RibbonPageGroup59});
            this.rbnRisk.KeyTip = "R";
            this.rbnRisk.Name = "rbnRisk";
            this.rbnRisk.Text = "Risk";
            // 
            // RibbonPageGroup39
            // 
            this.RibbonPageGroup39.ItemLinks.Add(this.BarButtonItem15);
            this.RibbonPageGroup39.Name = "RibbonPageGroup39";
            this.RibbonPageGroup39.Text = "Actions";
            // 
            // RibbonPageGroup47
            // 
            this.RibbonPageGroup47.ItemLinks.Add(this.BtnRefresh);
            this.RibbonPageGroup47.ItemLinks.Add(this.btnViewOptions);
            this.RibbonPageGroup47.ItemLinks.Add(this.btnMultiSelect);
            this.RibbonPageGroup47.ItemLinks.Add(this.btnGridExpand);
            this.RibbonPageGroup47.ItemLinks.Add(this.btnGridCollapse);
            this.RibbonPageGroup47.Name = "RibbonPageGroup47";
            this.RibbonPageGroup47.Text = "Grid";
            // 
            // RibbonPageGroup60
            // 
            this.RibbonPageGroup60.ItemLinks.Add(this.btnGridExport);
            this.RibbonPageGroup60.ItemLinks.Add(this.btnGridPrint);
            this.RibbonPageGroup60.ItemLinks.Add(this.btnRiskRegister);
            this.RibbonPageGroup60.Name = "RibbonPageGroup60";
            this.RibbonPageGroup60.Text = "Data";
            // 
            // RibbonPageGroup59
            // 
            this.RibbonPageGroup59.ItemLinks.Add(this.btnRiskRecategorise);
            this.RibbonPageGroup59.Name = "RibbonPageGroup59";
            this.RibbonPageGroup59.Text = "Admin";
            // 
            // rbnGovernance
            // 
            this.rbnGovernance.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.RibbonPageGroup27,
            this.RibbonPageGroup28,
            this.RibbonPageGroup70,
            this.RibbonPageGroup29,
            this.RibbonPageGroup48,
            this.RibbonPageGroup61,
            this.RibbonPageGroup26,
            this.RibbonPageGroup69,
            this.RibbonPageGroup50});
            this.rbnGovernance.KeyTip = "G";
            this.rbnGovernance.Name = "rbnGovernance";
            this.rbnGovernance.Text = "Governance";
            // 
            // RibbonPageGroup27
            // 
            this.RibbonPageGroup27.ItemLinks.Add(this.btnAddItem, "AD");
            this.RibbonPageGroup27.ItemLinks.Add(this.btnGovTemplate);
            this.RibbonPageGroup27.KeyTip = "AC";
            this.RibbonPageGroup27.Name = "RibbonPageGroup27";
            this.RibbonPageGroup27.Text = "Actions";
            // 
            // RibbonPageGroup28
            // 
            this.RibbonPageGroup28.ItemLinks.Add(this.btnFilterStandards, "SA");
            this.RibbonPageGroup28.ItemLinks.Add(this.btnFilterPolicies, "P");
            this.RibbonPageGroup28.ItemLinks.Add(this.btnFilterEvidence, "EV");
            this.RibbonPageGroup28.ItemLinks.Add(this.btnFilterKPI, "K");
            this.RibbonPageGroup28.ItemLinks.Add(this.btnFilterViewAll, true, "VI");
            this.RibbonPageGroup28.ItemLinks.Add(this.btnForReview, true);
            this.RibbonPageGroup28.ItemLinks.Add(this.btnFilterBy);
            this.RibbonPageGroup28.KeyTip = "F";
            this.RibbonPageGroup28.Name = "RibbonPageGroup28";
            this.RibbonPageGroup28.Text = "Filter";
            // 
            // RibbonPageGroup70
            // 
            this.RibbonPageGroup70.ItemLinks.Add(this.btnGovShowApplicable);
            this.RibbonPageGroup70.ItemLinks.Add(this.BarEditItem7);
            this.RibbonPageGroup70.Name = "RibbonPageGroup70";
            this.RibbonPageGroup70.Text = "View";
            // 
            // RibbonPageGroup29
            // 
            this.RibbonPageGroup29.ItemLinks.Add(this.btnExpandAll, "EX");
            this.RibbonPageGroup29.ItemLinks.Add(this.btnCollapseAll, "C");
            this.RibbonPageGroup29.ItemLinks.Add(this.btnClearTreeFilter);
            this.RibbonPageGroup29.KeyTip = "VS";
            this.RibbonPageGroup29.Name = "RibbonPageGroup29";
            this.RibbonPageGroup29.Text = "Tree";
            // 
            // RibbonPageGroup48
            // 
            this.RibbonPageGroup48.ItemLinks.Add(this.BtnRefresh);
            this.RibbonPageGroup48.ItemLinks.Add(this.btnViewOptions);
            this.RibbonPageGroup48.ItemLinks.Add(this.btnMultiSelect);
            this.RibbonPageGroup48.ItemLinks.Add(this.btnGridExpand);
            this.RibbonPageGroup48.ItemLinks.Add(this.btnGridCollapse);
            this.RibbonPageGroup48.Name = "RibbonPageGroup48";
            this.RibbonPageGroup48.Text = "Grid";
            // 
            // RibbonPageGroup61
            // 
            this.RibbonPageGroup61.ItemLinks.Add(this.btnGridExport);
            this.RibbonPageGroup61.ItemLinks.Add(this.btnGridPrint);
            this.RibbonPageGroup61.Name = "RibbonPageGroup61";
            this.RibbonPageGroup61.Text = "Data";
            // 
            // RibbonPageGroup26
            // 
            this.RibbonPageGroup26.ItemLinks.Add(this.btnStats, "ST");
            this.RibbonPageGroup26.ItemLinks.Add(this.btnGovReporting);
            this.RibbonPageGroup26.KeyTip = "RE";
            this.RibbonPageGroup26.Name = "RibbonPageGroup26";
            this.RibbonPageGroup26.Text = "Reporting";
            // 
            // RibbonPageGroup69
            // 
            this.RibbonPageGroup69.ItemLinks.Add(this.chkCaptureCopy);
            this.RibbonPageGroup69.ItemLinks.Add(this.btnViewOverview);
            this.RibbonPageGroup69.ItemLinks.Add(this.btnFindAfterDrag);
            this.RibbonPageGroup69.ItemLinks.Add(this.btnValidateFiles);
            this.RibbonPageGroup69.Name = "RibbonPageGroup69";
            this.RibbonPageGroup69.Text = "Advanced";
            // 
            // RibbonPageGroup50
            // 
            this.RibbonPageGroup50.ItemLinks.Add(this.BarButtonItem31);
            this.RibbonPageGroup50.Name = "RibbonPageGroup50";
            this.RibbonPageGroup50.Text = "Processes";
            // 
            // rbnDocuments
            // 
            this.rbnDocuments.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.RibbonPageGroup37,
            this.RibbonPageGroup38,
            this.RibbonPageGroup49,
            this.RibbonPageGroup62,
            this.RibbonPageGroup63});
            this.rbnDocuments.Name = "rbnDocuments";
            reduceOperation1.Behavior = DevExpress.XtraBars.Ribbon.ReduceOperationBehavior.Single;
            reduceOperation1.GroupName = "RibbonPageGroup63";
            reduceOperation1.ItemLinkIndex = 0;
            reduceOperation1.ItemLinksCount = 0;
            reduceOperation1.Operation = DevExpress.XtraBars.Ribbon.ReduceOperationType.Gallery;
            this.rbnDocuments.ReduceOperations.Add(reduceOperation1);
            this.rbnDocuments.Text = "Documents";
            // 
            // RibbonPageGroup37
            // 
            this.RibbonPageGroup37.ItemLinks.Add(this.btnAddDocument);
            this.RibbonPageGroup37.Name = "RibbonPageGroup37";
            this.RibbonPageGroup37.Text = "Admin";
            // 
            // RibbonPageGroup38
            // 
            this.RibbonPageGroup38.ItemLinks.Add(this.BarButtonItem13);
            this.RibbonPageGroup38.ItemLinks.Add(this.BarButtonItem14);
            this.RibbonPageGroup38.ItemLinks.Add(this.btnFilterBy);
            this.RibbonPageGroup38.Name = "RibbonPageGroup38";
            this.RibbonPageGroup38.Text = "Show";
            // 
            // RibbonPageGroup49
            // 
            this.RibbonPageGroup49.ItemLinks.Add(this.BtnRefresh);
            this.RibbonPageGroup49.ItemLinks.Add(this.btnViewOptions);
            this.RibbonPageGroup49.ItemLinks.Add(this.btnMultiSelect);
            this.RibbonPageGroup49.ItemLinks.Add(this.btnGridExpand);
            this.RibbonPageGroup49.ItemLinks.Add(this.btnGridCollapse);
            this.RibbonPageGroup49.Name = "RibbonPageGroup49";
            this.RibbonPageGroup49.Text = "Grid";
            // 
            // RibbonPageGroup62
            // 
            this.RibbonPageGroup62.ItemLinks.Add(this.btnGridExport);
            this.RibbonPageGroup62.ItemLinks.Add(this.btnGridPrint);
            this.RibbonPageGroup62.Name = "RibbonPageGroup62";
            this.RibbonPageGroup62.Text = "Data";
            // 
            // RibbonPageGroup63
            // 
            this.RibbonPageGroup63.ItemLinks.Add(this.RibbonGalleryBarItem2);
            this.RibbonPageGroup63.Name = "RibbonPageGroup63";
            this.RibbonPageGroup63.Text = "Document";
            // 
            // rbnAudit
            // 
            this.rbnAudit.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.RibbonPageGroup41,
            this.RibbonPageGroup51,
            this.RibbonPageGroup64,
            this.RibbonPageGroup67});
            this.rbnAudit.Name = "rbnAudit";
            this.rbnAudit.Text = "Audit";
            // 
            // RibbonPageGroup41
            // 
            this.RibbonPageGroup41.ItemLinks.Add(this.BarButtonItem18);
            this.RibbonPageGroup41.Name = "RibbonPageGroup41";
            this.RibbonPageGroup41.Text = "Admin";
            // 
            // RibbonPageGroup51
            // 
            this.RibbonPageGroup51.ItemLinks.Add(this.BtnRefresh);
            this.RibbonPageGroup51.ItemLinks.Add(this.btnViewOptions);
            this.RibbonPageGroup51.ItemLinks.Add(this.btnMultiSelect);
            this.RibbonPageGroup51.ItemLinks.Add(this.btnGridExpand);
            this.RibbonPageGroup51.ItemLinks.Add(this.btnGridCollapse);
            this.RibbonPageGroup51.Name = "RibbonPageGroup51";
            this.RibbonPageGroup51.Text = "Grid";
            // 
            // RibbonPageGroup64
            // 
            this.RibbonPageGroup64.ItemLinks.Add(this.btnGridExport);
            this.RibbonPageGroup64.ItemLinks.Add(this.btnGridPrint);
            this.RibbonPageGroup64.Name = "RibbonPageGroup64";
            this.RibbonPageGroup64.Text = "Data";
            // 
            // RibbonPageGroup67
            // 
            this.RibbonPageGroup67.ItemLinks.Add(this.btnFilterBy);
            this.RibbonPageGroup67.Name = "RibbonPageGroup67";
            this.RibbonPageGroup67.Text = "View";
            // 
            // rbnContacts
            // 
            this.rbnContacts.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.RibbonPageGroup53,
            this.RibbonPageGroup54,
            this.RibbonPageGroup65});
            this.rbnContacts.Name = "rbnContacts";
            this.rbnContacts.Text = "Contacts";
            // 
            // RibbonPageGroup53
            // 
            this.RibbonPageGroup53.ItemLinks.Add(this.BtnRefresh);
            this.RibbonPageGroup53.ItemLinks.Add(this.btnViewOptions);
            this.RibbonPageGroup53.ItemLinks.Add(this.btnMultiSelect);
            this.RibbonPageGroup53.ItemLinks.Add(this.btnGridExpand);
            this.RibbonPageGroup53.ItemLinks.Add(this.btnGridCollapse);
            this.RibbonPageGroup53.Name = "RibbonPageGroup53";
            this.RibbonPageGroup53.Text = "Grid";
            // 
            // RibbonPageGroup54
            // 
            this.RibbonPageGroup54.ItemLinks.Add(this.BarButtonItem19);
            this.RibbonPageGroup54.ItemLinks.Add(this.btnFilterBy);
            this.RibbonPageGroup54.Name = "RibbonPageGroup54";
            this.RibbonPageGroup54.Text = "View";
            // 
            // RibbonPageGroup65
            // 
            this.RibbonPageGroup65.ItemLinks.Add(this.btnGridExport);
            this.RibbonPageGroup65.ItemLinks.Add(this.btnGridPrint);
            this.RibbonPageGroup65.Name = "RibbonPageGroup65";
            this.RibbonPageGroup65.Text = "Data";
            // 
            // ViewRibbonPage1
            // 
            this.ViewRibbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ActiveViewRibbonPageGroup1,
            this.TimeScaleRibbonPageGroup1,
            this.LayoutRibbonPageGroup1});
            this.ViewRibbonPage1.Name = "ViewRibbonPage1";
            // 
            // ActiveViewRibbonPageGroup1
            // 
            this.ActiveViewRibbonPageGroup1.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
            this.ActiveViewRibbonPageGroup1.ItemLinks.Add(this.SwitchToDayViewItem1);
            this.ActiveViewRibbonPageGroup1.ItemLinks.Add(this.SwitchToWorkWeekViewItem1);
            this.ActiveViewRibbonPageGroup1.ItemLinks.Add(this.SwitchToWeekViewItem1);
            this.ActiveViewRibbonPageGroup1.ItemLinks.Add(this.SwitchToFullWeekViewItem1);
            this.ActiveViewRibbonPageGroup1.ItemLinks.Add(this.SwitchToMonthViewItem1);
            this.ActiveViewRibbonPageGroup1.ItemLinks.Add(this.SwitchToTimelineViewItem1);
            this.ActiveViewRibbonPageGroup1.ItemLinks.Add(this.SwitchToGanttViewItem1);
            this.ActiveViewRibbonPageGroup1.ItemLinks.Add(this.SwitchToAgendaViewItem1);
            this.ActiveViewRibbonPageGroup1.Name = "ActiveViewRibbonPageGroup1";
            // 
            // TimeScaleRibbonPageGroup1
            // 
            this.TimeScaleRibbonPageGroup1.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
            this.TimeScaleRibbonPageGroup1.ItemLinks.Add(this.SwitchTimeScalesItem1);
            this.TimeScaleRibbonPageGroup1.ItemLinks.Add(this.ChangeScaleWidthItem1);
            this.TimeScaleRibbonPageGroup1.ItemLinks.Add(this.SwitchTimeScalesCaptionItem1);
            this.TimeScaleRibbonPageGroup1.Name = "TimeScaleRibbonPageGroup1";
            // 
            // LayoutRibbonPageGroup1
            // 
            this.LayoutRibbonPageGroup1.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
            this.LayoutRibbonPageGroup1.ItemLinks.Add(this.SwitchCompressWeekendItem1);
            this.LayoutRibbonPageGroup1.ItemLinks.Add(this.SwitchShowWorkTimeOnlyItem1);
            this.LayoutRibbonPageGroup1.ItemLinks.Add(this.SwitchCellsAutoHeightItem1);
            this.LayoutRibbonPageGroup1.ItemLinks.Add(this.ChangeSnapToCellsUIItem1);
            this.LayoutRibbonPageGroup1.Name = "LayoutRibbonPageGroup1";
            // 
            // rbnFlagged
            // 
            this.rbnFlagged.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.RibbonPageGroup36,
            this.RibbonPageGroup52});
            this.rbnFlagged.Name = "rbnFlagged";
            this.rbnFlagged.Text = "Flagged Issues";
            // 
            // RibbonPageGroup36
            // 
            this.RibbonPageGroup36.ItemLinks.Add(this.btnFlaggedReport);
            this.RibbonPageGroup36.Name = "RibbonPageGroup36";
            this.RibbonPageGroup36.Text = "Reporting";
            // 
            // RibbonPageGroup52
            // 
            this.RibbonPageGroup52.ItemLinks.Add(this.btnFlag_Add);
            this.RibbonPageGroup52.Name = "RibbonPageGroup52";
            this.RibbonPageGroup52.Text = "Operations";
            // 
            // rbnNotes
            // 
            this.rbnNotes.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.RibbonPageGroup40});
            this.rbnNotes.Name = "rbnNotes";
            this.rbnNotes.Text = "Notes";
            // 
            // RibbonPageGroup40
            // 
            this.RibbonPageGroup40.ItemLinks.Add(this.btnAddNote);
            this.RibbonPageGroup40.Name = "RibbonPageGroup40";
            this.RibbonPageGroup40.Text = "Notes";
            // 
            // rbnTaskList
            // 
            this.rbnTaskList.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.RibbonPageGroup46});
            this.rbnTaskList.Name = "rbnTaskList";
            this.rbnTaskList.Text = "Tasks";
            // 
            // RibbonPageGroup46
            // 
            this.RibbonPageGroup46.ItemLinks.Add(this.BarButtonItem30);
            this.RibbonPageGroup46.Name = "RibbonPageGroup46";
            this.RibbonPageGroup46.Text = "Admin";
            // 
            // RibbonStatusBar1
            // 
            this.RibbonStatusBar1.ItemLinks.Add(this.brUser);
            this.RibbonStatusBar1.ItemLinks.Add(this.brLocale);
            this.RibbonStatusBar1.ItemLinks.Add(this.brIP);
            this.RibbonStatusBar1.ItemLinks.Add(this.brLoggedUsers);
            this.RibbonStatusBar1.ItemLinks.Add(this.brSecurity, true);
            this.RibbonStatusBar1.ItemLinks.Add(this.brShares);
            this.RibbonStatusBar1.ItemLinks.Add(this.brProgress);
            this.RibbonStatusBar1.ItemLinks.Add(this.br64);
            this.RibbonStatusBar1.ItemLinks.Add(this.brVersion);
            this.RibbonStatusBar1.ItemLinks.Add(this.brWebAccess);
            this.RibbonStatusBar1.ItemLinks.Add(this.brInfo);
            this.RibbonStatusBar1.ItemLinks.Add(this.BarEditItem6);
            this.RibbonStatusBar1.Location = new System.Drawing.Point(0, 1008);
            this.RibbonStatusBar1.Margin = new System.Windows.Forms.Padding(8);
            this.RibbonStatusBar1.Name = "RibbonStatusBar1";
            this.RibbonStatusBar1.Ribbon = this.RibbonControl1;
            this.RibbonStatusBar1.Size = new System.Drawing.Size(1839, 37);
            // 
            // PersonnellDataSet
            // 
            this.PersonnellDataSet.DataSetName = "PersonnellDataSet";
            this.PersonnellDataSet.Locale = new System.Globalization.CultureInfo("en-IE");
            this.PersonnellDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // GridColumn7
            // 
            this.GridColumn7.Caption = " ";
            this.GridColumn7.ColumnEdit = this.RepositoryItemCheckEdit10;
            this.GridColumn7.FieldName = "Flag";
            this.GridColumn7.MaxWidth = 86;
            this.GridColumn7.MinWidth = 68;
            this.GridColumn7.Name = "GridColumn7";
            this.GridColumn7.OptionsColumn.AllowEdit = false;
            this.GridColumn7.Visible = true;
            this.GridColumn7.VisibleIndex = 2;
            this.GridColumn7.Width = 86;
            // 
            // RepositoryItemCheckEdit10
            // 
            this.RepositoryItemCheckEdit10.AutoHeight = false;
            this.RepositoryItemCheckEdit10.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            this.RepositoryItemCheckEdit10.Name = "RepositoryItemCheckEdit10";
            // 
            // LeadListBindingSource
            // 
            this.LeadListBindingSource.DataMember = "Lead_List";
            this.LeadListBindingSource.DataSource = this.LeadsDataSet;
            // 
            // LeadsDataSet
            // 
            this.LeadsDataSet.DataSetName = "LeadsDataSet";
            this.LeadsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // RepositoryItemImageComboBox1
            // 
            this.RepositoryItemImageComboBox1.AutoHeight = false;
            this.RepositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RepositoryItemImageComboBox1.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", 0, 0),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", 1, 1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", 2, 2),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", 3, 3),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", 5, 5),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", 6, 6),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", 7, 7),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", 8, 8),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", 9, 9),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", 0, 0),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", 1, 1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", 2, 2),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", 3, 3),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", 5, 5),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", 6, 6),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", 7, 7),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", 8, 8),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", 9, 9)});
            this.RepositoryItemImageComboBox1.Name = "RepositoryItemImageComboBox1";
            this.RepositoryItemImageComboBox1.SmallImages = this.imgEmail;
            // 
            // RepositoryItemCheckEdit9
            // 
            this.RepositoryItemCheckEdit9.AutoHeight = false;
            this.RepositoryItemCheckEdit9.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            this.RepositoryItemCheckEdit9.Name = "RepositoryItemCheckEdit9";
            // 
            // ttTree
            // 
            this.ttTree.GetActiveObjectInfo += new DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventHandler(this.ToolTipController1_GetActiveObjectInfo);
            // 
            // RibbonPage2
            // 
            this.RibbonPage2.Name = "RibbonPage2";
            this.RibbonPage2.Text = "RibbonPage2";
            // 
            // NavBarGroup1
            // 
            this.NavBarGroup1.Caption = "Main";
            this.NavBarGroup1.Expanded = true;
            this.NavBarGroup1.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsText;
            this.NavBarGroup1.ImageOptions.SmallImageSize = new System.Drawing.Size(16, 16);
            this.NavBarGroup1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("NavBarGroup1.ImageOptions.SvgImage")));
            this.NavBarGroup1.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.nvMyDashBoard),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nvHome),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nvCalendar),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nvNotes),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nvTraining),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nvClinical),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nvPersonnel),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nvEquipment),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nvVehicles),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nvReportCentre)});
            this.NavBarGroup1.Name = "NavBarGroup1";
            this.NavBarGroup1.ShowIcons = DevExpress.Utils.DefaultBoolean.True;
            // 
            // nvMyDashBoard
            // 
            this.nvMyDashBoard.Caption = "My Dashboard";
            this.nvMyDashBoard.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("nvMyDashBoard.ImageOptions.LargeImage")));
            this.nvMyDashBoard.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("nvMyDashBoard.ImageOptions.SmallImage")));
            this.nvMyDashBoard.Name = "nvMyDashBoard";
            this.nvMyDashBoard.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nvMyDashBoard_LinkClicked);
            // 
            // nvHome
            // 
            this.nvHome.Caption = "Inbox";
            this.nvHome.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("nvHome.ImageOptions.LargeImage")));
            this.nvHome.Name = "nvHome";
            this.nvHome.LinkPressed += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.NvHome_LinkPressed);
            // 
            // nvCalendar
            // 
            this.nvCalendar.Caption = "Calendar";
            this.nvCalendar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("nvCalendar.ImageOptions.SvgImage")));
            this.nvCalendar.Name = "nvCalendar";
            this.nvCalendar.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nvCalendar_LinkClicked);
            // 
            // nvNotes
            // 
            this.nvNotes.Caption = "Notes";
            this.nvNotes.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("nvNotes.ImageOptions.SvgImage")));
            this.nvNotes.Name = "nvNotes";
            this.nvNotes.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.NvNotes_LinkClicked);
            // 
            // nvTraining
            // 
            this.nvTraining.Caption = "Training Courses";
            this.nvTraining.ImageOptions.SmallImageSize = new System.Drawing.Size(28, 8);
            this.nvTraining.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("nvTraining.ImageOptions.SvgImage")));
            this.nvTraining.Name = "nvTraining";
            this.nvTraining.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nvTraining_LinkClicked);
            // 
            // nvClinical
            // 
            this.nvClinical.Caption = "Clinical Services";
            this.nvClinical.ImageOptions.LargeImageSize = new System.Drawing.Size(32, 32);
            this.nvClinical.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("nvClinical.ImageOptions.SvgImage")));
            this.nvClinical.Name = "nvClinical";
            this.nvClinical.LinkPressed += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.NvClinical_LinkPressed);
            // 
            // nvPersonnel
            // 
            this.nvPersonnel.Caption = "Personnel";
            this.nvPersonnel.ImageOptions.LargeImageSize = new System.Drawing.Size(32, 32);
            this.nvPersonnel.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("nvPersonnel.ImageOptions.SvgImage")));
            this.nvPersonnel.Name = "nvPersonnel";
            this.nvPersonnel.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nvPersonnel_LinkClicked);
            // 
            // nvEquipment
            // 
            this.nvEquipment.Caption = "Equipment";
            this.nvEquipment.ImageOptions.LargeImageSize = new System.Drawing.Size(32, 32);
            this.nvEquipment.ImageOptions.SmallImageSize = new System.Drawing.Size(32, 32);
            this.nvEquipment.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("nvEquipment.ImageOptions.SvgImage")));
            this.nvEquipment.Name = "nvEquipment";
            this.nvEquipment.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nvEquipment_LinkClicked);
            // 
            // nvVehicles
            // 
            this.nvVehicles.Caption = "Vehicles";
            this.nvVehicles.ImageOptions.LargeImageSize = new System.Drawing.Size(32, 32);
            this.nvVehicles.ImageOptions.SmallImageSize = new System.Drawing.Size(16, 16);
            this.nvVehicles.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("nvVehicles.ImageOptions.SvgImage")));
            this.nvVehicles.Name = "nvVehicles";
            this.nvVehicles.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nvVehicles_LinkClicked);
            // 
            // nvReportCentre
            // 
            this.nvReportCentre.Caption = "Report Centre";
            this.nvReportCentre.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("nvReportCentre.ImageOptions.SvgImage")));
            this.nvReportCentre.Name = "nvReportCentre";
            this.nvReportCentre.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nvReportCentre_LinkClicked_1);
            // 
            // nvSales
            // 
            this.nvSales.Caption = "Leads";
            this.nvSales.ImageOptions.SmallImageSize = new System.Drawing.Size(20, 20);
            this.nvSales.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("nvSales.ImageOptions.SvgImage")));
            this.nvSales.Name = "nvSales";
            this.nvSales.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nvSales_LinkClicked);
            // 
            // nvDocuments
            // 
            this.nvDocuments.Caption = "Documents";
            this.nvDocuments.ImageOptions.SmallImageSize = new System.Drawing.Size(20, 20);
            this.nvDocuments.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("nvDocuments.ImageOptions.SvgImage")));
            this.nvDocuments.Name = "nvDocuments";
            this.nvDocuments.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navDocuments_LinkClicked);
            // 
            // nvAudit
            // 
            this.nvAudit.Caption = "Audit";
            this.nvAudit.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("nvAudit.ImageOptions.SvgImage")));
            this.nvAudit.Name = "nvAudit";
            this.nvAudit.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nvQuality_LinkClicked);
            // 
            // nvRisk
            // 
            this.nvRisk.Caption = "Risk";
            this.nvRisk.ImageOptions.LargeImageSize = new System.Drawing.Size(32, 32);
            this.nvRisk.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("nvRisk.ImageOptions.SvgImage")));
            this.nvRisk.Name = "nvRisk";
            this.nvRisk.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.NvRisk_LinkClicked);
            // 
            // nvGovernance
            // 
            this.nvGovernance.Caption = "Governance";
            this.nvGovernance.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("nvGovernance.ImageOptions.SvgImage")));
            this.nvGovernance.Name = "nvGovernance";
            this.nvGovernance.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nvGovernance_LinkClicked);
            // 
            // schWeb
            // 
            this.schWeb.AppointmentDependencies.DataSource = this.WebUpcomingBindingSource;
            this.schWeb.AppointmentDependencies.Mappings.DependentId = "StartDate";
            this.schWeb.AppointmentDependencies.Mappings.Type = "ID";
            this.schWeb.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("ID", "ID"));
            this.schWeb.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("Instructor", "Instructor"));
            this.schWeb.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("TableSort", "TableSort"));
            this.schWeb.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("Published", "Published"));
            this.schWeb.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("ItemType", "ItemType"));
            this.schWeb.Appointments.DataSource = this.WebUpcomingBindingSource;
            this.schWeb.Appointments.Mappings.AllDay = "AllDay";
            this.schWeb.Appointments.Mappings.Description = "Label";
            this.schWeb.Appointments.Mappings.End = "FinishDate";
            this.schWeb.Appointments.Mappings.Label = "Label";
            this.schWeb.Appointments.Mappings.Location = "Location";
            this.schWeb.Appointments.Mappings.Start = "StartDate";
            this.schWeb.Appointments.Mappings.Subject = "Label";
            // 
            // WebUpcomingBindingSource
            // 
            this.WebUpcomingBindingSource.DataMember = "WebUpcoming";
            this.WebUpcomingBindingSource.DataSource = this.WebDataSet;
            // 
            // WebDataSet
            // 
            this.WebDataSet.DataSetName = "WebDataSet";
            this.WebDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // SchedulerStorage
            // 
            this.SchedulerStorage.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("ID", "ID"));
            this.SchedulerStorage.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("Instructor", "Instructor"));
            this.SchedulerStorage.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("TableSort", "TableSort"));
            this.SchedulerStorage.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("Sub", "Sub"));
            this.SchedulerStorage.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("ItemType", "ItemType"));
            this.SchedulerStorage.Appointments.DataSource = this.UpcomingBindingSource;
            this.SchedulerStorage.Appointments.Mappings.AllDay = "Allday";
            this.SchedulerStorage.Appointments.Mappings.End = "FinishDate";
            this.SchedulerStorage.Appointments.Mappings.Location = "Location";
            this.SchedulerStorage.Appointments.Mappings.Start = "StartDate";
            this.SchedulerStorage.Appointments.Mappings.Status = "Status";
            this.SchedulerStorage.Appointments.Mappings.Subject = "Label";
            this.SchedulerStorage.FilterAppointment += new DevExpress.XtraScheduler.PersistentObjectCancelEventHandler(this.SchedulerStorage_FilterAppointment);
            this.SchedulerStorage.FetchAppointments += new DevExpress.XtraScheduler.FetchAppointmentsEventHandler(this.SchedulerStorage_FetchAppointments);
            // 
            // UpcomingBindingSource
            // 
            this.UpcomingBindingSource.DataMember = "Upcoming";
            this.UpcomingBindingSource.DataSource = this.MainDataSet;
            // 
            // PersonnellBindingSource1
            // 
            this.PersonnellBindingSource1.DataMember = "Personnell";
            this.PersonnellBindingSource1.DataSource = this.PersonnellDataSet;
            // 
            // ActivitiesBindingSource
            // 
            this.ActivitiesBindingSource.DataMember = "Activities";
            this.ActivitiesBindingSource.DataSource = this.LeadsDataSet;
            // 
            // SystemUsersBindingSource
            // 
            this.SystemUsersBindingSource.DataMember = "SystemUsers";
            this.SystemUsersBindingSource.DataSource = this.MainDataSet;
            // 
            // BusinessNotesBindingSource
            // 
            this.BusinessNotesBindingSource.DataMember = "BusinessNotes";
            this.BusinessNotesBindingSource.DataSource = this.MainDataSet;
            // 
            // SystemTasksBindingSource
            // 
            this.SystemTasksBindingSource.DataMember = "SystemTasks";
            this.SystemTasksBindingSource.DataSource = this.TaskDataSet;
            // 
            // TaskDataSet
            // 
            this.TaskDataSet.DataSetName = "TaskDataSet";
            this.TaskDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // TasksBindingSource
            // 
            this.TasksBindingSource.DataMember = "Tasks";
            this.TasksBindingSource.DataSource = this.TaskDataSet;
            // 
            // UpcomingTableAdapter
            // 
            this.UpcomingTableAdapter.ClearBeforeFill = true;
            // 
            // PersonnellTableAdapter
            // 
            this.PersonnellTableAdapter.ClearBeforeFill = true;
            // 
            // PersonnellTableAdapter1
            // 
            this.PersonnellTableAdapter1.ClearBeforeFill = true;
            // 
            // colID2
            // 
            this.colID2.FieldName = "ID";
            this.colID2.Name = "colID2";
            this.colID2.Visible = true;
            // 
            // colInstructorName
            // 
            this.colInstructorName.FieldName = "InstructorName";
            this.colInstructorName.Name = "colInstructorName";
            this.colInstructorName.Visible = true;
            // 
            // colCompany1
            // 
            this.colCompany1.FieldName = "Company";
            this.colCompany1.Name = "colCompany1";
            this.colCompany1.Visible = true;
            // 
            // colEmail
            // 
            this.colEmail.FieldName = "Email";
            this.colEmail.Name = "colEmail";
            this.colEmail.Visible = true;
            // 
            // colHomePhone
            // 
            this.colHomePhone.FieldName = "Home Phone";
            this.colHomePhone.Name = "colHomePhone";
            this.colHomePhone.Visible = true;
            // 
            // colMobilePhone
            // 
            this.colMobilePhone.FieldName = "Mobile Phone";
            this.colMobilePhone.Name = "colMobilePhone";
            this.colMobilePhone.Visible = true;
            // 
            // colAttachments
            // 
            this.colAttachments.Caption = "Image";
            this.colAttachments.FieldName = "Attachments";
            this.colAttachments.Name = "colAttachments";
            this.colAttachments.Visible = true;
            // 
            // colClinical_Grade
            // 
            this.colClinical_Grade.FieldName = "Clinical_Grade";
            this.colClinical_Grade.Name = "colClinical_Grade";
            this.colClinical_Grade.Visible = true;
            // 
            // PeopleByCourseTableAdapter1
            // 
            this.PeopleByCourseTableAdapter1.ClearBeforeFill = true;
            // 
            // PeopleByCourseBindingSource
            // 
            this.PeopleByCourseBindingSource.DataMember = "PeopleByCourse";
            this.PeopleByCourseBindingSource.DataSource = this.PersonnellDataSet;
            // 
            // bgwCourseUpdate
            // 
            this.bgwCourseUpdate.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker_DoWork);
            this.bgwCourseUpdate.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorker_RunWorkerCompleted);
            // 
            // puGrid
            // 
            this.puGrid.ItemLinks.Add(this.btnCopy, "CO");
            this.puGrid.ItemLinks.Add(this.btnCopyFiles);
            this.puGrid.ItemLinks.Add(this.btnOpenFolder, true);
            this.puGrid.ItemLinks.Add(this.btnCompanyReport, true, "CM");
            this.puGrid.ItemLinks.Add(this.btnCasualtySummary, true);
            this.puGrid.ItemLinks.Add(this.btnPersonValidate);
            this.puGrid.ItemLinks.Add(this.btnOpenThis, true);
            this.puGrid.ItemLinks.Add(this.btnAllThis, "SO");
            this.puGrid.ItemLinks.Add(this.btnClearFilter, "CL");
            this.puGrid.ItemLinks.Add(this.btnGridExpand, true);
            this.puGrid.ItemLinks.Add(this.btnGridCollapse);
            this.puGrid.Name = "puGrid";
            this.puGrid.Ribbon = this.RibbonControl1;
            this.puGrid.ShowCaption = true;
            this.puGrid.ShowNavigationHeader = DevExpress.Utils.DefaultBoolean.True;
            // 
            // puEmail
            // 
            this.puEmail.ItemLinks.Add(this.btnCopy, true);
            this.puEmail.ItemLinks.Add(this.btnConvertLead, true, "CO");
            this.puEmail.ItemLinks.Add(this.btnConvertTask, "CN");
            this.puEmail.ItemLinks.Add(this.BarButtonItem6);
            this.puEmail.ItemLinks.Add(this.btnReplyWith, true);
            this.puEmail.Name = "puEmail";
            this.puEmail.Ribbon = this.RibbonControl1;
            this.puEmail.Popup += new System.EventHandler(this.puEmail_Popup);
            // 
            // Timer1
            // 
            this.Timer1.Enabled = true;
            this.Timer1.Interval = 10000;
            this.Timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // ClinicalDataSet
            // 
            this.ClinicalDataSet.DataSetName = "ClinicalData";
            this.ClinicalDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // WebUpcomingTableAdapter
            // 
            this.WebUpcomingTableAdapter.ClearBeforeFill = true;
            // 
            // ActivitiesTableAdapter
            // 
            this.ActivitiesTableAdapter.ClearBeforeFill = true;
            // 
            // TableAdapterManager
            // 
            this.TableAdapterManager.ActivitiesTableAdapter = this.ActivitiesTableAdapter;
            this.TableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.TableAdapterManager.Lead_CommsTableAdapter = null;
            this.TableAdapterManager.Lead_Event_ServicesTableAdapter = null;
            this.TableAdapterManager.Lead_EventsTableAdapter = null;
            this.TableAdapterManager.Lead_ItemsTableAdapter = null;
            this.TableAdapterManager.UpdateOrder = LeadsDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // Lead_ListTableAdapter
            // 
            this.Lead_ListTableAdapter.ClearBeforeFill = true;
            // 
            // LeadsByCourseBindingSource
            // 
            this.LeadsByCourseBindingSource.DataMember = "LeadsByCourse";
            this.LeadsByCourseBindingSource.DataSource = this.LeadsDataSet;
            // 
            // LeadsByCourseTableAdapter
            // 
            this.LeadsByCourseTableAdapter.ClearBeforeFill = true;
            // 
            // SystemUsersTableAdapter
            // 
            this.SystemUsersTableAdapter.ClearBeforeFill = true;
            // 
            // GovTableAdapter
            // 
            this.GovTableAdapter.ClearBeforeFill = true;
            // 
            // GovStandardsTableAdapter
            // 
            this.GovStandardsTableAdapter.ClearBeforeFill = true;
            // 
            // TableAdapterManager1
            // 
            this.TableAdapterManager1.AuditTableAdapter = null;
            this.TableAdapterManager1.BackupDataSetBeforeUpdate = false;
            this.TableAdapterManager1.Document_EditsTableAdapter = null;
            this.TableAdapterManager1.GovBodyTableAdapter = null;
            this.TableAdapterManager1.GovScopeTableAdapter = null;
            this.TableAdapterManager1.GovStandardsTableAdapter = this.GovStandardsTableAdapter;
            this.TableAdapterManager1.GovTableAdapter = this.GovTableAdapter;
            this.TableAdapterManager1.GovThemeTableAdapter = null;
            this.TableAdapterManager1.GovTypeTableAdapter = null;
            this.TableAdapterManager1.ProcessesTableAdapter = null;
            this.TableAdapterManager1.Risk_ConsequenceTableAdapter = null;
            this.TableAdapterManager1.Risk_LikelihoodTableAdapter = null;
            this.TableAdapterManager1.RiskKPITableAdapter = null;
            this.TableAdapterManager1.UpdateOrder = GovDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // BusinessNotesTableAdapter
            // 
            this.BusinessNotesTableAdapter.ClearBeforeFill = true;
            // 
            // TableAdapterManager2
            // 
            this.TableAdapterManager2.AppointmentsTableAdapter = null;
            this.TableAdapterManager2.AuditLogTableAdapter = null;
            this.TableAdapterManager2.BackupDataSetBeforeUpdate = false;
            this.TableAdapterManager2.BusinessNotesTableAdapter = this.BusinessNotesTableAdapter;
            this.TableAdapterManager2.Cleaning_ReadingsTableAdapter = null;
            this.TableAdapterManager2.Cleaning_TestsTableAdapter = null;
            this.TableAdapterManager2.ContactsTableAdapter = null;
            this.TableAdapterManager2.DocumentsTableAdapter = null;
            this.TableAdapterManager2.FlagsTableAdapter = null;
            this.TableAdapterManager2.InfoTableAdapter = null;
            this.TableAdapterManager2.NCR_ItemsTableAdapter = null;
            this.TableAdapterManager2.NCRTableAdapter = null;
            this.TableAdapterManager2.optFLagCatTableAdapter = null;
            this.TableAdapterManager2.PersonnellDocumentsTableAdapter = null;
            this.TableAdapterManager2.PersonnellTableAdapter = this.PersonnellTableAdapter;
            this.TableAdapterManager2.Project_DependenciesTableAdapter = null;
            this.TableAdapterManager2.ProjectsTableAdapter = null;
            this.TableAdapterManager2.ResourcesTableAdapter = null;
            this.TableAdapterManager2.RiskByPolicyTableAdapter = null;
            this.TableAdapterManager2.RisksTableAdapter = null;
            this.TableAdapterManager2.SystemUsersTableAdapter = this.SystemUsersTableAdapter;
            this.TableAdapterManager2.TaskDependenciesTableAdapter = null;
            this.TableAdapterManager2.TaskListTableAdapter = null;
            this.TableAdapterManager2.UpdateOrder = BM.MainDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // bgwShiftSheetEmails
            // 
            this.bgwShiftSheetEmails.WorkerReportsProgress = true;
            this.bgwShiftSheetEmails.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwShiftSheetEmails_DoWork);
            this.bgwShiftSheetEmails.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwShiftSheetEmails_ProgressChanged);
            this.bgwShiftSheetEmails.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwShiftSheetEmails_RunWorkerCompleted);
            // 
            // bgwStudentsEmail
            // 
            this.bgwStudentsEmail.WorkerReportsProgress = true;
            this.bgwStudentsEmail.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwStudentsEmail_DoWork);
            this.bgwStudentsEmail.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwStudentsEmail_ProgressChanged);
            this.bgwStudentsEmail.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwStudentsEmail_RunWorkerCompleted);
            // 
            // bgwGlobalCompliance
            // 
            this.bgwGlobalCompliance.WorkerReportsProgress = true;
            this.bgwGlobalCompliance.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwGlobalCompliance_DoWork);
            this.bgwGlobalCompliance.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwGlobalCompliance_ProgressChanged);
            this.bgwGlobalCompliance.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwGlobalCompliance_RunWorkerCompleted);
            // 
            // BackgroundWorker1
            // 
            this.BackgroundWorker1.WorkerReportsProgress = true;
            this.BackgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BackgroundWorker1_ProgressChanged);
            this.BackgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker1_RunWorkerCompleted);
            // 
            // Popup
            // 
            this.Popup.ItemLinks.Add(this.btnOpenGov, "O");
            this.Popup.ItemLinks.Add(this.btnCopyValue);
            this.Popup.ItemLinks.Add(this.btnFindReferences, true);
            this.Popup.ItemLinks.Add(this.BarSubItem8, true);
            this.Popup.ItemLinks.Add(this.BarButtonItem1);
            this.Popup.ItemLinks.Add(this.btnRemoveItem, true, "R");
            this.Popup.Name = "Popup";
            this.Popup.Ribbon = this.RibbonControl1;
            this.Popup.CloseUp += new System.EventHandler(this.puGov_CloseUp);
            this.Popup.BeforePopup += new System.ComponentModel.CancelEventHandler(this.puGov_BeforePopup);
            // 
            // puGov
            // 
            this.puGov.ItemLinks.Add(this.btnOpenItem, "OP");
            this.puGov.ItemLinks.Add(this.btnOpenFile, "OE");
            this.puGov.ItemLinks.Add(this.btnOpenFileLocation);
            this.puGov.ItemLinks.Add(this.btnPrintGovList, true);
            this.puGov.ItemLinks.Add(this.btnViewGroupStandards);
            this.puGov.ItemLinks.Add(this.btnRename, true, "RE");
            this.puGov.ItemLinks.Add(this.btnTaskCompleted, true);
            this.puGov.ItemLinks.Add(this.btnCopyItem, true, "C");
            this.puGov.ItemLinks.Add(this.btnCopyStandards);
            this.puGov.ItemLinks.Add(this.BarSubItem2, "A");
            this.puGov.ItemLinks.Add(this.btnNewSection, "N");
            this.puGov.ItemLinks.Add(this.btnRemoveItemGov, true, "RM");
            this.puGov.ItemLinks.Add(this.BarSubItem4, true, "M");
            this.puGov.ItemLinks.Add(this.BarSubItem5, "E");
            this.puGov.Name = "puGov";
            this.puGov.Ribbon = this.RibbonControl1;
            this.puGov.CloseUp += new System.EventHandler(this.puGov_CloseUp);
            this.puGov.BeforePopup += new System.ComponentModel.CancelEventHandler(this.puGov_BeforePopup);
            // 
            // TasksTableAdapter
            // 
            this.TasksTableAdapter.ClearBeforeFill = true;
            // 
            // SystemTasksTableAdapter
            // 
            this.SystemTasksTableAdapter.ClearBeforeFill = true;
            // 
            // SchedulerBarController1
            // 
            this.SchedulerBarController1.BarItems.Add(this.EditAppointmentQueryItem1);
            this.SchedulerBarController1.BarItems.Add(this.EditOccurrenceUICommandItem1);
            this.SchedulerBarController1.BarItems.Add(this.EditSeriesUICommandItem1);
            this.SchedulerBarController1.BarItems.Add(this.DeleteAppointmentsItem1);
            this.SchedulerBarController1.BarItems.Add(this.DeleteOccurrenceItem1);
            this.SchedulerBarController1.BarItems.Add(this.DeleteSeriesItem1);
            this.SchedulerBarController1.BarItems.Add(this.SplitAppointmentItem1);
            this.SchedulerBarController1.BarItems.Add(this.ChangeAppointmentStatusItem1);
            this.SchedulerBarController1.BarItems.Add(this.ChangeAppointmentLabelItem1);
            this.SchedulerBarController1.BarItems.Add(this.ToggleRecurrenceItem1);
            this.SchedulerBarController1.BarItems.Add(this.ChangeAppointmentReminderItem1);
            this.SchedulerBarController1.BarItems.Add(this.SwitchToDayViewItem1);
            this.SchedulerBarController1.BarItems.Add(this.SwitchToWorkWeekViewItem1);
            this.SchedulerBarController1.BarItems.Add(this.SwitchToWeekViewItem1);
            this.SchedulerBarController1.BarItems.Add(this.SwitchToFullWeekViewItem1);
            this.SchedulerBarController1.BarItems.Add(this.SwitchToMonthViewItem1);
            this.SchedulerBarController1.BarItems.Add(this.SwitchToTimelineViewItem1);
            this.SchedulerBarController1.BarItems.Add(this.SwitchToGanttViewItem1);
            this.SchedulerBarController1.BarItems.Add(this.SwitchToAgendaViewItem1);
            this.SchedulerBarController1.BarItems.Add(this.SwitchTimeScalesItem1);
            this.SchedulerBarController1.BarItems.Add(this.ChangeScaleWidthItem1);
            this.SchedulerBarController1.BarItems.Add(this.SwitchTimeScalesCaptionItem1);
            this.SchedulerBarController1.BarItems.Add(this.SwitchCompressWeekendItem1);
            this.SchedulerBarController1.BarItems.Add(this.SwitchShowWorkTimeOnlyItem1);
            this.SchedulerBarController1.BarItems.Add(this.SwitchCellsAutoHeightItem1);
            this.SchedulerBarController1.BarItems.Add(this.ChangeSnapToCellsUIItem1);
            this.SchedulerBarController1.Control = this.schWebView;
            // 
            // schWebView
            // 
            this.schWebView.ActiveViewType = DevExpress.XtraScheduler.SchedulerViewType.Month;
            this.schWebView.DataStorage = this.schWeb;
            this.schWebView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.schWebView.Location = new System.Drawing.Point(0, 0);
            this.schWebView.Margin = new System.Windows.Forms.Padding(8);
            this.schWebView.MenuManager = this.RibbonControl1;
            this.schWebView.Name = "schWebView";
            this.schWebView.OptionsView.NavigationButtons.Visibility = DevExpress.XtraScheduler.NavigationButtonVisibility.Never;
            this.schWebView.Size = new System.Drawing.Size(1687, 776);
            this.schWebView.Start = new System.DateTime(2017, 3, 27, 0, 0, 0, 0);
            this.schWebView.TabIndex = 0;
            this.schWebView.Text = "SchedulerControl1";
            this.schWebView.ToolTipController = this.ttTree;
            this.schWebView.Views.AgendaView.AppointmentDisplayOptions.StatusDisplayType = DevExpress.XtraScheduler.AppointmentStatusDisplayType.Never;
            this.schWebView.Views.DayView.AppointmentDisplayOptions.AllDayAppointmentsStatusDisplayType = DevExpress.XtraScheduler.AppointmentStatusDisplayType.Never;
            this.schWebView.Views.DayView.TimeRulers.Add(timeRuler1);
            this.schWebView.Views.FullWeekView.TimeRulers.Add(timeRuler2);
            this.schWebView.Views.MonthView.AppointmentDisplayOptions.StatusDisplayType = DevExpress.XtraScheduler.AppointmentStatusDisplayType.Never;
            this.schWebView.Views.WeekView.Enabled = false;
            this.schWebView.Views.WeekView.StatusDisplayType = DevExpress.XtraScheduler.SchedulerViewStatusDisplayType.None;
            this.schWebView.Views.WorkWeekView.Enabled = false;
            this.schWebView.Views.WorkWeekView.StatusDisplayType = DevExpress.XtraScheduler.SchedulerViewStatusDisplayType.None;
            this.schWebView.Views.WorkWeekView.TimeRulers.Add(timeRuler3);
            this.schWebView.Views.YearView.UseOptimizedScrolling = false;
            this.schWebView.VisibleIntervalChanged += new System.EventHandler(this.schWebView_VisibleIntervalChanged);
            this.schWebView.AppointmentViewInfoCustomizing += new DevExpress.XtraScheduler.AppointmentViewInfoCustomizingEventHandler(this.SchedulerControl1_AppointmentViewInfoCustomizing);
            this.schWebView.PopupMenuShowing += new DevExpress.XtraScheduler.PopupMenuShowingEventHandler(this.SchedulerControl1_PopupMenuShowing);
            this.schWebView.CustomDrawTimeCell += new DevExpress.XtraScheduler.CustomDrawObjectEventHandler(this.SchedulerControl1_CustomDrawTimeCell);
            this.schWebView.CustomDrawDayHeader += new DevExpress.XtraScheduler.CustomDrawObjectEventHandler(this.SchedulerControl1_CustomDrawDayHeader);
            this.schWebView.Click += new System.EventHandler(this.SchedulerControl1_Click);
            this.schWebView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SchedulerControl1_MouseMove);
            // 
            // ttScheduler
            // 
            this.ttScheduler.BeforeShow += new DevExpress.Utils.ToolTipControllerBeforeShowEventHandler(this.ttScheduler_BeforeShow);
            // 
            // puScheduler
            // 
            this.puScheduler.ItemLinks.Add(this.btnAddAppointment);
            this.puScheduler.Name = "puScheduler";
            this.puScheduler.Ribbon = this.RibbonControl1;
            // 
            // ttTraining
            // 
            this.ttTraining.GetActiveObjectInfo += new DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventHandler(this.ttTraining_GetActiveObjectInfo);
            // 
            // RisksBindingSource
            // 
            this.RisksBindingSource.DataMember = "Risks";
            this.RisksBindingSource.DataSource = this.MainDataSet;
            // 
            // TaskPriorityBindingSource
            // 
            this.TaskPriorityBindingSource.DataMember = "TaskPriority";
            this.TaskPriorityBindingSource.DataSource = this.TaskDataSet;
            // 
            // DocumentsBindingSource
            // 
            this.DocumentsBindingSource.DataMember = "Documents";
            this.DocumentsBindingSource.DataSource = this.MainDataSet;
            // 
            // ImageCollection1
            // 
            this.ImageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("ImageCollection1.ImageStream")));
            // 
            // ContactsBindingSource
            // 
            this.ContactsBindingSource.DataMember = "Contacts";
            this.ContactsBindingSource.DataSource = this.MainDataSet;
            // 
            // InfoBindingSource
            // 
            this.InfoBindingSource.DataMember = "Info";
            this.InfoBindingSource.DataSource = this.MainDataSet;
            // 
            // AssetShiftBindingSource
            // 
            this.AssetShiftBindingSource.DataMember = "Asset_Shift";
            // 
            // imgTree
            // 
            this.imgTree.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgTree.ImageStream")));
            this.imgTree.InsertGalleryImage("mail_16x16.png", "images/mail/mail_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/mail/mail_16x16.png"), 0);
            this.imgTree.Images.SetKeyName(0, "mail_16x16.png");
            this.imgTree.InsertGalleryImage("task_16x16.png", "images/tasks/task_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/tasks/task_16x16.png"), 1);
            this.imgTree.Images.SetKeyName(1, "task_16x16.png");
            this.imgTree.InsertGalleryImage("employee_16x16.png", "images/people/employee_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/people/employee_16x16.png"), 2);
            this.imgTree.Images.SetKeyName(2, "employee_16x16.png");
            this.imgTree.InsertGalleryImage("textbox_16x16.png", "images/content/textbox_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/content/textbox_16x16.png"), 3);
            this.imgTree.Images.SetKeyName(3, "textbox_16x16.png");
            // 
            // NavBarControl1
            // 
            this.NavBarControl1.ActiveGroup = this.NavBarGroup1;
            this.NavBarControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NavBarControl1.ExplorerBarShowGroupButtons = false;
            this.NavBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.NavBarGroup1,
            this.NavBarGroup2});
            this.NavBarControl1.HideGroupCaptions = true;
            this.NavBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.nvAudit,
            this.nvGovernance,
            this.nvRisk,
            this.nvDocuments,
            this.nvFlagged,
            this.nvSales,
            this.nvMyDashBoard,
            this.nvReportCentre,
            this.nvVehicles,
            this.nvNotes,
            this.nvTaskList,
            this.nvProjects,
            this.nvQuality,
            this.nvFeedback});
            this.NavBarControl1.Location = new System.Drawing.Point(0, 0);
            this.NavBarControl1.Margin = new System.Windows.Forms.Padding(8);
            this.NavBarControl1.Name = "NavBarControl1";
            this.NavBarControl1.OptionsNavPane.ExpandedWidth = 118;
            this.NavBarControl1.OptionsNavPane.ShowGroupImageInHeader = true;
            this.NavBarControl1.OptionsNavPane.ShowOverflowButton = false;
            this.NavBarControl1.OptionsNavPane.ShowOverflowPanel = false;
            this.NavBarControl1.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.NavBarControl1.ShowGroupHint = false;
            this.NavBarControl1.Size = new System.Drawing.Size(118, 807);
            this.NavBarControl1.StoreDefaultPaintStyleName = true;
            this.NavBarControl1.TabIndex = 0;
            this.NavBarControl1.Text = "Navigation Bar";
            // 
            // NavBarGroup2
            // 
            this.NavBarGroup2.Caption = "Strategic";
            this.NavBarGroup2.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsText;
            this.NavBarGroup2.ImageOptions.SmallImageSize = new System.Drawing.Size(16, 16);
            this.NavBarGroup2.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("NavBarGroup2.ImageOptions.SvgImage")));
            this.NavBarGroup2.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.nvSales),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nvDocuments),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nvTaskList),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nvRisk),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nvGovernance),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nvAudit),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nvFlagged),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nvProjects),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nvQuality),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nvFeedback)});
            this.NavBarGroup2.Name = "NavBarGroup2";
            this.NavBarGroup2.ShowIcons = DevExpress.Utils.DefaultBoolean.True;
            // 
            // nvTaskList
            // 
            this.nvTaskList.Caption = "Tasks";
            this.nvTaskList.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("nvTaskList.ImageOptions.SvgImage")));
            this.nvTaskList.Name = "nvTaskList";
            this.nvTaskList.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.NvTaskList_LinkClicked);
            // 
            // nvFlagged
            // 
            this.nvFlagged.Caption = "Flagged";
            this.nvFlagged.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("nvFlagged.ImageOptions.SvgImage")));
            this.nvFlagged.Name = "nvFlagged";
            this.nvFlagged.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.NavBarItem2_LinkClicked);
            // 
            // nvProjects
            // 
            this.nvProjects.Caption = "Projects";
            this.nvProjects.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("nvProjects.ImageOptions.SvgImage")));
            this.nvProjects.Name = "nvProjects";
            this.nvProjects.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nvProjects_LinkClicked);
            // 
            // nvQuality
            // 
            this.nvQuality.Caption = "Quality Improvement";
            this.nvQuality.ImageOptions.LargeImageSize = new System.Drawing.Size(32, 32);
            this.nvQuality.ImageOptions.SmallImageSize = new System.Drawing.Size(16, 16);
            this.nvQuality.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("nvQuality.ImageOptions.SvgImage")));
            this.nvQuality.Name = "nvQuality";
            this.nvQuality.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nvQuality_LinkClicked_1);
            // 
            // nvFeedback
            // 
            this.nvFeedback.Caption = "Feedback";
            this.nvFeedback.ImageOptions.LargeImageSize = new System.Drawing.Size(32, 32);
            this.nvFeedback.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("nvFeedback.ImageOptions.SvgImage")));
            this.nvFeedback.Name = "nvFeedback";
            // 
            // SplitContainerControl1
            // 
            this.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainerControl1.Location = new System.Drawing.Point(0, 201);
            this.SplitContainerControl1.Margin = new System.Windows.Forms.Padding(8);
            this.SplitContainerControl1.Name = "SplitContainerControl1";
            // 
            // SplitContainerControl1.Panel1
            // 
            this.SplitContainerControl1.Panel1.Controls.Add(this.NavBarControl1);
            this.SplitContainerControl1.Panel1.Text = "Panel1";
            // 
            // SplitContainerControl1.Panel2
            // 
            this.SplitContainerControl1.Panel2.Controls.Add(this.tbDashboard);
            this.SplitContainerControl1.Panel2.Text = "Panel2";
            this.SplitContainerControl1.Size = new System.Drawing.Size(1839, 807);
            this.SplitContainerControl1.SplitterPosition = 118;
            this.SplitContainerControl1.TabIndex = 2;
            this.SplitContainerControl1.Text = "SplitContainerControl1";
            // 
            // tbDashboard
            // 
            this.tbDashboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbDashboard.Location = new System.Drawing.Point(0, 0);
            this.tbDashboard.Margin = new System.Windows.Forms.Padding(8);
            this.tbDashboard.Name = "tbDashboard";
            this.tbDashboard.SelectedTabPage = this.tabMyHome;
            this.tbDashboard.Size = new System.Drawing.Size(1705, 807);
            this.tbDashboard.TabIndex = 1;
            this.tbDashboard.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabMyHome,
            this.tabCalendar,
            this.tabTraining,
            this.tabClinical,
            this.tabLeads,
            this.tabGovernance,
            this.tabNotes,
            this.tabTasks,
            this.tabRisk,
            this.tabDocuments,
            this.tabAudit,
            this.tabFlagged,
            this.tabTaskList});
            this.tbDashboard.Click += new System.EventHandler(this.XtraTabControl_Click);
            this.tbDashboard.DragOver += new System.Windows.Forms.DragEventHandler(this.XtraTabControl_DragOver);
            // 
            // tabMyHome
            // 
            this.tabMyHome.Controls.Add(this.TabPane1);
            this.tabMyHome.Margin = new System.Windows.Forms.Padding(8);
            this.tabMyHome.Name = "tabMyHome";
            this.tabMyHome.Size = new System.Drawing.Size(1703, 776);
            this.tabMyHome.Text = "Home";
            // 
            // TabPane1
            // 
            this.TabPane1.Appearance.Options.UseImage = true;
            this.TabPane1.Controls.Add(this.TabNavigationPage3);
            this.TabPane1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabPane1.Location = new System.Drawing.Point(0, 0);
            this.TabPane1.Margin = new System.Windows.Forms.Padding(8);
            this.TabPane1.Name = "TabPane1";
            this.TabPane1.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.TabNavigationPage3});
            this.TabPane1.RegularSize = new System.Drawing.Size(1703, 776);
            this.TabPane1.SelectedPage = this.TabNavigationPage3;
            this.TabPane1.Size = new System.Drawing.Size(1703, 776);
            this.TabPane1.TabIndex = 2;
            this.TabPane1.Text = "TabPane1";
            this.TabPane1.SelectedPageChanged += new DevExpress.XtraBars.Navigation.SelectedPageChangedEventHandler(this.TabPane1_SelectedPageChanged);
            // 
            // TabNavigationPage3
            // 
            this.TabNavigationPage3.Caption = "Inbox";
            this.TabNavigationPage3.Controls.Add(this.SplitContainerControl3);
            this.TabNavigationPage3.Margin = new System.Windows.Forms.Padding(8);
            this.TabNavigationPage3.Name = "TabNavigationPage3";
            this.TabNavigationPage3.Size = new System.Drawing.Size(1703, 735);
            // 
            // SplitContainerControl3
            // 
            this.SplitContainerControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainerControl3.Location = new System.Drawing.Point(0, 0);
            this.SplitContainerControl3.Margin = new System.Windows.Forms.Padding(8);
            this.SplitContainerControl3.Name = "SplitContainerControl3";
            // 
            // SplitContainerControl3.Panel1
            // 
            this.SplitContainerControl3.Panel1.Controls.Add(this.TaskTree);
            this.SplitContainerControl3.Panel1.Text = "Panel1";
            // 
            // SplitContainerControl3.Panel2
            // 
            this.SplitContainerControl3.Panel2.Controls.Add(this.EmailGridControl);
            this.SplitContainerControl3.Panel2.Text = "Panel2";
            this.SplitContainerControl3.Size = new System.Drawing.Size(1703, 735);
            this.SplitContainerControl3.SplitterPosition = 236;
            this.SplitContainerControl3.TabIndex = 0;
            this.SplitContainerControl3.Text = "SplitContainerControl3";
            // 
            // TaskTree
            // 
            this.TaskTree.Cursor = System.Windows.Forms.Cursors.Default;
            this.TaskTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TaskTree.FixedLineWidth = 1;
            this.TaskTree.HorzScrollStep = 8;
            this.TaskTree.Location = new System.Drawing.Point(0, 0);
            this.TaskTree.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.TaskTree.Margin = new System.Windows.Forms.Padding(8);
            this.TaskTree.MinWidth = 60;
            this.TaskTree.Name = "TaskTree";
            this.TaskTree.OptionsBehavior.Editable = false;
            this.TaskTree.OptionsView.ShowColumns = false;
            this.TaskTree.OptionsView.ShowHorzLines = false;
            this.TaskTree.OptionsView.ShowIndicator = false;
            this.TaskTree.OptionsView.ShowVertLines = false;
            this.TaskTree.SelectImageList = this.imgEmail;
            this.TaskTree.Size = new System.Drawing.Size(236, 735);
            this.TaskTree.TabIndex = 0;
            this.TaskTree.TreeLevelWidth = 12;
            this.TaskTree.NodeCellStyle += new DevExpress.XtraTreeList.GetCustomNodeCellStyleEventHandler(this.TaskTree_NodeCellStyle);
            this.TaskTree.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.TaskTree_FocusedNodeChanged);
            this.TaskTree.Click += new System.EventHandler(this.TaskTree_Click);
            // 
            // EmailGridControl
            // 
            this.EmailGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EmailGridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(8);
            this.EmailGridControl.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.EmailGridControl.Location = new System.Drawing.Point(0, 0);
            this.EmailGridControl.MainView = this.grdMyInbox;
            this.EmailGridControl.Margin = new System.Windows.Forms.Padding(8);
            this.EmailGridControl.MenuManager = this.RibbonControl1;
            this.EmailGridControl.Name = "EmailGridControl";
            this.EmailGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.RepositoryItemCheckEdit9,
            this.RepositoryItemImageComboBox1,
            this.RepositoryItemCheckEdit10,
            this.RepositoryItemRichTextEdit1});
            this.EmailGridControl.Size = new System.Drawing.Size(1451, 735);
            this.EmailGridControl.TabIndex = 0;
            this.EmailGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdMyInbox});
            this.EmailGridControl.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GridControl1_KeyUp);
            // 
            // grdMyInbox
            // 
            this.grdMyInbox.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.GridColumn14,
            this.GridColumn30,
            this.colSeen,
            this.GridColumn4,
            this.GridColumn5,
            this.GridColumn6,
            this.GridColumn7,
            this.GridColumn8,
            this.GridColumn9,
            this.GridColumn10,
            this.GridColumn11,
            this.GridColumn12,
            this.GridColumn13});
            this.grdMyInbox.DetailHeight = 1130;
            gridFormatRule1.ApplyToRow = true;
            gridFormatRule1.Column = this.colSeen;
            gridFormatRule1.Name = "Format0";
            formatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.NotEqual;
            formatConditionRuleValue1.PredefinedName = "Red Fill, Red Text";
            formatConditionRuleValue1.Value1 = true;
            gridFormatRule1.Rule = formatConditionRuleValue1;
            this.grdMyInbox.FormatRules.Add(gridFormatRule1);
            this.grdMyInbox.GridControl = this.EmailGridControl;
            this.grdMyInbox.GroupPanelText = " ";
            this.grdMyInbox.GroupRowHeight = 0;
            this.grdMyInbox.LevelIndent = 14;
            this.grdMyInbox.Name = "grdMyInbox";
            this.grdMyInbox.OptionsDetail.ShowEmbeddedDetailIndent = DevExpress.Utils.DefaultBoolean.False;
            this.grdMyInbox.OptionsSelection.EnableAppearanceHotTrackedRow = DevExpress.Utils.DefaultBoolean.True;
            this.grdMyInbox.OptionsSelection.UseIndicatorForSelection = false;
            this.grdMyInbox.OptionsView.EnableAppearanceOddRow = true;
            this.grdMyInbox.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.Hidden;
            this.grdMyInbox.OptionsView.ShowFooter = true;
            this.grdMyInbox.OptionsView.ShowGroupedColumns = true;
            this.grdMyInbox.OptionsView.ShowGroupPanelColumnsAsSingleRow = true;
            this.grdMyInbox.OptionsView.ShowIndicator = false;
            this.grdMyInbox.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grdMyInbox.RowHeight = 22;
            this.grdMyInbox.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.GridColumn10, DevExpress.Data.ColumnSortOrder.Descending)});
            this.grdMyInbox.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.grdMyInbox_RowCellClick);
            this.grdMyInbox.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.grdMyInbox_PopupMenuShowing);
            this.grdMyInbox.GroupRowCollapsing += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.grdMyInbox_GroupRowCollapsing);
            this.grdMyInbox.CustomDrawEmptyForeground += new DevExpress.XtraGrid.Views.Base.CustomDrawEventHandler(this.grdMyInbox_CustomDrawEmptyForeground);
            this.grdMyInbox.ColumnFilterChanged += new System.EventHandler(this.MultiGrid_ColumnFilterChanged);
            this.grdMyInbox.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.grdMyInbox_CustomColumnDisplayText);
            this.grdMyInbox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseClickGrid);
            this.grdMyInbox.DoubleClick += new System.EventHandler(this.grdMyInbox_DoubleClick);
            // 
            // GridColumn14
            // 
            this.GridColumn14.Caption = "GridColumn14";
            this.GridColumn14.FieldName = "CID";
            this.GridColumn14.MinWidth = 68;
            this.GridColumn14.Name = "GridColumn14";
            this.GridColumn14.Width = 260;
            // 
            // GridColumn30
            // 
            this.GridColumn30.Caption = "ParentID";
            this.GridColumn30.FieldName = "ParentID";
            this.GridColumn30.GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.Value;
            this.GridColumn30.MinWidth = 68;
            this.GridColumn30.Name = "GridColumn30";
            this.GridColumn30.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
            this.GridColumn30.Width = 260;
            // 
            // GridColumn4
            // 
            this.GridColumn4.Caption = "GridColumn13";
            this.GridColumn4.FieldName = "Email";
            this.GridColumn4.MinWidth = 68;
            this.GridColumn4.Name = "GridColumn4";
            this.GridColumn4.Width = 260;
            // 
            // GridColumn5
            // 
            this.GridColumn5.Caption = " ";
            this.GridColumn5.ColumnEdit = this.RepositoryItemCheckEdit9;
            this.GridColumn5.FieldName = "Attachments";
            this.GridColumn5.MaxWidth = 86;
            this.GridColumn5.MinWidth = 68;
            this.GridColumn5.Name = "GridColumn5";
            this.GridColumn5.OptionsColumn.AllowEdit = false;
            this.GridColumn5.Visible = true;
            this.GridColumn5.VisibleIndex = 0;
            this.GridColumn5.Width = 86;
            // 
            // GridColumn6
            // 
            this.GridColumn6.Caption = " ";
            this.GridColumn6.ColumnEdit = this.RepositoryItemImageComboBox1;
            this.GridColumn6.FieldName = "Image";
            this.GridColumn6.MaxWidth = 86;
            this.GridColumn6.MinWidth = 68;
            this.GridColumn6.Name = "GridColumn6";
            this.GridColumn6.OptionsColumn.AllowEdit = false;
            this.GridColumn6.Visible = true;
            this.GridColumn6.VisibleIndex = 1;
            this.GridColumn6.Width = 86;
            // 
            // GridColumn8
            // 
            this.GridColumn8.Caption = "Name";
            this.GridColumn8.FieldName = "Name";
            this.GridColumn8.MinWidth = 68;
            this.GridColumn8.Name = "GridColumn8";
            this.GridColumn8.OptionsColumn.AllowEdit = false;
            this.GridColumn8.Visible = true;
            this.GridColumn8.VisibleIndex = 3;
            this.GridColumn8.Width = 260;
            // 
            // GridColumn9
            // 
            this.GridColumn9.Caption = "Subject";
            this.GridColumn9.FieldName = "Subject";
            this.GridColumn9.MinWidth = 68;
            this.GridColumn9.Name = "GridColumn9";
            this.GridColumn9.OptionsColumn.AllowEdit = false;
            this.GridColumn9.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Subject", "{0} Items")});
            this.GridColumn9.Visible = true;
            this.GridColumn9.VisibleIndex = 4;
            this.GridColumn9.Width = 260;
            // 
            // GridColumn10
            // 
            this.GridColumn10.AppearanceCell.Options.UseTextOptions = true;
            this.GridColumn10.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.GridColumn10.AppearanceHeader.Options.UseTextOptions = true;
            this.GridColumn10.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.GridColumn10.Caption = "Received";
            this.GridColumn10.DisplayFormat.FormatString = "g";
            this.GridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.GridColumn10.FieldName = "Received";
            this.GridColumn10.GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.DateRange;
            this.GridColumn10.MaxWidth = 420;
            this.GridColumn10.MinWidth = 68;
            this.GridColumn10.Name = "GridColumn10";
            this.GridColumn10.OptionsColumn.AllowEdit = false;
            this.GridColumn10.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.True;
            this.GridColumn10.Visible = true;
            this.GridColumn10.VisibleIndex = 5;
            this.GridColumn10.Width = 104;
            // 
            // GridColumn11
            // 
            this.GridColumn11.Caption = "Type";
            this.GridColumn11.FieldName = "Type";
            this.GridColumn11.MinWidth = 68;
            this.GridColumn11.Name = "GridColumn11";
            this.GridColumn11.OptionsColumn.AllowEdit = false;
            this.GridColumn11.Width = 260;
            // 
            // GridColumn12
            // 
            this.GridColumn12.Caption = "Body";
            this.GridColumn12.ColumnEdit = this.RepositoryItemRichTextEdit1;
            this.GridColumn12.FieldName = "Body";
            this.GridColumn12.MinWidth = 68;
            this.GridColumn12.Name = "GridColumn12";
            this.GridColumn12.OptionsColumn.AllowEdit = false;
            this.GridColumn12.Visible = true;
            this.GridColumn12.VisibleIndex = 6;
            this.GridColumn12.Width = 260;
            // 
            // RepositoryItemRichTextEdit1
            // 
            this.RepositoryItemRichTextEdit1.Name = "RepositoryItemRichTextEdit1";
            this.RepositoryItemRichTextEdit1.ShowCaretInReadOnly = false;
            // 
            // GridColumn13
            // 
            this.GridColumn13.Caption = "ID";
            this.GridColumn13.FieldName = "ID";
            this.GridColumn13.MinWidth = 68;
            this.GridColumn13.Name = "GridColumn13";
            this.GridColumn13.OptionsColumn.AllowEdit = false;
            this.GridColumn13.Width = 260;
            // 
            // tabCalendar
            // 
            this.tabCalendar.Controls.Add(this.SplitContainerControl4);
            this.tabCalendar.Margin = new System.Windows.Forms.Padding(8);
            this.tabCalendar.Name = "tabCalendar";
            this.tabCalendar.Size = new System.Drawing.Size(1703, 776);
            this.tabCalendar.Text = "Calendar";
            // 
            // SplitContainerControl4
            // 
            this.SplitContainerControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainerControl4.Location = new System.Drawing.Point(0, 0);
            this.SplitContainerControl4.Margin = new System.Windows.Forms.Padding(8);
            this.SplitContainerControl4.Name = "SplitContainerControl4";
            // 
            // SplitContainerControl4.Panel1
            // 
            this.SplitContainerControl4.Panel1.CaptionLocation = DevExpress.Utils.Locations.Right;
            this.SplitContainerControl4.Panel1.Controls.Add(this.schWebView);
            this.SplitContainerControl4.Panel1.Text = "Panel1";
            // 
            // SplitContainerControl4.Panel2
            // 
            this.SplitContainerControl4.Panel2.Controls.Add(this.schCourses);
            this.SplitContainerControl4.Panel2.Text = "Panel2";
            this.SplitContainerControl4.Size = new System.Drawing.Size(1703, 776);
            this.SplitContainerControl4.SplitterPosition = 2096;
            this.SplitContainerControl4.TabIndex = 1;
            // 
            // schCourses
            // 
            this.schCourses.ActiveViewType = DevExpress.XtraScheduler.SchedulerViewType.Month;
            this.schCourses.DataStorage = this.SchedulerStorage;
            this.schCourses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.schCourses.Location = new System.Drawing.Point(0, 0);
            this.schCourses.Margin = new System.Windows.Forms.Padding(8);
            this.schCourses.MenuManager = this.RibbonControl1;
            this.schCourses.Name = "schCourses";
            this.schCourses.OptionsBehavior.SelectOnRightClick = true;
            this.schCourses.OptionsCustomization.AllowAppointmentCopy = DevExpress.XtraScheduler.UsedAppointmentType.None;
            this.schCourses.OptionsCustomization.AllowAppointmentCreate = DevExpress.XtraScheduler.UsedAppointmentType.None;
            this.schCourses.OptionsCustomization.AllowAppointmentDelete = DevExpress.XtraScheduler.UsedAppointmentType.None;
            this.schCourses.OptionsCustomization.AllowAppointmentDrag = DevExpress.XtraScheduler.UsedAppointmentType.None;
            this.schCourses.OptionsCustomization.AllowAppointmentDragBetweenResources = DevExpress.XtraScheduler.UsedAppointmentType.None;
            this.schCourses.OptionsCustomization.AllowAppointmentEdit = DevExpress.XtraScheduler.UsedAppointmentType.None;
            this.schCourses.OptionsCustomization.AllowDisplayAppointmentFlyout = false;
            this.schCourses.OptionsCustomization.AllowInplaceEditor = DevExpress.XtraScheduler.UsedAppointmentType.None;
            this.schCourses.OptionsView.NavigationButtons.Visibility = DevExpress.XtraScheduler.NavigationButtonVisibility.Never;
            this.schCourses.OptionsView.ToolTipVisibility = DevExpress.XtraScheduler.ToolTipVisibility.Always;
            this.schCourses.OptionsView.UseInplaceEditor2016 = DevExpress.Utils.DefaultBoolean.False;
            this.schCourses.Size = new System.Drawing.Size(0, 0);
            this.schCourses.Start = new System.DateTime(2017, 3, 13, 0, 0, 0, 0);
            this.schCourses.TabIndex = 0;
            this.schCourses.Text = "SchedulerControl";
            this.schCourses.ToolTipController = this.ttScheduler;
            this.schCourses.Views.DayView.AppointmentDisplayOptions.StatusDisplayType = DevExpress.XtraScheduler.AppointmentStatusDisplayType.Never;
            this.schCourses.Views.DayView.Enabled = false;
            this.schCourses.Views.DayView.GroupSeparatorWidth = 2;
            this.schCourses.Views.DayView.StatusDisplayType = DevExpress.XtraScheduler.SchedulerViewStatusDisplayType.None;
            this.schCourses.Views.DayView.TimeRulers.Add(timeRuler4);
            this.schCourses.Views.FullWeekView.GroupSeparatorWidth = 2;
            this.schCourses.Views.FullWeekView.StatusDisplayType = DevExpress.XtraScheduler.SchedulerViewStatusDisplayType.None;
            this.schCourses.Views.FullWeekView.TimeRulers.Add(timeRuler5);
            this.schCourses.Views.MonthView.AppointmentDisplayOptions.StatusDisplayType = DevExpress.XtraScheduler.AppointmentStatusDisplayType.Never;
            this.schCourses.Views.MonthView.GroupSeparatorWidth = 2;
            this.schCourses.Views.WeekView.Enabled = false;
            this.schCourses.Views.WeekView.GroupSeparatorWidth = 2;
            this.schCourses.Views.WeekView.StatusDisplayType = DevExpress.XtraScheduler.SchedulerViewStatusDisplayType.None;
            this.schCourses.Views.WorkWeekView.Enabled = false;
            this.schCourses.Views.WorkWeekView.GroupSeparatorWidth = 2;
            this.schCourses.Views.WorkWeekView.StatusDisplayType = DevExpress.XtraScheduler.SchedulerViewStatusDisplayType.None;
            this.schCourses.Views.WorkWeekView.TimeRulers.Add(timeRuler6);
            this.schCourses.Views.YearView.UseOptimizedScrolling = false;
            this.schCourses.VisibleIntervalChanged += new System.EventHandler(this.schCourses_VisibleChanged);
            this.schCourses.ActiveViewChanged += new System.EventHandler(this.schCourses_ActiveViewChanged);
            this.schCourses.InitAppointmentDisplayText += new DevExpress.XtraScheduler.AppointmentDisplayTextEventHandler(this.schCourses_InitAppointmentDisplayText);
            this.schCourses.AppointmentViewInfoCustomizing += new DevExpress.XtraScheduler.AppointmentViewInfoCustomizingEventHandler(this.schCourses_AppointmentViewInfoCustomizing);
            this.schCourses.PopupMenuShowing += new DevExpress.XtraScheduler.PopupMenuShowingEventHandler(this.schCourses_PopupMenuShowing);
            this.schCourses.CustomDrawTimeCell += new DevExpress.XtraScheduler.CustomDrawObjectEventHandler(this.schCourses_CustomDrawTimeCell);
            this.schCourses.CustomDrawDayHeader += new DevExpress.XtraScheduler.CustomDrawObjectEventHandler(this.schCourses_CustomDrawDayHeader);
            this.schCourses.Click += new System.EventHandler(this.schCourses_Click);
            this.schCourses.MouseMove += new System.Windows.Forms.MouseEventHandler(this.schCourses_MouseMove);
            // 
            // tabTraining
            // 
            this.tabTraining.Controls.Add(this.TrainingGrid);
            this.tabTraining.Margin = new System.Windows.Forms.Padding(8);
            this.tabTraining.Name = "tabTraining";
            this.tabTraining.Size = new System.Drawing.Size(1703, 776);
            this.tabTraining.Text = "Training";
            // 
            // TrainingGrid
            // 
            this.TrainingGrid.AllowDrop = true;
            this.TrainingGrid.DataSource = this.courseListBindingSource;
            this.TrainingGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TrainingGrid.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(8);
            this.TrainingGrid.Location = new System.Drawing.Point(0, 0);
            this.TrainingGrid.MainView = this.TrainingGridView;
            this.TrainingGrid.Margin = new System.Windows.Forms.Padding(8);
            this.TrainingGrid.MenuManager = this.RibbonControl1;
            this.TrainingGrid.Name = "TrainingGrid";
            this.TrainingGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.RepositoryItemColorEdit1,
            this.RepositoryItemCalcEdit1,
            this.RepositoryItemCheckEdit7,
            this.RepositoryItemCheckEdit14});
            this.TrainingGrid.Size = new System.Drawing.Size(1703, 776);
            this.TrainingGrid.TabIndex = 0;
            this.TrainingGrid.ToolTipController = this.ttTraining;
            this.TrainingGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.TrainingGridView});
            this.TrainingGrid.DragDrop += new System.Windows.Forms.DragEventHandler(this.TrainingGrid_DragDrop);
            this.TrainingGrid.DragOver += new System.Windows.Forms.DragEventHandler(this.TrainingGrid_DragOver);
            // 
            // TrainingGridView
            // 
            this.TrainingGridView.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.TrainingGridView.Appearance.GroupRow.Options.UseFont = true;
            this.TrainingGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colInstructor,
            this.colStudents,
            this.colCourse,
            this.colLocation,
            this.colExternalRef,
            this.colStatus,
            this.colCourseContact,
            this.colCompany,
            this.colCourseTime,
            this.colPath,
            this.colTimeStamp,
            this.colTableSort,
            this.GridColumn1,
            this.colNotEmail,
            this.colKPI,
            this.colFlag,
            this.colIntRef,
            this.colDateofCourse,
            this.colNCR,
            this.colCourseType,
            this.colNotEmail2,
            this.colCert,
            this.colIV});
            this.TrainingGridView.DetailHeight = 1130;
            gridFormatRule2.ApplyToRow = true;
            gridFormatRule2.Column = this.colInstructor;
            gridFormatRule2.Name = "Not Set";
            formatConditionRuleValue2.Appearance.BackColor2 = System.Drawing.Color.White;
            formatConditionRuleValue2.Appearance.ForeColor = System.Drawing.Color.Black;
            formatConditionRuleValue2.Appearance.Options.UseBackColor = true;
            formatConditionRuleValue2.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue2.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue2.Value1 = "NOT SET";
            gridFormatRule2.Rule = formatConditionRuleValue2;
            gridFormatRule3.ApplyToRow = true;
            gridFormatRule3.Column = this.colStatus;
            gridFormatRule3.Name = "Defered";
            formatConditionRuleValue3.Appearance.BackColor2 = System.Drawing.Color.White;
            formatConditionRuleValue3.Appearance.ForeColor = System.Drawing.Color.Black;
            formatConditionRuleValue3.Appearance.Options.UseBackColor = true;
            formatConditionRuleValue3.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue3.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue3.Value1 = "Deferred";
            gridFormatRule3.Rule = formatConditionRuleValue3;
            gridFormatRule4.ApplyToRow = true;
            gridFormatRule4.Name = "Urgent";
            formatConditionRuleExpression1.Appearance.BackColor2 = System.Drawing.Color.White;
            formatConditionRuleExpression1.Appearance.ForeColor = System.Drawing.Color.Black;
            formatConditionRuleExpression1.Appearance.Options.UseBackColor = true;
            formatConditionRuleExpression1.Appearance.Options.UseForeColor = true;
            formatConditionRuleExpression1.Expression = "DateDiffDay(Today(), [DateofCourse]) < 14 And [Instructor] = \'NOT SET\' And [Statu" +
    "s] = \'Waiting\'";
            gridFormatRule4.Rule = formatConditionRuleExpression1;
            gridFormatRule5.ApplyToRow = true;
            gridFormatRule5.Column = this.colStatus;
            gridFormatRule5.Name = "Cancelled";
            formatConditionRuleValue4.Appearance.BackColor2 = System.Drawing.Color.White;
            formatConditionRuleValue4.Appearance.ForeColor = System.Drawing.Color.Black;
            formatConditionRuleValue4.Appearance.Options.UseBackColor = true;
            formatConditionRuleValue4.Appearance.Options.UseFont = true;
            formatConditionRuleValue4.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue4.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue4.Value1 = "Cancelled";
            gridFormatRule5.Rule = formatConditionRuleValue4;
            gridFormatRule6.ApplyToRow = true;
            gridFormatRule6.Column = this.colPath;
            gridFormatRule6.Name = "Paperwork";
            formatConditionRuleExpression2.Appearance.ForeColor = System.Drawing.Color.Black;
            formatConditionRuleExpression2.Appearance.Options.UseFont = true;
            formatConditionRuleExpression2.Appearance.Options.UseForeColor = true;
            formatConditionRuleExpression2.Expression = "Iif([Path] Is Null, True, False) And [DateofCourse] < Today()";
            gridFormatRule6.Rule = formatConditionRuleExpression2;
            gridFormatRule7.ApplyToRow = true;
            gridFormatRule7.Column = this.colTableSort;
            gridFormatRule7.Name = "Format0";
            formatConditionRuleValue5.Appearance.BackColor = System.Drawing.Color.GreenYellow;
            formatConditionRuleValue5.Appearance.ForeColor = System.Drawing.Color.Black;
            formatConditionRuleValue5.Appearance.Options.UseBackColor = true;
            formatConditionRuleValue5.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue5.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue5.Value1 = "4";
            gridFormatRule7.Rule = formatConditionRuleValue5;
            this.TrainingGridView.FormatRules.Add(gridFormatRule2);
            this.TrainingGridView.FormatRules.Add(gridFormatRule3);
            this.TrainingGridView.FormatRules.Add(gridFormatRule4);
            this.TrainingGridView.FormatRules.Add(gridFormatRule5);
            this.TrainingGridView.FormatRules.Add(gridFormatRule6);
            this.TrainingGridView.FormatRules.Add(gridFormatRule7);
            this.TrainingGridView.GridControl = this.TrainingGrid;
            this.TrainingGridView.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "ID", null, "Courses={0}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Students", null, "Students={0:0.}")});
            this.TrainingGridView.Name = "TrainingGridView";
            this.TrainingGridView.OptionsDetail.EnableMasterViewMode = false;
            this.TrainingGridView.OptionsDetail.SmartDetailExpandButtonMode = DevExpress.XtraGrid.Views.Grid.DetailExpandButtonMode.CheckDefaultDetail;
            this.TrainingGridView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel;
            this.TrainingGridView.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText;
            this.TrainingGridView.OptionsFilter.InHeaderSearchMode = DevExpress.XtraGrid.Views.Grid.GridInHeaderSearchMode.TextFilter;
            this.TrainingGridView.OptionsFilter.ShowCustomFunctions = DevExpress.Utils.DefaultBoolean.True;
            this.TrainingGridView.OptionsFilter.UseNewCustomFilterDialog = true;
            this.TrainingGridView.OptionsFind.FindDelay = 200;
            this.TrainingGridView.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.Always;
            this.TrainingGridView.OptionsSelection.EnableAppearanceHotTrackedRow = DevExpress.Utils.DefaultBoolean.True;
            this.TrainingGridView.OptionsSelection.ShowCheckBoxSelectorInGroupRow = DevExpress.Utils.DefaultBoolean.True;
            this.TrainingGridView.OptionsView.GroupDrawMode = DevExpress.XtraGrid.Views.Grid.GroupDrawMode.Standard;
            this.TrainingGridView.OptionsView.RowAutoHeight = true;
            this.TrainingGridView.OptionsView.ShowFooter = true;
            this.TrainingGridView.OptionsView.ShowGroupedColumns = true;
            this.TrainingGridView.OptionsView.ShowIndicator = false;
            this.TrainingGridView.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.TrainingGridView.RowHeight = 22;
            this.TrainingGridView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colID, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.TrainingGridView.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.TrainingGridView_RowCellClick);
            this.TrainingGridView.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.TrainingGridView_CustomDrawCell);
            this.TrainingGridView.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.TrainingGridView_PopupMenuShowing);
            this.TrainingGridView.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.TrainingGridView_SelectionChanged);
            this.TrainingGridView.CustomDrawEmptyForeground += new DevExpress.XtraGrid.Views.Base.CustomDrawEventHandler(this.TrainingGridView_CustomDrawEmptyForeground_1);
            this.TrainingGridView.EndGrouping += new System.EventHandler(this.TrainingGridView_EndGrouping);
            this.TrainingGridView.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.TrainingGridView_CellValueChanged);
            this.TrainingGridView.ColumnFilterChanged += new System.EventHandler(this.MultiGrid_ColumnFilterChanged);
            this.TrainingGridView.ShowFilterPopupDate += new DevExpress.XtraGrid.Views.Grid.FilterPopupDateEventHandler(this.ClinicalGridView_ShowFilterPopupDate);
            this.TrainingGridView.PrintInitialize += new DevExpress.XtraGrid.Views.Base.PrintInitializeEventHandler(this.TrainingGridView_PrintInitialize);
            this.TrainingGridView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseClickGrid);
            // 
            // colID
            // 
            this.colID.AppearanceCell.Options.UseTextOptions = true;
            this.colID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colID.AppearanceHeader.Options.UseTextOptions = true;
            this.colID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colID.ColumnEdit = this.RepositoryItemHyperLinkEdit6;
            this.colID.FieldName = "ID";
            this.colID.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colID.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colID.MaxWidth = 174;
            this.colID.MinWidth = 68;
            this.colID.Name = "colID";
            this.colID.OptionsColumn.AllowEdit = false;
            this.colID.OptionsColumn.AllowMove = false;
            this.colID.Visible = true;
            this.colID.VisibleIndex = 0;
            this.colID.Width = 100;
            // 
            // colStudents
            // 
            this.colStudents.AppearanceCell.Options.UseTextOptions = true;
            this.colStudents.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStudents.Caption = " ";
            this.colStudents.FieldName = "Students";
            this.colStudents.ImageOptions.Alignment = System.Drawing.StringAlignment.Center;
            this.colStudents.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.colStudents.MaxWidth = 122;
            this.colStudents.MinWidth = 68;
            this.colStudents.Name = "colStudents";
            this.colStudents.OptionsColumn.AllowEdit = false;
            this.colStudents.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Students", "{0:0.##}")});
            this.colStudents.Visible = true;
            this.colStudents.VisibleIndex = 2;
            this.colStudents.Width = 70;
            // 
            // colCourse
            // 
            this.colCourse.FieldName = "Course";
            this.colCourse.MinWidth = 68;
            this.colCourse.Name = "colCourse";
            this.colCourse.OptionsColumn.AllowEdit = false;
            this.colCourse.Visible = true;
            this.colCourse.VisibleIndex = 4;
            this.colCourse.Width = 137;
            // 
            // colLocation
            // 
            this.colLocation.FieldName = "Location";
            this.colLocation.MaxWidth = 278;
            this.colLocation.MinWidth = 68;
            this.colLocation.Name = "colLocation";
            this.colLocation.OptionsColumn.AllowEdit = false;
            this.colLocation.Visible = true;
            this.colLocation.VisibleIndex = 5;
            this.colLocation.Width = 115;
            // 
            // colExternalRef
            // 
            this.colExternalRef.FieldName = "ExternalRef";
            this.colExternalRef.MaxWidth = 314;
            this.colExternalRef.MinWidth = 68;
            this.colExternalRef.Name = "colExternalRef";
            this.colExternalRef.OptionsColumn.AllowEdit = false;
            this.colExternalRef.Visible = true;
            this.colExternalRef.VisibleIndex = 9;
            this.colExternalRef.Width = 131;
            // 
            // colCourseContact
            // 
            this.colCourseContact.FieldName = "Course Contact";
            this.colCourseContact.MaxWidth = 524;
            this.colCourseContact.MinWidth = 68;
            this.colCourseContact.Name = "colCourseContact";
            this.colCourseContact.OptionsColumn.AllowEdit = false;
            this.colCourseContact.Visible = true;
            this.colCourseContact.VisibleIndex = 7;
            this.colCourseContact.Width = 220;
            // 
            // colCompany
            // 
            this.colCompany.FieldName = "Company";
            this.colCompany.MaxWidth = 698;
            this.colCompany.MinWidth = 68;
            this.colCompany.Name = "colCompany";
            this.colCompany.OptionsColumn.AllowEdit = false;
            this.colCompany.Visible = true;
            this.colCompany.VisibleIndex = 6;
            this.colCompany.Width = 170;
            // 
            // colCourseTime
            // 
            this.colCourseTime.FieldName = "CourseTime";
            this.colCourseTime.MinWidth = 68;
            this.colCourseTime.Name = "colCourseTime";
            this.colCourseTime.OptionsColumn.AllowEdit = false;
            this.colCourseTime.Width = 290;
            // 
            // colTimeStamp
            // 
            this.colTimeStamp.FieldName = "TimeStamp";
            this.colTimeStamp.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            this.colTimeStamp.MaxWidth = 260;
            this.colTimeStamp.MinWidth = 68;
            this.colTimeStamp.Name = "colTimeStamp";
            this.colTimeStamp.OptionsColumn.AllowEdit = false;
            this.colTimeStamp.Width = 246;
            // 
            // GridColumn1
            // 
            this.GridColumn1.AppearanceHeader.Options.UseImage = true;
            this.GridColumn1.Caption = " Email Sent";
            this.GridColumn1.ColumnEdit = this.RepositoryItemCheckEdit2;
            this.GridColumn1.FieldName = "GridColumn1";
            this.GridColumn1.ImageOptions.Alignment = System.Drawing.StringAlignment.Center;
            this.GridColumn1.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.GridColumn1.MaxWidth = 156;
            this.GridColumn1.MinWidth = 68;
            this.GridColumn1.Name = "GridColumn1";
            this.GridColumn1.OptionsColumn.AllowEdit = false;
            this.GridColumn1.ToolTip = "Has the Lead Instructor been sent an email reminder";
            this.GridColumn1.UnboundExpression = "Iif([NotEmail] Is Null, False, True)";
            this.GridColumn1.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            this.GridColumn1.Visible = true;
            this.GridColumn1.VisibleIndex = 11;
            this.GridColumn1.Width = 70;
            // 
            // colNotEmail
            // 
            this.colNotEmail.AppearanceHeader.Options.UseImage = true;
            this.colNotEmail.ColumnEdit = this.RepositoryItemCheckEdit7;
            this.colNotEmail.FieldName = "NotEmail";
            this.colNotEmail.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.colNotEmail.MaxWidth = 156;
            this.colNotEmail.MinWidth = 68;
            this.colNotEmail.Name = "colNotEmail";
            this.colNotEmail.OptionsColumn.AllowEdit = false;
            this.colNotEmail.Width = 156;
            // 
            // RepositoryItemCheckEdit7
            // 
            this.RepositoryItemCheckEdit7.AutoHeight = false;
            this.RepositoryItemCheckEdit7.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.Custom;
            this.RepositoryItemCheckEdit7.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.RepositoryItemCheckEdit7.Name = "RepositoryItemCheckEdit7";
            // 
            // colKPI
            // 
            this.colKPI.AppearanceCell.Options.UseTextOptions = true;
            this.colKPI.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colKPI.AppearanceHeader.Options.UseImage = true;
            this.colKPI.Caption = " ";
            this.colKPI.ColumnEdit = this.RepositoryItemSpinEdit2;
            this.colKPI.DisplayFormat.FormatString = "P0";
            this.colKPI.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colKPI.FieldName = "KPI";
            this.colKPI.ImageOptions.Alignment = System.Drawing.StringAlignment.Center;
            this.colKPI.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.colKPI.MaxWidth = 156;
            this.colKPI.MinWidth = 68;
            this.colKPI.Name = "colKPI";
            this.colKPI.OptionsColumn.AllowEdit = false;
            this.colKPI.ToolTip = "KPI";
            this.colKPI.Visible = true;
            this.colKPI.VisibleIndex = 12;
            this.colKPI.Width = 70;
            // 
            // colFlag
            // 
            this.colFlag.AppearanceHeader.Options.UseImage = true;
            this.colFlag.Caption = " ";
            this.colFlag.ColumnEdit = this.RepositoryItemCheckEdit1;
            this.colFlag.FieldName = "Flag";
            this.colFlag.ImageOptions.Alignment = System.Drawing.StringAlignment.Center;
            this.colFlag.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.colFlag.MaxWidth = 156;
            this.colFlag.MinWidth = 68;
            this.colFlag.Name = "colFlag";
            this.colFlag.OptionsColumn.AllowEdit = false;
            this.colFlag.ToolTip = "Flag";
            this.colFlag.Width = 156;
            // 
            // colIntRef
            // 
            this.colIntRef.Caption = "Invoice";
            this.colIntRef.ColumnEdit = this.RepositoryItemHyperLinkEdit19;
            this.colIntRef.FieldName = "IntRef";
            this.colIntRef.MaxWidth = 246;
            this.colIntRef.MinWidth = 68;
            this.colIntRef.Name = "colIntRef";
            this.colIntRef.OptionsColumn.ReadOnly = true;
            this.colIntRef.Visible = true;
            this.colIntRef.VisibleIndex = 10;
            this.colIntRef.Width = 70;
            // 
            // colDateofCourse
            // 
            this.colDateofCourse.DisplayFormat.FormatString = "ddd, dd MMM yy";
            this.colDateofCourse.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colDateofCourse.FieldName = "DateofCourse";
            this.colDateofCourse.MinWidth = 68;
            this.colDateofCourse.Name = "colDateofCourse";
            this.colDateofCourse.OptionsColumn.AllowEdit = false;
            this.colDateofCourse.Visible = true;
            this.colDateofCourse.VisibleIndex = 3;
            this.colDateofCourse.Width = 108;
            // 
            // colNCR
            // 
            this.colNCR.Caption = " ";
            this.colNCR.ColumnEdit = this.RepositoryItemCheckEdit19;
            this.colNCR.FieldName = "NCR";
            this.colNCR.ImageOptions.Alignment = System.Drawing.StringAlignment.Center;
            this.colNCR.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.CommonPalette;
            this.colNCR.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.colNCR.MaxWidth = 156;
            this.colNCR.MinWidth = 68;
            this.colNCR.Name = "colNCR";
            this.colNCR.OptionsColumn.AllowEdit = false;
            this.colNCR.ToolTip = "NCR";
            this.colNCR.Width = 156;
            // 
            // colCourseType
            // 
            this.colCourseType.FieldName = "CourseType";
            this.colCourseType.MinWidth = 60;
            this.colCourseType.Name = "colCourseType";
            this.colCourseType.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.DateSmart;
            this.colCourseType.ToolTip = "Course Type";
            this.colCourseType.Width = 224;
            // 
            // colNotEmail2
            // 
            this.colNotEmail2.FieldName = "NotEmail";
            this.colNotEmail2.MinWidth = 60;
            this.colNotEmail2.Name = "colNotEmail2";
            this.colNotEmail2.Width = 224;
            // 
            // colCert
            // 
            this.colCert.FieldName = "Cert";
            this.colCert.MinWidth = 60;
            this.colCert.Name = "colCert";
            this.colCert.Width = 224;
            // 
            // colIV
            // 
            this.colIV.ColumnEdit = this.RepositoryItemCheckEdit14;
            this.colIV.FieldName = "IV";
            this.colIV.MaxWidth = 134;
            this.colIV.MinWidth = 60;
            this.colIV.Name = "colIV";
            this.colIV.Visible = true;
            this.colIV.VisibleIndex = 13;
            this.colIV.Width = 77;
            // 
            // RepositoryItemCheckEdit14
            // 
            this.RepositoryItemCheckEdit14.AutoHeight = false;
            this.RepositoryItemCheckEdit14.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.Custom;
            this.RepositoryItemCheckEdit14.ImageOptions.SvgImageChecked = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("RepositoryItemCheckEdit14.ImageOptions.SvgImageChecked")));
            this.RepositoryItemCheckEdit14.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.RepositoryItemCheckEdit14.Name = "RepositoryItemCheckEdit14";
            // 
            // RepositoryItemColorEdit1
            // 
            this.RepositoryItemColorEdit1.AutoHeight = false;
            this.RepositoryItemColorEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RepositoryItemColorEdit1.Name = "RepositoryItemColorEdit1";
            // 
            // RepositoryItemCalcEdit1
            // 
            this.RepositoryItemCalcEdit1.AutoHeight = false;
            this.RepositoryItemCalcEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RepositoryItemCalcEdit1.Name = "RepositoryItemCalcEdit1";
            // 
            // tabClinical
            // 
            this.tabClinical.Controls.Add(this.ClincalGridControl);
            this.tabClinical.Margin = new System.Windows.Forms.Padding(8);
            this.tabClinical.Name = "tabClinical";
            this.tabClinical.Size = new System.Drawing.Size(1703, 776);
            this.tabClinical.Text = "Clinical";
            // 
            // ClincalGridControl
            // 
            this.ClincalGridControl.AllowDrop = true;
            this.ClincalGridControl.DataSource = this.shiftsBindingSource;
            this.ClincalGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ClincalGridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(8);
            this.ClincalGridControl.Location = new System.Drawing.Point(0, 0);
            this.ClincalGridControl.MainView = this.ClinicalGridView;
            this.ClincalGridControl.Margin = new System.Windows.Forms.Padding(8);
            this.ClincalGridControl.MenuManager = this.RibbonControl1;
            this.ClincalGridControl.Name = "ClincalGridControl";
            this.ClincalGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.RepositoryItemLookUpEdit6});
            this.ClincalGridControl.Size = new System.Drawing.Size(1703, 776);
            this.ClincalGridControl.TabIndex = 0;
            this.ClincalGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.ClinicalGridView});
            this.ClincalGridControl.DragDrop += new System.Windows.Forms.DragEventHandler(this.ClincalGridControl_DragDrop);
            this.ClincalGridControl.DragOver += new System.Windows.Forms.DragEventHandler(this.ClincalGridControl_DragOver);
            // 
            // shiftsBindingSource
            // 
            this.shiftsBindingSource.DataMember = "Shifts";
            this.shiftsBindingSource.DataSource = this.ClinicalDataSet;
            // 
            // ClinicalGridView
            // 
            this.ClinicalGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID1,
            this.colShiftAttending,
            this.colLocation1,
            this.colDutyType,
            this.colNotes,
            this.colAR,
            this.colExpID,
            this.colStatus1,
            this.colHours,
            this.colDutyDate,
            this.colRecords,
            this.colRecordCreated,
            this.colCreatedBY,
            this.colRecordClosed,
            this.colLinkID,
            this.colTimeStamp1,
            this.colShiftSheet,
            this.colAddType,
            this.colShiftSheetReceived,
            this.colNotified,
            this.colPO,
            this.colHaveShiftSheet,
            this.colNotEmail1,
            this.colMedicID,
            this.colPin,
            this.colRole,
            this.colTableSort1,
            this.colPath1,
            this.colTemp,
            this.colStart,
            this.colFinish,
            this.colShiftscol,
            this.colLicenceExpiry,
            this.colCPGVersion,
            this.colInvoice,
            this.colOrgExport,
            this.colFlag1,
            this.colSP,
            this.colClient,
            this.colPrice,
            this.colInvoiceType});
            this.ClinicalGridView.DetailHeight = 1130;
            this.ClinicalGridView.GridControl = this.ClincalGridControl;
            this.ClinicalGridView.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Hours", null, "(Hours: Total={0:0.##})"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Average, "Hours", null, "(Hours: Avg={0:0.##})"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "ID", null, "(ID: Count={0})")});
            this.ClinicalGridView.Name = "ClinicalGridView";
            this.ClinicalGridView.OptionsFilter.InHeaderSearchMode = DevExpress.XtraGrid.Views.Grid.GridInHeaderSearchMode.TextFilter;
            this.ClinicalGridView.OptionsFind.FindDelay = 200;
            this.ClinicalGridView.OptionsMenu.ShowGroupSummaryEditorItem = true;
            this.ClinicalGridView.OptionsSelection.EnableAppearanceHotTrackedRow = DevExpress.Utils.DefaultBoolean.True;
            this.ClinicalGridView.OptionsSelection.ShowCheckBoxSelectorInGroupRow = DevExpress.Utils.DefaultBoolean.True;
            this.ClinicalGridView.OptionsSelection.UseIndicatorForSelection = false;
            this.ClinicalGridView.OptionsView.EnableAppearanceOddRow = true;
            this.ClinicalGridView.OptionsView.RowAutoHeight = true;
            this.ClinicalGridView.OptionsView.ShowFooter = true;
            this.ClinicalGridView.OptionsView.ShowIndicator = false;
            this.ClinicalGridView.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.ClinicalGridView.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Indicator;
            this.ClinicalGridView.RowHeight = 22;
            this.ClinicalGridView.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.ClinicalGridView_RowCellClick);
            this.ClinicalGridView.CustomDrawGroupRow += new DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventHandler(this.ClinicalGridView_CustomDrawGroupRow);
            this.ClinicalGridView.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.ClinicalGridView_PopupMenuShowing);
            this.ClinicalGridView.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.ClinicalGridView_SelectionChanged);
            this.ClinicalGridView.CustomDrawEmptyForeground += new DevExpress.XtraGrid.Views.Base.CustomDrawEventHandler(this.ClinicalGridView_CustomDrawEmptyForeground);
            this.ClinicalGridView.EndGrouping += new System.EventHandler(this.ClinicalGridView_EndGrouping);
            this.ClinicalGridView.ColumnFilterChanged += new System.EventHandler(this.MultiGrid_ColumnFilterChanged);
            this.ClinicalGridView.ShowFilterPopupDate += new DevExpress.XtraGrid.Views.Grid.FilterPopupDateEventHandler(this.ClinicalGridView_ShowFilterPopupDate);
            this.ClinicalGridView.QueryCustomFunctions += new DevExpress.XtraGrid.Views.Grid.QueryCustomFunctionsEventHandler(this.ClinicalGridView_QueryCustomFunctions);
            this.ClinicalGridView.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.ClinicalGridView_CustomUnboundColumnData);
            this.ClinicalGridView.PrintInitialize += new DevExpress.XtraGrid.Views.Base.PrintInitializeEventHandler(this.TrainingGridView_PrintInitialize);
            this.ClinicalGridView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseClickGrid);
            // 
            // colID1
            // 
            this.colID1.AppearanceCell.Options.UseTextOptions = true;
            this.colID1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colID1.AppearanceHeader.Options.UseTextOptions = true;
            this.colID1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colID1.ColumnEdit = this.RepositoryItemHyperLinkEdit7;
            this.colID1.FieldName = "ID";
            this.colID1.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colID1.MaxWidth = 150;
            this.colID1.MinWidth = 68;
            this.colID1.Name = "colID1";
            this.colID1.OptionsColumn.AllowEdit = false;
            this.colID1.Visible = true;
            this.colID1.VisibleIndex = 0;
            this.colID1.Width = 85;
            // 
            // colShiftAttending
            // 
            this.colShiftAttending.FieldName = "Shift Attending";
            this.colShiftAttending.MinWidth = 68;
            this.colShiftAttending.Name = "colShiftAttending";
            this.colShiftAttending.OptionsColumn.AllowEdit = false;
            this.colShiftAttending.Width = 260;
            // 
            // colLocation1
            // 
            this.colLocation1.FieldName = "Location";
            this.colLocation1.MinWidth = 68;
            this.colLocation1.Name = "colLocation1";
            this.colLocation1.OptionsColumn.AllowEdit = false;
            this.colLocation1.Visible = true;
            this.colLocation1.VisibleIndex = 5;
            this.colLocation1.Width = 74;
            // 
            // colDutyType
            // 
            this.colDutyType.FieldName = "DutyType";
            this.colDutyType.MinWidth = 68;
            this.colDutyType.Name = "colDutyType";
            this.colDutyType.OptionsColumn.ReadOnly = true;
            this.colDutyType.Visible = true;
            this.colDutyType.VisibleIndex = 4;
            this.colDutyType.Width = 130;
            // 
            // colNotes
            // 
            this.colNotes.FieldName = "Notes";
            this.colNotes.MinWidth = 68;
            this.colNotes.Name = "colNotes";
            this.colNotes.OptionsColumn.AllowEdit = false;
            this.colNotes.Width = 260;
            // 
            // colAR
            // 
            this.colAR.FieldName = "AR";
            this.colAR.MinWidth = 68;
            this.colAR.Name = "colAR";
            this.colAR.OptionsColumn.AllowEdit = false;
            this.colAR.Width = 260;
            // 
            // colExpID
            // 
            this.colExpID.FieldName = "ExpID";
            this.colExpID.MinWidth = 68;
            this.colExpID.Name = "colExpID";
            this.colExpID.OptionsColumn.AllowEdit = false;
            this.colExpID.Width = 260;
            // 
            // colStatus1
            // 
            this.colStatus1.AppearanceCell.Options.UseTextOptions = true;
            this.colStatus1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStatus1.AppearanceHeader.Options.UseTextOptions = true;
            this.colStatus1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStatus1.FieldName = "Status";
            this.colStatus1.MaxWidth = 210;
            this.colStatus1.MinWidth = 68;
            this.colStatus1.Name = "colStatus1";
            this.colStatus1.OptionsColumn.AllowEdit = false;
            this.colStatus1.Visible = true;
            this.colStatus1.VisibleIndex = 12;
            this.colStatus1.Width = 69;
            // 
            // colHours
            // 
            this.colHours.AppearanceCell.BackColor = System.Drawing.SystemColors.Info;
            this.colHours.AppearanceCell.ForeColor = System.Drawing.Color.Black;
            this.colHours.AppearanceCell.Options.UseBackColor = true;
            this.colHours.AppearanceCell.Options.UseForeColor = true;
            this.colHours.AppearanceCell.Options.UseTextOptions = true;
            this.colHours.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHours.AppearanceHeader.Options.UseTextOptions = true;
            this.colHours.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHours.FieldName = "Hours";
            this.colHours.MaxWidth = 192;
            this.colHours.MinWidth = 68;
            this.colHours.Name = "colHours";
            this.colHours.OptionsColumn.AllowEdit = false;
            this.colHours.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Hours", "{0:0.##}")});
            this.colHours.Visible = true;
            this.colHours.VisibleIndex = 10;
            this.colHours.Width = 69;
            // 
            // colDutyDate
            // 
            this.colDutyDate.ColumnEdit = this.RepositoryItemDateEdit1;
            this.colDutyDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colDutyDate.FieldName = "DutyDate";
            this.colDutyDate.MinWidth = 125;
            this.colDutyDate.Name = "colDutyDate";
            this.colDutyDate.OptionsColumn.AllowEdit = false;
            this.colDutyDate.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.True;
            this.colDutyDate.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.Date;
            this.colDutyDate.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "DutyDate", "{0} Shifts")});
            this.colDutyDate.Tag = "Date";
            this.colDutyDate.Visible = true;
            this.colDutyDate.VisibleIndex = 1;
            this.colDutyDate.Width = 125;
            // 
            // colRecords
            // 
            this.colRecords.AppearanceCell.Options.UseTextOptions = true;
            this.colRecords.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRecords.AppearanceHeader.Options.UseTextOptions = true;
            this.colRecords.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRecords.Caption = "Records";
            this.colRecords.FieldName = "Records";
            this.colRecords.MaxWidth = 192;
            this.colRecords.MinWidth = 68;
            this.colRecords.Name = "colRecords";
            this.colRecords.OptionsColumn.AllowEdit = false;
            this.colRecords.Visible = true;
            this.colRecords.VisibleIndex = 11;
            this.colRecords.Width = 69;
            // 
            // colRecordCreated
            // 
            this.colRecordCreated.FieldName = "Record Created";
            this.colRecordCreated.MinWidth = 68;
            this.colRecordCreated.Name = "colRecordCreated";
            this.colRecordCreated.OptionsColumn.AllowEdit = false;
            this.colRecordCreated.Width = 260;
            // 
            // colCreatedBY
            // 
            this.colCreatedBY.FieldName = "CreatedBY";
            this.colCreatedBY.MinWidth = 68;
            this.colCreatedBY.Name = "colCreatedBY";
            this.colCreatedBY.OptionsColumn.AllowEdit = false;
            this.colCreatedBY.Width = 260;
            // 
            // colRecordClosed
            // 
            this.colRecordClosed.FieldName = "RecordClosed";
            this.colRecordClosed.MinWidth = 68;
            this.colRecordClosed.Name = "colRecordClosed";
            this.colRecordClosed.OptionsColumn.AllowEdit = false;
            this.colRecordClosed.Width = 260;
            // 
            // colLinkID
            // 
            this.colLinkID.FieldName = "LinkID";
            this.colLinkID.MinWidth = 68;
            this.colLinkID.Name = "colLinkID";
            this.colLinkID.OptionsColumn.AllowEdit = false;
            this.colLinkID.Width = 260;
            // 
            // colTimeStamp1
            // 
            this.colTimeStamp1.FieldName = "TimeStamp";
            this.colTimeStamp1.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            this.colTimeStamp1.MaxWidth = 200;
            this.colTimeStamp1.MinWidth = 68;
            this.colTimeStamp1.Name = "colTimeStamp1";
            this.colTimeStamp1.OptionsColumn.AllowEdit = false;
            this.colTimeStamp1.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.Date;
            this.colTimeStamp1.Width = 200;
            // 
            // colShiftSheet
            // 
            this.colShiftSheet.FieldName = "Shift Sheet";
            this.colShiftSheet.MinWidth = 68;
            this.colShiftSheet.Name = "colShiftSheet";
            this.colShiftSheet.OptionsColumn.AllowEdit = false;
            this.colShiftSheet.Width = 260;
            // 
            // colAddType
            // 
            this.colAddType.FieldName = "AddType";
            this.colAddType.MinWidth = 68;
            this.colAddType.Name = "colAddType";
            this.colAddType.OptionsColumn.AllowEdit = false;
            this.colAddType.Width = 260;
            // 
            // colShiftSheetReceived
            // 
            this.colShiftSheetReceived.FieldName = "ShiftSheetReceived";
            this.colShiftSheetReceived.MinWidth = 68;
            this.colShiftSheetReceived.Name = "colShiftSheetReceived";
            this.colShiftSheetReceived.OptionsColumn.AllowEdit = false;
            this.colShiftSheetReceived.Width = 260;
            // 
            // colNotified
            // 
            this.colNotified.ColumnEdit = this.RepositoryItemCheckEdit4;
            this.colNotified.FieldName = "Email Sent";
            this.colNotified.ImageOptions.Alignment = System.Drawing.StringAlignment.Center;
            this.colNotified.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.colNotified.MaxWidth = 50;
            this.colNotified.MinWidth = 68;
            this.colNotified.Name = "colNotified";
            this.colNotified.OptionsColumn.AllowEdit = false;
            this.colNotified.UnboundExpression = "Iif(IsNullOrEmpty([NotEmail]), False, True)";
            this.colNotified.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            this.colNotified.Visible = true;
            this.colNotified.VisibleIndex = 16;
            this.colNotified.Width = 68;
            // 
            // colPO
            // 
            this.colPO.FieldName = "PO";
            this.colPO.MaxWidth = 300;
            this.colPO.MinWidth = 60;
            this.colPO.Name = "colPO";
            this.colPO.OptionsColumn.AllowEdit = false;
            this.colPO.Visible = true;
            this.colPO.VisibleIndex = 13;
            this.colPO.Width = 61;
            // 
            // colHaveShiftSheet
            // 
            this.colHaveShiftSheet.Caption = "ShiftSheet";
            this.colHaveShiftSheet.ColumnEdit = this.RepositoryItemCheckEdit5;
            this.colHaveShiftSheet.FieldName = "ShiftSheet";
            this.colHaveShiftSheet.ImageOptions.Alignment = System.Drawing.StringAlignment.Center;
            this.colHaveShiftSheet.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.colHaveShiftSheet.MaxWidth = 50;
            this.colHaveShiftSheet.MinWidth = 68;
            this.colHaveShiftSheet.Name = "colHaveShiftSheet";
            this.colHaveShiftSheet.OptionsColumn.AllowEdit = false;
            this.colHaveShiftSheet.UnboundExpression = "Iif(IsNullOrEmpty([ShiftSheetReceived]), False, True)";
            this.colHaveShiftSheet.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            this.colHaveShiftSheet.Visible = true;
            this.colHaveShiftSheet.VisibleIndex = 14;
            this.colHaveShiftSheet.Width = 68;
            // 
            // RepositoryItemCheckEdit5
            // 
            this.RepositoryItemCheckEdit5.AutoHeight = false;
            this.RepositoryItemCheckEdit5.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            this.RepositoryItemCheckEdit5.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.RepositoryItemCheckEdit5.Name = "RepositoryItemCheckEdit5";
            // 
            // colNotEmail1
            // 
            this.colNotEmail1.FieldName = "NotEmail";
            this.colNotEmail1.MinWidth = 68;
            this.colNotEmail1.Name = "colNotEmail1";
            this.colNotEmail1.OptionsColumn.AllowEdit = false;
            this.colNotEmail1.Width = 260;
            // 
            // colMedicID
            // 
            this.colMedicID.Caption = "Medic";
            this.colMedicID.ColumnEdit = this.RepositoryItemLookUpEdit6;
            this.colMedicID.FieldName = "MedicID";
            this.colMedicID.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colMedicID.MinWidth = 68;
            this.colMedicID.Name = "colMedicID";
            this.colMedicID.OptionsColumn.AllowEdit = false;
            this.colMedicID.Visible = true;
            this.colMedicID.VisibleIndex = 2;
            this.colMedicID.Width = 186;
            // 
            // RepositoryItemLookUpEdit6
            // 
            this.RepositoryItemLookUpEdit6.AutoHeight = false;
            this.RepositoryItemLookUpEdit6.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RepositoryItemLookUpEdit6.DisplayMember = "InstructorName";
            this.RepositoryItemLookUpEdit6.Name = "RepositoryItemLookUpEdit6";
            this.RepositoryItemLookUpEdit6.ValueMember = "ID";
            // 
            // colPin
            // 
            this.colPin.AppearanceCell.Options.UseTextOptions = true;
            this.colPin.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPin.AppearanceHeader.Options.UseTextOptions = true;
            this.colPin.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPin.FieldName = "Pin";
            this.colPin.MaxWidth = 174;
            this.colPin.MinWidth = 68;
            this.colPin.Name = "colPin";
            this.colPin.OptionsColumn.AllowEdit = false;
            this.colPin.Visible = true;
            this.colPin.VisibleIndex = 3;
            this.colPin.Width = 69;
            // 
            // colRole
            // 
            this.colRole.FieldName = "Role";
            this.colRole.MinWidth = 68;
            this.colRole.Name = "colRole";
            this.colRole.OptionsColumn.AllowEdit = false;
            this.colRole.Visible = true;
            this.colRole.VisibleIndex = 7;
            this.colRole.Width = 69;
            // 
            // colTableSort1
            // 
            this.colTableSort1.FieldName = "TableSort";
            this.colTableSort1.MinWidth = 68;
            this.colTableSort1.Name = "colTableSort1";
            this.colTableSort1.OptionsColumn.AllowEdit = false;
            this.colTableSort1.Width = 260;
            // 
            // colPath1
            // 
            this.colPath1.FieldName = "Path";
            this.colPath1.MinWidth = 68;
            this.colPath1.Name = "colPath1";
            this.colPath1.OptionsColumn.AllowEdit = false;
            this.colPath1.Width = 260;
            // 
            // colTemp
            // 
            this.colTemp.FieldName = "Temp";
            this.colTemp.MinWidth = 68;
            this.colTemp.Name = "colTemp";
            this.colTemp.OptionsColumn.AllowEdit = false;
            this.colTemp.Width = 260;
            // 
            // colStart
            // 
            this.colStart.AppearanceCell.Options.UseTextOptions = true;
            this.colStart.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStart.AppearanceHeader.Options.UseTextOptions = true;
            this.colStart.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStart.DisplayFormat.FormatString = "HH:mm";
            this.colStart.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colStart.FieldName = "Start";
            this.colStart.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colStart.MaxWidth = 192;
            this.colStart.MinWidth = 68;
            this.colStart.Name = "colStart";
            this.colStart.OptionsColumn.AllowEdit = false;
            this.colStart.Visible = true;
            this.colStart.VisibleIndex = 8;
            this.colStart.Width = 69;
            // 
            // colFinish
            // 
            this.colFinish.AppearanceCell.Options.UseTextOptions = true;
            this.colFinish.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colFinish.AppearanceHeader.Options.UseTextOptions = true;
            this.colFinish.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colFinish.DisplayFormat.FormatString = "HH:mm";
            this.colFinish.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colFinish.FieldName = "Finish";
            this.colFinish.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colFinish.MaxWidth = 192;
            this.colFinish.MinWidth = 68;
            this.colFinish.Name = "colFinish";
            this.colFinish.OptionsColumn.AllowEdit = false;
            this.colFinish.Visible = true;
            this.colFinish.VisibleIndex = 9;
            this.colFinish.Width = 69;
            // 
            // colShiftscol
            // 
            this.colShiftscol.FieldName = "Shiftscol";
            this.colShiftscol.MinWidth = 68;
            this.colShiftscol.Name = "colShiftscol";
            this.colShiftscol.OptionsColumn.AllowEdit = false;
            this.colShiftscol.Width = 260;
            // 
            // colLicenceExpiry
            // 
            this.colLicenceExpiry.FieldName = "LicenceExpiry";
            this.colLicenceExpiry.MinWidth = 68;
            this.colLicenceExpiry.Name = "colLicenceExpiry";
            this.colLicenceExpiry.OptionsColumn.AllowEdit = false;
            this.colLicenceExpiry.Width = 260;
            // 
            // colCPGVersion
            // 
            this.colCPGVersion.FieldName = "CPGVersion";
            this.colCPGVersion.MinWidth = 68;
            this.colCPGVersion.Name = "colCPGVersion";
            this.colCPGVersion.OptionsColumn.AllowEdit = false;
            this.colCPGVersion.Width = 150;
            // 
            // colInvoice
            // 
            this.colInvoice.FieldName = "Invoice";
            this.colInvoice.MaxWidth = 228;
            this.colInvoice.MinWidth = 50;
            this.colInvoice.Name = "colInvoice";
            this.colInvoice.OptionsColumn.AllowEdit = false;
            this.colInvoice.Visible = true;
            this.colInvoice.VisibleIndex = 15;
            this.colInvoice.Width = 141;
            // 
            // colOrgExport
            // 
            this.colOrgExport.FieldName = "OrgExport";
            this.colOrgExport.MinWidth = 68;
            this.colOrgExport.Name = "colOrgExport";
            this.colOrgExport.OptionsColumn.AllowEdit = false;
            this.colOrgExport.Width = 260;
            // 
            // colFlag1
            // 
            this.colFlag1.AppearanceHeader.Options.UseImage = true;
            this.colFlag1.Caption = "Flagged";
            this.colFlag1.ColumnEdit = this.RepositoryItemCheckEdit3;
            this.colFlag1.FieldName = "Flag";
            this.colFlag1.ImageOptions.Alignment = System.Drawing.StringAlignment.Center;
            this.colFlag1.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.colFlag1.MaxWidth = 50;
            this.colFlag1.MinWidth = 50;
            this.colFlag1.Name = "colFlag1";
            this.colFlag1.OptionsColumn.AllowEdit = false;
            this.colFlag1.Visible = true;
            this.colFlag1.VisibleIndex = 17;
            this.colFlag1.Width = 50;
            // 
            // RepositoryItemCheckEdit3
            // 
            this.RepositoryItemCheckEdit3.AutoHeight = false;
            this.RepositoryItemCheckEdit3.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            this.RepositoryItemCheckEdit3.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.RepositoryItemCheckEdit3.Name = "RepositoryItemCheckEdit3";
            // 
            // colSP
            // 
            this.colSP.FieldName = "SP";
            this.colSP.MinWidth = 60;
            this.colSP.Name = "colSP";
            this.colSP.Width = 402;
            // 
            // colClient
            // 
            this.colClient.FieldName = "Client";
            this.colClient.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colClient.GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.DisplayText;
            this.colClient.MinWidth = 60;
            this.colClient.Name = "colClient";
            this.colClient.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.True;
            this.colClient.Visible = true;
            this.colClient.VisibleIndex = 6;
            this.colClient.Width = 234;
            // 
            // colPrice
            // 
            this.colPrice.FieldName = "Price";
            this.colPrice.Name = "colPrice";
            // 
            // colInvoiceType
            // 
            this.colInvoiceType.FieldName = "InvoiceType";
            this.colInvoiceType.Name = "colInvoiceType";
            // 
            // tabLeads
            // 
            this.tabLeads.Controls.Add(this.ActivitiesGridControl);
            this.tabLeads.Margin = new System.Windows.Forms.Padding(8);
            this.tabLeads.Name = "tabLeads";
            this.tabLeads.Size = new System.Drawing.Size(1703, 776);
            this.tabLeads.Text = "Leads";
            // 
            // ActivitiesGridControl
            // 
            this.ActivitiesGridControl.DataSource = this.ActivitiesBindingSource;
            this.ActivitiesGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ActivitiesGridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(8);
            this.ActivitiesGridControl.Location = new System.Drawing.Point(0, 0);
            this.ActivitiesGridControl.MainView = this.LeadsGrid;
            this.ActivitiesGridControl.Margin = new System.Windows.Forms.Padding(8);
            this.ActivitiesGridControl.MenuManager = this.RibbonControl1;
            this.ActivitiesGridControl.Name = "ActivitiesGridControl";
            this.ActivitiesGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit7});
            this.ActivitiesGridControl.Size = new System.Drawing.Size(1703, 776);
            this.ActivitiesGridControl.TabIndex = 0;
            this.ActivitiesGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.LeadsGrid});
            // 
            // LeadsGrid
            // 
            this.LeadsGrid.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID4,
            this.colAName,
            this.colType,
            this.colDue,
            this.colTimeStamp3,
            this.colComplete,
            this.colContactID,
            this.colAssignedTo,
            this.colPriority,
            this.colCreated,
            this.colCreatedBy1,
            this.colMemo,
            this.colValue,
            this.colStage,
            this.colExp,
            this.colPhone,
            this.colEmail2,
            this.colOrg,
            this.colRef,
            this.colEmailMemo,
            this.colSource,
            this.colLeadSeen,
            this.colActivitiescol,
            this.colOrg1});
            this.LeadsGrid.DetailHeight = 1130;
            this.LeadsGrid.GridControl = this.ActivitiesGridControl;
            this.LeadsGrid.Name = "LeadsGrid";
            this.LeadsGrid.OptionsFind.AlwaysVisible = true;
            this.LeadsGrid.OptionsSelection.EnableAppearanceHotTrackedRow = DevExpress.Utils.DefaultBoolean.True;
            this.LeadsGrid.OptionsView.EnableAppearanceOddRow = true;
            this.LeadsGrid.OptionsView.ShowIndicator = false;
            this.LeadsGrid.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.LeadsGrid.RowHeight = 22;
            this.LeadsGrid.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.LeadsGrid_RowCellClick);
            this.LeadsGrid.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.LeadsGrid_CustomDrawCell);
            this.LeadsGrid.CustomDrawEmptyForeground += new DevExpress.XtraGrid.Views.Base.CustomDrawEventHandler(this.LeadsGrid_CustomDrawEmptyForeground);
            this.LeadsGrid.ColumnFilterChanged += new System.EventHandler(this.MultiGrid_ColumnFilterChanged);
            this.LeadsGrid.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseClickGrid);
            // 
            // colID4
            // 
            this.colID4.AppearanceCell.Options.UseTextOptions = true;
            this.colID4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colID4.AppearanceHeader.Options.UseTextOptions = true;
            this.colID4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colID4.FieldName = "ID";
            this.colID4.MinWidth = 68;
            this.colID4.Name = "colID4";
            this.colID4.OptionsColumn.AllowEdit = false;
            this.colID4.Visible = true;
            this.colID4.VisibleIndex = 0;
            this.colID4.Width = 100;
            // 
            // colAName
            // 
            this.colAName.Caption = "Name";
            this.colAName.ColumnEdit = this.RepositoryItemHyperLinkEdit14;
            this.colAName.FieldName = "AName";
            this.colAName.MinWidth = 68;
            this.colAName.Name = "colAName";
            this.colAName.OptionsColumn.AllowEdit = false;
            this.colAName.Visible = true;
            this.colAName.VisibleIndex = 1;
            this.colAName.Width = 349;
            // 
            // colType
            // 
            this.colType.FieldName = "Type";
            this.colType.MinWidth = 68;
            this.colType.Name = "colType";
            this.colType.OptionsColumn.AllowEdit = false;
            this.colType.Width = 260;
            // 
            // colDue
            // 
            this.colDue.FieldName = "Due";
            this.colDue.MaxWidth = 350;
            this.colDue.MinWidth = 68;
            this.colDue.Name = "colDue";
            this.colDue.OptionsColumn.AllowEdit = false;
            this.colDue.Visible = true;
            this.colDue.VisibleIndex = 4;
            this.colDue.Width = 156;
            // 
            // colTimeStamp3
            // 
            this.colTimeStamp3.FieldName = "TimeStamp";
            this.colTimeStamp3.MaxWidth = 260;
            this.colTimeStamp3.MinWidth = 68;
            this.colTimeStamp3.Name = "colTimeStamp3";
            this.colTimeStamp3.OptionsColumn.AllowEdit = false;
            this.colTimeStamp3.Visible = true;
            this.colTimeStamp3.VisibleIndex = 9;
            this.colTimeStamp3.Width = 146;
            // 
            // colComplete
            // 
            this.colComplete.FieldName = "Complete";
            this.colComplete.MinWidth = 68;
            this.colComplete.Name = "colComplete";
            this.colComplete.OptionsColumn.AllowEdit = false;
            this.colComplete.Width = 396;
            // 
            // colContactID
            // 
            this.colContactID.FieldName = "ContactID";
            this.colContactID.MinWidth = 68;
            this.colContactID.Name = "colContactID";
            this.colContactID.OptionsColumn.AllowEdit = false;
            this.colContactID.Width = 260;
            // 
            // colAssignedTo
            // 
            this.colAssignedTo.ColumnEdit = this.repositoryItemLookUpEdit7;
            this.colAssignedTo.FieldName = "AssignedTo";
            this.colAssignedTo.MaxWidth = 420;
            this.colAssignedTo.MinWidth = 68;
            this.colAssignedTo.Name = "colAssignedTo";
            this.colAssignedTo.OptionsColumn.AllowEdit = false;
            this.colAssignedTo.Visible = true;
            this.colAssignedTo.VisibleIndex = 5;
            this.colAssignedTo.Width = 191;
            // 
            // repositoryItemLookUpEdit7
            // 
            this.repositoryItemLookUpEdit7.AutoHeight = false;
            this.repositoryItemLookUpEdit7.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit7.DataSource = this.SystemUsersBindingSource1;
            this.repositoryItemLookUpEdit7.DisplayMember = "UserName";
            this.repositoryItemLookUpEdit7.Name = "repositoryItemLookUpEdit7";
            this.repositoryItemLookUpEdit7.ValueMember = "ID";
            // 
            // SystemUsersBindingSource1
            // 
            this.SystemUsersBindingSource1.DataMember = "SystemUsers";
            this.SystemUsersBindingSource1.DataSource = this.MainDataSet;
            // 
            // colPriority
            // 
            this.colPriority.FieldName = "Priority";
            this.colPriority.MaxWidth = 246;
            this.colPriority.MinWidth = 68;
            this.colPriority.Name = "colPriority";
            this.colPriority.OptionsColumn.AllowEdit = false;
            this.colPriority.Visible = true;
            this.colPriority.VisibleIndex = 6;
            this.colPriority.Width = 109;
            // 
            // colCreated
            // 
            this.colCreated.FieldName = "Created";
            this.colCreated.MaxWidth = 350;
            this.colCreated.MinWidth = 68;
            this.colCreated.Name = "colCreated";
            this.colCreated.OptionsColumn.AllowEdit = false;
            this.colCreated.Visible = true;
            this.colCreated.VisibleIndex = 7;
            this.colCreated.Width = 156;
            // 
            // colCreatedBy1
            // 
            this.colCreatedBy1.FieldName = "CreatedBy";
            this.colCreatedBy1.MinWidth = 68;
            this.colCreatedBy1.Name = "colCreatedBy1";
            this.colCreatedBy1.OptionsColumn.AllowEdit = false;
            this.colCreatedBy1.Width = 260;
            // 
            // colMemo
            // 
            this.colMemo.FieldName = "Memo";
            this.colMemo.MinWidth = 68;
            this.colMemo.Name = "colMemo";
            this.colMemo.OptionsColumn.AllowEdit = false;
            this.colMemo.Width = 260;
            // 
            // colValue
            // 
            this.colValue.AppearanceCell.Options.UseTextOptions = true;
            this.colValue.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colValue.AppearanceHeader.Options.UseTextOptions = true;
            this.colValue.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colValue.DisplayFormat.FormatString = "c0";
            this.colValue.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colValue.FieldName = "Value";
            this.colValue.MaxWidth = 260;
            this.colValue.MinWidth = 68;
            this.colValue.Name = "colValue";
            this.colValue.OptionsColumn.AllowEdit = false;
            this.colValue.Visible = true;
            this.colValue.VisibleIndex = 8;
            this.colValue.Width = 115;
            // 
            // colStage
            // 
            this.colStage.AppearanceCell.Options.UseTextOptions = true;
            this.colStage.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStage.AppearanceHeader.Options.UseTextOptions = true;
            this.colStage.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStage.FieldName = "Stage";
            this.colStage.MaxWidth = 330;
            this.colStage.MinWidth = 68;
            this.colStage.Name = "colStage";
            this.colStage.OptionsColumn.AllowEdit = false;
            this.colStage.Visible = true;
            this.colStage.VisibleIndex = 3;
            this.colStage.Width = 149;
            // 
            // colExp
            // 
            this.colExp.FieldName = "Exp";
            this.colExp.MinWidth = 68;
            this.colExp.Name = "colExp";
            this.colExp.OptionsColumn.AllowEdit = false;
            this.colExp.Width = 260;
            // 
            // colPhone
            // 
            this.colPhone.FieldName = "Phone";
            this.colPhone.MinWidth = 68;
            this.colPhone.Name = "colPhone";
            this.colPhone.OptionsColumn.AllowEdit = false;
            this.colPhone.Width = 260;
            // 
            // colEmail2
            // 
            this.colEmail2.FieldName = "Email";
            this.colEmail2.MinWidth = 68;
            this.colEmail2.Name = "colEmail2";
            this.colEmail2.OptionsColumn.AllowEdit = false;
            this.colEmail2.Width = 260;
            // 
            // colOrg
            // 
            this.colOrg.FieldName = "Org";
            this.colOrg.MinWidth = 68;
            this.colOrg.Name = "colOrg";
            this.colOrg.OptionsColumn.AllowEdit = false;
            this.colOrg.Width = 260;
            // 
            // colRef
            // 
            this.colRef.FieldName = "Ref";
            this.colRef.MinWidth = 68;
            this.colRef.Name = "colRef";
            this.colRef.OptionsColumn.AllowEdit = false;
            this.colRef.Width = 260;
            // 
            // colEmailMemo
            // 
            this.colEmailMemo.FieldName = "EmailMemo";
            this.colEmailMemo.MinWidth = 68;
            this.colEmailMemo.Name = "colEmailMemo";
            this.colEmailMemo.OptionsColumn.AllowEdit = false;
            this.colEmailMemo.Width = 260;
            // 
            // colSource
            // 
            this.colSource.FieldName = "Source";
            this.colSource.MinWidth = 68;
            this.colSource.Name = "colSource";
            this.colSource.OptionsColumn.AllowEdit = false;
            this.colSource.Width = 260;
            // 
            // colLeadSeen
            // 
            this.colLeadSeen.FieldName = "LeadSeen";
            this.colLeadSeen.MinWidth = 68;
            this.colLeadSeen.Name = "colLeadSeen";
            this.colLeadSeen.OptionsColumn.AllowEdit = false;
            this.colLeadSeen.Width = 260;
            // 
            // colActivitiescol
            // 
            this.colActivitiescol.FieldName = "Activitiescol";
            this.colActivitiescol.MinWidth = 68;
            this.colActivitiescol.Name = "colActivitiescol";
            this.colActivitiescol.OptionsColumn.AllowEdit = false;
            this.colActivitiescol.Width = 260;
            // 
            // colOrg1
            // 
            this.colOrg1.FieldName = "Org";
            this.colOrg1.MinWidth = 40;
            this.colOrg1.Name = "colOrg1";
            this.colOrg1.Visible = true;
            this.colOrg1.VisibleIndex = 2;
            this.colOrg1.Width = 236;
            // 
            // tabGovernance
            // 
            this.tabGovernance.Controls.Add(this.SplitContainerControl2);
            this.tabGovernance.Margin = new System.Windows.Forms.Padding(8);
            this.tabGovernance.Name = "tabGovernance";
            this.tabGovernance.Size = new System.Drawing.Size(1703, 776);
            this.tabGovernance.Text = "Gov";
            // 
            // SplitContainerControl2
            // 
            this.SplitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainerControl2.Location = new System.Drawing.Point(0, 0);
            this.SplitContainerControl2.Margin = new System.Windows.Forms.Padding(8);
            this.SplitContainerControl2.Name = "SplitContainerControl2";
            // 
            // SplitContainerControl2.Panel1
            // 
            this.SplitContainerControl2.Panel1.Controls.Add(this.TreeList1);
            this.SplitContainerControl2.Panel1.Text = "Panel1";
            // 
            // SplitContainerControl2.Panel2
            // 
            this.SplitContainerControl2.Panel2.Controls.Add(this.SplitContainerControl5);
            this.SplitContainerControl2.Panel2.Text = "Panel2";
            this.SplitContainerControl2.Size = new System.Drawing.Size(1703, 776);
            this.SplitContainerControl2.SplitterPosition = 226;
            this.SplitContainerControl2.TabIndex = 0;
            this.SplitContainerControl2.Text = "SplitContainerControl2";
            // 
            // TreeList1
            // 
            this.TreeList1.Appearance.FocusedCell.BackColor = System.Drawing.Color.Navy;
            this.TreeList1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.TreeList1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.TreeList1.Appearance.FocusedCell.Options.UseForeColor = true;
            this.TreeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colSection,
            this.colSort,
            this.colTimestamp4,
            this.colImage,
            this.colType1,
            this.colItemRef,
            this.colFixed1,
            this.colID13,
            this.colCompleted});
            this.TreeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeList1.FixedLineWidth = 6;
            treeListFormatRule1.ApplyToRow = true;
            treeListFormatRule1.Column = this.colCompleted;
            treeListFormatRule1.Name = "Format0";
            formatConditionRuleValue6.Appearance.Options.UseFont = true;
            formatConditionRuleValue6.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue6.Value1 = true;
            treeListFormatRule1.Rule = formatConditionRuleValue6;
            this.TreeList1.FormatRules.Add(treeListFormatRule1);
            this.TreeList1.HorzScrollStep = 8;
            this.TreeList1.ImageIndexFieldName = "Image";
            this.TreeList1.Location = new System.Drawing.Point(0, 0);
            this.TreeList1.LookAndFeel.SkinName = "Office 2016 Colorful";
            this.TreeList1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.TreeList1.Margin = new System.Windows.Forms.Padding(8);
            this.TreeList1.MinWidth = 60;
            this.TreeList1.Name = "TreeList1";
            this.TreeList1.OptionsBehavior.PopulateServiceColumns = true;
            this.TreeList1.OptionsDragAndDrop.DragNodesMode = DevExpress.XtraTreeList.DragNodesMode.Multiple;
            this.TreeList1.OptionsDragAndDrop.DropNodesMode = DevExpress.XtraTreeList.DropNodesMode.Standard;
            this.TreeList1.OptionsLayout.RemoveOldColumns = true;
            this.TreeList1.OptionsLayout.StoreAllOptions = true;
            this.TreeList1.OptionsLayout.StoreAppearance = true;
            this.TreeList1.OptionsSelection.MultiSelect = true;
            this.TreeList1.OptionsView.ShowColumns = false;
            this.TreeList1.OptionsView.ShowHorzLines = false;
            this.TreeList1.OptionsView.ShowIndicator = false;
            this.TreeList1.OptionsView.ShowVertLines = false;
            this.TreeList1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.RepositoryItemTextEdit4});
            this.TreeList1.SelectImageList = this.imgGov;
            this.TreeList1.Size = new System.Drawing.Size(226, 776);
            this.TreeList1.TabIndex = 0;
            this.TreeList1.ToolTipController = this.ttTree;
            this.TreeList1.TreeLevelWidth = 36;
            this.TreeList1.CompareNodeValues += new DevExpress.XtraTreeList.CompareNodeValuesEventHandler(this.TreeList1_CompareNodeValues);
            this.TreeList1.BeforeDragNode += new DevExpress.XtraTreeList.BeforeDragNodeEventHandler(this.TreeList1_BeforeDragNode);
            this.TreeList1.AfterExpand += new DevExpress.XtraTreeList.NodeEventHandler(this.TreeList1_AfterExpand);
            this.TreeList1.AfterCollapse += new DevExpress.XtraTreeList.NodeEventHandler(this.TreeList1_AfterCollapse);
            this.TreeList1.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.TreeList1_FocusedNodeChanged);
            this.TreeList1.PopupMenuShowing += new DevExpress.XtraTreeList.PopupMenuShowingEventHandler(this.TreeList1_PopupMenuShowing);
            this.TreeList1.CellValueChanged += new DevExpress.XtraTreeList.CellValueChangedEventHandler(this.TreeList1_CellValueChanged);
            this.TreeList1.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.TreeList1_ShowingEditor);
            this.TreeList1.DragObjectStart += new DevExpress.XtraTreeList.DragObjectStartEventHandler(this.TreeList1_DragObjectStart);
            this.TreeList1.DragDrop += new System.Windows.Forms.DragEventHandler(this.TreeList1_DragDrop);
            this.TreeList1.DragOver += new System.Windows.Forms.DragEventHandler(this.TreeList1_DragOver);
            this.TreeList1.DoubleClick += new System.EventHandler(this.TreeList1_DoubleClick);
            this.TreeList1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TreeList1_KeyDown);
            this.TreeList1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TreeList1_MouseDown);
            this.TreeList1.MouseLeave += new System.EventHandler(this.TreeList1_MouseLeave);
            this.TreeList1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TreeList1_MouseMove);
            this.TreeList1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TreeList1_MouseUp);
            // 
            // colSection
            // 
            this.colSection.ColumnEdit = this.RepositoryItemTextEdit4;
            this.colSection.FieldName = "Section";
            this.colSection.MinWidth = 372;
            this.colSection.Name = "colSection";
            this.colSection.OptionsColumn.AllowSort = false;
            this.colSection.Visible = true;
            this.colSection.VisibleIndex = 0;
            this.colSection.Width = 372;
            // 
            // colSort
            // 
            this.colSort.FieldName = "Sort";
            this.colSort.MinWidth = 68;
            this.colSort.Name = "colSort";
            this.colSort.OptionsColumn.AllowSort = false;
            this.colSort.SortMode = DevExpress.XtraGrid.ColumnSortMode.Value;
            this.colSort.SortOrder = System.Windows.Forms.SortOrder.Ascending;
            this.colSort.Width = 92;
            // 
            // colTimestamp4
            // 
            this.colTimestamp4.FieldName = "Timestamp";
            this.colTimestamp4.MinWidth = 68;
            this.colTimestamp4.Name = "colTimestamp4";
            this.colTimestamp4.OptionsColumn.AllowSort = false;
            this.colTimestamp4.Width = 92;
            // 
            // colImage
            // 
            this.colImage.FieldName = "Image";
            this.colImage.MinWidth = 68;
            this.colImage.Name = "colImage";
            this.colImage.OptionsColumn.AllowSort = false;
            this.colImage.Width = 96;
            // 
            // colType1
            // 
            this.colType1.FieldName = "Type";
            this.colType1.MinWidth = 68;
            this.colType1.Name = "colType1";
            this.colType1.OptionsColumn.AllowSort = false;
            this.colType1.Width = 96;
            // 
            // colItemRef
            // 
            this.colItemRef.FieldName = "ItemRef";
            this.colItemRef.MinWidth = 68;
            this.colItemRef.Name = "colItemRef";
            this.colItemRef.OptionsColumn.AllowSort = false;
            this.colItemRef.Width = 96;
            // 
            // colFixed1
            // 
            this.colFixed1.FieldName = "Fixed";
            this.colFixed1.MinWidth = 68;
            this.colFixed1.Name = "colFixed1";
            this.colFixed1.OptionsColumn.AllowSort = false;
            this.colFixed1.Width = 224;
            // 
            // colID13
            // 
            this.colID13.FieldName = "ID";
            this.colID13.MinWidth = 68;
            this.colID13.Name = "colID13";
            this.colID13.OptionsColumn.AllowSort = false;
            this.colID13.Width = 224;
            // 
            // SplitContainerControl5
            // 
            this.SplitContainerControl5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainerControl5.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.SplitContainerControl5.Horizontal = false;
            this.SplitContainerControl5.IsSplitterFixed = true;
            this.SplitContainerControl5.Location = new System.Drawing.Point(0, 0);
            this.SplitContainerControl5.Margin = new System.Windows.Forms.Padding(8);
            this.SplitContainerControl5.Name = "SplitContainerControl5";
            // 
            // SplitContainerControl5.Panel1
            // 
            this.SplitContainerControl5.Panel1.Controls.Add(this.GovStandardsGridControl);
            this.SplitContainerControl5.Panel1.Text = "Panel1";
            // 
            // SplitContainerControl5.Panel2
            // 
            this.SplitContainerControl5.Panel2.Controls.Add(this.txtGovInfo);
            this.SplitContainerControl5.Panel2.Text = "Panel2";
            this.SplitContainerControl5.Size = new System.Drawing.Size(1461, 776);
            this.SplitContainerControl5.SplitterPosition = 122;
            this.SplitContainerControl5.TabIndex = 1;
            this.SplitContainerControl5.Text = "SplitContainerControl5";
            // 
            // GovStandardsGridControl
            // 
            this.GovStandardsGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GovStandardsGridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(8);
            this.GovStandardsGridControl.Location = new System.Drawing.Point(0, 0);
            this.GovStandardsGridControl.MainView = this.GovGrid;
            this.GovStandardsGridControl.Margin = new System.Windows.Forms.Padding(8);
            this.GovStandardsGridControl.MenuManager = this.RibbonControl1;
            this.GovStandardsGridControl.Name = "GovStandardsGridControl";
            this.GovStandardsGridControl.Size = new System.Drawing.Size(1461, 638);
            this.GovStandardsGridControl.TabIndex = 0;
            this.GovStandardsGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GovGrid});
            this.GovStandardsGridControl.DragLeave += new System.EventHandler(this.GovStandardsGridControl_DragLeave);
            this.GovStandardsGridControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GovStandardsGridControl_MouseDown);
            this.GovStandardsGridControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GovStandardsGridControl_MouseMove);
            // 
            // GovGrid
            // 
            this.GovGrid.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colParent,
            this.GridColumn31,
            this.colReviewDate1,
            this.colBody,
            this.colScope,
            this.colReference,
            this.colStatement,
            this.colTheme,
            this.colPercent,
            this.colType2,
            this.colStatus2,
            this.GridColumn15,
            this.colPath2,
            this.colIncluded,
            this.colID14,
            this.colKocked,
            this.colResponsible});
            this.GovGrid.DetailHeight = 1130;
            gridFormatRule8.Column = this.colPercent;
            gridFormatRule8.ColumnApplyTo = this.colPercent;
            gridFormatRule8.Name = "Format0";
            formatConditionRuleDataBar1.AutomaticType = DevExpress.XtraEditors.FormatConditionAutomaticType.ZeroBased;
            formatConditionRuleDataBar1.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            formatConditionRuleDataBar1.MaximumType = DevExpress.XtraEditors.FormatConditionValueType.Number;
            formatConditionRuleDataBar1.MinimumType = DevExpress.XtraEditors.FormatConditionValueType.Number;
            formatConditionRuleDataBar1.PredefinedName = "Blue";
            gridFormatRule8.Rule = formatConditionRuleDataBar1;
            gridFormatRule9.ApplyToRow = true;
            gridFormatRule9.Column = this.colStatus2;
            gridFormatRule9.Name = "Format1";
            formatConditionRuleValue7.Appearance.Options.UseFont = true;
            formatConditionRuleValue7.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue7.Value1 = "Not Applicable";
            gridFormatRule9.Rule = formatConditionRuleValue7;
            this.GovGrid.FormatRules.Add(gridFormatRule8);
            this.GovGrid.FormatRules.Add(gridFormatRule9);
            this.GovGrid.GridControl = this.GovStandardsGridControl;
            this.GovGrid.GroupCount = 2;
            this.GovGrid.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "ID", null, "{0}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Average, "Percent", null, "Percent: AVG {0:0.}%", "Pct")});
            this.GovGrid.Name = "GovGrid";
            this.GovGrid.OptionsDetail.ShowEmbeddedDetailIndent = DevExpress.Utils.DefaultBoolean.False;
            this.GovGrid.OptionsMenu.ShowConditionalFormattingItem = true;
            this.GovGrid.OptionsSelection.EnableAppearanceHotTrackedRow = DevExpress.Utils.DefaultBoolean.True;
            this.GovGrid.OptionsView.EnableAppearanceOddRow = true;
            this.GovGrid.OptionsView.RowAutoHeight = true;
            this.GovGrid.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.GovGrid.OptionsView.ShowFooter = true;
            this.GovGrid.OptionsView.ShowIndicator = false;
            this.GovGrid.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.GovGrid.RowHeight = 22;
            this.GovGrid.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colType2, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colScope, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colReference, DevExpress.Data.ColumnSortOrder.Descending)});
            this.GovGrid.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.GovGrid_RowCellClick);
            this.GovGrid.CustomDrawFooterCell += new DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventHandler(this.GovGrid_CustomDrawFooterCell);
            this.GovGrid.CustomDrawGroupRow += new DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventHandler(this.GovGrid_CustomDrawGroupRow);
            this.GovGrid.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.GovGrid_PopupMenuShowing);
            this.GovGrid.CustomDrawEmptyForeground += new DevExpress.XtraGrid.Views.Base.CustomDrawEventHandler(this.GovGrid_CustomDrawEmptyForeground);
            this.GovGrid.ColumnFilterChanged += new System.EventHandler(this.MultiGrid_ColumnFilterChanged);
            this.GovGrid.ShowFilterPopupDate += new DevExpress.XtraGrid.Views.Grid.FilterPopupDateEventHandler(this.ClinicalGridView_ShowFilterPopupDate);
            this.GovGrid.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.GovGrid_CustomUnboundColumnData);
            this.GovGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GovGrid_KeyDown);
            this.GovGrid.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseClickGrid);
            this.GovGrid.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GovGrid_MouseMove);
            this.GovGrid.MouseLeave += new System.EventHandler(this.GovGrid_MouseLeave);
            // 
            // colParent
            // 
            this.colParent.Caption = "Parent";
            this.colParent.FieldName = "colParent";
            this.colParent.MinWidth = 60;
            this.colParent.Name = "colParent";
            this.colParent.OptionsColumn.AllowEdit = false;
            this.colParent.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colParent.Visible = true;
            this.colParent.VisibleIndex = 4;
            this.colParent.Width = 224;
            // 
            // GridColumn31
            // 
            this.GridColumn31.Caption = "Section";
            this.GridColumn31.FieldName = "GridColumn31";
            this.GridColumn31.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.GridColumn31.MinWidth = 68;
            this.GridColumn31.Name = "GridColumn31";
            this.GridColumn31.OptionsColumn.AllowEdit = false;
            this.GridColumn31.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.True;
            this.GridColumn31.SortMode = DevExpress.XtraGrid.ColumnSortMode.DisplayText;
            this.GridColumn31.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.GridColumn31.Visible = true;
            this.GridColumn31.VisibleIndex = 5;
            this.GridColumn31.Width = 120;
            // 
            // colReviewDate1
            // 
            this.colReviewDate1.Caption = "Review Date";
            this.colReviewDate1.FieldName = "ReviewDate";
            this.colReviewDate1.MaxWidth = 296;
            this.colReviewDate1.MinWidth = 68;
            this.colReviewDate1.Name = "colReviewDate1";
            this.colReviewDate1.OptionsColumn.AllowEdit = false;
            this.colReviewDate1.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.DateSmart;
            this.colReviewDate1.OptionsFilter.PopupExcelFilterEnumFilters = DevExpress.XtraGrid.Columns.ExcelFilterEnumFilters.EqualityFilters;
            this.colReviewDate1.Visible = true;
            this.colReviewDate1.VisibleIndex = 7;
            this.colReviewDate1.Width = 236;
            // 
            // colBody
            // 
            this.colBody.DisplayFormat.FormatString = "p0";
            this.colBody.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBody.FieldName = "Body";
            this.colBody.MaxWidth = 260;
            this.colBody.MinWidth = 68;
            this.colBody.Name = "colBody";
            this.colBody.OptionsColumn.AllowEdit = false;
            this.colBody.Visible = true;
            this.colBody.VisibleIndex = 0;
            this.colBody.Width = 210;
            // 
            // colScope
            // 
            this.colScope.FieldName = "Scope";
            this.colScope.MaxWidth = 260;
            this.colScope.MinWidth = 68;
            this.colScope.Name = "colScope";
            this.colScope.OptionsColumn.AllowEdit = false;
            this.colScope.Visible = true;
            this.colScope.VisibleIndex = 1;
            this.colScope.Width = 210;
            // 
            // colReference
            // 
            this.colReference.AppearanceCell.Options.UseTextOptions = true;
            this.colReference.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colReference.AppearanceHeader.Options.UseTextOptions = true;
            this.colReference.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colReference.ColumnEdit = this.RepositoryItemHyperLinkEdit6;
            this.colReference.FieldName = "Reference";
            this.colReference.MaxWidth = 210;
            this.colReference.MinWidth = 68;
            this.colReference.Name = "colReference";
            this.colReference.OptionsColumn.AllowEdit = false;
            this.colReference.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Reference", "{0}")});
            this.colReference.Visible = true;
            this.colReference.VisibleIndex = 1;
            this.colReference.Width = 164;
            // 
            // colStatement
            // 
            this.colStatement.FieldName = "Statement";
            this.colStatement.MinWidth = 68;
            this.colStatement.Name = "colStatement";
            this.colStatement.OptionsColumn.AllowEdit = false;
            this.colStatement.Visible = true;
            this.colStatement.VisibleIndex = 3;
            this.colStatement.Width = 1752;
            // 
            // colTheme
            // 
            this.colTheme.FieldName = "Theme";
            this.colTheme.MaxWidth = 524;
            this.colTheme.MinWidth = 68;
            this.colTheme.Name = "colTheme";
            this.colTheme.OptionsColumn.AllowEdit = false;
            this.colTheme.Visible = true;
            this.colTheme.VisibleIndex = 2;
            this.colTheme.Width = 408;
            // 
            // colType2
            // 
            this.colType2.ColumnEdit = this.RepositoryItemImageComboBox2;
            this.colType2.FieldName = "Type";
            this.colType2.MaxWidth = 350;
            this.colType2.MinWidth = 68;
            this.colType2.Name = "colType2";
            this.colType2.OptionsColumn.AllowEdit = false;
            this.colType2.Visible = true;
            this.colType2.VisibleIndex = 0;
            this.colType2.Width = 246;
            // 
            // GridColumn15
            // 
            this.GridColumn15.Caption = "File";
            this.GridColumn15.ColumnEdit = this.RepositoryItemCheckEdit12;
            this.GridColumn15.FieldName = "GridColumn15";
            this.GridColumn15.MaxWidth = 122;
            this.GridColumn15.MinWidth = 68;
            this.GridColumn15.Name = "GridColumn15";
            this.GridColumn15.OptionsColumn.AllowEdit = false;
            this.GridColumn15.UnboundExpression = "Iif([Path] Is Null, False, True)";
            this.GridColumn15.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            this.GridColumn15.Visible = true;
            this.GridColumn15.VisibleIndex = 11;
            this.GridColumn15.Width = 102;
            // 
            // colPath2
            // 
            this.colPath2.Caption = "File";
            this.colPath2.ColumnEdit = this.RepositoryItemCheckEdit12;
            this.colPath2.FieldName = "Path";
            this.colPath2.MaxWidth = 122;
            this.colPath2.MinWidth = 68;
            this.colPath2.Name = "colPath2";
            this.colPath2.OptionsColumn.AllowEdit = false;
            this.colPath2.Width = 122;
            // 
            // colIncluded
            // 
            this.colIncluded.ColumnEdit = this.RepositoryItemCheckEdit13;
            this.colIncluded.FieldName = "Included";
            this.colIncluded.MaxWidth = 122;
            this.colIncluded.MinWidth = 68;
            this.colIncluded.Name = "colIncluded";
            this.colIncluded.OptionsColumn.AllowEdit = false;
            this.colIncluded.Visible = true;
            this.colIncluded.VisibleIndex = 10;
            this.colIncluded.Width = 102;
            // 
            // colID14
            // 
            this.colID14.FieldName = "ID";
            this.colID14.MinWidth = 60;
            this.colID14.Name = "colID14";
            this.colID14.OptionsColumn.AllowEdit = false;
            this.colID14.Width = 216;
            // 
            // colKocked
            // 
            this.colKocked.Caption = "Locked";
            this.colKocked.ColumnEdit = this.RepositoryItemCheckEdit16;
            this.colKocked.FieldName = "Kocked";
            this.colKocked.MinWidth = 60;
            this.colKocked.Name = "colKocked";
            this.colKocked.OptionsColumn.AllowEdit = false;
            this.colKocked.Visible = true;
            this.colKocked.VisibleIndex = 8;
            this.colKocked.Width = 96;
            // 
            // colResponsible
            // 
            this.colResponsible.FieldName = "Responsible";
            this.colResponsible.MinWidth = 60;
            this.colResponsible.Name = "colResponsible";
            this.colResponsible.OptionsColumn.AllowEdit = false;
            this.colResponsible.Visible = true;
            this.colResponsible.VisibleIndex = 12;
            this.colResponsible.Width = 224;
            // 
            // txtGovInfo
            // 
            this.txtGovInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGovInfo.Location = new System.Drawing.Point(0, 0);
            this.txtGovInfo.Margin = new System.Windows.Forms.Padding(8);
            this.txtGovInfo.MenuManager = this.RibbonControl1;
            this.txtGovInfo.Name = "txtGovInfo";
            this.txtGovInfo.Properties.ReadOnly = true;
            this.txtGovInfo.Size = new System.Drawing.Size(1461, 122);
            this.txtGovInfo.TabIndex = 0;
            // 
            // tabNotes
            // 
            this.tabNotes.Controls.Add(this.BusinessNotesGridControl);
            this.tabNotes.Margin = new System.Windows.Forms.Padding(8);
            this.tabNotes.Name = "tabNotes";
            this.tabNotes.Size = new System.Drawing.Size(1703, 776);
            this.tabNotes.Text = "Notes";
            // 
            // BusinessNotesGridControl
            // 
            this.BusinessNotesGridControl.DataSource = this.BusinessNotesBindingSource;
            this.BusinessNotesGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BusinessNotesGridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(8);
            this.BusinessNotesGridControl.Location = new System.Drawing.Point(0, 0);
            this.BusinessNotesGridControl.MainView = this.TileView1;
            this.BusinessNotesGridControl.Margin = new System.Windows.Forms.Padding(8);
            this.BusinessNotesGridControl.MenuManager = this.RibbonControl1;
            this.BusinessNotesGridControl.Name = "BusinessNotesGridControl";
            this.BusinessNotesGridControl.Size = new System.Drawing.Size(1703, 776);
            this.BusinessNotesGridControl.TabIndex = 0;
            this.BusinessNotesGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.TileView1});
            // 
            // TileView1
            // 
            this.TileView1.Appearance.ItemNormal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.TileView1.Appearance.ItemNormal.ForeColor = System.Drawing.Color.Black;
            this.TileView1.Appearance.ItemNormal.Options.UseBackColor = true;
            this.TileView1.Appearance.ItemNormal.Options.UseForeColor = true;
            this.TileView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID5,
            this.colTitle,
            this.colBody1,
            this.colCreatedBy2,
            this.colCreatedTime,
            this.colModified});
            this.TileView1.DetailHeight = 1130;
            this.TileView1.GridControl = this.BusinessNotesGridControl;
            this.TileView1.Name = "TileView1";
            this.TileView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colCreatedTime, DevExpress.Data.ColumnSortOrder.Descending)});
            this.TileView1.TileColumns.Add(tableColumnDefinition1);
            this.TileView1.TileColumns.Add(tableColumnDefinition2);
            this.TileView1.TileColumns.Add(tableColumnDefinition3);
            this.TileView1.TileRows.Add(tableRowDefinition1);
            this.TileView1.TileRows.Add(tableRowDefinition2);
            this.TileView1.TileRows.Add(tableRowDefinition3);
            tableSpan1.ColumnSpan = 3;
            this.TileView1.TileSpans.Add(tableSpan1);
            tileViewItemElement1.Appearance.Normal.Options.UseFont = true;
            tileViewItemElement1.Column = this.colTitle;
            tileViewItemElement1.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement1.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            tileViewItemElement1.Text = "colTitle";
            tileViewItemElement1.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement2.Column = this.colCreatedBy2;
            tileViewItemElement2.ColumnIndex = 2;
            tileViewItemElement2.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement2.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            tileViewItemElement2.RowIndex = 2;
            tileViewItemElement2.Text = "colCreatedBy2";
            tileViewItemElement2.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement3.Column = this.colID5;
            tileViewItemElement3.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement3.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            tileViewItemElement3.RowIndex = 1;
            tileViewItemElement3.Text = "colID5";
            tileViewItemElement3.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement3.TextVisible = false;
            this.TileView1.TileTemplate.Add(tileViewItemElement1);
            this.TileView1.TileTemplate.Add(tileViewItemElement2);
            this.TileView1.TileTemplate.Add(tileViewItemElement3);
            this.TileView1.ItemClick += new DevExpress.XtraGrid.Views.Tile.TileViewItemClickEventHandler(this.TileView1_ItemClick);
            // 
            // colBody1
            // 
            this.colBody1.FieldName = "Body";
            this.colBody1.MinWidth = 68;
            this.colBody1.Name = "colBody1";
            this.colBody1.OptionsColumn.AllowEdit = false;
            this.colBody1.Visible = true;
            this.colBody1.VisibleIndex = 2;
            this.colBody1.Width = 260;
            // 
            // colModified
            // 
            this.colModified.FieldName = "Modified";
            this.colModified.MaxWidth = 260;
            this.colModified.MinWidth = 68;
            this.colModified.Name = "colModified";
            this.colModified.OptionsColumn.AllowEdit = false;
            this.colModified.Visible = true;
            this.colModified.VisibleIndex = 5;
            this.colModified.Width = 260;
            // 
            // tabTasks
            // 
            this.tabTasks.Controls.Add(this.TasksGridControl);
            this.tabTasks.Margin = new System.Windows.Forms.Padding(8);
            this.tabTasks.Name = "tabTasks";
            this.tabTasks.Size = new System.Drawing.Size(1703, 776);
            this.tabTasks.Text = "Tasks";
            // 
            // TasksGridControl
            // 
            this.TasksGridControl.DataSource = this.SystemTasksBindingSource;
            this.TasksGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TasksGridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(8);
            this.TasksGridControl.Location = new System.Drawing.Point(0, 0);
            this.TasksGridControl.MainView = this.GridView3;
            this.TasksGridControl.Margin = new System.Windows.Forms.Padding(8);
            this.TasksGridControl.MenuManager = this.RibbonControl1;
            this.TasksGridControl.Name = "TasksGridControl";
            this.TasksGridControl.Size = new System.Drawing.Size(1703, 776);
            this.TasksGridControl.TabIndex = 0;
            this.TasksGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridView3});
            // 
            // GridView3
            // 
            this.GridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID6,
            this.colName,
            this.colPID,
            this.colDue1,
            this.colFreq,
            this.colPriority1,
            this.colNotes1,
            this.colPolicy,
            this.colTimeStamp5,
            this.colEstTime,
            this.colOwnerType,
            this.colOwnerID,
            this.colStartDate,
            this.colSystemTaskscol,
            this.colAutoTask,
            this.colProcName,
            this.colFrmName,
            this.colCmdName,
            this.colActionType});
            this.GridView3.DetailHeight = 1130;
            this.GridView3.GridControl = this.TasksGridControl;
            this.GridView3.Name = "GridView3";
            this.GridView3.OptionsView.EnableAppearanceOddRow = true;
            this.GridView3.OptionsView.ShowIndicator = false;
            this.GridView3.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.GridView3.RowHeight = 22;
            this.GridView3.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.GridView3_RowCellClick);
            this.GridView3.CustomDrawEmptyForeground += new DevExpress.XtraGrid.Views.Base.CustomDrawEventHandler(this.GridView3_CustomDrawEmptyForeground);
            // 
            // colID6
            // 
            this.colID6.AppearanceCell.Options.UseTextOptions = true;
            this.colID6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colID6.AppearanceHeader.Options.UseTextOptions = true;
            this.colID6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colID6.ColumnEdit = this.RepositoryItemHyperLinkEdit7;
            this.colID6.FieldName = "ID";
            this.colID6.MaxWidth = 210;
            this.colID6.MinWidth = 68;
            this.colID6.Name = "colID6";
            this.colID6.OptionsColumn.AllowEdit = false;
            this.colID6.Visible = true;
            this.colID6.VisibleIndex = 0;
            this.colID6.Width = 100;
            // 
            // colName
            // 
            this.colName.FieldName = "Name";
            this.colName.MinWidth = 68;
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowEdit = false;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 133;
            // 
            // colPID
            // 
            this.colPID.ColumnEdit = this.RepositoryItemLookUpEdit5;
            this.colPID.FieldName = "PID";
            this.colPID.MinWidth = 68;
            this.colPID.Name = "colPID";
            this.colPID.OptionsColumn.AllowEdit = false;
            this.colPID.Visible = true;
            this.colPID.VisibleIndex = 2;
            this.colPID.Width = 133;
            // 
            // colDue1
            // 
            this.colDue1.FieldName = "Due";
            this.colDue1.MinWidth = 68;
            this.colDue1.Name = "colDue1";
            this.colDue1.OptionsColumn.AllowEdit = false;
            this.colDue1.Visible = true;
            this.colDue1.VisibleIndex = 3;
            this.colDue1.Width = 133;
            // 
            // colFreq
            // 
            this.colFreq.FieldName = "Freq";
            this.colFreq.MinWidth = 68;
            this.colFreq.Name = "colFreq";
            this.colFreq.OptionsColumn.AllowEdit = false;
            this.colFreq.Visible = true;
            this.colFreq.VisibleIndex = 4;
            this.colFreq.Width = 133;
            // 
            // colPriority1
            // 
            this.colPriority1.FieldName = "Priority";
            this.colPriority1.MinWidth = 68;
            this.colPriority1.Name = "colPriority1";
            this.colPriority1.OptionsColumn.AllowEdit = false;
            this.colPriority1.Visible = true;
            this.colPriority1.VisibleIndex = 5;
            this.colPriority1.Width = 133;
            // 
            // colNotes1
            // 
            this.colNotes1.ColumnEdit = this.RepositoryItemRichTextEdit2;
            this.colNotes1.FieldName = "Notes";
            this.colNotes1.MinWidth = 68;
            this.colNotes1.Name = "colNotes1";
            this.colNotes1.OptionsColumn.AllowEdit = false;
            this.colNotes1.Visible = true;
            this.colNotes1.VisibleIndex = 6;
            this.colNotes1.Width = 133;
            // 
            // colPolicy
            // 
            this.colPolicy.FieldName = "Policy";
            this.colPolicy.MinWidth = 68;
            this.colPolicy.Name = "colPolicy";
            this.colPolicy.OptionsColumn.AllowEdit = false;
            this.colPolicy.Visible = true;
            this.colPolicy.VisibleIndex = 7;
            this.colPolicy.Width = 133;
            // 
            // colTimeStamp5
            // 
            this.colTimeStamp5.FieldName = "TimeStamp";
            this.colTimeStamp5.MinWidth = 68;
            this.colTimeStamp5.Name = "colTimeStamp5";
            this.colTimeStamp5.OptionsColumn.AllowEdit = false;
            this.colTimeStamp5.Visible = true;
            this.colTimeStamp5.VisibleIndex = 8;
            this.colTimeStamp5.Width = 133;
            // 
            // colEstTime
            // 
            this.colEstTime.FieldName = "EstTime";
            this.colEstTime.MinWidth = 68;
            this.colEstTime.Name = "colEstTime";
            this.colEstTime.OptionsColumn.AllowEdit = false;
            this.colEstTime.Visible = true;
            this.colEstTime.VisibleIndex = 9;
            this.colEstTime.Width = 133;
            // 
            // colOwnerType
            // 
            this.colOwnerType.FieldName = "OwnerType";
            this.colOwnerType.MinWidth = 68;
            this.colOwnerType.Name = "colOwnerType";
            this.colOwnerType.OptionsColumn.AllowEdit = false;
            this.colOwnerType.Visible = true;
            this.colOwnerType.VisibleIndex = 10;
            this.colOwnerType.Width = 133;
            // 
            // colOwnerID
            // 
            this.colOwnerID.FieldName = "OwnerID";
            this.colOwnerID.MinWidth = 68;
            this.colOwnerID.Name = "colOwnerID";
            this.colOwnerID.OptionsColumn.AllowEdit = false;
            this.colOwnerID.Width = 260;
            // 
            // colStartDate
            // 
            this.colStartDate.FieldName = "StartDate";
            this.colStartDate.MinWidth = 68;
            this.colStartDate.Name = "colStartDate";
            this.colStartDate.OptionsColumn.AllowEdit = false;
            this.colStartDate.Visible = true;
            this.colStartDate.VisibleIndex = 11;
            this.colStartDate.Width = 133;
            // 
            // colSystemTaskscol
            // 
            this.colSystemTaskscol.FieldName = "SystemTaskscol";
            this.colSystemTaskscol.MinWidth = 68;
            this.colSystemTaskscol.Name = "colSystemTaskscol";
            this.colSystemTaskscol.OptionsColumn.AllowEdit = false;
            this.colSystemTaskscol.Width = 260;
            // 
            // colAutoTask
            // 
            this.colAutoTask.FieldName = "AutoTask";
            this.colAutoTask.MinWidth = 68;
            this.colAutoTask.Name = "colAutoTask";
            this.colAutoTask.OptionsColumn.AllowEdit = false;
            this.colAutoTask.Visible = true;
            this.colAutoTask.VisibleIndex = 12;
            this.colAutoTask.Width = 144;
            // 
            // colProcName
            // 
            this.colProcName.FieldName = "ProcName";
            this.colProcName.MinWidth = 68;
            this.colProcName.Name = "colProcName";
            this.colProcName.OptionsColumn.AllowEdit = false;
            this.colProcName.Width = 260;
            // 
            // colFrmName
            // 
            this.colFrmName.FieldName = "FrmName";
            this.colFrmName.MinWidth = 68;
            this.colFrmName.Name = "colFrmName";
            this.colFrmName.OptionsColumn.AllowEdit = false;
            this.colFrmName.Width = 260;
            // 
            // colCmdName
            // 
            this.colCmdName.FieldName = "CmdName";
            this.colCmdName.MinWidth = 68;
            this.colCmdName.Name = "colCmdName";
            this.colCmdName.OptionsColumn.AllowEdit = false;
            this.colCmdName.Width = 260;
            // 
            // colActionType
            // 
            this.colActionType.FieldName = "ActionType";
            this.colActionType.MinWidth = 68;
            this.colActionType.Name = "colActionType";
            this.colActionType.OptionsColumn.AllowEdit = false;
            this.colActionType.Width = 260;
            // 
            // tabRisk
            // 
            this.tabRisk.Controls.Add(this.LayoutControl1);
            this.tabRisk.Margin = new System.Windows.Forms.Padding(8);
            this.tabRisk.Name = "tabRisk";
            this.tabRisk.Size = new System.Drawing.Size(1703, 776);
            this.tabRisk.Text = "Risk";
            // 
            // LayoutControl1
            // 
            this.LayoutControl1.Controls.Add(this.ChartControl2);
            this.LayoutControl1.Controls.Add(this.ChartControl3);
            this.LayoutControl1.Controls.Add(this.ChartControl1);
            this.LayoutControl1.Controls.Add(this.RisksGridControl);
            this.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.LayoutControl1.Margin = new System.Windows.Forms.Padding(0);
            this.LayoutControl1.Name = "LayoutControl1";
            this.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1297, 653, 650, 400);
            this.LayoutControl1.Root = this.LayoutControlGroup1;
            this.LayoutControl1.Size = new System.Drawing.Size(1703, 776);
            this.LayoutControl1.TabIndex = 1;
            this.LayoutControl1.Text = "LayoutControl1";
            // 
            // ChartControl2
            // 
            this.ChartControl2.CrosshairOptions.CommonLabelPosition = crosshairFreePosition1;
            this.ChartControl2.CrosshairOptions.ShowArgumentLabels = true;
            this.ChartControl2.CrosshairOptions.ShowValueLabels = true;
            this.ChartControl2.CrosshairOptions.ShowValueLine = true;
            this.ChartControl2.DataSource = this.RisksBindingSource;
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            this.ChartControl2.Diagram = xyDiagram1;
            this.ChartControl2.Legend.Name = "Default Legend";
            this.ChartControl2.Location = new System.Drawing.Point(579, 16);
            this.ChartControl2.Margin = new System.Windows.Forms.Padding(8);
            this.ChartControl2.Name = "ChartControl2";
            this.ChartControl2.Padding.Bottom = 0;
            this.ChartControl2.Padding.Left = 0;
            this.ChartControl2.Padding.Right = 0;
            this.ChartControl2.Padding.Top = 0;
            this.ChartControl2.SelectionMode = DevExpress.XtraCharts.ElementSelectionMode.Multiple;
            this.ChartControl2.SeriesDataMember = "RiskClass";
            this.ChartControl2.SeriesSelectionMode = DevExpress.XtraCharts.SeriesSelectionMode.Point;
            this.ChartControl2.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.ChartControl2.SeriesTemplate.ArgumentDataMember = "BusinessArea";
            this.ChartControl2.SeriesTemplate.DateTimeSummaryOptions.SummaryFunction = "COUNT()";
            this.ChartControl2.SeriesTemplate.NumericSummaryOptions.SummaryFunction = "COUNT()";
            this.ChartControl2.SeriesTemplate.QualitativeSummaryOptions.SummaryFunction = "COUNT()";
            this.ChartControl2.SeriesTemplate.SeriesDataMember = "RiskClass";
            this.ChartControl2.SeriesTemplate.ValueDataMembersSerializable = "ID";
            this.ChartControl2.SeriesTemplate.View = stackedBarSeriesView1;
            this.ChartControl2.Size = new System.Drawing.Size(527, 160);
            this.ChartControl2.TabIndex = 7;
            this.ChartControl2.BoundDataChanged += new DevExpress.XtraCharts.BoundDataChangedEventHandler(this.ChartControl2_BoundDataChanged_1);
            // 
            // ChartControl3
            // 
            this.ChartControl3.DataSource = this.RisksBindingSource;
            this.ChartControl3.Legend.Name = "Default Legend";
            this.ChartControl3.Location = new System.Drawing.Point(1112, 16);
            this.ChartControl3.Margin = new System.Windows.Forms.Padding(8);
            this.ChartControl3.Name = "ChartControl3";
            this.ChartControl3.PaletteName = "Risks1";
            this.ChartControl3.PaletteRepository.Add("Risks1", new DevExpress.XtraCharts.Palette("Risks1", DevExpress.XtraCharts.PaletteScaleMode.Repeat, new DevExpress.XtraCharts.PaletteEntry[] {
                new DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.Red, System.Drawing.Color.Red),
                new DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.Yellow, System.Drawing.Color.Yellow),
                new DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.Orange, System.Drawing.Color.Orange),
                new DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.LightGreen, System.Drawing.Color.LightGreen)}));
            series1.ArgumentDataMember = "RiskClass";
            series1.DateTimeSummaryOptions.SummaryFunction = "COUNT()";
            series1.LegendTextPattern = "{S}";
            series1.Name = "Series 1";
            series1.NumericSummaryOptions.SummaryFunction = "COUNT()";
            series1.QualitativeSummaryOptions.SummaryFunction = "COUNT()";
            series1.ValueDataMembersSerializable = "ID";
            series1.View = pieSeriesView1;
            this.ChartControl3.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
            this.ChartControl3.Size = new System.Drawing.Size(575, 160);
            this.ChartControl3.TabIndex = 6;
            this.ChartControl3.BoundDataChanged += new DevExpress.XtraCharts.BoundDataChangedEventHandler(this.ChartControl3_BoundDataChanged);
            // 
            // ChartControl1
            // 
            this.ChartControl1.DataSource = this.RisksBindingSource;
            this.ChartControl1.Legend.Name = "Default Legend";
            this.ChartControl1.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
            this.ChartControl1.Location = new System.Drawing.Point(16, 16);
            this.ChartControl1.Margin = new System.Windows.Forms.Padding(8);
            this.ChartControl1.Name = "ChartControl1";
            series2.ArgumentDataMember = "BusinessArea";
            series2.DateTimeSummaryOptions.SummaryFunction = "COUNT()";
            pieSeriesLabel1.Border.Visibility = DevExpress.Utils.DefaultBoolean.False;
            pieSeriesLabel1.TextPattern = "{V}";
            series2.Label = pieSeriesLabel1;
            series2.LegendTextPattern = "{A}";
            series2.Name = "Business Area";
            series2.NumericSummaryOptions.SummaryFunction = "COUNT()";
            series2.QualitativeSummaryOptions.SummaryFunction = "COUNT()";
            series2.ValueDataMembersSerializable = "ID";
            pieSeriesView2.Titles.AddRange(new DevExpress.XtraCharts.SeriesTitle[] {
            seriesTitle1});
            series2.View = pieSeriesView2;
            this.ChartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series2};
            this.ChartControl1.Size = new System.Drawing.Size(557, 160);
            this.ChartControl1.TabIndex = 4;
            // 
            // RisksGridControl
            // 
            this.RisksGridControl.DataSource = this.RisksBindingSource;
            this.RisksGridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(8);
            this.RisksGridControl.Location = new System.Drawing.Point(16, 182);
            this.RisksGridControl.MainView = this.GridView11;
            this.RisksGridControl.Margin = new System.Windows.Forms.Padding(8);
            this.RisksGridControl.MenuManager = this.RibbonControl1;
            this.RisksGridControl.Name = "RisksGridControl";
            this.RisksGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.RepositoryItemLookUpEdit4});
            this.RisksGridControl.Size = new System.Drawing.Size(1671, 578);
            this.RisksGridControl.TabIndex = 0;
            this.RisksGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridView11});
            // 
            // GridView11
            // 
            this.GridView11.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID8,
            this.colRisk,
            this.colLikelihood,
            this.colImpact,
            this.colRiskClass,
            this.colRiskScore,
            this.colRiskOwner,
            this.colPriority2,
            this.colStatus4,
            this.colBusinessArea,
            this.colAffectedParty,
            this.colIdentified,
            this.colMitigationLevel,
            this.colReviewDate,
            this.colTimeStamp6,
            this.colCategory1});
            this.GridView11.DetailHeight = 1130;
            gridFormatRule10.Name = "Format0";
            formatConditionIconSet1.CategoryName = "Symbols";
            formatConditionIconSetIcon1.PredefinedName = "Flags3_1.png";
            formatConditionIconSetIcon1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            formatConditionIconSetIcon1.ValueComparison = DevExpress.XtraEditors.FormatConditionComparisonType.GreaterOrEqual;
            formatConditionIconSetIcon2.PredefinedName = "Flags3_2.png";
            formatConditionIconSetIcon2.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            formatConditionIconSetIcon2.ValueComparison = DevExpress.XtraEditors.FormatConditionComparisonType.GreaterOrEqual;
            formatConditionIconSetIcon3.PredefinedName = "Flags3_3.png";
            formatConditionIconSetIcon3.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            formatConditionIconSetIcon3.ValueComparison = DevExpress.XtraEditors.FormatConditionComparisonType.GreaterOrEqual;
            formatConditionIconSet1.Icons.Add(formatConditionIconSetIcon1);
            formatConditionIconSet1.Icons.Add(formatConditionIconSetIcon2);
            formatConditionIconSet1.Icons.Add(formatConditionIconSetIcon3);
            formatConditionIconSet1.Name = "Flags5";
            formatConditionRuleIconSet1.IconSet = formatConditionIconSet1;
            gridFormatRule10.Rule = formatConditionRuleIconSet1;
            this.GridView11.FormatRules.Add(gridFormatRule10);
            this.GridView11.GridControl = this.RisksGridControl;
            this.GridView11.GroupCount = 2;
            this.GridView11.Name = "GridView11";
            this.GridView11.OptionsView.EnableAppearanceOddRow = true;
            this.GridView11.OptionsView.ShowIndicator = false;
            this.GridView11.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.GridView11.RowHeight = 22;
            this.GridView11.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colBusinessArea, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colCategory1, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colRiskScore, DevExpress.Data.ColumnSortOrder.Descending)});
            this.GridView11.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.GridView11_RowCellClick);
            this.GridView11.CustomDrawEmptyForeground += new DevExpress.XtraGrid.Views.Base.CustomDrawEventHandler(this.GridView11_CustomDrawEmptyForeground);
            // 
            // colID8
            // 
            this.colID8.AppearanceCell.Options.UseTextOptions = true;
            this.colID8.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colID8.AppearanceHeader.Options.UseTextOptions = true;
            this.colID8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colID8.ColumnEdit = this.RepositoryItemHyperLinkEdit9;
            this.colID8.FieldName = "ID";
            this.colID8.MaxWidth = 210;
            this.colID8.MinWidth = 68;
            this.colID8.Name = "colID8";
            this.colID8.OptionsColumn.AllowEdit = false;
            this.colID8.Visible = true;
            this.colID8.VisibleIndex = 0;
            this.colID8.Width = 100;
            // 
            // colRisk
            // 
            this.colRisk.FieldName = "Risk";
            this.colRisk.MinWidth = 68;
            this.colRisk.Name = "colRisk";
            this.colRisk.OptionsColumn.AllowEdit = false;
            this.colRisk.Visible = true;
            this.colRisk.VisibleIndex = 1;
            this.colRisk.Width = 131;
            // 
            // colLikelihood
            // 
            this.colLikelihood.AppearanceCell.Options.UseTextOptions = true;
            this.colLikelihood.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLikelihood.AppearanceHeader.Options.UseTextOptions = true;
            this.colLikelihood.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLikelihood.FieldName = "Likelihood";
            this.colLikelihood.MaxWidth = 210;
            this.colLikelihood.MinWidth = 68;
            this.colLikelihood.Name = "colLikelihood";
            this.colLikelihood.OptionsColumn.AllowEdit = false;
            this.colLikelihood.Visible = true;
            this.colLikelihood.VisibleIndex = 5;
            this.colLikelihood.Width = 105;
            // 
            // colImpact
            // 
            this.colImpact.AppearanceCell.Options.UseTextOptions = true;
            this.colImpact.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colImpact.AppearanceHeader.Options.UseTextOptions = true;
            this.colImpact.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colImpact.FieldName = "Impact";
            this.colImpact.MaxWidth = 210;
            this.colImpact.MinWidth = 68;
            this.colImpact.Name = "colImpact";
            this.colImpact.OptionsColumn.AllowEdit = false;
            this.colImpact.Visible = true;
            this.colImpact.VisibleIndex = 6;
            this.colImpact.Width = 105;
            // 
            // colRiskClass
            // 
            this.colRiskClass.FieldName = "RiskClass";
            this.colRiskClass.MaxWidth = 278;
            this.colRiskClass.MinWidth = 68;
            this.colRiskClass.Name = "colRiskClass";
            this.colRiskClass.OptionsColumn.AllowEdit = false;
            this.colRiskClass.Visible = true;
            this.colRiskClass.VisibleIndex = 8;
            this.colRiskClass.Width = 131;
            // 
            // colRiskScore
            // 
            this.colRiskScore.AppearanceCell.Options.UseTextOptions = true;
            this.colRiskScore.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRiskScore.AppearanceHeader.Options.UseTextOptions = true;
            this.colRiskScore.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRiskScore.FieldName = "RiskScore";
            this.colRiskScore.MaxWidth = 210;
            this.colRiskScore.MinWidth = 68;
            this.colRiskScore.Name = "colRiskScore";
            this.colRiskScore.OptionsColumn.AllowEdit = false;
            this.colRiskScore.Visible = true;
            this.colRiskScore.VisibleIndex = 7;
            this.colRiskScore.Width = 105;
            // 
            // colRiskOwner
            // 
            this.colRiskOwner.FieldName = "RiskOwner";
            this.colRiskOwner.MaxWidth = 278;
            this.colRiskOwner.MinWidth = 68;
            this.colRiskOwner.Name = "colRiskOwner";
            this.colRiskOwner.OptionsColumn.AllowEdit = false;
            this.colRiskOwner.Visible = true;
            this.colRiskOwner.VisibleIndex = 10;
            this.colRiskOwner.Width = 131;
            // 
            // colPriority2
            // 
            this.colPriority2.ColumnEdit = this.RepositoryItemImageComboBox3;
            this.colPriority2.FieldName = "Priority";
            this.colPriority2.MaxWidth = 278;
            this.colPriority2.MinWidth = 68;
            this.colPriority2.Name = "colPriority2";
            this.colPriority2.OptionsColumn.AllowEdit = false;
            this.colPriority2.Visible = true;
            this.colPriority2.VisibleIndex = 3;
            this.colPriority2.Width = 131;
            // 
            // colStatus4
            // 
            this.colStatus4.FieldName = "Status";
            this.colStatus4.MaxWidth = 246;
            this.colStatus4.MinWidth = 68;
            this.colStatus4.Name = "colStatus4";
            this.colStatus4.OptionsColumn.AllowEdit = false;
            this.colStatus4.Visible = true;
            this.colStatus4.VisibleIndex = 11;
            this.colStatus4.Width = 124;
            // 
            // colBusinessArea
            // 
            this.colBusinessArea.FieldName = "BusinessArea";
            this.colBusinessArea.MaxWidth = 350;
            this.colBusinessArea.MinWidth = 68;
            this.colBusinessArea.Name = "colBusinessArea";
            this.colBusinessArea.OptionsColumn.AllowEdit = false;
            this.colBusinessArea.Visible = true;
            this.colBusinessArea.VisibleIndex = 2;
            this.colBusinessArea.Width = 260;
            // 
            // colAffectedParty
            // 
            this.colAffectedParty.FieldName = "AffectedParty";
            this.colAffectedParty.MaxWidth = 350;
            this.colAffectedParty.MinWidth = 68;
            this.colAffectedParty.Name = "colAffectedParty";
            this.colAffectedParty.OptionsColumn.AllowEdit = false;
            this.colAffectedParty.Visible = true;
            this.colAffectedParty.VisibleIndex = 2;
            this.colAffectedParty.Width = 131;
            // 
            // colIdentified
            // 
            this.colIdentified.DisplayFormat.FormatString = "MMM-yy";
            this.colIdentified.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colIdentified.FieldName = "Identified";
            this.colIdentified.MaxWidth = 210;
            this.colIdentified.MinWidth = 68;
            this.colIdentified.Name = "colIdentified";
            this.colIdentified.OptionsColumn.AllowEdit = false;
            this.colIdentified.Visible = true;
            this.colIdentified.VisibleIndex = 4;
            this.colIdentified.Width = 105;
            // 
            // colMitigationLevel
            // 
            this.colMitigationLevel.FieldName = "MitigationLevel";
            this.colMitigationLevel.MaxWidth = 278;
            this.colMitigationLevel.MinWidth = 68;
            this.colMitigationLevel.Name = "colMitigationLevel";
            this.colMitigationLevel.OptionsColumn.AllowEdit = false;
            this.colMitigationLevel.Visible = true;
            this.colMitigationLevel.VisibleIndex = 9;
            this.colMitigationLevel.Width = 131;
            // 
            // colReviewDate
            // 
            this.colReviewDate.Caption = "Review";
            this.colReviewDate.DisplayFormat.FormatString = "MMM-yy";
            this.colReviewDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colReviewDate.FieldName = "ReviewDate";
            this.colReviewDate.MaxWidth = 210;
            this.colReviewDate.MinWidth = 68;
            this.colReviewDate.Name = "colReviewDate";
            this.colReviewDate.OptionsColumn.AllowEdit = false;
            this.colReviewDate.Visible = true;
            this.colReviewDate.VisibleIndex = 12;
            this.colReviewDate.Width = 105;
            // 
            // colTimeStamp6
            // 
            this.colTimeStamp6.FieldName = "TimeStamp";
            this.colTimeStamp6.MaxWidth = 260;
            this.colTimeStamp6.MinWidth = 68;
            this.colTimeStamp6.Name = "colTimeStamp6";
            this.colTimeStamp6.OptionsColumn.AllowEdit = false;
            this.colTimeStamp6.Visible = true;
            this.colTimeStamp6.VisibleIndex = 13;
            this.colTimeStamp6.Width = 148;
            // 
            // colCategory1
            // 
            this.colCategory1.FieldName = "Category";
            this.colCategory1.MinWidth = 60;
            this.colCategory1.Name = "colCategory1";
            this.colCategory1.OptionsColumn.AllowEdit = false;
            this.colCategory1.Visible = true;
            this.colCategory1.VisibleIndex = 14;
            this.colCategory1.Width = 224;
            // 
            // RepositoryItemLookUpEdit4
            // 
            this.RepositoryItemLookUpEdit4.AutoHeight = false;
            this.RepositoryItemLookUpEdit4.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RepositoryItemLookUpEdit4.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "Text", 96, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.RepositoryItemLookUpEdit4.DataSource = this.TaskPriorityBindingSource;
            this.RepositoryItemLookUpEdit4.DisplayMember = "Text";
            this.RepositoryItemLookUpEdit4.Name = "RepositoryItemLookUpEdit4";
            this.RepositoryItemLookUpEdit4.NullText = "";
            this.RepositoryItemLookUpEdit4.ValueMember = "ID";
            // 
            // LayoutControlGroup1
            // 
            this.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.LayoutControlGroup1.GroupBordersVisible = false;
            this.LayoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.LayoutControlItem1,
            this.LayoutControlItem2,
            this.LayoutControlItem4,
            this.LayoutControlItem3});
            this.LayoutControlGroup1.Name = "Root";
            this.LayoutControlGroup1.Size = new System.Drawing.Size(1703, 776);
            this.LayoutControlGroup1.TextVisible = false;
            // 
            // LayoutControlItem1
            // 
            this.LayoutControlItem1.Control = this.RisksGridControl;
            this.LayoutControlItem1.Location = new System.Drawing.Point(0, 166);
            this.LayoutControlItem1.Name = "LayoutControlItem1";
            this.LayoutControlItem1.Size = new System.Drawing.Size(1677, 584);
            this.LayoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.SupportHorzAlignment;
            this.LayoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.LayoutControlItem1.TextVisible = false;
            // 
            // LayoutControlItem2
            // 
            this.LayoutControlItem2.Control = this.ChartControl1;
            this.LayoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.LayoutControlItem2.Name = "LayoutControlItem2";
            this.LayoutControlItem2.Size = new System.Drawing.Size(563, 166);
            this.LayoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.SupportHorzAlignment;
            this.LayoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.LayoutControlItem2.TextVisible = false;
            // 
            // LayoutControlItem4
            // 
            this.LayoutControlItem4.Control = this.ChartControl3;
            this.LayoutControlItem4.Location = new System.Drawing.Point(1096, 0);
            this.LayoutControlItem4.Name = "LayoutControlItem4";
            this.LayoutControlItem4.Size = new System.Drawing.Size(581, 166);
            this.LayoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.SupportHorzAlignment;
            this.LayoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.LayoutControlItem4.TextVisible = false;
            // 
            // LayoutControlItem3
            // 
            this.LayoutControlItem3.Control = this.ChartControl2;
            this.LayoutControlItem3.Location = new System.Drawing.Point(563, 0);
            this.LayoutControlItem3.Name = "LayoutControlItem3";
            this.LayoutControlItem3.Size = new System.Drawing.Size(533, 166);
            this.LayoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.SupportHorzAlignment;
            this.LayoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.LayoutControlItem3.TextVisible = false;
            // 
            // tabDocuments
            // 
            this.tabDocuments.Controls.Add(this.DocumentsGridControl);
            this.tabDocuments.Margin = new System.Windows.Forms.Padding(8);
            this.tabDocuments.Name = "tabDocuments";
            this.tabDocuments.Size = new System.Drawing.Size(1703, 776);
            this.tabDocuments.Text = "Docs";
            // 
            // DocumentsGridControl
            // 
            this.DocumentsGridControl.DataSource = this.DocumentsBindingSource;
            this.DocumentsGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DocumentsGridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(8);
            this.DocumentsGridControl.Location = new System.Drawing.Point(0, 0);
            this.DocumentsGridControl.MainView = this.GridView10;
            this.DocumentsGridControl.Margin = new System.Windows.Forms.Padding(8);
            this.DocumentsGridControl.MenuManager = this.RibbonControl1;
            this.DocumentsGridControl.Name = "DocumentsGridControl";
            this.DocumentsGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.RepositoryItemCheckEdit6});
            this.DocumentsGridControl.Size = new System.Drawing.Size(1703, 776);
            this.DocumentsGridControl.TabIndex = 0;
            this.DocumentsGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridView10});
            // 
            // GridView10
            // 
            this.GridView10.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colViewDocument,
            this.GridColumn29,
            this.colID7,
            this.colPath3,
            this.colCategory,
            this.colCreatedBy3,
            this.colDescription,
            this.colExtRef,
            this.colOwner,
            this.colDocDate,
            this.colStatus3,
            this.colAuthor,
            this.colType3,
            this.colSender,
            this.colFileStatus});
            this.GridView10.DetailHeight = 1130;
            this.GridView10.GridControl = this.DocumentsGridControl;
            this.GridView10.Name = "GridView10";
            this.GridView10.OptionsSelection.EnableAppearanceHotTrackedRow = DevExpress.Utils.DefaultBoolean.True;
            this.GridView10.OptionsView.EnableAppearanceOddRow = true;
            this.GridView10.OptionsView.ShowIndicator = false;
            this.GridView10.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.GridView10.RowHeight = 22;
            this.GridView10.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colDocDate, DevExpress.Data.ColumnSortOrder.Descending)});
            this.GridView10.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.GridView10_RowCellClick);
            this.GridView10.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.GridView10_CustomDrawCell);
            this.GridView10.CustomDrawEmptyForeground += new DevExpress.XtraGrid.Views.Base.CustomDrawEventHandler(this.GridView10_CustomDrawEmptyForeground);
            this.GridView10.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.GridView10_FocusedRowChanged);
            // 
            // colViewDocument
            // 
            this.colViewDocument.Caption = "View";
            this.colViewDocument.ColumnEdit = this.RepositoryItemCheckEdit6;
            this.colViewDocument.FieldName = "GridColumn2";
            this.colViewDocument.MaxWidth = 150;
            this.colViewDocument.MinWidth = 60;
            this.colViewDocument.Name = "colViewDocument";
            this.colViewDocument.OptionsColumn.AllowEdit = false;
            this.colViewDocument.UnboundExpression = "Not IsNullOrEmpty([Path])";
            this.colViewDocument.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            this.colViewDocument.Visible = true;
            this.colViewDocument.VisibleIndex = 9;
            this.colViewDocument.Width = 62;
            // 
            // RepositoryItemCheckEdit6
            // 
            this.RepositoryItemCheckEdit6.AutoHeight = false;
            this.RepositoryItemCheckEdit6.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.Custom;
            this.RepositoryItemCheckEdit6.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.RepositoryItemCheckEdit6.Name = "RepositoryItemCheckEdit6";
            // 
            // GridColumn29
            // 
            this.GridColumn29.MinWidth = 60;
            this.GridColumn29.Name = "GridColumn29";
            this.GridColumn29.OptionsColumn.AllowEdit = false;
            this.GridColumn29.Width = 224;
            // 
            // colID7
            // 
            this.colID7.AppearanceCell.Options.UseTextOptions = true;
            this.colID7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colID7.AppearanceHeader.Options.UseTextOptions = true;
            this.colID7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colID7.ColumnEdit = this.RepositoryItemHyperLinkEdit9;
            this.colID7.FieldName = "ID";
            this.colID7.MaxWidth = 210;
            this.colID7.MinWidth = 68;
            this.colID7.Name = "colID7";
            this.colID7.OptionsColumn.AllowEdit = false;
            this.colID7.Visible = true;
            this.colID7.VisibleIndex = 0;
            this.colID7.Width = 100;
            // 
            // colPath3
            // 
            this.colPath3.FieldName = "Path";
            this.colPath3.MinWidth = 68;
            this.colPath3.Name = "colPath3";
            this.colPath3.OptionsColumn.AllowEdit = false;
            this.colPath3.Width = 260;
            // 
            // colCategory
            // 
            this.colCategory.FieldName = "Category";
            this.colCategory.MinWidth = 68;
            this.colCategory.Name = "colCategory";
            this.colCategory.OptionsColumn.AllowEdit = false;
            this.colCategory.Visible = true;
            this.colCategory.VisibleIndex = 6;
            this.colCategory.Width = 153;
            // 
            // colCreatedBy3
            // 
            this.colCreatedBy3.FieldName = "CreatedBy";
            this.colCreatedBy3.MaxWidth = 296;
            this.colCreatedBy3.MinWidth = 68;
            this.colCreatedBy3.Name = "colCreatedBy3";
            this.colCreatedBy3.OptionsColumn.AllowEdit = false;
            this.colCreatedBy3.Visible = true;
            this.colCreatedBy3.VisibleIndex = 8;
            this.colCreatedBy3.Width = 99;
            // 
            // colDescription
            // 
            this.colDescription.FieldName = "Description";
            this.colDescription.MinWidth = 68;
            this.colDescription.Name = "colDescription";
            this.colDescription.OptionsColumn.AllowEdit = false;
            this.colDescription.Width = 314;
            // 
            // colExtRef
            // 
            this.colExtRef.FieldName = "ExtRef";
            this.colExtRef.MinWidth = 68;
            this.colExtRef.Name = "colExtRef";
            this.colExtRef.OptionsColumn.AllowEdit = false;
            this.colExtRef.Visible = true;
            this.colExtRef.VisibleIndex = 5;
            this.colExtRef.Width = 331;
            // 
            // colOwner
            // 
            this.colOwner.FieldName = "Owner";
            this.colOwner.MinWidth = 68;
            this.colOwner.Name = "colOwner";
            this.colOwner.OptionsColumn.AllowEdit = false;
            this.colOwner.Visible = true;
            this.colOwner.VisibleIndex = 7;
            this.colOwner.Width = 126;
            // 
            // colDocDate
            // 
            this.colDocDate.DisplayFormat.FormatString = "MMM-yy";
            this.colDocDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colDocDate.FieldName = "DocDate";
            this.colDocDate.MaxWidth = 260;
            this.colDocDate.MinWidth = 68;
            this.colDocDate.Name = "colDocDate";
            this.colDocDate.OptionsColumn.AllowEdit = false;
            this.colDocDate.Visible = true;
            this.colDocDate.VisibleIndex = 2;
            this.colDocDate.Width = 89;
            // 
            // colStatus3
            // 
            this.colStatus3.AppearanceCell.Options.UseTextOptions = true;
            this.colStatus3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStatus3.FieldName = "Status";
            this.colStatus3.MinWidth = 68;
            this.colStatus3.Name = "colStatus3";
            this.colStatus3.OptionsColumn.AllowEdit = false;
            this.colStatus3.OptionsColumn.FixedWidth = true;
            this.colStatus3.Visible = true;
            this.colStatus3.VisibleIndex = 10;
            this.colStatus3.Width = 300;
            // 
            // colAuthor
            // 
            this.colAuthor.FieldName = "Author";
            this.colAuthor.MinWidth = 68;
            this.colAuthor.Name = "colAuthor";
            this.colAuthor.OptionsColumn.AllowEdit = false;
            this.colAuthor.Visible = true;
            this.colAuthor.VisibleIndex = 4;
            this.colAuthor.Width = 126;
            // 
            // colType3
            // 
            this.colType3.FieldName = "Type";
            this.colType3.MinWidth = 68;
            this.colType3.Name = "colType3";
            this.colType3.OptionsColumn.AllowEdit = false;
            this.colType3.Visible = true;
            this.colType3.VisibleIndex = 1;
            this.colType3.Width = 195;
            // 
            // colSender
            // 
            this.colSender.FieldName = "Sender";
            this.colSender.MinWidth = 68;
            this.colSender.Name = "colSender";
            this.colSender.OptionsColumn.AllowEdit = false;
            this.colSender.Visible = true;
            this.colSender.VisibleIndex = 3;
            this.colSender.Width = 126;
            // 
            // colFileStatus
            // 
            this.colFileStatus.FieldName = "FileStatus";
            this.colFileStatus.MinWidth = 68;
            this.colFileStatus.Name = "colFileStatus";
            this.colFileStatus.OptionsColumn.AllowEdit = false;
            this.colFileStatus.Width = 294;
            // 
            // tabAudit
            // 
            this.tabAudit.Controls.Add(this.AuditGridControl);
            this.tabAudit.Margin = new System.Windows.Forms.Padding(8);
            this.tabAudit.Name = "tabAudit";
            this.tabAudit.Size = new System.Drawing.Size(1703, 776);
            this.tabAudit.Text = "Audit";
            // 
            // AuditGridControl
            // 
            this.AuditGridControl.DataSource = this.AuditBindingSource;
            this.AuditGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AuditGridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(8);
            this.AuditGridControl.Location = new System.Drawing.Point(0, 0);
            this.AuditGridControl.MainView = this.grdAudit;
            this.AuditGridControl.Margin = new System.Windows.Forms.Padding(8);
            this.AuditGridControl.MenuManager = this.RibbonControl1;
            this.AuditGridControl.Name = "AuditGridControl";
            this.AuditGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.RepositoryItemRatingControl1});
            this.AuditGridControl.Size = new System.Drawing.Size(1703, 776);
            this.AuditGridControl.TabIndex = 0;
            this.AuditGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdAudit});
            // 
            // grdAudit
            // 
            this.grdAudit.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID10,
            this.colType5,
            this.colAuditor,
            this.colDate,
            this.colVerifier,
            this.colPolicy1,
            this.colScope1,
            this.GridColumn28,
            this.colFilePath,
            this.colTimeStamp8,
            this.colStatus5,
            this.colNotes2,
            this.GridColumn25,
            this.colResult});
            this.grdAudit.DetailHeight = 1130;
            this.grdAudit.GridControl = this.AuditGridControl;
            this.grdAudit.GroupCount = 1;
            this.grdAudit.Name = "grdAudit";
            this.grdAudit.OptionsView.EnableAppearanceOddRow = true;
            this.grdAudit.OptionsView.ShowGroupedColumns = true;
            this.grdAudit.OptionsView.ShowIndicator = false;
            this.grdAudit.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grdAudit.RowHeight = 22;
            this.grdAudit.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colDate, DevExpress.Data.ColumnSortOrder.Descending)});
            this.grdAudit.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.GridView1_RowCellClick_1);
            this.grdAudit.CustomDrawEmptyForeground += new DevExpress.XtraGrid.Views.Base.CustomDrawEventHandler(this.grdAudit_CustomDrawEmptyForeground);
            // 
            // colID10
            // 
            this.colID10.AppearanceCell.Options.UseTextOptions = true;
            this.colID10.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colID10.AppearanceHeader.Options.UseTextOptions = true;
            this.colID10.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colID10.ColumnEdit = this.RepositoryItemHyperLinkEdit13;
            this.colID10.FieldName = "ID";
            this.colID10.MaxWidth = 210;
            this.colID10.MinWidth = 68;
            this.colID10.Name = "colID10";
            this.colID10.OptionsColumn.AllowEdit = false;
            this.colID10.Visible = true;
            this.colID10.VisibleIndex = 0;
            this.colID10.Width = 100;
            // 
            // colType5
            // 
            this.colType5.FieldName = "Type";
            this.colType5.MinWidth = 68;
            this.colType5.Name = "colType5";
            this.colType5.OptionsColumn.AllowEdit = false;
            this.colType5.Visible = true;
            this.colType5.VisibleIndex = 1;
            this.colType5.Width = 164;
            // 
            // colAuditor
            // 
            this.colAuditor.FieldName = "Auditor";
            this.colAuditor.MaxWidth = 420;
            this.colAuditor.MinWidth = 68;
            this.colAuditor.Name = "colAuditor";
            this.colAuditor.OptionsColumn.AllowEdit = false;
            this.colAuditor.Visible = true;
            this.colAuditor.VisibleIndex = 4;
            this.colAuditor.Width = 148;
            // 
            // colDate
            // 
            this.colDate.DisplayFormat.FormatString = "MMM yy";
            this.colDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colDate.FieldName = "Date";
            this.colDate.GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.DateRange;
            this.colDate.MaxWidth = 210;
            this.colDate.MinWidth = 68;
            this.colDate.Name = "colDate";
            this.colDate.OptionsColumn.AllowEdit = false;
            this.colDate.Visible = true;
            this.colDate.VisibleIndex = 5;
            this.colDate.Width = 73;
            // 
            // colVerifier
            // 
            this.colVerifier.FieldName = "Verifier";
            this.colVerifier.MaxWidth = 420;
            this.colVerifier.MinWidth = 68;
            this.colVerifier.Name = "colVerifier";
            this.colVerifier.OptionsColumn.AllowEdit = false;
            this.colVerifier.Visible = true;
            this.colVerifier.VisibleIndex = 6;
            this.colVerifier.Width = 148;
            // 
            // colPolicy1
            // 
            this.colPolicy1.FieldName = "Policy";
            this.colPolicy1.MaxWidth = 420;
            this.colPolicy1.MinWidth = 68;
            this.colPolicy1.Name = "colPolicy1";
            this.colPolicy1.OptionsColumn.AllowEdit = false;
            this.colPolicy1.Visible = true;
            this.colPolicy1.VisibleIndex = 7;
            this.colPolicy1.Width = 148;
            // 
            // colScope1
            // 
            this.colScope1.FieldName = "Scope";
            this.colScope1.MinWidth = 68;
            this.colScope1.Name = "colScope1";
            this.colScope1.OptionsColumn.AllowEdit = false;
            this.colScope1.Visible = true;
            this.colScope1.VisibleIndex = 3;
            this.colScope1.Width = 531;
            // 
            // GridColumn28
            // 
            this.GridColumn28.Caption = " ";
            this.GridColumn28.ColumnEdit = this.RepositoryItemCheckEdit16;
            this.GridColumn28.FieldName = "GridColumn28";
            this.GridColumn28.MaxWidth = 122;
            this.GridColumn28.MinWidth = 68;
            this.GridColumn28.Name = "GridColumn28";
            this.GridColumn28.OptionsColumn.AllowEdit = false;
            this.GridColumn28.UnboundExpression = "Iif([FilePath] Is Null, False, True)";
            this.GridColumn28.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            this.GridColumn28.Visible = true;
            this.GridColumn28.VisibleIndex = 10;
            this.GridColumn28.Width = 68;
            // 
            // colFilePath
            // 
            this.colFilePath.FieldName = "FilePath";
            this.colFilePath.MinWidth = 68;
            this.colFilePath.Name = "colFilePath";
            this.colFilePath.OptionsColumn.AllowEdit = false;
            this.colFilePath.Width = 260;
            // 
            // colTimeStamp8
            // 
            this.colTimeStamp8.FieldName = "TimeStamp";
            this.colTimeStamp8.MaxWidth = 246;
            this.colTimeStamp8.MinWidth = 68;
            this.colTimeStamp8.Name = "colTimeStamp8";
            this.colTimeStamp8.OptionsColumn.AllowEdit = false;
            this.colTimeStamp8.Visible = true;
            this.colTimeStamp8.VisibleIndex = 11;
            this.colTimeStamp8.Width = 70;
            // 
            // colStatus5
            // 
            this.colStatus5.FieldName = "Status";
            this.colStatus5.MaxWidth = 296;
            this.colStatus5.MinWidth = 68;
            this.colStatus5.Name = "colStatus5";
            this.colStatus5.OptionsColumn.AllowEdit = false;
            this.colStatus5.Visible = true;
            this.colStatus5.VisibleIndex = 8;
            this.colStatus5.Width = 105;
            // 
            // colNotes2
            // 
            this.colNotes2.FieldName = "Notes";
            this.colNotes2.MinWidth = 68;
            this.colNotes2.Name = "colNotes2";
            this.colNotes2.OptionsColumn.AllowEdit = false;
            this.colNotes2.Width = 260;
            // 
            // GridColumn25
            // 
            this.GridColumn25.AppearanceCell.Options.UseTextOptions = true;
            this.GridColumn25.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.GridColumn25.AppearanceHeader.Options.UseTextOptions = true;
            this.GridColumn25.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.GridColumn25.Caption = "Sample";
            this.GridColumn25.FieldName = "SampleSize";
            this.GridColumn25.MaxWidth = 174;
            this.GridColumn25.MinWidth = 68;
            this.GridColumn25.Name = "GridColumn25";
            this.GridColumn25.OptionsColumn.AllowEdit = false;
            this.GridColumn25.Visible = true;
            this.GridColumn25.VisibleIndex = 2;
            this.GridColumn25.Width = 68;
            // 
            // colResult
            // 
            this.colResult.ColumnEdit = this.RepositoryItemRatingControl1;
            this.colResult.FieldName = "Result";
            this.colResult.MinWidth = 60;
            this.colResult.Name = "colResult";
            this.colResult.Visible = true;
            this.colResult.VisibleIndex = 9;
            this.colResult.Width = 84;
            // 
            // RepositoryItemRatingControl1
            // 
            this.RepositoryItemRatingControl1.FillPrecision = DevExpress.XtraEditors.RatingItemFillPrecision.Half;
            this.RepositoryItemRatingControl1.FirstItemValue = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.RepositoryItemRatingControl1.Name = "RepositoryItemRatingControl1";
            this.RepositoryItemRatingControl1.ValueInterval = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // tabFlagged
            // 
            this.tabFlagged.Controls.Add(this.LayoutControl2);
            this.tabFlagged.Margin = new System.Windows.Forms.Padding(8);
            this.tabFlagged.Name = "tabFlagged";
            this.tabFlagged.Size = new System.Drawing.Size(1703, 776);
            this.tabFlagged.Text = "Flagged";
            // 
            // LayoutControl2
            // 
            this.LayoutControl2.Controls.Add(this.ChartControl6);
            this.LayoutControl2.Controls.Add(this.ChartControl5);
            this.LayoutControl2.Controls.Add(this.ChartControl4);
            this.LayoutControl2.Controls.Add(this.GridControl1);
            this.LayoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutControl2.Location = new System.Drawing.Point(0, 0);
            this.LayoutControl2.Margin = new System.Windows.Forms.Padding(8);
            this.LayoutControl2.Name = "LayoutControl2";
            this.LayoutControl2.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1297, 653, 650, 400);
            this.LayoutControl2.Root = this.LayoutControlGroup2;
            this.LayoutControl2.Size = new System.Drawing.Size(1703, 776);
            this.LayoutControl2.TabIndex = 1;
            this.LayoutControl2.Text = "LayoutControl2";
            // 
            // ChartControl6
            // 
            this.ChartControl6.AnimationStartMode = DevExpress.XtraCharts.ChartAnimationMode.OnLoad;
            this.ChartControl6.DataSource = this.trainDataSet.TrainingReturns;
            this.ChartControl6.Legend.Name = "Default Legend";
            this.ChartControl6.Location = new System.Drawing.Point(1359, 16);
            this.ChartControl6.Margin = new System.Windows.Forms.Padding(8);
            this.ChartControl6.Name = "ChartControl6";
            series3.ArgumentDataMember = "Status";
            series3.DataSource = this.NCRBindingSource;
            series3.DateTimeSummaryOptions.SummaryFunction = "COUNT()";
            series3.LegendTextPattern = "{A}";
            series3.Name = "Series 1";
            series3.NumericSummaryOptions.SummaryFunction = "COUNT()";
            series3.QualitativeSummaryOptions.SummaryFunction = "COUNT()";
            series3.ValueDataMembersSerializable = "ID";
            series3.View = pieSeriesView3;
            this.ChartControl6.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series3};
            this.ChartControl6.Size = new System.Drawing.Size(328, 277);
            this.ChartControl6.TabIndex = 6;
            // 
            // ChartControl5
            // 
            this.ChartControl5.AnimationStartMode = DevExpress.XtraCharts.ChartAnimationMode.OnLoad;
            this.ChartControl5.DataSource = this.NCRBindingSource;
            xyDiagram2.AxisX.Alignment = DevExpress.XtraCharts.AxisAlignment.Zero;
            xyDiagram2.AxisX.DateTimeScaleOptions.AggregateFunction = DevExpress.XtraCharts.AggregateFunction.Count;
            xyDiagram2.AxisX.DateTimeScaleOptions.AutoGrid = false;
            xyDiagram2.AxisX.DateTimeScaleOptions.GridAlignment = DevExpress.XtraCharts.DateTimeGridAlignment.Quarter;
            xyDiagram2.AxisX.DateTimeScaleOptions.MeasureUnit = DevExpress.XtraCharts.DateTimeMeasureUnit.Quarter;
            xyDiagram2.AxisX.Label.TextPattern = "{A:q}";
            xyDiagram2.AxisX.QualitativeScaleOptions.AggregateFunction = DevExpress.XtraCharts.AggregateFunction.Count;
            xyDiagram2.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram2.AxisY.VisibleInPanesSerializable = "-1";
            this.ChartControl5.Diagram = xyDiagram2;
            this.ChartControl5.Legend.MarkerMode = DevExpress.XtraCharts.LegendMarkerMode.CheckBox;
            this.ChartControl5.Legend.Name = "Default Legend";
            this.ChartControl5.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
            this.ChartControl5.Location = new System.Drawing.Point(646, 16);
            this.ChartControl5.Margin = new System.Windows.Forms.Padding(8);
            this.ChartControl5.Name = "ChartControl5";
            this.ChartControl5.PaletteName = "Palette 1";
            this.ChartControl5.PaletteRepository.Add("Palette 1", new DevExpress.XtraCharts.Palette("Palette 1", DevExpress.XtraCharts.PaletteScaleMode.Repeat, new DevExpress.XtraCharts.PaletteEntry[] {
                new DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255))))), System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))))),
                new DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.Lime, System.Drawing.Color.Lime),
                new DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(113))))), System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(113)))))),
                new DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(133)))), ((int)(((byte)(23))))), System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(133)))), ((int)(((byte)(23)))))),
                new DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.Red, System.Drawing.Color.Red)}));
            this.ChartControl5.SeriesDataMember = "Level";
            this.ChartControl5.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.ChartControl5.SeriesSorting = DevExpress.XtraCharts.SortingMode.Ascending;
            this.ChartControl5.SeriesTemplate.ArgumentDataMember = "ItemDate";
            this.ChartControl5.SeriesTemplate.ArgumentScaleType = DevExpress.XtraCharts.ScaleType.DateTime;
            this.ChartControl5.SeriesTemplate.ColorDataMember = "Level";
            this.ChartControl5.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            seriesKeyColorColorizer1.Keys.Add("A1");
            seriesKeyColorColorizer1.Keys.Add("A2");
            seriesKeyColorColorizer1.Keys.Add("B1");
            seriesKeyColorColorizer1.Keys.Add("B2");
            seriesKeyColorColorizer1.Keys.Add("C");
            seriesKeyColorColorizer1.PaletteName = "Palette 1";
            this.ChartControl5.SeriesTemplate.SeriesColorizer = seriesKeyColorColorizer1;
            this.ChartControl5.SeriesTemplate.SeriesDataMember = "Level";
            this.ChartControl5.SeriesTemplate.SeriesPointsSorting = DevExpress.XtraCharts.SortingMode.Descending;
            this.ChartControl5.SeriesTemplate.ValueDataMembersSerializable = "ID";
            this.ChartControl5.SeriesTemplate.View = stackedBarSeriesView2;
            this.ChartControl5.Size = new System.Drawing.Size(691, 277);
            this.ChartControl5.TabIndex = 5;
            // 
            // ChartControl4
            // 
            this.ChartControl4.AnimationStartMode = DevExpress.XtraCharts.ChartAnimationMode.OnLoad;
            this.ChartControl4.DataSource = this.NCRBindingSource;
            xyDiagram3.AxisX.DateTimeScaleOptions.AggregateFunction = DevExpress.XtraCharts.AggregateFunction.Count;
            xyDiagram3.AxisX.DateTimeScaleOptions.MeasureUnit = DevExpress.XtraCharts.DateTimeMeasureUnit.Quarter;
            xyDiagram3.AxisX.Label.TextPattern = "{A:q}";
            xyDiagram3.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram3.AxisY.VisibleInPanesSerializable = "-1";
            this.ChartControl4.Diagram = xyDiagram3;
            this.ChartControl4.Legend.MarkerMode = DevExpress.XtraCharts.LegendMarkerMode.CheckBox;
            this.ChartControl4.Legend.Name = "Default Legend";
            this.ChartControl4.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
            this.ChartControl4.Location = new System.Drawing.Point(16, 16);
            this.ChartControl4.Margin = new System.Windows.Forms.Padding(8);
            this.ChartControl4.Name = "ChartControl4";
            this.ChartControl4.SeriesDataMember = "Category";
            this.ChartControl4.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.ChartControl4.SeriesTemplate.ArgumentDataMember = "ItemDate";
            stackedBarSeriesLabel1.TextPattern = "{A:q}";
            this.ChartControl4.SeriesTemplate.Label = stackedBarSeriesLabel1;
            this.ChartControl4.SeriesTemplate.SeriesDataMember = "Category";
            this.ChartControl4.SeriesTemplate.ValueDataMembersSerializable = "ID";
            this.ChartControl4.SeriesTemplate.View = stackedBarSeriesView3;
            this.ChartControl4.Size = new System.Drawing.Size(608, 277);
            this.ChartControl4.TabIndex = 4;
            // 
            // GridControl1
            // 
            this.GridControl1.DataSource = this.NCRBindingSource;
            this.GridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(8);
            this.GridControl1.Location = new System.Drawing.Point(16, 315);
            this.GridControl1.MainView = this.grdFlagged;
            this.GridControl1.Margin = new System.Windows.Forms.Padding(8);
            this.GridControl1.MenuManager = this.RibbonControl1;
            this.GridControl1.Name = "GridControl1";
            this.GridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repFlaggedCategory,
            this.RepositoryItemLookUpEdit8});
            this.GridControl1.Size = new System.Drawing.Size(1671, 445);
            this.GridControl1.TabIndex = 0;
            this.GridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdFlagged});
            // 
            // grdFlagged
            // 
            this.grdFlagged.ActiveFilterString = "[Status] = \'Open\'";
            this.grdFlagged.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID12,
            this.colItemID,
            this.colItemType,
            this.colItemPerson,
            this.colRootCause,
            this.colItemDate,
            this.colActionDate,
            this.colStatus6,
            this.colCreated2,
            this.colTimeStamp9,
            this.colLevel,
            this.GridColumn17,
            this.colSource1,
            this.colCategory2,
            this.colNotifiable,
            this.colActionBy});
            this.grdFlagged.DetailHeight = 1130;
            gridFormatRule11.ApplyToRow = true;
            gridFormatRule11.Column = this.colLevel;
            gridFormatRule11.Name = "Format1";
            formatConditionRuleValue8.Appearance.BackColor = System.Drawing.Color.Brown;
            formatConditionRuleValue8.Appearance.ForeColor = System.Drawing.Color.White;
            formatConditionRuleValue8.Appearance.Options.UseBackColor = true;
            formatConditionRuleValue8.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue8.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue8.Value1 = "Level 3";
            gridFormatRule11.Rule = formatConditionRuleValue8;
            gridFormatRule12.ApplyToRow = true;
            gridFormatRule12.Column = this.colLevel;
            gridFormatRule12.Name = "Format2";
            formatConditionRuleValue9.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            formatConditionRuleValue9.Appearance.BackColor2 = System.Drawing.Color.White;
            formatConditionRuleValue9.Appearance.Options.UseBackColor = true;
            formatConditionRuleValue9.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue9.Value1 = "Level 2";
            gridFormatRule12.Rule = formatConditionRuleValue9;
            this.grdFlagged.FormatRules.Add(gridFormatRule11);
            this.grdFlagged.FormatRules.Add(gridFormatRule12);
            this.grdFlagged.GridControl = this.GridControl1;
            this.grdFlagged.GroupCount = 1;
            this.grdFlagged.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "ID", null, "(Report ID: Count={0})")});
            this.grdFlagged.Name = "grdFlagged";
            this.grdFlagged.OptionsView.EnableAppearanceOddRow = true;
            this.grdFlagged.OptionsView.ShowFooter = true;
            this.grdFlagged.OptionsView.ShowGroupedColumns = true;
            this.grdFlagged.OptionsView.ShowIndicator = false;
            this.grdFlagged.RowHeight = 22;
            this.grdFlagged.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colLevel, DevExpress.Data.ColumnSortOrder.Descending)});
            this.grdFlagged.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.grdFlagged_RowCellClick);
            this.grdFlagged.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.grdFlagged_CustomDrawCell);
            // 
            // colID12
            // 
            this.colID12.AppearanceCell.Options.UseTextOptions = true;
            this.colID12.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colID12.AppearanceHeader.Options.UseTextOptions = true;
            this.colID12.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colID12.Caption = "Report ID";
            this.colID12.FieldName = "ID";
            this.colID12.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.colID12.MaxWidth = 210;
            this.colID12.MinWidth = 68;
            this.colID12.Name = "colID12";
            this.colID12.OptionsColumn.AllowEdit = false;
            this.colID12.Visible = true;
            this.colID12.VisibleIndex = 0;
            this.colID12.Width = 100;
            // 
            // colItemID
            // 
            this.colItemID.AppearanceCell.Options.UseTextOptions = true;
            this.colItemID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colItemID.AppearanceHeader.Options.UseTextOptions = true;
            this.colItemID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colItemID.ColumnEdit = this.RepositoryItemHyperLinkEdit18;
            this.colItemID.FieldName = "ItemID";
            this.colItemID.MaxWidth = 210;
            this.colItemID.MinWidth = 68;
            this.colItemID.Name = "colItemID";
            this.colItemID.OptionsColumn.AllowEdit = false;
            this.colItemID.Width = 210;
            // 
            // colItemType
            // 
            this.colItemType.FieldName = "ItemType";
            this.colItemType.MinWidth = 68;
            this.colItemType.Name = "colItemType";
            this.colItemType.OptionsColumn.AllowEdit = false;
            this.colItemType.Width = 860;
            // 
            // colItemPerson
            // 
            this.colItemPerson.ColumnEdit = this.RepositoryItemLookUpEdit8;
            this.colItemPerson.FieldName = "ItemPerson";
            this.colItemPerson.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.colItemPerson.MaxWidth = 420;
            this.colItemPerson.MinWidth = 68;
            this.colItemPerson.Name = "colItemPerson";
            this.colItemPerson.OptionsColumn.AllowEdit = false;
            this.colItemPerson.Visible = true;
            this.colItemPerson.VisibleIndex = 5;
            this.colItemPerson.Width = 124;
            // 
            // RepositoryItemLookUpEdit8
            // 
            this.RepositoryItemLookUpEdit8.AutoHeight = false;
            this.RepositoryItemLookUpEdit8.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RepositoryItemLookUpEdit8.ContextImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.RepositoryItemLookUpEdit8.DataSource = this.PersonnellBindingSource2;
            this.RepositoryItemLookUpEdit8.DisplayMember = "InstructorName";
            this.RepositoryItemLookUpEdit8.Name = "RepositoryItemLookUpEdit8";
            this.RepositoryItemLookUpEdit8.NullText = "[Not Assignedl]";
            this.RepositoryItemLookUpEdit8.ValueMember = "ID";
            // 
            // PersonnellBindingSource2
            // 
            this.PersonnellBindingSource2.DataMember = "Personnell";
            this.PersonnellBindingSource2.DataSource = this.PersonnellDataSet;
            // 
            // colRootCause
            // 
            this.colRootCause.FieldName = "RootCause";
            this.colRootCause.MinWidth = 68;
            this.colRootCause.Name = "colRootCause";
            this.colRootCause.OptionsColumn.AllowEdit = false;
            this.colRootCause.Width = 728;
            // 
            // colItemDate
            // 
            this.colItemDate.DisplayFormat.FormatString = "D";
            this.colItemDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colItemDate.FieldName = "ItemDate";
            this.colItemDate.MaxWidth = 488;
            this.colItemDate.MinWidth = 68;
            this.colItemDate.Name = "colItemDate";
            this.colItemDate.OptionsColumn.AllowEdit = false;
            this.colItemDate.Visible = true;
            this.colItemDate.VisibleIndex = 2;
            this.colItemDate.Width = 185;
            // 
            // colActionDate
            // 
            this.colActionDate.FieldName = "ActionDate";
            this.colActionDate.MaxWidth = 278;
            this.colActionDate.MinWidth = 68;
            this.colActionDate.Name = "colActionDate";
            this.colActionDate.OptionsColumn.AllowEdit = false;
            this.colActionDate.Width = 152;
            // 
            // colCreated2
            // 
            this.colCreated2.DisplayFormat.FormatString = "D";
            this.colCreated2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colCreated2.FieldName = "Created";
            this.colCreated2.MaxWidth = 450;
            this.colCreated2.MinWidth = 68;
            this.colCreated2.Name = "colCreated2";
            this.colCreated2.OptionsColumn.AllowEdit = false;
            this.colCreated2.Visible = true;
            this.colCreated2.VisibleIndex = 6;
            this.colCreated2.Width = 178;
            // 
            // colTimeStamp9
            // 
            this.colTimeStamp9.FieldName = "TimeStamp";
            this.colTimeStamp9.MaxWidth = 246;
            this.colTimeStamp9.MinWidth = 68;
            this.colTimeStamp9.Name = "colTimeStamp9";
            this.colTimeStamp9.OptionsColumn.AllowEdit = false;
            this.colTimeStamp9.Width = 246;
            // 
            // GridColumn17
            // 
            this.GridColumn17.ColumnEdit = this.RepositoryItemCheckEdit20;
            this.GridColumn17.FieldName = "View";
            this.GridColumn17.MinWidth = 60;
            this.GridColumn17.Name = "GridColumn17";
            this.GridColumn17.OptionsColumn.AllowEdit = false;
            this.GridColumn17.OptionsColumn.AllowSize = false;
            this.GridColumn17.UnboundExpression = "True";
            this.GridColumn17.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            this.GridColumn17.Visible = true;
            this.GridColumn17.VisibleIndex = 1;
            this.GridColumn17.Width = 70;
            // 
            // colSource1
            // 
            this.colSource1.FieldName = "Source";
            this.colSource1.MinWidth = 60;
            this.colSource1.Name = "colSource1";
            this.colSource1.OptionsFilter.AllowAutoFilter = false;
            this.colSource1.OptionsFilter.AllowFilter = false;
            this.colSource1.Width = 224;
            // 
            // colCategory2
            // 
            this.colCategory2.FieldName = "Category";
            this.colCategory2.MinWidth = 60;
            this.colCategory2.Name = "colCategory2";
            this.colCategory2.OptionsColumn.AllowFocus = false;
            this.colCategory2.OptionsColumn.ReadOnly = true;
            this.colCategory2.Visible = true;
            this.colCategory2.VisibleIndex = 3;
            this.colCategory2.Width = 382;
            // 
            // colNotifiable
            // 
            this.colNotifiable.FieldName = "Notifiable";
            this.colNotifiable.MinWidth = 60;
            this.colNotifiable.Name = "colNotifiable";
            this.colNotifiable.Visible = true;
            this.colNotifiable.VisibleIndex = 8;
            this.colNotifiable.Width = 89;
            // 
            // colActionBy
            // 
            this.colActionBy.ColumnEdit = this.RepositoryItemLookUpEdit8;
            this.colActionBy.FieldName = "ActionBy";
            this.colActionBy.MinWidth = 60;
            this.colActionBy.Name = "colActionBy";
            this.colActionBy.OptionsColumn.AllowEdit = false;
            this.colActionBy.Visible = true;
            this.colActionBy.VisibleIndex = 9;
            this.colActionBy.Width = 205;
            // 
            // LayoutControlGroup2
            // 
            this.LayoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.LayoutControlGroup2.GroupBordersVisible = false;
            this.LayoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.LayoutControlItem5,
            this.LayoutControlItem6,
            this.LayoutControlItem7,
            this.LayoutControlItem8,
            this.SplitterItem1,
            this.SplitterItem3,
            this.SplitterItem4});
            this.LayoutControlGroup2.Name = "Root";
            this.LayoutControlGroup2.Size = new System.Drawing.Size(1703, 776);
            this.LayoutControlGroup2.TextVisible = false;
            // 
            // LayoutControlItem5
            // 
            this.LayoutControlItem5.Control = this.GridControl1;
            this.LayoutControlItem5.Location = new System.Drawing.Point(0, 299);
            this.LayoutControlItem5.Name = "LayoutControlItem5";
            this.LayoutControlItem5.Size = new System.Drawing.Size(1677, 451);
            this.LayoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.LayoutControlItem5.TextVisible = false;
            // 
            // LayoutControlItem6
            // 
            this.LayoutControlItem6.Control = this.ChartControl4;
            this.LayoutControlItem6.Location = new System.Drawing.Point(0, 0);
            this.LayoutControlItem6.Name = "LayoutControlItem6";
            this.LayoutControlItem6.Size = new System.Drawing.Size(614, 283);
            this.LayoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.LayoutControlItem6.TextVisible = false;
            // 
            // LayoutControlItem7
            // 
            this.LayoutControlItem7.Control = this.ChartControl5;
            this.LayoutControlItem7.Location = new System.Drawing.Point(630, 0);
            this.LayoutControlItem7.Name = "LayoutControlItem7";
            this.LayoutControlItem7.Size = new System.Drawing.Size(697, 283);
            this.LayoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.LayoutControlItem7.TextVisible = false;
            // 
            // LayoutControlItem8
            // 
            this.LayoutControlItem8.Control = this.ChartControl6;
            this.LayoutControlItem8.Location = new System.Drawing.Point(1343, 0);
            this.LayoutControlItem8.Name = "LayoutControlItem8";
            this.LayoutControlItem8.Size = new System.Drawing.Size(334, 283);
            this.LayoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.LayoutControlItem8.TextVisible = false;
            // 
            // SplitterItem1
            // 
            this.SplitterItem1.AllowHotTrack = true;
            this.SplitterItem1.Location = new System.Drawing.Point(614, 0);
            this.SplitterItem1.Name = "SplitterItem1";
            this.SplitterItem1.Size = new System.Drawing.Size(16, 283);
            // 
            // SplitterItem3
            // 
            this.SplitterItem3.AllowHotTrack = true;
            this.SplitterItem3.Location = new System.Drawing.Point(0, 283);
            this.SplitterItem3.Name = "SplitterItem3";
            this.SplitterItem3.Size = new System.Drawing.Size(1677, 16);
            // 
            // SplitterItem4
            // 
            this.SplitterItem4.AllowHotTrack = true;
            this.SplitterItem4.Location = new System.Drawing.Point(1327, 0);
            this.SplitterItem4.Name = "SplitterItem4";
            this.SplitterItem4.Size = new System.Drawing.Size(16, 283);
            // 
            // tabTaskList
            // 
            this.tabTaskList.Controls.Add(this.GridControl3);
            this.tabTaskList.Margin = new System.Windows.Forms.Padding(8);
            this.tabTaskList.Name = "tabTaskList";
            this.tabTaskList.Size = new System.Drawing.Size(1703, 776);
            this.tabTaskList.Text = "TaskList";
            // 
            // GridControl3
            // 
            this.GridControl3.DataSource = this.TaskListBindingSource;
            this.GridControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridControl3.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(8);
            this.GridControl3.Location = new System.Drawing.Point(0, 0);
            this.GridControl3.MainView = this.GridView1;
            this.GridControl3.Margin = new System.Windows.Forms.Padding(8);
            this.GridControl3.MenuManager = this.RibbonControl1;
            this.GridControl3.Name = "GridControl3";
            this.GridControl3.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.RepositoryItemHypertextLabel1});
            this.GridControl3.Size = new System.Drawing.Size(1703, 776);
            this.GridControl3.TabIndex = 15;
            this.GridControl3.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridView1});
            this.GridControl3.Click += new System.EventHandler(this.GridControl3_Click);
            // 
            // TaskListBindingSource
            // 
            this.TaskListBindingSource.DataMember = "TaskList";
            this.TaskListBindingSource.DataSource = this.MainDataSet;
            // 
            // GridView1
            // 
            this.GridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID3,
            this.colStandard,
            this.colRef1,
            this.colFindings,
            this.colRA,
            this.colPerson,
            this.colTimeStamp2,
            this.colStatus7});
            this.GridView1.DetailHeight = 1050;
            gridFormatRule13.ApplyToRow = true;
            gridFormatRule13.Column = this.colStatus7;
            gridFormatRule13.Name = "Format0";
            formatConditionRuleValue10.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue10.PredefinedName = "Green Fill";
            formatConditionRuleValue10.Value1 = "Completed";
            gridFormatRule13.Rule = formatConditionRuleValue10;
            this.GridView1.FormatRules.Add(gridFormatRule13);
            this.GridView1.GridControl = this.GridControl3;
            this.GridView1.GroupCount = 1;
            this.GridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "ID", null, "(Count={0})")});
            this.GridView1.Name = "GridView1";
            this.GridView1.OptionsView.ShowFooter = true;
            this.GridView1.OptionsView.ShowIndicator = false;
            this.GridView1.RowHeight = 22;
            this.GridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colPerson, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.GridView1.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.GridView1_RowCellClick);
            // 
            // colID3
            // 
            this.colID3.AppearanceCell.Options.UseTextOptions = true;
            this.colID3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colID3.AppearanceHeader.Options.UseTextOptions = true;
            this.colID3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colID3.ColumnEdit = this.RepositoryItemHyperLinkEdit13;
            this.colID3.FieldName = "ID";
            this.colID3.MaxWidth = 224;
            this.colID3.MinWidth = 60;
            this.colID3.Name = "colID3";
            this.colID3.OptionsColumn.AllowEdit = false;
            this.colID3.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ID", "{0}")});
            this.colID3.Visible = true;
            this.colID3.VisibleIndex = 0;
            this.colID3.Width = 100;
            // 
            // colStandard
            // 
            this.colStandard.FieldName = "Standard";
            this.colStandard.MinWidth = 60;
            this.colStandard.Name = "colStandard";
            this.colStandard.OptionsColumn.AllowEdit = false;
            this.colStandard.Visible = true;
            this.colStandard.VisibleIndex = 2;
            this.colStandard.Width = 894;
            // 
            // colRef1
            // 
            this.colRef1.FieldName = "Ref";
            this.colRef1.MaxWidth = 254;
            this.colRef1.MinWidth = 60;
            this.colRef1.Name = "colRef1";
            this.colRef1.OptionsColumn.AllowEdit = false;
            this.colRef1.Visible = true;
            this.colRef1.VisibleIndex = 1;
            this.colRef1.Width = 103;
            // 
            // colFindings
            // 
            this.colFindings.FieldName = "Findings";
            this.colFindings.MinWidth = 60;
            this.colFindings.Name = "colFindings";
            this.colFindings.OptionsColumn.AllowEdit = false;
            this.colFindings.Visible = true;
            this.colFindings.VisibleIndex = 3;
            this.colFindings.Width = 432;
            // 
            // colRA
            // 
            this.colRA.FieldName = "RA";
            this.colRA.MinWidth = 60;
            this.colRA.Name = "colRA";
            this.colRA.OptionsColumn.AllowEdit = false;
            this.colRA.Width = 552;
            // 
            // colPerson
            // 
            this.colPerson.FieldName = "Person";
            this.colPerson.MaxWidth = 374;
            this.colPerson.MinWidth = 60;
            this.colPerson.Name = "colPerson";
            this.colPerson.OptionsColumn.AllowEdit = false;
            this.colPerson.Visible = true;
            this.colPerson.VisibleIndex = 4;
            this.colPerson.Width = 374;
            // 
            // colTimeStamp2
            // 
            this.colTimeStamp2.FieldName = "TimeStamp";
            this.colTimeStamp2.MaxWidth = 374;
            this.colTimeStamp2.MinWidth = 60;
            this.colTimeStamp2.Name = "colTimeStamp2";
            this.colTimeStamp2.OptionsColumn.AllowEdit = false;
            this.colTimeStamp2.Visible = true;
            this.colTimeStamp2.VisibleIndex = 5;
            this.colTimeStamp2.Width = 93;
            // 
            // RepositoryItemHypertextLabel1
            // 
            this.RepositoryItemHypertextLabel1.Name = "RepositoryItemHypertextLabel1";
            // 
            // TaskListTableAdapter
            // 
            this.TaskListTableAdapter.ClearBeforeFill = true;
            // 
            // DocumentsTableAdapter
            // 
            this.DocumentsTableAdapter.ClearBeforeFill = true;
            // 
            // RisksTableAdapter
            // 
            this.RisksTableAdapter.ClearBeforeFill = true;
            // 
            // TaskPriorityTableAdapter
            // 
            this.TaskPriorityTableAdapter.ClearBeforeFill = true;
            // 
            // InfoTableAdapter
            // 
            this.InfoTableAdapter.ClearBeforeFill = true;
            // 
            // AuditTableAdapter
            // 
            this.AuditTableAdapter.ClearBeforeFill = true;
            // 
            // ContactsTableAdapter
            // 
            this.ContactsTableAdapter.ClearBeforeFill = true;
            // 
            // ntIconNew
            // 
            this.ntIconNew.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ntIconNew.BalloonTipText = "You have unread items in Business Manager";
            this.ntIconNew.BalloonTipTitle = "Attention";
            this.ntIconNew.Text = "Dashboard : Business Manager";
            this.ntIconNew.Visible = true;
            // 
            // puCopy
            // 
            this.puCopy.ItemLinks.Add(this.btnCopyValue);
            this.puCopy.ItemLinks.Add(this.btnCopyCol);
            this.puCopy.Name = "puCopy";
            this.puCopy.Ribbon = this.RibbonControl1;
            // 
            // bgEmail
            // 
            this.bgEmail.WorkerReportsProgress = true;
            this.bgEmail.WorkerSupportsCancellation = true;
            this.bgEmail.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgEmail_DoWork);
            this.bgEmail.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgemail_runworkercompleted);
            // 
            // NCRTableAdapter
            // 
            this.NCRTableAdapter.ClearBeforeFill = true;
            // 
            // schStorageMedics
            // 
            // 
            // 
            // 
            this.schStorageMedics.AppointmentDependencies.AutoReload = false;
            // 
            // 
            // 
            this.schStorageMedics.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("PersonID", "PersonID"));
            this.schStorageMedics.Appointments.DataSource = this.PersonAvailBindingSource;
            this.schStorageMedics.Appointments.Labels.CreateNewLabel(0, "None", "&None", System.Drawing.SystemColors.Window);
            this.schStorageMedics.Appointments.Labels.CreateNewLabel(1, "Important", "&Important", System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(194)))), ((int)(((byte)(190))))));
            this.schStorageMedics.Appointments.Labels.CreateNewLabel(2, "Business", "&Business", System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(213)))), ((int)(((byte)(255))))));
            this.schStorageMedics.Appointments.Labels.CreateNewLabel(3, "Personal", "&Personal", System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(244)))), ((int)(((byte)(156))))));
            this.schStorageMedics.Appointments.Labels.CreateNewLabel(4, "Vacation", "&Vacation", System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(228)))), ((int)(((byte)(199))))));
            this.schStorageMedics.Appointments.Labels.CreateNewLabel(5, "Must Attend", "Must &Attend", System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(206)))), ((int)(((byte)(147))))));
            this.schStorageMedics.Appointments.Labels.CreateNewLabel(6, "Travel Required", "&Travel Required", System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(244)))), ((int)(((byte)(255))))));
            this.schStorageMedics.Appointments.Labels.CreateNewLabel(7, "Needs Preparation", "&Needs Preparation", System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(219)))), ((int)(((byte)(152))))));
            this.schStorageMedics.Appointments.Labels.CreateNewLabel(8, "Birthday", "&Birthday", System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(207)))), ((int)(((byte)(233))))));
            this.schStorageMedics.Appointments.Labels.CreateNewLabel(9, "Anniversary", "&Anniversary", System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(233)))), ((int)(((byte)(223))))));
            this.schStorageMedics.Appointments.Labels.CreateNewLabel(10, "Phone Call", "Phone &Call", System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(165))))));
            this.schStorageMedics.Appointments.Mappings.AllDay = "AllDay";
            this.schStorageMedics.Appointments.Mappings.Description = "Description";
            this.schStorageMedics.Appointments.Mappings.End = "EndDate";
            this.schStorageMedics.Appointments.Mappings.Label = "Label";
            this.schStorageMedics.Appointments.Mappings.Location = "Note";
            this.schStorageMedics.Appointments.Mappings.OriginalOccurrenceStart = "TimeStamp";
            this.schStorageMedics.Appointments.Mappings.ResourceId = "ResourceID";
            this.schStorageMedics.Appointments.Mappings.Start = "StartDate";
            this.schStorageMedics.Appointments.Mappings.Status = "Status";
            this.schStorageMedics.Appointments.Mappings.Subject = "Subject";
            this.schStorageMedics.Appointments.Mappings.Type = "Type";
            // 
            // 
            // 
            this.schStorageMedics.Labels.ColorSaving = DevExpress.XtraScheduler.DXColorSavingType.ArgbColor;
            // 
            // PersonAvailBindingSource
            // 
            this.PersonAvailBindingSource.DataMember = "PersonAvail";
            this.PersonAvailBindingSource.DataSource = this.PersonnellDataSet;
            // 
            // tt
            // 
            this.tt.ClearBeforeFill = true;
            // 
            // schInstructors
            // 
            // 
            // 
            // 
            this.schInstructors.AppointmentDependencies.AutoReload = false;
            // 
            // 
            // 
            this.schInstructors.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("PersonID", "PersonID"));
            this.schInstructors.Appointments.DataSource = this.InstructorAvailabilityBindingSource;
            this.schInstructors.Appointments.Labels.CreateNewLabel(0, "None", "&None", System.Drawing.SystemColors.Window);
            this.schInstructors.Appointments.Labels.CreateNewLabel(1, "Important", "&Important", System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(194)))), ((int)(((byte)(190))))));
            this.schInstructors.Appointments.Labels.CreateNewLabel(2, "Business", "&Business", System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(213)))), ((int)(((byte)(255))))));
            this.schInstructors.Appointments.Labels.CreateNewLabel(3, "Personal", "&Personal", System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(244)))), ((int)(((byte)(156))))));
            this.schInstructors.Appointments.Labels.CreateNewLabel(4, "Vacation", "&Vacation", System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(228)))), ((int)(((byte)(199))))));
            this.schInstructors.Appointments.Labels.CreateNewLabel(5, "Must Attend", "Must &Attend", System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(206)))), ((int)(((byte)(147))))));
            this.schInstructors.Appointments.Labels.CreateNewLabel(6, "Travel Required", "&Travel Required", System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(244)))), ((int)(((byte)(255))))));
            this.schInstructors.Appointments.Labels.CreateNewLabel(7, "Needs Preparation", "&Needs Preparation", System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(219)))), ((int)(((byte)(152))))));
            this.schInstructors.Appointments.Labels.CreateNewLabel(8, "Birthday", "&Birthday", System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(207)))), ((int)(((byte)(233))))));
            this.schInstructors.Appointments.Labels.CreateNewLabel(9, "Anniversary", "&Anniversary", System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(233)))), ((int)(((byte)(223))))));
            this.schInstructors.Appointments.Labels.CreateNewLabel(10, "Phone Call", "Phone &Call", System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(165))))));
            this.schInstructors.Appointments.Mappings.AllDay = "AllDay";
            this.schInstructors.Appointments.Mappings.End = "Date";
            this.schInstructors.Appointments.Mappings.Start = "Date";
            this.schInstructors.Appointments.Mappings.Status = "Status";
            this.schInstructors.Appointments.Mappings.Subject = "Name";
            // 
            // InstructorAvailabilityBindingSource
            // 
            this.InstructorAvailabilityBindingSource.DataMember = "InstructorAvailability";
            this.InstructorAvailabilityBindingSource.DataSource = this.PersonnellDataSet;
            // 
            // INstructorAvailabilityTableAdapter
            // 
            this.INstructorAvailabilityTableAdapter.ClearBeforeFill = true;
            // 
            // PopupMenu5
            // 
            this.PopupMenu5.ItemLinks.Add(this.btnFlag);
            this.PopupMenu5.Name = "PopupMenu5";
            this.PopupMenu5.Ribbon = this.RibbonControl1;
            // 
            // GridControl2
            // 
            this.GridControl2.Location = new System.Drawing.Point(450, 450);
            this.GridControl2.MainView = this.GridView2;
            this.GridControl2.MenuManager = this.RibbonControl1;
            this.GridControl2.Name = "GridControl2";
            this.GridControl2.Size = new System.Drawing.Size(400, 742);
            this.GridControl2.TabIndex = 13;
            this.GridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridView2});
            // 
            // GridView2
            // 
            this.GridView2.GridControl = this.GridControl2;
            this.GridView2.Name = "GridView2";
            this.GridView2.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.GridView2_RowCellClick);
            this.GridView2.CustomDrawEmptyForeground += new DevExpress.XtraGrid.Views.Base.CustomDrawEventHandler(this.GridView2_CustomDrawEmptyForeground);
            // 
            // GalleryDropDown2
            // 
            // 
            // 
            // 
            galleryItemGroup6.Caption = "Group6";
            this.GalleryDropDown2.Gallery.Groups.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItemGroup[] {
            galleryItemGroup6});
            this.GalleryDropDown2.Name = "GalleryDropDown2";
            this.GalleryDropDown2.Ribbon = this.RibbonControl1;
            // 
            // shiftsTableAdapter
            // 
            this.shiftsTableAdapter.ClearBeforeFill = true;
            // 
            // trainDataSet
            // 
            this.trainDataSet.DataSetName = "TrainDataSet";
            this.trainDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // courseListBindingSource
            // 
            this.courseListBindingSource.DataMember = "CourseList";
            this.courseListBindingSource.DataSource = this.trainDataSet;
            // 
            // courseListTableAdapter
            // 
            this.courseListTableAdapter.ClearBeforeFill = true;
            // 
            // frmMain
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.False;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1839, 1045);
            this.Controls.Add(this.SplitContainerControl1);
            this.Controls.Add(this.RibbonStatusBar1);
            this.Controls.Add(this.RibbonControl1);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.Name = "frmMain";
            this.Ribbon = this.RibbonControl1;
            this.StatusBar = this.RibbonStatusBar1;
            this.Text = " Business Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyUp);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemCheckEdit11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemHyperLinkEdit15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NCRBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repFlaggedCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.svgFlagged)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemCheckEdit8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repShowInactive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repByCourse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemLookUpEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemProgressBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemTextEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemDuration1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemZoomTrackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemSpinEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemHyperLinkEdit6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemHyperLinkEdit19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemCheckEdit19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemHyperLinkEdit7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemCheckEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PersonnellBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemHyperLinkEdit14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemLookUpEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemImageComboBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgGov)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemCheckEdit12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemCheckEdit13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemCheckEdit16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemLookUpEdit5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemRichTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemHyperLinkEdit9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemImageComboBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdImageList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemCheckEdit18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemHyperLinkEdit13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemHyperLinkEdit17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemHyperLinkEdit18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemCheckEdit20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemTextEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ApplicationMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.puOpen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PersonnellDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemCheckEdit10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeadListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeadsDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemImageComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemCheckEdit9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schWeb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WebUpcomingBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WebDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SchedulerStorage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpcomingBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PersonnellBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ActivitiesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SystemUsersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BusinessNotesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SystemTasksBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TaskDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TasksBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PeopleByCourseBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.puGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.puEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClinicalDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeadsByCourseBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Popup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.puGov)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SchedulerBarController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schWebView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.puScheduler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RisksBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TaskPriorityBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DocumentsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AuditBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContactsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InfoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AssetShiftBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NavBarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerControl1.Panel1)).EndInit();
            this.SplitContainerControl1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerControl1.Panel2)).EndInit();
            this.SplitContainerControl1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerControl1)).EndInit();
            this.SplitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbDashboard)).EndInit();
            this.tbDashboard.ResumeLayout(false);
            this.tabMyHome.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TabPane1)).EndInit();
            this.TabPane1.ResumeLayout(false);
            this.TabNavigationPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerControl3.Panel1)).EndInit();
            this.SplitContainerControl3.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerControl3.Panel2)).EndInit();
            this.SplitContainerControl3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerControl3)).EndInit();
            this.SplitContainerControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TaskTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmailGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMyInbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemRichTextEdit1)).EndInit();
            this.tabCalendar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerControl4.Panel1)).EndInit();
            this.SplitContainerControl4.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerControl4.Panel2)).EndInit();
            this.SplitContainerControl4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerControl4)).EndInit();
            this.SplitContainerControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.schCourses)).EndInit();
            this.tabTraining.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TrainingGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrainingGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemCheckEdit7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemCheckEdit14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemColorEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemCalcEdit1)).EndInit();
            this.tabClinical.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ClincalGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shiftsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClinicalGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemCheckEdit5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemLookUpEdit6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemCheckEdit3)).EndInit();
            this.tabLeads.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ActivitiesGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeadsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SystemUsersBindingSource1)).EndInit();
            this.tabGovernance.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerControl2.Panel1)).EndInit();
            this.SplitContainerControl2.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerControl2.Panel2)).EndInit();
            this.SplitContainerControl2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerControl2)).EndInit();
            this.SplitContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TreeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerControl5.Panel1)).EndInit();
            this.SplitContainerControl5.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerControl5.Panel2)).EndInit();
            this.SplitContainerControl5.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerControl5)).EndInit();
            this.SplitContainerControl5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GovStandardsGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GovGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGovInfo.Properties)).EndInit();
            this.tabNotes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BusinessNotesGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TileView1)).EndInit();
            this.tabTasks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TasksGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView3)).EndInit();
            this.tabRisk.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl1)).EndInit();
            this.LayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(stackedBarSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartControl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RisksGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemLookUpEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItem3)).EndInit();
            this.tabDocuments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DocumentsGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemCheckEdit6)).EndInit();
            this.tabAudit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AuditGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAudit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemRatingControl1)).EndInit();
            this.tabFlagged.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl2)).EndInit();
            this.LayoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartControl6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(stackedBarSeriesView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartControl5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(stackedBarSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(stackedBarSeriesView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartControl4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFlagged)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemLookUpEdit8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PersonnellBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitterItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitterItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitterItem4)).EndInit();
            this.tabTaskList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridControl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TaskListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemHypertextLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.puCopy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schStorageMedics)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PersonAvailBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schInstructors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InstructorAvailabilityBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PopupMenu5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GalleryDropDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trainDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.courseListBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

	}
	private DevExpress.XtraBars.Ribbon.RibbonPage RibbonPage2;
	private RibbonPage rbnGovernance;
	private RibbonPage rbnRisk;
	private RibbonPage rbnTasks;
	private RibbonPage rbnLeads;
	private RibbonPage rbnPersonnel;
	private RibbonPage rbnClinical;
	private RibbonPage rbnTraining;
	private RibbonPage rbnMyHome;
	private RibbonPageGroup RibbonPageGroup1;
	private BarButtonItem btnNewCourse;
	private RibbonPageGroup RibbonPageGroup2;
	private RibbonControl RibbonControl1;
	private RibbonStatusBar RibbonStatusBar1;
	private NavBarGroup NavBarGroup1;
	private NavBarItem nvHome;
	private NavBarItem nvTraining;
	private NavBarItem nvClinical;
	private NavBarItem nvEquipment;
	private NavBarItem nvPersonnel;
	private NavBarItem nvSales;
	private NavBarItem nvRisk;
	private NavBarItem nvGovernance;
	private RibbonPageGroup RibbonPageGroup3;
	private RibbonPageGroup RibbonPageBatchUpdate;
	private RibbonPageGroup RibbonPageGroup5;
	private RibbonPageGroup RibbonPageGroup6;
	private RibbonPageGroup RibbonPageGroup7;
	private RibbonPageGroup RibbonPageGroup8;
	private RepositoryItemCheckEdit RepositoryItemCheckEdit5;
	private RibbonPageGroup RibbonPageGroup9;
	private RibbonPageGroup RibbonPageGroup10;
	private BarButtonItem btnEditCourse;
	private BarButtonItem btnMultiAddCourse;
	private BarButtonItem btnMultiSelect;
	private BarButtonItem btnBatchUpdate;
	private BarButtonItem btnBatchExportCourse;
	private BarButtonItem btnBatchCerts;
	private BarButtonItem btnFindStudents;
	private BarButtonItem btnImportStudents;
	public BarButtonItem BtnRefresh;
	private BarButtonItem btnOpenCourses;
	private BarButtonItem BtnAllCourses;
	private BarButtonItem btnNotSet;
	private BarButtonItem btnYesterday;
	private BarButtonItem btnToday;
	private BarButtonItem btnTomorrow;
	private BarButtonItem btnLastWeek;
	private BarButtonItem btnThisWeek;
	private BarButtonItem btnNextWeek;
	private BarButtonItem btnLastMonth;
	private BarButtonItem btnThisMonth;
	private BarButtonItem btnNextMonth;
	private BarButtonItem btnTrainingReturns;
	private BarButtonItem btnStats;
	private BarButtonItem btnFlagged;
	private PopupMenu puOpen;
	private BarButtonItem btnPastOpen;
	private BarButtonItem btnNotInvoiced;
	private BarButtonItem btnPastNotInvoiced;
	private BarStaticItem brUser;
	private BarStaticItem brIP;
	private BarStaticItem brLoggedUsers;
	private BarStaticItem brSecurity;
	private BarStaticItem brSecure;
	private BarStaticItem brShares;
	private BarStaticItem brVersion;
	private BarStaticItem brWebAccess;
	private BarButtonItem btnOptionsView;
	private NavBarItem nvCalendar;
	private DevExpress.XtraScheduler.SchedulerStorage SchedulerStorage;
	private BindingSource UpcomingBindingSource;
	private BM.MainDataSet MainDataSet;
	private BM.MainDataSetTableAdapters.UpcomingTableAdapter UpcomingTableAdapter;
	private RibbonPageGroup RibbonPageGroup11;
	private BarSubItem btnClinicalAdd;
	private RibbonPageGroup RibbonPageGroup12;
	private BarButtonItem btnClinicalAudits;
	private BarButtonItem btnClinicalReports;
	private RibbonPageGroup RibbonPageGroup13;
	private RibbonPageGroup RibbonPageGroup14;
	private RibbonPageGroup RibbonPageGroup15;
	private RibbonPageGroup RibbonPageGroup16;
	private RibbonPageGroup RibbonPageGroup17;
    private BindingSource PersonnellBindingSource;
	private BM.MainDataSetTableAdapters.PersonnellTableAdapter PersonnellTableAdapter;
	private PersonnellDataSet PersonnellDataSet;
	private BindingSource PersonnellBindingSource1;
	private PersonnellDataSetTableAdapters.PersonnellTableAdapter PersonnellTableAdapter1;
	private DevExpress.XtraGrid.Views.BandedGrid.GridBand GridBand1;
	private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colID2;
	private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colInstructorName;
	private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colCompany1;
	private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colEmail;
	private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colHomePhone;
	private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colMobilePhone;
	private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colAttachments;
	private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colClinical_Grade;
	private RibbonPageGroup RibbonPageGroup19;
	private BarButtonItem btnViewbyMedics;
	private BarButtonItem btnViewbyInstructors;
	private BarSubItem BarSubItem1;
	private BarEditItem BarEditItem1;
	private BarEditItem btnShowInactive;
	private BarEditItem BarEditItem2;
	private BarEditItem brByCourse;
	private PersonnellDataSetTableAdapters.PeopleByCourseTableAdapter PeopleByCourseTableAdapter1;
	private BindingSource PeopleByCourseBindingSource;
	private BarButtonItem btnResetPersonnelView;
	private BarButtonItem btnAddSingleShift;
	private System.ComponentModel.BackgroundWorker bgwCourseUpdate;
	private BarButtonItem btnClinicalStats;
	private BarButtonItem btnCopy;
	private BarButtonItem btnOpenThis;
	private BarButtonItem btnAllThis;
	private BarButtonItem btnClearFilter;
	private BarSubItem btnCompanyReport;
	private BarButtonItem btn7DayReport;
	private BarButtonItem btnSummaryReport;
	private BarButtonItem btnDetailReport;
	private BarButtonItem btnTempReport;
	private BarSubItem BarSubItem3;
	private BarButtonItem btnThisMonthReport;
	private BarButtonItem btnMonthReportLast;
	private BarButtonItem btnMonthReportNext;
	private PopupMenu puGrid;
	private DevExpress.Utils.ImageCollection imgEmail;
	private BarButtonItem btnConvertLead;
	private BarButtonItem btnConvertTask;
	private PopupMenu puEmail;
	private System.Windows.Forms.Timer Timer1;
	private ApplicationMenu ApplicationMenu1;
	private BarButtonItem btnLogOff;
	private BarStaticItem brInfo;
	private BarButtonItem btnAuditLog;
	private BarButtonItem btnAddTask;
	private BarButtonItem btnAddLead;
	private BarButtonItem BtnShiftSheets;
	private BarButtonItem btnCourseExpiry;
	private BarButtonItem btnStaffCompliance;
	private RibbonPageGroup RibbonPageGroup20;
	private RibbonPageGroup RibbonPageGroup21;
	private BarButtonItem btnGlobalCompliance;
	private BarEditItem BarEditItem3;
	private BarButtonItem btnShowWeb;
	private BarSubItem btnAvailability;
	private BarButtonItem btnMedicsAvailability;
	private BarButtonItem btnInstAvailability;
	private DevExpress.XtraScheduler.SchedulerStorage schWeb;
	private WebDataSet WebDataSet;
	private BindingSource WebUpcomingBindingSource;
	private WebDataSetTableAdapters.WebUpcomingTableAdapter WebUpcomingTableAdapter;
	private BarSubItem btnFilter;
	private BarButtonItem btnFilterShift;
	private BarButtonItem btnFilterCourse;
	private BarButtonItem btnFilterMeeting;
	private LeadsDataSet LeadsDataSet;
	private BindingSource ActivitiesBindingSource;
	private LeadsDataSetTableAdapters.ActivitiesTableAdapter ActivitiesTableAdapter;
	private LeadsDataSetTableAdapters.TableAdapterManager TableAdapterManager;
	private RibbonPageGroup RibbonPageGroup22;
	private BarButtonItem btnOpenLeads;
	private BarButtonItem btnNewLead;
	private RibbonPageGroup RibbonPageGroup23;
	private RibbonPageGroup RibbonPageGroup24;
	private BarButtonItem btnAllLeads;
	private BarButtonItem btnClosedLost;
	private BarButtonItem btnClosedWon;
	private BarButtonItem btnMyLeads;
	private RibbonPageGroup RibbonPageGroup25;
	private BarEditItem BarEditItem4;
	private BindingSource LeadListBindingSource;
	private LeadsDataSetTableAdapters.Lead_ListTableAdapter Lead_ListTableAdapter;
	private BindingSource LeadsByCourseBindingSource;
	private LeadsDataSetTableAdapters.LeadsByCourseTableAdapter LeadsByCourseTableAdapter;
	private BindingSource SystemUsersBindingSource;
	private BM.MainDataSetTableAdapters.SystemUsersTableAdapter SystemUsersTableAdapter;
	private GovDataSetTableAdapters.GovTableAdapter GovTableAdapter;
	private GovDataSetTableAdapters.GovStandardsTableAdapter GovStandardsTableAdapter;
	private GovDataSetTableAdapters.TableAdapterManager TableAdapterManager1;
	private RepositoryItemProgressBar RepositoryItemProgressBar1;
	private RibbonPageGroup RibbonPageGroup26;
	private BarButtonItem btnReport;
	private RibbonPageGroup RibbonPageGroup27;
	private BarButtonItem btnAddItem;
	private RibbonPageGroup RibbonPageGroup28;
	private BarButtonItem btnFilterStandards;
	private BarButtonItem btnFilterPolicies;
	private BarButtonItem btnFilterEvidence;
	private BarButtonItem btnFilterKPI;
	private BarButtonItem btnFilterViewAll;
	private RibbonPageGroup RibbonPageGroup29;
	private BarButtonItem btnExpandAll;
	private BarButtonItem btnCollapseAll;
	private BindingSource BusinessNotesBindingSource;
	private BM.MainDataSetTableAdapters.BusinessNotesTableAdapter BusinessNotesTableAdapter;
	private BarButtonItem btnWorkDiary;
	private RibbonPageGroup RibbonPageGroup30;
	private System.ComponentModel.BackgroundWorker bgRefresh;
	private BarButtonItem btnMap;
	private RibbonPageGroup RibbonPageGroup31;
	private BarButtonItem btnSortName;
	private BarButtonItem btnSortLocation;
	private RibbonPageGroup RibbonPageGroup32;
	private System.ComponentModel.BackgroundWorker bgwShiftSheetEmails;
	private BarEditItem brProgress;
	private System.ComponentModel.BackgroundWorker bgwStudentsEmail;
	private System.ComponentModel.BackgroundWorker bgwGlobalCompliance;
	private BarButtonItem btnGridExpand;
	private BarButtonItem btnSanity;
	private RibbonPageGroup RibbonPageGroup33;
	private System.ComponentModel.BackgroundWorker BackgroundWorker1;
	private BarButtonItem btnFilterTask;
	private BarButtonItem btnFilterLead;
	private BarButtonItem btnFilterEmail;
	private BarButtonItem BarButtonItem9;
	private BarButtonItem btnOpenGov;
	private BarButtonItem btnRemoveItem;
	private BarButtonItem btnFindReferences;
	private BarButtonItem btnOpenItem;
	private BarButtonItem btnOpenFile;
	private BarButtonItem btnRename;
	private BarButtonItem btnCopyItem;
	private BarButtonItem btnNewSection;
	private BarButtonItem btnRemoveItemGov;
	private BarEditItem BarEditItem5;
	private BarSubItem BarSubItem2;
	private BarButtonItem btnAddStandard;
	private BarButtonItem btnAddPolicy;
	private BarButtonItem btnAddLegislation;
	private BarButtonItem btnAddGuideline;
	private BarButtonItem btnAddEvidence;
	private BarButtonItem btnAddKPI;
	private BarButtonItem btnAddGovTask;
	private BarSubItem BarSubItem4;
	private BarButtonItem btnMoveUp;
	private BarButtonItem btnMoveDown;
	private BarSubItem BarSubItem5;
	private BarButtonItem btnExpandTree;
	private BarButtonItem btnCollapseTree;
	private PopupMenu Popup;
	private PopupMenu puGov;
	private RibbonPageGroup RibbonPageGroup34;
	private BarButtonItem BarButtonItem10;
	private BarButtonItem btnShiftTemplate;
	private RibbonPageGroup RibbonPageGroup35;
	private BarButtonItem BarButtonItem11;
	private BarButtonItem btnAddNote;
	private TaskDataSet TaskDataSet;
	private BindingSource TasksBindingSource;
	private TaskDataSetTableAdapters.TasksTableAdapter TasksTableAdapter;
	private BindingSource SystemTasksBindingSource;
	private TaskDataSetTableAdapters.SystemTasksTableAdapter SystemTasksTableAdapter;
	private DevExpress.XtraScheduler.UI.EditAppointmentQueryItem EditAppointmentQueryItem1;
	private DevExpress.XtraScheduler.UI.EditOccurrenceUICommandItem EditOccurrenceUICommandItem1;
	private DevExpress.XtraScheduler.UI.EditSeriesUICommandItem EditSeriesUICommandItem1;
	private DevExpress.XtraScheduler.UI.DeleteAppointmentsItem DeleteAppointmentsItem1;
	private DevExpress.XtraScheduler.UI.DeleteOccurrenceItem DeleteOccurrenceItem1;
	private GridColumn GridColumn7;
	private DevExpress.XtraScheduler.UI.DeleteSeriesItem DeleteSeriesItem1;
	private DevExpress.XtraScheduler.UI.SplitAppointmentItem SplitAppointmentItem1;
	private DevExpress.XtraScheduler.UI.ChangeAppointmentStatusItem ChangeAppointmentStatusItem1;
	private DevExpress.XtraScheduler.UI.ChangeAppointmentLabelItem ChangeAppointmentLabelItem1;
	private DevExpress.XtraScheduler.UI.ToggleRecurrenceItem ToggleRecurrenceItem1;
	private DevExpress.XtraScheduler.UI.ChangeAppointmentReminderItem ChangeAppointmentReminderItem1;
	private DevExpress.XtraScheduler.UI.SchedulerBarController SchedulerBarController1;
	private BarButtonItem btnAddAppointment;
	private PopupMenu puScheduler;
	private NavBarItem nvDocuments;
	private NavBarControl NavBarControl1;
	private SplitContainerControl SplitContainerControl1;
	private BindingSource DocumentsBindingSource;
	private BM.MainDataSetTableAdapters.DocumentsTableAdapter DocumentsTableAdapter;
	private BindingSource RisksBindingSource;
	private BM.MainDataSetTableAdapters.RisksTableAdapter RisksTableAdapter;
	private BarButtonItem btnAddDocument;
	private RibbonPage rbnDocuments;
	private RibbonPageGroup RibbonPageGroup37;
	private BarButtonItem BarButtonItem13;
	private BarButtonItem BarButtonItem14;
	private RibbonPageGroup RibbonPageGroup38;
	private RibbonPageGroup RibbonPageGroup39;
	private BarButtonItem BarButtonItem15;
	private BindingSource TaskPriorityBindingSource;
	private TaskDataSetTableAdapters.TaskPriorityTableAdapter TaskPriorityTableAdapter;
	private DevExpress.Utils.ImageCollection grdImageList;
	private NavBarItem nvAudit;
	private NavBarGroup NavBarGroup2;
	private NavBarItem nvFlagged;
	private BarSubItem btnViewOptions;
	private BarButtonItem btnViewFooter;
	private BarButtonItem btnViewFilter;
	private BarButtonItem btnFooterFilter;
	private BarButtonItem btnViewFind;
	private BarButtonItem btnHorLines;
	private BarButtonItem btnVerticalLInes;
	private BarButtonItem btnCellMerge;
	private BarButtonItem btnAddInfo;
	private BindingSource InfoBindingSource;
	private BM.MainDataSetTableAdapters.InfoTableAdapter InfoTableAdapter;
	private BarButtonItem btnShowGrouped;
	private RibbonPage rbnAudit;
	private RibbonPageGroup RibbonPageGroup41;
	private BindingSource AuditBindingSource;
	private GovDataSetTableAdapters.AuditTableAdapter AuditTableAdapter;
	private BarButtonItem BarButtonItem18;
	private RibbonPageGroup RibbonPageGroup42;
	private RibbonPageGroup RibbonPageGroup43;
	private RibbonPageGroup RibbonPageGroup44;
	private RibbonPageGroup RibbonPageGroup45;
	private RibbonPageGroup RibbonPageGroup47;
	private RibbonPageGroup RibbonPageGroup49;
	private RibbonPageGroup RibbonPageGroup51;
	private RibbonPageGroup RibbonPageGroup48;
	private BarButtonItem btnForReview;
	private BarButtonItem btnViewOpen;
	private BarButtonItem btnShowAll;
	private BarListItem BarListItem1;
	private BindingSource ContactsBindingSource;
	private BM.MainDataSetTableAdapters.ContactsTableAdapter ContactsTableAdapter;
	private RibbonPage rbnContacts;
	private RibbonPageGroup RibbonPageGroup53;
	private RibbonPageGroup RibbonPageGroup54;
	private BarButtonItem BarButtonItem19;
	private RibbonPageGroup RibbonPageGroup55;
	private BarButtonItem btnGridCollapse;
	private BarSubItem btnGridExport;
	private BarToggleSwitchItem btnExportSelected;
	private BarButtonItem btnGridExportPDF;
	private BarButtonItem btnGridExportCSV;
	private BarButtonItem btnGridExportExcel;
	private BarButtonItem btnGridExportWord;
	private BarButtonItem btnGridExportHtml;
	private BarButtonItem btnGridExportXLXS;
	private BarButtonItem btnGridPrint;
	private RibbonPageGroup RibbonPageGroup56;
	private RibbonPageGroup RibbonPageGroup57;
	private RibbonPageGroup RibbonPageGroup58;
	private RibbonPageGroup RibbonPageGroup60;
	private RibbonPageGroup RibbonPageGroup62;
	private RibbonPageGroup RibbonPageGroup64;
	private RibbonPageGroup RibbonPageGroup65;
	private RibbonPageGroup RibbonPageGroup61;
	private BarButtonItem btnOddRow;
	private BarButtonItem BarButtonItem5;
	private NotifyIcon ntIconNew;
	private DevExpress.Utils.ImageCollection imgGov;
	private DevExpress.Utils.ToolTipController ttTree;
	private BarButtonItem btnCopyValue;
	private PopupMenu puCopy;
	private BarButtonItem btnCourseCurrent;
	private BindingSource SystemUsersBindingSource1;
	private BarSubItem btnFilterBy;
	private RibbonPageGroup RibbonPageGroup66;
	private BarButtonItem BarButtonItem20;
	private BarSubItem BarSubItem6;
	private BarButtonItem btnPersonClinicalReport;
	private System.ComponentModel.BackgroundWorker bgEmail;
	private BarButtonItem btnNoPaperworkShow;
	private BarButtonItem btnFutureTasks;
	private BarButtonItem btnResetInbox;
	private BarButtonItem btnMedicReminders;
	private BarButtonItem btnInstructorsReminders;
	private GridColumn GridColumn26;
	private GridColumn GridColumn27;
	private GridControl GridControl3;
	private GridView GridView1;
	private BindingSource NCRBindingSource;
	private BM.MainDataSetTableAdapters.NCRTableAdapter NCRTableAdapter;
	private BarButtonItem BarButtonItem3;
	private RibbonPageGroup RibbonPageGroup67;
	private BarButtonItem BarButtonItem4;
	private BarEditItem BarEditItem6;
	private BarButtonItem BarButtonItem6;
	private DevExpress.Utils.ToolTipController ttTraining;
	private BarButtonItem BarButtonItem7;
	private BarButtonItem btnRestart;
	private BarButtonItem btnInvoice;
	private BarButtonItem btnMedicsReport;
	private BarSubItem BarSubItem7;
	private BarButtonItem btnMedicRegister;
	private BarButtonItem btnMedicCompliance;
	private RibbonPageGroup RibbonPageGroup68;
	private DevExpress.Utils.ToolTipController ttPersonnell;
	private BarButtonItem btnCaptureCopy;
	private BarCheckItem chkCaptureCopy;
	private RibbonPageGroup RibbonPageGroup69;
	private BarButtonItem btnViewOverview;
	private BarButtonItem btnCasualtySummary;
	private BarButtonItem btnAmbulanceControl;
	private BarButtonItem BarButtonItem22;
	private RibbonPageGroup RibbonPageGroup4;
	private BarButtonItem BarButtonItem23;
	private BarSubItem btnGovReporting;
	private BarButtonItem btnGovReportOverview;
	private BarButtonItem btnGovReportDetails;
	private BarButtonItem btnGovShowApplicable;
	private RibbonPageGroup RibbonPageGroup70;
	private BarButtonItem btnPaid;
	private DevExpress.Utils.ImageCollection imgTree;
	private BarStaticItem br64;
	private BarButtonItem BarButtonItem1;
	private BarSubItem BarSubItem8;
	private BarButtonItem btnGovApplicapable;
	private BarButtonItem btnGovNotApplicable;
	private BarButtonItem btnClinicalKPI;
	private BarButtonItem btnBatchImport;
	private BarButtonItem btnGoToToday;
	private BarButtonItem btnZoomIn;
	private BarButtonItem BtnZoomOut;
	private BarButtonItem BarButtonItem27;
	private RibbonPageGroup RibbonPageGroup18;
	private BarButtonItem BarButtonItem24;
	private BarButtonItem btnPhonebook;
	private BarButtonItem BarButtonItem25;
	private BarButtonItem BarButtonItem26;
	private BarButtonItem btnIndentRow;
	private BarButtonItem btnPrintGovList;
	private BarCheckItem btnGroupColour;
	private BarToggleSwitchItem BarToggleSwitchItem1;
	private BarButtonItem btnClearTreeFilter;
	private SkinDropDownButtonItem SkinDropDownButtonItem1;
	private BarButtonItem btnViewGroupStandards;
	private BarButtonItem btnCopyFiles;
	private BarButtonItem btnOpenFolder;
	private BarButtonItem btnCopyStandards;
	private BarButtonItem btnShowGroupSummary;
	private BarButtonItem btnTrainingAction;
	private BarButtonItem btnCopyCol;
	private DevExpress.XtraScheduler.SchedulerDataStorage schStorageMedics;
	private BindingSource PersonAvailBindingSource;
	private PersonnellDataSetTableAdapters.PersonAvailTableAdapter tt;
	private BarButtonItem BarButtonItem28;
	private BarButtonItem btnAvailabilityPerson;
	private RibbonPageGroup RibbonPageGroup71;
	private DevExpress.XtraScheduler.UI.SwitchToDayViewItem SwitchToDayViewItem1;
	private DevExpress.XtraScheduler.UI.SwitchToWorkWeekViewItem SwitchToWorkWeekViewItem1;
	private DevExpress.XtraScheduler.UI.SwitchToWeekViewItem SwitchToWeekViewItem1;
	private DevExpress.XtraScheduler.UI.SwitchToFullWeekViewItem SwitchToFullWeekViewItem1;
	private DevExpress.XtraScheduler.UI.SwitchToMonthViewItem SwitchToMonthViewItem1;
	private DevExpress.XtraScheduler.UI.SwitchToTimelineViewItem SwitchToTimelineViewItem1;
	private DevExpress.XtraScheduler.UI.SwitchToGanttViewItem SwitchToGanttViewItem1;
	private DevExpress.XtraScheduler.UI.SwitchToAgendaViewItem SwitchToAgendaViewItem1;
	private DevExpress.XtraScheduler.UI.SwitchTimeScalesItem SwitchTimeScalesItem1;
	private DevExpress.XtraScheduler.UI.ChangeScaleWidthItem ChangeScaleWidthItem1;
	private DevExpress.XtraScheduler.UI.SwitchTimeScalesCaptionItem SwitchTimeScalesCaptionItem1;
	private DevExpress.XtraScheduler.UI.SwitchCompressWeekendItem SwitchCompressWeekendItem1;
	private DevExpress.XtraScheduler.UI.SwitchShowWorkTimeOnlyItem SwitchShowWorkTimeOnlyItem1;
	private DevExpress.XtraScheduler.UI.SwitchCellsAutoHeightItem SwitchCellsAutoHeightItem1;
	private DevExpress.XtraScheduler.UI.ChangeSnapToCellsUIItem ChangeSnapToCellsUIItem1;
	private DevExpress.XtraScheduler.UI.ViewRibbonPage ViewRibbonPage1;
	private DevExpress.XtraScheduler.UI.ActiveViewRibbonPageGroup ActiveViewRibbonPageGroup1;
	private DevExpress.XtraScheduler.UI.TimeScaleRibbonPageGroup TimeScaleRibbonPageGroup1;
	private DevExpress.XtraScheduler.UI.LayoutRibbonPageGroup LayoutRibbonPageGroup1;
	private DevExpress.Utils.ToolTipController ttScheduler;
	private BarButtonItem btnGovFindAll;
	private BarButtonItem btnGovTemplate;
	private DevExpress.XtraScheduler.SchedulerDataStorage schInstructors;
	private BindingSource InstructorAvailabilityBindingSource;
	private PersonnellDataSetTableAdapters.INstructorAvailabilityTableAdapter INstructorAvailabilityTableAdapter;
	private BarButtonItem BarButtonItem8;
	private BarSubItem btnReplyWith;
	private DevExpress.Utils.ImageCollection ImageCollection1;
	private AssetDataSetTableAdapters.Asset_ShiftTableAdapter Asset_ShiftTableAdapter;
	private AssetDataSet AssetDataSet;
	private BindingSource AssetShiftBindingSource;
	private BarButtonItem btnFlag;
	private PopupMenu PopupMenu5;
	private BarEditItem BarEditItem7;
	private BarButtonItem btnImportInvoices;
	private RibbonPageGroup RibbonPageGroup72;
	private BarToggleSwitchItem btnFindAfterDrag;
	private BarButtonItem btn100Percent;
	private NavBarItem nvMyDashBoard;
	private NavBarItem nvReportCentre;
	private NavBarItem nvVehicles;
	private BarButtonItem btnTaskCompleted;
	private BarButtonItem btnOpenFileLocation;
	private BarButtonItem btnFlaggedReport;
	private RibbonPage rbnFlagged;
	private RibbonPageGroup RibbonPageGroup36;
	private DevExpress.XtraScheduler.SchedulerControl schWebView;
	private XtraTabControl tbDashboard;
	private XtraTabPage tabMyHome;
	private DevExpress.XtraBars.Navigation.TabPane TabPane1;
	private DevExpress.XtraBars.Navigation.TabNavigationPage TabNavigationPage3;
	private SplitContainerControl SplitContainerControl3;
	private DevExpress.XtraTreeList.TreeList TaskTree;
	private GridControl EmailGridControl;
	private GridView grdMyInbox;
	private GridColumn GridColumn14;
	private GridColumn GridColumn30;
	private GridColumn colSeen;
	private GridColumn GridColumn4;
	private GridColumn GridColumn5;
	private RepositoryItemCheckEdit RepositoryItemCheckEdit9;
	private GridColumn GridColumn6;
	private RepositoryItemImageComboBox RepositoryItemImageComboBox1;
	private RepositoryItemCheckEdit RepositoryItemCheckEdit10;
	private GridColumn GridColumn8;
	private GridColumn GridColumn9;
	private GridColumn GridColumn10;
	private GridColumn GridColumn11;
	private GridColumn GridColumn12;
	private RepositoryItemRichTextEdit RepositoryItemRichTextEdit1;
	private GridColumn GridColumn13;
	private XtraTabPage tabCalendar;
	private SplitContainerControl SplitContainerControl4;
	private DevExpress.XtraScheduler.SchedulerControl schCourses;
	private XtraTabPage tabTraining;
	private GridControl TrainingGrid;
	private GridView TrainingGridView;
	private GridColumn colID;
	private GridColumn colInstructor;
	private GridColumn colStudents;
	private GridColumn colCourse;
	private GridColumn colLocation;
	private GridColumn colExternalRef;
	private GridColumn colStatus;
	private GridColumn colCourseContact;
	private GridColumn colCompany;
	private GridColumn colCourseTime;
	private GridColumn colPath;
	private GridColumn colTimeStamp;
	private GridColumn colTableSort;
	private GridColumn GridColumn1;
	private GridColumn colNotEmail;
	private GridColumn colKPI;
	private GridColumn colFlag;
	private GridColumn colIntRef;
	private GridColumn colDateofCourse;
	private GridColumn colNCR;
	private RepositoryItemColorEdit RepositoryItemColorEdit1;
	private RepositoryItemCalcEdit RepositoryItemCalcEdit1;
	private XtraTabPage tabClinical;
	private GridControl ClincalGridControl;
	private GridColumn colID1;
	private GridColumn colShiftAttending;
	private GridColumn colLocation1;
	private GridColumn colDutyType;
	private GridColumn colNotes;
	private GridColumn colAR;
	private GridColumn colExpID;
	private GridColumn colStatus1;
	private GridColumn colHours;
	private GridColumn colDutyDate;
	private GridColumn colRecords;
	private GridColumn colRecordCreated;
	private GridColumn colCreatedBY;
	private GridColumn colRecordClosed;
	private GridColumn colLinkID;
	private GridColumn colTimeStamp1;
	private GridColumn colShiftSheet;
	private GridColumn colAddType;
	private GridColumn colShiftSheetReceived;
	private GridColumn colNotified;
	private GridColumn colPO;
	private GridColumn colHaveShiftSheet;
	private GridColumn colNotEmail1;
	private GridColumn colMedicID;
	private GridColumn colPin;
	private GridColumn colRole;
	private GridColumn colTableSort1;
	private GridColumn colPath1;
	private GridColumn colTemp;
	private GridColumn colStart;
	private GridColumn colFinish;
	private GridColumn colShiftscol;
	private GridColumn colLicenceExpiry;
	private GridColumn colCPGVersion;
	private GridColumn colInvoice;
	private GridColumn colOrgExport;
	private GridColumn colFlag1;
	private XtraTabPage tabLeads;
	private GridControl ActivitiesGridControl;
	private GridView LeadsGrid;
	private GridColumn colID4;
	private GridColumn colAName;
	private GridColumn colType;
	private GridColumn colDue;
	private GridColumn colTimeStamp3;
	private GridColumn colComplete;
	private GridColumn colContactID;
	private GridColumn colAssignedTo;
	private GridColumn colPriority;
	private GridColumn colCreated;
	private GridColumn colCreatedBy1;
	private GridColumn colMemo;
	private GridColumn colValue;
	private GridColumn colStage;
	private GridColumn colExp;
	private GridColumn colPhone;
	private GridColumn colEmail2;
	private RepositoryItemCheckEdit RepositoryItemCheckEdit3;
	private GridColumn colOrg;
	private GridColumn colRef;
	private GridColumn colEmailMemo;
	private GridColumn colSource;
	private GridColumn colLeadSeen;
	private GridColumn colActivitiescol;
	private XtraTabPage tabGovernance;
	private SplitContainerControl SplitContainerControl2;
	private DevExpress.XtraTreeList.TreeList TreeList1;
	private DevExpress.XtraTreeList.Columns.TreeListColumn colSection;
	private RepositoryItemTextEdit RepositoryItemTextEdit4;
	private DevExpress.XtraTreeList.Columns.TreeListColumn colSort;
	private DevExpress.XtraTreeList.Columns.TreeListColumn colTimestamp4;
	private DevExpress.XtraTreeList.Columns.TreeListColumn colImage;
	private DevExpress.XtraTreeList.Columns.TreeListColumn colType1;
	private DevExpress.XtraTreeList.Columns.TreeListColumn colItemRef;
	private DevExpress.XtraTreeList.Columns.TreeListColumn colFixed1;
	private DevExpress.XtraTreeList.Columns.TreeListColumn colID13;
	private DevExpress.XtraTreeList.Columns.TreeListColumn colCompleted;
	private SplitContainerControl SplitContainerControl5;
	private GridControl GovStandardsGridControl;
	private GridView GovGrid;
	private GridColumn colParent;
	private GridColumn GridColumn31;
	private GridColumn colReviewDate1;
	private GridColumn colBody;
	private GridColumn colScope;
	private GridColumn colReference;
	private GridColumn colStatement;
	private GridColumn colTheme;
	private GridColumn colPercent;
	private GridColumn colType2;
	private GridColumn colStatus2;
	private GridColumn GridColumn15;
	private GridColumn colPath2;
	private GridColumn colIncluded;
	private GridColumn colID14;
	private GridColumn colKocked;
	private MemoEdit txtGovInfo;
	private XtraTabPage tabNotes;
	private GridControl BusinessNotesGridControl;
	private XtraTabPage tabTasks;
	private GridControl TasksGridControl;
	private GridView GridView3;
	private GridColumn colID6;
	private GridColumn colName;
	private GridColumn colPID;
	private GridColumn colDue1;
	private GridColumn colFreq;
	private GridColumn colPriority1;
	private GridColumn colNotes1;
	private GridColumn colPolicy;
	private GridColumn colTimeStamp5;
	private GridColumn colEstTime;
	private GridColumn colOwnerType;
	private GridColumn colOwnerID;
	private GridColumn colStartDate;
	private GridColumn colSystemTaskscol;
	private GridColumn colAutoTask;
	private GridColumn colProcName;
	private GridColumn colFrmName;
	private GridColumn colCmdName;
	private GridColumn colActionType;
	private XtraTabPage tabRisk;
	private DevExpress.XtraLayout.LayoutControl LayoutControl1;
	private DevExpress.XtraCharts.ChartControl ChartControl2;
	private DevExpress.XtraCharts.ChartControl ChartControl3;
	private DevExpress.XtraCharts.ChartControl ChartControl1;
	private GridControl RisksGridControl;
	private GridView GridView11;
	private GridColumn colID8;
	private GridColumn colRisk;
	private GridColumn colLikelihood;
	private GridColumn colImpact;
	private GridColumn colRiskClass;
	private GridColumn colRiskScore;
	private GridColumn colRiskOwner;
	private GridColumn colPriority2;
	private GridColumn colStatus4;
	private GridColumn colBusinessArea;
	private GridColumn colAffectedParty;
	private GridColumn colIdentified;
	private GridColumn colMitigationLevel;
	private GridColumn colReviewDate;
	private GridColumn colTimeStamp6;
	private GridColumn colCategory1;
	private RepositoryItemLookUpEdit RepositoryItemLookUpEdit4;
	private DevExpress.XtraLayout.LayoutControlGroup LayoutControlGroup1;
	private DevExpress.XtraLayout.LayoutControlItem LayoutControlItem1;
	private DevExpress.XtraLayout.LayoutControlItem LayoutControlItem2;
	private DevExpress.XtraLayout.LayoutControlItem LayoutControlItem4;
	private DevExpress.XtraLayout.LayoutControlItem LayoutControlItem3;
	private XtraTabPage tabDocuments;
	private GridControl DocumentsGridControl;
	private GridView GridView10;
	private GridColumn GridColumn29;
	private GridColumn colID7;
	private GridColumn colPath3;
	private GridColumn colCategory;
	private GridColumn colCreatedBy3;
	private GridColumn colDescription;
	private GridColumn colExtRef;
	private GridColumn colOwner;
	private GridColumn colDocDate;
	private GridColumn colStatus3;
	private GridColumn colAuthor;
	private GridColumn colType3;
	private GridColumn colSender;
	private GridColumn colFileStatus;
	private XtraTabPage tabAudit;
	private GridControl AuditGridControl;
	private GridView grdAudit;
	private GridColumn colID10;
	private GridColumn colType5;
	private GridColumn colAuditor;
	private GridColumn colDate;
	private GridColumn colVerifier;
	private GridColumn colPolicy1;
	private GridColumn colScope1;
	private GridColumn GridColumn28;
	private GridColumn colFilePath;
	private GridColumn colTimeStamp8;
	private GridColumn colStatus5;
	private GridColumn colNotes2;
	private GridColumn GridColumn25;
	private XtraTabPage tabFlagged;
	private DevExpress.XtraLayout.LayoutControl LayoutControl2;
	private DevExpress.XtraCharts.ChartControl ChartControl6;
	private DevExpress.XtraCharts.ChartControl ChartControl5;
	private DevExpress.XtraCharts.ChartControl ChartControl4;
	private GridControl GridControl1;
	private GridView grdFlagged;
	private GridColumn colID12;
	private GridColumn colItemID;
	private GridColumn colItemType;
	private GridColumn colItemPerson;
	private GridColumn colRootCause;
	private GridColumn colItemDate;
	private GridColumn colActionDate;
	private GridColumn colStatus6;
	private GridColumn colCreated2;
	private GridColumn colTimeStamp9;
	private GridColumn colLevel;
	private GridColumn GridColumn17;
	private GridColumn colSource1;
	private DevExpress.XtraLayout.LayoutControlGroup LayoutControlGroup2;
	private DevExpress.XtraLayout.LayoutControlItem LayoutControlItem5;
	private DevExpress.XtraLayout.LayoutControlItem LayoutControlItem6;
	private DevExpress.XtraLayout.LayoutControlItem LayoutControlItem7;
	private DevExpress.XtraLayout.LayoutControlItem LayoutControlItem8;
	private DevExpress.XtraLayout.SplitterItem SplitterItem1;
	private DevExpress.XtraLayout.SplitterItem SplitterItem3;
	private DevExpress.XtraLayout.SplitterItem SplitterItem4;
	private SkinRibbonGalleryBarItem SkinRibbonGalleryBarItem3;
	private SkinPaletteRibbonGalleryBarItem SkinPaletteRibbonGalleryBarItem3;
	private NavBarItem nvNotes;
	private DevExpress.XtraGrid.Views.Tile.TileView TileView1;
	private TileViewColumn colID5;
	private TileViewColumn colTitle;
	private TileViewColumn colBody1;
	private TileViewColumn colCreatedBy2;
	private TileViewColumn colCreatedTime;
	private TileViewColumn colModified;
	private BarButtonItem BarButtonItem29;
	private RibbonPage rbnNotes;
	private RibbonPageGroup RibbonPageGroup40;
	private NavBarItem nvTaskList;
	private XtraTabPage tabTaskList;
	private GridControl GridControl2;
	private GridView GridView2;
	private BM.MainDataSetTableAdapters.TaskListTableAdapter TaskListTableAdapter;
	private BindingSource TaskListBindingSource;
	private GridColumn colID3;
	private GridColumn colStandard;
	private GridColumn colRef1;
	private GridColumn colFindings;
	private GridColumn colRA;
	private GridColumn colPerson;
	private GridColumn colTimeStamp2;
	private BarButtonItem BarButtonItem30;
	private RibbonPage rbnTaskList;
	private RibbonPageGroup RibbonPageGroup46;
	private RepositoryItemHypertextLabel RepositoryItemHypertextLabel1;
	private GridColumn colStatus7;
	private GridColumn colCategory2;
	private BarButtonItem btnValidateFiles;
	private RepositoryItemCheckEdit RepositoryItemCheckEdit11;
	private RepositoryItemHyperLinkEdit RepositoryItemHyperLinkEdit15;
	private RepositoryItemCheckEdit RepositoryItemCheckEdit8;
	private RepositoryItemCheckEdit repShowInactive;
	private RepositoryItemTextEdit RepositoryItemTextEdit2;
	private RepositoryItemLookUpEdit repByCourse;
	private RepositoryItemMemoEdit RepositoryItemMemoEdit1;
	private RepositoryItemLookUpEdit RepositoryItemLookUpEdit2;
	private RepositoryItemTextEdit RepositoryItemTextEdit3;
	private DevExpress.XtraScheduler.UI.RepositoryItemDuration RepositoryItemDuration1;
	private RepositoryItemZoomTrackBar RepositoryItemZoomTrackBar1;
	private RepositoryItemSpinEdit RepositoryItemSpinEdit2;
	private RepositoryItemComboBox RepositoryItemComboBox1;
	private RepositoryItemHyperLinkEdit RepositoryItemHyperLinkEdit6;
	private RepositoryItemCheckEdit RepositoryItemCheckEdit2;
	private RepositoryItemCheckEdit RepositoryItemCheckEdit1;
	private RepositoryItemHyperLinkEdit RepositoryItemHyperLinkEdit19;
	private RepositoryItemCheckEdit RepositoryItemCheckEdit19;
	private RepositoryItemHyperLinkEdit RepositoryItemHyperLinkEdit7;
	private RepositoryItemDateEdit RepositoryItemDateEdit1;
	private RepositoryItemCheckEdit RepositoryItemCheckEdit4;
	private RepositoryItemLookUpEdit RepositoryItemLookUpEdit1;
	private RepositoryItemHyperLinkEdit RepositoryItemHyperLinkEdit14;
	private RepositoryItemLookUpEdit RepositoryItemLookUpEdit3;
	private RepositoryItemImageComboBox RepositoryItemImageComboBox2;
	private RepositoryItemCheckEdit RepositoryItemCheckEdit12;
	private RepositoryItemCheckEdit RepositoryItemCheckEdit13;
	private RepositoryItemCheckEdit RepositoryItemCheckEdit16;
	private RepositoryItemLookUpEdit RepositoryItemLookUpEdit5;
	private RepositoryItemRichTextEdit RepositoryItemRichTextEdit2;
	private RepositoryItemHyperLinkEdit RepositoryItemHyperLinkEdit9;
	private RepositoryItemImageComboBox RepositoryItemImageComboBox3;
	private RepositoryItemCheckEdit RepositoryItemCheckEdit18;
	private RepositoryItemHyperLinkEdit RepositoryItemHyperLinkEdit13;
	private RepositoryItemHyperLinkEdit RepositoryItemHyperLinkEdit17;
	private RepositoryItemHyperLinkEdit RepositoryItemHyperLinkEdit18;
	private RepositoryItemCheckEdit RepositoryItemCheckEdit20;
	private RepositoryItemLookUpEdit RepositoryItemLookUpEdit6;
	private BarButtonItem btnWebImport;
	private GridColumn colResponsible;
	private BarButtonItem BarButtonItem31;
	private RibbonPageGroup RibbonPageGroup50;
	private BarButtonItem btnCleanGPS;
	private RepositoryItemImageComboBox repFlaggedCategory;
	private SvgImageCollection svgFlagged;
	private RepositoryItemLookUpEdit RepositoryItemLookUpEdit8;
	private GridColumn colNotifiable;
	private GridColumn colActionBy;
	private BindingSource PersonnellBindingSource2;
	private BarButtonItem btnFlag_Add;
	private RibbonPageGroup RibbonPageGroup52;
	private GridColumn colResult;
	private RepositoryItemRatingControl RepositoryItemRatingControl1;
	private BarButtonItem btnRiskRecategorise;
	private RibbonPageGroup RibbonPageGroup59;
	private RibbonPageGroup RibbonPageGroup63;
	private GridColumn colViewDocument;
	private RepositoryItemCheckEdit RepositoryItemCheckEdit6;
	private RibbonGalleryBarItem RibbonGalleryBarItem1;
	private RibbonGalleryBarItem RibbonGalleryBarItem2;
	// Friend WithEvents CustomInstaller1 As MySql.Data.MySqlClient.CustomInstaller
	private GridColumn colCourseType;
	private NavBarItem nvProjects;
	private NavBarItem nvQuality;
	private NavBarItem nvFeedback;
	private RepositoryItemCheckEdit RepositoryItemCheckEdit7;
	private GridColumn colSP;
	private GridColumn colNotEmail2;
	private GridColumn colCert;
	private GridColumn colIV;
	private RepositoryItemCheckEdit RepositoryItemCheckEdit14;
	private BM.MainDataSetTableAdapters.TableAdapterManager TableAdapterManager2;
	private RibbonGalleryBarItem RibbonGalleryBarItem3;
	private RibbonGalleryBarItem RibbonGalleryBarItem4;
	private GalleryDropDown GalleryDropDown2;
	private BM.Clinical.ClinicalData ClinicalDataSet;
	private RibbonPageGroup RibbonPageGroup74;
	private RibbonGalleryBarItem rbnViewGallery;
	private RibbonGalleryBarItem RibbonGalleryBarItem5;
	private BarStaticItem brLocale;
	private BarButtonItem BtnCheckInvoice;
	private RibbonPageGroup RibbonPageGroup73;
	private BarButtonItem btnSendMattermost;
	private GridColumn colClient;
	private BarButtonItem btnValidateShifts;
	private BarButtonItem btnPersonValidate;
	private GridView ClinicalGridView;
	private GridColumn colOrg1;
	private BarButtonItem btnRiskRegister;
	private BarButtonItem BarButtonItem2;
	private BarButtonItem BtnColourGroupRow;
	private GridColumn colPrice;
	private GridColumn colInvoiceType;
	private RibbonPageCategory RibbonPageCategory1;
	private PopupMenu PopupMenu1;
	private PopupMenu PopupMenu2;
	private PopupMenu PopupMenu3;
	private PopupMenu PopupMenu4;
	private PopupMenu PopupMenu6;
	private PopupMenu PopupMenu7;
	private PopupMenu PopupMenu8;
	private PopupMenu PopupMenu9;
	private BarButtonItem btnBugFile;
    private RepositoryItemLookUpEdit repositoryItemLookUpEdit7;
    private BindingSource shiftsBindingSource;
    private BM.Clinical.ClinicalDataTableAdapters.ShiftsTableAdapter shiftsTableAdapter;
    #endregion

    private BindingSource courseListBindingSource;
    private BM.Training.TrainDataSet trainDataSet;
    private BM.Training.TrainDataSetTableAdapters.CourseListTableAdapter courseListTableAdapter;
};
