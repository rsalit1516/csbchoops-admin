
function writeActxViewer(sViewerVer, sProductLang, sPreferredViewingLang, bDrillDown, bExport, bDisplayGroupTree, 
						bGroupTree, bAnimation, bPrint, bRefresh, bSearch, 
						bZoom, bSearchExpert, bSelectExpert, sParamVer) {
	document.write("<OBJECT ID=\"CRViewer\"");
	document.write("CLASSID=\"CLSID:DCFEDB58-DB3F-4DEB-A4C4-D8107FBBDAC3\"");
	document.write("WIDTH=\"100%\" HEIGHT=\"99%\"");
	document.write("CODEBASE=\"" + gPath + viewerPath + "ActiveXControls/ActiveXViewer.cab#Version=" + sViewerVer + "\">");
	document.write("<PARAM NAME=\"LocaleID\" VALUE=\"" + sProductLang + "\">");
	document.write("<PARAM NAME=\"PreferredViewingLocaleID\" VALUE=\"" + sPreferredViewingLang + "\">");
	document.write("<PARAM NAME=\"EnableDrillDown\" VALUE=" + bDrillDown + ">");
	document.write("<PARAM NAME=\"EnableExportButton\" VALUE=" + bExport + ">");
	document.write("<PARAM NAME=\"DisplayGroupTree\" VALUE=" + bDisplayGroupTree + ">");
	
	document.write("<PARAM NAME=\"EnableGroupTree\" VALUE=" + bGroupTree +">");
	document.write("<PARAM NAME=\"EnableAnimationControl\" VALUE=" + bAnimation + ">");
	document.write("<PARAM NAME=\"EnablePrintButton\" VALUE=" + bPrint + ">");
	document.write("<PARAM NAME=\"EnableRefreshButton\" VALUE=" + bRefresh + ">");
	document.write("<PARAM NAME=\"EnableSearchControl\" VALUE=" + bSearch + ">");
	
	document.write("<PARAM NAME=\"EnableZoomControl\" VALUE=" + bZoom + ">");
	document.write("<PARAM NAME=\"EnableSearchExpertButton\" VALUE=" + bSearchExpert + ">");
	document.write("<PARAM NAME=\"EnableSelectExpertButton\" VALUE=" + bSelectExpert + ">");
	document.write("</OBJECT>");

	document.write("<OBJECT ID=\"ReportSource\"");
	document.write("CLASSID=\"CLSID:010068CD-0767-44C7-A205-4753009DAD6D\"");
	document.write("HEIGHT=\"1%\" WIDTH=\"1%\"");
	document.write("CODEBASE=\"" + gPath + viewerPath + "ActiveXControls/ActiveXViewer.cab#Version=" + sViewerVer + "\">");
	document.write("</OBJECT>");

	document.write("<OBJECT ID=\"ViewHelp\"");
	document.write("CLASSID=\"CLSID:D2C591F8-C922-4591-95F4-6094BCAD5B50\"");
	document.write("HEIGHT=\"1%\" WIDTH=\"1%\"");
	document.write("CODEBASE=\"" + gPath + viewerPath + "ActiveXControls/ActiveXViewer.cab#Version=" + sViewerVer + "\">");
	document.write("</OBJECT>");	
}

var jspath2 = document.all.item("jspath2");
if (jspath2.src == "http://")
	jspath2.src = jspath.src;
