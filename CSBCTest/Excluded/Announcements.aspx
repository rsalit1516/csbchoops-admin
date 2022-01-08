
<%@ Page Language="VB" MasterPageFile="~/CSBCAdminMasterPage.master" AutoEventWireup="false" CodeFile="Announcements.aspx.vb" Inherits="Announcements" title="Emails" %>

<%@ Register TagPrefix="ighedit" Namespace="Infragistics.WebUI.WebHtmlEditor" Assembly="Infragistics2.WebUI.WebHtmlEditor.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

	<script id="Infragistics" type="text/javascript">
<!--

function grdMembers_DELETE(gridName, cellId){
	//Add code to handle your event here.
}
// -->
</script>

  
	<table style="width: 371px; height: 123px">
		<tr>
			<td align="left">
				<asp:Label ID="lblFromCaption" runat="server" Text="From:" Width="86px"></asp:Label></td>
			<td align="left" style="width: 181px">
				<asp:Label ID="lblFrom" runat="server" Width="294px"></asp:Label></td>
			<td align="left" style="width: 222px">
				&nbsp;</td>
			<td align="right" style="width: 24px">
				<asp:Button ID="btnSend" runat="server" Text="Send" Width="90px" TabIndex="4" /></td>
		</tr>
		<tr>
			<td align="left">
				<asp:Label ID="lblTo" runat="server" Text="To:" Width="86px"></asp:Label></td>
			<td align="left" style="width: 181px">
				<asp:DropDownList ID="cboTo" runat="server" Font-Bold="True" TabIndex="1" Width="299px" AutoPostBack="True">
					<asp:ListItem Value="0">Board Members</asp:ListItem>
					<asp:ListItem Value="1">Season Candidates Only</asp:ListItem>
					<asp:ListItem Value="2">Season Players</asp:ListItem>
					<asp:ListItem Value="3">Season Coaches/Sponsors</asp:ListItem>
					<asp:ListItem Value="4">Members(All seasons)</asp:ListItem>
				</asp:DropDownList></td>
			<td align="left" style="width: 222px">
			</td>
			<td align="right" style="width: 24px">
				</td>
		</tr>
		<tr>
			<td align="left">
				<asp:Label ID="lblSubject" runat="server" Text="Subject:" Width="86px"></asp:Label></td>
			<td align="left" style="width: 181px">
				<asp:TextBox ID="txtSubject" runat="server" Width="294px" TabIndex="2" Font-Bold="True"></asp:TextBox></td>
			<td align="left" style="width: 222px">
				</td>
			<td style="width: 24px" align="right">
				</td>
		</tr>
		<tr>
			<td align="left" style="height: 22px">
				<asp:Label ID="lblUsernameCaption" runat="server" Text="Content:" Width="86px"></asp:Label></td>
			<td style="width: 181px; height: 22px" align="left">
				</td>
			<td style="width: 222px; height: 22px">
			</td>
			<td align="center" rowspan="3" style="width: 24px" valign="top">
				</td>
		</tr>
		<tr>
			<td align="left" colspan="2" rowspan="3" valign="top">
				<ighedit:WebHtmlEditor ID="htmlMail" runat="server" BackgroundImageName=""
					FontFormattingList="Heading 1=<h1>&Heading 2=<h2>&Heading 3=<h3>&Heading 4=<h4>&Heading 5=<h5>&Normal=<p>"
					FontNameList="Arial,Verdana,Tahoma,Courier New,Georgia" FontSizeList="1,2,3,4,5,6,7"
					FontStyleList="Blue Underline=color:blue;text-decoration:underline;&Red Bold=color:red;font-weight:bold;&ALL CAPS=text-transform:uppercase;&all lowercase=text-transform:lowercase;&Reset="
					Height="266px" SpecialCharacterList="&#937;,&#931;,&#916;,&#934;,&#915;,&#936;,&#928;,&#920;,&#926;,&#923;,&#958;,&#956;,&#951;,&#966;,&#969;,&#949;,&#952;,&#948;,&#950;,&#968;,&#946;,&#960;,&#963;,&szlig;,&thorn;,&THORN;,&#402,&#1046;,&#1064;,&#1070;,&#1071;,&#1078;,&#1092;,&#1096;,&#1102;,&#1103;,&#12362;,&#12354;,&#32117;,&AElig;,&Aring;,&Ccedil;,&ETH;,&Ntilde;,&Ouml;,&aelig;,&aring;,&atilde;,&ccedil;,&eth;,&euml;,&ntilde;,&cent;,&pound;,&curren;,&yen;,&#8470;,&#153;,&copy;,&reg;,&#151;,@,&#149;,&iexcl;,&#14;,&#8592;,&#8593;,&#8594;,&#8595;,&#8596;,&#8597;,&#8598;,&#8599;,&#8600;,&#8601;,&#18;,&brvbar;,&sect;,&uml;,&ordf;,&not;,&macr;,&para;,&deg;,&plusmn;,&laquo;,&raquo;,&middot;,&cedil;,&ordm;,&sup1;,&sup2;,&sup3;,&frac14;,&frac12;,&frac34;,&iquest;,&times;,&divide;"
					TabStripDisplay="False" UseLineBreak="True" Width="388px" TabIndex="3" ImageDirectory="images/htmleditor/">
					<Toolbar Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
						Font-Underline="False">
						<ighedit:ToolbarImage runat="server" Font-Bold="False" Font-Italic="False" Font-Overline="False"
							Font-Strikeout="False" Font-Underline="False" Type="DoubleSeparator" />
						<ighedit:ToolbarButton runat="server" Font-Bold="False" Font-Italic="False" Font-Overline="False"
							Font-Strikeout="False" Font-Underline="False" Type="Bold" />
						<ighedit:ToolbarButton runat="server" Font-Bold="False" Font-Italic="False" Font-Overline="False"
							Font-Strikeout="False" Font-Underline="False" Type="Italic" />
						<ighedit:ToolbarButton runat="server" Font-Bold="False" Font-Italic="False" Font-Overline="False"
							Font-Strikeout="False" Font-Underline="False" Type="Underline" />
						<ighedit:ToolbarImage runat="server" Font-Bold="False" Font-Italic="False" Font-Overline="False"
							Font-Strikeout="False" Font-Underline="False" Type="Separator" />
						<ighedit:ToolbarButton runat="server" Font-Bold="False" Font-Italic="False" Font-Overline="False"
							Font-Strikeout="False" Font-Underline="False" Type="JustifyLeft" />
						<ighedit:ToolbarButton runat="server" Font-Bold="False" Font-Italic="False" Font-Overline="False"
							Font-Strikeout="False" Font-Underline="False" Type="JustifyCenter" />
						<ighedit:ToolbarButton runat="server" Font-Bold="False" Font-Italic="False" Font-Overline="False"
							Font-Strikeout="False" Font-Underline="False" Type="JustifyRight" />
						<ighedit:ToolbarButton runat="server" Font-Bold="False" Font-Italic="False" Font-Overline="False"
							Font-Strikeout="False" Font-Underline="False" Type="JustifyFull" />
						<ighedit:ToolbarImage runat="server" Font-Bold="False" Font-Italic="False" Font-Overline="False"
							Font-Strikeout="False" Font-Underline="False" Type="Separator" />
						<ighedit:ToolbarButton runat="server" Font-Bold="False" Font-Italic="False" Font-Overline="False"
							Font-Strikeout="False" Font-Underline="False" Type="UnorderedList" />
						<ighedit:ToolbarButton runat="server" Font-Bold="False" Font-Italic="False" Font-Overline="False"
							Font-Strikeout="False" Font-Underline="False" Type="OrderedList" />
						<ighedit:ToolbarText runat="server" Font-Bold="False" Font-Italic="False" Font-Overline="False"
							Font-Strikeout="False" Font-Underline="False" Type="Break" />
						<ighedit:ToolbarDialogButton runat="server" Font-Bold="False" Font-Italic="False"
							Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Type="FontColor">
							<Dialog Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
								Font-Underline="False" />
						</ighedit:ToolbarDialogButton>
						<ighedit:ToolbarDialogButton runat="server" Font-Bold="False" Font-Italic="False"
							Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Type="FontHighlight">
							<Dialog Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
								Font-Underline="False" />
						</ighedit:ToolbarDialogButton>
						<ighedit:ToolbarImage runat="server" Font-Bold="False" Font-Italic="False" Font-Overline="False"
							Font-Strikeout="False" Font-Underline="False" Type="Separator" />
						<ighedit:ToolbarButton runat="server" Font-Bold="False" Font-Italic="False" Font-Overline="False"
							Font-Strikeout="False" Font-Underline="False" Type="Preview" />
						<ighedit:ToolbarImage runat="server" Font-Bold="False" Font-Italic="False" Font-Overline="False"
							Font-Strikeout="False" Font-Underline="False" Type="Separator" />
						<ighedit:ToolbarDropDown runat="server" Font-Bold="False" Font-Italic="False" Font-Overline="False"
							Font-Strikeout="False" Font-Underline="False" Type="FontName">
						</ighedit:ToolbarDropDown>
						<ighedit:ToolbarDropDown runat="server" Font-Bold="False" Font-Italic="False" Font-Overline="False"
							Font-Strikeout="False" Font-Underline="False" Type="FontSize">
						</ighedit:ToolbarDropDown>
					</Toolbar>
					<DropDownStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
						Font-Underline="False" />
					<ProgressBar Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
						Font-Underline="False" />
					<DownlevelTextArea Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
						Font-Underline="False" />
					<RightClickMenu Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
						Font-Underline="False">
						<ighedit:HtmlBoxMenuItem runat="server" Act="Cut" Font-Bold="False" Font-Italic="False"
							Font-Overline="False" Font-Strikeout="False" Font-Underline="False">
							<Dialog Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
								Font-Underline="False" />
						</ighedit:HtmlBoxMenuItem>
						<ighedit:HtmlBoxMenuItem runat="server" Act="Copy" Font-Bold="False" Font-Italic="False"
							Font-Overline="False" Font-Strikeout="False" Font-Underline="False">
							<Dialog Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
								Font-Underline="False" />
						</ighedit:HtmlBoxMenuItem>
						<ighedit:HtmlBoxMenuItem runat="server" Act="Paste" Font-Bold="False" Font-Italic="False"
							Font-Overline="False" Font-Strikeout="False" Font-Underline="False">
							<Dialog Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
								Font-Underline="False" />
						</ighedit:HtmlBoxMenuItem>
						<ighedit:HtmlBoxMenuItem runat="server" Act="PasteHtml" Font-Bold="False" Font-Italic="False"
							Font-Overline="False" Font-Strikeout="False" Font-Underline="False">
							<Dialog Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
								Font-Underline="False" />
						</ighedit:HtmlBoxMenuItem>
						<ighedit:HtmlBoxMenuItem runat="server" Act="CellProperties" Font-Bold="False" Font-Italic="False"
							Font-Overline="False" Font-Strikeout="False" Font-Underline="False">
							<Dialog Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
								Font-Underline="False" InternalDialogType="CellProperties" />
						</ighedit:HtmlBoxMenuItem>
						<ighedit:HtmlBoxMenuItem runat="server" Act="TableProperties" Font-Bold="False" Font-Italic="False"
							Font-Overline="False" Font-Strikeout="False" Font-Underline="False">
							<Dialog Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
								Font-Underline="False" InternalDialogType="ModifyTable" />
						</ighedit:HtmlBoxMenuItem>
						<ighedit:HtmlBoxMenuItem runat="server" Act="InsertImage" Font-Bold="False" Font-Italic="False"
							Font-Overline="False" Font-Strikeout="False" Font-Underline="False">
							<Dialog Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
								Font-Underline="False" />
						</ighedit:HtmlBoxMenuItem>
					</RightClickMenu>
					<TextWindow Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
						Font-Underline="False" />
					<DownlevelLabel Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
						Font-Underline="False" />
					<TabStrip Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
						Font-Underline="False" />
				</ighedit:WebHtmlEditor>
			</td>
			<td style="width: 222px; height: 22px">
				</td>
		</tr>
		<tr>
			<td align="right" style="width: 222px">
				<asp:Label ID="Label1" runat="server" Text="Recipients" Width="86px"></asp:Label></td>
		</tr>
		<tr>
			<td align="left" colspan="2" valign="top" style="height: 279px">
				<asp:ListBox ID="lstEmails" runat="server" Height="280px" SelectionMode="Multiple"
					Width="330px" Font-Size="Small" Font-Names="Courier New"></asp:ListBox></td>
		</tr>
		<tr>
			<td align="left" colspan="4" valign="top">
				<asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Red" Width="600px"></asp:Label></td>
		</tr>
	</table>
</asp:Content>



