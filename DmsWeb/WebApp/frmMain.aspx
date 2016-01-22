<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmMain.aspx.vb" Inherits="WebApp_frmDocRegis" %>

<%@ Register Src="~/Template/ucHeader_Page.ascx" TagName="ucHeader" TagPrefix="ucHeader" %>
<!DOCTYPE html>

<html>
<head>
 <link href="../css/screen.css" media="screen" rel="stylesheet" type="text/css" />
 <link href="../css/frm.css" media="screen" rel="stylesheet" type="text/css" />
 <link href="../css/input.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="calendar/calendar.css" rel="stylesheet" type="text/css" />
    <script src="calendar/calendar.js" type="text/javascript"></script>
    <script src="calendar/calendar-th.js" type="text/javascript"></script>
    <script src="calendar/loadcalendar.js" type="text/javascript"></script>
    <script src="js/callDialog.js" type="text/javascript"></script>
    
    <link  href="../logoboi.ico" rel="shortcut icon" />
    <title>BOI-DMS : ระบบสารบรรณอิเล็กทรอนิกส์</title>
    <meta charset="UTF-8">
    <title></title>
</head>
<body topmargin="0">
    <form id="form1" runat="server">
    <ucHeader:ucHeader ID="ucHeader" runat="server" />
  <div id="container" class="clearfix">
		
		<div id="breadcrumb">
			<ul id="current_location" runat="server">
				<li>Document Register</li>			 
			</ul>
		</div>
		  
		<div id="content2">
			<div></div>
			<div class="mh">
				<!--<ul id="tabs" class="clearfix">
					<li><a id="tab-1" class="tabs1green currentTab" onClick="switchTab(1);" href="content_inner1_sshe.aspx" target="frm"></a></li>					 
				</ul>-->
				<div class="wrapFrameContent blue" id="line_actived">
					<iframe allowtransparency="true" frameborder="0" id="frmContent" title="content_main" name="frm" scrolling="auto" height="1000px" src="frmDocToDoList.aspx" width="940px" frameborder=0></iframe>
				</div>
			</div>
			<div></div>
		</div>
	    
	</div>
    </form>
        <script src="../ecma/framework.js" type="text/javascript"></script>
    <script src="../ecma/script.js" type="text/javascript"></script>
    <script type="text/javascript">
        function setFrameHeight(h){ $('iframe#frmContent').css('height', h); }
    </script>
</body>
</html>
